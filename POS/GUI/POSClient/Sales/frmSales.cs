using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NDatabaseAccess;

namespace POSClient
{
    public partial class frmSales : Form
    {
        #region "Private Variables"
        Sale _objSales = null;
        GeneralDB _objGeneralDB = null;
        GenerateBarcode _objGenBarcode;
        ComputerLists _objComputerLists = null;
        AuditRecords _objAuditRecords = null;

        private DataTable _dtPaymentMode;
        private DataTable _dtDiscountType;

        private long _salesId;
        private int _optFlag = 0;
        private decimal _oldQty = 0;
        //private decimal _newQty = 0;
        //private long _inventoryId = 0;
        #endregion

        #region "Constructor/Destructor"
        public frmSales()
        {
            InitializeComponent();
            SetTheme();
            this.KeyPreview = true;
        }

        ~frmSales()
        {
            if (_objSales != null)
                _objSales = null;

            if (_objGenBarcode != null)
                _objGenBarcode = null;

            if (_objComputerLists != null)
                _objComputerLists = null;

            if (_objAuditRecords != null)
                _objAuditRecords = null;

            if (_dtPaymentMode != null)
                _dtPaymentMode = null;

            if (_dtDiscountType != null)
                _dtDiscountType = null;
        }
        #endregion

        #region "Set Theme"
        private void SetTheme()
        {
            this.BackColor = Themes.FormBackColor;

            //Header
            btnHeader.BackColor = Themes.HeaderBackColor;
            btnHeader.ForeColor = Themes.HeaderForeColor;
            btnHeader.FlatStyle = FlatStyle.Flat;
            btnHeader.FlatAppearance.BorderSize = 1;
            btnHeader.FlatAppearance.BorderColor = Themes.HeaderBorderColor;

            //Label
            lblCustomerName.ForeColor = Themes.LabelForeColor;
            lblCustomerName.BackColor = Themes.LabelBackColor;

            lblCustMobileNo.ForeColor = Themes.LabelForeColor;
            lblCustMobileNo.BackColor = Themes.LabelBackColor;

            lblBarcode.ForeColor = Themes.LabelForeColor;
            lblBarcode.BackColor = Themes.LabelBackColor;

            lblInvoiceNo.ForeColor = Themes.LabelForeColor;
            lblInvoiceNo.BackColor = Themes.LabelBackColor;

            lblInvoiceDt.ForeColor = Themes.LabelForeColor;
            lblInvoiceDt.BackColor = Themes.LabelBackColor;

            lblPaymentMode.ForeColor = Themes.LabelForeColor;
            lblPaymentMode.BackColor = Themes.LabelBackColor;

            lblAmtCollected.ForeColor = Themes.LabelForeColor;
            lblAmtCollected.BackColor = Themes.LabelBackColor;

            lblAmtReturned.ForeColor = Themes.LabelForeColor;
            lblAmtReturned.BackColor = Themes.LabelBackColor;

            lblGrossTotal.ForeColor = Themes.LabelForeColor;
            lblGrossTotal.BackColor = Themes.LabelBackColor;

            lblDiscount.ForeColor = Themes.LabelForeColor;
            lblDiscount.BackColor = Themes.LabelBackColor;

            lblNetTotal.ForeColor = Themes.LabelForeColor;
            lblNetTotal.BackColor = Themes.LabelBackColor;

            lblTotalItems.ForeColor = Themes.LabelForeColor;
            lblTotalItems.BackColor = Themes.LabelBackColor;

            lblDiscountType.ForeColor = Themes.LabelForeColor;
            lblDiscountType.BackColor = Themes.LabelBackColor;

            lblShortcut.ForeColor = Themes.LabelForeColor;
            lblShortcut.BackColor = Themes.LabelBackColor;

            //Button
            btnSavePrint.FlatStyle = FlatStyle.Flat;
            btnSavePrint.BackColor = Themes.ButtonBackColor;
            btnSavePrint.ForeColor = Themes.ButtonForeColor;
            btnSavePrint.FlatAppearance.BorderSize = 1;
            btnSavePrint.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnView.FlatStyle = FlatStyle.Flat;
            btnView.BackColor = Themes.ButtonBackColor;
            btnView.ForeColor = Themes.ButtonForeColor;
            btnView.FlatAppearance.BorderSize = 1;
            btnView.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.BackColor = Themes.ButtonBackColor;
            btnNew.ForeColor = Themes.ButtonForeColor;
            btnNew.FlatAppearance.BorderSize = 1;
            btnNew.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnReprint.FlatStyle = FlatStyle.Flat;
            btnReprint.BackColor = Themes.ButtonBackColor;
            btnReprint.ForeColor = Themes.ButtonForeColor;
            btnReprint.FlatAppearance.BorderSize = 1;
            btnReprint.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnViewInvoice.FlatStyle = FlatStyle.Flat;
            btnViewInvoice.BackColor = Themes.ButtonBackColor;
            btnViewInvoice.ForeColor = Themes.ButtonForeColor;
            btnViewInvoice.FlatAppearance.BorderSize = 1;
            btnViewInvoice.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.BackColor = Themes.ButtonBackColor;
            btnCancel.ForeColor = Themes.ButtonForeColor;
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = Themes.ButtonBorderColor;
        }
        #endregion

