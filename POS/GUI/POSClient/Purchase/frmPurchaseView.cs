using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NDatabaseAccess;

namespace POSClient
{
    public partial class frmPurchaseView : Form
    {
        #region "Private Variables"
        Purchases _objPurchases = null;
        GenerateBarcode _objGenBarcode;
        RawPrinterHelper _objrawPrinterHelper;
        DataTable _dtPurchaseView = null;
        Suppliers _objSuppliers = null;
        ComputerLists _objComputerLists = null;
        ItemsGroup _objItemGroup = null;

        private string _barcodeValue;
        private string _productName;
        private string _size;
        private string _articleNo;
        private string _mrp;
        private int _invId;
        private DataTable _dtSupplier;
        private DataTable _dtPurchase;
        private DataTable _dtMaterial;
        TextBox editingTextBox = null;
        private int selectedCount = 0; // Initialize counter

        private string _searchPlaceHolder = "Search here by Supplier Name, Material, Article No. and press Get Data button";
        #endregion

        #region "Constructor/Destructor"
        public frmPurchaseView()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
            dgvPurchaseView.CellDoubleClick += dgvPurchaseView_CellDoubleClick;
            dgvPurchaseView.KeyDown += dgvPurchaseView_KeyDown;
            dgvPurchaseView.CellEndEdit += dgvPurchaseView_CellEndEdit;
            dgvPurchaseView.EditingControlShowing += dgvPurchaseView_EditingControlShowing;
        }

        ~frmPurchaseView()
        {
            if (_objPurchases != null)
                _objPurchases = null;

            if (_objGenBarcode != null)
                _objGenBarcode = null;

            if (_objrawPrinterHelper != null)
                _objrawPrinterHelper = null;

            if (_dtPurchaseView != null)
                _dtPurchaseView = null;

            if (_objComputerLists != null)
                _objComputerLists = null;
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
            lblFromDate.ForeColor = Themes.LabelForeColor;
            lblFromDate.BackColor = Themes.LabelBackColor;

            lblToDate.ForeColor = Themes.LabelForeColor;
            lblToDate.BackColor = Themes.LabelBackColor;

            lblSupplier.ForeColor = Themes.LabelForeColor;
            lblSupplier.BackColor = Themes.LabelBackColor;

            chkStockAvaliable.ForeColor = Themes.LabelForeColor;
            chkStockAvaliable.BackColor = Themes.LabelBackColor;

            lblMaterial.ForeColor = Themes.LabelForeColor;
            lblMaterial.BackColor = Themes.LabelBackColor;

            lblPurchaseNo.ForeColor = Themes.LabelForeColor;
            lblPurchaseNo.BackColor = Themes.LabelBackColor;

            lblShortcut2.ForeColor = Themes.LabelForeColor;
            lblShortcut2.BackColor = Themes.LabelBackColor;

            //Buttons
            btnGetData.FlatStyle = FlatStyle.Flat;
            btnGetData.BackColor = Themes.ButtonBackColor;
            btnGetData.ForeColor = Themes.ButtonForeColor;
            btnGetData.FlatAppearance.BorderSize = 1;
            btnGetData.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.BackColor = Themes.ButtonBackColor;
            btnPrint.ForeColor = Themes.ButtonForeColor;
            btnPrint.FlatAppearance.BorderSize = 1;
            btnPrint.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.BackColor = Themes.ButtonBackColor;
            btnReset.ForeColor = Themes.ButtonForeColor;
            btnReset.FlatAppearance.BorderSize = 1;
            btnReset.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.BackColor = Themes.ButtonBackColor;
            btnPrint.ForeColor = Themes.ButtonForeColor;
            btnPrint.FlatAppearance.BorderSize = 1;
            btnPrint.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            txtSearch.ForeColor = Themes.searchPlaceHolder;

            Themes.DataGridTheme(dgvPurchaseView);
        }

        #endregion

