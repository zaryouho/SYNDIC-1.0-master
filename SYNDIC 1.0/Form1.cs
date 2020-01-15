using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SYNDIC_1._0
{
    public partial class frmMenuOfficiel : Form
    {
        public frmMenuOfficiel()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnSlideBar_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 265)
                MenuVertical.Width = 65;
            else
                MenuVertical.Width = 265;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestaure.Visible = true;
            btnMaximized.Visible = false;
        }

        private void btnRestaure_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaure.Visible = false;
            btnMaximized.Visible = true;

        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void BarreTitulaire_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenFormInPannel(object formChild)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);

            Form frmchild = formChild as Form;
            frmchild.TopLevel = false;
            frmchild.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(frmchild);
            this.panelContainer.Tag = frmchild;
            frmchild.Show();            
        }

        private void buttonBiens_Click(object sender, EventArgs e)
        {
            OpenFormInPannel(new frmBiens());
        }

        private void buttonProprietaires_Click(object sender, EventArgs e)
        {
            OpenFormInPannel(new frmProprietaires());
        }

        private void buttonFinances_Click(object sender, EventArgs e)
        {
            OpenFormInPannel(new frmFinances());
        }

        private void buttonDocuments_Click(object sender, EventArgs e)
        {
            OpenFormInPannel(new frmDocuments());
        }

        private void buttonHistoriques_Click(object sender, EventArgs e)
        {
            OpenFormInPannel(new frmHistoriques());
        }

        private void buttonRapportsStatistiques_Click(object sender, EventArgs e)
        {
            OpenFormInPannel(new frmRapportsStatistiques());
        }

        private void buttonBiens_MouseEnter(object sender, EventArgs e)
        {
            hidePanelsSubMenus();
            panelSsBiens.Visible = true;
        }

        private void buttonBiens_MouseLeave(object sender, EventArgs e)
        {            
            hidePanelSubMenus(panelSsBiens);
        }

        private void panelSsBiens_MouseEnter(object sender, EventArgs e)
        {
            panelSsBiens.Visible = true;
        }

        private void MenuVertical_MouseEnter(object sender, EventArgs e)
        {
            hidePanelsSubMenus();
        }

        

        private void panelContainer_MouseEnter(object sender, EventArgs e)
        {
            hidePanelsSubMenus();
        }
        
        public void hidePanelsSubMenus()
        {
            panelSsBiens.Visible = false;
            panelSsProprietaires.Visible = false;
            panelSsFinances.Visible = false;
            panelSsDocuments.Visible = false;
        }
        public void hidePanelSubMenus(Panel panelToHide)
        {
            if (Cursor.Position.X < MenuVertical.Location.X + MenuVertical.Width - 1)
                panelToHide.Visible = false;
            else
                panelToHide.Visible = true;
        }

        private void buttonProprietaires_MouseEnter(object sender, EventArgs e)
        {
            panelSsProprietaires.Visible = true;
        }

        private void buttonProprietaires_MouseLeave(object sender, EventArgs e)
        {
            hidePanelSubMenus(panelSsProprietaires);
        }

        private void buttonFinances_MouseEnter(object sender, EventArgs e)
        {           
            panelSsFinances.Visible = true;
        }

        private void buttonFinances_MouseLeave(object sender, EventArgs e)
        {
            hidePanelSubMenus(panelSsFinances);
        }

        private void buttonDocuments_MouseEnter(object sender, EventArgs e)
        {
            panelSsDocuments.Visible = true;
        }

        private void buttonDocuments_MouseLeave(object sender, EventArgs e)
        {
            hidePanelSubMenus(panelSsDocuments);
        }
    }
}