        private void frmSales_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            _objSales = new Sale(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objGeneralDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objComputerLists = new ComputerLists(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objAuditRecords = new AuditRecords(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

            txtInvoiceNo.Text = _objSales.GetNewSalesNo();
            BindPaymentMode();
            BindDiscountType();
            cmbDiscountType.SelectedIndex = 1;
            FillPrinterList();
            _optFlag = 0;
            SetCtrl();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                MDIMain md = (MDIMain)this.Parent.Parent;
                frmSalesView frmSalesView = new frmSalesView();
                md.OpenChildForm(frmSalesView);
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Sales : View");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        //Tejas Started - Insert Barcode Data into Datagrid

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcodeValue = txtBarcode.Text.Trim();
                if (!string.IsNullOrEmpty(barcodeValue))
                {
                    bool barCodeExists = false;

                    foreach (DataGridViewRow row in dgvSalesItem.Rows)
                    {
                        if (row.Cells["BarcodeValue"].Value != null && row.Cells["BarcodeValue"].Value.ToString().Equals(barcodeValue, StringComparison.OrdinalIgnoreCase))
                        {
                            barCodeExists = true;
                            //_inventoryId = Convert.ToInt64(row.Cells["InventoryId"].Value);
                            break;
                        }
                    }

                    if(barCodeExists)
                    {
                        DialogResult dialogResult = MessageBox.Show("Item with this barcode already exists. Do you want to add it again?", "Duplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        txtBarcode.Text = "";
                        if (dialogResult == DialogResult.No)
                            return;
                    }

                    DataTable objDataTable = null;
                    objDataTable = _objSales.GetItemByBarcode(barcodeValue, Environment.MachineName);
                    if (objDataTable != null && objDataTable.Rows.Count > 0)
                    {
                        int srNo = dgvSalesItem.Rows.Count + 1;
                        string inventoryId = Convert.ToString(objDataTable.Rows[0]["InventoryId"]);
                        string material = Convert.ToString(objDataTable.Rows[0]["GroupName"]);
                        string articleNo = Convert.ToString(objDataTable.Rows[0]["ArticleNo"]);
                        string classification = Convert.ToString(objDataTable.Rows[0]["Classification"]);
                        string size = Convert.ToString(objDataTable.Rows[0]["Size"]);
                        string color = Convert.ToString(objDataTable.Rows[0]["Color"]);
                        string hsn = Convert.ToString(objDataTable.Rows[0]["HSNCode"]);
                        string rate = Convert.ToString(objDataTable.Rows[0]["SalePrice"]);
                        string qty = Convert.ToString(objDataTable.Rows[0]["Quantity"]);

                        // Add a new row to the DataGridView
                        int rowIndex = dgvSalesItem.Rows.Add(srNo.ToString(), inventoryId, barcodeValue, material, articleNo, classification, size, color, hsn, rate, qty);

                        _objSales.SaveScannedItems(Convert.ToInt64(inventoryId), barcodeValue, Environment.MachineName);
                        // Clear the textbox for next input
                        txtBarcode.Clear();

                        // Optional: Keep focus on the textbox
                        txtBarcode.Focus();
                        txtTotalItems.Text = Convert.ToString((int)dgvSalesItem.Rows.Count);
                        txtGrossTotal.Text = GetColumnSum(dgvSalesItem, "Rate").ToString("F2");
                        txtNetTotal.Text = (Convert.ToDecimal(txtGrossTotal.Text) - Convert.ToDecimal(txtDiscount.Text)).ToString("F2");
                    }
                    else
                    {
                        MessageBox.Show("No matching item found for the scanned barcode. Please verify the barcode or try scanning again.", "Barcode Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBarcode.Text = "";
                    }
                }
                // Prevent the "ding" sound
                e.SuppressKeyPress = true;
            }
        }
        //Tejas Ended - Insert Barcode Data into Datagrid

        //Tejas Started - Get Column Sum
        private decimal GetColumnSum(DataGridView dgv, string columnName)
        {
            decimal sum = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                if (decimal.TryParse(Convert.ToString(row.Cells[columnName].Value), out decimal val))
                {
                    sum += val;
                }
            }

            return sum;
        }
        //Tejas Ended - Get Column Sum

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                int discountType = Convert.ToInt32(cmbDiscountType.SelectedValue);
                decimal discountAmt = discountType == 0 ? ((Convert.ToDecimal(txtGrossTotal.Text) * Convert.ToDecimal(txtDiscount.Text)) / 100) : Convert.ToDecimal(txtDiscount.Text);
                txtNetTotal.Text = (Convert.ToDecimal(txtGrossTotal.Text) - discountAmt).ToString("F2");
            }
        }

