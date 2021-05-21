using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visao
{
    public partial class FO_Consulta : Form
    {
        #region Construtores

        /// <summary>
        /// Construtor Principal da classe
        /// </summary>
        /// <param name="mensagem"></param>
        public FO_Consulta(string mensagem)
        {
            this.InitializeComponent();
            this.tbx_nomeCampo.Text = mensagem;
        }

        #endregion Construtores
    }
}
