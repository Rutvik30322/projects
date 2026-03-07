using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class Suppliers
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public Suppliers(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~Suppliers()
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
        public DataTable GetSupplier(int supplierId, int isActive)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[2] { "@SupplierId", "@IsActive" };
                object[] values = new object[2] { supplierId, isActive };
                _strSQL = "GetSupplier";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Suppliers : GetSupplier");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        //public DataTable GetSupplierList(int supplierId, int isActive)
        //{
        //    DataTable objDataTable = null;
        //    try
        //    {
        //        string[] param = new string[2] { "@SupplierId", "@IsActive" };
        //        object[] values = new object[2] { supplierId, isActive };
        //        _strSQL = "GetSupplier";
        //        objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);

        //        if (objDataTable != null)
        //        {
        //            DataRow newRow = objDataTable.NewRow();
        //            newRow["Id"] = 0;
        //            newRow["SupplierName"] = "ALL";
        //            objDataTable.Rows.InsertAt(newRow, 0); // Add at the top of the table
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _objErrorLogger.WritetoLogFile("Suppliers : GetSupplier");
        //        _objErrorLogger.WritetoLogFile(ex);
        //    }
        //    return objDataTable;
        //}

        public int SaveSuppliers(string SupplierName,
                                 string Address1, string Address2, string City, string State, string Country, string Pincode,
                                 string GSTNo, string PANNo,
                                 string CntPersonName, string CntPersonPosition, string CntPersonPhNo, string CntPersonEmail, int UpdatedBy, string sysName)
        {
            int retValue = -1;
            try
            {
                string[] param = new string[15];

                param[0] = "@SupplierName";
                param[1] = "@Address1";
                param[2] = "@Address2";
                param[3] = "@City";
                param[4] = "@State";
                param[5] = "@Country";
                param[6] = "@PinCode";
                param[7] = "@GSTNumber";
                param[8] = "@PanNumber";
                param[9] = "@ContactPersonName";
                param[10] = "@ContactPersonPosition";
                param[11] = "@ContactPersonPhone";
                param[12] = "@ContactPersonEmail";
                param[13] = "@UpdatedBy";
                param[14] = "@SystemName";

                object[] values = new object[15];
                values[0] = SupplierName;
                values[1] = Address1;
                values[2] = Address2;
                values[3] = City;
                values[4] = State;
                values[5] = Country;
                values[6] = Pincode;
                values[7] = GSTNo;
                values[8] = PANNo;
                values[9] = CntPersonName;
                values[10] = CntPersonPosition;
                values[11] = CntPersonPhNo;
                values[12] = CntPersonEmail;
                values[13] = UpdatedBy;
                values[14] = sysName;

                _strSQL = "SaveSupplier";
                retValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Supplier : SaveSupplier");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return retValue;
        }

        public int UpdateSuppliers(int SupplierId, string SupplierName,
                               string Address1, string Address2, string City, string State, string Country, string Pincode,
                               string GSTNo, string PANNo,
                               string CntPersonName, string CntPersonPosition, string CntPersonPhNo, string CntPersonEmail, int UpdatedBy, string sysName)
        {
            int retValue = -1;
            try
            {
                string[] param = new string[16];
                param[0] = "@SupplierId";
                param[1] = "@SupplierName";
                param[2] = "@Address1";
                param[3] = "@Address2";
                param[4] = "@City";
                param[5] = "@State";
                param[6] = "@Country";
                param[7] = "@PinCode";
                param[8] = "@GSTNumber";
                param[9] = "@PanNumber";
                param[10] = "@ContactPersonName";
                param[11] = "@ContactPersonPosition";
                param[12] = "@ContactPersonPhone";
                param[13] = "@ContactPersonEmail";
                param[14] = "@UpdatedBy";
                param[15] = "@SystemName";

                object[] values = new object[16];
                values[0] = SupplierId;
                values[1] = SupplierName;
                values[2] = Address1;
                values[3] = Address2;
                values[4] = City;
                values[5] = State;
                values[6] = Country;
                values[7] = Pincode;
                values[8] = GSTNo;
                values[9] = PANNo;
                values[10] = CntPersonName;
                values[11] = CntPersonPosition;
                values[12] = CntPersonPhNo;
                values[13] = CntPersonEmail;
                values[14] = UpdatedBy;
                values[15] = sysName;

                _strSQL = "UpdateSupplier";
                retValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Supplier : SaveSupplier");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return retValue;
        }
        #endregion
    }
}
