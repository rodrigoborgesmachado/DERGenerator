using System.Collections.Generic;
using System.Windows.Forms;
using DAO;

namespace Visao
{
    public partial class UC_ControleTabelas : UserControl
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Controle da tela principal
        /// </summary>
        Visao.FO_Principal principal = null;

        /// <summary>
        /// Controle da classe do projeto
        /// </summary>
        Model.MD_Projeto projeto = null;

        /// <summary>
        /// Lista de tabelas
        /// </summary>
        List<Model.MD_Tabela> listaTabelas = new List<Model.MD_Tabela>();

        /// <summary>
        /// Lista de campos
        /// </summary>
        List<Model.MD_Campos> listaCampos = new List<Model.MD_Campos>();

        /// <summary>
        /// Propriedade que controla os eventos
        /// </summary>
        bool lockChange = false;

        #endregion Atributos e Propriedades

        #region Eventos

        /// <summary>
        /// Evento lançado quando alterado a seleção da tabela de tabelas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_tabelas_SelectionChanged(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().dgv_tabelas_SelectionChanged()", Util.Global.TipoLog.DETALHADO);
            if (lockChange) return;

            if (this.dgv_tabelas.SelectedRows.Count > 0)
            {
                this.CarregaCampos(this.listaTabelas[this.dgv_tabelas.SelectedRows[0].Index]);
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão fechar da tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fechar_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_fechar_Click()", Util.Global.TipoLog.DETALHADO);
            this.principal.FecharTela(Util.Enumerator.Telas.CONTROLE_TABELAS);
        }

        /// <summary>
        /// Evento lançado na busca de tabelas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_buscarTabela_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_buscarTabela_Click()", Util.Global.TipoLog.DETALHADO);
            if (string.IsNullOrEmpty(this.tbx_filtroTabela.Text))
            {
                Message.MensagemAlerta("O filtro não foi preenchido!");
            }
            else
            {
                lockChange = true;
                this.CarregaTabelas(this.tbx_filtroTabela.Text);
                lockChange = false;
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão para carregar tabela de Tabelas completa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_completaTabela_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_completaTabela_Click()", Util.Global.TipoLog.DETALHADO);
            lockChange = true;
            this.CarregaTabelas();
            lockChange = false;
        }

