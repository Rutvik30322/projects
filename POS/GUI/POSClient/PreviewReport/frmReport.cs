using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using NDatabaseAccess;
using static NConstant.Constant;

namespace POSClient
{
    public partial class frmReport : Form
    {
        #region "private Variable"
        PreviewReport _objReport = null;
        GeneralDB _objGeneralDB = null;
        ItemsGroup _objMaterial = null;
        Inventory _objInventory = null;
        Suppliers _objSupplier = null;
        Purchases _objPurchases = null;


        private string _reportName = "";
        private string _viewName = "";
        private string[] _paramName;
        private string[] _paramValue;
        private string _paramNameIn;
        private bool isSettingDate = false;

        private int reportId = 0;
        private long paramId;
        private string _ReportType;
        private string _ReportCategory;

        private DataTable _dtMaterial;
        private DataTable _dtSupplier;
        private DataTable _dtArticleNo;
        private DataTable _dtSize;
        private DataTable _dtReportCategory;
        private DataTable _dtReport;

        private bool _subReportFlag = false;
        private string _reportPath = Application.StartupPath + @"\Reports\";
        #endregion

        #region "Constructor/Destructor"
        public frmReport()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetTheme();
        }

        ~frmReport()
        {
            if (_objReport != null)
                _objReport = null;

            if (_objGeneralDB != null)
                _objGeneralDB = null;

            if (_objSupplier != null)
                _objSupplier = null;

            if (_objPurchases != null)
                _objPurchases = null;

            if (_objMaterial != null)
                _objMaterial = null;

            if (_objInventory != null)
                _objInventory = null;
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

            lblMaterial.ForeColor = Themes.LabelForeColor;
            lblMaterial.BackColor = Themes.LabelBackColor;

            lblArticleNo.ForeColor = Themes.LabelForeColor;
            lblArticleNo.BackColor = Themes.LabelBackColor;

            lblReportCategory.ForeColor = Themes.LabelForeColor;
            lblReportCategory.BackColor = Themes.LabelBackColor;

            lblReportName.ForeColor = Themes.LabelForeColor;
            lblReportName.BackColor = Themes.LabelBackColor;

            lblSupplier.ForeColor = Themes.LabelForeColor;
            lblSupplier.BackColor = Themes.LabelBackColor;

            lblSalesThreshold.ForeColor = Themes.LabelForeColor;
            lblSalesThreshold.BackColor = Themes.LabelBackColor;

            lblDays.ForeColor = Themes.LabelForeColor;
            lblDays.BackColor = Themes.LabelBackColor;

            //Button Save & Cancel
            btnPreview.FlatStyle = FlatStyle.Flat;
            btnPreview.BackColor = Themes.ButtonBackColor;
            btnPreview.ForeColor = Themes.ButtonForeColor;
            btnPreview.FlatAppearance.BorderSize = 1;
            btnPreview.FlatAppearance.BorderColor = Themes.ButtonBorderColor;
        }
        #endregion

