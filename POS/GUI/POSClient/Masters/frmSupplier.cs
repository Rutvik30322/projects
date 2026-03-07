using NDatabaseAccess;
using POSClient.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSClient
{
    public partial class frmSupplier : Form
    {
        #region Private Variable
        Suppliers _objSupplier = null;
        GeneralDB _generalDB;
        private int _supplierId = 0;
        private string _auditText = "";
        private string _supplier = "";
        private string _username = GeneralObjects.FirstName + " " + GeneralObjects.LastName;
        GeneralSettings _objGeneralSettings = null;
        AuditRecords _objAuditRecords = null;
        #endregion

        #region Constructor/Destructor
        public frmSupplier()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }

        ~frmSupplier()
        {
            if (_objSupplier != null)
                _objSupplier = null;

            if (_generalDB != null)
                _generalDB = null;

            if (_auditText != null)
                _auditText = null;

            if (_supplier != null)
                _supplier = null;

            if (_username != null)
                _username = null;

            if (_supplierId != 0)
                _supplierId = 0;

            if (_objGeneralSettings != null)
                _objGeneralSettings = null;

            if (_objAuditRecords != null)
                _objAuditRecords = null;
        }
        #endregion

        private void SetTheme()
        {
            this.BackColor = Themes.FormBackColor;

            //Header
            btnHeader.BackColor = Themes.HeaderBackColor;
            btnHeader.ForeColor = Themes.HeaderForeColor;
            btnHeader.FlatStyle = FlatStyle.Flat;
            btnHeader.FlatAppearance.BorderSize = 1;
            btnHeader.FlatAppearance.BorderColor = Themes.HeaderBorderColor;

            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.BackColor = Themes.ButtonBackColor;
            btnAdd.ForeColor = Themes.ButtonForeColor;
            btnAdd.FlatAppearance.BorderSize = 1;
            btnAdd.FlatAppearance.BorderColor = Themes.ButtonBorderColor;

            lblShortcut.ForeColor = Themes.LabelForeColor;
            lblShortcut.BackColor = Themes.LabelBackColor;

            Themes.DataGridTheme(dgvSupplier);
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            btnAdd.Focus();
            try
            {
                _objSupplier = new Suppliers(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objGeneralSettings = new GeneralSettings(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _objAuditRecords = new AuditRecords(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                BindSupplier();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Supplier : Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void BindSupplier()
        {
            DataTable _objDataTable = _objSupplier.GetSupplier(0, -1);

            if (_objDataTable != null || _objDataTable.Rows.Count > 0)
            {
                dgvSupplier.DataSource = _objDataTable;
                dgvSupplier.Columns["Sr. No."].DisplayIndex = 1;

                dgvSupplier.Columns["Id"].Visible = false;
                dgvSupplier.Columns["PanNumber"].Visible = false;
                dgvSupplier.Columns["IsActive"].Visible = false;
                dgvSupplier.Columns["IsActive"].Visible = false;
                //dgvSupplier.Columns["Country"].Visible = false;
                dgvSupplier.Columns["ContactPersonName"].Visible = false;
                dgvSupplier.Columns["ContactPersonPhone"].Visible = false;
                dgvSupplier.Columns["ContactPersonPosition"].Visible = false;
                dgvSupplier.Columns["ContactPersonEmail"].Visible = false;
                dgvSupplier.Columns["UpdatedBy"].Visible = false;
                dgvSupplier.Columns["UpdatedDate"].Visible = false;
                dgvSupplier.Columns["UpdatedByUser"].Visible = false;

                dgvSupplier.Columns["SupplierName"].HeaderText = "Name";
                dgvSupplier.Columns["GSTNumber"].HeaderText = "GST No.";
                //dgvSupplier.Columns["ContactPersonName"].HeaderText = "Contact Person Name";
                //dgvSupplier.Columns["ContactPersonPhone"].HeaderText = "Contact Person Phone";

                dgvSupplier.Columns["Sr. No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSupplier.Columns["SupplierName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSupplier.Columns["Address1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSupplier.Columns["Address2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSupplier.Columns["City"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSupplier.Columns["State"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSupplier.Columns["Country"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSupplier.Columns["Pincode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSupplier.Columns["GSTNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSupplier.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSupplier.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSupplier.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSupplier.Columns["View"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvSupplier.Columns["Sr. No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSupplier.Columns["Pincode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSupplier.Columns["GSTNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgvSupplier.Columns["Sr. No."].Width = 70;
                dgvSupplier.Columns["City"].Width = 100;
                dgvSupplier.Columns["State"].Width = 100;
                dgvSupplier.Columns["Country"].Width = 100;
                dgvSupplier.Columns["Pincode"].Width = 80;
                dgvSupplier.Columns["GSTNumber"].Width = 150;
                dgvSupplier.Columns["Status"].Width = 80;
                dgvSupplier.Columns["Edit"].Width = 50;
                dgvSupplier.Columns["Delete"].Width = 50;
                dgvSupplier.Columns["View"].Width = 50;

            }
            else
            {
                dgvSupplier.DataSource = null;
            }

        }

        private void DeleteSupplier()
        {
            if (_supplierId == 0)
            {
                MessageBox.Show("Please select Row to delete Supplier", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _generalDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            int retValue = _generalDB.DeleteRecord("Suppliers", _supplierId, GeneralObjects.CurrentUserId);
            if (retValue == 0)
            {
                MessageBox.Show("Supplier Deleted Successfully", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _auditText = "Supplier : " + _supplier + " deleted.";
                _objAuditRecords.SetAuditRecords(_auditText, _username, this.Text, Environment.MachineName);

                BindSupplier();
                return;
            }
            else
            {
                MessageBox.Show("Failed to Delete Supplier", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GeneralObjects.isNavigating = true;
            frmAddSupplier addSupplierForm = new frmAddSupplier(0, false);
            //frmAddSupplier addSupplierForm = new frmAddSupplier(0);
            DialogResult result = addSupplierForm.ShowDialog(this);
            BindSupplier();
        }
        private void dgvSupplier_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 16 && e.Value != null)
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

        private void dgvSupplier_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                if (e.ColumnIndex == 20) // For Edit Icon
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.PaintBackground(e.ClipBounds, false);

                    var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                    e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, 20, 20));
                    e.Handled = true;
                }

                if (e.ColumnIndex == 21) // For Delete
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.PaintBackground(e.ClipBounds, false);

                    var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                    //e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, w, h));
                    e.Graphics.DrawImage(Properties.Resources.Delete, new Rectangle(x, y, 20, 20));
                    e.Handled = true;
                }
                if (e.ColumnIndex == 22) // For View
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.PaintBackground(e.ClipBounds, false);

                    var x = e.CellBounds.Left + (e.CellBounds.Width - 20) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - 20) / 2;

                    //e.Graphics.DrawImage(Properties.Resources.Edit, new Rectangle(x, y, w, h));
                    e.Graphics.DrawImage(Properties.Resources.visible_24, new Rectangle(x, y, 20, 20));
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Supplier : SetEditandDelete");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void ccdc_Status(object sender, DataGridViewCellEventArgs e)
        {
            _generalDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

            if (e.RowIndex >= 0 && e.ColumnIndex == 16)
            {

                _supplier = dgvSupplier.Rows[e.RowIndex].Cells["SupplierName"].Value.ToString();

                _supplierId = Convert.ToInt32(dgvSupplier.Rows[e.RowIndex].Cells["Id"].Value);
                int _statusFlag = Convert.ToBoolean(dgvSupplier.Rows[e.RowIndex].Cells["IsActive"].Value) ? 1 : 0;

                bool _statusValue = Convert.ToBoolean(dgvSupplier.Rows[e.RowIndex].Cells["IsActive"].Value) ? true : false;
                try
                {
                    if (_statusValue == true)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to InActive " + _supplier + "?", "Confirmation",
                                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 0;
                            bool retFlag = _generalDB.SetActiveInActiveStatus("Suppliers", _supplierId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "Supplier : " + _supplier + " Inactive successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _username, this.Text, Environment.MachineName);
                            }
                        }

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to Active " + _supplier + "?", "Confirmation",
                                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _statusFlag = 1;
                            bool retFlag = _generalDB.SetActiveInActiveStatus("Suppliers", _supplierId, _statusFlag, GeneralObjects.CurrentUserId);
                            if (retFlag)
                            {
                                _auditText = "Supplier : " + _supplier + " Active successfully.";
                                _objAuditRecords.SetAuditRecords(_auditText, _username, this.Text, Environment.MachineName);
                            }
                        }
                    }

                    BindSupplier();
                }
                catch (Exception ex)
                {
                    GeneralObjects.ErrLogger.WritetoLogFile("Supplier : SetActiveInactive");
                    GeneralObjects.ErrLogger.WritetoLogFile(ex);
                }
            }
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _supplierId = Convert.ToInt32(dgvSupplier.Rows[e.RowIndex].Cells["Id"].Value);
            _supplier = Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["SupplierName"].Value);

            int status = Convert.ToInt32(dgvSupplier.Rows[e.RowIndex].Cells["IsActive"].Value);

            if (e.ColumnIndex == 20)
            {
                if (status == 0)
                {
                    MessageBox.Show("This record is inactive and can't be edited right now.", "Action not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmAddSupplier adduserform = new frmAddSupplier(_supplierId, false);
                //frmAddSupplier adduserform = new frmAddSupplier(_supplierId);
                DialogResult result = adduserform.ShowDialog(this);
                BindSupplier();
            }
            else if (e.ColumnIndex == 21)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this Supplier? This action cannot be undone.", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    _supplierId = Convert.ToInt32(dgvSupplier.Rows[e.RowIndex].Cells["Id"].Value);
                    DeleteSupplier();
                }
            }
            else if (e.ColumnIndex == 22)  // for View
            {

                _supplierId = Convert.ToInt32(dgvSupplier.Rows[e.RowIndex].Cells["Id"].Value);

                frmAddSupplier adduserform = new frmAddSupplier(_supplierId, true);
                DialogResult result = adduserform.ShowDialog(this);
                BindSupplier();
            }
        }

        private void dgvSupplier_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var dataGridView = (sender as DataGridView);
            if (e.ColumnIndex == 16 || e.ColumnIndex == 20 || e.ColumnIndex == 21 || e.ColumnIndex == 22)
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Default;
        }

        private void dgvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.E))
            {
                if (dgvSupplier.CurrentCell != null) // && dgvMaterial.Columns[dgvMaterial.CurrentCell.ColumnIndex].Name == "Edit"
                {
                    dgvSupplier.ReadOnly = false;
                    dgvSupplier.BeginEdit(true);
                    e.SuppressKeyPress = true; // Stop further processing of the key

                    if (dgvSupplier.CurrentCell != null)
                    {
                        int rowIndex = dgvSupplier.CurrentCell.RowIndex;
                        int _sId = Convert.ToInt32(dgvSupplier.Rows[rowIndex].Cells["Id"].Value);
                        int status = Convert.ToInt32(dgvSupplier.Rows[rowIndex].Cells["IsActive"].Value);
                        if (status == 0)
                        {
                            MessageBox.Show("This record is inactive and can't be edited right now.", "Action not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        frmAddSupplier adduserform = new frmAddSupplier(_sId, false);
                        //frmAddSupplier adduserform = new frmAddSupplier(_supplierId);
                        DialogResult result = adduserform.ShowDialog(this);
                        BindSupplier();
                    }
                }
            }
        }

        private void frmSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show("Are you sure you want to close this form?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
