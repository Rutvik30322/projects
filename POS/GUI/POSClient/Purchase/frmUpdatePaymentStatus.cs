using NDatabaseAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using static NConstant.Constant;

namespace POSClient
{
    public partial class frmUpdatePaymentStaus : Form
    {
        #region "private Variable"
        Purchases _objpurchase = null;
        GeneralDB _objGeneralDB = null;
        private bool isUpdating = false;
        private DataTable _dtPaymentStatus;
        private DataTable _dtSupplier;
        private DataTable _dtPaymentStatusFilter;
        Suppliers _objSuppliers = null;
        #endregion

        #region "Constructor/Destructor"
        public frmUpdatePaymentStaus()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }

        ~frmUpdatePaymentStaus()
        {
            if (_objpurchase != null)
                _objpurchase = null;

            if (_objGeneralDB != null)
                _objGeneralDB = null;


            if (_objSuppliers != null)
                _objSuppliers = null;
        }
        #endregion

        #region "Set Theme"
        private void SetTheme()
        {
            //Header
            btnHeader.BackColor = Themes.HeaderBackColor;
            btnHeader.ForeColor = Themes.HeaderForeColor;
            btnHeader.FlatStyle = FlatStyle.Flat;
            btnHeader.FlatAppearance.BorderSize = 1;
            btnHeader.FlatAppearance.BorderColor = Themes.HeaderBorderColor;

            //Form
            this.BackColor = Themes.FormBackColor;

            lblFromDate.ForeColor = Themes.LabelForeColor;
            lblFromDate.BackColor = Themes.LabelBackColor;

            lblToDate.ForeColor = Themes.LabelForeColor;
            lblToDate.BackColor = Themes.LabelBackColor;

            lblSupplier.ForeColor = Themes.LabelForeColor;
            lblSupplier.BackColor = Themes.LabelBackColor;

            lblPaymentStatus.ForeColor = Themes.LabelForeColor;
            lblPaymentStatus.BackColor = Themes.LabelBackColor;

            lblShortcut.ForeColor = Themes.LabelForeColor;
            lblShortcut.BackColor = Themes.LabelBackColor;

            btnGetData.FlatStyle = FlatStyle.Flat;
            btnGetData.BackColor = Themes.ButtonBackColor;
            btnGetData.ForeColor = Themes.ButtonForeColor;
            btnGetData.FlatAppearance.BorderSize = 1;
            btnGetData.FlatAppearance.BorderColor = Themes.ButtonBorderColor;


            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.BackColor = Themes.ButtonBackColor;
            btnReset.ForeColor = Themes.ButtonForeColor;
            btnReset.FlatAppearance.BorderSize = 1;
            btnReset.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            Themes.DataGridTheme(dgvUpdatePaymentStatus);

        }
        #endregion

