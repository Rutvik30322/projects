using System;
using NDatabaseHandler;
using NErrorHandler;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using NDatabaseAccess;
using System.Data;
using static NConstant.Constant;

namespace POSClient
{
    public static class GeneralObjects
    {
        public static ErrorHandler ErrLogger;
        public static DataAccess DbHelper;

        public static string FirstName;
        public static string LastName;
        public static string UserName;
        public static int CurrentUserId;
        public static int CurrentRoleId;
        public static String CurrentRoleName;
        public static int CurrentRoleType;
        public static string LoginTime;
        public static string stationName;

        public static bool transactionDataUpdate = false;
        public static bool SetMenuAndSubMenu = false;

        public static string msgToDisplay = "";
        public static string[] selectData;
        public static bool selectDataFlag = false;
        public static QueryDataIndex QueryIndex;

        //For Report
        public static string[] paramList;
        public static string[] rptParamName;
        public static string[] rptParamValue;
        public static string[] paramSelectionValue;

        public static string _reportName = "";
        public static string _viewName = "";

        public static string[] _paramName;
        public static string[] _paramValue;
        public static string _paramNameIn;
        public static int reportId = 0;
        public static bool _subReportFlag = false;

        //For Navigate One Form to Another from MDIMain at that doesn't check validation.
        public static bool isNavigating = false;

        public static string DateAsPerSQL(DateTime date)
        {
            string modifiedDate;
            if (date == null)
            {
                modifiedDate = "";
            }
            else
            {
                modifiedDate = date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            return modifiedDate;
        }

        public static bool validateDecimal(object sender, KeyPressEventArgs e)
        {
            bool retFlag = true;
            try
            {
                // allows 0-9, backspace, and decimal
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    retFlag = false;
                }

                // checks to make sure only 1 decimal is allowed
                if (e.KeyChar == 46)
                {
                    if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                        e.Handled = true;
                    if (e.Handled == true)
                        retFlag = false;
                }
            }
            catch (Exception ex)
            {
                ErrLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        public static void ReportPreviewWithParam(int reportId, DateTime fromDate, DateTime toDate, bool _reportScreen = false)
        {
            PreviewReport objReports = null;
            try
            {
                objReports = new PreviewReport(ErrLogger, DbHelper);
                string rptFileName = "";
                string viewName = "";
                string paramName = "";

                rptFileName = objReports.GetReportFileName(reportId);
                viewName = objReports.GetSPName(reportId);
                paramName = objReports.GetParameterName(reportId);
                string[] strArr = null;
                char[] splitchar = { '^' };
                strArr = paramName.Split(splitchar);
                if (strArr.Length > 1)
                {
                    rptParamName = new string[strArr.Length];
                    for (int i = 0; i <= strArr.Length - 1; i++)
                    {
                        rptParamName[i] = strArr[i];
                    }
                    if (_reportScreen == true)
                    {
                        ReportViewer(rptFileName, viewName, rptParamName, paramSelectionValue);
                    }
                    else
                    {
                        //frmReportViewer reportViewerForm = new frmReportViewer(rptFileName, viewName, rptParamName, paramSelectionValue);
                        //reportViewerForm.Show();
                    }
                }
                else
                {
                    if (_reportScreen == true)
                    {
                        ReportViewer(rptFileName, viewName, paramName, paramSelectionValue);
                    }
                    else
                    {
                        //frmReportViewer reportViewerForm = new frmReportViewer(rptFileName, viewName, paramName, paramSelectionValue);
                        //reportViewerForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrLogger.WritetoLogFile("General Objects : DetailedReportPreview");
                ErrLogger.WritetoLogFile(ex);
            }
            finally
            {
                if (objReports != null)
                    objReports = null;
            }
        }

        public static void ReportViewer(string rptName, string viewName, string[] paramName, string[] paramValue, bool subReport = false)
        {
            _reportName = rptName;
            _viewName = viewName;
            
            _paramName = new string[paramName.Length];
            _paramValue = new string[paramValue.Length];

            for (int i = 0; i < paramName.Length; i++)
            {
                _paramName[i] = paramName[i];
            }

            for (int i = 0; i < paramValue.Length; i++)
            {
                _paramValue[i] = paramValue[i];
            }
            _subReportFlag = subReport;
        }

        public static void ReportViewer(string rptName, string viewName, string paramName, string[] paramValue)
        {
            _reportName = rptName;
            _viewName = viewName;
            _paramNameIn = paramName;
            _paramValue = new string[paramValue.Length];

            for (int i = 0; i < paramValue.Length; i++)
            {
                _paramValue[i] = paramValue[i];
            }
        }

        public static void ReportViewer(string rptName, string viewName)
        {
            _reportName = rptName;
            _viewName = viewName;
        }


        public static void ReportPreview(int reportId, bool _reportScreen = false)
        {
            PreviewReport objReports = null;
            try
            {
                objReports = new PreviewReport(ErrLogger, DbHelper);
                string rptFileName = "";
                string viewName = "";

                rptFileName = objReports.GetReportFileName(reportId);
                viewName = objReports.GetSPName(reportId);
                if (_reportScreen == true)
                {
                    ReportViewer(rptFileName, viewName);
                }
                else
                {
                    //frmReportViewer reportViewerForm = new frmReportViewer(rptFileName, viewName);
                    //reportViewerForm.Show();
                }
            }
            catch (Exception ex)
            {
                ErrLogger.WritetoLogFile("General Objects : SummaryReportPreview");
                ErrLogger.WritetoLogFile(ex);
            }
            finally
            {
                if (objReports != null)
                    objReports = null;
            }
        }
    }
}
