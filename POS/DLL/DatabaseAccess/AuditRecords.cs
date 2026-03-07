using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class AuditRecords
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public AuditRecords(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~AuditRecords()
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
        public void SetAuditRecords(string auditText, string userName, string screenName, string systemName)
        {
            try
            {
                string[] param = new string[4];
                param[0] = "@AuditText";
                param[1] = "@UserName";
                param[2] = "@ScreenName";
                param[3] = "@SystemId";

                object[] values = new object[4];
                values[0] = auditText;
                values[1] = userName;
                values[2] = screenName;
                values[3] = systemName;

                _strSQL = "SetAuditRecords";
                _objDataAccess.ExecuteNonQuery(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("AuditRecords : SetAuditRecords");
                _objErrorLogger.WritetoLogFile(ex);
            }
        }
        #endregion
    }
}
