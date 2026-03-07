using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDatabaseAccess;
using POSClient.Properties;

namespace POSClient
{
    public partial class frmInventoryDetails : Form
    {
        #region Variables
        private CheckBox headerCheckBox;
        #endregion

        #region Constructor
        Inventory _objInventory = null;
        Sale _objSales = null;
        RawPrinterHelper _objrawPrinterHelper;
        ComputerLists _objComputerLists = null;

        private int _itemgrpId = 0;
        private int _supplierId = 0;
        private decimal _salePrice = 0;
        private string _size = null;
        private string _color = null;
        private string _articleNo = null;

        private int _inventoryId = 0;
        private string _barcodeValue = null;

        private int selectedCount = 0;

        private decimal _oldSalePrice = 0;

        ~frmInventoryDetails()
        {
            if (_objInventory != null)
                _objInventory = null;

            if (_objSales != null)
                _objSales = null;

            if (_objComputerLists != null)
                _objComputerLists = null;

            if (_objrawPrinterHelper != null)
                _objrawPrinterHelper = null;
        }
        #endregion
        public frmInventoryDetails(int itemGroupId, int supplierId, decimal salePrice, string size, string color, string articleNo)
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
            _itemgrpId = itemGroupId;
            _supplierId = supplierId;
            _salePrice = salePrice;
            _size = size;
            _color = color;
            _articleNo = articleNo;
        }

        private void frmInventoryDetails_Load(object sender, EventArgs e)
        {
            _objInventory = new Inventory(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objSales = new Sale(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objComputerLists = new ComputerLists(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objrawPrinterHelper = new RawPrinterHelper();

            btnTotalSelectedCount.Text = "Selected Row Count : " + selectedCount;
            BindInventoryData();
            SetTheme();
        }
        private void SetTheme()
        {
            this.BackColor = Themes.FormBackColor;

            //Header
            btnHeader.BackColor = Themes.HeaderBackColor;
            btnHeader.ForeColor = Themes.HeaderForeColor;
            btnHeader.FlatStyle = FlatStyle.Flat;
            btnHeader.FlatAppearance.BorderSize = 1;
            btnHeader.FlatAppearance.BorderColor = Themes.HeaderBorderColor;

            Themes.DataGridTheme(dgvInventoryDetail);
        }

        private void BindInventoryData()
        {
            DataTable _objDT = _objInventory.GetInventoryStock(_itemgrpId, _supplierId, _salePrice, _size, _color, _articleNo);
            if (_objDT != null || _objDT.Rows.Count > 0)
            {
                dgvInventoryDetail.DataSource = _objDT;
                if (!_objDT.Columns.Contains("Select"))
                {
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.Name = "Select";
                    chk.HeaderText = "";  // Set empty header text to hide the column header
                    chk.Width = 30;
                    chk.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                    dgvInventoryDetail.Columns.Insert(0, chk);  // Insert as first column                    
                }

                dgvInventoryDetail.ReadOnly = false;
                foreach (DataGridViewColumn column in dgvInventoryDetail.Columns)
                {
                    if (column.Name != "SalePrice" && column.Name != "Select")
                        column.ReadOnly = true;
                }

                dgvInventoryDetail.Columns["InventoryId"].Visible = false;
                dgvInventoryDetail.Columns["SupplierId"].Visible = false;
                dgvInventoryDetail.Columns["UpdatedBy"].Visible = false;
                dgvInventoryDetail.Columns["UpdatedDate"].Visible = false;

                dgvInventoryDetail.Columns["GroupName"].HeaderText = "Material";
                //dgvInventoryDetail.Columns["Quantity"].HeaderText = "Available Stock";
                dgvInventoryDetail.Columns["GSTRate"].HeaderText = "GST Rate";
                dgvInventoryDetail.Columns["HSNCode"].HeaderText = "HSN Code";
                dgvInventoryDetail.Columns["SalePrice"].HeaderText = "Sale Price";

                dgvInventoryDetail.Columns["Sr. No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventoryDetail.Columns["Size"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventoryDetail.Columns["Color"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventoryDetail.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventoryDetail.Columns["SalePrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventoryDetail.Columns["GSTRate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventoryDetail.Columns["HSNCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //dgvInventoryDetail.Columns["Classification"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvInventoryDetail.Columns["Sr. No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventoryDetail.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventoryDetail.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventoryDetail.Columns["GSTRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInventoryDetail.Columns["HSNCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvInventoryDetail.Columns["Sr. No."].Width = 70;
                dgvInventoryDetail.Columns["Size"].Width = 50;
                dgvInventoryDetail.Columns["Color"].Width = 80;
                dgvInventoryDetail.Columns["Quantity"].Width = 100;
                dgvInventoryDetail.Columns["SalePrice"].Width = 80;
                dgvInventoryDetail.Columns["GSTRate"].Width = 80;
                dgvInventoryDetail.Columns["HSNCode"].Width = 90;

                AddHeaderCheckBox();
            }

            else
            {
                dgvInventoryDetail.DataSource = null;
            }
        }
        #region Checkbox functionality
        private void AddHeaderCheckBox()
        {
            // Create a CheckBox for the header
            //CheckBox headerCheckBox = new CheckBox();
            headerCheckBox = new CheckBox();
            headerCheckBox.Size = new Size(15, 15);
            Point headerCellLocation = dgvInventoryDetail.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 5);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            // Add the CheckBox to the DataGridView control (at the appropriate header location)
            dgvInventoryDetail.Controls.Add(headerCheckBox);
        }
        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dgvInventoryDetail.CellValueChanged -= dgvInventoryDetail_CellValueChanged; // Unsubscribe temporarily
            dgvInventoryDetail.EndEdit(); // Force end edit

            CheckBox headerBox = (CheckBox)sender;
            bool isChecked = headerBox.Checked;

            foreach (DataGridViewRow row in dgvInventoryDetail.Rows)
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
            selectedCount = isChecked ? dgvInventoryDetail.Rows.Count : 0;
            btnTotalSelectedCount.Text = "Selected Row Count : " + selectedCount;

            dgvInventoryDetail.CellValueChanged += dgvInventoryDetail_CellValueChanged; // Resubscribe
        }

        private void dgvInventoryDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvInventoryDetail.Columns[e.ColumnIndex].Name == "Select")
            {
                dgvInventoryDetail.EndEdit(); // Ensure value updated

                DataGridViewRow row = dgvInventoryDetail.Rows[e.RowIndex];
                bool isSelected = Convert.ToBoolean(dgvInventoryDetail.Rows[e.RowIndex].Cells["Select"].Value);

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

                btnTotalSelectedCount.Text = "Selected Row Count : " + selectedCount;
            }
        }

        private List<int> GetSelectedIds()
        {
            List<int> selectedIds = new List<int>();

            foreach (DataGridViewRow row in dgvInventoryDetail.Rows)
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

        #endregion

        #region Edit Sale Price
        private void dgvInventoryDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11 && dgvInventoryDetail.Columns[e.ColumnIndex].Name == "SalePrice" && GeneralObjects.CurrentRoleId == 1)
            {
                //GetSelectedRowData(sender, e);
                dgvInventoryDetail.BeginEdit(true);
            }
            else
            {

            }
        }

