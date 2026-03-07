using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NDatabaseAccess;
using static NConstant.Constant;

namespace POSClient
{
    public partial class frmPurchase : Form
    {

        #region "Private Variables"
        Purchases _objPurchases = null;
        Suppliers _objSuppliers = null;
        ItemsGroup _objItemGroup = null;
        UOM _objUOM = null;
        GeneralDB _objGeneralDB = null;
        GeneralSettings _objGeneralSettings = null;
        RawPrinterHelper _objrawPrinterHelper;
        ComputerLists _objComputerLists = null;

        //DataTable
        private DataTable _dtSupplier;
        private DataTable _dtItemGroup;
        private DataTable _dtUOM;
        private DataTable _dtDiscountType;

        //Tejas Started -- Define Column Tags dictionary for validate only Decimal Value.
        private Dictionary<DataGridViewColumn, string> columnTags = new Dictionary<DataGridViewColumn, string>();

        //Tejas Started -- For Validation of Required Column
        private HashSet<string> requiredColumns;
        private HashSet<string> zeroNotAllowedColumns;
        //Tejas Ended -- For Validation of Required Column
        #endregion

        #region "Constructor/Destructor"
        public frmPurchase()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }

        ~frmPurchase()
        {
            if (_objPurchases != null)
                _objPurchases = null;

            if (_objSuppliers != null)
                _objSuppliers = null;

            if (_objItemGroup != null)
                _objItemGroup = null;

            if (_objUOM != null)
                _objUOM = null;

            if (_objGeneralDB != null)
                _objGeneralDB = null;

            if (_objGeneralSettings != null)
                _objGeneralSettings = null;

            if (_objrawPrinterHelper != null)
                _objrawPrinterHelper = null;

            if (_objComputerLists != null)
                _objComputerLists = null;

            if (_dtSupplier != null)
                _dtSupplier = null;

            if (_dtItemGroup != null)
                _dtItemGroup = null;

            if (_dtDiscountType != null)
                _dtDiscountType = null;
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

            //Label
            lblPurchaseNo.ForeColor = Themes.LabelForeColor;
            lblPurchaseNo.BackColor = Themes.LabelBackColor;

            lblSupplier.ForeColor = Themes.LabelForeColor;
            lblSupplier.BackColor = Themes.LabelBackColor;

            lblInvoiceDate.ForeColor = Themes.LabelForeColor;
            lblInvoiceDate.BackColor = Themes.LabelBackColor;

            lblInvoiceNo.ForeColor = Themes.LabelForeColor;
            lblInvoiceNo.BackColor = Themes.LabelBackColor;

            lblGSTINNo.ForeColor = Themes.LabelForeColor;
            lblGSTINNo.BackColor = Themes.LabelBackColor;

            lblRemarks.ForeColor = Themes.LabelForeColor;
            lblRemarks.BackColor = Themes.LabelBackColor;

            lblTotalItems.ForeColor = Themes.LabelForeColor;
            lblTotalItems.BackColor = Themes.LabelBackColor;

            lblTotalAmount.ForeColor = Themes.LabelForeColor;
            lblTotalAmount.BackColor = Themes.LabelBackColor;

            lblNetAmount.ForeColor = Themes.LabelForeColor;
            lblNetAmount.BackColor = Themes.LabelBackColor;

            lblGSTAmount.ForeColor = Themes.LabelForeColor;
            lblGSTAmount.BackColor = Themes.LabelBackColor;

            lblPaymentDueDate.ForeColor = Themes.LabelForeColor;
            lblPaymentDueDate.BackColor = Themes.LabelBackColor;

            lblTD.ForeColor = Themes.LabelForeColor;
            lblTD.BackColor = Themes.LabelBackColor;

            lblRoundOff.ForeColor = Themes.LabelForeColor;
            lblRoundOff.BackColor = Themes.LabelBackColor;

            lblIGST.ForeColor = Themes.LabelForeColor;
            lblIGST.BackColor = Themes.LabelBackColor;

            lblCGST.ForeColor = Themes.LabelForeColor;
            lblCGST.BackColor = Themes.LabelBackColor;

            lblSGST.ForeColor = Themes.LabelForeColor;
            lblSGST.BackColor = Themes.LabelBackColor;

            lblCity.ForeColor = Themes.LabelForeColor;
            lblCity.BackColor = Themes.LabelBackColor;

            lblState.ForeColor = Themes.LabelForeColor;
            lblState.BackColor = Themes.LabelBackColor;

            lblShortcut2.ForeColor = Themes.LabelForeColor;
            lblShortcut2.BackColor = Themes.LabelBackColor;
            //TextBox

            //Button

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

            btnView.FlatStyle = FlatStyle.Flat;
            btnView.BackColor = Themes.ButtonBackColor;
            btnView.ForeColor = Themes.ButtonForeColor;
            btnView.FlatAppearance.BorderSize = 1;
            btnView.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.BackColor = Themes.ButtonBackColor;
            btnSupplier.ForeColor = Themes.ButtonForeColor;
            btnSupplier.FlatAppearance.BorderSize = 1;
            btnSupplier.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnUpdatePayment.FlatStyle = FlatStyle.Flat;
            btnUpdatePayment.BackColor = Themes.ButtonBackColor;
            btnUpdatePayment.ForeColor = Themes.ButtonForeColor;
            btnUpdatePayment.FlatAppearance.BorderSize = 1;
            btnUpdatePayment.FlatAppearance.BorderColor = Themes.ButtonBorderColor;
        }
        #endregion

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            cmbSupplier.Focus();
            _objPurchases = new Purchases(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objSuppliers = new Suppliers(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objItemGroup = new ItemsGroup(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objUOM = new UOM(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objGeneralDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objComputerLists = new ComputerLists(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objGeneralSettings = new GeneralSettings(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

            txtPurchaseNo.Text = _objPurchases.GetNewPurchaseNo();
            AssignColumnTag();
            //requiredColumns = new HashSet<string>
            //{
            //    "cmbMaterialCell", "ArticleNo", "Classification", "Size", "Color", "Qty", "Rate", "NetRate", "NetAmount"
            //};
            requiredColumns = new HashSet<string>
            {
                "cmbMaterialCell", "ArticleNo", "Qty", "cmbUOMCell", "MRP", "Rate", "NetRate", "NetAmount"
            };
            zeroNotAllowedColumns = new HashSet<string> { "Qty", "MRP", "Rate", "NetRate", "NetAmount" };

            //Bind Combobox
            BindSupplier();
            SearchSupplier();

            BindMaterial();
            BindUOM();
            BindDiscountType();
        }

        private void AssignColumnTag()
        {
            columnTags[dgvPurchaseItems.Columns["Qty"]] = "DecimalOnly";
            columnTags[dgvPurchaseItems.Columns["HSN"]] = "DecimalOnly";
            columnTags[dgvPurchaseItems.Columns["MRP"]] = "DecimalOnly";
            columnTags[dgvPurchaseItems.Columns["Rate"]] = "DecimalOnly";
            columnTags[dgvPurchaseItems.Columns["Disc"]] = "DecimalOnly";
            columnTags[dgvPurchaseItems.Columns["NetRate"]] = "DecimalOnly";
            columnTags[dgvPurchaseItems.Columns["NetAmount"]] = "DecimalOnly";
            columnTags[dgvPurchaseItems.Columns["GSTRate"]] = "DecimalOnly";
        }

        private void BindSupplier()
        {
            _dtSupplier = _objSuppliers.GetSupplier(0, 1);
            if (_dtSupplier != null && _dtSupplier.Rows.Count > 0)
            {
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "Id";
                cmbSupplier.DataSource = _dtSupplier;
            }
        }

        //Tejas Start - Below Code For Delete Datagridview Item
        private void dgvPurchaseItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvPurchaseItems.SelectedCells.Count > 0)
                {
                    int rowIndex = dgvPurchaseItems.SelectedCells[0].RowIndex;
                    if (rowIndex >= 0 && !dgvPurchaseItems.Rows[rowIndex].IsNewRow)
                    {
                        dgvPurchaseItems.Rows.RemoveAt(rowIndex);
                    }
                }
            }
        }
        //Tejas End

        private void dgvPurchaseItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You Click Save Button.", "BeSpokeERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                if (ValidateDetails())
                {
                    int itemSuccessCount = 0;
                    string invoiceDate = GeneralObjects.DateAsPerSQL(dtpInvoiceDate.Value);
                    string paymentDueDate = GeneralObjects.DateAsPerSQL(dtpPaymentDueDate.Value);
                    DataTable objDataTable = _objPurchases.SavePurchase(txtPurchaseNo.Text.Trim(), cmbSupplier.Text.Trim(), txtGSTNo.Text.Trim(), txtInvoiceNo.Text.Trim(), invoiceDate, txtRemarks.Text.Trim(), Convert.ToDecimal(txtTotalAmount.Text),
                        Convert.ToDecimal(txtTD.Text), Convert.ToDecimal(txtGSTAmount.Text), Convert.ToDecimal(txtNetAmount.Text), paymentDueDate, GeneralObjects.CurrentUserId, GeneralObjects.stationName, txtCity.Text, txtState.Text);

                    if (objDataTable != null && objDataTable.Rows.Count > 0)
                    {
                        int returnStatus = Convert.ToInt32(objDataTable.Rows[0]["ReturnStatus"]);
                        long purchaseId = Convert.ToInt32(objDataTable.Rows[0]["PurchaseId"]);

                        if (returnStatus == 1)
                        {
                            for (int i = 0; i < dgvPurchaseItems.Rows.Count; i++)
                            {
                                if (dgvPurchaseItems.Rows[i].IsNewRow) continue;

                                int itemGroupId = Convert.ToInt32(dgvPurchaseItems.Rows[i].Cells["cmbMaterialCell"].Value);
                                string articleNo = Convert.ToString(dgvPurchaseItems.Rows[i].Cells["ArticleNo"].Value);
                                string classification = Convert.ToString(dgvPurchaseItems.Rows[i].Cells["Classification"].Value);
                                string size = Convert.ToString(dgvPurchaseItems.Rows[i].Cells["Size"].Value);
                                string color = Convert.ToString(dgvPurchaseItems.Rows[i].Cells["Color"].Value);
                                decimal qty = Convert.ToDecimal(dgvPurchaseItems.Rows[i].Cells["Qty"].Value);
                                string uom = Convert.ToString(dgvPurchaseItems.Rows[i].Cells["cmbUOMCell"].FormattedValue);
                                string hsnCode = Convert.ToString(dgvPurchaseItems.Rows[i].Cells["HSN"].Value);
                                decimal supplierMRP = Convert.ToDecimal(dgvPurchaseItems.Rows[i].Cells["MRP"].Value);
                                decimal rate = Convert.ToDecimal(dgvPurchaseItems.Rows[i].Cells["Rate"].Value);
                                int discType = Convert.ToInt32(dgvPurchaseItems.Rows[i].Cells["cmbDiscTypeCell"].Value);
                                decimal discount = Convert.ToDecimal(dgvPurchaseItems.Rows[i].Cells["Disc"].Value);
                                decimal netRate = Convert.ToDecimal(dgvPurchaseItems.Rows[i].Cells["NetRate"].Value);
                                decimal gstRate = Convert.ToDecimal(dgvPurchaseItems.Rows[i].Cells["GSTRate"].Value);

                                bool retFlag = _objPurchases.SavePurchaseItem(purchaseId, itemGroupId, articleNo.Trim(), classification.Trim(), size.Trim(), color.Trim(), qty, uom.Trim(), hsnCode.Trim(), supplierMRP, rate, discType, discount, netRate, gstRate, GeneralObjects.CurrentUserId);
                                if (retFlag)
                                    itemSuccessCount = itemSuccessCount + 1;
                            }

                            if (itemSuccessCount == dgvPurchaseItems.Rows.Count - 1)
                            {
                                MessageBox.Show("Purchase entry has been saved successfully.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DialogResult dialogResult = MessageBox.Show("Would you like to print barcodes for all the items?", "Print Barcodes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    _objrawPrinterHelper = new RawPrinterHelper();
                                    DataTable _dtBarcodeData = _objPurchases.GetBarcodeData(purchaseId);
                                    if (_dtBarcodeData != null && _dtBarcodeData.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < _dtBarcodeData.Rows.Count; i += 2)
                                        {
                                            DataRow dtRow1 = _dtBarcodeData.Rows[i];
                                            string barCodeValue1 = dtRow1["BarcodeValue"].ToString();
                                            string productName1 = dtRow1["ProductName"].ToString();
                                            string articleNo1 = dtRow1["ArticleNo"].ToString();
                                            string size1 = dtRow1["Size"].ToString();
                                            string mrp1 = dtRow1["MRP"].ToString();

                                            string barCodeValue2 = null;
                                            string productName2 = null;
                                            string articleNo2 = null;
                                            string size2 = null;
                                            string mrp2 = null;

                                            if (i + 1 < _dtBarcodeData.Rows.Count)
                                            {
                                                DataRow dtRow2 = _dtBarcodeData.Rows[i + 1];
                                                barCodeValue2 = dtRow2["BarcodeValue"].ToString();
                                                productName2 = dtRow2["ProductName"].ToString();
                                                articleNo2 = dtRow2["ArticleNo"].ToString();
                                                size2 = dtRow2["Size"].ToString();
                                                mrp2 = dtRow2["MRP"].ToString();
                                            }
                                            string barcodePrinter = _objComputerLists.GetBarcodePrinter(Environment.MachineName);
                                            _objrawPrinterHelper.PrintLabel(barcodePrinter, barCodeValue1, productName1, size1, articleNo1, mrp1, barCodeValue2, productName2, size2, articleNo2, mrp2);
                                        }
                                    }
                                }
                                Reset();
                            }
                            else
                            {
                                MessageBox.Show("The purchase entry was saved, but some items could not be saved. Please review and try again.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Purchase entry could not be saved. Please try again.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase : Save");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        //Tejas Start - to Assign Hot Key
        private void frmPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true; // Prevents default beep sound
                btnSave.PerformClick();    // Trigger the save button
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
        //Tejas End


        //Tejas Start - Below Code for Auto Generate Sr. No.
        private void dgvPurchaseItems_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvPurchaseItems.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        //Tejas End

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                MDIMain md = (MDIMain)(this.Parent.Parent);
                frmPurchaseView frmFormName = new frmPurchaseView();
                md.OpenChildForm(frmFormName);
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase : View");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }


        #region "Search Supplier from Database Auto Complete Functionality"
        private void SearchSupplier()
        {
            try
            {
                cmbSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collAutoCompleteText = new AutoCompleteStringCollection();


                if (_dtSupplier != null && _dtSupplier.Rows.Count > 0)
                {
                    for (int i = 0; i < _dtSupplier.Rows.Count; i++)
                    {
                        collAutoCompleteText.Add(_dtSupplier.Rows[i][1].ToString());
                    }
                }
                cmbSupplier.AutoCompleteCustomSource = collAutoCompleteText;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("BOQ : SearchWorkOrder");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        public long GetValueMember(string displayMember)
        {
            Dictionary<string, long> dicValueMember = new Dictionary<string, long>();

            if (_dtSupplier != null && _dtSupplier.Rows.Count > 0)
            {
                for (int i = 0; i < _dtSupplier.Rows.Count; i++)
                {
                    dicValueMember.Add(_dtSupplier.Rows[i][1].ToString(), (long)_dtSupplier.Rows[i][0]);
                }
            }

            return (dicValueMember[displayMember]);
        }
        #endregion

        //Tejas Start - DataGridViewCombobox Editable
        private void dgvPurchaseItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = e.Control as DataGridViewComboBoxEditingControl;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //AutoCompleteStringCollection collAutoCompleteText = new AutoCompleteStringCollection();
            }

            //Tejas Started -- Only decimal Value allow.
            var column = dgvPurchaseItems.Columns[dgvPurchaseItems.CurrentCell.ColumnIndex];

            if (columnTags.TryGetValue(column, out string tag) && tag == "DecimalOnly")
            {
                if (e.Control is TextBox txt)
                {
                    txt.KeyPress -= OnlyDecimal_KeyPress;
                    txt.KeyPress += OnlyDecimal_KeyPress;
                }
            }
        }
        //Tejas End

        //Bind DataGridViewComboBox of Material
        private void BindMaterial()
        {
            _dtItemGroup = _objItemGroup.GetItemGroup(0, 1);
            if (_dtItemGroup != null && _dtItemGroup.Rows.Count > 0)
            {
                cmbMaterialCell.DisplayMember = "GroupName";
                cmbMaterialCell.ValueMember = "Id";
                cmbMaterialCell.DataSource = _dtItemGroup;
            }
        }

        //Bind DataGridViewComboBox of UOM
        private void BindUOM()
        {
            _dtUOM = _objUOM.GetUOM(0, 1);
            if (_dtUOM != null && _dtUOM.Rows.Count > 0)
            {
                cmbUOMCell.DisplayMember = "UnitCode";
                cmbUOMCell.ValueMember = "Id";
                cmbUOMCell.DataSource = _dtUOM;
            }
        }

        //Bind DataGridViewComboBox of Discount Type
        private void BindDiscountType()
        {
            _dtDiscountType = _objGeneralDB.GetListIndexWithMessageText(2);
            if (_dtDiscountType != null && _dtDiscountType.Rows.Count > 0)
            {
                cmbDiscTypeCell.DisplayMember = "MessageText";
                cmbDiscTypeCell.ValueMember = "ListIndex";
                cmbDiscTypeCell.DataSource = _dtDiscountType;
            }
        }

        //Tejas Start -- Below Code For Set Default Value
        private void dgvPurchaseItems_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Size"].Value = "N.A";
            e.Row.Cells["Qty"].Value = "0.00";
            e.Row.Cells["MRP"].Value = "0.00";
            e.Row.Cells["Rate"].Value = "0.00";
            e.Row.Cells["Disc"].Value = "0.00";
            e.Row.Cells["NetRate"].Value = "0.00";
            e.Row.Cells["NetAmount"].Value = "0.00";
            e.Row.Cells["GSTRate"].Value = "0.00";
            e.Row.Cells["cmbDiscTypeCell"].Value = 1;
            e.Row.Cells["cmbUOMCell"].Value = 1;
        }

        //Added Tejas - Calculate Net Amount
        private void dgvPurchaseItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {

                // Get current row
                DataGridViewRow row = dgvPurchaseItems.Rows[e.RowIndex];

                //Tejas Started - Get NetRate After Discount.
                decimal rate = 0;
                int discType = 0;
                decimal discAmt = 0;

                decimal.TryParse(Convert.ToString(row.Cells["Rate"].Value), out rate);
                int.TryParse(Convert.ToString(row.Cells["cmbDiscTypeCell"].Value), out discType);
                decimal.TryParse(Convert.ToString(row.Cells["Disc"].Value), out discAmt);

                decimal netRate = discType == 0 ? (rate - ((rate * discAmt) / 100)) : rate - discAmt;
                row.Cells["NetRate"].Value = netRate.ToString("0.00");
                //Tejas Ended - Get NetRate After Discount.

                //Tejas Started - Get Net Amount 
                decimal quantity = 0;
                decimal unitPrice = 0;

                decimal.TryParse(Convert.ToString(row.Cells["Qty"].Value), out quantity);
                decimal.TryParse(Convert.ToString(row.Cells["NetRate"].Value), out unitPrice);

                // Calculate total
                decimal total = quantity * unitPrice;

                // Set total in the Total column
                row.Cells["NetAmount"].Value = total.ToString("0.00");
                //Tejas Ended - Get Net Amount


            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error while calculating total: " + ex.Message);
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase : Calculate Net Amount : Error while calculating total");
                GeneralObjects.ErrLogger.WritetoLogFile(ex.Message);
            }
        }


        private void dgvPurchaseItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPurchaseItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgvPurchaseItems_CellEndEdit(sender, e);
            }
        }
        //Ended Tejas - Calculate Net Amount


        //Added Tejas for while Select Supplier then Automatically Fetch GST Number
        private void cmbSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataRowView drvSupplier = cmbSupplier.SelectedItem as DataRowView;
                if (drvSupplier != null)
                {
                    txtGSTNo.Text = drvSupplier["GSTNumber"].ToString();
                    txtCity.Text = drvSupplier["City"].ToString();
                    txtState.Text = drvSupplier["State"].ToString();
                }
            }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drvSupplier = cmbSupplier.SelectedItem as DataRowView;
            txtGSTNo.Text = drvSupplier != null ? drvSupplier["GSTNumber"].ToString() : "";
            txtCity.Text = drvSupplier != null ? drvSupplier["City"].ToString() : "";
            txtState.Text = drvSupplier != null ? drvSupplier["State"].ToString() : "";

