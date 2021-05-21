using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data.Common;
using Util;
using System.Data;

namespace DataBase
{
    class BancoOracle : Banco
    {
        /// <summary>
        /// Class of the connection with the data_base
        /// </summary>
        private static OracleConnection m_dbConnection;

        /// <summary>
        /// Método que fecha a conexão com o banco
        /// </summary>
        /// <returns></returns>
        public override bool CloseConnection()
        {
            if (is_open)
                m_dbConnection.Close();
            return true;
        }

        /// <summary>
        /// Método que converte Date to Inte
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public override int Date_to_Int(DateTime date)
        {
            string sentenca = "SELECT strftime('%s','" + date.Year + "-" + (date.Month < 10 ? "0" + date.Month : date.Month.ToString()) + "-" + (date.Day < 10 ? "0" + date.Day : date.Day.ToString()) + " 00:00:00') ";
            DbDataReader reader = Select(sentenca);

            int num_date = 0;
            if (reader.Read())
            {
                num_date = int.Parse(reader[0].ToString());
            }
            reader.Close();
            return num_date;
        }

        /// <summary>
        /// Método que executa a querie
        /// </summary>
        /// <param name="command_sql"></param>
        /// <returns></returns>
        public override bool Execute(string command_sql)
        {
            if (!is_open)
                OpenConnection();

            OracleCommand command = new OracleCommand(command_sql, m_dbConnection);
            try
            {
                command.Transaction = m_dbConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                command.Transaction.InitializeLifetimeService();
                command.ExecuteNonQuery();
                command.Transaction.Commit();
                command.Dispose();

                return true;
            }
            catch (Exception e)
            {
                command.Transaction.Rollback();
                Util.CL_Files.WriteOnTheLog("Erro no execute: " + command_sql + ". Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
        }

        /// <summary>
        /// Método que faz conexão com o banco
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public override bool OpenConnection(string connectionString = "")
        {
            if (is_open)
                return true;

            if (string.IsNullOrEmpty(connectionString))
                return false;

            try
            {
                m_dbConnection = new OracleConnection(connectionString);
                m_dbConnection.Open();
                while (m_dbConnection.State == ConnectionState.Connecting) ;
                is_open = true;
                Util.CL_Files.WriteOnTheLog("Abrindo conexão. Banco: " + connectionString, Global.TipoLog.SIMPLES);
            }
            catch (Exception e)
            {
                Util.CL_Files.WriteOnTheLog("DataBase.OpenConnection. Erro: " + e.Message, Global.TipoLog.SIMPLES);
                is_open = false;
            }
            return is_open;
        }

        /// <summary>
        /// Método que faz select no banco
        /// </summary>
        /// <param name="command_sql"></param>
        /// <returns></returns>
        public override DbDataReader Select(string command_sql)
        {
            try
            {
                if (!is_open)
                {
                    OpenConnection();
                }

                OracleCommand command = new OracleCommand(command_sql, m_dbConnection);
                OracleDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Problem on the sentence. Sentence: " + command_sql + ". Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return null;
            }
        }
    }
}
