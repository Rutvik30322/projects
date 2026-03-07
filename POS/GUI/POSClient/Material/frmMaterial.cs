using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NDatabaseAccess;

namespace POSClient
{
    public partial class frmMaterial : Form
    {

        #region "Private Varaibles"
        ItemsGroup _objItemGroup = null;
        GeneralDB _generalDB;
        GeneralSettings _objGeneralSettings = null;
        AuditRecords _objAuditRecords = null;

        private int _itemGroupId = 0;
        private string _group = "";
        private string _userName = GeneralObjects.FirstName + " " + GeneralObjects.LastName;
        private string _auditText = "";
        #endregion

        #region "Constructor/Destructor"
        public frmMaterial()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }

        ~frmMaterial()
        {
            if (_objItemGroup != null)
                _objItemGroup = null;

            if (_group != null)
                _group = null;

            if (_userName != null)
                _userName = null;

            if (_generalDB != null)
                _generalDB = null;

            if (_objGeneralSettings != null)
                _objGeneralSettings = null;

            if (_itemGroupId != 0)
                _itemGroupId = 0;

            if (_objAuditRecords != null)
                _objAuditRecords = null;

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
            lblGroupCode.ForeColor = Themes.LabelForeColor;
            lblGroupCode.BackColor = Themes.LabelBackColor;

            lblGroupName.ForeColor = Themes.LabelForeColor;
            lblGroupName.BackColor = Themes.LabelBackColor;

            lblShortcut.ForeColor = Themes.LabelForeColor;
            lblShortcut.BackColor = Themes.LabelBackColor;

            lblMinLevel.ForeColor = Themes.LabelForeColor;
            lblMinLevel.BackColor = Themes.LabelBackColor;

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

            //DataGrid
            Themes.DataGridTheme(dgvMaterial);
        }
        #endregion

