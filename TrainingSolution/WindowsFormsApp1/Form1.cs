using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.webBrowser.CanGoBackChanged += WebBrowser_CanGoBackChanged;
            this.webBrowser.CanGoForwardChanged += WebBrowser_CanGoForwardChanged;
            this.BtnBack.Enabled = this.webBrowser.CanGoBack;
            this.BtnForward.Enabled = this.webBrowser.CanGoForward;
        }

        private void WebBrowser_CanGoForwardChanged(object sender, EventArgs e)
        {
            this.BtnForward.Enabled = this.webBrowser.CanGoForward;
        }

        private void WebBrowser_CanGoBackChanged(object sender, EventArgs e)
        {
            this.BtnBack.Enabled = this.webBrowser.CanGoBack;
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            this.webBrowser.Navigate(this.TxtAddressBar.Text);
        }

        private void TxtAddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.webBrowser.Navigate(this.TxtAddressBar.Text);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (this.webBrowser.CanGoBack)
                this.webBrowser.GoBack();
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            if (this.webBrowser.CanGoForward)
                this.webBrowser.GoForward();
        }
    }
}
