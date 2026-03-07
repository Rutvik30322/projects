using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NDatabaseAccess;
using static NConstant.Constant;

namespace POSClient
{
    public partial class frmUOM : Form
    {

        #region "private Variable"
        UOM _objUOM = null;
        GeneralDB _objGeneralDB = null;
        AuditRecords _objAuditRecords = null;

        private DataTable _dtUOMType;
        private int _CellClickUOMId = 0;
        private string _UOM = "";
        private string _auditText = "";
        private string _userName = GeneralObjects.FirstName + " " + GeneralObjects.LastName;
        #endregion

        #region "Constructor/Destructor"
        public frmUOM()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }
        ~frmUOM()
        {
            if (_objUOM != null)
                _objUOM = null;

            if (_objGeneralDB != null)
                _objGeneralDB = null;

            if (_objAuditRecords != null)
                _objAuditRecords = null;

            if (_dtUOMType != null)
                _dtUOMType = null;
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
            lblUnitCode.ForeColor = Themes.LabelForeColor;
            lblUnitCode.BackColor = Themes.LabelBackColor;

            lblType.ForeColor = Themes.LabelForeColor;
            lblType.BackColor = Themes.LabelBackColor;

            lblShortcut.ForeColor = Themes.LabelForeColor;
            lblShortcut.BackColor = Themes.LabelBackColor;

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

            Themes.DataGridTheme(dgvUOM);
        }
        #endregion

        private void BindUOMGrid()
        {
            DataTable objDataTable = _objUOM.GetUOM(0, -1);
            if (objDataTable != null && objDataTable.Rows.Count > 0)
            {
                dgvUOM.DataSource = objDataTable;
                dgvUOM.Columns["Id"].Visible = false;
                dgvUOM.Columns["UOMTypeValue"].Visible = false;
                dgvUOM.Columns["IsActive"].Visible = false;
                dgvUOM.Columns["IsDeleted"].Visible = false;
                dgvUOM.Columns["UpdatedBy"].Visible = false;
                dgvUOM.Columns["UpdatedByName"].Visible = false;
                dgvUOM.Columns["UpdatedDate"].Visible = false;

                //Set Column Header Text
                dgvUOM.Columns["UnitCode"].HeaderText = "Unit Code";
                dgvUOM.Columns["Sr No."].HeaderText = "Sr. No.";
                dgvUOM.Columns["UOMType"].HeaderText = "Unit Type";

                //Alignment Set in Data Grid View
                dgvUOM.Columns["Sr No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUOM.Columns["UnitCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUOM.Columns["UOMType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvUOM.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                //Auto Size Column Mode
                dgvUOM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvUOM.Columns["Sr No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUOM.Columns["UOMType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUOM.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUOM.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUOM.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


                //Width in Date Grid View
                dgvUOM.Columns["Sr No."].Width = 70;
                dgvUOM.Columns["UOMType"].Width = 150;
                dgvUOM.Columns["Status"].Width = 80;
                dgvUOM.Columns["Edit"].Width = 50;
                dgvUOM.Columns["Delete"].Width = 50;
            }
            else
            {
                dgvUOM.DataSource = null;
            }
        }

        private void RefreshUOMGrid(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvUOM.Rows[e.RowIndex];
                //txtUnitCode.Text = "";
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("UOM : RefreshUOMGridData");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }

        }

        private void frmUOM_Load(object sender, EventArgs e)
        {
            try
            {
                _objUOM = new UOM(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objGeneralDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objAuditRecords = new AuditRecords(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

                txtUnitCode.Focus();
                BindUOMGrid();
                BindUOMType();
                cmbType.SelectedIndex = -1;
                SearchUOMType();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("UOM : Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        
        private void GetUOMEditData(int id)
        {
            try
            {
                DataTable objDataTable = _objUOM.GetUOM(id, -1);
                if (objDataTable.Rows.Count > 0 && objDataTable != null)
                {
                    txtUnitCode.Text = Convert.ToString(objDataTable.Rows[0]["UnitCode"]);
                    cmbType.Text = Convert.ToString(objDataTable.Rows[0]["UOMType"]);
                    _CellClickUOMId = id;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("UOM : GetUOMEditData");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_CellClickUOMId == 0)
            {
                if (ValidateDetails())
                {
                    DialogResult result = MessageBox.Show(
                   "Are you sure you want to add this UOM?",
                   "Add UOM",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information
               );

                    if (result == DialogResult.Yes)
                    {
                        SaveUOM(); // Call your Save UOM function here
                    }
                }
            }
            else
            {
                if (ValidateDetails())
                {
                    DialogResult result = MessageBox.Show(
                   "Are you sure you want to edit this UOM?",
                   "Edit UOM",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information
               );

                    if (result == DialogResult.Yes)
                    {
                        txtUnitCode.ReadOnly = false;
                        EditUOM(); // Call your Save UOM function here
                    }
                }

            }

        }

        private void dgvUOM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshUOMGrid(sender, e);
        }

        private void dgvUOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on the column header row
            if (e.RowIndex < 0)
                return;

            txtUnitCode.Text = "";
            cmbType.SelectedIndex = -1;
            // Get the Id from the clicked row
            _CellClickUOMId = Convert.ToInt32(dgvUOM.Rows[e.RowIndex].Cells["Id"].Value);
            _UOM = Convert.ToString(dgvUOM.Rows[e.RowIndex].Cells["UnitCode"].Value);
            int status = Convert.ToInt32(dgvUOM.Rows[e.RowIndex].Cells["IsActive"].Value);

            if (e.ColumnIndex == 11) // Assuming column index 9 is the "Edit" button
            {
                if (status == 0)
                {
                    MessageBox.Show("This record is inactive and can't be edited right now.", "Action not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call edit method
                GetUOMEditData(_CellClickUOMId);
            }

            else if (e.ColumnIndex == 12) // Delete button
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this UOM? This action cannot be undone.",
                    "Delete UOM",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    //_CellClickUOMId = Convert.ToInt32(dgvUOM.Rows[e.RowIndex].Cells["Id"].Value);
                    //_UOM = Convert.ToString(dgvUOM.Rows[e.RowIndex].Cells["UnitCode"].Value);
                    DeleteUOM(); // Call your delete function here
                }
            }
        }

        //Set Hand Cursor of Edit and Delete Cell

        private void dgvUOM_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var dataGridView = (sender as DataGridView);
            if (e.ColumnIndex == 11 || e.ColumnIndex == 12)
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Default;
        }

        //Set Edit and Delete Icon
        private void dgvUOM_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                int status = Convert.ToInt32(dgvUOM.Rows[e.RowIndex].Cells["IsActive"].Value); // Adjust column name if needed

                if (e.ColumnIndex == 11)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.PaintBackground(e.ClipBounds, false);

                    var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                    //e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, w, h));
                    if (status == 0)
                    {
                        e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, 20, 20)); // use a faded/disabled icon
                    }
                    else
                    {
                        e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, 20, 20));
                    }
                    e.Handled = true;
                }

