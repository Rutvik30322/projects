using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NDatabaseHandler;
using NErrorHandler;
using NEncryptDecrypt;
using NDatabaseAccess;

namespace POSClient
{
    public partial class Login : Form
    {
        #region "Private Variables"
        private string ConnectionString;
        Users objUsers = null;
        SaltGenerator _objSaltGenerator;
        AuditRecords _objAuditRecords = null;
        GeneralSettings objGeneralSettings = null;

        private string _auditText = "";
        private string _userName = "";
        #endregion

        #region "Constructor/Destructor"

        public Login()
        {
            InitializeComponent();
        }

        ~Login()
        {
            if (objUsers != null)
                objUsers = null;

            if (_objSaltGenerator != null)
                _objSaltGenerator = null;

            if (_objAuditRecords != null)
                _objAuditRecords = null;

            if (objGeneralSettings != null)
                objGeneralSettings = null;
        }

        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            ConnectionString = EncryptDecrypt.GetConnString();
            GeneralObjects.DbHelper = new DataAccess(ConnectionString, GeneralObjects.ErrLogger);
            GeneralObjects.ErrLogger = new ErrorHandler("BeSpokeERPClient");
            objUsers = new Users(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objAuditRecords = new AuditRecords(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            objGeneralSettings = new GeneralSettings(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

            txtUserName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            txtUserName.BackColor = Color.White;
            pnlUserName.BackColor = Color.White;
            txtPassword.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            pnlPassword.BackColor = Color.White;
            txtUserName.BackColor = SystemColors.Control;
            pnlUserName.BackColor = SystemColors.Control;
        }

        private void pbPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pbPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void VerifyUser()
        {
            _objSaltGenerator = new SaltGenerator();
            try
            {
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("User Name should not be Empty!", "BeSpoke ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                    return;
                }

                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Password should not be Empty!", "BeSpoke ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                    return;
                }

                DataTable objDataTable = objUsers.ValidateUser(txtUserName.Text);
                if(objDataTable != null && objDataTable.Rows.Count > 0)
                {
                    string passwordHash = objDataTable.Rows[0]["PasswordSalt"] + txtPassword.Text;
                    string hashedPassword = _objSaltGenerator.HashPassword(passwordHash);
                    if (Convert.ToDateTime(objDataTable.Rows[0]["ExpiryDate"]) < Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy")))
                    {
                        MessageBox.Show("Users Login Expired, Please Request Admin to Extend your Expiry Date.", "BeSpoke ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUserName.Focus();
                        return;
                    }
                    else
                    {
                        if (Convert.ToString(objDataTable.Rows[0]["Password"]) == hashedPassword)
                        {
                            GeneralObjects.UserName = Convert.ToString(objDataTable.Rows[0]["UserName"]);
                            GeneralObjects.FirstName = Convert.ToString(objDataTable.Rows[0]["FirstName"]);
                            GeneralObjects.LastName = Convert.ToString(objDataTable.Rows[0]["LastName"]);
                            GeneralObjects.CurrentUserId = Convert.ToInt32(objDataTable.Rows[0]["UserId"]);
                            GeneralObjects.CurrentRoleId = Convert.ToInt32(objDataTable.Rows[0]["RoleId"]);
                            GeneralObjects.CurrentRoleName = Convert.ToString(objDataTable.Rows[0]["RoleName"]);
                            GeneralObjects.CurrentRoleType = Convert.ToInt32(objDataTable.Rows[0]["RoleType"]);
                            GeneralObjects.stationName = Environment.MachineName;

                            //GeneralObjects.LoginTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                            //string[] param = new string[1];
                            //param[0] = txtUserName.Text;
                            //objAuditRecords.GenerateAudit("LoginSuccess", System.Environment.MachineName, txtUserName.Text, this.Text, param);

                            GeneralObjects.SetMenuAndSubMenu = true;
                            this.Hide();
                            MDIMain masterForm = new MDIMain();
                            masterForm.Show();
                            _auditText = "User logged in successfully.";
                            _userName = GeneralObjects.FirstName + " " + GeneralObjects.LastName;
                            _objAuditRecords.SetAuditRecords(_auditText, _userName, "Login", Environment.MachineName);
                            //objEvents.SetAudit("LOGINSUCCESS", txtUserName.Text, System.Environment.MachineName, param);
                            //this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Login failed. Please verify username and password", "BeSpoke ERP");
                            _userName = GeneralObjects.FirstName + " " + GeneralObjects.LastName;
                            _auditText = "Login attempt failed for user " + txtUserName.Text + ".";
                            _objAuditRecords.SetAuditRecords(_auditText, txtUserName.Text, "Login", Environment.MachineName);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Login failed. Please verify username and password", "BeSpoke ERP");
                    _userName = GeneralObjects.FirstName + " " + GeneralObjects.LastName;
                    _auditText = "Login attempt failed for user " + txtUserName.Text + ".";
                    _objAuditRecords.SetAuditRecords(_auditText, txtUserName.Text, "Login", Environment.MachineName);
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Login : VerifyUser");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            VerifyUser();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                VerifyUser();
            }
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("Please Enter User Name!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return;
                }
                if (txtUserName.Text == "admin")
                {
                    MessageBox.Show("You Can not send Request for Reset Password for admin User", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                    return;
                }
                else
                {
                    bool isRequested = objUsers.RequestForResetPwd(txtUserName.Text);
                    if (isRequested == true)
                    {
                        MessageBox.Show("Password Reset Request is Sent To Admin.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUserName.Focus();
                        _auditText = "Reset password request submitted for user: " + txtUserName.Text;
                        _objAuditRecords.SetAuditRecords(_auditText, txtUserName.Text, this.Text, Environment.MachineName);
                        return;
                    }
                    else
                    {
                        //MessageBox.Show("Password Reset Request Failed", "Login");
                        MessageBox.Show("The entered username does not exist.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUserName.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Forget Password Failed", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (GeneralObjects.ErrLogger != null)
                {
                    GeneralObjects.ErrLogger.WritetoLogFile(ex);
                }
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.BackColor = Color.White;
            pnlUserName.BackColor = Color.White;
            txtPassword.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            pnlPassword.BackColor = Color.White;
            txtUserName.BackColor = SystemColors.Control;
            pnlUserName.BackColor = SystemColors.Control;
        }
    }
}
