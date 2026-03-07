using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;
namespace NDatabaseAccess
{
    public class ServiceThreadTCPConfig
    {
        #region "Private Variable"
        private int id;
        private int serviceThreadId;
        private string iPAddress;
        private int tCPPortAddress;
        private int isActive;
        private string addedBy;
        private DateTime addedDate;
        private string updatedBy;
        private DateTime updatedDate;
        private string strSQL;
        private DataAccess objDataAccess;

        private ErrorHandler objErrorLogger;
        #endregion

        #region "Public Property"
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int ServiceThreadId
        {
            get
            {
                return serviceThreadId;
            }
            set
            {
                serviceThreadId = value;
            }
        }

        public string IPAddress
        {
            get
            {
                return iPAddress;
            }
            set
            {
                iPAddress = value;
            }
        }
        public int TCPPortAddress
        {
            get
            {
                return tCPPortAddress;
            }
            set
            {
                tCPPortAddress = value;
            }
        }
        public int IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
            }
        }

        public string AddedBy
        {
            get
            {
                return addedBy;
            }
            set
            {
                addedBy = value;
            }
        }

        public DateTime AddedDate
        {
            get
            {
                return addedDate;
            }
            set
            {
                addedDate = value;
            }
        }

        public string UpdatedBy
        {
            get
            {
                return updatedBy;
            }
            set
            {
                updatedBy = value;
            }
        }
        public DateTime UpdatedDate
        {
            get
            {
                return updatedDate;
            }
            set
            {
                updatedDate = value;
            }
        }
        #endregion

        #region "Public Methods

        public ServiceThreadTCPConfig(ErrorHandler errorLogger, DataAccess dataAccess)
        {
            try
            {
                objDataAccess = dataAccess;
                objErrorLogger = errorLogger;
            }
            catch (Exception ex)
            {
                errorLogger.WritetoLogFile(ex);
            }

        }

        public bool GetServiceThreadTCPConfig(ref DataTable objDataTable)
        {
            try
            {
                //DataTable objDataTable = new DataTable();
                objDataTable = objDataAccess.GetDataTable("select * From GetServiceThreadTCPConfig");

                return true;
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public bool GetServiceThreadTCPConfig(int serviceThreadId, ref DataTable objDataTable)
        {
            try
            {
                objDataTable = objDataAccess.GetDataTable("SELECT * FROM ServiceThreadTCPConfig WHERE IsActive = 1 AND ServiceThreadId = " + serviceThreadId);
                return true;
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public bool InsertServiceThreadTCPConfig(int serviceThreadId, string iPAddress, int tCPPortAddress, int isActive, string addedBy)
        {
            DateTime addeddate = DateTime.Now;
            try
            {
                strSQL = "Insert Into ServiceThreadTCPConfig (serviceThreadId, iPAddress, tCPPortAddress, isActive, addedBy, addedDate, updatedBy, updatedDate) Values("
                      + serviceThreadId + "', '" + iPAddress + "', '" + tCPPortAddress + "', '" + isActive + "', '" + addedBy + "', '" + addedDate;

                int result = objDataAccess.ExecuteNonQuery(strSQL);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public bool UpdateServiceThreadTCPConfig(int id, int serviceThreadId, string iPAddress, int tCPPortAddress, int isActive, string updatedBy)
        {
            try
            {
                strSQL = "UPDATE ServiceThreadTCPConfig SET ServiceThreadId = '" + serviceThreadId + "', IPAddress = '" + iPAddress +
                    "', TCPPortAddress = " + tCPPortAddress + "', IsActive = " + isActive + "', UpdatedBy = '" +
                    updatedBy + "', UpdatedDate = '" + updatedDate + "' WHERE Id = '" + id;

                int result = objDataAccess.ExecuteNonQuery(strSQL);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public bool DeleteServiceThreadTCPConfig(int id)
        {
            try
            {
                strSQL = "Delete from ServiceThreadTCPConfig Where Id = " + id;
                int result = objDataAccess.ExecuteNonQuery(strSQL);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }
        #endregion
    }
}