        /// <summary>
        /// Evento lançado no clique do botão para filtrar campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_buscarCampo_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_buscarCampo_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else if (string.IsNullOrEmpty(this.tbx_filtroCampo.Text))
            {
                Message.MensagemAlerta("O filtro não foi preenchido");
            }
            else
            {
                lockChange = true;
                this.CarregaCampos(this.listaTabelas[this.dgv_tabelas.SelectedRows[0].Index], this.tbx_filtroCampo.Text);
                lockChange = false;
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão de busca completa de campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_buscarCompleta_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_buscarCompleta_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else
            {
                lockChange = true;
                this.CarregaCampos(this.listaTabelas[this.dgv_tabelas.SelectedRows[0].Index]);
                lockChange = false;
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão de incluir tabela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_incluirTabela_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_incluirTabela_Click()", Util.Global.TipoLog.DETALHADO);
            this.principal.AbrirCadastroTabela(projeto, Util.Enumerator.Tarefa.INCLUIR, this);
        }

        /// <summary>
        /// Evento Lançado no clique do botão de incluir o relacionamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_incluirRelacionamento_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_incluirRelacionamento_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else if (this.dgv_campos.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione algum campo");
            }
            else
            {
                Model.MD_Campos campoOrigem = this.listaCampos[this.dgv_campos.SelectedRows[0].Index];
                FO_Relacionamento relacionamento = new FO_Relacionamento(Util.Enumerator.Tarefa.INCLUIR, campoOrigem, principal);
                relacionamento.ShowDialog();
            }
        }

        /// <summary>
        /// Evento lançado no clique da opção de visualizar a relacao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_visualizarRelacao_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_visualizarRelacao_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else if (this.dgv_campos.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione algum campo");
            }
            else
            {
                Model.MD_Campos campoOrigem = this.listaCampos[this.dgv_campos.SelectedRows[0].Index];
                Model.MD_Relacao relacao = Model.MD_Relacao.RetornaRelacao(campoOrigem);
                FO_Relacionamento relacionamento = new FO_Relacionamento(Util.Enumerator.Tarefa.VISUALIZAR, campoOrigem, principal, relacao);
                relacionamento.ShowDialog();
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão de incluir campo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_incluirCampo_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_incluirCampo_Click()", Util.Global.TipoLog.DETALHADO);
            if(this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione uma tabela");
            }
            else
            {
                Model.MD_Tabela tabela = this.listaTabelas[this.dgv_tabelas.SelectedRows[0].Index];
                this.principal.AbrirCadastroCampo(tabela, Util.Enumerator.Tarefa.INCLUIR, this);
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão de gerar script
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gerarScripts_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_gerarScripts_Click()", Util.Global.TipoLog.DETALHADO);
            principal.GerarScriptBD(projeto);
        }

        /// <summary>
        /// Evento lançado no cliquer do bõtão de gerar o DER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gerarDER_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_gerarDER_Click()", Util.Global.TipoLog.DETALHADO);
            principal.GerarDer(projeto);
        }

        /// <summary>
        /// Evento lançado no clique do botão de remover o campo selecionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_removerCampo_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_removerCampo_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else if (this.dgv_campos.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione algum campo");
            }
            else
            {
                int indexCampo = this.dgv_campos.SelectedRows[0].Index;
                Model.MD_Campos campo = this.listaCampos[indexCampo];
                if(Message.MensagemConfirmaçãoYesNo("Deseja realmente excluir o campo " + campo.DAO.Nome + "?") == DialogResult.Yes)
                {
                    if (campo.DAO.Delete())
                    {
                        this.dgv_campos.Rows.RemoveAt(indexCampo);
                        this.listaCampos.RemoveAt(indexCampo);
                        Message.MensagemSucesso("Excluído com sucesso");
                    }
                }
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão de editar o campo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_editarCampo_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_editarCampo_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else if (this.dgv_campos.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione algum campo");
            }
            else
            {
                Model.MD_Tabela tabela = this.listaTabelas[this.dgv_tabelas.SelectedRows[0].Index];
                Model.MD_Campos campo = this.listaCampos[this.dgv_campos.SelectedRows[0].Index];
                this.principal.AbrirCadastroCampo(tabela, Util.Enumerator.Tarefa.EDITAR, this, campo);
            }
        }

        /// <summary>
        /// Evento lançado no botão de adicionar campo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_adicionarCampo_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_adicionarCampo_Click()", Util.Global.TipoLog.DETALHADO);
            this.btn_incluirCampo_Click(sender, e);
        }

        /// <summary>
        /// Evento lançado no botão de remover tabela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_removerTabela_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_removerTabela_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else
            {
                int indexTabela = this.dgv_tabelas.SelectedRows[0].Index;
                Model.MD_Tabela tabela = this.listaTabelas[indexTabela];
                if (Message.MensagemConfirmaçãoYesNo("Deseja realmente excluir a tabela " + tabela.DAO.Nome + "?") == DialogResult.Yes)
                {
                    if (tabela.DAO.Delete())
                    {
                        this.dgv_tabelas.Rows.RemoveAt(indexTabela);
                        this.listaTabelas.RemoveAt(indexTabela);
                        this.dgv_campos.Rows.Clear();
                        this.dgv_campos.Columns.Clear();
                        Message.MensagemSucesso("Excluído com sucesso");
                    }
                }
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão para editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_editarTabela_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_editarTabela_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else
            {
                Model.MD_Tabela tabela = this.listaTabelas[this.dgv_tabelas.SelectedRows[0].Index];
                this.principal.AbrirCadastroTabela(projeto, Util.Enumerator.Tarefa.EDITAR, this, tabela);
            }
        }

        /// <summary>
        /// Evento lançado no clique de adicionar tabela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addTabela_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_addTabela_Click()", Util.Global.TipoLog.DETALHADO);
            this.btn_incluirTabela_Click(sender, e);
        }

        /// <summary>
        /// Evento lançado no clique da opção de visualizar campo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_visualizarCampo_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_visualizarCampo_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else if (this.dgv_campos.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione algum campo");
            }
            else
            {
                Model.MD_Tabela tabela = this.listaTabelas[this.dgv_tabelas.SelectedRows[0].Index];
                Model.MD_Campos campo = this.listaCampos[this.dgv_campos.SelectedRows[0].Index];
                this.principal.AbrirCadastroCampo(tabela, Util.Enumerator.Tarefa.VISUALIZAR, this, campo);
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão de abrir para visualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_visualizarTabela_Click(object sender, System.EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().btn_visualizarTabela_Click()", Util.Global.TipoLog.DETALHADO);
            if (this.dgv_tabelas.SelectedRows.Count == 0)
            {
                Message.MensagemAlerta("Selecione alguma tabela");
            }
            else
            {
                Model.MD_Tabela tabela = this.listaTabelas[this.dgv_tabelas.SelectedRows[0].Index];
                this.principal.AbrirCadastroTabela(projeto, Util.Enumerator.Tarefa.VISUALIZAR, this, tabela);
            }
        }

        #endregion Eventos

        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        /// <param name="projeto">Projeto</param>
        public UC_ControleTabelas(Visao.FO_Principal principal, Model.MD_Projeto projeto)
        {
            this.principal = principal;
            InitializeComponent();
            this.projeto = projeto;
            this.InicializaForm();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que inicializa o formulário
        /// </summary>
        public void InicializaForm()
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().InicializaForm()", Util.Global.TipoLog.DETALHADO);
            this.Dock = DockStyle.Fill;
            this.CarregaTabelas();
        }

        /// <summary>
        /// Método que carrega a tabela de Tabelas
        /// </summary>
        public void CarregaTabelas(string filtro = "")
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().CarregaTabelas()", Util.Global.TipoLog.DETALHADO);

            this.lockChange = true;
            this.dgv_tabelas.Columns.Clear();
            this.dgv_tabelas.Rows.Clear();

            this.dgv_tabelas.Columns.Add("Nome", "Nome");
            this.dgv_tabelas.Columns.Add("Descrição", "Descrição");

            if (string.IsNullOrEmpty(filtro))
            {
                this.listaTabelas = Model.MD_Tabela.RetornaTabelasProjeto(projeto.DAO.Codigo);
            }
            else
            {
                this.listaTabelas = Model.MD_Tabela.RetornaTabelasProjeto(filtro, projeto.DAO.Codigo);
            }
            int quantidade = this.listaTabelas.Count;
            BarraDeCarregamento barra = new BarraDeCarregamento(quantidade, "Quarregando talas");
            barra.Show();

            this.listaTabelas.ForEach(t => {
                CarregaTabelas(t);
                barra.AvancaBarra(1);
            });
            barra.Dispose();

            if(this.dgv_tabelas.Rows.Count > 0)
                this.dgv_tabelas.Rows[0].Selected = true;

            this.lockChange = false;

            if(this.listaTabelas.Count > 0)
            {
                this.CarregaCampos(this.listaTabelas[0]);
            }
        }

        /// <summary>
        /// Método que carrega as tabelas
        /// </summary>
        /// <param name="tabela"></param>
        public void CarregaTabelas(Model.MD_Tabela tabela)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().CarregaTabelas()", Util.Global.TipoLog.DETALHADO);
            List<string> list = new List<string>();
            list.Add(tabela.DAO.Nome);
            list.Add(tabela.DAO.Descricao);

            this.dgv_tabelas.Rows.Add(list.ToArray());
        }

        /// <summary>
        /// Método que carrega os campos
        /// </summary>
        public void CarregaCampos(Model.MD_Tabela tabela, string filtro = "")
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().CarregaCampos()", Util.Global.TipoLog.DETALHADO);

            this.lockChange = true;
            this.dgv_campos.Columns.Clear();
            this.dgv_campos.Rows.Clear();

            this.dgv_campos.Columns.Add("Nome", "Nome");
            this.dgv_campos.Columns.Add("Descrição", "Descrição");
            this.dgv_campos.Columns.Add("Primary Key", "Primary Key");
            this.dgv_campos.Columns.Add("NotNull", "NotNull");
            this.dgv_campos.Columns.Add("Default", "Default");
            this.dgv_campos.Columns.Add("Checked", "Checked");
            this.dgv_campos.Columns.Add("Precisão", "Precisão");
            this.dgv_campos.Columns.Add("Foreing key", "Foreing key");
            this.dgv_campos.Columns.Add("Domínio", "Domínio");
            this.dgv_campos.Columns.Add("Tamanho", "Tamanho");
            this.dgv_campos.Columns.Add("Unique", "Unique");

            if (string.IsNullOrEmpty(filtro))
            {
                this.listaCampos = Model.MD_Campos.RetornaCamposTabela(tabela.DAO.Codigo, projeto.DAO.Codigo);
            }
            else
            {
                this.listaCampos = Model.MD_Campos.RetornaCamposTabela(filtro, tabela.DAO.Codigo, projeto.DAO.Codigo);
            }

            this.listaCampos.ForEach(t => CarregaCampos(t));

            this.lockChange = false;
        }

        /// <summary>
        /// Método que carrega os campos
        /// </summary>
        /// <param name="tabela"></param>
        public void CarregaCampos(Model.MD_Campos campo)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().CarregaCampos()", Util.Global.TipoLog.DETALHADO);
            List<string> list = new List<string>();
            list.Add(campo.DAO.Nome); //Nome
            list.Add(campo.DAO.Comentario); //Descrição
            list.Add(campo.DAO.PrimaryKey ? "PK" : ""); //Primary key
            list.Add(campo.DAO.NotNull ? "NOTNULL" : ""); //NotNull
            list.Add(campo.DAO.Default == null ? "" : campo.DAO.Default.ToString()); //Default
            list.Add(string.IsNullOrEmpty(campo.DAO.Check) ? "" : campo.DAO.Check); //Check
            list.Add(campo.DAO.Precisao.ToString("0.00")); //Precisão
            list.Add(campo.DAO.ForeingKey ? "FK" : ""); //Foreing Key
            list.Add(campo.DAO.Dominio); //Domínio
            list.Add(campo.DAO.Tamanho.ToString("0000")); //Tamanho
            list.Add(campo.DAO.Unique ? "UNIQUE" : ""); // Unique

            this.dgv_campos.Rows.Add(list.ToArray());
        }

        /// <summary>
        /// Método que adiciona tabela na lista e na tabela da tela
        /// </summary>
        /// <param name="table"></param>
        public void AdicionaTabela(Model.MD_Tabela table)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().AdicionaTabela()", Util.Global.TipoLog.DETALHADO);
            this.listaTabelas.Add(table);
            CarregaTabelas(table);
        }

        /// <summary>
        /// Método que adiciona o campo na lista e carrega em tela
        /// </summary>
        /// <param name="campo"></param>
        public void AdicionaCampo(Model.MD_Campos campo)
        {
            Util.CL_Files.WriteOnTheLog("UC_ControleTabelas().AdicionaCampo()", Util.Global.TipoLog.DETALHADO);
            this.listaCampos.Add(campo);
            this.CarregaCampos(campo);
        }

        #endregion Métodos
        
    }
}
