using NDatabaseAccess;
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
    public partial class frmAuditRecords : Form
    {
        #region Private Variables
        GeneralDB _generalDB;
        #endregion
        public frmAuditRecords()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetThemes();
        }

        public void SetThemes()
        {
            this.BackColor = Themes.FormBackColor;

            //Header
            btnHeader.BackColor = Themes.HeaderBackColor;
            btnHeader.ForeColor = Themes.HeaderForeColor;
            btnHeader.FlatStyle = FlatStyle.Flat;
            btnHeader.FlatAppearance.BorderSize = 1;
            btnHeader.FlatAppearance.BorderColor = Themes.HeaderBorderColor;

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

            Themes.DataGridTheme(dgvAuditRecords);

            lblStartDate.BackColor = Themes.LabelBackColor;
            lblStartDate.ForeColor = Themes.LabelForeColor;

            lblEndDt.BackColor = Themes.LabelBackColor;
            lblEndDt.ForeColor = Themes.LabelForeColor;

            lblShortcut.BackColor = Themes.LabelBackColor;
            lblShortcut.ForeColor = Themes.LabelForeColor;
        }

        private void frmAuditRecords_Load(object sender, EventArgs e)
        {
            dtpStartDt.Focus();
            dtpEndDate.Value = DateTime.Today;
            dtpStartDt.Value = DateTime.Today;
            dtpStartDt.MaxDate = DateTime.Today;
            dtpEndDate.MaxDate = DateTime.Today;
            try
            {
                _generalDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                BindGridView();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Material : Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void BindGridView()
        {
            DataTable _objDataTable = _generalDB.GetAuditRecords(dtpStartDt.Value, dtpEndDate.Value);
            if (_objDataTable != null || _objDataTable.Rows.Count > 0)
            {
                dgvAuditRecords.DataSource = _objDataTable;
                dgvAuditRecords.Columns["AuditText"].HeaderText = "Audit Details";
                dgvAuditRecords.Columns["TimeStamp"].HeaderText = "Date";
                dgvAuditRecords.Columns["UserName"].HeaderText = "User Name";
                dgvAuditRecords.Columns["ScreenName"].HeaderText = "Screen Name";
                dgvAuditRecords.Columns["SystemName"].HeaderText = "Station Name";


                dgvAuditRecords.Columns["TimeStamp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAuditRecords.Columns["AuditText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAuditRecords.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAuditRecords.Columns["ScreenName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAuditRecords.Columns["SystemName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvAuditRecords.Columns["TimeStamp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvAuditRecords.Columns["TimeStamp"].Width = 120;
                //dgvAuditRecords.Columns["AuditText"].Width = 180;
                dgvAuditRecords.Columns["UserName"].Width = 120;
                dgvAuditRecords.Columns["ScreenName"].Width = 120;
                dgvAuditRecords.Columns["SystemName"].Width = 120;
            }
            else
            {
                dgvAuditRecords = null;
            }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Today;
            dtpStartDt.Value = DateTime.Today;
            BindGridView();
        }

        private void frmAuditRecords_KeyDown(object sender, KeyEventArgs e)
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
