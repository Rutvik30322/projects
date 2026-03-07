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
    public class Sale
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public Sale(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~Sale()
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
        public string GetNewSalesNo()
        {
            string purchaseNo = "";
            try
            {
                _strSQL = "GenSalesNo";
                purchaseNo = Convert.ToString(_objDataAccess.ExecuteScalar(_strSQL, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : GetNewSalesNo");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return purchaseNo;
        }

        public DataTable GetItemByBarcode(string barcode, string stationName)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[2] { "@Barcode", "@StationName" };
                object[] values = new object[2] { barcode, stationName };
                _strSQL = "GetItemByBarcode";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : GetItemByBarcode");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public DataTable SaveSales(string salesNo, string salesDate, decimal grossAmount, int discType, decimal discount, decimal netAmount, int paymentMode, string custName, string mobileNumber, int updatedBy, string systemName)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[11];
                param[0] = "@SalesNo";
                param[1] = "@SalesDate";
                param[2] = "@GrossAmount";
                param[3] = "@DiscType";
                param[4] = "@Discount";
                param[5] = "@NetAmount";
                param[6] = "@PaymentBy";
                param[7] = "@CustomerName";
                param[8] = "@MobileNumber";
                param[9] = "@UpdatedBy";
                param[10] = "@SystemName";

                object[] values = new object[11];
                values[0] = salesNo;
                values[1] = salesDate;
                values[2] = grossAmount;
                values[3] = discType;
                values[4] = discount;
                values[5] = netAmount;
                values[6] = paymentMode;
                values[7] = custName;
                values[8] = mobileNumber;
                values[9] = updatedBy;
                values[10] = systemName;

                _strSQL = "SaveSales";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : SaveSales");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public bool SaveSalesItem(long salesId, long inventoryId, decimal grossRate, string hsnCode, decimal qty, int updatedBy)
        {
            bool retFlag = false;
            try
            {
                string[] param = new string[6];
                param[0] = "@SalesId";
                param[1] = "@InventoryId";
                param[2] = "@GrossRate";
                param[3] = "@HSNCode";
                param[4] = "@Quantity";
                param[5] = "@UpdatedBy";

                object[] values = new object[6];
                values[0] = salesId;
                values[1] = inventoryId;
                values[2] = grossRate;
                values[3] = hsnCode;
                values[4] = qty;
                values[5] = updatedBy;

                _strSQL = "SaveSalesItem";
                retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(_strSQL, param, values, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : SaveSalesItem");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        public DataTable GetInvReportData(long salesId)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[1] { "@SalesId" };
                object[] values = new object[1] { salesId };
                _strSQL = "rptInvoice";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : InvoiceReportData");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public string GetCustomerName(string mobileNumber)
        {
            string custName = "";
            try
            {
                string[] param = new string[1] { "@MobileNumber" };
                object[] values = new object[1] { mobileNumber };
                _strSQL = "GetCustomerName";
                custName = Convert.ToString(_objDataAccess.ExecuteScalar(_strSQL, param, values, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : GetCustomerName");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return custName;
        }

        public long GetSalesId(string salesNo)
        {
            long salesId = 0;
            try
            {
                string[] param = new string[1] { "@SalesNo" };
                object[] values = new object[1] { salesNo };
                _strSQL = "GetSalesId";
                salesId = Convert.ToInt64(_objDataAccess.ExecuteScalar(_strSQL, param, values, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : GetSalesId");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return salesId;
        }

        public DataSet GetInvoiceDetails(string invoiceNo)
        {
            DataSet objDataSet = null;
            try
            {
                string[] param = new string[1] { "@SalesNo" };
                object[] values = new object[1] { invoiceNo };
                _strSQL = "GetInvoiceData"; 
                objDataSet = _objDataAccess.GetDataSet(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : GetInvoiceDetails");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataSet;
        }

        public DataTable GetSalesView(int itemGroupId, string fromDate, string toDate, string mobileNo, string custName)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[5] { "@ItemGroupId", "@FromDate", "@ToDate", "@MobileNo", "@CustName" };
                object[] values = new object[5] { itemGroupId, fromDate, toDate, mobileNo, custName };
                _strSQL = "GetSalesView";

                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : GetSalesView");
                _objErrorLogger.WritetoLogFile(ex);
            }

            return objDataTable;
        }

        public DataTable GetSalesViewSummary(int itemGroupId, string fromDate, string toDate, string mobileNo, string custName)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[5] { "@ItemGroupId", "@FromDate", "@ToDate", "@MobileNo", "@CustName" };
                object[] values = new object[5] { itemGroupId, fromDate, toDate, mobileNo, custName };
                _strSQL = "GetSalesViewSummary";

                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : GetSalesViewSummary");
                _objErrorLogger.WritetoLogFile(ex);
            }

            return objDataTable;
        }

        public void SaveScannedItems(long inventoryId, string barcode, string stationName)
        {
            try
            {
                string[] param = new string[3] { "@InventoryId", "@Barcode", "@StationName" };
                object[] values = new object[3] { inventoryId, barcode, stationName };
                _strSQL = "SaveScannedItems";

                _objDataAccess.ExecuteNonQuery(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : SaveScannedItems");
                _objErrorLogger.WritetoLogFile(ex);
            }
        }

        public void DelScannedItems(string stationName, long inventoryId = 0)
        {
            try
            {
                string[] param = new string[2] { "@StationName", "@InventoryId" };
                object[] values = new object[2] { stationName, inventoryId };
                _strSQL = "DelScannedItems";

                _objDataAccess.ExecuteNonQuery(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Sales : DelScannedItems");
                _objErrorLogger.WritetoLogFile(ex);
            }
        }
        #endregion
    }
}
