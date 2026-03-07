using NDatabaseAccess;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POSClient
{
    public partial class frmSalesView : Form
    {
        #region "private Variable"
        ItemsGroup _objMaterial = null;
        Sale _objSales = null;
        
        private DataTable _dtMaterial;
        private int _CellClickSalesId = 0;

        private bool _subReportFlag = false;
        #endregion

        #region "Constructor/Destructor"
        public frmSalesView()
        {
            InitializeComponent();
            this.KeyPreview = true;
            setTheme();
        }

        ~frmSalesView()
        {
            if (_objMaterial != null)
                _objMaterial = null;

            if (_objSales != null)
                _objSales = null;
        }
        #endregion

        #region "Set Theme"
        private void setTheme()
        {
            this.BackColor = Themes.FormBackColor;

            //Header
            btnHeader.BackColor = Themes.HeaderBackColor;
            btnHeader.ForeColor = Themes.HeaderForeColor;
            btnHeader.FlatStyle = FlatStyle.Flat;
            btnHeader.FlatAppearance.BorderSize = 1;
            btnHeader.FlatAppearance.BorderColor = Themes.HeaderBorderColor;

            //label
            lblFromDt.ForeColor = Themes.LabelForeColor;
            lblFromDt.BackColor = Themes.LabelBackColor;

            lblToDt.ForeColor = Themes.LabelForeColor;
            lblToDt.BackColor = Themes.LabelBackColor;

            lblMobileNo.ForeColor = Themes.LabelForeColor;
            lblMobileNo.BackColor = Themes.LabelBackColor;

            lblMaterial.ForeColor = Themes.LabelForeColor;
            lblMaterial.BackColor = Themes.LabelBackColor;

            lblCustomerName.ForeColor = Themes.LabelForeColor;
            lblCustomerName.BackColor = Themes.LabelBackColor;

            lblShortcut.ForeColor = Themes.LabelForeColor;
            lblShortcut.BackColor = Themes.LabelBackColor;

            Themes.DataGridTheme(dgvViewSales);
        }
        #endregion

        private void frmSalesView_Load(object sender, EventArgs e)
        {
            _objMaterial = new ItemsGroup(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objSales = new Sale(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

            dtpFromDt.Focus();
            // Set default date range
            dtpFromDt.Value = DateTime.Today.AddDays(-7); // 7 days before today
            dtpToDt.Value = DateTime.Today;               // Today's date

            BindMaterialCmb();
            SearchMaterial();
            cmbMaterial.SelectedIndex = -1;
            BindSalesViewGrid();
            BindSalesViewSummary();
        }

        private void BindMaterialCmb()
        {
            _dtMaterial = _objMaterial.GetItemGroup(0, 1);
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

        private void BindSalesViewGrid()
        {
            DataTable objDataTable = _objSales.GetSalesView(Convert.ToInt32(cmbMaterial.SelectedValue), dtpFromDt.Value.ToString("yyyy-MM-dd"), dtpToDt.Value.ToString("yyyy-MM-dd"), txtMobileNo.Text, txtCustomerName.Text);
            if (objDataTable != null && objDataTable.Rows.Count > 0)
            {
                dgvViewSales.DataSource = objDataTable;
                dgvViewSales.Columns["Id"].Visible = false;

                dgvViewSales.Columns["InvNo"].HeaderText = "Invoice No.";
                dgvViewSales.Columns["InvDate"].HeaderText = "Invoice Date";
                dgvViewSales.Columns["CustomerName"].HeaderText = "Customer";
                dgvViewSales.Columns["MobileNumber"].HeaderText = "Mobile No.";
                dgvViewSales.Columns["GroupName"].HeaderText = "Material";
                dgvViewSales.Columns["Quantity"].HeaderText = "Quantity";
                dgvViewSales.Columns["SalePrice"].HeaderText = "Sale Price";
                dgvViewSales.Columns["ArticleNo"].HeaderText = "Article No.";
                dgvViewSales.Columns["HSNCode"].HeaderText = "HSN Code";

                dgvViewSales.Columns["InvNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvViewSales.Columns["InvDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvViewSales.Columns["CustomerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvViewSales.Columns["MobileNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvViewSales.Columns["GroupName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvViewSales.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvViewSales.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvViewSales.Columns["UOM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvViewSales.Columns["HSNCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //Auto Size Column Mode
                dgvViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvViewSales.Columns["InvNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["InvDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvViewSales.Columns["MobileNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["GroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["ArticleNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["Size"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["Color"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["SalePrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["BarCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["UOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvViewSales.Columns["HSNCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                //Width in Date Grid View
                dgvViewSales.Columns["InvNo"].Width = 100;
                dgvViewSales.Columns["InvDate"].Width = 100;
                dgvViewSales.Columns["MobileNumber"].Width = 100;
                dgvViewSales.Columns["GroupName"].Width = 150;
                dgvViewSales.Columns["ArticleNo"].Width = 90;
                dgvViewSales.Columns["Size"].Width = 70;
                dgvViewSales.Columns["Color"].Width = 80;
                dgvViewSales.Columns["Quantity"].Width = 70;
                dgvViewSales.Columns["SalePrice"].Width = 100;
                dgvViewSales.Columns["BarCode"].Width = 70;
                dgvViewSales.Columns["UOM"].Width = 80;
                dgvViewSales.Columns["HSNCode"].Width = 100;
            }
            else
            {
                dgvViewSales.DataSource = null;
            }
        }

        private void BindSalesViewSummary()
        {
            try
            {
                DataTable objDataTable = _objSales.GetSalesViewSummary(Convert.ToInt32(cmbMaterial.SelectedValue), dtpFromDt.Value.ToString("yyyy-MM-dd"), dtpToDt.Value.ToString("yyyy-MM-dd"), txtMobileNo.Text, txtCustomerName.Text);
                if (objDataTable != null && objDataTable.Rows.Count > 0)
                {
                    btnTotalInvoice.Text = "Total Invoice : " +  objDataTable.Rows[0]["TotalInvoice"].ToString();
                    btnTotalSaleQty.Text = "Total Sale Quantity : " + objDataTable.Rows[0]["TotalSaleQty"].ToString();
                    btnTotalSaleAmount.Text = "Total Sale Amount : " +objDataTable.Rows[0]["TotalSaleAmount"].ToString();
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("View Sales : BindSalesViewSummary");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            BindSalesViewGrid();
            BindSalesViewSummary();
        }

        private void RefreshSalesViewGrid(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvViewSales.Rows[e.RowIndex];
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("View Sales : RefreshSalesViewGrid");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void dgvViewSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshSalesViewGrid(sender, e);
        }

        private void dgvViewSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12) // Assuming column index 10 is the "Edit" button
            {
                // Get the Id from the clicked row
                _CellClickSalesId = Convert.ToInt32(dgvViewSales.Rows[e.RowIndex].Cells["Id"].Value);
            }
        }

        private void dgvViewSales_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var dataGridView = (sender as DataGridView);
            if (e.ColumnIndex == 12)
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Default;
        }

        private void dgvViewSales_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;

            //try
            //{
            //    //Set View Bill icon
            //    if (e.ColumnIndex == 12)
            //    {
            //        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            //        e.PaintBackground(e.ClipBounds, false);

            //        var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
            //        var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

            //        //e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, w, h));
            //        e.Graphics.DrawImage(Properties.Resources.preview_24, new Rectangle(x, y, 20, 20));
            //        e.Handled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    GeneralObjects.ErrLogger.WritetoLogFile("View Sales : dgvViewSales_CellPainting");
            //    GeneralObjects.ErrLogger.WritetoLogFile(ex);
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable objExcelData = new DataTable();
            DataTable objTemp = null;
            ExcelUtility objExcelUtility = null;
            string exportedFlag = "";
            string fileName = "";
            try
            {
                //Adding the Columns.
                foreach (DataGridViewColumn column in dgvViewSales.Columns)
                {
                    objExcelData.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows.
                foreach (DataGridViewRow row in dgvViewSales.Rows)
                {
                    objExcelData.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        objExcelData.Rows[objExcelData.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }

                if (objExcelData != null && objExcelData.Rows.Count > 0)
                {
                    objTemp = objExcelData;
                    objTemp.Columns.Remove(objTemp.Columns["Id"]);
                    objExcelData = objTemp;

                    objExcelUtility = new ExcelUtility(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                    fileName = "Sales_" + dtpFromDt.Value.ToString("dd-MM-yyyy") + "_" + dtpToDt.Value.ToString("dd-MM-yyyy");
                    exportedFlag = objExcelUtility.ExportToExcel(objExcelData, fileName);
                    if (!string.IsNullOrEmpty(exportedFlag))
                    {
                        //MessageBox.Show("Sales View SuccessFully exported.", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show($"Data exported successfully to:\n{exportedFlag}", "BespokeERP",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error occurred while exporting excel", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error occurred while exporting excel", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Sales View : Export to Excel");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
            finally
            {
                if (objExcelUtility != null)
                    objExcelUtility = null;

                if (objExcelData != null)
                    objExcelData = null;

                if (objTemp != null)
                    objTemp = null;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Set default date range
            dtpFromDt.Value = DateTime.Today.AddDays(-7); // 7 days before today
            dtpToDt.Value = DateTime.Today;               // Today's date
            cmbMaterial.SelectedIndex = -1;
            txtCustomerName.Text = "";
            txtMobileNo.Text = "";
            BindSalesViewGrid();
        }

        //only Allow number in Mobile Number Field.
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

        private void frmSalesView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show("Are you sure you want to close this form?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