                if (e.ColumnIndex == 12)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.PaintBackground(e.ClipBounds, false);

                    var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                    //e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, w, h));
                    e.Graphics.DrawImage(Properties.Resources.Delete, new Rectangle(x, y, 20, 20));
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("UOM : SetEditandDelete");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        //Set Active and InActive color
        private void dgvUOM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
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

        private bool ValidateDetails()
        {
            bool retFlag = true;
            if (txtUnitCode.Text == "" || string.IsNullOrEmpty(txtUnitCode.Text))
            {
                MessageBox.Show("Please Enter Unit Code", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitCode.Focus();
                txtUnitCode.BackColor = Color.MistyRose;
                return retFlag = false;
            }
            if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Unit Type", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbType.Focus();
                cmbType.BackColor = Color.MistyRose;
                return retFlag = false;
            }
            else
            {
                txtUnitCode.BackColor = SystemColors.Control;
            }
            return retFlag;
        }

        //Save UOM Function
        private void SaveUOM()
        {

            int retValue = _objUOM.SaveUOM(txtUnitCode.Text.Trim(), Convert.ToInt32(cmbType.SelectedIndex), GeneralObjects.CurrentUserId, GeneralObjects.stationName);
            if (retValue == 1)
            {
                MessageBox.Show("UOM added successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindUOMGrid();
                txtUnitCode.Text = "";
                cmbType.SelectedIndex = -1;
                return;
            }
            else if(retValue == -99)
            {
                MessageBox.Show("UOM Already exist", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Failed to add Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }

        //Edit UOM Function
        private void EditUOM()
        {
            int retValue = _objUOM.UpdateUOM(_CellClickUOMId, txtUnitCode.Text.Trim(), Convert.ToInt32(cmbType.SelectedIndex), GeneralObjects.CurrentUserId, GeneralObjects.stationName);
            if (retValue == 1)
            {
                MessageBox.Show("UOM Updated successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindUOMGrid();
                txtUnitCode.Text = "";
                cmbType.SelectedIndex = -1;
                return;
            }
            else if (retValue == -99)
            {
                MessageBox.Show("UOM Already exist", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Failed to update UOM", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUnitCode.Text = "";
            cmbType.SelectedIndex = -1;
            _CellClickUOMId = 0;
            //txtUnitCode.BackColor = SystemColors.Control;
            //cmbType.BackColor = SystemColors.Control;
            txtUnitCode.Focus();
        }

        //Delete UOM
        private void DeleteUOM()
        {
            if (_CellClickUOMId == 0)
            {
                MessageBox.Show("Please select Row to delete Unit Code", "Delete UOM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int retValue = _objGeneralDB.DeleteRecord("UOM", _CellClickUOMId, GeneralObjects.CurrentUserId);
            if (retValue == 0)
            {
                MessageBox.Show("UOM Deleted Successfully", "Delete UOM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _auditText = "UOM : " + _UOM + " deleted.";
                _objAuditRecords.SetAuditRecords(_auditText, _userName, this.Text, Environment.MachineName);
                BindUOMGrid();
                txtUnitCode.Text = "";
                cmbType.SelectedIndex = -1;
                return;
            }
            else
            {
                MessageBox.Show("Failed to Delete UOM", "Delete UOM", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvUOM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) // column index 3 is the "Active / InActive" button
            {
                _CellClickUOMId = Convert.ToInt32(dgvUOM.Rows[e.RowIndex].Cells["Id"].Value);
                string _unicode = dgvUOM.Rows[e.RowIndex].Cells["UnitCode"].Value.ToString();
                int _statusFlag = Convert.ToBoolean(dgvUOM.Rows[e.RowIndex].Cells["IsActive"].Value) ? 1 : 0;
                bool _statusValue = Convert.ToBoolean(dgvUOM.Rows[e.RowIndex].Cells["IsActive"].Value);

                try
                {
                    DialogResult result;
                    if (_statusValue) // Currently Active
                    {
                        result = MessageBox.Show($"Are you sure you want to InActive {_unicode}?", "Change Status",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 0;
                            bool retFlag = _objGeneralDB.SetActiveInActiveStatus("UOM", _CellClickUOMId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "UOM : " + _unicode + " Inactive successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _userName, this.Text, Environment.MachineName);
                            }
                        }
                    }
                    else // Currently Inactive
                    {
                        result = MessageBox.Show($"Are you sure you want to Active {_unicode}?", "Change Status",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 1;
                            bool retFlag = _objGeneralDB.SetActiveInActiveStatus("UOM", _CellClickUOMId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "UOM : " + _unicode + " Active successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _userName, this.Text, Environment.MachineName);
                            }
                        }
                    }

                    // Refresh the grid regardless of user choice
                    BindUOMGrid();
                }
                catch (Exception ex)
                {
                    GeneralObjects.ErrLogger.WritetoLogFile("UOM : SetActiveInactive");
                    GeneralObjects.ErrLogger.WritetoLogFile(ex);
                }
            }
        }

        //Bind DataGridViewComboBox of UOM Type
        private void BindUOMType()
        {
            _dtUOMType = _objGeneralDB.GetListIndexWithMessageText((int)ListId.UOMType);
            if (_dtUOMType != null && _dtUOMType.Rows.Count > 0)
            {
                cmbType.DisplayMember = "MessageText";
                cmbType.ValueMember = "ListIndex";
                cmbType.DataSource = _dtUOMType;
            }
        }

        private void SearchUOMType()
        {
            try
            {
                cmbType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbType.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collAutoCompleteText = new AutoCompleteStringCollection();

                if (_dtUOMType != null && _dtUOMType.Rows.Count > 0)
                {
                    for (int i = 0; i < _dtUOMType.Rows.Count; i++)
                    {
                        collAutoCompleteText.Add(_dtUOMType.Rows[i][1].ToString());
                    }
                }
                cmbType.AutoCompleteCustomSource = collAutoCompleteText;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("UOM : SearchUOMType");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void dgvUOM_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.E))
            {
                if (dgvUOM.CurrentCell != null) // && dgvMaterial.Columns[dgvMaterial.CurrentCell.ColumnIndex].Name == "Edit"
                {
                    dgvUOM.ReadOnly = false;
                    dgvUOM.BeginEdit(true);
                    e.SuppressKeyPress = true; // Stop further processing of the key

                    if (dgvUOM.CurrentCell != null)
                    {
                        int rowIndex = dgvUOM.CurrentCell.RowIndex;
                        int _uomId = Convert.ToInt32(dgvUOM.Rows[rowIndex].Cells["Id"].Value);
                        int status = Convert.ToInt32(dgvUOM.Rows[rowIndex].Cells["IsActive"].Value);
                        if (status == 0)
                        {
                            MessageBox.Show("This record is inactive and can't be edited right now.", "Action not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        GetUOMEditData(_uomId);
                        txtUnitCode.Focus();
                    }
                }
            }
        }

        private void frmUOM_KeyDown(object sender, KeyEventArgs e)
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
