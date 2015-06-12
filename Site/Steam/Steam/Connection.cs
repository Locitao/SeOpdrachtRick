using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

namespace Steam
{
    /// <summary>
    ///     This class is used to maintain/open/close the connection with the database.
    /// </summary>
    public class Connection
    {
        /// <summary>
        ///     Fields.
        /// </summary>

        private const string User = "system";
        private const string Pw = "wachtwoord";
        private const string Test = "xe";
        private readonly OracleConnection _conn = new OracleConnection();

        /// <summary>
        ///     This method tries to open the connection.
        /// </summary>
        /// <returns>A bool to check if opening the connection succeeded.</returns>
        public bool NewConnection()
        {
            _conn.ConnectionString = "User Id=" + User + ";Password=" + Pw + ";Data Source=" +
                                    "//localhost:1521/" + Test + ";";

            try
            {
                _conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Closes the connection.
        /// </summary>
        public void CloseConnection()
        {
            _conn.Close();
        }

        /// <summary>
        ///     Method to get data out of the database.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>A list of dictionary objects with database information.</returns>
        public static List<Dictionary<string, object>> ExecuteQuery(string query)
        {
            var result = new List<Dictionary<string, object>>();

            var connection = new Connection();
            connection.CloseConnection();

            if (connection.NewConnection())
            {
                var reader = new OracleCommand(query, connection._conn).ExecuteReader();

                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();

                    //Loop through the fields, add them to row

                    for (var fieldId = 0; fieldId < reader.FieldCount; fieldId++)
                        row.Add(reader.GetName(fieldId), reader.GetValue(fieldId));

                    result.Add(row);
                }
                connection._conn.Close();
                return result;
            }
            connection._conn.Close();
            return result;
        }

        /// <summary>
        ///     Executes a given query on the database.
        /// </summary>
        /// <param name="sql"></param>
        public void Execute(string sql)
        {
            var query = sql;


            if (!NewConnection()) return;
            // Command opzetten voor het uitvoeren van de query
            var cmd = new OracleCommand(query, _conn);

            // Query uitvoeren, er wordt geen waarde terug gegeven
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
    }
}