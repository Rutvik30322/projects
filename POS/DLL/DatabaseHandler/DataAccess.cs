/// <summary>
/// Utility to interact with Database
/// </summary>
namespace NDatabaseHandler
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using NErrorHandler;

    public class DataAccess
    {
        #region "Private Variable"
        private SqlConnection DbConnection;
        private ErrorHandler errHandler;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="objErrorLogger"></param>
        public DataAccess(string connectionString, ErrorHandler objErrorLogger)
        {
            try
            {
                DbConnection = new SqlConnection(connectionString);

                if (objErrorLogger != null)
                {
                    errHandler = objErrorLogger;
                }
                else
                {
                    errHandler = new ErrorHandler("Database");
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);
            }
        }

        public DataAccess(string connectionString)
        {
            try
            {
                DbConnection = new SqlConnection(connectionString);
                errHandler = new ErrorHandler("Database");
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);
            }
        }

        #endregion

        #region "Generic Method"
        /// <summary>
        /// Fetch dataset as per passed sql query.
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strSql)
        {
            DataSet objDataSet = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(strSql, DbConnection);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);

                if (DbConnection.State == ConnectionState.Closed)
                {
                    DbConnection.Open();
                }
                adpt.Fill(objDataSet);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
            return objDataSet;
        }

        /// <summary>
        /// Fetch dataset as per passed sql query with parameter and command Type.
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strSql, string[] paramArray, object[] values, CommandType cmdType = CommandType.Text)
        {
            DataSet objDataSet = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(strSql, DbConnection);
                //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.CommandType = cmdType;
                cmd.CommandTimeout = 3600;
                if (DbConnection.State == ConnectionState.Closed)
                {
                    DbConnection.Open();
                }

                if ((paramArray != null) && (values != null) && (paramArray.Length == values.Length))
                {
                    for (int i = 0; i < paramArray.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(paramArray[i], values[i]);
                    }
                }
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(objDataSet);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
            return objDataSet;
        }

        /// <summary>
        /// Fetch datatable as per passed sql query.
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strSql)
        {
            DataTable objDataTable = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(strSql, DbConnection);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);

                if (DbConnection.State == ConnectionState.Closed)
                {
                    DbConnection.Open();
                }
                adpt.Fill(objDataTable);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
            return objDataTable;
        }


        /// <summary>
        /// Fetch datatable as per passed sql query with diff. command type.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strSql, CommandType cmdType = CommandType.Text)
        {
            DataTable objDataTable = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(strSql, DbConnection);
                cmd.CommandType = cmdType;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);

                if (DbConnection.State == ConnectionState.Closed)
                {
                    DbConnection.Open();
                }
                adpt.Fill(objDataTable);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
            return objDataTable;
        }

        /// <summary>
        /// Fetch datatable as per passed sql query with Parameter.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paramArray"></param>
        /// <param name="values"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strSql, string[] paramArray, object[] values, CommandType cmdType = CommandType.Text)
        {
            DataTable objDataTable = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(strSql, DbConnection);
                cmd.CommandType = cmdType;

                if ((paramArray != null) && (values != null) && (paramArray.Length == values.Length))
                {
                    for (int i = 0; i < paramArray.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(paramArray[i], values[i]);
                    }
                }

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(objDataTable);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
            return objDataTable;
        }

        /// <summary>
        /// Execute SQL statement.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string strSql, CommandType type = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSql, DbConnection))
                {
                    cmd.CommandType = type;
                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        DbConnection.Open();
                    }
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);

                return 0;
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Execute Non Query with parameter
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string strSql, List<object> sqlParams, CommandType type = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSql, DbConnection))
                {
                    cmd.CommandType = type;
                    string paramId;
                    object value;

                    for (int index = 0; index < sqlParams.Count; index++)
                    {
                        paramId = "@param" + index;
                        value = sqlParams[index];
                        cmd.Parameters.AddWithValue(paramId, value);
                    }

                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        DbConnection.Open();
                    }
                    int i = cmd.ExecuteNonQuery();
                    return i;
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);

                return 0;
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        /// <summary>
        ///  Execute Non Query with parameter with Parameter name and values.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paramArray"></param>
        /// <param name="values"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string strSql, string[] paramArray, object[] values, CommandType type = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSql, DbConnection))
                {
                    if ((paramArray != null) && (values != null) && (paramArray.Length == values.Length))
                    {
                        for (int i = 0; i < paramArray.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(paramArray[i], values[i]);
                        }
                    }

                    cmd.CommandType = type;
                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        DbConnection.Open();
                    }
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);

                return 0;
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        /// <summary>
        ///  Execute Non Query with sqlcommand
        /// </summary>
        /// <param name="objSqlCommand"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlCommand objSqlCommand)
        {
            try
            {
                SqlCommand cmd = objSqlCommand;
                cmd.Connection = DbConnection;
                DbConnection.Open();
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + objSqlCommand.CommandText + Environment.NewLine + ", ex = " + ex);

                return 0;
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Execute stored procedure and get new created key as output.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paramArray"></param>
        /// <param name="values"></param>
        /// <param name="isKeyRequired"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string strSql, string[] paramArray, object[] values, bool isKeyRequired, CommandType type = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSql, DbConnection))
                {
                    if ((paramArray != null) && (values != null) && (paramArray.Length == values.Length))
                    {
                        for (int i = 0; i < paramArray.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(paramArray[i], values[i]);
                        }
                    }

                    if (isKeyRequired)
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int);
                        cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    }

                    cmd.CommandType = type;
                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        DbConnection.Open();
                    }
                    int result = cmd.ExecuteNonQuery();

                    int id = Convert.ToInt16(cmd.Parameters["@id"].Value);
                    return id;
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);

                return 0;
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Execute stored procedure and get new created key as output.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paramArray"></param>
        /// <param name="values"></param>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string strSql, string[] paramArray, object[] values, ref int id, CommandType type = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSql, DbConnection))
                {
                    if ((paramArray != null) && (values != null) && (paramArray.Length == values.Length))
                    {
                        for (int i = 0; i < paramArray.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(paramArray[i], values[i]);
                        }
                        cmd.Parameters.Add("@id", SqlDbType.Int);
                        cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    }

                    cmd.CommandType = type;
                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        DbConnection.Open();
                    }
                    int result = cmd.ExecuteNonQuery();
                    id = Convert.ToInt16(cmd.Parameters["@id"].Value);
                    return result;
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);

                return 0;
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Execute scallar with parameter name and values.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paramArry"></param>
        /// <param name="values"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ExecuteNonQueryWithReturnValue(string strSql, string[] paramArray, object[] values, CommandType type = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSql, DbConnection))
                {
                    if ((paramArray != null) && (values != null) && (paramArray.Length == values.Length))
                    {
                        for (int i = 0; i < paramArray.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(paramArray[i], values[i]);
                        }
                    }

                    cmd.CommandType = type;
                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        DbConnection.Open();
                    }
                    SqlParameter returnsqlParameter = cmd.Parameters.Add("@return", SqlDbType.Int);
                    returnsqlParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int result = (int)cmd.Parameters["@return"].Value;
                    return result;
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);

                return 0;
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Execute scallar with parameter name and values.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paramArry"></param>
        /// <param name="values"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object ExecuteScalar(string strSql, string[] paramArry, object[] values, CommandType type = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSql, DbConnection))
                {
                    if ((paramArry != null) && (values != null) && (paramArry.Length == values.Length))
                        for (int i = 0; i < paramArry.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(paramArry[i], values[i]);
                        }

                    cmd.CommandType = type;
                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        DbConnection.Open();
                    }
                    object result = cmd.ExecuteScalar();

                    //if (errLogger != null)
                    //    errLogger.WriteToLogger("ExecuteNonQuery function call succesfully.");

                    return result;
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                {
                    errHandler.WritetoLogFile("strSql = " + strSql + Environment.NewLine + ", ex = " + ex);
                }
                return false;
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Execute scalar.
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public object ExecuteScalar(string strSQL, CommandType cmdType = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, DbConnection))
                {
                    cmd.CommandType = cmdType;
                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        DbConnection.Open();
                    }
                    object result = cmd.ExecuteScalar();

                    //if (errLogger != null)
                    //    errLogger.WriteToLogger("ExecuteNonQuery function call succesfully.");

                    return result;
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                {
                    errHandler.WritetoLogFile("strSql = " + strSQL + Environment.NewLine + ", ex = " + ex);
                }
                return null;
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        public void BulkCopyDataTable(DataTable objDataTable, string destinationTableName)
        {
            try
            {
                //using (var bulkCopy = new System.Data.SqlClient.SqlBulkCopy(DbConnection.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                using (var bulkCopy = new System.Data.SqlClient.SqlBulkCopy(DbConnection))
                {
                    // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match,
                    // just pass in which datatable name matches the SQL column name in Column Mappings
                    foreach (DataColumn col in objDataTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    }

                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        DbConnection.Open();
                    }

                    bulkCopy.BulkCopyTimeout = 600;
                    bulkCopy.DestinationTableName = destinationTableName;
                    bulkCopy.WriteToServer(objDataTable);
                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + destinationTableName + Environment.NewLine + ", ex = " + ex);
            }
            finally
            {
                if (DbConnection != null)
                {
                    DbConnection.Close();
                }
            }
        }

        public void BulkCopyDataTable(DataTable objDataTable, string destinationTableName, string connString)
        {
            try
            {
                using (var bulkCopy = new System.Data.SqlClient.SqlBulkCopy(connString, SqlBulkCopyOptions.KeepIdentity))
                {
                    // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match,
                    // just pass in which datatable name matches the SQL column name in Column Mappings
                    foreach (DataColumn col in objDataTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    }

                    //if (DbConnection.State == ConnectionState.Closed)
                    //{
                    //    DbConnection.Open();
                    //}


                    bulkCopy.BulkCopyTimeout = 600;
                    bulkCopy.DestinationTableName = destinationTableName;
                    bulkCopy.WriteToServer(objDataTable);

                }
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile("strSql = " + destinationTableName + Environment.NewLine + ", ex = " + ex);
            }
            finally
            {
                //if (DbConnection != null)
                //{
                //    DbConnection.Close();
                //}
            }
        }
        #endregion


    }
}