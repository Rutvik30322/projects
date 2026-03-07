using NDatabaseAccess;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace POSClient
{
    public partial class frmSettings : Form
    {
        #region "private Variable"
        SystemSettings _objSystemSettings = null;
        GeneralDB _objGeneralDB = null;
        AuditRecords _objAuditRecords = null;

        public int _RowsSelectedId = 0;

        public string _invoicePrinter = "";
        public string _barcodePrinter = "";

        private string _system = "";
        private string _auditText = "";
        private string _userName = GeneralObjects.FirstName + " " + GeneralObjects.LastName;

        #endregion

        #region "Constructor/Destructor"     
        public frmSettings()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }

        ~frmSettings()
        {
            if (_objSystemSettings != null)
                _objSystemSettings = null;
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

            //label
            lblStationName.ForeColor = Themes.LabelForeColor;
            lblStationName.BackColor = Themes.LabelBackColor;

            lblInvoicePrinter.ForeColor = Themes.LabelForeColor;
            lblInvoicePrinter.BackColor = Themes.LabelBackColor;

            lblBarcodePrinter.ForeColor = Themes.LabelForeColor;
            lblBarcodePrinter.BackColor = Themes.LabelBackColor;

            lblShortcut.ForeColor = Themes.LabelForeColor;
            lblShortcut.BackColor = Themes.LabelBackColor;

            Themes.DataGridTheme(dgvSettings);
        }
        #endregion

        private void frmSettings_Load(object sender, EventArgs e)
        {
            try
            {
                txtStation.Focus();
                _objSystemSettings = new SystemSettings(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objAuditRecords = new AuditRecords(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

                FillPrinterList();
                BindSettingsGrid(0);
                cmbInvoicePrinter.Enabled = false;
                cmbBarcodePrinter.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Settings : Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void BindSettingsGrid(int computerId)
        {
            DataTable objDataTable = _objSystemSettings.GetComputerList(computerId);
            if (objDataTable != null && objDataTable.Rows.Count > 0)
            {
                dgvSettings.DataSource = objDataTable;
                dgvSettings.Columns["Id"].Visible = false;
                dgvSettings.Columns["ComputerCode"].Visible = false;
                dgvSettings.Columns["Status"].Visible = false;

                txtStation.Text = Convert.ToString(objDataTable.Rows[0]["ComputerName"]);
                cmbInvoicePrinter.Text = Convert.ToString(objDataTable.Rows[0]["InvoicePriner"]);
                cmbBarcodePrinter.Text = Convert.ToString(objDataTable.Rows[0]["BarcodePriner"]);

                //Set Column Header Text
                dgvSettings.Columns["ComputerName"].HeaderText = "Stations";
                dgvSettings.Columns["InvoicePriner"].HeaderText = "Invoice Printer";
                dgvSettings.Columns["BarcodePriner"].HeaderText = "Barcode Printer";
                dgvSettings.Columns["StatusName"].HeaderText = "Status";
                dgvSettings.Columns["Sr No."].HeaderText = "Sr. No.";

                dgvSettings.Columns["Sr No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSettings.Columns["StatusName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSettings.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvSettings.Columns["Sr No."].Width = 70;
                dgvSettings.Columns["StatusName"].Width = 50;
                dgvSettings.Columns["Edit"].Width = 50;

                //dgvSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvSettings.Columns["Sr No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSettings.Columns["ComputerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvSettings.Columns["InvoicePriner"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvSettings.Columns["BarcodePriner"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void FillPrinterList()
        {
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbInvoicePrinter.Items.Add(strPrinter);
                cmbBarcodePrinter.Items.Add(strPrinter);
                if (strPrinter == strDefaultPrinter)
                {
                    cmbInvoicePrinter.SelectedIndex = cmbInvoicePrinter.Items.IndexOf(strPrinter);
                    cmbBarcodePrinter.SelectedIndex = cmbInvoicePrinter.Items.IndexOf(strPrinter);
                }
            }
        }

        private void dgvSettings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on the column header row
            if (e.RowIndex < 0)
                return;

            _RowsSelectedId = Convert.ToInt32(dgvSettings.Rows[e.RowIndex].Cells["Id"].Value);
            DataTable objDataTable = _objSystemSettings.GetComputerList(_RowsSelectedId);

            if (objDataTable != null && objDataTable.Rows.Count > 0)
            {
                txtStation.Text = Convert.ToString(objDataTable.Rows[0]["ComputerName"]);
                cmbInvoicePrinter.Text = Convert.ToString(objDataTable.Rows[0]["InvoicePriner"]);
                cmbBarcodePrinter.Text = Convert.ToString(objDataTable.Rows[0]["BarcodePriner"]);

                _invoicePrinter = Convert.ToString(objDataTable.Rows[0]["InvoicePriner"]);
                _barcodePrinter = Convert.ToString(objDataTable.Rows[0]["BarcodePriner"]);
            }
            else
            {
                txtStation.Text = string.Empty;
                cmbInvoicePrinter.Text = string.Empty;
                cmbBarcodePrinter.Text = string.Empty;
            }

            if (e.ColumnIndex == 8)
            {
                cmbInvoicePrinter.Enabled = true;
                cmbBarcodePrinter.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void dgvSettings_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0)
            //{
            //    return;
            //}
            //var dataGridView = (sender as DataGridView);
            //if (e.ColumnIndex == 7)
            //    dataGridView.Cursor = Cursors.Hand;
            //else
            //    dataGridView.Cursor = Cursors.Default;
        }

        private void dgvSettings_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                if (e.ColumnIndex == 8)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.PaintBackground(e.ClipBounds, false);

                    var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                    //e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, w, h));
                    e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, 20, 20));
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("UOM : SetEditandDelete");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void UpdateComputerList()
        {
            int retValue = _objSystemSettings.UpdateComputerList(_RowsSelectedId, cmbInvoicePrinter.Text, cmbBarcodePrinter.Text, GeneralObjects.stationName, GeneralObjects.CurrentUserId);
            if (retValue == 1)
            {
                MessageBox.Show("Data Updated successfully.", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindSettingsGrid(0);
                cmbInvoicePrinter.Enabled = false;
                cmbBarcodePrinter.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("Failed to update data", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

        //Set Active and InActive color
        private void dgvSettings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.Value != null)
            {
                if (Convert.ToString(e.Value) == "Active")
                {
                    e.CellStyle.BackColor = Color.FromArgb(198, 239, 206);
                }
                else if (Convert.ToString(e.Value) == "Inactive")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 199, 206);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                   "Are you sure you want to edit this Station?",
                   "BespokeERP",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information
               );
            if (result == DialogResult.Yes)
            {
                UpdateComputerList(); // Call your Save UOM function here
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cmbInvoicePrinter.Enabled = false;
            cmbBarcodePrinter.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            cmbInvoicePrinter.Text = _invoicePrinter;
            cmbBarcodePrinter.Text = _barcodePrinter;
        }

        private void dgvSettings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7) // column index 3 is the "Active / InActive" button
            {
                _RowsSelectedId = Convert.ToInt32(dgvSettings.Rows[e.RowIndex].Cells["Id"].Value);
                _system = dgvSettings.Rows[e.RowIndex].Cells["ComputerName"].Value.ToString();
                int _statusFlag = Convert.ToBoolean(dgvSettings.Rows[e.RowIndex].Cells["Status"].Value) ? 1 : 0;
                bool _statusValue = Convert.ToBoolean(dgvSettings.Rows[e.RowIndex].Cells["Status"].Value);

                try
                {
                    DialogResult result;

                    if (_statusValue) // Currently Active
                    {
                        result = MessageBox.Show($"Are you sure you want to InActive {_system}?", "Change Status",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 0;
                            bool retFlag = _objSystemSettings.SetActiveInActiveComputerList("ComputerLists", _RowsSelectedId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "System : " + _system + " Inactive successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _userName, this.Text, Environment.MachineName);
                            }
                        }
                    }
                    else // Currently Inactive
                    {
                        result = MessageBox.Show($"Are you sure you want to Active {_system}?", "Change Status",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 1;
                            bool retFlag = _objSystemSettings.SetActiveInActiveComputerList("ComputerLists", _RowsSelectedId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "System : " + _system + " Inactive successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _userName, this.Text, Environment.MachineName);
                            }
                        }
                    }

                    // Refresh the grid regardless of user choice
                    BindSettingsGrid(0);
                }
                catch (Exception ex)
                {
                    GeneralObjects.ErrLogger.WritetoLogFile("Settings : SetActiveInactive");
                    GeneralObjects.ErrLogger.WritetoLogFile(ex);
                }
            }
        }

        private void frmSettings_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.E))
            {
                if (dgvSettings.CurrentCell != null) // && dgvMaterial.Columns[dgvMaterial.CurrentCell.ColumnIndex].Name == "Edit"
                {
                    dgvSettings.ReadOnly = false;
                    dgvSettings.BeginEdit(true);
                    e.SuppressKeyPress = true; // Stop further processing of the key

                    if (dgvSettings.CurrentCell != null)
                    {
                        int rowIndex = dgvSettings.CurrentCell.RowIndex;
                        int _itemId = Convert.ToInt32(dgvSettings.Rows[rowIndex].Cells["Id"].Value);

                        cmbInvoicePrinter.Enabled = true;
                        cmbBarcodePrinter.Enabled = true;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                    }
                }
            }
        }
    }
}
