using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PredictiveTool.DALayer
{

    public class BaseClass
    {
        protected SqlCommand sqlCommand;
        protected SqlConnection sqlConnection;
        protected ArrayList SqlParam = new ArrayList();
        protected Int64 RowsAffected = 0;
        protected Boolean executeResult;
        protected Int64 insertIdentity;
        protected string sql;
        public IConfiguration Configuration { get; set; }
        public string connStr = String.Empty;
        //IWebHostEnvironment 


        //protected SqlParameter[] lstParam { get; set; }
        protected List<SqlParameter> lstparameters { get; set; }
        protected SqlCommand SqlCommand { get; set; }
        SqlParameter[] commandParameters;
        object[] parameterValues;
        public SqlConnection SqlConnection { get; set; }
        static string connectionString = string.Empty;
        //connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString
        public BaseClass()
        {
            try
            {

           this.Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();

                //var asa = Configuration.GetConnectionString("DevConnection"); //ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString.ToString();
                connectionString = Configuration.GetConnectionString("DevConnection");
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        protected string DBConnectionString
        {
            get { return Configuration.GetConnectionString("DevConnection"); }
        }

        protected struct SqlValueType
        {
            public string ParameterName { get; set; }
            public DbType ValueType { get; set; }
            public object Value { get; set; }
            public ParameterDirection Direction { get; set; }
        }

        protected DataSet datasetFromDB(string Command)
        {
            return datasetFromDB(Command, false);
        }

        protected DataSet datasetFromDB(string command, bool isStoreProc)
        {
            return datasetFromDB(command, "table0", isStoreProc);
        }

        protected DataSet datasetFromDB_ValueOnly(string command, bool isStoreProc)
        {
            return datasetFromDB_valueOnly(command, "table0", isStoreProc);
        }

        protected DataSet datasetFromDB(string command, string tableName, bool isStoreProc)
        {
            Stopwatch objWatch = new Stopwatch();
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            try
            {
                PrepareSqlCommand(command, isStoreProc);
                using (sqlConnection = new SqlConnection(DBConnectionString))
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlCommand.CommandTimeout = 3600;

                    objWatch.Start();
                    sqlDataAdapter.Fill(ds);
                    objWatch.Stop();
                    //if (ConfigurationManager.AppSettings["SSCProcPerfLog"].ToString() == "1")
                    //{
                    //    //ProcedurePerformance.GetProcedurePerformance(sqlCommand, objWatch.ElapsedMilliseconds, "true");
                    //}
                    return ds;
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(sqlCommand.CommandText + " ");
                SqlParameterCollection objParameterCollection = sqlCommand.Parameters;
                foreach (SqlParameter objParameter in objParameterCollection)
                {
                    sb.Append(objParameter.ParameterName).Append("='").Append(objParameter.Value).Append("',");
                }
                sb.Length--;
                sb.Append(" ");
                //if (ConfigurationManager.AppSettings["SSCErrorLog"].ToString() == "1")
                //{
                //    // ErrorLogger.ErrorLog("SQL_Exception", sb.ToString(), ex.Message.ToString());
                //}
                //Log4Net.Error("SQL_Exception~" + sb.ToString(), ex);
                throw;
            }
            finally
            {
                ds.Dispose();
                sqlDataAdapter.Dispose();
                sqlCommand.Dispose();
            }
        }

        protected DataSet datasetFromDB_valueOnly(string command, string tableName, bool isStoreProc)
        {
            Stopwatch objWatch = new Stopwatch();
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            try
            {
                PrepareSqlCommand_WithValueOnly(command, isStoreProc);
                using (sqlConnection = new SqlConnection(DBConnectionString))
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlCommand.CommandTimeout = 3600;

                    objWatch.Start();
                    sqlDataAdapter.Fill(ds);
                    objWatch.Stop();
                    //if (ConfigurationManager.AppSettings["SSCProcPerfLog"].ToString() == "1")
                    //{
                    //    // ProcedurePerformance.GetProcedurePerformance(sqlCommand, objWatch.ElapsedMilliseconds, "false");
                    //}
                    return ds;
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(sqlCommand.CommandText + " ");
                SqlParameterCollection objParameterCollection = sqlCommand.Parameters;
                foreach (SqlParameter objParameter in objParameterCollection)
                {
                    sb.Append(objParameter.ParameterName).Append("='").Append(objParameter.Value).Append("',");
                }
                sb.Length--;
                sb.Append(" ");
                //if (ConfigurationManager.AppSettings["SSCErrorLog"].ToString() == "1")
                //{
                //    //ErrorLogger.ErrorLog("SQL_Exception", sb.ToString(), ex.Message.ToString());
                //}
                //Log4Net.Error("SQL_Exception~" + sb.ToString(), ex);
                throw;
            }
            finally
            {
                ds.Dispose();
                sqlDataAdapter.Dispose();
                sqlCommand.Dispose();

            }
        }

        protected DataTable dataTableFromDB(string Command)
        {
            return dataTableFromDB(Command, false);
        }

        protected DataTable dataTableFromDB(string command, bool isStoreProc)
        {
            return dataTableFromDB(command, "table0", isStoreProc);
        }

        protected DataTable dataTableFromDB(string command, string tableName, bool isStoreProc)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            try
            {
                PrepareSqlCommand(command, isStoreProc);
                using (sqlConnection = new SqlConnection(DBConnectionString))
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlCommand.CommandTimeout = 3600;

                    sqlDataAdapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
            finally
            {
                ds.Dispose();
                sqlDataAdapter.Dispose();
                sqlCommand.Dispose();
            }
        }

        protected Int64 ExecuteDBCommand(string command, bool isStoreProc)
        {
            Stopwatch objWatch = new Stopwatch();
            try
            {
                PrepareSqlCommand(command, isStoreProc);

                using (sqlConnection = new SqlConnection(DBConnectionString))
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;


                    objWatch.Start();
                    RowsAffected = sqlCommand.ExecuteNonQuery();
                    objWatch.Stop();

                    if (RowsAffected >= 1)
                        executeResult = true;
                    else
                        executeResult = false;
                    //if (ConfigurationManager.AppSettings["SSCProcPerfLog"].ToString() == "1")
                    //{
                    //    //ProcedurePerformance.GetProcedurePerformance(sqlCommand, objWatch.ElapsedMilliseconds, executeResult.ToString());
                    //}

                    if (SqlParam != null && SqlParam.Count > 0)
                    {
                        for (int i = 0; i < SqlParam.Count; i++)
                        {
                            SqlValueType oSqlValueType = (SqlValueType)SqlParam[i];
                            if (oSqlValueType.Direction == ParameterDirection.Output)
                            {
                                oSqlValueType.Value = sqlCommand.Parameters[oSqlValueType.ParameterName];
                                SqlParam[i] = oSqlValueType;

                                if (oSqlValueType.Value != null)
                                {
                                    insertIdentity = (long)oSqlValueType.Value;
                                    executeResult = true;
                                }
                            }
                        }
                        if (insertIdentity == 0)
                        {
                            insertIdentity = RowsAffected;
                            executeResult = true;
                        }
                    }
                    return insertIdentity;
                }
            }
            finally
            {
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }


        protected Int64 ExecuteDBScalarCommand(string command, bool isStoreProc)
        {
            Stopwatch objWatch = new Stopwatch();
            try
            {
                PrepareSqlCommand(command, isStoreProc);

                using (sqlConnection = new SqlConnection(DBConnectionString))
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;

                    objWatch.Start();
                    RowsAffected = Convert.ToInt64(sqlCommand.ExecuteScalar());
                    objWatch.Stop();

                    if (RowsAffected >= 1)
                        executeResult = true;
                    else
                        executeResult = false;
                    //if (ConfigurationManager.AppSettings["SSCProcPerfLog"].ToString() == "1")
                    //{
                    //    //ProcedurePerformance.GetProcedurePerformance(sqlCommand, objWatch.ElapsedMilliseconds, executeResult.ToString());
                    //}
                    if (SqlParam != null && SqlParam.Count > 0)
                    {
                        for (int i = 0; i < SqlParam.Count; i++)
                        {
                            SqlValueType oSqlValueType = (SqlValueType)SqlParam[i];
                            if (oSqlValueType.Direction == ParameterDirection.Output)
                            {
                                oSqlValueType.Value = sqlCommand.Parameters[oSqlValueType.ParameterName];
                                SqlParam[i] = oSqlValueType;

                                if (oSqlValueType.Value != null)
                                {
                                    insertIdentity = Convert.ToInt64(((System.Data.SqlTypes.SqlInt64)(((System.Data.SqlClient.SqlParameter)(oSqlValueType.Value)).SqlValue)).Value);
                                    executeResult = true;
                                }
                            }
                        }
                    }
                    return insertIdentity;
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(sqlCommand.CommandText + " ");
                SqlParameterCollection objParameterCollection = sqlCommand.Parameters;
                foreach (SqlParameter objParameter in objParameterCollection)
                {
                    sb.Append(objParameter.ParameterName).Append("='").Append(objParameter.Value).Append("',");
                }
                sb.Length--;
                sb.Append(" ");
                //if (ConfigurationManager.AppSettings["SSCErrorLog"].ToString() == "1")
                //{
                //    //ErrorLogger.ErrorLog("SQL_Exception", sb.ToString(), ex.Message.ToString());
                //}
                //Log4Net.Error("SQL_Exception~" + sb.ToString(), ex);
                throw;
            }
            finally
            {

                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }

        #region "Helper Functions"

        protected void PrepareSqlCommand(string sqlQuery, bool isStoreProc)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sqlQuery;
            if (isStoreProc)
                sqlCommand.CommandType = CommandType.StoredProcedure;
            else
                sqlCommand.CommandType = CommandType.Text;

            if (SqlParam != null && SqlParam.Count >= 1)
            {
                for (int i = 0; i < SqlParam.Count; i++)
                {
                    SqlParameter sqlParameter = new SqlParameter();
                    SqlValueType sqlValueType = (SqlValueType)SqlParam[i];
                    sqlParameter.ParameterName = sqlValueType.ParameterName;
                    sqlParameter.DbType = sqlValueType.ValueType;
                    sqlParameter.Direction = sqlValueType.Direction;
                    if (sqlValueType.Value != null)
                        sqlParameter.Value = sqlValueType.Value;

                    sqlCommand.Parameters.Add(sqlParameter);
                }
            }
        }


        //new Added
        protected void PrepareSqlCommand_WithValueOnly(string sqlQuery, bool isStoreProc)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sqlQuery;
            if (isStoreProc)
                sqlCommand.CommandType = CommandType.StoredProcedure;
            else
                sqlCommand.CommandType = CommandType.Text;

            if (SqlParam != null && SqlParam.Count >= 1)
            {
                for (int i = 0; i < SqlParam.Count; i++)
                {
                    SqlParameter sqlParameter = new SqlParameter();
                    SqlValueType sqlValueType = (SqlValueType)SqlParam[i];
                    sqlParameter.ParameterName = sqlValueType.ParameterName;
                    sqlParameter.Direction = sqlValueType.Direction;
                    if (sqlValueType.Value != null)
                        sqlParameter.Value = sqlValueType.Value;

                    sqlCommand.Parameters.Add(sqlParameter);
                }
            }
        }

        protected void SqlParamAddWithValue(string parameter, object value)
        {
            SqlValueType sqlValueType = new SqlValueType();
            sqlValueType.ParameterName = parameter;
            sqlValueType.Value = value;
            SqlParam.Add(sqlValueType);
        }


        protected void SqlParamAdd(string parameter, DbType valueType, object value)
        {
            SqlValueType sqlValueType = new SqlValueType();
            sqlValueType.ParameterName = parameter;
            sqlValueType.ValueType = valueType;
            DateTime dateTime;
            if (DateTime.TryParse(valueType.ToString(), out dateTime))
            {
                if (dateTime != DateTime.MinValue)
                    sqlValueType.Value = value;
                else
                    sqlValueType.Value = null;
            }
            else
            {
                sqlValueType.Value = value;

            }
            SqlParam.Add(sqlValueType);
        }

        protected void SqlParamAddOut(string parameter, DbType valueType, object value, ParameterDirection paramDirection)
        {
            SqlValueType sqlValueType = new SqlValueType();
            sqlValueType.ParameterName = parameter;
            sqlValueType.ValueType = valueType;
            DateTime dateTime;
            if (DateTime.TryParse(valueType.ToString(), out dateTime))
            {
                if (dateTime != DateTime.MinValue)
                    sqlValueType.Value = value;
                else
                    sqlValueType.Value = null;
            }
            else
            {
                sqlValueType.Value = value;
                sqlValueType.Direction = paramDirection;
            }
            SqlParam.Add(sqlValueType);
        }

        #endregion

        /// </summary>
        /// <param name="command">The command to which the parameters will be added</param>
        /// <param name="commandParameters">An array of SqlParameters to be added to command</param>
        private static void AttachParameters(SqlCommand command, IEnumerable<SqlParameter> commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters == null) return;
            foreach (var p in commandParameters.Where(p => p != null))
            {
                // Check for derived output value with no value assigned
                if ((p.Direction == ParameterDirection.InputOutput ||
                     p.Direction == ParameterDirection.Input) &&
                    (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }
                command.Parameters.Add(p);
            }
        }
        /// <param name="command">The SqlCommand to be prepared</param>
        /// <param name="connection">A valid SqlConnection, on which to execute this command</param>
        /// <param name="transaction">A valid SqlTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, IEnumerable<SqlParameter> commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (string.IsNullOrEmpty(commandText)) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please Make It transaction.", "transaction");
                command.Transaction = transaction;
            }

            // Set the command type
            command.CommandType = commandType;

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }

        public static void ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(commandText, connection))
            {
                command.CommandType = commandType;
                command.Parameters.AddRange(commandParameters);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static DataSet ExecuteQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(commandText, connection))
            {
                DataSet ds = new DataSet();
                command.CommandType = commandType;
                command.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                return ds;
            }
        }
    }
}