        private void dgvInventoryDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvInventoryDetail.CurrentCell.ColumnIndex == dgvInventoryDetail.Columns["SalePrice"].Index)
            {
                dgvInventoryDetail.EndEdit();
                e.Handled = true;
            }
            else if ((e.Control && e.KeyCode == Keys.E))
            {
                if (dgvInventoryDetail.CurrentCell != null && dgvInventoryDetail.CurrentCell.ColumnIndex == dgvInventoryDetail.Columns["SalePrice"].Index) // && dgvMaterial.Columns[dgvMaterial.CurrentCell.ColumnIndex].Name == "Edit"
                {
                    dgvInventoryDetail.ReadOnly = false;
                    dgvInventoryDetail.BeginEdit(true);
                    e.SuppressKeyPress = true; // Stop further processing of the key

                    if (dgvInventoryDetail.CurrentCell != null)
                    {
                        {
                            dgvInventoryDetail.BeginEdit(true); // Enters edit mode for the SalePrice cell
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void dgvInventoryDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventoryDetail.Columns[e.ColumnIndex].Name == "SalePrice")
            {
                string newValueStr = Convert.ToString(dgvInventoryDetail.Rows[e.RowIndex].Cells["SalePrice"].Value);

                if (string.IsNullOrWhiteSpace(newValueStr))
                {
                    MessageBox.Show("Sale Price should not be empty", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double newPrice = Convert.ToDouble(newValueStr);

                if (newPrice == 0)
                {
                    MessageBox.Show("Sale Price should not be zero", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (Convert.ToDouble(_salePrice) != newPrice)
                if (Convert.ToDouble(_oldSalePrice) != newPrice)
                {
                    DialogResult result = MessageBox.Show(
                          "Are you sure you want to update Sale Price for all items in this group?",
                         "BespokeERP", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)  //Update Sales Price for all items
                    {
                        int updateCount = 0;

                        foreach (DataGridViewRow row in dgvInventoryDetail.Rows)
                        {
                            int inventoryId = Convert.ToInt32(row.Cells["InventoryId"].Value);
                            int retValue = _objInventory.UpdateSalePrice(inventoryId, newPrice, GeneralObjects.CurrentUserId, GeneralObjects.stationName);

                            if (retValue == 1)
                            {
                                row.Cells["SalePrice"].Value = newPrice; // reflect new value
                                updateCount++;
                            }
                        }
                        if (updateCount > 0)
                        {
                            DialogResult result1 = MessageBox.Show($"Sale Price updated successfully for {updateCount} items. Please reprint barcode", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information
                            );
                        }
                    }
                    else  // Update sales price for only single item
                    {
                        var inventoryId = Convert.ToInt32(dgvInventoryDetail.Rows[e.RowIndex].Cells["InventoryId"].Value);
                        int retValue = _objInventory.UpdateSalePrice(inventoryId, newPrice, GeneralObjects.CurrentUserId, GeneralObjects.stationName);

                        if (retValue == 1)
                        {
                            DialogResult result2 = MessageBox.Show("Sale Price updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information
                            );
                        }
                        //{
                        //    DialogResult result2 = MessageBox.Show("Sale Price updated successfully." +
                        //           $"Do you want to reprint the barcode?", "Success",
                        //           MessageBoxButtons.YesNo, MessageBoxIcon.Information
                        //    );
                        //    if (result2 == DialogResult.Yes)
                        //    {
                        //        _objrawPrinterHelper = new RawPrinterHelper();

                        //        int invId1 = Convert.ToInt32(dgvInventoryDetail.Rows[0].Cells["InventoryId"].Value);
                        //        string barcode1 = Convert.ToString(dgvInventoryDetail.Rows[0].Cells["Barcode"].Value);
                        //        string productName1 = Convert.ToString(dgvInventoryDetail.Rows[0].Cells["GroupName"].Value);
                        //        string articleNo1 = Convert.ToString(dgvInventoryDetail.Rows[0].Cells["ArticleNo"].Value);
                        //        string size1 = Convert.ToString(dgvInventoryDetail.Rows[0].Cells["Size"].Value);
                        //        string mrp1 = Convert.ToString(dgvInventoryDetail.Rows[0].Cells["SalePrice"].Value);

                        //        string barcodePrinter = _objComputerLists.GetBarcodePrinter(Environment.MachineName);
                        //        _objrawPrinterHelper.PrintLabel(barcodePrinter, barcode1, productName1, articleNo1, size1, mrp1, null, null, null, null, null);
                        //        //_objrawPrinterHelper.PrintLabel("barcodePrinter", barcode1, productName1, articleNo1, size1, mrp1, null, null, null, null, null);

                        //    }
                        //}
                        else
                        {
                            MessageBox.Show("Failed to update Sale Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
            }
        }
        #endregion

        #region Print Barcode
        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = GetSelectedIds(); // Get selected InventoryIds

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Please select at least one item to print.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PrintBarcode();

            // After successful printing, uncheck all selected checkboxes
            foreach (DataGridViewRow row in dgvInventoryDetail.Rows)
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
            headerCheckBox.Checked = false;
        }

        private void PrintBarcode()
        {
            try
            {
                var selectedRows = new List<(string barcodevalue, string productname, string size, string articleno, string mrp)>();

                foreach (DataGridViewRow row in dgvInventoryDetail.Rows)
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
                    _objrawPrinterHelper.PrintLabel(barcodePrinter, barCodeValue1, productName1, size1, articleNo1, mrp1, barCodeValue2, productName2, size2, articleNo2, mrp2);
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Inventory Details : Print Barcode");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
        #endregion

        private void dgvInventoryDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInventoryDetail.IsCurrentCellDirty)
            {
                dgvInventoryDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void frmInventoryDetails_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvInventoryDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvInventoryDetail.Columns[e.ColumnIndex].Name == "SalePrice")
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal salesprice))
                {
                    dgvInventoryDetail.CancelEdit();
                    dgvInventoryDetail.CurrentCell.Value = Convert.ToString(_salePrice);  // Revert back to old value
                    MessageBox.Show("Please enter a valid decimal number for Qty.");
                    //e.Cancel = true;
                    //dgvSalesItem.Rows[e.RowIndex].Cells["Qty"].Value = Convert.ToString(_oldQty);
                }
            }
        }

        private void dgvInventoryDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvInventoryDetail.CurrentCell.ColumnIndex == dgvInventoryDetail.Columns["SalePrice"].Index)
            {
                TextBox txtSPEdit = e.Control as TextBox;
                if (txtSPEdit != null)
                {
                    txtSPEdit.KeyPress -= new KeyPressEventHandler(SPCell_KeyPress);
                    txtSPEdit.KeyPress += new KeyPressEventHandler(SPCell_KeyPress);

                    txtSPEdit.MaxLength = 8;
                }
            }
        }

        private void SPCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvInventoryDetail.ReadOnly && dgvInventoryDetail.CurrentCell.ColumnIndex == dgvInventoryDetail.Columns["SalePrice"].Index)
            {
                dgvInventoryDetail.ReadOnly = false;
                dgvInventoryDetail.BeginEdit(true);
            }
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

        private void dgvInventoryDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvInventoryDetail.Columns[e.ColumnIndex].Name == "SalePrice")
            {
                _oldSalePrice = Convert.ToDecimal(dgvInventoryDetail.Rows[e.RowIndex].Cells["SalePrice"].Value);
            }
        }
    }
}