        private void frmReport_Load(object sender, EventArgs e)
        {
            _objReport = new PreviewReport(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objMaterial = new ItemsGroup(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objInventory = new Inventory(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objGeneralDB = new GeneralDB(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objSupplier = new Suppliers(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            _objPurchases = new Purchases(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);

            //DataTable objReportTypedt = _objGeneralDB.GetListIndexWithMessageText((int)ListId.ReportCategory);
            //PopulateTreeView();
            BindMaterialCmb();
            SearchMaterial();
            cmbMaterial.SelectedIndex = -1;
            BindSupplier();
            SearchSupplier();
            cmbSupplier.SelectedIndex = -1;
            BindArticleNo();
            SearchArticleNo();
            cmbArticleNo.SelectedIndex = -1;
            BindReportCategory();
            SearchReportCategory();
            cmbReportCategory.SelectedIndex = 0;
            cmbReportName.SelectedIndex = 0;

            //All Filter and report viewer window is disabled
            cmbMaterial.Enabled = true;
            cmbArticleNo.Enabled = true;
            dtpFromDate.Enabled = false;
            dtpToDate.Enabled = false;
            cmbSupplier.Enabled = false;
            txtSalesThreshold.Enabled = false;
            txtDays.Enabled = false;
            rptReportViewer.Visible = false;




            //this.rptReportViewer.RefreshReport();

            //trreport.Focus();

            ////blank all combobx
            //cmbSupplier.SelectedIndex = -1;
            //cmbmaterial.SelectedIndex = -1;
            //cmbArticleNo.SelectedIndex = -1;
            //cmbSize.SelectedIndex = -1;

            //btnPreview.Enabled = false;
            ////btnPDF.Enabled = false;
            ////btnExcel.Enabled = false;
            //rptReportViewer.Visible = false;

            ////expand Tree view
            //trreport.ExpandAll();
            //this.rptReportViewer.RefreshReport();
            this.rptReportViewer.RefreshReport();
        }

        //    private void PopulateTreeView()
        //    {
        //        // Step 1: Get Report Types from database
        //        DataTable dtReportType = _objGeneralDB.GetListIndexWithMessageText((int)ListId.ReportType);

        //        foreach (DataRow reportTypeRow in dtReportType.Rows)
        //        {
        //            string reportTypeName = Convert.ToString(reportTypeRow["MessageText"]);
        //            int reportTypeId = Convert.ToInt32(reportTypeRow["ListIndex"]);

        //            TreeNode reportTypeNode = new TreeNode()
        //            {
        //                Text = reportTypeName,
        //                Tag = reportTypeId
        //            };
        //            trreport.Nodes.Add(reportTypeNode);

        //            // Step 2: Get all report categories
        //            DataTable dtCategories = _objGeneralDB.GetListIndexWithMessageText((int)ListId.ReportCategory);

        //            foreach (DataRow categoryRow in dtCategories.Rows)
        //            {
        //                int reportCategoryId = Convert.ToInt32(categoryRow["ListIndex"]);
        //                string categoryName = Convert.ToString(categoryRow["MessageText"]);

        //                TreeNode categoryNode = new TreeNode()
        //                {
        //                    Text = categoryName,
        //                    Tag = reportCategoryId
        //                };
        //                reportTypeNode.Nodes.Add(categoryNode);

        //                // Step 3: Get reports based on ReportTypeId and CategoryId
        //                DataTable dtReports = _objReport.GetReportsConfig(reportTypeId, reportCategoryId);
        //                foreach (DataRow reportRow in dtReports.Rows)
        //                {
        //                    TreeNode reportNode = new TreeNode()
        //                    {
        //                        Text = Convert.ToString(reportRow["ReportName"]),
        //                        Tag = reportRow["Id"]
        //                    };
        //                    categoryNode.Nodes.Add(reportNode);
        //                }
        //            }
        //        }
        //    }

        //    private void trreport_AfterSelect(object sender, TreeViewEventArgs e)
        //    {
        //        TreeNode selectedNode = e.Node;

        //        if (selectedNode.Parent != null) // Means it's a child (report), not a category
        //        {
        //            lblSelectedReportName.Text = selectedNode.Text;
        //            reportId = _objReport.GetReportId(Convert.ToString(lblSelectedReportName.Text));

        //            if (reportId == 0)
        //            {
        //                btnPreview.Enabled = false;
        //                //btnPDF.Enabled = false;
        //                //btnExcel.Enabled = false;
        //                rptReportViewer.Visible = false;
        //            }
        //            else
        //            {
        //                btnPreview.Enabled = true;
        //                //btnPDF.Enabled = true;
        //                //btnExcel.Enabled = true;
        //                rptReportViewer.Visible = false;
        //            }

        //        }
        //        else
        //        {
        //            lblSelectedReportName.Text = ""; // Clear or show category name if needed
        //        }
        //    }

        //    private void btnExpandAll_Click(object sender, EventArgs e)
        //    {
        //        trreport.ExpandAll();
        //    }

        //    private void btnCollapseAll_Click(object sender, EventArgs e)
        //    {
        //        trreport.CollapseAll();
        //    }

        //    //Material Combobox


        //    //Size Combobox
        //    private void BindSizeCmb()
        //    {
        //        _dtSize = _objInventory.GetSize();
        //        if (_dtSize != null && _dtSize.Rows.Count > 0)
        //        {
        //            DataRow dr = _dtSize.NewRow();
        //            dr["SIZE"] = "All";
        //            dr["SIZE"] = "All";
        //            _dtSize.Rows.InsertAt(dr, 0);

        //            cmbSize.DisplayMember = "SIZE";
        //            cmbSize.ValueMember = "SIZE";
        //            cmbSize.DataSource = _dtSize;
        //        }
        //    }

        #region "Bind and Search Report Category from Database Auto Complete Functionality"
        private void BindReportCategory()
        {
            _dtReportCategory = _objGeneralDB.GetListIndexWithMessageText((int)ListId.ReportCategory);
            if (_dtReportCategory != null && _dtReportCategory.Rows.Count > 0)
            {
                cmbReportCategory.DisplayMember = "MessageText";
                cmbReportCategory.ValueMember = "ListIndex";
                cmbReportCategory.DataSource = _dtReportCategory;
            }
        }

        private void SearchReportCategory()
        {
            try
            {
                cmbReportCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbReportCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collAutoCompleteText = new AutoCompleteStringCollection();


                if (_dtReportCategory != null && _dtReportCategory.Rows.Count > 0)
                {
                    for (int i = 0; i < _dtSupplier.Rows.Count; i++)
                    {
                        collAutoCompleteText.Add(_dtReportCategory.Rows[i][1].ToString());
                    }
                }
                cmbReportCategory.AutoCompleteCustomSource = collAutoCompleteText;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Report : SearchReportCategory");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
        #endregion

        #region "Bind and Search Supplier from Database Auto Complete Functionality"
        private void BindSupplier()
        {
            _dtSupplier = _objSupplier.GetSupplier(0, 1);
            if (_dtSupplier != null && _dtSupplier.Rows.Count > 0)
            {
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "Id";
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
                GeneralObjects.ErrLogger.WritetoLogFile("Supplier : SearchSupplier");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
        #endregion

        #region "Bind and Search Material from Database Auto Complete Functionality"

        private void BindMaterialCmb()
        {
            _dtMaterial = _objMaterial.GetItemGroup(0, 1);
            if (_dtMaterial != null && _dtMaterial.Rows.Count > 0)
            {
                cmbMaterial.DisplayMember = "GroupName";
                cmbMaterial.ValueMember = "Id";
                cmbMaterial.DataSource = _dtMaterial;
            }
        }

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

        #region "Bind And Search Article No from Database Auto Complete Functionality"
        private void BindArticleNo()
        {
            _dtArticleNo = _objPurchases.GetArticleNumber();
            if (_dtArticleNo != null && _dtArticleNo.Rows.Count > 0)
            {
                cmbArticleNo.DisplayMember = "ArticleNo";
                cmbArticleNo.ValueMember = "ArticleNo";
                cmbArticleNo.DataSource = _dtArticleNo;
            }
        }

        private void SearchArticleNo()
        {
            try
            {
                cmbArticleNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbArticleNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collAutoCompleteText = new AutoCompleteStringCollection();

                if (_dtArticleNo != null && _dtArticleNo.Rows.Count > 0)
                {
                    foreach (DataRow row in _dtArticleNo.Rows)
                    {
                        string articleno = row["ArticleNo"].ToString();
                        if (!string.IsNullOrWhiteSpace(articleno) && !collAutoCompleteText.Contains(articleno))
                        {
                            collAutoCompleteText.Add(articleno);
                        }
                    }
                }

                cmbArticleNo.AutoCompleteCustomSource = collAutoCompleteText;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Reports : SearchArticleNo");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
        #endregion

        #region "Bind And Search Report from Database Auto Complete Functionality"
        private void BindReportList()
        {
            _dtReport = _objReport.GetReportsConfig(0, cmbReportCategory.SelectedIndex);
            if (_dtReport != null && _dtReport.Rows.Count > 0)
            {
                cmbReportName.DisplayMember = "ReportName";
                cmbReportName.ValueMember = "Id";
                cmbReportName.DataSource = _dtReport;
            }
        }

        private void SearchReport()
        {
            try
            {
                cmbReportName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbReportName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collAutoCompleteText = new AutoCompleteStringCollection();

                if (_dtReport != null && _dtReport.Rows.Count > 0)
                {
                    foreach (DataRow row in _dtReport.Rows)
                    {
                        string rpt = row["ReportName"].ToString();
                        if (!string.IsNullOrWhiteSpace(rpt) && !collAutoCompleteText.Contains(rpt))
                        {
                            collAutoCompleteText.Add(rpt);
                        }
                    }
                }

                cmbReportName.AutoCompleteCustomSource = collAutoCompleteText;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Reports : SearchReport");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
        #endregion

        //    private void SearchSize()
        //    {
        //        try
        //        {
        //            cmbSize.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //            cmbSize.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //            AutoCompleteStringCollection collAutoCompleteSizeText = new AutoCompleteStringCollection();


        //            if (_dtSize != null && _dtSize.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < _dtSize.Rows.Count; i++)
        //                {
        //                    collAutoCompleteSizeText.Add(_dtSize.Rows[i][1].ToString());
        //                }
        //            }
        //            cmbSize.AutoCompleteCustomSource = collAutoCompleteSizeText;
        //        }
        //        catch (Exception ex)
        //        {
        //            GeneralObjects.ErrLogger.WritetoLogFile("Size : SearchSize");
        //            GeneralObjects.ErrLogger.WritetoLogFile(ex);
        //        }
        //    }

        //    public void showLocalReport(string rptName, string viewName, string paramName, string[] paramValue)
        //    {
        //        try
        //        {
        //            rptReportViewer.ProcessingMode = ProcessingMode.Local;
        //            //rptReportViewer.LocalReport.ReportPath = @"C:\Program Files (x86)\BeSpokePOS\Bin\Reports\" + rptName + ".rdl";
        //            rptReportViewer.LocalReport.ReportPath = _reportPath + rptName + ".rdl";


        //            DataSet ds = new DataSet();

        //            if (paramName != null)
        //            {
        //                if (paramValue.Length > 0)
        //                {
        //                    ds = _objReport.GetReportSQLQueryWhereIn(viewName, paramName, paramValue);
        //                }
        //            }

        //            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
        //            rptReportViewer.LocalReport.DataSources.Clear();
        //            rptReportViewer.LocalReport.DataSources.Add(rds);
        //            rptReportViewer.LocalReport.Refresh();
        //            rptReportViewer.RefreshReport();
        //            rptReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
        //            rptReportViewer.ZoomMode = ZoomMode.PageWidth;
        //            //rptViewer1.ZoomPercent = 75;

        //            if (ds.Tables[0].Rows.Count == 0)
        //            {
        //                rptReportViewer.Visible = false;
        //                MessageBox.Show("No Records found", "BeSpokeERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                rptReportViewer.Visible = true;
        //            }
        //            // Refresh the report  
        //            rptReportViewer.RefreshReport();
        //        }
        //        catch (Exception ex)
        //        {
        //            GeneralObjects.ErrLogger.WritetoLogFile("Report Viewer : showLocalReport With Parameters");
        //            GeneralObjects.ErrLogger.WritetoLogFile(ex);
        //        }
        //    }

        //    public void showLocalReport(string rptName, string viewName, string[] paramName, string[] paramValue)
        //    {
        //        try
        //        {
        //            rptReportViewer.ProcessingMode = ProcessingMode.Local;
        //            rptReportViewer.LocalReport.ReportPath = _reportPath + rptName + ".rdl";

        //            DataSet ds = new DataSet();

        //            if (paramName != null)
        //            {
        //                if (paramValue.Length > 0)
        //                {
        //                    ds = _objReport.GetReportSQLStoreProc(viewName, paramName, paramValue);
        //                }
        //            }

        //            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
        //            rptReportViewer.LocalReport.DataSources.Clear();
        //            rptReportViewer.LocalReport.DataSources.Add(rds);
        //            rptReportViewer.LocalReport.Refresh();
        //            rptReportViewer.RefreshReport();
        //            rptReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
        //            rptReportViewer.ZoomMode = ZoomMode.PageWidth;
        //            //rptViewer1.ZoomPercent = 75;

        //            if (ds.Tables[0].Rows.Count == 0)
        //            {
        //                rptReportViewer.Visible = false;
        //                MessageBox.Show("No Records found", "BeSpokeERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                rptReportViewer.Visible = true;
        //            }
        //            // Refresh the report  
        //            rptReportViewer.RefreshReport();
        //        }
        //        catch (Exception ex)
        //        {
        //            GeneralObjects.ErrLogger.WritetoLogFile("Report Viewer : showLocalReport With Parameters");
        //            GeneralObjects.ErrLogger.WritetoLogFile(ex);
        //        }
        //    }

        //    public void showLocalReport()
        //    {
        //        try
        //        {
        //            rptReportViewer.ProcessingMode = ProcessingMode.Local;
        //            rptReportViewer.LocalReport.ReportPath = _reportPath + _reportName + ".rdl";
        //            if (_paramName != null)
        //            {
        //                if (_paramName.Length > 0)
        //                {
        //                    ReportParameter rptParam = new ReportParameter();
        //                    for (int i = 0; i < _paramName.Length; i++)
        //                    {
        //                        rptParam.Name = _paramName[i];
        //                        rptParam.Values.Add(_paramValue[i]);

        //                        rptReportViewer.LocalReport.SetParameters(new ReportParameter[] { rptParam });
        //                    }
        //                }
        //            }

        //            DataSet ds = new DataSet();

        //            if (_paramName != null)
        //            {
        //                if (_paramName.Length > 0)
        //                {
        //                    ds = _objReport.GetReportSQLQueryWhere(_viewName, _paramName, _paramValue);
        //                }
        //            }
        //            else
        //            {
        //                ds = _objReport.GetReportSQLQuery(_viewName);
        //            }

        //            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
        //            rptReportViewer.LocalReport.DataSources.Clear();
        //            rptReportViewer.LocalReport.DataSources.Add(rds);
        //            rptReportViewer.LocalReport.Refresh();
        //            rptReportViewer.RefreshReport();
        //            rptReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
        //            rptReportViewer.ZoomMode = ZoomMode.PageWidth;
        //            //rptViewer1.ZoomPercent = 75;

        //            if (ds.Tables[0].Rows.Count == 0)
        //            {
        //                rptReportViewer.Visible = false;
        //                MessageBox.Show("No Records found", "BeSpokeERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                rptReportViewer.Visible = true;
        //            }
        //            // Refresh the report  
        //            rptReportViewer.RefreshReport();
        //        }
        //        catch (Exception ex)
        //        {
        //            GeneralObjects.ErrLogger.WritetoLogFile("Report Viewer : showLocalReport");
        //            GeneralObjects.ErrLogger.WritetoLogFile(ex);
        //        }
        //    }

        //    private void btnPreview_Click(object sender, EventArgs e)
        //    {
        //        try
        //        {
        //            if (reportId == 2) // rptInventory
        //            {
        //                GeneralObjects.paramSelectionValue = new string[3];
        //                GeneralObjects.paramSelectionValue[0] = Convert.ToString(cmbmaterial.SelectedValue);
        //                GeneralObjects.paramSelectionValue[1] = Convert.ToString(string.IsNullOrEmpty(cmbSize.Text) ? "All" : cmbSize.Text);
        //                GeneralObjects.paramSelectionValue[2] = Convert.ToString(string.IsNullOrEmpty(cmbArticleNo.Text) ? "All" : cmbArticleNo.Text);
        //                //GeneralObjects.paramSelectionValue[2] = Convert.ToString(string.IsNullOrEmpty(txtSizeForReport.Text) ? "0" : txtSizeForReport.Text);
        //                GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
        //            }
        //            else if (reportId == 1) // rptSales
        //            {
        //                GeneralObjects.paramSelectionValue = new string[5];
        //                GeneralObjects.paramSelectionValue[0] = Convert.ToString(cmbmaterial.SelectedValue);
        //                GeneralObjects.paramSelectionValue[1] = Convert.ToString(string.IsNullOrEmpty(cmbSize.Text) ? "All" : cmbSize.Text);
        //                GeneralObjects.paramSelectionValue[2] = Convert.ToString(string.IsNullOrEmpty(cmbArticleNo.Text) ? "All" : cmbArticleNo.Text);
        //                GeneralObjects.paramSelectionValue[3] = dtpFromDate.Value.ToString("yyyy-MM-dd");
        //                GeneralObjects.paramSelectionValue[4] = dtpToDate.Value.ToString("yyyy-MM-dd");
        //                GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
        //            }
        //            else if (reportId == 5) // rptSummarySales
        //            {
        //                GeneralObjects.paramSelectionValue = new string[5];
        //                GeneralObjects.paramSelectionValue[0] = Convert.ToString(cmbmaterial.SelectedValue);
        //                GeneralObjects.paramSelectionValue[1] = Convert.ToString(string.IsNullOrEmpty(cmbSize.Text) ? "All" : cmbSize.Text);
        //                GeneralObjects.paramSelectionValue[2] = Convert.ToString(string.IsNullOrEmpty(cmbArticleNo.Text) ? "All" : cmbArticleNo.Text);
        //                GeneralObjects.paramSelectionValue[3] = dtpFromDate.Value.ToString("yyyy-MM-dd");
        //                GeneralObjects.paramSelectionValue[4] = dtpToDate.Value.ToString("yyyy-MM-dd");
        //                GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
        //            }
        //            else if (reportId == 4) // rptSupplierWiseInventory
        //            {
        //                GeneralObjects.paramSelectionValue = new string[4];
        //                GeneralObjects.paramSelectionValue[0] = Convert.ToString(cmbmaterial.SelectedValue);
        //                GeneralObjects.paramSelectionValue[1] = Convert.ToString(cmbSupplier.SelectedValue);
        //                GeneralObjects.paramSelectionValue[2] = Convert.ToString(string.IsNullOrEmpty(cmbArticleNo.Text) ? "All" : cmbArticleNo.Text);
        //                GeneralObjects.paramSelectionValue[3] = Convert.ToString(string.IsNullOrEmpty(cmbSize.Text) ? "All" : cmbSize.Text);
        //                GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
        //            }
        //            else if (reportId == 3) // rptNonMovingInventory
        //            {
        //                GeneralObjects.paramSelectionValue = new string[4];
        //                GeneralObjects.paramSelectionValue[0] = Convert.ToString(cmbmaterial.SelectedValue);
        //                GeneralObjects.paramSelectionValue[1] = Convert.ToString(string.IsNullOrEmpty(cmbArticleNo.Text) ? "All" : cmbArticleNo.Text);
        //                GeneralObjects.paramSelectionValue[2] = Convert.ToString(string.IsNullOrEmpty(cmbSize.Text) ? "All" : cmbSize.Text);
        //                TimeSpan totalDays = dtpToDate.Value - dtpFromDate.Value;
        //                int days = totalDays.Days;
        //                GeneralObjects.paramSelectionValue[3] = Convert.ToString(days);
        //                GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
        //            }

        //            else
        //            {
        //                GeneralObjects.ReportPreview(reportId, true);
        //            }

        //            _objReport = new PreviewReport(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
        //            _reportName = GeneralObjects._reportName;
        //            _viewName = GeneralObjects._viewName;
        //            _paramName = GeneralObjects._paramName;
        //            _paramValue = GeneralObjects._paramValue;
        //            _paramNameIn = GeneralObjects._paramNameIn;

        //            if (_paramNameIn != null)
        //            {
        //                if (_subReportFlag == false)
        //                {
        //                    showLocalReport(_reportName, _viewName, _paramNameIn, _paramValue);
        //                }
        //                else
        //                {
        //                    //showLocalReportWithSubReport(_reportName, _viewName, _paramName, _paramValue);
        //                }
        //            }
        //            else
        //            {
        //                if (_subReportFlag == false && _paramName == null)
        //                {
        //                    showLocalReport();
        //                }
        //                else if (_subReportFlag == false && _paramName != null)
        //                {
        //                    showLocalReport(_reportName, _viewName, _paramName, _paramValue);
        //                }
        //                else
        //                {
        //                    //showLocalReportWithSubReport(_reportName, _viewName, _paramName, _paramValue);
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            GeneralObjects.ErrLogger.WritetoLogFile("Report Viewer : Load");
        //            GeneralObjects.ErrLogger.WritetoLogFile(ex);
        //        }
        //        this.rptReportViewer.RefreshReport();
        //        _reportName = "";
        //        _viewName = "";
        //        GeneralObjects._paramName = null;
        //        GeneralObjects._paramValue = null;
        //    }

        //    private void dtpToDate_ValueChanged(object sender, EventArgs e)
        //    {
        //        if (isSettingDate) return;

        //        if (dtpFromDate.Value >= dtpToDate.Value)
        //        {
        //            MessageBox.Show("To Date is not before From Date!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            isSettingDate = true; // prevent recursion
        //            dtpToDate.Value = DateTime.Today;
        //            isSettingDate = false;
        //        }
        //    }

        private void frmReport_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbReportCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindReportList();
            SearchReport();
        }

        private void txtSalesThreshold_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                rptReportViewer.Visible = true;

                if (reportId == 2) // Low Stock Alert
                {
                    GeneralObjects.paramSelectionValue = new string[2];
                    GeneralObjects.paramSelectionValue[0] = Convert.ToString(cmbMaterial.SelectedValue ?? 0);
                    GeneralObjects.paramSelectionValue[1] = Convert.ToString(string.IsNullOrEmpty(cmbArticleNo.Text) ? "All" : cmbArticleNo.Text);
                    GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
                }
                else if (reportId == 1) // Current Stock
                {
                    GeneralObjects.paramSelectionValue = new string[2];
                    GeneralObjects.paramSelectionValue[0] = Convert.ToString(cmbMaterial.SelectedValue ?? 0);
                    GeneralObjects.paramSelectionValue[1] = Convert.ToString(string.IsNullOrEmpty(cmbArticleNo.Text) ? "All" : cmbArticleNo.Text);
                    GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
                }
                else if (reportId == 5) // Slow Moving Items
                {
                    GeneralObjects.paramSelectionValue = new string[2];
                    GeneralObjects.paramSelectionValue[0] = Convert.ToString(txtSalesThreshold.Text);
                    GeneralObjects.paramSelectionValue[1] = Convert.ToString(txtDays.Text);
                    GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
                }
                else if (reportId == 4) // Best Selling Items
                {
                    GeneralObjects.paramSelectionValue = new string[2];
                    GeneralObjects.paramSelectionValue[0] = dtpFromDate.Value.ToString("yyyy-MM-dd");
                    GeneralObjects.paramSelectionValue[1] = dtpToDate.Value.ToString("yyyy-MM-dd");
                    GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
                }
                else if (reportId == 3) // Aging Inventory
                {
                    //GeneralObjects.paramSelectionValue = new string[0];
                    //GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId));
                    GeneralObjects.ReportPreview(Convert.ToInt32(reportId), true);
                }
                else if (reportId == 6) // Stock Valuation
                {
                    //GeneralObjects.paramSelectionValue = new string[0];
                    //GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
                    GeneralObjects.ReportPreview(Convert.ToInt32(reportId), true);
                }
                else if (reportId == 7) // Sell Through
                {
                    GeneralObjects.paramSelectionValue = new string[2];
                    GeneralObjects.paramSelectionValue[0] = dtpFromDate.Value.ToString("yyyy-MM-dd");
                    GeneralObjects.paramSelectionValue[1] = dtpToDate.Value.ToString("yyyy-MM-dd");
                    GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
                }
                else if (reportId == 8) //Purchase Order Summary
                {
                    GeneralObjects.paramSelectionValue = new string[4];
                    GeneralObjects.paramSelectionValue[0] = dtpFromDate.Value.ToString("yyyy-MM-dd");
                    GeneralObjects.paramSelectionValue[1] = dtpToDate.Value.ToString("yyyy-MM-dd");
                    GeneralObjects.paramSelectionValue[2] = Convert.ToString(cmbSupplier.SelectedValue ?? 0);
                    GeneralObjects.paramSelectionValue[3] = Convert.ToString(cmbMaterial.SelectedValue ?? 0);
                    GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
                }
                else if (reportId == 9) //Sales
                {
                    GeneralObjects.paramSelectionValue = new string[3];
                    GeneralObjects.paramSelectionValue[0] = dtpFromDate.Value.ToString("yyyy-MM-dd");
                    GeneralObjects.paramSelectionValue[1] = dtpToDate.Value.ToString("yyyy-MM-dd");
                    GeneralObjects.paramSelectionValue[2] = Convert.ToString(cmbMaterial.SelectedValue ?? 0);
                    GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId), Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), true);
                }
                else if (reportId == 10) // OverDue
                {
                    //GeneralObjects.paramSelectionValue = new string[0];
                    //GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId));
                    GeneralObjects.ReportPreview(Convert.ToInt32(reportId), true);
                }
                else if (reportId == 11) // Pending Payment
                {
                    //GeneralObjects.paramSelectionValue = new string[0];
                    //GeneralObjects.ReportPreviewWithParam(Convert.ToInt32(reportId));
                    GeneralObjects.ReportPreview(Convert.ToInt32(reportId), true);
                }
                else
                {
                    GeneralObjects.ReportPreview(reportId, true);
                }

                _objReport = new PreviewReport(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
                _reportName = GeneralObjects._reportName;
                _viewName = GeneralObjects._viewName;
                _paramName = GeneralObjects._paramName;
                _paramValue = GeneralObjects._paramValue;
                _paramNameIn = GeneralObjects._paramNameIn;

                if (_paramNameIn != null)
                {
                    if (_subReportFlag == false)
                    {
                        showLocalReport(_reportName, _viewName, _paramNameIn, _paramValue);
                    }
                    else
                    {
                        //showLocalReportWithSubReport(_reportName, _viewName, _paramName, _paramValue);
                    }
                }
                else
                {
                    if (_subReportFlag == false && _paramName == null)
                    {
                        showLocalReport();
                    }
                    else if (_subReportFlag == false && _paramName != null)
                    {
                        showLocalReport(_reportName, _viewName, _paramName, _paramValue);
                    }
                    else
                    {
                        //showLocalReportWithSubReport(_reportName, _viewName, _paramName, _paramValue);
                    }
                }

            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Report Viewer : Load");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
            this.rptReportViewer.RefreshReport();
            _reportName = "";
            _viewName = "";
            GeneralObjects._paramName = null;
            GeneralObjects._paramValue = null;
        }

        public void showLocalReport(string rptName, string viewName, string paramName, string[] paramValue)
        {
            try
            {
                rptReportViewer.ProcessingMode = ProcessingMode.Local;
                //rptReportViewer.LocalReport.ReportPath = @"C:\Program Files (x86)\BeSpokePOS\Bin\Reports\" + rptName + ".rdl";
                rptReportViewer.LocalReport.ReportPath = _reportPath + rptName + ".rdl";


                DataSet ds = new DataSet();

                if (paramName != null)
                {
                    if (paramValue.Length > 0)
                    {
                        ds = _objReport.GetReportSQLQueryWhereIn(viewName, paramName, paramValue);
                    }
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                rptReportViewer.LocalReport.DataSources.Clear();
                rptReportViewer.LocalReport.DataSources.Add(rds);
                rptReportViewer.LocalReport.Refresh();
                rptReportViewer.RefreshReport();
                rptReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                rptReportViewer.ZoomMode = ZoomMode.PageWidth;
                //rptViewer1.ZoomPercent = 75;

                if (ds.Tables[0].Rows.Count == 0)
                {
                    rptReportViewer.Visible = false;
                    MessageBox.Show("No Records found", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rptReportViewer.Visible = true;
                }
                // Refresh the report  
                rptReportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Report Viewer : showLocalReport With Parameters");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        public void showLocalReport(string rptName, string viewName, string[] paramName, string[] paramValue)
        {
            try
            {
                rptReportViewer.ProcessingMode = ProcessingMode.Local;
                rptReportViewer.LocalReport.ReportPath = _reportPath + rptName + ".rdl";

                DataSet ds = new DataSet();

                if (paramName != null)
                {
                    if (paramValue.Length > 0)
                    {
                        ds = _objReport.GetReportSQLStoreProc(viewName, paramName, paramValue);
                    }
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                rptReportViewer.LocalReport.DataSources.Clear();
                rptReportViewer.LocalReport.DataSources.Add(rds);
                rptReportViewer.LocalReport.Refresh();
                rptReportViewer.RefreshReport();
                rptReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                rptReportViewer.ZoomMode = ZoomMode.PageWidth;
                //rptViewer1.ZoomPercent = 75;

                if (ds.Tables[0].Rows.Count == 0)
                {
                    rptReportViewer.Visible = false;
                    MessageBox.Show("No Records found", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rptReportViewer.Visible = true;
                }
                // Refresh the report  
                rptReportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Report Viewer : showLocalReport With Parameters");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        public void showLocalReport()
        {
            try
            {
                rptReportViewer.ProcessingMode = ProcessingMode.Local;
                rptReportViewer.LocalReport.ReportPath = _reportPath + _reportName + ".rdl";
                if (_paramName != null)
                {
                    if (_paramName.Length > 0)
                    {
                        ReportParameter rptParam = new ReportParameter();
                        for (int i = 0; i < _paramName.Length; i++)
                        {
                            rptParam.Name = _paramName[i];
                            rptParam.Values.Add(_paramValue[i]);

                            rptReportViewer.LocalReport.SetParameters(new ReportParameter[] { rptParam });
                        }
                    }
                }

                DataSet ds = new DataSet();

                if (_paramName != null)
                {
                    if (_paramName.Length > 0)
                    {
                        ds = _objReport.GetReportSQLQueryWhere(_viewName, _paramName, _paramValue);
                    }
                }
                else
                {
                    //ds = _objReport.GetReportSQLQuery(_viewName);
                    ds = _objReport.GetReportData(_viewName);
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                rptReportViewer.LocalReport.DataSources.Clear();
                rptReportViewer.LocalReport.DataSources.Add(rds);
                rptReportViewer.LocalReport.Refresh();
                rptReportViewer.RefreshReport();
                rptReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                rptReportViewer.ZoomMode = ZoomMode.PageWidth;
                //rptViewer1.ZoomPercent = 75;

                if (ds.Tables[0].Rows.Count == 0)
                {
                    rptReportViewer.Visible = false;
                    MessageBox.Show("No Records found", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rptReportViewer.Visible = true;
                }
                // Refresh the report  
                rptReportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Report Viewer : showLocalReport");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }

        private void cmbReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportId = Convert.ToInt32(cmbReportName.SelectedValue);
            cmbMaterial.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            cmbArticleNo.SelectedIndex = -1;

            if (reportId == 1)
            {
                cmbMaterial.Enabled = true;
                cmbArticleNo.Enabled = true;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                cmbSupplier.Enabled = false;
                txtSalesThreshold.Enabled = false;
                txtDays.Enabled = false;
            }
            else if (reportId == 2)
            {
                cmbMaterial.Enabled = true;
                cmbArticleNo.Enabled = true;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                cmbSupplier.Enabled = false;
                txtSalesThreshold.Enabled = false;
                txtDays.Enabled = false;
            }
            else if (reportId == 4)
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
                cmbMaterial.Enabled = false;
                cmbArticleNo.Enabled = false;
                cmbSupplier.Enabled = false;
                txtSalesThreshold.Enabled = false;
                txtDays.Enabled = false;
            }
            else if (reportId == 5)
            {
                txtSalesThreshold.Enabled = true;
                txtDays.Enabled = true;
                txtSalesThreshold.Text = "10";
                txtDays.Text = "30";
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                cmbMaterial.Enabled = false;
                cmbArticleNo.Enabled = false;
                cmbSupplier.Enabled = false;
            }
            else if (reportId == 7)
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
                cmbMaterial.Enabled = false;
                cmbArticleNo.Enabled = false;
                cmbSupplier.Enabled = false;
                txtSalesThreshold.Enabled = false;
                txtDays.Enabled = false;
            }
            else if (reportId == 8)
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
                cmbSupplier.Enabled = true;
                cmbMaterial.Enabled = true;
                txtSalesThreshold.Enabled = false;
                txtDays.Enabled = false;
                cmbArticleNo.Enabled = false;
            }
            else if (reportId == 9)
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
                cmbMaterial.Enabled = true;
                txtSalesThreshold.Enabled = false;
                txtDays.Enabled = false;
                cmbArticleNo.Enabled = false;
                cmbSupplier.Enabled = false;
            }
            else
            {
                cmbMaterial.Enabled = false;
                cmbArticleNo.Enabled = false;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                cmbSupplier.Enabled = false;
                txtSalesThreshold.Enabled = false;
                txtDays.Enabled = false;
            }
        }
    }
}

