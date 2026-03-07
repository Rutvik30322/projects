using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class UOM
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public UOM(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~UOM()
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
        public DataTable GetUOM(int uomId, int isActive)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[2] { "@UOMId", "@IsActive" };
                object[] values = new object[2] { uomId, isActive };
                _strSQL = "GetUOM";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("UOM : GetUOM");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public int SaveUOM(string unitCode, int uomType, int updatedBy, string systemName)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[4];
                param[0] = "@UnitCode";
                param[1] = "@UOMType";
                param[2] = "@UpdatedBy";
                param[3] = "@SystemName";

                object[] values = new object[4];
                values[0] = unitCode;
                values[1] = uomType;
                values[2] = updatedBy;
                values[3] = systemName;

                _strSQL = "SaveUOM";
                ReturnValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("UOM : SaveUOM");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return ReturnValue;
        }

        public int UpdateUOM(int id, string unitCode, int unitType, int updatedBy, string systemName)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[5];
                param[0] = "@Id";
                param[1] = "@UnitCode";
                param[2] = "@UOMType";
                param[3] = "@UpdatedBy";
                param[4] = "@SystemName";

                object[] values = new object[5];
                values[0] = id;
                values[1] = unitCode;
                values[2] = unitType;
                values[3] = updatedBy;
                values[4] = systemName;

                _strSQL = "UpdateUOM";
                ReturnValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("UOM : SaveUOM");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return ReturnValue;
        }
        #endregion
    }
}
