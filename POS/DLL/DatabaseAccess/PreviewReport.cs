using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class PreviewReport
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public PreviewReport(ErrorHandler errorLogger, DataAccess dataAccess)
        {
            try
            {
                _objDataAccess = dataAccess;
                _objErrorLogger = errorLogger;
            }
            catch (Exception ex)
            {
                errorLogger.WritetoLogFile(ex);
            }
        }

        ~PreviewReport()
        {
            if (_objDataAccess != null)
                _objDataAccess = null;

            if (_objErrorLogger != null)
                _objErrorLogger = null;

            if (_strSQL != null)
                _strSQL = null;
        }
        #endregion

        #region "Public Method"
        public DataTable GetReportsConfig(int ReportType, int ReportCategory)
        {
            DataTable objDataTable = null;
            try
            {
                string[] paramArray = new string[2];
                paramArray[0] = "@ReportType";
                paramArray[1] = "@ReportCategory";

                object[] values = new object[2];
                values[0] = ReportType;
                values[1] = ReportCategory;

                _strSQL = "GetReportsConfig";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, paramArray, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile(string.Format("Message:{0}, Exception:{1}", ex.Message, ex));
                return objDataTable;
            }
            return objDataTable;
        }

        public DataTable GetDataForPopulateTreeView(int child)
        {
            DataTable objDataTable = null;
            try
            {
                _strSQL = "SELECT Id, ReportName[Name] FROM ReportsConfig Where ReportCategory = " + child;

                objDataTable = _objDataAccess.GetDataTable(_strSQL);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetDataForPopulateTreeView");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public int GetReportId(string reportName)
        {
            int reportId = 0;
            try
            {
                _strSQL = "SELECT Id FROM ReportsConfig where ReportName = '" + reportName + "'";
                reportId = Convert.ToInt32(_objDataAccess.ExecuteScalar(_strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetReportId");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return reportId;
        }

        public string GetReportFileName(int reportId)
        {
            string reportName = "";
            try
            {
                _strSQL = "SELECT RPTFileName FROM ReportsConfig Where Id = " + reportId;
                reportName = Convert.ToString(_objDataAccess.ExecuteScalar(_strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetReportName");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return reportName;
        }

        public string GetSPName(int reportId)
        {
            string viewName = "";
            try
            {
                _strSQL = "SELECT SPName FROM ReportsConfig Where Id = " + reportId;
                viewName = Convert.ToString(_objDataAccess.ExecuteScalar(_strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetViewName");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return viewName;
        }

        public string GetParameterName(int reportId)
        {
            string paramName = "";
            try
            {
                _strSQL = "SELECT ParameterName FROM ReportsConfig Where Id = " + reportId;
                paramName = Convert.ToString(_objDataAccess.ExecuteScalar(_strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetParameterName");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return paramName;
        }

        public DataSet GetReportSQLQueryWhereIn(string SPName, string conditionFieldName, string[] conditionFieldValue)
        {
            DataSet objDataSet = null;
            try
            {
                _strSQL = "SELECT * FROM " + SPName;
                string condMsg = "";

                if (conditionFieldName != null && conditionFieldName.Length > 0)
                {
                    condMsg = " WHERE " + conditionFieldName + " IN(";
                    for (int i = 0; i < conditionFieldValue.Length; i++)
                    {
                        condMsg = condMsg + "'" + conditionFieldValue[i] + "',";
                    }
                    condMsg = condMsg + ")";
                    condMsg = condMsg.Remove(condMsg.Length - 2, 1);
                }

                _strSQL += condMsg;
                objDataSet = _objDataAccess.GetDataSet(_strSQL);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetReportSQLQueryWhere");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataSet;
        }

        public DataSet GetReportSQLStoreProc(string storeproc, string[] conditionFieldName, string[] conditionFieldValue)
        {
            DataSet objDataSet = null;
            try
            {
                //strSQL = "EXEC " + storeproc;
                objDataSet = _objDataAccess.GetDataSet(storeproc, conditionFieldName, conditionFieldValue, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetReportSQLStoreProc");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataSet;
        }

        public DataSet GetReportSQLQueryWhere(string viewName, string[] conditionFieldName, string[] conditionFieldValue)
        {
            DataSet objDataSet = null;
            try
            {
                _strSQL = "SELECT * FROM " + viewName;
                string condMsg = "";

                if (conditionFieldName != null && conditionFieldName.Length > 0)
                {
                    condMsg = " WHERE ";
                    for (int i = 0; i < conditionFieldName.Length; i++)
                    {
                        condMsg += conditionFieldName[i];
                        condMsg += " = '";
                        condMsg += conditionFieldValue[i];
                        condMsg += "' AND ";
                    }

                    condMsg = condMsg.Remove(condMsg.Length - 5, 5);
                }

                _strSQL += condMsg;
                objDataSet = _objDataAccess.GetDataSet(_strSQL);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetReportSQLQueryWhere");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataSet;
        }

        public DataSet GetReportSQLQuery(string SpName)
        {
            DataSet objDataSet = null;
            try
            {
                _strSQL = "SELECT * FROM " + SpName;
                objDataSet = _objDataAccess.GetDataSet(_strSQL);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetReportSQLQuery");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataSet;
        }

        public DataSet GetReportData(string spName)
        {
            DataSet objDataSet = null;
            try
            {
                _strSQL = spName;
                objDataSet = _objDataAccess.GetDataSet(_strSQL, null, null, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetReportData");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataSet;
        }

        public string GetParameterLabel(int reportId)
        {
            string paramName = "";
            try
            {
                _strSQL = "SELECT ParameterLabel FROM ReportsConfig Where Id = " + reportId;
                paramName = Convert.ToString(_objDataAccess.ExecuteScalar(_strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetParameterLabel");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return paramName;
        }

        public string GetDataSetName(int reportId)
        {
            string paramName = "";
            try
            {
                _strSQL = "SELECT DataSetName FROM ReportsConfig Where Id = " + reportId;
                paramName = Convert.ToString(_objDataAccess.ExecuteScalar(_strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Reports : GetDataSetName");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return paramName;
        }
        #endregion
    }
}
