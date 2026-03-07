using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class Purchases
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public Purchases(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~Purchases()
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
        public string GetNewPurchaseNo()
        {
            string purchaseNo = "";
            try
            {
                _strSQL = "GenPurchaseNo";
                purchaseNo = Convert.ToString(_objDataAccess.ExecuteScalar(_strSQL, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Purchases : GetNewPurchaseNo");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return purchaseNo;
        }

        public DataTable SavePurchase(string purchaseNo, string supplierName, string gstNo, string invoiceNo, string invoiceDate, string remarks, decimal grossAmount, decimal totalDiscount, decimal gstAmount, decimal netAmount, string paymentDueDate, int updatedBy, string systemName, string city, string state)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[15];
                param[0] = "@PurchaseNo";
                param[1] = "@SupplierName";
                param[2] = "@GSTNo";
                param[3] = "@InvoiceNo";
                param[4] = "@InvoiceDate";
                param[5] = "@Remarks";
                param[6] = "@GrossAmount";
                param[7] = "@TotalDiscount";
                param[8] = "@GSTAmount";
                param[9] = "@NetAmount";
                param[10] = "@PaymentDueDate";
                param[11] = "@UpdatedBy";
                param[12] = "@SystemName";
                param[13] = "@City";
                param[14] = "@State";

                object[] values = new object[15];
                values[0] = purchaseNo;
                values[1] = supplierName;
                values[2] = gstNo;
                values[3] = invoiceNo;
                values[4] = invoiceDate;
                values[5] = remarks;
                values[6] = grossAmount;
                values[7] = totalDiscount;
                values[8] = gstAmount;
                values[9] = netAmount;
                values[10] = paymentDueDate;
                values[11] = updatedBy;
                values[12] = systemName;
                values[13] = city;
                values[14] = state;

                _strSQL = "SavePurchase";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Purchases : SavePurchase");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public bool SavePurchaseItem(long purchaseId, int itemGroupId, string articleNo, string classification, string size, string color, decimal qty, string uom, string hsnCode, decimal supplierMRP, decimal rate,
            int discType, decimal discount, decimal netRate, decimal gstRate, int updatedBy)
        {
            bool retFlag = false;
            try
            {
                string[] param = new string[16];
                param[0] = "@PurchaseId";
                param[1] = "@ItemGroupId";
                param[2] = "@ArticleNo";
                param[3] = "@Classification";
                param[4] = "@Size";
                param[5] = "@Color";
                param[6] = "@Quantity";
                param[7] = "@UOM";
                param[8] = "@HSNCode";
                param[9] = "@SupplierMRP";
                param[10] = "@Rate";
                param[11] = "@DiscType";
                param[12] = "@Discount";
                param[13] = "@NetRate";
                param[14] = "@GSTRate";
                param[15] = "@UpdatedBy";

                object[] values = new object[16];
                values[0] = purchaseId;
                values[1] = itemGroupId;
                values[2] = articleNo;
                values[3] = classification;
                values[4] = size;
                values[5] = color;
                values[6] = qty;
                values[7] = uom;
                values[8] = hsnCode;
                values[9] = supplierMRP;
                values[10] = rate;
                values[11] = discType;
                values[12] = discount;
                values[13] = netRate;
                values[14] = gstRate;
                values[15] = updatedBy;

                _strSQL = "SavePurchaseItems";
                retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(_strSQL, param, values, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Purchases : SavePurchaseItem");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        public DataTable GetPurchaseView(string fromDate, string toDate, string searchText)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[3] { "@FromDate", "@ToDate", "@SearchText" };
                object[] values = new object[3] { fromDate, toDate, searchText };
                _strSQL = "GetPurchaseView";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Purchases : GetPurchaseView");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public DataTable GetBarcodeData(long purchaseId)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[1] { "@PurchaseId" };
                object[] values = new object[1] { purchaseId };
                _strSQL = "GetBarcodeData";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Purchases : GetBarcodeData");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public DataTable GetArticleNumber()
        {
            DataTable objDataTable = null;
            try
            {
                _strSQL = "GetArticleNumber";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Purchases : GetArticleNumber");
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

        public DataTable GetDataForPrintPurchaseView(long invId)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[1] { "@InventoryId" };
                object[] values = new object[1] { invId };
                _strSQL = "GetDataForPrintPurchaseView";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Purchases : GetDataForPrintPurchaseView");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        #region"Update Payment Status"
        public DataTable GetPurchaseDataForUpdatePaymentStatus(string fromDate, string toDate, int supplier, int paymentStatus)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[4] { "@FromDate", "@ToDate", "@Supplier", "@PaymentStatus" };
                object[] values = new object[4] { fromDate, toDate, supplier, paymentStatus };

                _strSQL = "GetPurchaseDataForUpdatePaymentStatus";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("ItemsGroup : GetItemGroup");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public int UpdatePaymentStatus(int id, int paymentStatus, int updatedBy, string systemName)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[4];
                param[0] = "@Id";
                param[1] = "@PaymentStatus";
                param[2] = "@UpdatedBy";
                param[3] = "@SystemName";

                object[] values = new object[4];
                values[0] = id;
                values[1] = paymentStatus;
                values[2] = updatedBy;
                values[3] = systemName;

                _strSQL = "UpdatePaymentStatus";
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
        #endregion
    }
}
