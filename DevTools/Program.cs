using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevTools
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Util.CL_Files.WriteOnTheLog("--------------------------------------Iniciando sistema", Util.Global.TipoLog.SIMPLES);
            bool connection = false;
            try
            {
                connection = DataBase.Connection.OpenConection(Util.Global.app_base_file, Util.Enumerator.BancoDados.SQLite);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Util.CL_Files.CreateMainDirectories();

                Regras.Versao.AtualizaVersao(Application.ProductVersion);
                Util.Global.InsereDadosIniciais();
                Util.Global.log_system = DataBase.Connection.GetLog();
                Util.Global.CarregarAutomaticamente = DataBase.Connection.GetAutomatico();
                Util.Global.ApresentaInformacao = DataBase.Connection.GetApresentaInformacao();
                Regras.Parametros.AtualizaParametros();

                Application.Run(new Visao.FO_Principal());

            }
            catch(Exception e)
            {
                Util.CL_Files.WriteException(e);
            }
            finally
            {
                if (connection)
                {
                    DataBase.Connection.CloseConnection();
                }
            }
            
            Util.CL_Files.WriteOnTheLog("--------------------------------------Finalizando sistema", Util.Global.TipoLog.SIMPLES);
        }
    }
}
