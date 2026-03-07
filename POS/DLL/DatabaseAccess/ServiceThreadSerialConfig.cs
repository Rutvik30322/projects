using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
   public class ServiceThreadSerialConfig
    {
        #region "Private Variable"
        private int id;
        private int serviceThreadId;
        private string serialPort;
        private int baudRate;
        private int dataBits;
        private int stopBits;
        private int parity;
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
        public string SerialPort
        {
            get
            {
                return serialPort;
            }
            set
            {
                serialPort = value;
            }
        }
        public int BaudRate
        {
            get
            {
                return baudRate;
            }
            set
            {
                baudRate = value;
            }
        }
        public int DataBits
        {
            get
            {
                return dataBits;
            }
            set
            {
                dataBits = value;
            }
        }
        public int StopBits
        {
            get
            {
                return stopBits;
            }
            set
            {
                stopBits = value;
            }
        }
        public int Parity
        {
            get
            {
                return parity;
            }
            set
            {
                parity = value;
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
        public ServiceThreadSerialConfig(ErrorHandler errorLogger, DataAccess dataAccess)
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

        public bool GetServiceThreadSerialConfig(ref DataTable objDataTable)
        {
            try
            {
                //DataTable objDataTable = new DataTable();
                objDataTable = objDataAccess.GetDataTable("select * From GetServiceThreadSerialConfig");

                return true;
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public bool GetServiceThreadSerialConfig(int serviceThreadId, ref DataTable objDataTable)
        {
            try
            {
                objDataTable = objDataAccess.GetDataTable("SELECT * FROM ServiceThreadSerialConfig WHERE IsActive = 1 AND ServiceThreadId = " + serviceThreadId);
                return true;
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public bool InsertServiceThreadSerialConfig(int serviceThreadId, string serialPort, int baudRate, int dataBits, int stopBits, int parity, int isActive, string addedBy)
        {
            DateTime addedDate = DateTime.Now;
            try
            {
                strSQL = "Insert Into ServiceThreadSerialConfig (serviceThreadId, serialPort, baudRate, dataBits, stopBits, parity,  isActive, addedBy, addedDate, updatedBy, updatedDate) Values("
                      + serviceThreadId + "', '" + serialPort + "', '" + baudRate + "', '" + dataBits + "', '" + stopBits + "', '" + parity  + "', '" + isActive + "', '" + addedBy + "', '" +  addedDate;

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

        public bool UpdateServiceThreadSerialConfig(int id, int serviceThreadId, string serialPort, int baudRate, int dataBits, int stopBits, int parity,
            int isActive ,string updatedBy)
        {
            DateTime updatedDate = DateTime.Now;
            try
            {
                strSQL = "UPDATE ServiceThreadSerialConfig SET ServiceThreadId = '" + serviceThreadId + "', SerialPort = '" + serialPort +
                      "', BaudRate = " + baudRate + ", DataBits = '" + dataBits + "', StopBits = '" + stopBits + "', Parity = '" +
                      parity  + "', IsActive = " + isActive + "', UpdatedBy = '" +
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

        public bool DeleteServiceThreadSerialConfig(int id)
        {
            try
            {
                strSQL = "Delete from ServiceThreadSerialConfig Where Id = " + id;
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
