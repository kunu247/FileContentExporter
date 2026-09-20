using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace FileContentExporter
{
    /// <summary>
    /// Borderless "please wait" card with a gradient arc spinner. It runs on its own UI thread
    /// (see WaitScope), so the animation keeps moving while the main thread is busy.
    /// </summary>
    [DesignerCategory("Code")]
    internal sealed class WaitForm : Form
    {
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        private static readonly Font TitleFont = new Font("Segoe UI Semibold", 10.5f);
        private static readonly Font DetailFont = new Font("Segoe UI", 8.5f);

        private readonly System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer { Interval = 15 };
        private readonly Stopwatch _clock;
        private readonly Rectangle _ring = new Rectangle(26, 28, 40, 40);
        private readonly Pen _trackPen = new Pen(DraculaTheme.CurrentLine, 4f);
        private readonly Pen _borderPen = new Pen(DraculaTheme.Comment);
        private readonly LinearGradientBrush _arcBrush;
        private readonly Pen _arcPen;
        private string _message = "Please wait…";

        public WaitForm(Rectangle ownerBounds, Stopwatch clock)
        {
            _clock = clock;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            TopMost = true;
            Cursor = Cursors.AppStarting;
            BackColor = DraculaTheme.Background;
            ClientSize = new Size(300, 96);
            Location = new Point(
                ownerBounds.Left + (ownerBounds.Width - Width) / 2,
                ownerBounds.Top + (ownerBounds.Height - Height) / 2);

            _arcBrush = new LinearGradientBrush(_ring, DraculaTheme.Purple, DraculaTheme.Cyan, 45f)
            {
                WrapMode = WrapMode.TileFlipXY
            };
            _arcPen = new Pen(_arcBrush, 4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };

            _timer.Tick += (s, e) => Invalidate();
        }

        // Never steal focus from the main window, and stay out of the taskbar / Alt+Tab.
        protected override bool ShowWithoutActivation { get { return true; } }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TOOLWINDOW | WS_EX_NOACTIVATE;
                return cp;
            }
        }

        // Must be called on this form's thread (WaitScope marshals it).
        public void SetMessage(string message)
        {
            _message = message;
            Invalidate();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(DraculaTheme.Background);
            g.DrawRectangle(_borderPen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);

            double t = _clock.Elapsed.TotalSeconds;

            // Track ring plus an arc that spins while it stretches and shrinks (Material-style).
            g.DrawEllipse(_trackPen, _ring);
            float start = (float)(t * 320.0 % 360.0);
            float sweep = 40f + 200f * (float)(0.5 - 0.5 * Math.Cos(t * 3.2));
            g.DrawArc(_arcPen, _ring, start, sweep);

            const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                                          TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding;
            TextRenderer.DrawText(g, _message, TitleFont, new Rectangle(84, 26, 200, 22),
                DraculaTheme.Foreground, flags);
            TextRenderer.DrawText(g, t.ToString("0.0") + " s elapsed", DetailFont, new Rectangle(84, 50, 200, 18),
                DraculaTheme.Comment, flags);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timer.Dispose();
                _arcPen.Dispose();
                _arcBrush.Dispose();
                _trackPen.Dispose();
                _borderPen.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// Usage:  using (var wait = WaitScope.Begin(this, "Loading…")) { ...work...; wait.Update("Almost there…"); }
    /// The card only appears if the work takes longer than delayMs, so quick operations never flash it.
    /// </summary>
    internal sealed class WaitScope : IDisposable
    {
        private const int DefaultDelayMs = 200;

        private readonly Form _owner;
        private readonly Thread _thread;
        private readonly Stopwatch _clock = Stopwatch.StartNew();
        private readonly ManualResetEventSlim _done = new ManualResetEventSlim(false);
        private readonly object _sync = new object();
        private WaitForm _form;
        private string _message;

        private WaitScope(Form owner, string message, int delayMs)
        {
            _owner = owner;
            _message = message;
            _owner.UseWaitCursor = true;

            Rectangle bounds = owner.WindowState == FormWindowState.Minimized
                ? Screen.FromControl(owner).WorkingArea
                : owner.Bounds;

            _thread = new Thread(() => Run(bounds, delayMs)) { IsBackground = true, Name = "WaitForm UI" };
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        public static WaitScope Begin(Form owner, string message, int delayMs = DefaultDelayMs)
        {
            return new WaitScope(owner, message, delayMs);
        }

        public void Update(string message)
        {
            WaitForm form;
            lock (_sync)
            {
                _message = message;
                form = _form;
            }
            if (form == null) return;

            try { form.BeginInvoke(new Action<string>(form.SetMessage), message); }
            catch (InvalidOperationException) { }
            // catch (ObjectDisposedException) { }
        }

        private void Run(Rectangle ownerBounds, int delayMs)
        {
            WaitForm form = null;
            try
            {
                form = new WaitForm(ownerBounds, _clock);
                if (form.Handle == IntPtr.Zero) return;   // create the window now; the delay below hides the cost

                if (_done.Wait(delayMs)) return;          // work finished first: never show anything

                lock (_sync)
                {
                    if (_done.IsSet) return;
                    form.SetMessage(_message);
                    _form = form;
                }
                Application.Run(form);
            }
            catch
            {
                // The wait card is cosmetic; it must never take the app down.
            }
            finally
            {
                lock (_sync) { _form = null; }
                if (form != null) form.Dispose();
            }
        }

        public void Dispose()
        {
            WaitForm form;
            lock (_sync)
            {
                if (_done.IsSet) return;
                _done.Set();
                form = _form;
            }

            if (form != null)
            {
                try { form.BeginInvoke(new Action(form.Close)); }
                catch (InvalidOperationException) { }
                // catch (ObjectDisposedException) { }
            }

            _thread.Join(2000);                  // card is gone before any MessageBox that follows
            _owner.UseWaitCursor = false;
        }
    }
}
