using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class GeneralDB
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public GeneralDB(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~GeneralDB()
        {
            if (_objDataAccess != null)
                _objDataAccess = null;

            if (_objErrorLogger != null)
                _objErrorLogger = null;

            if (_strSQL != null)
                _strSQL = null;
        }
        #endregion

        #region "Public Methods"
        public DataTable GetListIndexWithMessageText(int listId)
        {
            DataTable objDataTable = null;
            try
            {
                objDataTable = _objDataAccess.GetDataTable("Select lv.ListIndex,mt.MessageText from Messages mt Inner Join ListValues lv on lv.MessageId = mt.Id where lv.IsActive = 1 AND lv.ListId = " + listId + " Order by lv.ListIndex");
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("GeneralDB : GetListIndexWithMessageText");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        //Common PROCEDURE For Delete Record for any table
        public int DeleteRecord(string tableName, int id, long updatedby)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[3] { "@TableName", "@Id", "@UpdatedBy" };
                object[] values = new object[3] { tableName, id, updatedby };

                _strSQL = "DeleteRecord";
                ReturnValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("GeneralSettings : DeleteRecord");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return ReturnValue;
        }

        public bool SetActiveInActiveStatus(string TableName, int Id, int StatusFlag, int UpdatedBy)
        {
            bool retFlag = false;
            try
            {
                string _strSql = "SetActiveInActive";
                string[] param = new string[4] { "@TableName", "@Id", "@StatusFlag", "@UpdatedBy" };
                object[] value = new object[4] { TableName, Id, StatusFlag, UpdatedBy };
                //retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(_strSql, param, value, System.Data.CommandType.StoredProcedure));
                retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(_strSql, param, value, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile(ex.ToString());
            }
            return retFlag;
        }

        public DataTable GetAuditRecords(DateTime StartDate, DateTime EndDate)
        {
            DataTable _objDt = new DataTable();
            try
            {
                string[] param = new string[2] { "@StartDate", "@EndDate" };
                object[] values = new object[2] { StartDate, EndDate };
                _strSQL = "GetAuditRecords";

                _objDt = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("GeneralSettings : DeleteRecord");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return _objDt;
        }
        #endregion
    }
}
