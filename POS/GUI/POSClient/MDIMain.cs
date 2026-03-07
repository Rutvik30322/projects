using NDatabaseAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSClient
{
    public partial class MDIMain : Form
    {
        #region "Private Variables"

        private AuditRecords _objAuditRecords = null;
        private int childFormNumber = 0;
        private string _auditText = "";
        private string _userName = "";
        #endregion

        #region "Constructor/Destructor"
        public MDIMain()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
            tsslLoginDateTime.Text = DateTime.Now.ToString();
            tsslCapsLock.Text = "CAPS LOCK: " + (Control.IsKeyLocked(Keys.CapsLock) ? "ON" : "OFF");
            tsslNumLock.Text = "NUM LOCK: " + (Control.IsKeyLocked(Keys.NumLock) ? "ON" : "OFF");
            tsslStationValue.Text = GeneralObjects.stationName;
        }

        ~MDIMain()
        {
            if (_objAuditRecords != null)
                _objAuditRecords = null;
        }
        #endregion

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region "Set Theme"
        private void SetTheme()
        {
            this.BackColor = Themes.FormBackColor;
            //Home Button
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.BackColor = Themes.ButtonBackColor;
            btnHome.ForeColor = Themes.ButtonForeColor;
            btnHome.FlatAppearance.BorderSize = 1;
            btnHome.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Purchase Button
            btnPurchase.FlatStyle = FlatStyle.Flat;
            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnPurchase.ForeColor = Themes.ButtonForeColor;
            btnPurchase.FlatAppearance.BorderSize = 1;
            btnPurchase.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Sales Button
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnSales.ForeColor = Themes.ButtonForeColor;
            btnSales.FlatAppearance.BorderSize = 1;
            btnSales.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Material Button
            btnMaterial.FlatStyle = FlatStyle.Flat;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnMaterial.ForeColor = Themes.ButtonForeColor;
            btnMaterial.FlatAppearance.BorderSize = 1;
            btnMaterial.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Users Button
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnUsers.ForeColor = Themes.ButtonForeColor;
            btnUsers.FlatAppearance.BorderSize = 1;
            btnUsers.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Reports Button
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnReports.ForeColor = Themes.ButtonForeColor;
            btnReports.FlatAppearance.BorderSize = 1;
            btnReports.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Backup Button
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnBackup.ForeColor = Themes.ButtonForeColor;
            btnBackup.FlatAppearance.BorderSize = 1;
            btnBackup.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //UOM Button
            btnUOM.FlatStyle = FlatStyle.Flat;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUOM.ForeColor = Themes.ButtonForeColor;
            btnUOM.FlatAppearance.BorderSize = 1;
            btnUOM.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Inventory Button
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnInventory.ForeColor = Themes.ButtonForeColor;
            btnInventory.FlatAppearance.BorderSize = 1;
            btnInventory.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Settings Button
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnSettings.ForeColor = Themes.ButtonForeColor;
            btnSettings.FlatAppearance.BorderSize = 1;
            btnSettings.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Audits Button
            btnAudits.FlatStyle = FlatStyle.Flat;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnAudits.ForeColor = Themes.ButtonForeColor;
            btnAudits.FlatAppearance.BorderSize = 1;
            btnAudits.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Logout Button
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnLogout.ForeColor = Themes.ButtonForeColor;
            btnLogout.FlatAppearance.BorderSize = 1;
            btnLogout.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            //Exit Button
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.BackColor = Themes.ButtonBackColor;
            btnExit.ForeColor = Themes.ButtonForeColor;
            btnExit.FlatAppearance.BorderSize = 1;
            btnExit.FlatAppearance.BorderColor = Themes.ButtonBorderColor;
        }
        #endregion

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIMain_Load(object sender, EventArgs e)
        {
            //tsslLoginDateTime.Text = DateTime.Now.ToString();
            _objAuditRecords = new AuditRecords(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            tsslUser.Text = GeneralObjects.UserName;
            frmHome objHome = new frmHome();
            OpenChildForm(objHome);
        }

        public void OpenChildForm(Form objForm)
        {
            try
            {
                Form objFormCtrl = null;

                foreach (Control ctrl in this.pnlContainer.Controls)
                {
                    objFormCtrl = ctrl.FindForm();
                    objFormCtrl.Close();

                    pnlContainer.Controls.Remove(ctrl);
                }

                objForm.TopLevel = false;
                pnlContainer.Controls.Add(objForm);
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                objForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //GeneralObjects.ErrLogger.WritetoLogFile("MDIMain : Open Child Form");
                //GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void MDIMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnHome.BackColor = Themes.ButtonActiveBackColor;

                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnHome_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnPurchase.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnPurchase_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnSales.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnSales_Click(null, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnInventory.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnInventory_Click(null, null);
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnMaterial.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnMaterial_Click(null, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnUOM.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnUOM_Click(null, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnUsers.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnUsers_Click(null, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnReports.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnReports_Click(null, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnBackup.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                //btnBackup_Click(null, null);
            }
            //UOM
            else if (e.KeyCode == Keys.F10)
            {
                btnSettings.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnAudits.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnSettings_Click(null, null);
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnAudits.BackColor = Themes.ButtonActiveBackColor;

                btnHome.BackColor = Themes.ButtonBackColor;
                btnPurchase.BackColor = Themes.ButtonBackColor;
                btnSales.BackColor = Themes.ButtonBackColor;
                btnInventory.BackColor = Themes.ButtonBackColor;
                btnMaterial.BackColor = Themes.ButtonBackColor;
                btnUOM.BackColor = Themes.ButtonBackColor;
                btnUsers.BackColor = Themes.ButtonBackColor;
                btnReports.BackColor = Themes.ButtonBackColor;
                btnBackup.BackColor = Themes.ButtonBackColor;
                btnSettings.BackColor = Themes.ButtonBackColor;
                btnLogout.BackColor = Themes.ButtonBackColor;
                btnExit.BackColor = Themes.ButtonBackColor;
                btnAudits_Click(null, null);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            btnHome.BackColor = Themes.ButtonActiveBackColor;

            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            frmHome frmFormName = new frmHome();
            OpenChildForm(frmFormName);
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            btnPurchase.BackColor = Themes.ButtonActiveBackColor;

            btnHome.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            GeneralObjects.isNavigating = true;
            frmPurchase objPurchase = new frmPurchase();
            OpenChildForm(objPurchase);
        }
        private void btnSales_Click(object sender, EventArgs e)
        {
            btnSales.BackColor = Themes.ButtonActiveBackColor;

            btnHome.BackColor = Themes.ButtonBackColor;
            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            GeneralObjects.isNavigating = true;
            frmSales objSales = new frmSales();
            OpenChildForm(objSales);
        }
        private void btnMaterial_Click(object sender, EventArgs e)
        {
            btnMaterial.BackColor = Themes.ButtonActiveBackColor;

            btnHome.BackColor = Themes.ButtonBackColor;
            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            GeneralObjects.isNavigating = true;
            frmMaterial objMaterial = new frmMaterial();
            OpenChildForm(objMaterial);
        }
        private void MDIMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GeneralObjects.isNavigating = true;
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GeneralObjects.isNavigating = true;
            Application.Exit();
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            btnUsers.BackColor = Themes.ButtonActiveBackColor;

            btnHome.BackColor = Themes.ButtonBackColor;
            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            GeneralObjects.isNavigating = true;
            frmUsers objuser = new frmUsers();
            OpenChildForm(objuser);
        }

        private void MDIMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
                tsslCapsLock.Text = "CAPS LOCK: " + (Control.IsKeyLocked(Keys.CapsLock) ? "ON" : "OFF");

            if(e.KeyCode == Keys.NumLock)
                tsslNumLock.Text = "NUM LOCK: " + (Control.IsKeyLocked(Keys.NumLock) ? "ON" : "OFF");
        }

        private void btnUOM_Click(object sender, EventArgs e)
        {
            btnUOM.BackColor = Themes.ButtonActiveBackColor;

            btnHome.BackColor = Themes.ButtonBackColor;
            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            GeneralObjects.isNavigating = true;
            frmUOM objUOM = new frmUOM();
            OpenChildForm(objUOM);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            btnInventory.BackColor = Themes.ButtonActiveBackColor;

            btnHome.BackColor = Themes.ButtonBackColor;
            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            GeneralObjects.isNavigating = true;
            frmInventory objInventory = new frmInventory();
            OpenChildForm(objInventory);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log off?", "BespokeERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GeneralObjects.isNavigating = true;
                _userName = GeneralObjects.FirstName + " " + GeneralObjects.LastName;
                _auditText = "User logged out successfully.";
                _objAuditRecords.SetAuditRecords(_auditText, _userName, "Logout", Environment.MachineName);
                this.Hide(); // Hide the current form
                Login login = new Login();
                login.Show(); // or ShowDialog() if you want it modal
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            btnReports.BackColor = Themes.ButtonActiveBackColor;

            btnHome.BackColor = Themes.ButtonBackColor;
            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            GeneralObjects.isNavigating = true;
            frmReport objreport = new frmReport();
            OpenChildForm(objreport);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnSettings.BackColor = Themes.ButtonActiveBackColor;

            btnHome.BackColor = Themes.ButtonBackColor;
            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            GeneralObjects.isNavigating = true;
            frmSettings objsettings = new frmSettings();
            OpenChildForm(objsettings);
        }

        private void btnAudits_Click(object sender, EventArgs e)
        {
            btnAudits.BackColor = Themes.ButtonActiveBackColor;

            btnHome.BackColor = Themes.ButtonBackColor;
            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;

            GeneralObjects.isNavigating = true;
            frmAuditRecords objAuditRecords = new frmAuditRecords();
            OpenChildForm(objAuditRecords);
        }

        private void MDIMain_Activated(object sender, EventArgs e)
        {
            GeneralObjects.isNavigating = false;

            btnHome.BackColor = Themes.ButtonActiveBackColor;

            btnPurchase.BackColor = Themes.ButtonBackColor;
            btnSales.BackColor = Themes.ButtonBackColor;
            btnInventory.BackColor = Themes.ButtonBackColor;
            btnMaterial.BackColor = Themes.ButtonBackColor;
            btnUOM.BackColor = Themes.ButtonBackColor;
            btnUsers.BackColor = Themes.ButtonBackColor;
            btnReports.BackColor = Themes.ButtonBackColor;
            btnBackup.BackColor = Themes.ButtonBackColor;
            btnSettings.BackColor = Themes.ButtonBackColor;
            btnAudits.BackColor = Themes.ButtonBackColor;
            btnLogout.BackColor = Themes.ButtonBackColor;
            btnExit.BackColor = Themes.ButtonBackColor;
        }
    }
}
