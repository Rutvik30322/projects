using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class ItemsGroup
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public ItemsGroup(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~ItemsGroup()
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
        public DataTable GetItemGroup(int itemGroupId, int isActive)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[2] { "@ItemGroupId", "@IsActive" };
                object[] values = new object[2] { itemGroupId, isActive };
                _strSQL = "GetItemGroup";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("ItemsGroup : GetItemGroup");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public int SaveItemsGroup(string groupCode, string groupName, decimal minLevel, int updatedBy, string sysName)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[5];
                param[0] = "@GroupCode";
                param[1] = "@GroupName";
                param[2] = "@MinLevel";
                param[3] = "@UpdatedBy";
                param[4] = "@SystemName";

                object[] values = new object[5];
                values[0] = groupCode;
                values[1] = groupName;
                values[2] = minLevel;
                values[3] = updatedBy;
                values[4] = sysName;

                _strSQL = "SaveItemGroup";
                ReturnValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("ItemGroup : SaveItemGroup");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return ReturnValue;
        }

        public int UpdateItemsGroup(int itemGroupId, string groupCode, string groupName, decimal minLevel, int updatedBy, string sysName)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[6];
                param[0] = "@ItemGroupId";
                param[1] = "@GroupCode";
                param[2] = "@GroupName";
                param[3] = "@MinLevel";
                param[4] = "@UpdatedBy";
                param[5] = "@SystemName";

                object[] values = new object[6];
                values[0] = itemGroupId;
                values[1] = groupCode;
                values[2] = groupName;
                values[3] = minLevel;
                values[4] = updatedBy;
                values[5] = sysName;

                _strSQL = "UpdateItemGroup";
                ReturnValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("ItemGroup : UpdateItemGroup");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return ReturnValue;
        }

        public int CheckItemGroupStock(int ItemGroupId)
        {
            int retValue = -1;
            try
            {
                string[] param = new string[1] { "@ItemGroupId" };
                object[] values = new object[1] { ItemGroupId };

                _strSQL = "CheckItemGroupStock";
                retValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("ItemGroup : CheckItemGroupStock");
                _objErrorLogger.WritetoLogFile(ex);
            }

            return retValue;
        }
        #endregion
    }
}
