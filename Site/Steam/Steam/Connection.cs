﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Oracle.DataAccess;

namespace Steam
{
    /// <summary>
    /// This class is used to maintain/open/close the connection with the database.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Fields.
        /// </summary>
        OracleConnection conn = new OracleConnection();
        private const string user = "system";
        private const string pw = "wachtwoord";
        private const string test = "xe";

        /// <summary>
        /// This method tries to open the connection.
        /// </summary>
        /// <returns>A bool to check if opening the connection succeeded.</returns>
        public bool NewConnection()
        {
            conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" +
                                    "//localhost:1521/" + test + ";";

            try
            {
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void CloseConnection()
        {
            conn.Close();
        }

        /// <summary>
        /// Method to get data out of the database.
        /// </summary>
        /// <param name="query"></param>    
        /// <returns>A list of dictionary objects with database information.</returns>
        public static List<Dictionary<string, object>> ExecuteQuery(string query)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            Connection connection = new Connection();
            connection.CloseConnection();

            if (connection.NewConnection())
            {
                try
                {
                    OracleDataReader reader = new OracleCommand(query, connection.conn).ExecuteReader();

                    while (reader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();

                        //Loop through the fields, add them to row

                        for (int fieldId = 0; fieldId < reader.FieldCount; fieldId++)
                            row.Add(reader.GetName(fieldId), reader.GetValue(fieldId));

                        result.Add(row);
                    }
                    connection.conn.Close();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            connection.conn.Close();
            return result;
        }

        /// <summary>
        /// Executes a given query on the database.
        /// </summary>
        /// <param name="sql"></param>
        public void Execute(string sql)
        {
            string query = sql;


            if (!NewConnection()) return;
            // Command opzetten voor het uitvoeren van de query
            OracleCommand cmd = new OracleCommand(query, conn);

            // Query uitvoeren, er wordt geen waarde terug gegeven
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}