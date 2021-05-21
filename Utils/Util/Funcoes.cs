using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Funcoes
    {

        /// <summary>
        /// Método que trata o CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static string TrataCNPJ(string cnpj)
        {
            return cnpj.Replace(".", "").Replace("/", "").Replace("\\", "").Replace("-", "");
        }

        /// <summary>
        /// Método que valida se o arquivo que atualiza o der existe
        /// </summary>
        /// <returns></returns>
        public static bool ExisteArquivoAtualizarDER()
        {
            return File.Exists(Util.Global.app_DER_Atualizar_file);
        }

        /// <summary>
        /// Método que cria o arquivo de atualização do DER
        /// </summary>
        public static void CriarArquivoAtualizarDER()
        {
            try
            {
                if (!ExisteArquivoAtualizarDER())
                    File.Create(Util.Global.app_DER_Atualizar_file);
            }
            catch(Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Error: " + e.Message, Global.TipoLog.SIMPLES);
            }
        }

        /// <summary>
        /// Método que exlcui o arquivo que atualiza o der existe
        /// </summary>
        /// <returns></returns>
        public static void ExcluiArquivoAtualizarDER()
        {
            try
            {
                if (!ExisteArquivoAtualizarDER())
                    File.Delete(Util.Global.app_DER_Atualizar_file);
            }
            catch (Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Error: " + e.Message, Global.TipoLog.SIMPLES);
            }
        }

        /// <summary>
        /// Método que faz o sleep de um minuto
        /// </summary>
        public static void SleepASecond()
        {
            Sleep(1000);
        }

        /// <summary>
        /// Método que faz um sleep de x milisegundos
        /// </summary>
        /// <param name="milliseconds"></param>
        public static void Sleep(Int32 milliseconds)
        {
#if (!DEBUG)
            System.Threading.Thread.Sleep(milliseconds);
#endif
        }
    }
}
