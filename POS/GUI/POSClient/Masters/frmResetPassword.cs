using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NDatabaseAccess;

namespace POSClient
{
    public partial class frmResetPassword : Form
    {
        SaltGenerator _objSaltGenerator;

        #region "private Variable"
        Users _objUsers = null;
        private int _CellClickUserId = 0;
        private string _FirstName;
        private string _LastName;

        #endregion

        #region "Constructor/Destructor"
        public frmResetPassword()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }

        ~frmResetPassword()
        {
            if (_objUsers != null)
                _objUsers = null;
        }

        #endregion

        #region "Set Theme"
        private void SetTheme()
        {
            //Form
            this.BackColor = Themes.FormBackColor;

            //Header
            btnHeader.BackColor = Themes.HeaderBackColor;
            btnHeader.ForeColor = Themes.HeaderForeColor;
            btnHeader.FlatStyle = FlatStyle.Flat;
            btnHeader.FlatAppearance.BorderSize = 1;
            btnHeader.FlatAppearance.BorderColor = Themes.HeaderBorderColor;

            Themes.DataGridTheme(dgvResetRequest);
        }

        private void BindResetReqGrid()
        {
            DataTable objDataTable = _objUsers.GetUserDetailsForResetPassword();
            if (objDataTable != null && objDataTable.Rows.Count > 0)
            {
                dgvResetRequest.DataSource = objDataTable;
                dgvResetRequest.Columns["Id"].Visible = false;

                //Set Column Header Text
                dgvResetRequest.Columns["UserName"].HeaderText = "User Name";
                dgvResetRequest.Columns["FirstName"].HeaderText = "First Name";
                dgvResetRequest.Columns["LastName"].HeaderText = "Last Name";
                dgvResetRequest.Columns["ExpiryDate"].HeaderText = "Expiry Date";
                dgvResetRequest.Columns["ResetPasswordRequestDate"].HeaderText = "Request Date & Time";

                //Alignment Set in Data Grid View
                dgvResetRequest.Columns["Sr No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvResetRequest.Columns["UserName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvResetRequest.Columns["FirstName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvResetRequest.Columns["LastName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvResetRequest.Columns["ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvResetRequest.Columns["ResetPasswordRequestDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //Auto Size Column Mode
                dgvResetRequest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvResetRequest.Columns["Sr No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvResetRequest.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvResetRequest.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvResetRequest.Columns["LastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvResetRequest.Columns["ExpiryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvResetRequest.Columns["ResetPasswordRequestDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvResetRequest.Columns["Reset"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                //Width in Date Grid View
                dgvResetRequest.Columns["Sr No."].Width = 70;
                dgvResetRequest.Columns["FirstName"].Width = 200;
                dgvResetRequest.Columns["LastName"].Width = 200;
                dgvResetRequest.Columns["ExpiryDate"].Width = 150;
                dgvResetRequest.Columns["ResetPasswordRequestDate"].Width = 200;
                dgvResetRequest.Columns["Reset"].Width = 80;

                //Width in Date Grid View
                dgvResetRequest.Columns["Sr No."].Width = 70;
            }
            else
            {
                dgvResetRequest.DataSource = null;
            }
        }
        #endregion

        private void RefreshResetReqGrid(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvResetRequest.Rows[e.RowIndex];
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Reset Password : RefreshResetReqGrid");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }

        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {
            btnHeader.Focus();
            try
            {
                _objUsers = new Users(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                BindResetReqGrid();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Reset Password : frmResetPassword_Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void dgvResetRequest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshResetReqGrid(sender, e);
        }

        private void dgvResetRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                _CellClickUserId = Convert.ToInt32(dgvResetRequest.Rows[e.RowIndex].Cells["Id"].Value);
                _FirstName = Convert.ToString(dgvResetRequest.Rows[e.RowIndex].Cells["FirstName"].Value);
                _LastName = Convert.ToString(dgvResetRequest.Rows[e.RowIndex].Cells["LastName"].Value);

                //Call Reset Password function called
                DialogResult result = MessageBox.Show(
                   "Are you sure you want to reset the password for " + _FirstName + ' ' + _LastName + " ?",
                   "Reset Password",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information
               ) ;

                if (result == DialogResult.Yes)
                {
                    ResetPassword(); // Call your Save UOM function here
                }


            }
        }

        private void dgvResetRequest_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var dataGridView = (sender as DataGridView);
            if (e.ColumnIndex == 7)
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Default;
        }

        private void dgvResetRequest_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            try
            {
                if (e.ColumnIndex == 7)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.PaintBackground(e.ClipBounds, false);

                    var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                    //e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, w, h));
                    e.Graphics.DrawImage(Properties.Resources.refresh_24, new Rectangle(x, y, 20, 20));
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Reset Password : dgvResetRequest_CellPainting");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void ResetPassword()
        {
            _objSaltGenerator = new SaltGenerator();
            string defaultpwd = "Admin";
            //Password Salt
            string PasswordSalt = _objSaltGenerator.GenerateSalt();
            string passwordWithSalt = PasswordSalt + defaultpwd;
            defaultpwd = _objSaltGenerator.HashPassword(passwordWithSalt);

            bool retValue = _objUsers.ResetUserPassword(_CellClickUserId, defaultpwd, PasswordSalt);
            if (retValue == true)
            {
                MessageBox.Show("Password has been reset to the default password 'Admin'. It is recommended to change your password after logging in.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindResetReqGrid();
            }
            else
            {
                MessageBox.Show("Failed to reset password", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmResetPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show("Are you sure you want to close this form? Any unsaved data will be lost.", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    MDIMain md = (MDIMain)(this.Parent.Parent);
                    frmUsers objUser = new frmUsers();
                    md.OpenChildForm(objUser);
                    this.Close();
                }
            }
        }
    }
}
