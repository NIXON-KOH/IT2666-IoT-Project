using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public partial class CustomForm : Form
{
    private const int HTLEFT = 10;
    private const int HTRIGHT = 11;
    private const int HTTOP = 12;
    private const int HTTOPLEFT = 13;
    private const int HTTOPRIGHT = 14;
    private const int HTBOTTOM = 15;
    private const int HTBOTTOMLEFT = 16;
    private const int HTBOTTOMRIGHT = 17;
    private const int WM_NCHITTEST = 0x84;

    private const int HTCLIENT = 1;
    private const int HTCAPTION = 2;

    private int _resizeBorderThickness = 10; // Thickness of the resize area in pixels

    private Panel titleBar;
    private PictureBox btnClose;
    private PictureBox btnMinimize;
    private PictureBox btnFullscreen;

    public CustomForm()
    {

        // Set FormBorderStyle to None for a borderless form
        this.FormBorderStyle = FormBorderStyle.None;

        // Enable double buffering for smooth rendering
        this.DoubleBuffered = true;

        InitializeTitleBar();
    }

    private void InitializeTitleBar()
    {
        titleBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 30,
            BackColor = Color.Aqua 
        };
        titleBar.MouseDown += (s, e) =>
        {
            // Enable dragging the form via the title bar
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, HTCAPTION, 0);
            }
        };
        btnClose = new PictureBox
        {
            Size = new Size(30, 30),
            Dock = DockStyle.Right,
            SizeMode = PictureBoxSizeMode.CenterImage,
            Cursor = Cursors.Hand
        };
        btnClose.Click += (s, e) => this.Close();

        // Minimize 
        btnMinimize = new PictureBox
        {
            Size = new Size(30, 30),
            Dock = DockStyle.Right,
            SizeMode = PictureBoxSizeMode.CenterImage,
            Cursor = Cursors.Hand
        };
        btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

        // Fullscreen 
        btnFullscreen = new PictureBox
        {
            Size = new Size(30, 30),
            Dock = DockStyle.Right,
            SizeMode = PictureBoxSizeMode.CenterImage,
            Cursor = Cursors.Hand
        };
        btnFullscreen.Click += (s, e) =>
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized
                ? FormWindowState.Normal
                : FormWindowState.Maximized;
        };

        // Images 
        btnClose.Image = WindowsFormsApplication1.Properties.Resources.cross;
        btnFullscreen.Image = WindowsFormsApplication1.Properties.Resources.fullscreen;
        btnMinimize.Image = WindowsFormsApplication1.Properties.Resources.minimize;

        titleBar.Controls.Add(btnMinimize);
        titleBar.Controls.Add(btnFullscreen);
        titleBar.Controls.Add(btnClose);
        this.Controls.Add(titleBar);
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        if (m.Msg == WM_NCHITTEST)
        {
            Point cursor = PointToClient(Cursor.Position);

            if (cursor.X < _resizeBorderThickness && cursor.Y < _resizeBorderThickness)
                m.Result = (IntPtr)HTTOPLEFT;
            else if (cursor.X > Width - _resizeBorderThickness && cursor.Y < _resizeBorderThickness)
                m.Result = (IntPtr)HTTOPRIGHT;
            else if (cursor.X < _resizeBorderThickness && cursor.Y > Height - _resizeBorderThickness)
                m.Result = (IntPtr)HTBOTTOMLEFT;
            else if (cursor.X > Width - _resizeBorderThickness && cursor.Y > Height - _resizeBorderThickness)
                m.Result = (IntPtr)HTBOTTOMRIGHT;
            else if (cursor.X < _resizeBorderThickness)
                m.Result = (IntPtr)HTLEFT;
            else if (cursor.X > Width - _resizeBorderThickness)
                m.Result = (IntPtr)HTRIGHT;
            else if (cursor.Y < _resizeBorderThickness)
                m.Result = (IntPtr)HTTOP;
            else if (cursor.Y > Height - _resizeBorderThickness)
                m.Result = (IntPtr)HTBOTTOM;
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }
    }

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // CustomForm
            // 
            this.ClientSize = new System.Drawing.Size(862, 486);
            this.Name = "CustomForm";
            this.Load += new System.EventHandler(this.CustomForm_Load);
            this.ResumeLayout(false);

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void CustomForm_Load(object sender, EventArgs e)
    {

    }
}
