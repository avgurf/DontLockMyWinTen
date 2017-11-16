using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DontLockMyWinTen
{
    public partial class Form1 : Form
    {
        public const uint ES_CONTINUOUS = 0x80000000;
        public const uint ES_SYSTEM_REQUIRED = 0x00000001;
        public const uint ES_DISPLAY_REQUIRED = 0x00000002;
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint SetThreadExecutionState([In] uint esFlags);

        public const string SHOW_TXT = "Show";
        public const string HIDE_TXT = "Hide";

        public bool showBalloon = true;

        public Form1()
        {
            InitializeComponent();

            SetThreadExecutionState(ES_CONTINUOUS | ES_DISPLAY_REQUIRED);

            this.showOrHideToolStripMenuItem.Text = SHOW_TXT;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            HandleAppClosed();
        }

        private void HandleAppClosed()
        {
            SetThreadExecutionState(ES_CONTINUOUS | ES_DISPLAY_REQUIRED);
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.HideWindow();
        }

        private void HideWindow()
        {
            // Show balloon only in the first time
            if (this.showBalloon)
            {
                this.notifyIcon1.ShowBalloonTip(500);
                this.showBalloon = false;
            }
            this.Hide();
            this.showOrHideToolStripMenuItem.Text = SHOW_TXT;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ToggleShowOrHide();
        }

        private void RestoreWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.showOrHideToolStripMenuItem.Text = HIDE_TXT;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.HandleAppClosed();
        }

        private void showOrHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ToggleShowOrHide();
        }

        private void ToggleShowOrHide()
        {
            if (this.showOrHideToolStripMenuItem.Text == HIDE_TXT)
            {
                this.WindowState = FormWindowState.Minimized;
                this.HideWindow();
            }
            else
            {
                this.RestoreWindow();
            }
        }

    }
}
