using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visao
{
    public partial class FO_WebPage : Form
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Controle da página aberta
        /// </summary>
        private string url = string.Empty;

        private string html = string.Empty;

        #endregion Atributos e Propriedades

        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        /// <param name="url">Caminho do arquivo a ser colocado na tela</param>
        public FO_WebPage(string url)
        {
            this.url = url;
            InitializeComponent();
            IniciaForm();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que inicia o formulário
        /// </summary>
        private void IniciaForm()
        {
            Util.CL_Files.WriteOnTheLog("FO_WebSite().IniciaForm()", Util.Global.TipoLog.DETALHADO);

            html = string.Empty;

            foreach (string t in File.ReadAllLines(url))
            {
                html += t;
            }

            this.wbr_principal.DocumentText = html;
        }

        #endregion Métodos
    }
}
