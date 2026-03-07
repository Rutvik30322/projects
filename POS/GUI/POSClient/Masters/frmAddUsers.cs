using NDatabaseAccess;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace POSClient
{
    public partial class frmAddUsers : Form
    {
        SaltGenerator _objSaltGenerator;

        #region "Private Variable"
        Users objUsers = null;
        private int _CellClickuserId = 0;
        private DataTable _dtRoleMaster;
        #endregion

        #region "Constructor/Destructor"
        public frmAddUsers(int userId)
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
            _CellClickuserId = userId;
        }

        ~frmAddUsers()
        {
            if (objUsers != null)
                objUsers = null;
        }
        #endregion

        #region "Set Theme"
        private void SetTheme()
        {
            //Form
            this.BackColor = Themes.FormBackColor;

            //Label
            lblFirstName.ForeColor = Themes.LabelForeColor;
            lblFirstName.BackColor = Themes.LabelBackColor;
            lblLastName.ForeColor = Themes.LabelForeColor;
            lblLastName.BackColor = Themes.LabelBackColor;
            lblUserName.ForeColor = Themes.LabelForeColor;
            lblUserName.BackColor = Themes.LabelBackColor;
            lblPassword.ForeColor = Themes.LabelForeColor;
            lblPassword.BackColor = Themes.LabelBackColor;
            lblExpiryDate.ForeColor = Themes.LabelForeColor;
            lblExpiryDate.BackColor = Themes.LabelBackColor;
            lblRole.ForeColor = Themes.LabelForeColor;
            lblRole.BackColor = Themes.LabelBackColor;

            //Button Save & Cancel
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.BackColor = Themes.ButtonBackColor;
            btnCancel.ForeColor = Themes.ButtonForeColor;
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.BackColor = Themes.ButtonBackColor;
            btnSave.ForeColor = Themes.ButtonForeColor;
            btnSave.FlatAppearance.BorderSize = 1;
            btnSave.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

        }
        #endregion

        private void frmAddUsers_Load(object sender, EventArgs e)
        {
            objUsers = new Users(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            BindRoleCmb();

            if (_CellClickuserId == 0)
            {
                txtFirstName.Focus();
                cmbRole.SelectedIndex = 2;
            }
            else
            {
                txtUserName.Enabled = false;
                GetUserData(_CellClickuserId);
            }
        }

        private void GetUserData(int id)
        {
            try
            {
                DataTable objDataTable = objUsers.GetUser(id, -1, GeneralObjects.CurrentRoleType);
                if (objDataTable.Rows.Count > 0 && objDataTable != null)
                {
                    txtFirstName.Text = Convert.ToString(objDataTable.Rows[0]["FirstName"]);
                    txtlastName.Text = Convert.ToString(objDataTable.Rows[0]["LastName"]);
                    txtUserName.Text = Convert.ToString(objDataTable.Rows[0]["UserName"]);

                    // Make password field not editable and display bydefault star 
                    txtPassword.UseSystemPasswordChar = true;
                    txtPassword.Enabled = false;
                    txtPassword.ReadOnly = false;
                    txtPassword.Text = "********";

                    dtpExpiryDate.Text = Convert.ToString(objDataTable.Rows[0]["ExpiryDate"]);
                    cmbRole.Text = Convert.ToString(objDataTable.Rows[0]["RoleName"]);

                    _CellClickuserId = id;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("User : GetUserData");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void BindRoleCmb()
        {
            _dtRoleMaster = objUsers.GetRole(0, 1);
            if (_dtRoleMaster != null && _dtRoleMaster.Rows.Count > 0)
            {
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "Id";
                cmbRole.DataSource = _dtRoleMaster;
            }
        }

        public bool IsValidPassword(string password)
        {
            var pattern = @"^(?=.*[A-Z])(?=.*[a-zA-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        private bool ValidateDetails()
        {
            bool retFlag = true;
            try
            {
                if (txtFirstName.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter First Name", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Focus();
                    txtFirstName.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (txtlastName.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter Last Name", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtlastName.Focus();
                    txtlastName.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (txtUserName.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter User Name", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    txtUserName.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (txtPassword.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter Password", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    txtPassword.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (cmbRole.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Role", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return retFlag = false;
                }

                if (_CellClickuserId == 0)
                {
                    if (!IsValidPassword(txtPassword.Text))
                    {
                        MessageBox.Show("Password must be at least 8 characters long and include one uppercase letter, one special character, and alphanumeric characters.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Focus();
                        txtPassword.BackColor = Color.MistyRose;
                        return retFlag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("User : ValidateDetails");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _objSaltGenerator = new SaltGenerator();
            try
            {
                if (_CellClickuserId == 0)
                {
                    if (ValidateDetails())
                    {
                        //Password Salt
                        string PasswordSalt = _objSaltGenerator.GenerateSalt();
                        string passwordWithSalt = PasswordSalt + txtPassword.Text;
                        string addedpwd = _objSaltGenerator.HashPassword(passwordWithSalt);

                        int result = objUsers.SaveUser(txtFirstName.Text, txtlastName.Text, txtUserName.Text, addedpwd, dtpExpiryDate.Value, Convert.ToInt32(cmbRole.SelectedValue), PasswordSalt, GeneralObjects.CurrentUserId, GeneralObjects.stationName);
                        if (result == 1)
                        {
                            MessageBox.Show("User registered successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else if (result == -99)
                        {
                            MessageBox.Show("User Name Already exist", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Failed to registered User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                }

                else
                {
                    if (ValidateDetails())
                    {
                        int result = objUsers.UpdateUser(_CellClickuserId, txtFirstName.Text, txtlastName.Text, dtpExpiryDate.Value, Convert.ToInt32(cmbRole.SelectedValue), GeneralObjects.CurrentUserId, GeneralObjects.stationName);
                        if (result == 1)
                        {
                            MessageBox.Show("User Updated successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to Update User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralObjects.ErrLogger.WritetoLogFile("User : SaveandUpdateUser");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //For validation

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            if (GeneralObjects.isNavigating) return;
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Please Enter First Name", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtFirstName.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }

        private void txtlastName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtlastName.Text))
            {
                txtlastName.BackColor = Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Please Enter Last Name", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtlastName.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.BackColor = Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Please Enter User Name", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtUserName.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.BackColor = Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Please Enter Password", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtPassword.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }

        //Press CTRL + S then Data Will be Save
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave.PerformClick(); // Or call your save logic directly
                return true; // Indicate the key is handled
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmAddUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show("Are you sure you want to close this form? Any unsaved data will be lost.", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
