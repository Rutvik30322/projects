using NDatabaseAccess;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POSClient
{
    public partial class frmUsers : Form
    {
        #region "private Variable"
        Users _objUsers = null;
        GeneralDB _objGeneralDB = null;
        AuditRecords _objAuditRecords = null;

        private int _CellClickUserId = 0;
        private string _user = "";
        private string _auditText = "";
        private string _AudituserName = GeneralObjects.FirstName + " " + GeneralObjects.LastName;

        #endregion

        #region "Constructor/Destructor"
        public frmUsers()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }

        ~frmUsers()
        {
            if (_objUsers != null)
                _objUsers = null;

            if (_objGeneralDB != null)
                _objGeneralDB = null;

            if (_objAuditRecords != null)
                _objAuditRecords = null;

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

            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.BackColor = Themes.ButtonBackColor;
            btnAdd.ForeColor = Themes.ButtonForeColor;
            btnAdd.FlatAppearance.BorderSize = 1;
            btnAdd.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            lblShortcut.ForeColor = Themes.LabelForeColor;
            lblShortcut.BackColor = Themes.LabelBackColor;

            Themes.DataGridTheme(dgvUser);
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GeneralObjects.isNavigating = true;
            frmAddUsers adduserform = new frmAddUsers(0);
            DialogResult result = adduserform.ShowDialog(this);
            BindUserGrid();
        }

        private void RefreshUsersGrid(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvUser.Rows[e.RowIndex];
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Users : RefreshUsersGrid");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            btnAdd.Focus();
            try
            {
                _objUsers = new Users(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objGeneralDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objAuditRecords = new AuditRecords(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

                BindUserGrid();

                if(GeneralObjects.CurrentRoleType == 3)
                {
                    btnAdd.Visible = false;
                    btnResetPassword.Visible = false;
                    btnSAdd.Visible = false;
                    btnSResetList.Visible = false;
                    btnSEdit.Visible = false;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Users : Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void BindUserGrid()
        {
            //IF Role Type = 3 [User] then display only its own user other wise display all uses
            DataTable objDataTable = GeneralObjects.CurrentRoleType == 3
        ? _objUsers.GetUser(GeneralObjects.CurrentUserId, -1, GeneralObjects.CurrentRoleType)
        : _objUsers.GetUser(0, -1, GeneralObjects.CurrentRoleType);


            if (objDataTable != null && objDataTable.Rows.Count > 0)
            {
                dgvUser.DataSource = objDataTable;
                dgvUser.Columns["Id"].Visible = false;
                dgvUser.Columns["MobileNumber"].Visible = false;
                dgvUser.Columns["Password"].Visible = false;
                dgvUser.Columns["TransactionPassword"].Visible = false;
                dgvUser.Columns["Lastlogin"].Visible = false;
                dgvUser.Columns["OTPCode"].Visible = false;
                dgvUser.Columns["OTPExpiryDate"].Visible = false;
                dgvUser.Columns["IsActive"].Visible = false;
                dgvUser.Columns["ResetPasswordRequest"].Visible = false;
                dgvUser.Columns["ResetPasswordRequestDate"].Visible = false;
                dgvUser.Columns["UpdatedBy"].Visible = false;
                dgvUser.Columns["UpdatedByName"].Visible = false;
                dgvUser.Columns["UpdatedDate"].Visible = false;
                dgvUser.Columns["RoleId"].Visible = false;
                dgvUser.Columns["PasswordSalt"].Visible = false;

                //Set Column Header Text
                dgvUser.Columns["UserName"].HeaderText = "User Name";
                dgvUser.Columns["FirstName"].HeaderText = "First Name";
                dgvUser.Columns["LastName"].HeaderText = "Last Name";
                dgvUser.Columns["ExpiryDate"].HeaderText = "Expiry Date";
                dgvUser.Columns["RoleName"].HeaderText = "Role";
                dgvUser.Columns["Sr No."].HeaderText = "Sr. No.";


                //Alignment Set in Data Grid View
                dgvUser.Columns["Sr No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUser.Columns["UserName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUser.Columns["FirstName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUser.Columns["LastName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUser.Columns["ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUser.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


                //Auto Size Column Mode
                dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvUser.Columns["Sr No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUser.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill ;
                dgvUser.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUser.Columns["LastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUser.Columns["RoleName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUser.Columns["ExpiryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUser.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                if(GeneralObjects.CurrentRoleType != 3)
                {
                dgvUser.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }

                //Width in Date Grid View
                dgvUser.Columns["Sr No."].Width = 70;
                dgvUser.Columns["FirstName"].Width = 200;
                dgvUser.Columns["LastName"].Width = 200;
                dgvUser.Columns["RoleName"].Width = 100;
                dgvUser.Columns["ExpiryDate"].Width = 90;
                dgvUser.Columns["Status"].Width = 80;
                if (GeneralObjects.CurrentRoleType != 3)
                {
                    dgvUser.Columns["Edit"].Width = 50;
                }
               
            }
            else
            {
                dgvUser.DataSource = null;
            }
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshUsersGrid(sender, e);
        }

        private void dgvUser_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var dataGridView = (sender as DataGridView);
            if ( e.ColumnIndex == 21)
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Default;
        }

        private void dgvUser_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int status = Convert.ToInt32(dgvUser.Rows[e.RowIndex].Cells["IsActive"].Value); // Adjust column name if needed

                if (e.ColumnIndex == 21)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.PaintBackground(e.ClipBounds, false);

                    var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                    //e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, w, h));
                    if (status == 0)
                    {
                        e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, 20, 20)); // use a faded/disabled icon
                    }
                    else
                    {
                        e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, 20, 20));
                    }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("UOM : SetEditandDelete");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void dgvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 20 && e.Value != null)
            {
                if (Convert.ToString(e.Value) == "Active")
                {
                    e.CellStyle.BackColor = Color.FromArgb(198, 239, 206);
                }
                else if (Convert.ToString(e.Value) == "Inactive")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 199, 206);
                }
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on the column header row
            if (e.RowIndex < 0)
                return;

            _CellClickUserId = Convert.ToInt32(dgvUser.Rows[e.RowIndex].Cells["Id"].Value);
            _user = Convert.ToString(dgvUser.Rows[e.RowIndex].Cells["UserName"].Value);
            int status = Convert.ToInt32(dgvUser.Rows[e.RowIndex].Cells["IsActive"].Value);

            //RefreshUsersGrid(sender, e);
            if (e.ColumnIndex == 21) // Assuming column index 21 is the "Edit" button
            {
                if (status == 0)
                {
                    MessageBox.Show("This record is inactive and can't be edited right now.", "Action not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmAddUsers adduserform = new frmAddUsers(_CellClickUserId);
                DialogResult result = adduserform.ShowDialog(this);
                BindUserGrid();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            GeneralObjects.isNavigating = true;
            frmChangePassword changepwdform = new frmChangePassword();
            DialogResult result = changepwdform.ShowDialog(this);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                MDIMain md = (MDIMain)(this.Parent.Parent);
                frmResetPassword frmresetpwd = new frmResetPassword();
                md.OpenChildForm(frmresetpwd);
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("User : ResetPassword");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 20)
            {
                if (GeneralObjects.CurrentRoleType == 3)
                {
                    MessageBox.Show("You are not authorized to update the status.", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _CellClickUserId = Convert.ToInt32(dgvUser.Rows[e.RowIndex].Cells["Id"].Value);
                string _userName = dgvUser.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                string _fullName = dgvUser.Rows[e.RowIndex].Cells["FirstName"].Value.ToString() + " " + dgvUser.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                int _statusFlag = Convert.ToBoolean(dgvUser.Rows[e.RowIndex].Cells["IsActive"].Value) ? 1 : 0;
                bool _statusValue = Convert.ToBoolean(dgvUser.Rows[e.RowIndex].Cells["IsActive"].Value);

                try
                {
                    DialogResult result;

                    if (_statusValue) // Currently Active
                    {
                        result = MessageBox.Show($"Are you sure you want to InActive {_fullName}?", "Change Status",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 0;
                            bool retFlag = _objGeneralDB.SetActiveInActiveStatus("Users", _CellClickUserId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "User : " + _user + " Inactive successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _AudituserName, this.Text, Environment.MachineName);
                            }
                        }
                    }
                    else // Currently Inactive
                    {
                        result = MessageBox.Show($"Are you sure you want to Active {_fullName}?", "Change Status",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 1;
                            bool retFlag = _objGeneralDB.SetActiveInActiveStatus("Users", _CellClickUserId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "User : " + _user + " Active successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _AudituserName, this.Text, Environment.MachineName);
                            }
                        }
                    }

                    // Refresh the grid regardless of user choice
                    BindUserGrid();
                }

                catch (Exception ex)
                {
                    GeneralObjects.ErrLogger.WritetoLogFile("User : SetActiveInactive");
                    GeneralObjects.ErrLogger.WritetoLogFile(ex);
                }
            }
        }

        private void dgvUser_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.E))
            {
                if (dgvUser.CurrentCell != null) // && dgvMaterial.Columns[dgvMaterial.CurrentCell.ColumnIndex].Name == "Edit"
                {
                    dgvUser.ReadOnly = false;
                    dgvUser.BeginEdit(true);
                    e.SuppressKeyPress = true; // Stop further processing of the key

                    if (dgvUser.CurrentCell != null)
                    {
                        int rowIndex = dgvUser.CurrentCell.RowIndex;
                        int _userId = Convert.ToInt32(dgvUser.Rows[rowIndex].Cells["Id"].Value);
                        int status = Convert.ToInt32(dgvUser.Rows[rowIndex].Cells["IsActive"].Value);
                        if (status == 0)
                        {
                            MessageBox.Show("This record is inactive and can't be edited right now.", "Action not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        frmAddUsers adduserform = new frmAddUsers(_userId);
                        DialogResult result = adduserform.ShowDialog(this);
                        BindUserGrid();
                    }
                }
            }
        }

        private void frmUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show("Are you sure you want to close this form? Any unsaved data will be lost.", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    MDIMain md = (MDIMain)(this.Parent.Parent);
                    frmHome objHome = new frmHome();
                    md.OpenChildForm(objHome);
                    this.Close();
                }
            }
        }
    }
}
