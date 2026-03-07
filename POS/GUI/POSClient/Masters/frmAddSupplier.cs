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

namespace POSClient.Masters
{
    public partial class frmAddSupplier : Form
    {
        #region Private Variables
        Suppliers _objSuppliers = null;
        private int _supplierId = 0;
        private bool _onlyView = false;
        #endregion

        public frmAddSupplier(int supplierId, bool onlyView)
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
            _supplierId = supplierId;
            _onlyView = onlyView;
        }

        private void SetTheme()
        {
            //Form
            this.BackColor = Themes.FormBackColor;
            tlpMain.BackColor = Themes.FormBackColor;

            //Label
            lblSupplierName.ForeColor = Themes.LabelForeColor;
            lblSupplierName.BackColor = Themes.LabelBackColor;

            lblAddress1.ForeColor = Themes.LabelForeColor;
            lblAddress1.BackColor = Themes.LabelBackColor;

            lblAddress2.ForeColor = Themes.LabelForeColor;
            lblAddress2.BackColor = Themes.LabelBackColor;

            lblCity.ForeColor = Themes.LabelForeColor;
            lblCity.BackColor = Themes.LabelBackColor;

            lblState.ForeColor = Themes.LabelForeColor;
            lblState.BackColor = Themes.LabelBackColor;

            lblCountry.ForeColor = Themes.LabelForeColor;
            lblCountry.BackColor = Themes.LabelBackColor;

            lblPincode.ForeColor = Themes.LabelForeColor;
            lblPincode.BackColor = Themes.LabelBackColor;

            lblGST.ForeColor = Themes.LabelForeColor;
            lblGST.BackColor = Themes.LabelBackColor;

            lblPAN.ForeColor = Themes.LabelForeColor;
            lblPAN.BackColor = Themes.LabelBackColor;

            lblContactName.ForeColor = Themes.LabelForeColor;
            lblContactName.BackColor = Themes.LabelBackColor;

            lblContactPhoneNo.ForeColor = Themes.LabelForeColor;
            lblContactPhoneNo.BackColor = Themes.LabelBackColor;

            lblContactEmail.ForeColor = Themes.LabelForeColor;
            lblContactEmail.BackColor = Themes.LabelBackColor;

            lblContactPersonPosition.ForeColor = Themes.LabelForeColor;
            lblContactPersonPosition.BackColor = Themes.LabelBackColor;

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
        private void frmAddSupplier_Load(object sender, EventArgs e)
        {
            _objSuppliers = new Suppliers(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

            if (_supplierId == 0)
            {

                //txtSupplierName.Focus();
            }
            else
            {
                GetSupplier(_supplierId);
            }

        }

        private void GetSupplier(int SupplierId)
        {
            DataTable _objDataTable = _objSuppliers.GetSupplier(SupplierId, -1);
            if (_objDataTable != null || _objDataTable.Rows.Count > 0)
            {
                txtSupplierName.Text = Convert.ToString(_objDataTable.Rows[0]["SupplierName"]);

                txtAddress1.Text = Convert.ToString(_objDataTable.Rows[0]["Address1"]);
                txtAddress2.Text = Convert.ToString(_objDataTable.Rows[0]["Address2"]);
                txtCity.Text = Convert.ToString(_objDataTable.Rows[0]["City"]);
                txtState.Text = Convert.ToString(_objDataTable.Rows[0]["State"]);
                txtCountry.Text = Convert.ToString(_objDataTable.Rows[0]["Country"]);
                txtPincode.Text = Convert.ToString(_objDataTable.Rows[0]["Pincode"]);

                txtGST.Text = Convert.ToString(_objDataTable.Rows[0]["GSTNumber"]);
                txtPAN.Text = Convert.ToString(_objDataTable.Rows[0]["PanNumber"]);

                txtContactPersonName.Text = Convert.ToString(_objDataTable.Rows[0]["ContactPersonName"]);
                txtContactPersonEmail.Text = Convert.ToString(_objDataTable.Rows[0]["ContactPersonEmail"]);
                txtContactPersonNo.Text = Convert.ToString(_objDataTable.Rows[0]["ContactPersonPhone"]);
                txtContactPosition.Text = Convert.ToString(_objDataTable.Rows[0]["ContactPersonPosition"]);
                if (_onlyView) //For View
                {
                    txtSupplierName.ReadOnly = true;
                    txtAddress1.ReadOnly = true;
                    txtAddress2.ReadOnly = true;
                    txtCity.ReadOnly = true;
                    txtState.ReadOnly = true;
                    txtCountry.ReadOnly = true;
                    txtPincode.ReadOnly = true;
                    txtGST.ReadOnly = true;
                    txtPAN.ReadOnly = true;
                    txtContactPersonName.ReadOnly = true;
                    txtContactPersonEmail.ReadOnly = true;
                    txtContactPersonNo.ReadOnly = true;
                    txtContactPosition.ReadOnly = true;
                    btnSave.Enabled = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_onlyView == false)
                {
                    if (ValidateDetails() == true)
                    {
                        if (_supplierId == 0)
                        {
                            int result = _objSuppliers.SaveSuppliers(txtSupplierName.Text.Trim(),
                                                                     txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtState.Text, txtCountry.Text, txtPincode.Text,
                                                                     txtGST.Text, txtPAN.Text, txtContactPersonName.Text, txtContactPosition.Text, txtContactPersonNo.Text, txtContactPersonEmail.Text,
                                                                     GeneralObjects.CurrentUserId, GeneralObjects.stationName);
                            if (result == 1)
                            {
                                MessageBox.Show("Supplier added successfully.", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            int result = _objSuppliers.UpdateSuppliers(_supplierId, txtSupplierName.Text.Trim(),
                                                                     txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtState.Text, txtCountry.Text, txtPincode.Text,
                                                                     txtGST.Text, txtPAN.Text, txtContactPersonName.Text, txtContactPosition.Text, txtContactPersonNo.Text, txtContactPersonEmail.Text,
                                                                     GeneralObjects.CurrentUserId, GeneralObjects.stationName);
                            if (result == 1)
                            {
                                MessageBox.Show("Supplier updated successfully.", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    else
                    {
                        txtSupplierName.Focus();

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidateDetails()
        {
            bool retFlag = true;

            try
            {
                if (_onlyView == false)
                {
                    if (txtSupplierName.TextLength == 0)
                    {
                        MessageBox.Show("Supplier Name should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        retFlag = false;
                        return retFlag;
                    }
                    if (txtGST.TextLength == 0)
                    {
                        MessageBox.Show("GST Number should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        retFlag = false;
                        return retFlag;
                    }

                    if (txtAddress1.TextLength == 0)
                    {
                        MessageBox.Show("Address should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        retFlag = false;
                        return retFlag;
                    }

                    if (txtCity.TextLength == 0)
                    {
                        MessageBox.Show("City should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        retFlag = false;
                        return retFlag;
                    }
                    if (txtState.TextLength == 0)
                    {
                        MessageBox.Show("State should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        retFlag = false;
                        return retFlag;
                    }
                    if (txtCountry.TextLength == 0)
                    {
                        MessageBox.Show("Country should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        retFlag = false;
                        return retFlag;
                    }
                    if (txtPincode.TextLength == 0)
                    {
                        MessageBox.Show("Pincode should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        retFlag = false;
                        return retFlag;
                    }

                    if (txtPAN.TextLength == 0)
                    {
                        MessageBox.Show("PAN Number should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        retFlag = false;
                        return retFlag;
                    }

                    else
                    {
                        txtSupplierName.BackColor = SystemColors.Control;
                        txtGST.BackColor = SystemColors.Control;
                        txtAddress1.BackColor = SystemColors.Control;
                        txtCity.BackColor = SystemColors.Control;
                        txtState.BackColor = SystemColors.Control;
                        txtCountry.BackColor = SystemColors.Control;
                        txtPincode.BackColor = SystemColors.Control;
                        txtPAN.BackColor = SystemColors.Control;
                    }

                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("AddSupplier : ValidateDetails");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSupplierName_Leave(object sender, EventArgs e)
        {
            if (GeneralObjects.isNavigating) return;
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text) && !_onlyView)
            {
                MessageBox.Show("Supplier Name should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.BackColor = Color.MistyRose;
            }
            else
            {
                txtSupplierName.BackColor = SystemColors.Window;
            }

        }

        private void txtGST_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGST.Text) && !_onlyView)
            {
                MessageBox.Show("GST Number should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGST.BackColor = Color.MistyRose;
            }
            else
            {
                txtGST.BackColor = SystemColors.Window;
            }
        }

        private void txtAddress1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress1.Text) && !_onlyView)
            {
                MessageBox.Show("Address should be not empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress1.BackColor = Color.MistyRose;
            }
            else
            {
                txtAddress1.BackColor = SystemColors.Window;
            }
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCity.Text) && !_onlyView)
            {
                MessageBox.Show("City should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.BackColor = Color.MistyRose;
            }
            else
            {
                txtCity.BackColor = SystemColors.Window;
            }
        }

        private void txtState_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtState.Text) && !_onlyView)
            {
                MessageBox.Show("State should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtState.BackColor = Color.MistyRose;
            }
            else
            {
                txtState.BackColor = SystemColors.Window;
            }
        }

        private void txtCountry_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCountry.Text) && !_onlyView)
            {
                MessageBox.Show("Country should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCountry.BackColor = Color.MistyRose;
            }
            else
            {
                txtCountry.BackColor = SystemColors.Window;
            }
        }

        private void txtPincode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPincode.Text) && !_onlyView)
            {
                MessageBox.Show("Pincode should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPincode.BackColor = Color.MistyRose;
            }
            else
            {
                txtPincode.BackColor = SystemColors.Window;
            }
        }

        private void txtPAN_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPAN.Text) && !_onlyView)
            {
                MessageBox.Show("PAN Number should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPAN.BackColor = Color.MistyRose;
            }
            else
            {
                txtPAN.BackColor = SystemColors.Window;
            }
        }

        //Only Allow Numbers
        private void txtContactPersonNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void frmAddSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true; // Prevents default beep sound
                btnSave.PerformClick();    // Trigger the save button
            }
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
