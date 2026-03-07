using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NDatabaseAccess;

namespace POSClient
{
    public partial class frmInventory : Form
    {
        #region "Private Variable"
        Inventory _objInventory = null;
        ExcelUtility objExcelUtility = null;
        Suppliers _objSuppliers = null;
        ItemsGroup _objItemGrp = null;
        

        private DataTable _dtSupplier;
        private DataTable _dtMaterial;
        private DataTable _dtArticleNo;
        bool _supplierData = false;
        bool _nonMovingData = false;
        #endregion

        #region "Constructor/Destructor"
        ~frmInventory()
        {
            if (_objInventory != null)
                _objInventory = null;

            if (objExcelUtility != null)
                objExcelUtility = null;

            if (_objSuppliers != null)
                _objSuppliers = null;

            if (_dtSupplier != null)
                _dtSupplier = null;

            if (_objItemGrp != null)
                _objItemGrp = null;

            if(_dtMaterial != null)
                _dtMaterial = null;
        }

        #endregion

        public frmInventory()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }
        private void frmInventory_Load(object sender, EventArgs e)
        {
            cmbSupplier.Focus();
         
          
            _objInventory = new Inventory(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objSuppliers = new Suppliers(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objItemGrp = new ItemsGroup(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            try
            {               
                BindSupplier();
                cmbSupplier.SelectedIndex = -1;
                SearchSupplier();

                BindMaterial();
                cmbMaterial.SelectedIndex = -1;
                SearchMaterial();

                BindArticleNo();
                cmbArticleNo.SelectedIndex = -1;
                SearchArticleNo();

                dtpFromDt.Value = DateTime.Today.AddDays(-30);
                dtpToDt.Value = DateTime.Today;
                BindInventoryGrid();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Inventory : Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
 
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
            lblFromDt.BackColor = Themes.LabelBackColor;
            lblFromDt.ForeColor = Themes.LabelForeColor;

            lblToDt.BackColor = Themes.LabelBackColor;
            lblToDt.ForeColor = Themes.LabelForeColor;

            lblSupplier.BackColor = Themes.LabelBackColor;
            lblSupplier.ForeColor = Themes.LabelForeColor;

            lblNonMoving.BackColor = Themes.LabelBackColor;
            lblNonMoving.ForeColor = Themes.LabelForeColor;

            lblDays.BackColor = Themes.LabelBackColor;
            lblDays.ForeColor = Themes.LabelForeColor;

            lblMaterialSearch.BackColor = Themes.LabelBackColor;
            lblMaterialSearch.ForeColor = Themes.LabelForeColor;

            lblSearchArticeNo.BackColor = Themes.LabelBackColor;
            lblSearchArticeNo.ForeColor = Themes.LabelForeColor;
            Themes.DataGridTheme(dgvInventory);
        }

        #region Bind Data Table
        private void BindSupplier()
        {
            //_objSuppliers = new Suppliers(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _dtSupplier = _objSuppliers.GetSupplier(0, 1);
            if (_dtSupplier != null && _dtSupplier.Rows.Count > 0)
            {
                cmbSupplier.ValueMember = "Id";
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.DataSource = _dtSupplier;
            }
        }

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
                GeneralObjects.ErrLogger.WritetoLogFile("Inventory : SearchSupplier");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void BindMaterial()
        {
            _dtMaterial = _objItemGrp.GetItemGroup(0, 1);
            if (_dtMaterial != null && _dtMaterial.Rows.Count > 0)
            {
                cmbMaterial.ValueMember = "Id";
                cmbMaterial.DisplayMember = "GroupName";
                cmbMaterial.DataSource = _dtMaterial;
                //cmbMaterial.SelectedIndex = 0;
            }
        }
        private void SearchMaterial()
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
       
        private void BindArticleNo()
        {
            _dtArticleNo = _objInventory.GetArticleNo();
            if (_dtArticleNo != null && _dtArticleNo.Rows.Count > 0)
            {
                cmbArticleNo.ValueMember = "Id";
                cmbArticleNo.DisplayMember = "ArticleNo";
                cmbArticleNo.DataSource = _dtArticleNo;
                //cmbMaterial.SelectedIndex = 0;
            }
        }

        private void SearchArticleNo()
        {
            cmbArticleNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbArticleNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collAutoCompleteText = new AutoCompleteStringCollection();

            if (_dtArticleNo != null && _dtArticleNo.Rows.Count > 0)
            {
                foreach (DataRow row in _dtArticleNo.Rows)
                {
                    string articleNo = row["ArticleNo"].ToString();
                    if (!string.IsNullOrWhiteSpace(articleNo) && !collAutoCompleteText.Contains(articleNo))
                    {
                        collAutoCompleteText.Add(articleNo);
                    }
                }
            }

            cmbArticleNo.AutoCompleteCustomSource = collAutoCompleteText;
        }
        private void BindInventoryGrid()
        {
           if (_nonMovingData == false)
           {
               BindSupplierData();             
           }
           else
           {
               BindNonMovingGrid();
           }
        }

        private void BindSupplierData()
        {
            dgvInventory.DataSource = null;
            DataTable objDataTable = _objInventory.GetSupplierWiseInventory(Convert.ToInt32(cmbSupplier.SelectedValue),Convert.ToInt32(cmbMaterial.SelectedValue) , cmbArticleNo.Text ,dtpFromDt.Value, dtpToDt.Value);
            if (objDataTable != null && objDataTable.Rows.Count > 0)
            {
                dgvInventory.DataSource = objDataTable;

                dgvInventory.Columns["SupplierId"].Visible = false;
                dgvInventory.Columns["SupplierName"].HeaderText = "Supplier";
                dgvInventory.Columns["UpdatedBy"].Visible = false;
                dgvInventory.Columns["ItemGroupId"].Visible = false;

                dgvInventory.Columns["GroupName"].HeaderText = "Material";
                dgvInventory.Columns["AvailableStock"].HeaderText = "Available Stock";
                dgvInventory.Columns["HSNCode"].HeaderText = "HSN Code";
                dgvInventory.Columns["SalePrice"].HeaderText = "Sale Price";
                dgvInventory.Columns["GSTRate"].HeaderText = "GST Rate";
                dgvInventory.Columns["ArticleNo"].HeaderText = "Article No.";

                dgvInventory.Columns["Sr. No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["GroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["Size"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["Color"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["AvailableStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["SalePrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["GSTRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["HSNCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["ArticleNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["SupplierName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvInventory.Columns["Classification"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvInventory.Columns["Sr. No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["AvailableStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["GSTRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["HSNCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["ArticleNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvInventory.Columns["Sr. No."].Width = 70;
                dgvInventory.Columns["GroupName"].Width = 150;
                dgvInventory.Columns["Size"].Width = 70;
                dgvInventory.Columns["Color"].Width = 100;
                dgvInventory.Columns["AvailableStock"].Width = 120;
                dgvInventory.Columns["SalePrice"].Width = 100;
                dgvInventory.Columns["GSTRate"].Width = 100;
                dgvInventory.Columns["HSNCode"].Width = 100;
                dgvInventory.Columns["ArticleNo"].Width = 100;
            }
            else
            {
                dgvInventory.DataSource = null;
            }
        }

        private void BindNonMovingGrid()
        {

            DataTable objDataTable = _objInventory.GetNonMovingInventory(Convert.ToInt32(txtNonMovingDays.Text));
            if (objDataTable != null && objDataTable.Rows.Count > 0)
            {
                dgvInventory.DataSource = objDataTable;
                dgvInventory.Columns["UpdatedBy"].Visible = false;

                dgvInventory.Columns["GroupName"].HeaderText = "Material";
                dgvInventory.Columns["AvailableStock"].HeaderText = "Available Stock";
                dgvInventory.Columns["HSNCode"].HeaderText = "HSN Code";
                dgvInventory.Columns["SalePrice"].HeaderText = "Sale Price";
                dgvInventory.Columns["GSTRate"].HeaderText = "GST Rate";
                dgvInventory.Columns["ArticleNo"].HeaderText = "Article No.";


                //dgvInventory.Columns["UpdatedDate"].HeaderText = "Purchase Date";

                dgvInventory.Columns["Sr. No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["GroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["Size"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["Color"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["AvailableStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["SalePrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["GSTRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["HSNCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventory.Columns["ArticleNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //dgvInventory.Columns["SupplierName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvInventory.Columns["Classification"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvInventory.Columns["Sr. No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["AvailableStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["GSTRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["HSNCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventory.Columns["ArticleNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvInventory.Columns["Sr. No."].Width = 70;
                dgvInventory.Columns["GroupName"].Width = 150;
                dgvInventory.Columns["Size"].Width = 70;
                dgvInventory.Columns["Color"].Width = 100;
                dgvInventory.Columns["AvailableStock"].Width = 120;
                dgvInventory.Columns["SalePrice"].Width = 100;
                dgvInventory.Columns["GSTRate"].Width = 100;
                dgvInventory.Columns["HSNCode"].Width = 100;
                dgvInventory.Columns["ArticleNo"].Width = 100;
            }
            else
            {
                dgvInventory.DataSource = null;
            }
        }

        #endregion

        #region Filter   
         private void btnGetData_Click(object sender, EventArgs e)
        {
            //BindSupplierData();
            _nonMovingData = false;
            BindSupplierData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbSupplier.SelectedIndex = -1;
            cmbMaterial.SelectedIndex = -1;
            cmbArticleNo.SelectedIndex = -1;
            dtpFromDt.Value = DateTime.Today.AddDays(-30);
            dtpToDt.Value = DateTime.Today;

            //BindSupplier();

            //BindMaterial();
          
            BindInventoryGrid();
        }
        private void btnNMGetData_Click(object sender, EventArgs e)
        {
            _nonMovingData = true;
            BindInventoryGrid();
        }

        private void btnNMReset_Click(object sender, EventArgs e)
        {
            _nonMovingData = false;
            txtNonMovingDays.Text = "30";
            BindInventoryGrid();
        }
        #endregion

        #region Export To Excel
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataTable objExcelData = new DataTable();
            DataTable objTemp = null;
            ExcelUtility objExcelUtility = null;
            string exportedFlag = "";
            string fileName = "";
            string fileType = "NonMoving_";
            try
            {
                //Adding the Columns.
                foreach (DataGridViewColumn column in dgvInventory.Columns)
                {
                    objExcelData.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows.
                foreach (DataGridViewRow row in dgvInventory.Rows)
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

                    if (objTemp.Columns.Contains("SupplierId"))
                    {
                        objTemp.Columns.Remove(objTemp.Columns["SupplierId"]);
                        fileType = "Inventory_";
                    }
                    if (objTemp.Columns.Contains("ItemGroupId"))
                    {
                        objTemp.Columns.Remove(objTemp.Columns["ItemGroupId"]);
                    }
                    if (objTemp.Columns.Contains("UpdatedBy"))
                    {
                        objTemp.Columns.Remove(objTemp.Columns["UpdatedBy"]);
                    }
                    objExcelData = objTemp;                

                    objExcelUtility = new ExcelUtility(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                    //fileName = "Inventory_" + dtpFromDt.Value.ToString("dd-MM-yyyy")+ "_" + dtpToDt.Value.ToString("dd-MM-yyyy");
                    fileName = fileType + dtpFromDt.Value.ToString("dd-MM-yyyy") + "_" + dtpToDt.Value.ToString("dd-MM-yyyy");
                    exportedFlag = objExcelUtility.ExportToExcel(objExcelData, fileName);
                    if (!string.IsNullOrEmpty(exportedFlag))
                    {
                        MessageBox.Show($"Data exported successfully to:\n{exportedFlag}", "BespokeERP",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error occurred while exporting Excel", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No data available to export", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Inventory : Export to Excel");
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




        #endregion

        //Change Sale Price
        private void dgvInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && GeneralObjects.CurrentRoleId == 1 && _nonMovingData == false) // Delete button
            {
                int _supplierId = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["SupplierId"].Value);
                int _itemGroupId = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["ItemGroupId"].Value);
                decimal salePrice = Convert.ToDecimal(dgvInventory.Rows[e.RowIndex].Cells["SalePrice"].Value);
                string size = dgvInventory.Rows[e.RowIndex].Cells["Size"].Value.ToString();
                string color = dgvInventory.Rows[e.RowIndex].Cells["Color"].Value.ToString();
                string articleNo = dgvInventory.Rows[e.RowIndex].Cells["ArticleNo"].Value.ToString();

                frmInventoryDetails _objfrm = new frmInventoryDetails(_itemGroupId,_supplierId, salePrice,size ,color, articleNo);
                DialogResult result = _objfrm.ShowDialog(this);
                BindInventoryGrid();
            }
        }

        private void frmInventory_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNonMovingDays_KeyPress(object sender, KeyPressEventArgs e)
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
