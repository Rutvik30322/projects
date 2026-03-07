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
    public class Inventory
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public Inventory(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~Inventory()
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
        public DataTable GetInventory(int inventoryId)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[1] { "@InventoryId" };
                object[] values = new object[1] { inventoryId };
                _strSQL = "GetInventory";

                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Inventory : GetInventory");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public DataTable GetSize()
        {
            DataTable objDataTable = null;
            try
            {
                _strSQL = "GetSize";

                objDataTable = _objDataAccess.GetDataTable(_strSQL, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Inventory : GetSize");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public DataTable GetArticleNo()
        {
            DataTable _objDt = null;
            try
            {
                _strSQL = "GetArticleNumber";
                _objDt = _objDataAccess.GetDataTable(_strSQL, CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Inventory : GetArticleNo");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return _objDt;
        }
        public DataTable GetSupplierWiseInventory(int SupplierId, int ItemGroupId, string ArticleNo ,DateTime FromDate, DateTime ToDate)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[5] { "@SupplierId", "@ItemGroupId","@ArticleNo", "@FromDate", "@ToDate" };
                object[] values = new object[5] { SupplierId, ItemGroupId, ArticleNo ,FromDate, ToDate };

                _strSQL = "GetSupplierWiseInventory";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Inventory : GetSupplierWiseInventory");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public DataTable GetNonMovingInventory(int Days)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[1] { "@Days" };
                object[] values = new object[1] { Days };
                _strSQL = "GetNonMovingInventory";

                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Inventory : GetNonMovingInventory");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public DataTable GetInventoryStock(int itemGroupId, int supplierId, decimal salePrice, string size, string color, string articleNo)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[6] { "@ItemGroupId", "@SupplierId", "@SalePrice", "@Size", "@Color", "@ArticleNo" };
                object[] values = new object[6] { itemGroupId, supplierId, salePrice, size, color, articleNo };

                _strSQL = "GetInventoryDetails";

                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Inventory : GetInventoryStock");
                _objErrorLogger.WritetoLogFile(ex);
            }

            return objDataTable;
        }

        public int UpdateSalePrice(int invid, double salePrice, int updatedBy, string systemName)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[4];
                param[0] = "@InvId";
                param[1] = "@SalePrice";
                param[2] = "@UpdatedBy";
                param[3] = "@SystemName";

                object[] values = new object[4];
                values[0] = invid;
                values[1] = salePrice;
                values[2] = updatedBy;
                values[3] = systemName;

                _strSQL = "UpdateSalePrice";
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
