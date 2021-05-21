using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data.Common;
using Model;
using System.Data;

namespace Util
{
    public static class DocumentOracle
    {
        /// <summary>
        /// Método que faz a importação das tabelas do banco de dados
        /// </summary>
        /// <returns></returns>
        public static bool Importar()
        {
            try
            {
                Visao.BarraDeCarregamento barra = new Visao.BarraDeCarregamento(Total(), "Importando dados");
                barra.Show();

                GerarTabelas(barra);

                GerarColunas(barra);

                GerarRelacionamentos(barra);

                barra.Dispose();
                barra = null;
            }
            catch (Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Error: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método que retorna o total de processamento
        /// </summary>
        /// <returns>total</returns>
        public static int Total()
        {
            int retorno = 0;

            string sentenca = "SELECT 10000 AS TOTAL FROM DUAL";

            DbDataReader reader = DataBase.Connection.Select(sentenca);

            if (reader.Read())
            {
                retorno = int.Parse(reader["total"].ToString());
            }
            reader.Close();

            return retorno;
        }

        /// <summary>
        /// método que salva no arquivo
        /// </summary>
        /// <param name="tabelas"></param>
        private static void PreencheArquivoCampos(List<Campo> campo)
        {
            if (File.Exists(Global.app_exportacao_campos_file))
            {
                File.Delete(Global.app_exportacao_campos_file);
            }

            string json = JsonConvert.SerializeObject(campo);
            File.WriteAllLines(Global.app_exportacao_campos_file, json.Split(Environment.NewLine.ToCharArray()));
        }

        /// <summary>
        /// Método que gera as colunas
        /// </summary>
        private static void GerarColunas(Visao.BarraDeCarregamento barra)
        {
            List<Campo> campos = new List<Campo>();

            RetornaDetalhesCampos(barra, ref campos);

            PreencheArquivoCampos(campos);
        }

        /// <summary>
        /// Método que retorna uma lista de tabelas e suas descrições
        /// </summary>
        /// <returns></returns>
        public static void RetornaDetalhesCampos(Visao.BarraDeCarregamento barra, ref List<Model.Campo> campos)
        {
            Util.CL_Files.WriteOnTheLog("Iniciando RetornaDetalhesCampos", Global.TipoLog.SIMPLES);

            if (File.Exists(Global.app_exportacao_campos_file))
            {
                File.Delete(Global.app_exportacao_campos_file);
            }

            string sentenca = @"SELECT
                                   col.COLUMN_NAME,
                                   col.DATA_TYPE,
                                   col.NULLABLE,
                                   '' AS DATA_DEFAULT,
                                   case
                                       when allCons.CONSTRAINT_TYPE = 'P' then
                                         '1'
                                       else '0'
                                   end primarykey,
                                   case
                                       when allCons.CONSTRAINT_TYPE = 'U' then
                                         '1'
                                       else '0'
                                   end isunique,
                                   col.DATA_LENGTH,
                                   col.DATA_PRECISION,
                                   col.TABLE_NAME,
                                   COMM.COMMENTS
                               FROM all_tab_columns col
                               LEFT JOIN ALL_COL_COMMENTS COMM ON (col.COLUMN_NAME = COMM.COLUMN_NAME AND col.TABLE_NAME = COMM.TABLE_NAME)
                               LEFT JOIN all_cons_columns consCol on (col.COLUMN_NAME = consCol.COLUMN_NAME)
                               LEFT JOIN all_constraints allCons on (consCol.CONSTRAINT_NAME = allCons.CONSTRAINT_NAME)
                               WHERE(NOT col.TABLE_NAME LIKE '%$%') AND(NOT col.TABLE_NAME LIKE '%LOGMNR%')";

            DbDataReader reader = DataBase.Connection.Select(sentenca);
            DataTable table = new DataTable();
            table.Load(reader);
            Util.CL_Files.WriteOnTheLog("Rodou consulta. Resultados: " + table.Rows.Count, Global.TipoLog.SIMPLES);
            reader.Close();
            Util.CL_Files.WriteOnTheLog("Fechou conexão", Global.TipoLog.SIMPLES);

            foreach (DataRow row in table.Rows)
            {
                barra.AvancaBarra(1);

                string nome = row["COLUMN_NAME"].ToString();
                bool notnull = row["NULLABLE"].ToString().ToUpper().Equals("YES");
                string tipo = row["DATA_TYPE"].ToString();
                string valueDefault = row["DATA_DEFAULT"].ToString();
                bool primarykey = row["primarykey"].ToString().Equals("1");
                bool unique = row["isunique"].ToString().Equals("1");
                string tamanho = row["DATA_LENGTH"].ToString();
                string precisao = row["DATA_PRECISION"].ToString();
                string tabela = row["TABLE_NAME"].ToString();
                string comments = row["COMMENTS"].ToString();

                Model.Campo c = new Model.Campo();
                c.Name_Field = nome;
                c.NotNull = notnull;
                c.Type = tipo;
                c.ValueDefault = valueDefault;
                c.PrimaryKey = primarykey;
                c.Unique = unique;
                c.Size = string.IsNullOrEmpty(tamanho) ? 0 : int.Parse(tamanho);
                c.Precision = string.IsNullOrEmpty(precisao) ? decimal.Zero : decimal.Parse(precisao);
                c.Tabela = tabela;
                c.Comments = comments;

                campos.Add(c);
            }

        }

        /// <summary>
        /// Método que gera as tabelas
        /// </summary>
        private static void GerarTabelas(Visao.BarraDeCarregamento barra)
        {
            List<DAO.MDN_Table> tabelas = new List<DAO.MDN_Table>();

            tabelas = RetornaDetalhesTabelas(barra);

            GeraArquivotabela(tabelas);
        }

        /// <summary>
        /// Método que retorna uma lista de tabelas e suas descrições
        /// </summary>
        /// <returns></returns>
        public static List<DAO.MDN_Table> RetornaDetalhesTabelas(Visao.BarraDeCarregamento barra)
        {
            List<DAO.MDN_Table> tables = new List<DAO.MDN_Table>();

            string sentenca = "SELECT table_name FROM ALL_TABLES WHERE(NOT TABLE_NAME LIKE '%$%') AND(NOT TABLE_NAME LIKE '%LOGMNR%')AND(NOT TABLESPACE_NAME = 'SYSTEM') ";

            DbDataReader reader = DataBase.Connection.Select(sentenca);

            while (reader.Read())
            {
                barra.AvancaBarra(1);

                DAO.MDN_Table table = new DAO.MDN_Table(reader["table_name"].ToString());
                tables.Add(table);
            }
            reader.Close();

            return tables;
        }

        /// <summary>
        /// Método que armazena nos arquivos as tabelas
        /// </summary>
        /// <param name="tables"></param>
        private static void GeraArquivotabela(List<DAO.MDN_Table> tables)
        {
            List<Tabela> tabelas = new List<Tabela>();

            foreach(DAO.MDN_Table table in tables)
            {
                Tabela t = new Tabela();
                t.nome = table.Table_Name;
                tabelas.Add(t);
            }

            PreencheArquivo(tabelas);
        }

        /// <summary>
        /// método que salva no arquivo
        /// </summary>
        /// <param name="tabelas"></param>
        private static void PreencheArquivo(List<Tabela> tabelas)
        {
            if (File.Exists(Global.app_exportacao_tabela_file))
            {
                File.Delete(Global.app_exportacao_tabela_file);
            }

            string json = JsonConvert.SerializeObject(tabelas);
            File.WriteAllLines(Global.app_exportacao_tabela_file, json.Split(Environment.NewLine.ToCharArray()));
        }

        /// <summary>
        /// Método que gera os relacionamentos
        /// </summary>
        private static void GerarRelacionamentos(Visao.BarraDeCarregamento barra)
        {
            List<Relacionamento> relacionamentos = new List<Relacionamento>();

            //RetornaDetalhesRelacionamentos(barra, ref relacionamentos);

            //PreencheArquivoRelacionamentos(relacionamentos);

        }

        /// <summary>
        /// Método que retorna os detalhes de todos os relacionamentos
        /// </summary>
        /// <param name="barra"></param>
        /// <param name="relacionamentos"></param>
        public static void RetornaDetalhesRelacionamentos(Visao.BarraDeCarregamento barra, ref List<Model.Relacionamento> relacionamentos)
        {
            string sentenca = @" SELECT
                                     f.name constraint_name
                                    ,OBJECT_NAME(f.parent_object_id) referencing_table_name
                                    ,COL_NAME(fc.parent_object_id, fc.parent_column_id) referencing_column_name
                                    ,OBJECT_NAME (f.referenced_object_id) referenced_table_name
                                    ,COL_NAME(fc.referenced_object_id, fc.referenced_column_id) referenced_column_name
                                 FROM sys.foreign_keys AS f
                                 INNER JOIN sys.foreign_key_columns AS fc
                                    ON f.object_id = fc.constraint_object_id
                                 ORDER BY f.name";

            DbDataReader reader = DataBase.Connection.Select(sentenca);

            while (reader.Read())
            {
                barra.AvancaBarra(1);

                string constraintName = reader["constraint_name"].ToString();
                string tabelaOrigem = reader["referencing_table_name"].ToString();
                string tabelaDestino = reader["referenced_table_name"].ToString().ToUpper();
                string campoOrigem = reader["referencing_column_name"].ToString();
                string campoDestino = reader["referenced_column_name"].ToString();


                Model.Relacionamento r = new Model.Relacionamento();
                r.constraintName = constraintName;
                r.tabelaDestino = tabelaDestino;
                r.tabelaOrigem = tabelaOrigem;
                r.campoDestino = campoDestino;
                r.campoOrigem = campoOrigem;

                relacionamentos.Add(r);
            }
            reader.Close();
        }

        /// <summary>
        /// método que salva no arquivo
        /// </summary>
        /// <param name="tabelas"></param>
        private static void PreencheArquivoRelacionamentos(List<Relacionamento> relacionamentos)
        {
            if (File.Exists(Global.app_exportacao_relacionamentos_file))
            {
                File.Delete(Global.app_exportacao_relacionamentos_file);
            }

            string json = JsonConvert.SerializeObject(relacionamentos);
            File.WriteAllLines(Global.app_exportacao_relacionamentos_file, json.Split(Environment.NewLine.ToCharArray()));
        }

        /// <summary>
        /// Método que valida se tem permissão no banco para verificar as tabelas
        /// </summary>
        /// <returns></returns>
        public static bool VerificaPermissao()
        {
            string sentenca = "SELECT 1 FROM DUAL";
            DbDataReader reader = DataBase.Connection.Select(sentenca);

            bool retorno = reader.Read();
            reader.Close();

            return retorno;
        }
    }

}