        private void frmPurchaseView_Load(object sender, EventArgs e)
        {
            _objPurchases = new Purchases(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objSuppliers = new Suppliers(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objComputerLists = new ComputerLists(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objGenBarcode = new GenerateBarcode();
            _objrawPrinterHelper = new RawPrinterHelper();
            _objItemGroup = new ItemsGroup(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

            // Set default date range
            dtpFromDate.Value = DateTime.Today.AddDays(-7); // 7 days before today
            dtpToDate.Value = DateTime.Today;               // Today's date
            dtpFromDate.MaxDate = DateTime.Today;
            dtpToDate.MaxDate = DateTime.Today;
            btnSelectedCount.Text = "Selected Row Count : " + selectedCount;

            //_dtPurchaseView = _objPurchases.GetPurchaseView(dtpFromDate.Value.ToString("yyyy-MM-dd"), dtpToDate.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(cmbSupplier.SelectedValue));
            BindPurchaseViewGrid();
            BindSupplier();
            SearchSupplier();
            cmbSupplier.SelectedIndex = -1;
            //BindPurchseNo();
            SearchPurchaseNo();
            cmbPurchaseNo.SelectedIndex = -1;
            BindMaterialCmb();
            SearchMaterial();
            cmbMaterial.SelectedIndex = -1;

            txtSearch.Text = _searchPlaceHolder;
            btnTotalSelectedCount.Text = "Selected Row Count : " + selectedCount;
            dtpFromDate.Focus();

            if (_dtPurchaseView != null && _dtPurchaseView.Rows.Count > 0)
            {
                dgvPurchaseView.DataSource = _dtPurchaseView;
                _productName = Convert.ToString(dgvPurchaseView.Rows[0].Cells["GroupName"].Value);
                _size = Convert.ToString(dgvPurchaseView.Rows[0].Cells["Size"].Value);
                _articleNo = Convert.ToString(dgvPurchaseView.Rows[0].Cells["ArticleNo"].Value);
                _mrp = Convert.ToString(dgvPurchaseView.Rows[0].Cells["SalePrice"].Value);
                _barcodeValue = Convert.ToString(dgvPurchaseView.Rows[0].Cells["Barcode"].Value);

                //Generate Barcode Image and Display on Screen
                Bitmap barcode = _objGenBarcode.Create(35, _barcodeValue, 0, false, 1);
                pbBarcode.Image = (Bitmap)_objGenBarcode.GenerateLabelPreviewWithBitmap(barcode, _productName, _size, _articleNo, _mrp);
                //GenerateLabelPreviewWithBitmap(barcode, _productName, _size, _articleNo, _mrp);
            }
            
            //FillPrinterList();
        }

        //Below Code for Generate Barcode.
        //private void GenerateLabelPreviewWithBitmap(Bitmap barcodeBitmap, string productName, string size, string artNo, string mrp)
        //{
        //    try
        //    {
        //        int dpi = 85;
        //        float labelWidthInches = 2.0f;
        //        float labelHeightInches = 1.0f;

        //        int width = (int)(labelWidthInches * dpi);
        //        int height = (int)(labelHeightInches * dpi);

        //        Bitmap labelBitmap = new Bitmap(width, height);
        //        labelBitmap.SetResolution(dpi, dpi);

        //        using (Graphics g = Graphics.FromImage(labelBitmap))
        //        {
        //            g.Clear(Color.White);

        //            // Fonts
        //            Font labelFont = new Font("Segoe UI", 7F, FontStyle.Bold);
        //            Font valueFont = new Font("Segoe UI", 7F, FontStyle.Regular);
        //            Brush brush = Brushes.Black;

        //            // Barcode area
        //            int barcodeHeight = (int)(height * 0.45);
        //            Rectangle barcodeArea = new Rectangle(5, 5, width - 10, barcodeHeight);
        //            if (barcodeBitmap != null)
        //                g.DrawImage(barcodeBitmap, barcodeArea);
        //            else
        //                g.DrawString("Barcode image not available", valueFont, Brushes.Red, new PointF(10, 10));

        //            // Text content
        //            float textY = barcodeArea.Bottom + 2;
        //            float lineHeight = valueFont.GetHeight(g) + 1;

        //            // Draw "Product:" label and value
        //            g.DrawString("Product:", labelFont, brush, new PointF(5, textY));
        //            g.DrawString(productName, valueFont, brush, new PointF(40, textY));
        //            textY += lineHeight;

        //            // Draw "Size:" and "Art no."
        //            g.DrawString("Size:", labelFont, brush, new PointF(5, textY));
        //            g.DrawString(size, valueFont, brush, new PointF(30, textY));
        //            g.DrawString("Art no.", labelFont, brush, new PointF(60, textY));
        //            g.DrawString(artNo, valueFont, brush, new PointF(90, textY));
        //            textY += lineHeight;

        //            // Draw "MRP:"
        //            g.DrawString("MRP:", labelFont, brush, new PointF(5, textY));
        //            g.DrawString(mrp, valueFont, brush, new PointF(30, textY));
        //        }
        //        pbBarcode.Image = labelBitmap;
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralObjects.ErrLogger.WritetoLogFile("Purchase View : GenerateLabelPreviewWithBitmap");
        //        GeneralObjects.ErrLogger.WritetoLogFile(ex);
        //    }
        //}

        private void GetSelectedRowData(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvPurchaseView.Rows[e.RowIndex];
                _productName = Convert.ToString(row.Cells["GroupName"].Value);
                _size = Convert.ToString(row.Cells["Size"].Value);
                _articleNo = Convert.ToString(row.Cells["ArticleNo"].Value);
                _mrp = Convert.ToString(row.Cells["SalePrice"].Value);
                _barcodeValue = Convert.ToString(row.Cells["Barcode"].Value);
                _invId = Convert.ToInt32(row.Cells["InventoryId"].Value);
                Bitmap barcode = _objGenBarcode.Create(35, _barcodeValue, 0, false, 1);
                pbBarcode.Image = (Bitmap)_objGenBarcode.GenerateLabelPreviewWithBitmap(barcode, _productName, _size, _articleNo, _mrp);
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase View : GetSelectedRowData");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void dgvPurchaseView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetSelectedRowData(sender, e);
        }

        private void dgvPurchaseView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetSelectedRowData(sender, e);
        }

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    Bitmap barcode = _objGenBarcode.Create(35, "A00001", 0, false, 1);
        //    _objGenBarcode.PrintLabel(_objGenBarcode.GenerateLabelPreviewWithBitmap(barcode, "Saree", "M", "S0001", "8999"), cmbPrinter.Text);
        //}


        //private void FillPrinterList()
        //{
        //    PrintDocument prtdoc = new PrintDocument();
        //    string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
        //    foreach (String strPrinter in PrinterSettings.InstalledPrinters)
        //    {
        //        cmbPrinter.Items.Add(strPrinter);
        //        if (strPrinter == strDefaultPrinter)
        //        {
        //            cmbPrinter.SelectedIndex = cmbPrinter.Items.IndexOf(strPrinter);
        //        }
        //    }
        //}

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
                GeneralObjects.ErrLogger.WritetoLogFile("Supplier : SearchSupplier");
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

        //private void BindPurchseNo()
        //{
        //    _dtPurchase = _objPurchases.GetPurchaseNoForFilter();
        //    if (_dtPurchase != null && _dtSupplier.Rows.Count > 0)
        //    {
        //        cmbPurchaseNo.DisplayMember = "PurchaseNo";
        //        cmbPurchaseNo.ValueMember = "Id";
        //        cmbPurchaseNo.DataSource = _dtPurchase;
        //    }
        //}

        #region "Search Purchase Number from Database Auto Complete Functionality"
        private void SearchPurchaseNo()
        {
            try
            {
                cmbPurchaseNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbPurchaseNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collAutoCompleteText = new AutoCompleteStringCollection();

                if (_dtPurchase != null && _dtPurchase.Rows.Count > 0)
                {
                    foreach (DataRow row in _dtPurchase.Rows)
                    {
                        string pono = row["PurchaseNo"].ToString();
                        if (!string.IsNullOrWhiteSpace(pono) && !collAutoCompleteText.Contains(pono))
                        {
                            collAutoCompleteText.Add(pono);
                        }
                    }
                }

                cmbPurchaseNo.AutoCompleteCustomSource = collAutoCompleteText;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase View : SearchPurchase");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        public long GetValueMemberForPurchaseNo(string displayMember)
        {
            Dictionary<string, long> dicValueMember = new Dictionary<string, long>();

            if (_dtPurchase != null && _dtPurchase.Rows.Count > 0)
            {
                for (int i = 0; i < _dtPurchase.Rows.Count; i++)
                {
                    dicValueMember.Add(_dtPurchase.Rows[i][1].ToString(), (long)_dtPurchase.Rows[i][0]);
                }
            }

            return (dicValueMember[displayMember]);
        }
        #endregion

        private void BindMaterialCmb()
        {
            _dtMaterial = _objItemGroup.GetItemGroup(0, 1);
            if (_dtMaterial != null && _dtMaterial.Rows.Count > 0)
            {
                //DataRow dr = _dtMaterial.NewRow();
                //dr["Id"] = 0;
                //dr["GroupName"] = "All";
                //_dtMaterial.Rows.InsertAt(dr, 0);

                cmbMaterial.DisplayMember = "GroupName";
                cmbMaterial.ValueMember = "Id";
                cmbMaterial.DataSource = _dtMaterial;
            }
        }

        #region "Search Material from Database Auto Complete Functionality"
        private void SearchMaterial()
        {
            try
            {
                cmbMaterial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbMaterial.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collAutoCompleteText = new AutoCompleteStringCollection();

                if (_dtMaterial != null && _dtMaterial.Rows.Count > 0)
                {
                    foreach (DataRow row in _dtMaterial.Rows)
                    {
                        string groupName = row["GroupName"].ToString();
                        if (!string.IsNullOrWhiteSpace(groupName) && !collAutoCompleteText.Contains(groupName))
                        {
                            collAutoCompleteText.Add(groupName);
                        }
                    }
                }

                cmbMaterial.AutoCompleteCustomSource = collAutoCompleteText;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase View : SearchMaterial");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
        #endregion

        private void BindPurchaseViewGrid()
        {
            try
            {
                _dtPurchaseView = _objPurchases.GetPurchaseView(dtpFromDate.Value.ToString("yyyy-MM-dd"), dtpToDate.Value.ToString("yyyy-MM-dd"), txtSearch.Text == _searchPlaceHolder ? "" : txtSearch.Text);

                if (_dtPurchaseView != null && _dtPurchaseView.Rows.Count > 0)
                {
                    dgvPurchaseView.DataSource = _dtPurchaseView;

                    // Check if checkbox column exists, if not, add it
                    if (!dgvPurchaseView.Columns.Contains("Select"))
                    {
                        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                        chk.Name = "Select";
                        chk.HeaderText = "";  // Set empty header text to hide the column header
                        chk.Width = 30;
                        chk.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvPurchaseView.Columns.Insert(0, chk);  // Insert as first column
                    }

                    ////If Column name is 'SalePrice' price it should be editable
                    dgvPurchaseView.ReadOnly = false;
                    foreach (DataGridViewColumn column in dgvPurchaseView.Columns)
                    {
                        if (column.Name != "Select")
                            //if (column.Name != "SalePrice" && column.Name != "Select")
                                column.ReadOnly = true;
                    }


                    _productName = Convert.ToString(dgvPurchaseView.Rows[0].Cells["GroupName"].Value);
                    _size = Convert.ToString(dgvPurchaseView.Rows[0].Cells["Size"].Value);
                    _articleNo = Convert.ToString(dgvPurchaseView.Rows[0].Cells["ArticleNo"].Value);
                    _mrp = Convert.ToString(dgvPurchaseView.Rows[0].Cells["SalePrice"].Value);
                    _barcodeValue = Convert.ToString(dgvPurchaseView.Rows[0].Cells["Barcode"].Value);

                    dgvPurchaseView.Columns["InventoryId"].Visible = false;
                    dgvPurchaseView.Columns["Barcode"].Visible = false;

                    dgvPurchaseView.Columns["PurchaseNo"].HeaderText = "Purchase No.";
                    dgvPurchaseView.Columns["PurchaseDate"].HeaderText = "Purchase Date";
                    dgvPurchaseView.Columns["SupplierName"].HeaderText = "Supplier";
                    dgvPurchaseView.Columns["InvoiceNo"].HeaderText = "Invoice No.";
                    dgvPurchaseView.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                    dgvPurchaseView.Columns["GroupName"].HeaderText = "Material";
                    dgvPurchaseView.Columns["SalePrice"].HeaderText = "Sale Price";
                    dgvPurchaseView.Columns["ArticleNo"].HeaderText = "Article No.";
                    dgvPurchaseView.Columns["HSNCode"].HeaderText = "HSN Code";

                    dgvPurchaseView.Columns["PurchaseNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvPurchaseView.Columns["PurchaseDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["SupplierName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["InvoiceNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["InvoiceDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["GroupName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["ArticleNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["Barcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["Size"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvPurchaseView.Columns["Color"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvPurchaseView.Columns["HSNCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPurchaseView.Columns["UOM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    //Auto Size Column Mode
                    dgvPurchaseView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgvPurchaseView.Columns["PurchaseNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["PurchaseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["SupplierName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvPurchaseView.Columns["InvoiceNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["InvoiceDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["GroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["SalePrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["ArticleNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["Size"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["Color"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["HSNCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvPurchaseView.Columns["UOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                    dgvPurchaseView.Columns["PurchaseNo"].Width = 100;
                    dgvPurchaseView.Columns["PurchaseDate"].Width = 120;
                    dgvPurchaseView.Columns["InvoiceNo"].Width = 90;
                    dgvPurchaseView.Columns["InvoiceDate"].Width = 120;
                    dgvPurchaseView.Columns["GroupName"].Width = 100;
                    dgvPurchaseView.Columns["SalePrice"].Width = 80;
                    dgvPurchaseView.Columns["ArticleNo"].Width = 100;
                    dgvPurchaseView.Columns["Barcode"].Width = 80;
                    dgvPurchaseView.Columns["Quantity"].Width = 90;
                    dgvPurchaseView.Columns["Size"].Width = 90;
                    dgvPurchaseView.Columns["Color"].Width = 90;
                    dgvPurchaseView.Columns["HSNCode"].Width = 90;
                    dgvPurchaseView.Columns["UOM"].Width = 90;

                    //Generate Barcode Image and Display on Screen
                    Bitmap barcode = _objGenBarcode.Create(35, _barcodeValue, 0, false, 1);
                    pbBarcode.Image = (Bitmap)_objGenBarcode.GenerateLabelPreviewWithBitmap(barcode, _productName, _size, _articleNo, _mrp);
                    //GenerateLabelPreviewWithBitmap(barcode, _productName, _size, _articleNo, _mrp);

                    // Add the Select All checkbox in the header
                    AddHeaderCheckBox();
                }
                else
                {
                    dgvPurchaseView.DataSource = null;
                    _dtPurchaseView = null;
                    pbBarcode.Image = null;
                    Bitmap barcode = null;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Purchase View : BindPurchaseViewGrid");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void dgvPurchaseView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvPurchaseView.Columns[e.ColumnIndex].Name == "SalePrice")
            {
                dgvPurchaseView.BeginEdit(true);
            }
        }

        private void dgvPurchaseView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvPurchaseView.CurrentCell.ColumnIndex == dgvPurchaseView.Columns["SalePrice"].Index)
            {
                dgvPurchaseView.EndEdit(); // Ends editing and triggers CellEndEdit
                e.Handled = true;
            }
        }

        private void dgvPurchaseView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvPurchaseView.Columns[e.ColumnIndex].Name == "SalePrice")
            //{
            //    string newValueStr = Convert.ToString(dgvPurchaseView.Rows[e.RowIndex].Cells["SalePrice"].Value);

            //    if (string.IsNullOrWhiteSpace(newValueStr))
            //    {
            //        MessageBox.Show("Price should not be empty", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    if (!double.TryParse(newValueStr, out double newPrice))
            //    {
            //        MessageBox.Show("Invalid price entered", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    if (newPrice == 0)
            //    {
            //        MessageBox.Show("Price should not be zero", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    var inventoryId = Convert.ToInt32(dgvPurchaseView.Rows[e.RowIndex].Cells["InventoryId"].Value);

            //    if (Convert.ToDouble(_mrp) != newPrice)
            //    {
            //        int retValue = _objPurchases.UpdateSalePrice(inventoryId, newPrice, GeneralObjects.CurrentUserId, GeneralObjects.stationName);
            //        if (retValue == 1)
            //        {
            //            MessageBox.Show("Sale Price Updated successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            BindPurchaseViewGrid();
            //            return;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to update Sale price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("There is no change in Sale Price", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            if (dgvPurchaseView.Columns[e.ColumnIndex].Name == "SalePrice")
            {
                string newValueStr = Convert.ToString(dgvPurchaseView.Rows[e.RowIndex].Cells["SalePrice"].Value);

                if (string.IsNullOrWhiteSpace(newValueStr))
                {
                    MessageBox.Show("Sale Price should not be empty", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BindPurchaseViewGrid();
                    return;
                }

                double newPrice = Convert.ToDouble(newValueStr);

                if (newPrice == 0)
                {
                    MessageBox.Show("Sale Price should not be zero", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BindPurchaseViewGrid();
                    return;
                }

                if (Convert.ToDouble(_mrp) != newPrice)
                {
                    var inventoryId = Convert.ToInt32(dgvPurchaseView.Rows[e.RowIndex].Cells["InventoryId"].Value);
                    int retValue = _objPurchases.UpdateSalePrice(inventoryId, newPrice, GeneralObjects.CurrentUserId, GeneralObjects.stationName);

                    if (retValue == 1)
                    {
                        MessageBox.Show("Sale Price updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindPurchaseViewGrid();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update Sale Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BindPurchaseViewGrid();
                    }
                }
            }
        }

        private void SalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, and one dot
            TextBox tb = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && tb.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void dgvPurchaseView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvPurchaseView.CurrentCell.ColumnIndex == dgvPurchaseView.Columns["SalePrice"].Index)
            {
                if (editingTextBox != null)
                {
                    editingTextBox.KeyPress -= SalePrice_KeyPress;
                }

                editingTextBox = e.Control as TextBox;

                if (editingTextBox != null)
                {
                    editingTextBox.KeyPress -= SalePrice_KeyPress;
                    editingTextBox.KeyPress += SalePrice_KeyPress;
                }
            }
        }

        private void dgvPurchaseView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvPurchaseView.Columns[e.ColumnIndex].Name == "SalePrice")
            {
                var value = dgvPurchaseView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                _mrp = value != DBNull.Value ? Convert.ToDouble(value).ToString() : "0";
            }
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dgvPurchaseView.CellValueChanged -= dgvPurchaseView_CellValueChanged; // Unsubscribe temporarily
            dgvPurchaseView.EndEdit(); // Force end edit

            CheckBox headerBox = (CheckBox)sender;
            bool isChecked = headerBox.Checked;

            foreach (DataGridViewRow row in dgvPurchaseView.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                if (cell != null)
                {
                    cell.Value = isChecked;
                    // Set color based on checkbox state
                    row.DefaultCellStyle.BackColor = isChecked ? Color.Lavender : Color.White;
                }
            }

            // Update selected count
            selectedCount = isChecked ? dgvPurchaseView.Rows.Count : 0;
            btnSelectedCount.Text = "Selected Row Count : " + selectedCount;

            dgvPurchaseView.CellValueChanged += dgvPurchaseView_CellValueChanged; // Resubscribe
        }

        private List<int> GetSelectedIds()
        {
            List<int> selectedIds = new List<int>();

            foreach (DataGridViewRow row in dgvPurchaseView.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isChecked)
                {
                    int id = Convert.ToInt32(row.Cells["InventoryId"].Value);
                    selectedIds.Add(id);
                }
            }

            return selectedIds;
        }

        private void AddHeaderCheckBox()
        {
            // Create a CheckBox for the header
            CheckBox headerCheckBox = new CheckBox();
            headerCheckBox.Size = new Size(15, 15);
            Point headerCellLocation = dgvPurchaseView.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 5);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            // Add the CheckBox to the DataGridView control (at the appropriate header location)
            dgvPurchaseView.Controls.Add(headerCheckBox);
        }

        private void PrintBarcode()
        {
            var selectedRows = new List<(string barcodevalue, string productname, string size, string articleno, string mrp)>();

            foreach (DataGridViewRow row in dgvPurchaseView.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected)
                {
                    string barcodevalue = row.Cells["Barcode"].Value.ToString();
                    string productname = row.Cells["GroupName"].Value.ToString();
                    string size = row.Cells["Size"].Value.ToString();
                    string articleno = row.Cells["ArticleNo"].Value.ToString();
                    string mrp = row.Cells["SalePrice"].Value.ToString();
                    selectedRows.Add((barcodevalue, productname, size, articleno, mrp));
                }
            }

            for (int i = 0; i < selectedRows.Count; i += 2)
            {
                string barCodeValue1 = selectedRows[i].barcodevalue.ToString();
                string productName1 = selectedRows[i].productname.ToString();
                string articleNo1 = selectedRows[i].articleno.ToString();
                string size1 = selectedRows[i].size.ToString();
                string mrp1 = selectedRows[i].mrp.ToString();

                string barCodeValue2 = null;
                string productName2 = null;
                string articleNo2 = null;
                string size2 = null;
                string mrp2 = null;

                if (i + 1 < selectedRows.Count)
                {

                    barCodeValue2 = selectedRows[i + 1].barcodevalue.ToString();
                    productName2 = selectedRows[i + 1].productname.ToString();
                    articleNo2 = selectedRows[i + 1].articleno.ToString();
                    size2 = selectedRows[i + 1].size.ToString();
                    mrp2 = selectedRows[i + 1].mrp.ToString();
                }

                string barcodePrinter = _objComputerLists.GetBarcodePrinter(Environment.MachineName);
                _objrawPrinterHelper.PrintLabel(barcodePrinter, barCodeValue1, productName1, size1, articleNo1, mrp1,
                                                                         barCodeValue2, productName2, size2, articleNo2, mrp2);
            }
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            List<int> selectedIds = GetSelectedIds(); // Get selected InventoryIds

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Please select at least one item to print.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PrintBarcode();

            // After successful printing, uncheck all selected checkboxes
            foreach (DataGridViewRow row in dgvPurchaseView.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells["Select"] as DataGridViewCheckBoxCell;
                if (chk != null && Convert.ToBoolean(chk.Value))
                {
                    chk.Value = false;
                    row.DefaultCellStyle.BackColor = Color.White; // Remove highlight if you had added any
                }
            }

            selectedCount = 0; // Reset selected count
            btnTotalSelectedCount.Text = "Selected Row Count : 0";
        }

        private void btnGetData_Click_2(object sender, EventArgs e)
        {
            BindPurchaseViewGrid();
        }

        //To Date is not before From Date
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFromDate.Value >= dtpToDate.Value)
            {
                MessageBox.Show("To Date is not before From Date!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpToDate.Value = DateTime.Today;
                return;
            }
        }

        private void dgvPurchaseView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvPurchaseView.Columns[e.ColumnIndex].Name == "Select")
            {
                dgvPurchaseView.EndEdit(); // Ensure value updated

                DataGridViewRow row = dgvPurchaseView.Rows[e.RowIndex];
                bool isSelected = Convert.ToBoolean(dgvPurchaseView.Rows[e.RowIndex].Cells["Select"].Value);

                if (isSelected)
                {
                    selectedCount++; //  Increase count
                    row.DefaultCellStyle.BackColor = Color.Lavender; // Highlight row
                }
                else
                {
                    selectedCount--; //  Decrease count
                    row.DefaultCellStyle.BackColor = Color.White; // Remove highlight
                }

                btnSelectedCount.Text = "Selected Row Count : " + selectedCount;
            }
        }

        //In a DataGridView, when you click a checkbox, the value doesn't immediately change — it only changes after the cell loses focus (after moving to another cell). This is called "dirty state".

        private void dgvPurchaseView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPurchaseView.IsCurrentCellDirty)
            {
                dgvPurchaseView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter text here to search...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Enter text here to search...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = _searchPlaceHolder;
            txtSearch.ForeColor = Themes.searchPlaceHolder;
            dtpFromDate.Value = DateTime.Today.AddDays(-7); // 7 days before today
            dtpToDate.Value = DateTime.Today;
            cmbSupplier.SelectedIndex = -1;
            cmbPurchaseNo.SelectedIndex = -1;
            cmbMaterial.SelectedIndex = -1;
            BindPurchaseViewGrid();
        }

        //For Search Text Box Place Holder
        public void RemovePlaceHolder(object sender, EventArgs e)
        {
            if (txtSearch.Text == _searchPlaceHolder)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Themes.searchTextColor;
            }
        }

        public void AddPlaceHolder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = _searchPlaceHolder;
                txtSearch.ForeColor = Themes.searchPlaceHolder;
            }
            else
            {
                txtSearch.ForeColor = Themes.searchTextColor;
            }
        }
        //End Place Holder

        private void frmPurchaseView_KeyDown(object sender, KeyEventArgs e)
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