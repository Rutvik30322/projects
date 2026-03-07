using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;
using static NConstant.Constant;

namespace NDatabaseAccess
{
    public class ServiceThreadsConfig
    {
        #region "Private Variable"
        private int id;
        private string serviceName;
        private string serviceThreadName;
        private int computerCode;
        private int deviceType;
        private int protocol;
        private int noOfNetworks;
        private int flowControl;
        private int maxAttempts;
        private int timeOut;
        private int writeReadDelay;
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
        public string ServiceName
        {
            get
            {
                return serviceName;
            }
            set
            {
                serviceName = value;
            }
        }
        public string ServiceThreadName
        {
            get
            {
                return serviceThreadName;
            }
            set
            {
                serviceThreadName = value;
            }
        }
        public int ComputerCode
        {
            get
            {
                return computerCode;
            }
            set
            {
                computerCode = value;
            }

        }
        public int DeviceType
        {
            get
            {
                return deviceType;
            }
            set
            {
                deviceType = value;
            }
        }
        public int Protocol
        {
            get
            {
                return protocol;
            }
            set
            {
                protocol = value;
            }
        }
        public int NoOfNetworks
        {
            get
            {
                return noOfNetworks;
            }
            set
            {
                noOfNetworks = value;
            }
        }
        public int FlowControl
        {
            get
            {
                return flowControl;
            }
            set
            {
                flowControl = value;
            }
        }
        public int MaxAttempts
        {
            get
            {
                return maxAttempts;
            }
            set
            {
                maxAttempts = value;
            }
        }
        public int TimeOut
        {
            get
            {
                return timeOut;
            }
            set
            {
                timeOut = value;
            }
        }
        public int WriteReadDelay
        {
            get
            {
                return writeReadDelay;
            }
            set
            {
                writeReadDelay = value;
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
        public ServiceThreadsConfig(ErrorHandler errorLogger, DataAccess dataAccess)
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

        public bool GetServiceThreadsConfig(ref DataTable objDataTable)
        {
            try
            {
                //DataTable objDataTable = new DataTable();
                objDataTable = objDataAccess.GetDataTable("select * From GetServiceThreadsConfig");

                return true;
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public bool InsertServiceThreadsConfig(string serviceName, string serviceThreadName, int computerCode, int deviceType, int protocol, int noOfNetworks, int flowControl, int maxAttempts, int timeOut, int writeReadDelay, int isActive, int addedBy)
        {
            DateTime addedDate = DateTime.Now;
            try
            {
                strSQL = "Insert Into ServiceThreadsConfig ( serviceName, serviceThreadName, computerCode, deviceType, protocol, noOfNetworks, flowControl, maxAttempts,timeOut, writeReadDelay,  isActive, addedBy, addedDate, updatedBy, updatedDate) Values("
                        + serviceName + "', '" + serviceThreadName + "', '" + computerCode + "', '" + deviceType + "', '" + protocol + "', '" + noOfNetworks + "', '" + flowControl + "', '" + maxAttempts + "', '" + timeOut + "', '" + writeReadDelay + "', '" + isActive + "', '" + addedBy + "', '" + addedDate;

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

        public bool UpdateServiceThreadsConfig(int id, string serviceName, string serviceThreadName, int computerCode, int deviceType, int protocol, int noOfNetworks, int flowControl, int maxAttempts, int timeOut, int writeReadDelay, int isActive, string updatedBy)
        {
            try
            {

                strSQL = "UPDATE ServiceThreadsConfig SET ServiceName = '" + serviceName + "', ServiceThreadName = '" + serviceThreadName +
                    "', ComputerCode = " + computerCode + ", DeviceType = '" + deviceType + "', Protocol = '" + protocol + "', NoOfNetworks = '" +
                    noOfNetworks + "', FlowControl = " + flowControl + "', MaxAttempts = '" + maxAttempts +
                    "', TimeOut = " + timeOut + ", WriteReadDelay = '" + writeReadDelay + "', IsActive = " + isActive + "', UpdatedBy = '" +
                    updatedBy + "', UpdatedDate = '" + updatedDate + "' WHERE Id = '" + id + "'";
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

        public bool DeleteServiceThreadsConfig(int id)
        {
            try
            {
                strSQL = "Delete from ServiceThreadsConfig Where Id = " + id;
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

        public bool GetServiceThreadsConfig(int serviceId, ref DataTable objDataTable)
        {
            try
            {
                objDataTable = objDataAccess.GetDataTable("SELECT stc.Id [Id], ServiceThreadName [Description] from ServicesConfig sc left join ServiceThreadsConfig stc on sc.Id = stc.ServiceId WHERE sc.IsActive = 1 AND stc.IsActive = 1 AND sc.Id = " + serviceId);
                return true;
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public DataTable GetServiceThreadsConfig(int serviceId, int computerId)
        {
            DataTable objDataTable = null;
            try
            {
                objDataTable = objDataAccess.GetDataTable("SELECT stc.Id [Id], ServiceThreadName [Description] from ServicesConfig sc left join ServiceThreadsConfig stc on sc.Id = stc.ServiceId WHERE sc.IsActive = 1 AND stc.IsActive = 1 AND sc.Id = " + serviceId + " AND ComputerCode = " + computerId);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public TypeOfCommunication GetServiceThreadsType(int serviceThreadId)
        {
            TypeOfCommunication reply = TypeOfCommunication.NONE;
            try
            {
                reply = (TypeOfCommunication)objDataAccess.ExecuteScalar("SELECT isnull(DeviceType, 0) FROM ServiceThreadsConfig WHERE Id = " + serviceThreadId);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
            }
            return reply;
        }
        #endregion

    }
}