        private void RefreshUpdatePaymentStatusGrid(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvUpdatePaymentStatus.Rows[e.RowIndex];
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("UpdatePaymentStatus : RefreshUpdatePaymentStatusGrid");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }

        }

        private void frmUpdatePaymentStaus_Load(object sender, EventArgs e)
        {
            try
            {
                _objpurchase = new Purchases(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objGeneralDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objSuppliers = new Suppliers(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                dgvUpdatePaymentStatus.DataError += dgvUpdatePaymentStatus_DataError;
                dgvUpdatePaymentStatus.RowPrePaint += dgvUpdatePaymentStatus_RowPrePaint;
                dgvUpdatePaymentStatus.KeyDown += dgvUpdatePaymentStatus_KeyDown;
                dtpFromDate.Focus();

                // Set default date range
                dtpFromDate.Value = DateTime.Today.AddDays(-45); // 7 days before today
                dtpToDate.Value = DateTime.Today;               // Today's date


                BindPaymentStatus();
                BindSupplier();
                cmbSupplier.SelectedIndex = -1;
                SearchSupplier();

                BindPaymentStatusFilter();
                cmbPaymentStatus.SelectedIndex = -1;
                SearchPaymentStatus();
                BindPurchaseDataGrid();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Update Payment Status : Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        //Bind DataGridViewComboBox of Payment Status
        private void BindPaymentStatus()
        {
            _dtPaymentStatus = _objGeneralDB.GetListIndexWithMessageText((int)ListId.PaymentStatus);
            //if (_dtPaymentStatus != null && _dtPaymentStatus.Rows.Count > 0)
            //{
            //    //cmbType.DisplayMember = "MessageText";
            //    //cmbType.ValueMember = "ListIndex";
            //    //cmbType.DataSource = _dtUOMType;
            //}
        }

        private void BindPurchaseDataGrid()
        {
            DataTable objDataTable = _objpurchase.GetPurchaseDataForUpdatePaymentStatus(dtpFromDate.Value.ToString("yyyy-MM-dd"), dtpToDate.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(cmbSupplier.SelectedValue), Convert.ToInt32(cmbPaymentStatus.SelectedValue));
            if (objDataTable != null && objDataTable.Rows.Count > 0)
            {
                dgvUpdatePaymentStatus.DataSource = objDataTable;
                dgvUpdatePaymentStatus.Columns["Id"].Visible = false;
                dgvUpdatePaymentStatus.Columns["PaymentStatus"].Visible = false;

                if (dgvUpdatePaymentStatus.Columns.Contains("PaymentStatusName"))
                {
                    dgvUpdatePaymentStatus.Columns.Remove("PaymentStatusName");
                }

                DataGridViewComboBoxColumn cmbColumn = new DataGridViewComboBoxColumn
                {
                    Name = "PaymentStatusName",
                    HeaderText = "Payment Status",
                    DataPropertyName = "PaymentStatusName", // must match data table column name
                    DataSource = _dtPaymentStatus,
                    DisplayMember = "MessageText",
                    ValueMember = "ListIndex",
                    FlatStyle = FlatStyle.Flat,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                };
                dgvUpdatePaymentStatus.Columns.Insert(12, cmbColumn); // adjust index as needed

                dgvUpdatePaymentStatus.ReadOnly = false;
                foreach (DataGridViewColumn column in dgvUpdatePaymentStatus.Columns) //IF Column is 'Payment Status' then user can edit this column
                {
                    if (column.Name != "PaymentStatusName")
                        column.ReadOnly = true;
                }


                //Set Column Header Text
                dgvUpdatePaymentStatus.Columns["PurchaseNo"].HeaderText = "Purchase No.";
                dgvUpdatePaymentStatus.Columns["PurchaseDate"].HeaderText = "Purchase Date";
                dgvUpdatePaymentStatus.Columns["InvoiceNo"].HeaderText = "Invoice No.";
                dgvUpdatePaymentStatus.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                dgvUpdatePaymentStatus.Columns["SupplierName"].HeaderText = "Supplier";
                dgvUpdatePaymentStatus.Columns["GSTNumber"].HeaderText = "GST Number";
                dgvUpdatePaymentStatus.Columns["NetAmount"].HeaderText = "Net Amount";
                dgvUpdatePaymentStatus.Columns["PaymentDueDate"].HeaderText = "Payment Due Date";
                dgvUpdatePaymentStatus.Columns["PaymentStatusName"].HeaderText = "Payment Status";

                //Alignment Set in Data Grid View
                dgvUpdatePaymentStatus.Columns["Sr. No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUpdatePaymentStatus.Columns["PurchaseNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUpdatePaymentStatus.Columns["PurchaseDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUpdatePaymentStatus.Columns["InvoiceNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUpdatePaymentStatus.Columns["InvoiceDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUpdatePaymentStatus.Columns["SupplierName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUpdatePaymentStatus.Columns["City"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUpdatePaymentStatus.Columns["State"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUpdatePaymentStatus.Columns["GSTNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUpdatePaymentStatus.Columns["NetAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUpdatePaymentStatus.Columns["PaymentDueDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUpdatePaymentStatus.Columns["PaymentStatusName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                //Auto Size Column Mode
                dgvUpdatePaymentStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvUpdatePaymentStatus.Columns["Sr. No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["PurchaseNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["PurchaseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["InvoiceNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["InvoiceDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["SupplierName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvUpdatePaymentStatus.Columns["City"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["State"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["GSTNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["NetAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["PaymentDueDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUpdatePaymentStatus.Columns["PaymentStatusName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


                //Width in Date Grid View
                dgvUpdatePaymentStatus.Columns["Sr. No."].Width = 80;
                dgvUpdatePaymentStatus.Columns["PurchaseNo"].Width = 100;
                dgvUpdatePaymentStatus.Columns["PurchaseDate"].Width = 120;
                dgvUpdatePaymentStatus.Columns["InvoiceNo"].Width = 90;
                dgvUpdatePaymentStatus.Columns["InvoiceDate"].Width = 100;
                dgvUpdatePaymentStatus.Columns["City"].Width = 80;
                dgvUpdatePaymentStatus.Columns["State"].Width = 80;
                dgvUpdatePaymentStatus.Columns["GSTNumber"].Width = 110;
                dgvUpdatePaymentStatus.Columns["NetAmount"].Width = 100;
                dgvUpdatePaymentStatus.Columns["PaymentDueDate"].Width = 140;
                dgvUpdatePaymentStatus.Columns["PaymentStatusName"].Width = 120;
            }
            else
            {
                dgvUpdatePaymentStatus.DataSource = null;
            }
        }

        private void dgvUpdatePaymentStatus_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void UpdatePaymentStatus(int id, int paymentStatusId)
        {
            int isSuccess = _objpurchase.UpdatePaymentStatus(id, paymentStatusId, GeneralObjects.CurrentUserId, GeneralObjects.stationName);
            if (isSuccess == 1)
            {
                MessageBox.Show("Payment status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindPurchaseDataGrid();
            }
            else
            {
                MessageBox.Show("Failed to update payment status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUpdatePaymentStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvUpdatePaymentStatus.IsCurrentCellInEditMode)
            {
                dgvUpdatePaymentStatus.EndEdit();
            }
        }

        private void dgvUpdatePaymentStatus_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUpdatePaymentStatus.Columns[e.ColumnIndex].Name == "PaymentStatusName")
            {
                if (isUpdating) return;

                DataGridViewRow row = dgvUpdatePaymentStatus.Rows[e.RowIndex];
                var cellValue = row.Cells["PaymentStatusName"].Value;

                // Check for null or DBNull or invalid value
                if (cellValue == null || cellValue == DBNull.Value || !int.TryParse(cellValue.ToString(), out int newStatusId))
                {
                    return; // Skip processing if no valid selection
                }

                int id = Convert.ToInt32(row.Cells["Id"].Value);

                isUpdating = true;
                UpdatePaymentStatus(id, newStatusId);
                isUpdating = false;
            }
        }

        private void dgvUpdatePaymentStatus_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                var row = dgvUpdatePaymentStatus.Rows[e.RowIndex];
                if (row.Cells["PaymentDueDate"].Value != DBNull.Value)
                {
                    DateTime dueDate = Convert.ToDateTime(row.Cells["PaymentDueDate"].Value);
                    string _status = Convert.ToString(row.Cells["PaymentStatusName"].Value);
                    if (dueDate.Date < DateTime.Today & _status != "Full")
                    {
                        //row.DefaultCellStyle.BackColor = Color.Lavender; // or any other highlight color
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Update Payment Status: dgvUpdatePaymentStatus_RowPrePaint");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);  // Optional: Log or handle the error if date conversion fails
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindPurchaseDataGrid();
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

        private void BindPaymentStatusFilter()
        {
            _dtPaymentStatusFilter = _objGeneralDB.GetListIndexWithMessageText((int)ListId.PaymentStatus);
            if (_dtPaymentStatusFilter != null && _dtPaymentStatusFilter.Rows.Count > 0)
            {
                cmbPaymentStatus.DisplayMember = "MessageText";
                cmbPaymentStatus.ValueMember = "ListIndex";
                cmbPaymentStatus.DataSource = _dtPaymentStatusFilter;
            }
        }

        private void SearchPaymentStatus()
        {
            try
            {
                cmbPaymentStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbPaymentStatus.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collAutoCompleteTextStatus = new AutoCompleteStringCollection();

                if (_dtPaymentStatusFilter != null && _dtPaymentStatusFilter.Rows.Count > 0)
                {
                    for (int i = 0; i < _dtPaymentStatusFilter.Rows.Count; i++)
                    {
                        collAutoCompleteTextStatus.Add(_dtPaymentStatusFilter.Rows[i][1].ToString());
                    }
                }
                cmbPaymentStatus.AutoCompleteCustomSource = collAutoCompleteTextStatus;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Inventory : SearchSupplier");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            BindPurchaseDataGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbPaymentStatus.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            dtpFromDate.Value = DateTime.Today.AddDays(-45); // 7 days before today
            dtpToDate.Value = DateTime.Today;               // Today's date
            BindPurchaseDataGrid();
        }

        private void dgvUpdatePaymentStatus_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var dataGridView = (sender as DataGridView);
            if (e.ColumnIndex == 13)
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Default;
        }

        private void frmUpdatePaymentStaus_KeyDown(object sender, KeyEventArgs e)
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