        private void txtAmtCollected_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAmtCollected.Text))
                txtAmountReturn.Text = (Convert.ToDecimal(txtAmtCollected.Text) - Convert.ToDecimal(txtNetTotal.Text)).ToString("F2");
        }

        //Tejas Started - Delete Row
        private void dgvSalesItem_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.E)) // Ctrl+E
            {
                if (dgvSalesItem.CurrentCell != null && dgvSalesItem.Columns[dgvSalesItem.CurrentCell.ColumnIndex].Name == "Qty")
                {
                    dgvSalesItem.ReadOnly = false;
                    dgvSalesItem.BeginEdit(true);
                    e.SuppressKeyPress = true; // Stop further processing of the key
                }
            }
            else
            {
                if (dgvSalesItem.ReadOnly && dgvSalesItem.CurrentCell != null && dgvSalesItem.Columns[dgvSalesItem.CurrentCell.ColumnIndex].Name == "Qty")
                {
                    dgvSalesItem.ReadOnly = false;
                    dgvSalesItem.BeginEdit(true);
                }
            }

            if (e.KeyCode == Keys.Enter && dgvSalesItem.CurrentCell.ColumnIndex == dgvSalesItem.Columns["Qty"].Index)
            {
                dgvSalesItem.EndEdit(); // Ends editing and triggers CellEndEdit
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (dgvSalesItem.SelectedCells.Count > 0)
                {
                    int rowIndex = dgvSalesItem.SelectedCells[0].RowIndex;
                    if (rowIndex >= 0 && !dgvSalesItem.Rows[rowIndex].IsNewRow)
                    {
                        long inventoryId = Convert.ToInt64(dgvSalesItem.Rows[rowIndex].Cells["InventoryId"].Value ?? 0);

                        dgvSalesItem.Rows.RemoveAt(rowIndex);
                        UpdateSerialNumbers();
                        _objSales.DelScannedItems(Environment.MachineName, inventoryId);
                        txtTotalItems.Text = Convert.ToString((int)dgvSalesItem.Rows.Count);
                        txtGrossTotal.Text = GetColumnSum(dgvSalesItem, "Rate").ToString("F2");
                        txtNetTotal.Text = (Convert.ToDecimal(txtGrossTotal.Text) - Convert.ToDecimal(txtDiscount.Text)).ToString("F2");
                    }
                }
            }
        }
        //Tejas Ended - Delete Row

        //Tejas Started - Updated the Serial Number while Delete the Row
        private void UpdateSerialNumbers()
        {
            for (int i = 0; i < dgvSalesItem.Rows.Count; i++)
            {
                dgvSalesItem.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }
        //Tejas End - Updated the Serial Number while Delete the Row

        private void txtCustName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustName.Text))
            {
                txtCustName.BackColor = System.Drawing.Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Customer Name required!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtCustName.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }

        //Tejas Started - to Assign Hot Key
        private void frmSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                e.SuppressKeyPress = true; // Prevents default beep sound
                btnSavePrint.PerformClick();    // Trigger the save button
            }
            else if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show("Are you sure you want to close this form? Any unsaved data will be lost.", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    GeneralObjects.isNavigating = true;
                    MDIMain md = (MDIMain)(this.Parent.Parent);
                    frmHome objHome = new frmHome();
                    md.OpenChildForm(objHome);
                    this.Close();
                }
            }
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You have clicked Print Button.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                if (ValidateDetails())
                {
                    int itemSuccessCount = 0;
                    string invoiceDate = GeneralObjects.DateAsPerSQL(dtpInvoiceDate.Value);

                    DataTable objDataTable = _objSales.SaveSales(txtInvoiceNo.Text.Trim(), invoiceDate, Convert.ToDecimal(txtGrossTotal.Text), Convert.ToInt32(cmbDiscountType.SelectedValue), Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtNetTotal.Text),
                        Convert.ToInt32(cmbPaymentMode.SelectedValue), txtCustName.Text.Trim(), txtMobileNo.Text.Trim(), GeneralObjects.CurrentUserId, GeneralObjects.stationName);

                    if (objDataTable != null && objDataTable.Rows.Count > 0)
                    {
                        int returnStatus = Convert.ToInt32(objDataTable.Rows[0]["ReturnStatus"]);
                        _salesId = Convert.ToInt32(objDataTable.Rows[0]["SalesId"]);

                        if (returnStatus == 1)
                        {
                            for (int i = 0; i < dgvSalesItem.Rows.Count; i++)
                            {
                                if (dgvSalesItem.Rows[i].IsNewRow) continue;

                                long inventoryId = Convert.ToInt64(dgvSalesItem.Rows[i].Cells["InventoryId"].Value);
                                decimal rate = Convert.ToDecimal(dgvSalesItem.Rows[i].Cells["Rate"].Value);
                                string hsnCode = Convert.ToString(dgvSalesItem.Rows[i].Cells["HSN"].Value);
                                decimal qty = Convert.ToDecimal(dgvSalesItem.Rows[i].Cells["Qty"].Value);

                                bool retFlag = _objSales.SaveSalesItem(_salesId, inventoryId, rate, hsnCode.Trim(), qty, GeneralObjects.CurrentUserId);
                                if (retFlag)
                                    itemSuccessCount = itemSuccessCount + 1;
                            }

                            if (itemSuccessCount == dgvSalesItem.Rows.Count)
                            {
                                MessageBox.Show("Sales entry has been saved successfully.", "Sales Entry Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Print Code
                                DataTable dtReportData = _objSales.GetInvReportData(_salesId);
                                string invoicePrinter = _objComputerLists.GetInvoicePrinter(Environment.MachineName);
                                var printer = new RptPrinter();
                                printer.PrintFAN(dtReportData, invoicePrinter);
                                _optFlag = 1;
                                SetCtrl();
                            }
                            else
                            {
                                MessageBox.Show("The sales entry was saved, but some items could not be saved. Please review and try again.", "Save Completed with Errors", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            _objSales.DelScannedItems(Environment.MachineName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sales entry could not be saved. Please try again.", "Save Unsuccessful: Please Retry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Sales : Save");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
        //Tejas Ended - to Assign Hot Key

        private void BindPaymentMode()
        {
            _dtPaymentMode = _objGeneralDB.GetListIndexWithMessageText(3);
            if (_dtPaymentMode != null && _dtPaymentMode.Rows.Count > 0)
            {
                cmbPaymentMode.DisplayMember = "MessageText";
                cmbPaymentMode.ValueMember = "ListIndex";
                cmbPaymentMode.DataSource = _dtPaymentMode;
            }
        }

        private void BindDiscountType()
        {
            _dtDiscountType = _objGeneralDB.GetListIndexWithMessageText(2);
            if (_dtDiscountType != null && _dtDiscountType.Rows.Count > 0)
            {
                cmbDiscountType.DisplayMember = "MessageText";
                cmbDiscountType.ValueMember = "ListIndex";
                cmbDiscountType.DataSource = _dtDiscountType;
            }
        }

        private bool ValidateDetails()
        {
            bool retFlag = true;
            if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text) && txtInvoiceNo.Text.Length == 0)
            {
                MessageBox.Show("Invoice Number should not be empty!", "Missing Invoice Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retFlag = false;
                txtBarcode.Focus();
                return retFlag;
            }

            if (dgvSalesItem.Rows.Count == 0)
            {
                MessageBox.Show("sales items should not be empty!", "Sales Items Are Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retFlag = false;
                txtBarcode.Focus();
                return retFlag;
            }

            if (string.IsNullOrWhiteSpace(txtMobileNo.Text) && txtMobileNo.Text.Length == 0)
            {
                MessageBox.Show("Mobile number should not be empty!", "Missing Mobile Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retFlag = false;
                txtMobileNo.Focus();
                txtMobileNo.BackColor = System.Drawing.Color.MistyRose;
                return retFlag;
            }

            if (string.IsNullOrWhiteSpace(txtCustName.Text) && txtCustName.Text.Length == 0)
            {
                MessageBox.Show("Customer Name should not be empty!", "Missing Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retFlag = false;
                txtCustName.Focus();
                txtCustName.BackColor = System.Drawing.Color.MistyRose;
                return retFlag;
            }
            return retFlag;
        }

        private void Reset()
        {
            txtInvoiceNo.Enabled = false;
            txtInvoiceNo.Text = _objSales.GetNewSalesNo();
            dtpInvoiceDate.Value = DateTime.Today;
            txtBarcode.Text = "";
            txtMobileNo.Text = "";
            txtCustName.Text = "";
            cmbDiscountType.SelectedIndex = 1;
            cmbPaymentMode.SelectedIndex = 0;
            txtTotalItems.Text = "0";

            txtAmtCollected.Text = "0.00";
            txtAmountReturn.Text = "0.00";
            txtGrossTotal.Text = "0.00";
            txtDiscount.Text = "0.00";
            txtNetTotal.Text = "0.00";

            dgvSalesItem.Rows.Clear();

            txtBarcode.Focus();
        }

        private void cmbDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiscount.Text = "0.00";
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            DataTable dtReportData = _objSales.GetInvReportData(_objSales.GetSalesId(txtInvoiceNo.Text.Trim()));
            string invoicePrinter = _objComputerLists.GetInvoicePrinter(Environment.MachineName);
            var printer = new RptPrinter();
            printer.PrintFAN(dtReportData, invoicePrinter);
            string auditText = "Invoice Number : " + txtInvoiceNo.Text.Trim() + " Reprinted.";
            string userName = GeneralObjects.FirstName + " " + GeneralObjects.LastName;
            _objAuditRecords.SetAuditRecords(auditText, userName, this.Text, Environment.MachineName);
        }

        private void txtMobileNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobileNo.Text))
            {
                txtMobileNo.BackColor = System.Drawing.Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Customer Mobile Number required!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtMobileNo.BackColor = SystemColors.Window; // reset to normal if filled
            }
            txtCustName.Text = _objSales.GetCustomerName(txtMobileNo.Text.Trim());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void FillPrinterList()
        {
            //PrintDocument prtdoc = new PrintDocument();
            //string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            //foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            //{
            //    cmbPrinter.Items.Add(strPrinter);
            //    if (strPrinter == strDefaultPrinter)
            //    {
            //        cmbPrinter.SelectedIndex = cmbPrinter.Items.IndexOf(strPrinter);
            //    }
            //}
        }

        private void SetCtrl()
        {
            switch (_optFlag)
            {
                case 0:
                    btnNew.Enabled = false;
                    btnSavePrint.Enabled = true;
                    btnReprint.Enabled = false;
                    btnViewInvoice.Enabled = true;
                    btnView.Enabled = true;
                    btnCancel.Enabled = true;

                    txtInvoiceNo.Enabled = false;
                    break;
                case 1:
                    btnNew.Enabled = true;
                    btnSavePrint.Enabled = false;
                    btnReprint.Enabled = true;
                    btnViewInvoice.Enabled = true;
                    btnView.Enabled = true;
                    btnCancel.Enabled = false;

                    txtInvoiceNo.Enabled = false;
                    break;
                case 2:
                    btnNew.Enabled = true;
                    btnSavePrint.Enabled = false;
                    btnReprint.Enabled = true;
                    btnViewInvoice.Enabled = false;
                    btnView.Enabled = true;
                    btnCancel.Enabled = false;

                    txtInvoiceNo.Enabled = true;
                    txtInvoiceNo.Text = "";
                    break;
            }
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            if (dgvSalesItem.Rows.Count > 0)
            {
                MessageBox.Show("A bill is already in process. Please complete or cancel it before view invoice.", "Bill In Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _optFlag = 0;
                SetCtrl();
                return;
            }
            _optFlag = 2;
            SetCtrl();
            txtInvoiceNo.Focus();
        }

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvSalesItem.Rows.Clear();

                DataSet dsInvoiceDetails = _objSales.GetInvoiceDetails(txtInvoiceNo.Text.Trim());
                if (dsInvoiceDetails != null && dsInvoiceDetails.Tables.Count > 0 && dsInvoiceDetails.Tables[0].Rows.Count > 0)
                {
                    DataTable dtSales = dsInvoiceDetails.Tables[0];
                    DataTable dtSalesItem = dsInvoiceDetails.Tables[1];

                    dtpInvoiceDate.Value = Convert.ToDateTime(dtSales.Rows[0]["SalesDate"]);
                    txtGrossTotal.Text = Convert.ToString(dtSales.Rows[0]["GrossAmount"]);
                    cmbDiscountType.Text = Convert.ToString(dtSales.Rows[0]["DiscountTypeName"]);
                    txtDiscount.Text = Convert.ToString(dtSales.Rows[0]["Discount"]);
                    txtNetTotal.Text = Convert.ToString(dtSales.Rows[0]["NetAmount"]);
                    cmbPaymentMode.Text = Convert.ToString(dtSales.Rows[0]["PaymentMode"]);
                    txtMobileNo.Text = Convert.ToString(dtSales.Rows[0]["MobileNumber"]);
                    txtCustName.Text = Convert.ToString(dtSales.Rows[0]["CustomerName"]);

                    if (dtSalesItem != null && dtSalesItem.Rows.Count > 0)
                    {
                        txtTotalItems.Text = Convert.ToString(dtSalesItem.Rows.Count);
                        //dgvSalesItem.DataSource = dtSalesItem;
                        foreach (DataRow row in dtSalesItem.Rows)
                        {
                            dgvSalesItem.Rows.Add(row["SrNo"], row["InventoryId"], row["Barcode"], row["GroupName"], row["ArticleNo"], row["Classification"], row["Size"], row["Color"], row["HSNCode"], row["GrossRate"]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invoice not found. Please check the invoice number and try again.", "Invoice not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _optFlag = 0;
                    SetCtrl();
                    Reset();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
            _objSales.DelScannedItems(Environment.MachineName);
        }

        private void dgvSalesItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvSalesItem.Columns[e.ColumnIndex].Name == "Qty")
            {
                dgvSalesItem.ReadOnly = false;
                dgvSalesItem.BeginEdit(true);
            }
        }

        private void dgvSalesItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvSalesItem.Columns[e.ColumnIndex].Name == "Qty")
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal qty))
                {
                    dgvSalesItem.CancelEdit();
                    dgvSalesItem.CurrentCell.Value = Convert.ToString(_oldQty);  // Revert back to old value
                    MessageBox.Show("Please enter a valid decimal number for Qty.");
                    //e.Cancel = true;
                    //dgvSalesItem.Rows[e.RowIndex].Cells["Qty"].Value = Convert.ToString(_oldQty);
                }
            }
        }

        private void dgvSalesItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvSalesItem.Columns[e.ColumnIndex].Name == "Qty")
            {
                _oldQty = Convert.ToDecimal(dgvSalesItem.Rows[e.RowIndex].Cells["Qty"].Value);
            }
        }

        private void dgvSalesItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvSalesItem.ReadOnly = true;
        }

        private void QtyCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvSalesItem.ReadOnly && dgvSalesItem.CurrentCell.ColumnIndex == dgvSalesItem.Columns["Qty"].Index)
            {
                dgvSalesItem.ReadOnly = false;
                dgvSalesItem.BeginEdit(true);
            }
        }

        private void dgvSalesItem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvSalesItem.CurrentCell.ColumnIndex == dgvSalesItem.Columns["Qty"].Index)
            {
                TextBox txtqtyEdit = e.Control as TextBox;
                if (txtqtyEdit != null)
                {
                    txtqtyEdit.KeyPress -= new KeyPressEventHandler(QtyCell_KeyPress);
                    txtqtyEdit.KeyPress += new KeyPressEventHandler(QtyCell_KeyPress);
                }
            }
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmtCollected_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmountReturn_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGrossTotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNetTotal_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
