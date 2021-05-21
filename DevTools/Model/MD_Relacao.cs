using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// [RELACAO] Tabela da classe
    /// </summary>
    public class MD_Relacao 
    {
        #region Atributos e Propriedades

        /// <summary>
        /// DAO que representa a classe
        /// </summary>
        public DAO.MD_Relacao DAO = null;

        #endregion Atributos e Propriedades

        #region Construtores
        
        /// <summary>
        /// Construtor secundário da classe
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="projeto"></param>
        /// <param name="tabelaOrigem"></param>
        /// <param name="tabelaDestino"></param>
        /// <param name="campoOrigem"></param>
        /// <param name="campoDestino"></param>
        public MD_Relacao(int codigo, DAO.MD_Projeto projeto, DAO.MD_Tabela tabelaOrigem, DAO.MD_Tabela tabelaDestino, DAO.MD_Campos campoOrigem, DAO.MD_Campos campoDestino) 
        {
            Util.CL_Files.WriteOnTheLog("MD_Relacao()", Util.Global.TipoLog.DETALHADO);

            this.DAO = new DAO.MD_Relacao(codigo, projeto, tabelaOrigem, tabelaDestino, campoOrigem, campoDestino);
        }

        #endregion Construtores

        #region Métodos
        
        /// <summary>
        /// Método que retorna a relação através do campo
        /// </summary>
        /// <param name="campo"></param>
        /// <returns></returns>
        public static MD_Relacao RetornaRelacao(MD_Campos campo)
        {
            MD_Relacao retorno = null;

            string sentenca = new DAO.MD_Relacao().table.CreateCommandSQLTable() + " WHERE CAMPODESTINO = " + campo.DAO.Codigo;
            DbDataReader reader = DataBase.Connection.Select(sentenca);

            if (reader.Read())
            {
                DAO.MD_Tabela tabelaOrigem = new DAO.MD_Tabela(int.Parse(reader["TABELAORIGEM"].ToString()), campo.DAO.Projeto.Codigo);
                DAO.MD_Campos campoOrigem = new DAO.MD_Campos(int.Parse(reader["CAMPOORIGEM"].ToString()), tabelaOrigem);
                DAO.MD_Campos campoDestino = campo.DAO;
                DAO.MD_Tabela tabelaDestino = new DAO.MD_Tabela(campo.DAO.Tabela.Codigo, campo.DAO.Projeto.Codigo);
                retorno = new MD_Relacao(int.Parse(reader["CODIGO"].ToString()), campo.DAO.Projeto, tabelaOrigem, tabelaDestino, campoOrigem, campoDestino);
            }
            return retorno;
        }

        #endregion Métodos

    }
}
