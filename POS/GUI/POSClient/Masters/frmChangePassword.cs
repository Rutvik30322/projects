using NDatabaseAccess;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace POSClient
{
    public partial class frmChangePassword : Form
    {
        SaltGenerator _objSaltGenerator;

        #region "Private Variable"
        Users objUsers = null;
        private int _CellClickuserId = 0;
        #endregion

        #region "Constructor/Destructor"
        public frmChangePassword()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }

        ~frmChangePassword()
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
            lblOldPwd.ForeColor = Themes.LabelForeColor;
            lblOldPwd.BackColor = Themes.LabelBackColor;
            lblNewPwd.ForeColor = Themes.LabelForeColor;
            lblNewPwd.BackColor = Themes.LabelBackColor;
            lblConfirmPassword.ForeColor = Themes.LabelForeColor;
            lblConfirmPassword.BackColor = Themes.LabelBackColor;
            lblUserName.ForeColor = Themes.LabelForeColor;
            lblUserName.BackColor = Themes.LabelBackColor;

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

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            objUsers = new Users(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            txtOldPwd.Focus();
            txtUserName.Text = GeneralObjects.UserName;
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
                if (txtOldPwd.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter Old Password", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOldPwd.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (txtNewPwd.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter New Password", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPwd.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (txtConfirmPwd.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter Confirm Password", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPwd.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (!IsValidPassword(txtNewPwd.Text))
                {
                    MessageBox.Show("Password must be at least 8 characters long and include one uppercase letter, one special character, and alphanumeric characters.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPwd.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (!IsValidPassword(txtConfirmPwd.Text))
                {
                    MessageBox.Show("Password must be at least 8 characters long and include one uppercase letter, one special character, and alphanumeric characters.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPwd.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (txtNewPwd.Text != txtConfirmPwd.Text)
                {
                    MessageBox.Show("New Password and Confirm Password are not same", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPwd.BackColor = Color.MistyRose;
                    return retFlag = false;
                }

                if (txtOldPwd.Text == txtNewPwd.Text)
                {
                    MessageBox.Show("Old Password and New Password are same", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPwd.BackColor = Color.MistyRose;
                    return retFlag = false;
                }


            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("ChangePassword : ValidateDetails");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _objSaltGenerator = new SaltGenerator();
            if (ValidateDetails())
            {
                DataTable objDataTable = objUsers.GetUser(GeneralObjects.CurrentUserId, -1, GeneralObjects.CurrentRoleType);
                string existingPwd = objDataTable.Rows[0]["Password"].ToString();
                string passwordHash = objDataTable.Rows[0]["PasswordSalt"].ToString() + txtOldPwd.Text;
                string passwordSalt = objDataTable.Rows[0]["PasswordSalt"].ToString();

                string CurrentPassword = _objSaltGenerator.HashPassword(passwordHash);

                if (existingPwd == CurrentPassword)
                {
                    passwordSalt = _objSaltGenerator.GenerateSalt();
                    string passwordWithSalt = passwordSalt + txtNewPwd.Text;
                    string loginPassword = _objSaltGenerator.HashPassword(passwordWithSalt);
                    bool result = objUsers.UpdateChangePassword(GeneralObjects.CurrentUserId, loginPassword, passwordSalt);
                    if (result == true)
                    {
                        MessageBox.Show("Password changed successfully. Please log in with your new credentials.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide(); // Hide the current form
                        Login login = new Login();
                        login.Show(); // or ShowDialog() if you want it modal


                    }
                    else
                    {
                        MessageBox.Show("Failed to Change Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("You have entered wrong Old Password!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GeneralObjects.isNavigating = true;
            this.Close();
        }

        private void txtOldPwd_Leave(object sender, EventArgs e)
        {
            if (GeneralObjects.isNavigating) return;
            if (string.IsNullOrWhiteSpace(txtOldPwd.Text))
            {
                txtOldPwd.BackColor = Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Please Enter Old Password", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtOldPwd.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }

        private void txtNewPwd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPwd.Text))
            {
                txtNewPwd.BackColor = Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Please Enter New Password", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtNewPwd.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }

        private void txtConfirmPwd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPwd.Text))
            {
                txtConfirmPwd.BackColor = Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Please Enter Confirm Password", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtConfirmPwd.BackColor = SystemColors.Window; // reset to normal if filled
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

        private void frmChangePassword_KeyDown(object sender, KeyEventArgs e)
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