            //if (drvSupplier != null)
            //    txtGSTNo.Text = drvSupplier["GSTNumber"].ToString();
        }
        //Ended Tejas - while Select Supplier then Automatically Fetch GST Number

        //Added Tejas - Get Total Items
        private int GetActualRowCount(DataGridView dgv)
        {
            int count = dgv.Rows.Count;
            if (dgv.AllowUserToAddRows)
            {
                count -= 1;
            }
            return count;
        }
        //Ended Tejas - Get Total Items

        //Added Tejas - Display Total Item, Total Amount, GST Amount, Net Amount

        private void dgvPurchaseItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //txtTotalItems.Text = Convert.ToString(GetActualRowCount(dgvPurchaseItems));
            //txtTotalAmount.Text = Convert.ToString(GetColumnSum(dgvPurchaseItems, "NetAmount"));
            //txtGSTAmount.Text = Convert.ToString(GetTotalGSTAmount());
            //Tejas Stared - Here F2 Means its display only two decimal value.
            txtTotalItems.Text = Convert.ToString((int)GetActualRowCount(dgvPurchaseItems));
            txtTotalAmount.Text = GetColumnSum(dgvPurchaseItems, "NetAmount").ToString("F2");
            txtGSTAmount.Text = GetTotalGSTAmount().ToString("F2");
            FillGSTAmount(Convert.ToDecimal(txtGSTAmount.Text));

            decimal rawNetAmount = Convert.ToDecimal((Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtTD.Text)) + Convert.ToDecimal(txtGSTAmount.Text));
            decimal roundedTotal = Math.Round(rawNetAmount, 0, MidpointRounding.AwayFromZero);
            txtRoundOff.Text = (roundedTotal - rawNetAmount).ToString("F2");
            //txtNetAmount.Text = Convert.ToString((Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtTD.Text)) + Convert.ToDecimal(txtGSTAmount.Text));
            txtNetAmount.Text = roundedTotal.ToString("F2");
        }

        private void dgvPurchaseItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //txtTotalItems.Text = Convert.ToString(GetActualRowCount(dgvPurchaseItems));
            //txtTotalAmount.Text = Convert.ToString(GetColumnSum(dgvPurchaseItems, "NetAmount"));
            //txtGSTAmount.Text = Convert.ToString(GetTotalGSTAmount());
            //txtNetAmount.Text = Convert.ToString((Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtTD.Text)) + Convert.ToDecimal(txtGSTAmount.Text));
            txtTotalItems.Text = Convert.ToString((int)GetActualRowCount(dgvPurchaseItems));
            txtTotalAmount.Text = GetColumnSum(dgvPurchaseItems, "NetAmount").ToString("F2");
            txtGSTAmount.Text = GetTotalGSTAmount().ToString("F2");
            FillGSTAmount(Convert.ToDecimal(txtGSTAmount.Text));

            decimal rawNetAmount = Convert.ToDecimal((Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtTD.Text)) + Convert.ToDecimal(txtGSTAmount.Text));
            decimal roundedTotal = Math.Round(rawNetAmount, 0, MidpointRounding.AwayFromZero);
            txtRoundOff.Text = (roundedTotal - rawNetAmount).ToString("F2");
            txtNetAmount.Text = roundedTotal.ToString("F2");
        }

        private void dgvPurchaseItems_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //txtTotalItems.Text = Convert.ToString(GetActualRowCount(dgvPurchaseItems));
            //txtTotalAmount.Text = Convert.ToString(GetColumnSum(dgvPurchaseItems, "NetAmount"));
            //txtGSTAmount.Text = Convert.ToString(GetTotalGSTAmount());
            //txtNetAmount.Text = Convert.ToString((Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtTD.Text)) + Convert.ToDecimal(txtGSTAmount.Text));
            txtTotalItems.Text = Convert.ToString((int)GetActualRowCount(dgvPurchaseItems));
            txtTotalAmount.Text = GetColumnSum(dgvPurchaseItems, "NetAmount").ToString("F2");
            txtGSTAmount.Text = GetTotalGSTAmount().ToString("F2");
            FillGSTAmount(Convert.ToDecimal(txtGSTAmount.Text));

            decimal rawNetAmount = Convert.ToDecimal((Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtTD.Text)) + Convert.ToDecimal(txtGSTAmount.Text));
            decimal roundedTotal = Math.Round(rawNetAmount, 0, MidpointRounding.AwayFromZero);
            txtRoundOff.Text = (roundedTotal - rawNetAmount).ToString("F2");
            txtNetAmount.Text = roundedTotal.ToString("F2");
        }

        //Ended Tejas - Display Total Item, Total Amount, GST Amount, Net Amount


        //Added Tejas - Get Column Sum
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
        //Ended Tejas - Get Column Sum

        private decimal GetTotalGSTAmount()
        {
            decimal totalGSTAmt = 0;
            foreach (DataGridViewRow row in dgvPurchaseItems.Rows)
            {
                if (row.IsNewRow) continue;

                decimal.TryParse((string)row.Cells["NetAmount"].Value, out decimal netAmount);
                decimal.TryParse((string)row.Cells["GSTRate"].Value, out decimal gstRate);
                if (decimal.TryParse(Convert.ToString((netAmount * gstRate) / 100), out decimal val))
                {
                    totalGSTAmt += val;
                }
            }
            return totalGSTAmt;
        }

        private void txtTD_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTD.Text))
            {
                //txtNetAmount.Text = Convert.ToString((Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtTD.Text)) + Convert.ToDecimal(txtGSTAmount.Text));
                decimal rawNetAmount = Convert.ToDecimal((Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtTD.Text)) + Convert.ToDecimal(txtGSTAmount.Text));
                decimal roundedTotal = Math.Round(rawNetAmount, 0, MidpointRounding.AwayFromZero);
                txtRoundOff.Text = (roundedTotal - rawNetAmount).ToString("F2");
                txtNetAmount.Text = roundedTotal.ToString("F2");
            }
        }

        //Tejas Started - Validate Invoice Number
        private void txtInvoiceNo_Leave(object sender, EventArgs e)
        {
            if (GeneralObjects.isNavigating) return;

            if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
            {
                txtInvoiceNo.BackColor = System.Drawing.Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Invoice Number required!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtInvoiceNo.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }
        //Tejas Ended

        //Tejas Started - Validate Supplier
        private void cmbSupplier_Leave(object sender, EventArgs e)
        {
            if (GeneralObjects.isNavigating) return; //if switch to another form.

            if (string.IsNullOrWhiteSpace(cmbSupplier.Text))
            {
                cmbSupplier.BackColor = System.Drawing.Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Supplier required!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cmbSupplier.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }
        //Tejas Ended - Validate Supplier


        //Tejas Started -- Validation for Only Number and Single Decimal Allow
        private void OnlyDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Allow control keys (like Backspace)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow one decimal point
            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;

            // Block all other characters
            e.Handled = true;
        }

        //Tejas Ended -- Validation for Only Number and Single Decimal Allow

        //Tejas Started -- For Validate Required Column
        private void dgvPurchaseItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvPurchaseItems.Rows[e.RowIndex].IsNewRow) return;

            var column = dgvPurchaseItems.Columns[e.ColumnIndex];
            string value = e.FormattedValue?.ToString().Trim();
            var cell = dgvPurchaseItems.Rows[e.RowIndex].Cells[e.ColumnIndex];

            bool hasError = false;
            string errorMessage = "";

            if (requiredColumns.Contains(column.Name) && string.IsNullOrWhiteSpace(value))
            {
                hasError = true;
                errorMessage = $"{column.HeaderText} is required.";
            }
            else if (zeroNotAllowedColumns.Contains(column.Name))
            {
                if (string.IsNullOrWhiteSpace(value) || !decimal.TryParse(value, out decimal number) || number == 0)
                {
                    hasError = true;
                    errorMessage = $"{column.HeaderText} must be a number and not 0.00";
                }
            }

            if (hasError)
            {
                // Highlight the cell
                cell.Style.BackColor = System.Drawing.Color.MistyRose;

                // Show message without blocking movement
                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(errorMessage, "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }));

                // Do NOT cancel — just notify
                // e.Cancel = true; // ← REMOVE or COMMENT this
            }
            else
            {
                // Reset background if valid
                cell.Style.BackColor = System.Drawing.Color.White;
            }
        }

        private void dgvPurchaseItems_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dgvPurchaseItems.Rows[e.RowIndex].Cells[e.ColumnIndex];

            // Only reset color if the cell is not already showing an error
            if (cell.Style.BackColor != System.Drawing.Color.MistyRose)
            {
                cell.Style.BackColor = System.Drawing.Color.White;
            }
        }

        //Tejas Ended -- For Validate Required Column

        private bool ValidateDetails()
        {
            bool retFlag = true;
            if (string.IsNullOrWhiteSpace(cmbSupplier.Text) && cmbSupplier.Text.Length == 0)
            {
                MessageBox.Show("Supplier should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retFlag = false;
                cmbSupplier.Focus();
                cmbSupplier.BackColor = System.Drawing.Color.MistyRose;
                return retFlag;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text) && txtInvoiceNo.Text.Length == 0)
            {
                MessageBox.Show("Invoice number should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retFlag = false;
                txtInvoiceNo.BackColor = System.Drawing.Color.MistyRose;
                txtInvoiceNo.Focus();
                return retFlag;
            }

            if (string.IsNullOrWhiteSpace(txtGSTNo.Text) && txtGSTNo.Text.Length == 0)
            {
                MessageBox.Show("GST Number should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retFlag = false;
                txtGSTNo.Focus();
                txtGSTNo.BackColor = System.Drawing.Color.MistyRose;
                return retFlag;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text) && txtCity.Text.Length == 0)
            {
                MessageBox.Show("City should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retFlag = false;
                txtCity.Focus();
                txtCity.BackColor = System.Drawing.Color.MistyRose;
                return retFlag;
            }


            if (string.IsNullOrWhiteSpace(txtState.Text) && txtState.Text.Length == 0)
            {
                MessageBox.Show("State should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retFlag = false;
                txtState.Focus();
                txtState.BackColor = System.Drawing.Color.MistyRose;
                return retFlag;
            }

            if (dgvPurchaseItems.Rows.Count - 1 == 0)
            {
                MessageBox.Show("purchase items should not be empty!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retFlag = false;
                return retFlag;
            }

            //Validate Required Purchase Items
            foreach (DataGridViewRow row in dgvPurchaseItems.Rows)
            {
                // Skip the new row placeholder
                if (row.IsNewRow) continue;

                var materialCell = row.Cells["cmbMaterialCell"].Value;
                var articleNoCell = row.Cells["ArticleNo"].Value;
                var qtyCell = row.Cells["Qty"].Value;
                var uomCell = row.Cells["cmbUOMCell"].Value;
                var mrpCell = row.Cells["MRP"].Value;
                var rateCell = row.Cells["Rate"].Value;
                var netRateCell = row.Cells["NetRate"].Value;
                var netAmountCell = row.Cells["NetAmount"].Value;


                // Check if cell is null or empty
                if (materialCell == null || string.IsNullOrWhiteSpace(materialCell.ToString()))
                {
                    MessageBox.Show("Material is required in all rows.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["cmbMaterialCell"].Style.BackColor = System.Drawing.Color.MistyRose;
                    dgvPurchaseItems.CurrentCell = row.Cells["cmbMaterialCell"];
                    retFlag = false;
                    return retFlag;
                }

                if (articleNoCell == null || string.IsNullOrWhiteSpace(articleNoCell.ToString()))
                {
                    MessageBox.Show("Article No. is required in all rows.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["ArticleNo"].Style.BackColor = System.Drawing.Color.MistyRose;
                    dgvPurchaseItems.CurrentCell = row.Cells["ArticleNo"];
                    retFlag = false;
                    return retFlag;
                }

                if (qtyCell == null || !decimal.TryParse(qtyCell.ToString(), out decimal qty) || qty == 0)
                {
                    MessageBox.Show("Qty must be a number greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["Qty"].Style.BackColor = System.Drawing.Color.MistyRose;
                    dgvPurchaseItems.CurrentCell = row.Cells["Qty"];
                    retFlag = false;
                    return retFlag;
                }

                if (uomCell == null || string.IsNullOrWhiteSpace(uomCell.ToString()))
                {
                    MessageBox.Show("UOM is required in all rows.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["cmbUOMCell"].Style.BackColor = System.Drawing.Color.MistyRose;
                    dgvPurchaseItems.CurrentCell = row.Cells["cmbUOMCell"];
                    retFlag = false;
                    return retFlag;
                }

                if (mrpCell == null || !decimal.TryParse(mrpCell.ToString(), out decimal mrp) || mrp == 0)
                {
                    MessageBox.Show("MRP must be a number greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["MRP"].Style.BackColor = System.Drawing.Color.MistyRose;
                    dgvPurchaseItems.CurrentCell = row.Cells["MRP"];
                    retFlag = false;
                    return retFlag;
                }

                if (rateCell == null || !decimal.TryParse(rateCell.ToString(), out decimal rate) || rate == 0)
                {
                    MessageBox.Show("Rate must be a number greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["Rate"].Style.BackColor = System.Drawing.Color.MistyRose;
                    dgvPurchaseItems.CurrentCell = row.Cells["Rate"];
                    retFlag = false;
                    return retFlag;
                }

                if (netRateCell == null || !decimal.TryParse(netRateCell.ToString(), out decimal netRate) || netRate == 0)
                {
                    MessageBox.Show("Net Rate must be a number greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["NetRate"].Style.BackColor = System.Drawing.Color.MistyRose;
                    dgvPurchaseItems.CurrentCell = row.Cells["NetRate"];
                    retFlag = false;
                    return retFlag;
                }

                if (netAmountCell == null || !decimal.TryParse(netAmountCell.ToString(), out decimal netAmount) || netAmount == 0)
                {
                    MessageBox.Show("Net Amount must be a number greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["NetAmount"].Style.BackColor = System.Drawing.Color.MistyRose;
                    dgvPurchaseItems.CurrentCell = row.Cells["NetAmount"];
                    retFlag = false;
                    return retFlag;
                }
            }

            return retFlag;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralObjects.isNavigating = true;
                MDIMain md = (MDIMain)(this.Parent.Parent);
                frmHome frmFormName = new frmHome();
                md.OpenChildForm(frmFormName);
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase : Cancel");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void Reset()
        {
            txtPurchaseNo.Text = _objPurchases.GetNewPurchaseNo();
            cmbSupplier.Text = "";
            dtpInvoiceDate.Value = DateTime.Today;
            txtInvoiceNo.Text = "";
            txtGSTNo.Text = "";
            txtRemarks.Text = "";
            txtTotalItems.Text = "0";
            dtpPaymentDueDate.Value = DateTime.Today;
            txtTotalAmount.Text = "0.00";
            txtTD.Text = "0.00";
            txtGSTAmount.Text = "0.00";
            txtIGST.Text = "0.00";
            txtCGST.Text = "0.00";
            txtSGST.Text = "0.00";
            txtRoundOff.Text = "0.00";
            txtNetAmount.Text = "0.00";
            txtCity.Text = "";
            txtState.Text = "";

            dgvPurchaseItems.Rows.Clear();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                MDIMain md = (MDIMain)(this.Parent.Parent);
                frmSupplier frmFormName = new frmSupplier();
                md.OpenChildForm(frmFormName);
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase : Supplier");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void cmbSupplier_TextChanged(object sender, EventArgs e)
        {
            DataRowView drvSupplier = cmbSupplier.SelectedItem as DataRowView;
            txtGSTNo.Text = drvSupplier != null ? drvSupplier["GSTNumber"].ToString() : "";
            txtCity.Text = drvSupplier != null ? drvSupplier["City"].ToString() : "";
            txtState.Text = drvSupplier != null ? drvSupplier["State"].ToString() : "";
        }

        private void FillGSTAmount(decimal gstAmount)
        {
            try
            {
                string prjCustState = Convert.ToString(_objGeneralSettings.GetParamValue((int)GeneralSettingParamName.PrjState));
                if (prjCustState == txtState.Text.Trim())
                {
                    txtCGST.Text = (gstAmount / 2).ToString("F2");
                    txtSGST.Text = (gstAmount / 2).ToString("F2");
                    txtIGST.Text = "0.00";
                }
                else
                {
                    txtIGST.Text = gstAmount.ToString("F2");
                    txtCGST.Text = "0.00";
                    txtSGST.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase : FillGSTAmount");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            MDIMain md = (MDIMain)(this.Parent.Parent);
            frmUpdatePaymentStaus frmupdatepaymentStatus = new frmUpdatePaymentStaus();
            md.OpenChildForm(frmupdatepaymentStatus);
        }

        private void txtTD_KeyPress(object sender, KeyPressEventArgs e)
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
