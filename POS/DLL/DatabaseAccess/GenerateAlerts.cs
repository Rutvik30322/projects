using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class GenerateAlerts
    {
        #region "Private Variable"
        private string strSQL;
        private DataAccess objDataAccess;
        private ErrorHandler objErrorLogger;
        #endregion

        #region "Public Methods
        public GenerateAlerts(ErrorHandler errorLogger, DataAccess dataAccess)
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

        public void StartAlertGeneration()
        {
            string strSql = "";
            string destinationTableName = "AlertRecords";
            DataTable objDataTable = null;
            DataTable objDistinctDt = null;
            try
            {
                strSql = "AlertGenerator";
                //do
                //{
                objDataTable = objDataAccess.GetDataTable(strSql);

                //Get Distinct ActionsTransaction Id and Delete from Alert Records 
                //Delete Old Generated Records
                objDistinctDt = SelectDistinct(objDataTable, "TransactionId");
                if (objDistinctDt != null && objDistinctDt.Rows.Count > 0)
                {
                    for (int i = 0; i < objDistinctDt.Rows.Count; i++)
                    {
                        long actionTransactionId = Convert.ToInt64(objDataTable.Rows[i]["TransactionId"]);
                        strSql = "DELETE FROM AlertRecords WHERE TransactionId = " + actionTransactionId;
                        objDataAccess.ExecuteNonQuery(strSql);
                    }
                }

                if (objDataTable != null && objDataTable.Rows.Count > 0)
                {
                    objDataAccess.BulkCopyDataTable(objDataTable, destinationTableName);
                }

                for (int i = 0; i < objDataTable.Rows.Count; i++)
                {
                    int alertFlagFor = Convert.ToInt32(objDataTable.Rows[i]["AlertFlagFor"]);
                    long transactionId = Convert.ToInt64(objDataTable.Rows[i]["TransactionId"]);
                    if (alertFlagFor == 1)
                    {
                        strSql = "UPDATE TaskTransaction SET DateOfGenerateAlert = GETDATE(), IsMailSend = 1 Where Id = " + transactionId;
                    }
                    else if (alertFlagFor == 2)
                    {
                        strSql = "UPDATE VisitTransaction SET DateOfGenerateAlert = GETDATE(), IsMailSend = 1 Where Id = " + transactionId;
                    }
                    else if (alertFlagFor == 3)
                    {
                        strSql = "UPDATE AssetAlerts SET DateOfGenerateAlert = GETDATE(), IsMailSend = 1 Where Id = " + transactionId;
                    }
                    objDataAccess.ExecuteNonQuery(strSql);
                }
                //    System.Threading.Thread.Sleep(1000 * 60 * 60);
                //} while (true);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
            }
            finally
            {
                strSql = "";
                destinationTableName = "";

                if (objDataTable != null)
                    objDataTable = null;

                if (objDistinctDt != null)
                    objDistinctDt = null;
            }
        }

        public DataTable SelectDistinct(DataTable SourceTable, string FieldName)
        {
            // Create a Datatable – datatype same as FieldName  
            DataTable dt = new DataTable(SourceTable.TableName);
            dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
            // Loop each row & compare each value with one another  
            // Add it to datatable if the values are mismatch  
            object LastValue = null;
            foreach (DataRow dr in SourceTable.Select("", FieldName))
            {
                if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
                {
                    LastValue = dr[FieldName];
                    dt.Rows.Add(new object[] { LastValue });
                }
            }
            return dt;
        }

        private bool ColumnEqual(object A, object B)
        {
            // Compares two values to see if they are equal. Also compares DBNULL.Value.             
            if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value  
                return true;
            if (A == DBNull.Value || B == DBNull.Value) //  only one is BNull.Value  
                return false;
            return (A.Equals(B)); // value type standard comparison  
        }
        #endregion
    }
}