        private void frmMaterial_Load(object sender, EventArgs e)
        {
            //txtGrpCode.Focus();
            try
            {
                _objItemGroup = new ItemsGroup(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objGeneralSettings = new GeneralSettings(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objAuditRecords = new AuditRecords(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                BindMaterial();
                txtGrpCode.Focus();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Material : Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void BindMaterial()
        {
            DataTable _objDataTable = _objItemGroup.GetItemGroup(0, -1);
            //_objItemGroup = new ItemsGroup(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            if (_objDataTable != null && _objDataTable.Rows.Count > 0)
            {
                dgvMaterial.DataSource = _objDataTable;

                dgvMaterial.DataSource = _objDataTable;
                dgvMaterial.Columns["UpdatedBy"].Visible = false;
                dgvMaterial.Columns["UpdatedByName"].Visible = false;
                dgvMaterial.Columns["UpdatedDate"].Visible = false;
                dgvMaterial.Columns["IsDeleted"].Visible = false;
                dgvMaterial.Columns["IsActive"].Visible = false;
                dgvMaterial.Columns["Id"].Visible = false;

                dgvMaterial.Columns["GroupCode"].HeaderText = "Group Code";
                dgvMaterial.Columns["GroupName"].HeaderText = "Group Name";
                dgvMaterial.Columns["MinLevel"].HeaderText = "Min Level";

                dgvMaterial.Columns["Sr. No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvMaterial.Columns["GroupCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvMaterial.Columns["GroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMaterial.Columns["MinLevel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvMaterial.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvMaterial.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvMaterial.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvMaterial.Columns["Sr. No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvMaterial.Columns["Sr. No."].Width = 70;
                dgvMaterial.Columns["GroupCode"].Width = 150;
                dgvMaterial.Columns["MinLevel"].Width = 100;
                dgvMaterial.Columns["Status"].Width = 80;
                dgvMaterial.Columns["Edit"].Width = 50;
                dgvMaterial.Columns["Delete"].Width = 50;
            }
            else
            {
                dgvMaterial.DataSource = null;
            }
        }

        private void RefreshMaterialGrid(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvMaterial.Rows[e.RowIndex];
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Material : RefreshMaterialGridData");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDetails())
            {

                if (_itemGroupId == 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to Add Data " + "?", "Confirmation",
                                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SaveMaterial();
                    }
                    else
                    {
                        Clear();
                    }
                }
                else
                {
                    txtGrpCode.Enabled = false;
                    DialogResult result = MessageBox.Show("Are you sure you want to Edit Data " + "?", "Confirmation",
                                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EditMaterial();
                    }
                    else
                    {
                        Clear();
                    }
                }
            }
        }

        private void GetMaterialEditData(int id)
        {
            try
            {
                DataTable objDataTable = _objItemGroup.GetItemGroup(id, -1);
                if (objDataTable.Rows.Count > 0 && objDataTable != null)
                {
                    txtGrpCode.Text = Convert.ToString(objDataTable.Rows[0]["GroupCode"]);
                    txtGrpName.Text = Convert.ToString(objDataTable.Rows[0]["GroupName"]);
                    txtMinLevel.Text = Convert.ToString(objDataTable.Rows[0]["MinLevel"]);
                    _itemGroupId = id;
                    txtGrpName.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Material : GetMaterialEditData");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void SaveMaterial()
        {
            if (txtGrpCode.Text == "" || string.IsNullOrEmpty(txtGrpCode.Text) || txtGrpName.Text == "" || string.IsNullOrEmpty(txtGrpName.Text))
            {
                MessageBox.Show("Fill Mandatory Fields!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int retValue = _objItemGroup.SaveItemsGroup(txtGrpCode.Text.Trim(), txtGrpName.Text.Trim(), Convert.ToDecimal(txtMinLevel.Text.Trim()), GeneralObjects.CurrentUserId, GeneralObjects.stationName);
            if (retValue == 1)
            {
                MessageBox.Show("Data Added Successfully", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindMaterial();
                txtGrpCode.Text = "";
                txtGrpName.Text = "";
                txtMinLevel.Text = "0.00";
                return;
            }
            else if (retValue == -99)
            {
                MessageBox.Show("Group Code already Exists", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtGrpCode.Text = "";
                //txtGrpName.Text = "";
                txtGrpCode.BackColor = Color.MistyRose;
                txtGrpCode.Focus();
                return;
            }
            else if (retValue == -98)
            {
                MessageBox.Show("Group Name already Exists", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtGrpCode.Text = "";
                //txtGrpName.Text = "";
                txtGrpName.BackColor = Color.MistyRose;
                txtGrpName.Focus();
                return;
            }
            else
            {
                MessageBox.Show("Failed to Save Material Data", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void EditMaterial()
        {
            if (txtGrpCode.Text == "" || string.IsNullOrEmpty(txtGrpCode.Text) || txtGrpName.Text == "" || string.IsNullOrEmpty(txtGrpName.Text))
            {
                MessageBox.Show("Fill Mandatory Fields!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_itemGroupId == 0)
            {
                MessageBox.Show("Please select Row to edit ", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int retValue = _objItemGroup.UpdateItemsGroup(_itemGroupId, txtGrpCode.Text.Trim(), txtGrpName.Text.Trim(), Convert.ToDecimal(txtMinLevel.Text.Trim()), GeneralObjects.CurrentUserId, GeneralObjects.stationName);
            if (retValue == 1)
            {
                MessageBox.Show("Material Updated Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindMaterial();
                txtGrpCode.Text = "";
                txtGrpName.Text = "";
                txtMinLevel.Text = "0.00";
                _itemGroupId = 0;
                return;
            }
            else if (retValue == -99)
            {
                MessageBox.Show("Group Code already Exists", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtGrpCode.Text = "";
                //txtGrpName.Text = "";
                txtGrpCode.BackColor = Color.MistyRose;
                txtGrpCode.Focus();
                return;
            }
            else if (retValue == -98)
            {
                MessageBox.Show("Group Name already Exists", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtGrpCode.Text = "";
                //txtGrpName.Text = "";
                txtGrpName.BackColor = Color.MistyRose;
                txtGrpName.Focus();
                return;
            }
            else
            {
                MessageBox.Show("Failed to update Material Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //Validate Form Fields
        private bool ValidateDetails()
        {
            bool retValue = true;
            if (txtGrpCode.Text == "" || string.IsNullOrEmpty(txtGrpCode.Text) || txtGrpCode.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Group Code", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGrpCode.Focus();
                txtGrpCode.BackColor = Color.MistyRose;
                retValue = false;

                return retValue;
            }

            if (txtGrpName.Text == "" || string.IsNullOrEmpty(txtGrpName.Text) || txtGrpName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Group Name", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retValue = false;
                txtGrpName.Focus();
                txtGrpName.BackColor = Color.MistyRose;
                return retValue;
            }

            else
            {
                txtGrpCode.BackColor = SystemColors.Window;
                txtGrpName.BackColor = SystemColors.Window; // reset to normal if filled

            }

            return retValue;
        }

        //Clear Form Fields
        private void Clear()
        {
            txtGrpCode.Enabled = true;
            txtGrpCode.Text = "";
            txtGrpName.Text = "";
            txtMinLevel.Text = "0.00";
            txtGrpCode.BackColor = SystemColors.Window;
            txtGrpName.BackColor = SystemColors.Window;
            txtMinLevel.BackColor = SystemColors.Window;
            _itemGroupId = 0;
            txtGrpCode.Focus();
        }

        private void txtGrpCode_Leave(object sender, EventArgs e)
        {
            if (GeneralObjects.isNavigating) return; //if switch to another form.

            if (string.IsNullOrWhiteSpace(txtGrpCode.Text))
            {
                txtGrpCode.BackColor = Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Please Enter Group Code", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtGrpCode.BackColor = SystemColors.Window; // reset to normal if filled
            }
        }

        private void txtGrpName_Leave(object sender, EventArgs e)
        {
            if (GeneralObjects.isNavigating) return;
            if (string.IsNullOrWhiteSpace(txtGrpCode.Text))
            {
                txtGrpName.BackColor = Color.MistyRose; // highlight with a soft red/pink
                MessageBox.Show("Please Enter Group Name", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtGrpName.BackColor = SystemColors.Window; // reset to normal if filled
            }

        }

        // Change Status
        private void ccdc_Status(object sender, DataGridViewCellEventArgs e)
        {
            _generalDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _group = dgvMaterial.Rows[e.RowIndex].Cells["GroupName"].Value.ToString();

            _itemGroupId = Convert.ToInt32(dgvMaterial.Rows[e.RowIndex].Cells["Id"].Value);
            int _statusFlag = Convert.ToBoolean(dgvMaterial.Rows[e.RowIndex].Cells["IsActive"].Value) ? 1 : 0;
            bool _statusValue = Convert.ToBoolean(dgvMaterial.Rows[e.RowIndex].Cells["IsActive"].Value) ? true : false;

            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                try
                {
                    if (_statusValue == true)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to InActive " + _group + "?", "Confirmation",
                                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 0;
                            bool retFlag = _generalDB.SetActiveInActiveStatus("ItemGroup", _itemGroupId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "Material : " + _group + " Inactive successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _userName, this.Text, Environment.MachineName);
                            }
                        }

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to Active " + _group + "?", "Confirmation",
                                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 1;
                            bool retFlag = _generalDB.SetActiveInActiveStatus("ItemGroup", _itemGroupId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "Material : " + _group + " Active successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _userName, this.Text, Environment.MachineName);
                            }
                        }
                    }

                    BindMaterial();
                    //dgvMaterial.DataSource = _objItemGroup.GetItemGroup(0, -1);
                }
                catch (Exception ex)
                {
                    GeneralObjects.ErrLogger.WritetoLogFile("Material : SetActiveInactive");
                    GeneralObjects.ErrLogger.WritetoLogFile(ex);
                }
            }
        }

        private void DeleteMaterial()
        {
            if (_itemGroupId == 0)
            {
                MessageBox.Show("Please select Row to delete Material", "BespokeERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (_itemGroupId != 0)
            {
                int _CanDelete = _objItemGroup.CheckItemGroupStock(_itemGroupId);
                if (_CanDelete == 0)
                {
                    _generalDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                    int retValue = _generalDB.DeleteRecord("ItemGroup", _itemGroupId, GeneralObjects.CurrentUserId);
                    if (retValue == 0)
                    {
                        MessageBox.Show("Material Deleted Successfully", "Delete Material", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _auditText = "Material : " + _group + " deleted.";
                        _objAuditRecords.SetAuditRecords(_auditText, _userName, this.Text, Environment.MachineName);
                        BindMaterial();
                        txtGrpCode.Text = "";
                        txtGrpName.Text = "";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Can't Delete Material with pending Stock", "Delete Material", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Failed to Delete Material", "Delete Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on the column header row
            if (e.RowIndex < 0)
                return;

            txtGrpCode.Text = "";
            txtGrpName.Text = "";
            _itemGroupId = Convert.ToInt32(dgvMaterial.Rows[e.RowIndex].Cells["Id"].Value);
            _group = Convert.ToString(dgvMaterial.Rows[e.RowIndex].Cells["GroupName"].Value);


            if (e.ColumnIndex == 11) // Assuming column index 10 is the "Edit" button
            {
                // Get the Id from the clicked row
                int status = Convert.ToInt32(dgvMaterial.Rows[e.RowIndex].Cells["IsActive"].Value);

                if (status == 0)
                {
                    MessageBox.Show("This record is inactive and can't be edited right now.", "Action not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Call edit method
                GetMaterialEditData(_itemGroupId);
            }
            else if (e.ColumnIndex == 12) // Delete button
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this Material? This action cannot be undone.",
                    "BespokeERP",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    _itemGroupId = Convert.ToInt32(dgvMaterial.Rows[e.RowIndex].Cells["Id"].Value);
                    DeleteMaterial(); // Call your delete function here
                }
            }

        }

        private void dgvMaterial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void dgvMaterial_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                if (e.ColumnIndex == 11)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.PaintBackground(e.ClipBounds, false);

                    var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                    e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, 20, 20));
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
                GeneralObjects.ErrLogger.WritetoLogFile("Material : SetEditandDelete");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //txtGrpCode.Text = "";
            //txtGrpName.Text = "";
            Clear();
        }

        private void dgvMaterial_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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

        private void frmMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
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

        private void dgvMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.E))
            {
                if (dgvMaterial.CurrentCell != null) // && dgvMaterial.Columns[dgvMaterial.CurrentCell.ColumnIndex].Name == "Edit"
                {
                    dgvMaterial.ReadOnly = false;
                    dgvMaterial.BeginEdit(true);
                    e.SuppressKeyPress = true; // Stop further processing of the key

                    if (dgvMaterial.CurrentCell != null)
                    {
                        int rowIndex = dgvMaterial.CurrentCell.RowIndex;
                        int _itemId = Convert.ToInt32(dgvMaterial.Rows[rowIndex].Cells["Id"].Value);
                        int status = Convert.ToInt32(dgvMaterial.Rows[rowIndex].Cells["IsActive"].Value);

                        if (status == 0)
                        {
                            MessageBox.Show("This record is inactive and can't be edited right now.", "Action not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        GetMaterialEditData(_itemId);
                        txtGrpCode.Focus();

                    }
                }
            }
        }
    }
}
