using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class SystemSettings
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public SystemSettings(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~SystemSettings()
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
        public DataTable GetComputerList(int computerId)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[1] { "@ComputerId"};
                object[] values = new object[1] { computerId};

                _strSQL = "GetComputerList";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("SystemSettings : GetComputerList");
                _objErrorLogger.WritetoLogFile(ex);
            }

            return objDataTable;
        }

        public int UpdateComputerList(int id, string invoicePrinter, string barcodePrinter, string systemName, int updatedBy)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[5];
                param[0] = "@Id";
                param[1] = "@InvoicePrinter";
                param[2] = "@BarcodePrinter";
                param[3] = "@SystemName";
                param[4] = "@UpdatedBy";

                object[] values = new object[5];
                values[0] = id;
                values[1] = invoicePrinter;
                values[2] = barcodePrinter;
                values[3] = systemName;
                values[4] = updatedBy;

                _strSQL = "UpdateComputerList";
                ReturnValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }

            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("SystemSettings : UpdateComputerList");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return ReturnValue;
        }

        public bool SetActiveInActiveComputerList(string TableName, int Id, int StatusFlag, int UpdatedBy)
        {
            bool retFlag = false;
            try
            {
                string _strSql = "SetActiveInActiveComputerList";
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
        #endregion
    }
}
