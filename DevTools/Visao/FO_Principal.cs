using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Util.Enumerator;
using static Util.Global;

namespace Visao
{
    public partial class FO_Principal : Form
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Controle de eventos da tela
        /// </summary>
        bool lockchange = false;

        List<TabPage> pages = new List<TabPage>();
        /// <summary>
        /// Páginas abertas
        /// </summary>
        public List<TabPage> Pages
        {
            get
            {
                return pages;
            }
            set
            {
                this.pages = value;
            }
        }

        public Model.MD_Projeto projeto = new Model.MD_Projeto(-1);

        #endregion Atributos e Propriedades

        #region Eventos

        /// <summary>
        /// Evento lançado no clique do botão atualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.btn_atualizar_Click()", Util.Global.TipoLog.DETALHADO);

            this.CarregaTreeView();
        }

        /// <summary>
        /// Evento lançado no clique de novo projeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_novo_projeto_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.btn_novo_projeto_Click()", Util.Global.TipoLog.DETALHADO);

            AbrirJanelaDeCadastroProjeto(Util.Enumerator.Tarefa.INCLUIR);
        }

        /// <summary>
        /// CArrega informações após seleção
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trv_projetos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.trv_projetos_AfterSelect()", Util.Global.TipoLog.DETALHADO);

            if (this.trv_projetos.SelectedNode == null)
                return;

            string codigo = this.trv_projetos.SelectedNode.Tag.ToString();
            this.AbrirJanela(codigo);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_editarProjeto_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_editar_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();
            this.AbrirJanelaDeCadastroProjeto(Tarefa.EDITAR, int.Parse(codigo));
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_excluirProjeto_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_excluirProjeto_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();
            Model.MD_Projeto project = new Model.MD_Projeto(int.Parse(codigo));
            if (Visao.Message.MensagemConfirmaçãoYesNo("Deseja excluir o projeto: " + project.DAO.Nome + "?") == DialogResult.Yes)
            {
                if (project.DAO.Delete())
                    Visao.Message.MensagemSucesso("Excluído com sucesso!");
                else
                    Visao.Message.MensagemErro("Erro ao excluir!");

                this.CarregaTreeViewAutomaticamente();
                this.FecharTela(Telas.CADASTRO_ENTRADA);
            }
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_incluirTabela_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_incluirTabela_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();
            Model.MD_Projeto project = new Model.MD_Projeto(int.Parse(codigo));
            this.AbrirCadastroTabela(project, Tarefa.INCLUIR);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_gerarDER_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_gerarDER_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();
            Model.MD_Projeto project = new Model.MD_Projeto(int.Parse(codigo));
            this.GerarDer(project);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_gerarScriptsProjeto_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_gerarScriptsProjeto_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();
            Model.MD_Projeto project = new Model.MD_Projeto(int.Parse(codigo));
            this.GerarScriptBD(project);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_buscarTabelasBancoDados_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_buscarTabelaBancoDados_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();
            this.BuscarImportacaoBancoDados(int.Parse(codigo));
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_ativar_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_ativar_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();

            Model.MD_Projeto projeto = new Model.MD_Projeto(int.Parse(codigo));
            projeto.DAO.StatusProjeto = Status.ATIVO;
            projeto.DAO.Update();
            this.CarregaTreeViewAutomaticamente();
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_desativar_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_desativar_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();

            Model.MD_Projeto projeto = new Model.MD_Projeto(int.Parse(codigo));
            projeto.DAO.StatusProjeto = Status.DESATIVADO;
            projeto.DAO.Update();
            this.CarregaTreeViewAutomaticamente();
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_gerarDERProjeto_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_gerarDER_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();

            Model.MD_Projeto projeto = new Model.MD_Projeto(int.Parse(codigo));
            this.GerarDer(projeto);
        }

        /// <summary>
        /// Evento lançado na seleção do botão direito no tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_gerarClasses_selected_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.item_gerarClasses_selected_Click()", Util.Global.TipoLog.DETALHADO);

            MenuItem item = (MenuItem)sender;
            string codigo = item.Tag.ToString();

            Model.MD_Projeto projeto = new Model.MD_Projeto(int.Parse(codigo));
            this.GerarClasses(projeto);
        }

        /// <summary>
        /// Evento lançado quando a opção de log é alterada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsp_log_simples_CheckedChanged(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.Tsp_log_simples_CheckedChanged()", Util.Global.TipoLog.DETALHADO);

            if (lockchange)
                return;
            lockchange = true;

            tsp_log_simples.Checked = true;
            tsp_log_detalhado.Checked = !tsp_log_simples.Checked;
            DataBase.Connection.SetLog(TipoLog.SIMPLES);
            log_system = DataBase.Connection.GetLog();

            lockchange = false;
        }

        /// <summary>
        /// Evento lançado quando a opção de log é alterada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsp_log_detalhado_CheckedChanged(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.Tsp_log_detalhado_CheckedChanged()", Util.Global.TipoLog.DETALHADO);

            if (lockchange)
                return;
            lockchange = true;

            tsp_log_detalhado.Checked = true;
            tsp_log_simples.Checked = !tsp_log_detalhado.Checked;
            DataBase.Connection.SetLog(TipoLog.DETALHADO);
            log_system = DataBase.Connection.GetLog();

            lockchange = false;
        }

        /// <summary>
        /// Evento lançado no clique do botão expandir do treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_expandTree_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.btn_expandTree_Click()", Util.Global.TipoLog.DETALHADO);

            this.trv_projetos.ExpandAll();
        }

        /// <summary>
        /// Evento lançado no clique do botão recolher do treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_inplandsTree_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.btn_inplandsTree_Click()", Util.Global.TipoLog.DETALHADO);

            this.trv_projetos.CollapseAll();
        }

        /// <summary>
        /// Evento lançado no clique da opção de configurações
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsp_configurações_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.tsp_configurações_Click()", Util.Global.TipoLog.DETALHADO);

            this.AbrirConfiguracoes();
        }

        /// <summary>
        /// Evento lançado no clique do botão de gera hash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gerarHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FO_GerarHash gerar = new FO_GerarHash();
            gerar.ShowDialog();
        }

        /// <summary>
        /// Evento lançado no clique da opção de apresentar mensagens automaticamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apresentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.apresentaToolStripMenuItem_Click()", Util.Global.TipoLog.DETALHADO);

            if (lockchange)
                return;
            lockchange = true;

            tsp_apresenta.Checked = true;
            tsp_naoApresenta.Checked = !tsp_apresenta.Checked;
            DataBase.Connection.SetApresentaInformacao(Informacao.APRESETAR);
            Util.Global.ApresentaInformacao = DataBase.Connection.GetApresentaInformacao();

            lockchange = false;
        }

        /// <summary>
        /// Evento lançado no clique da opção de apresentar não mensagens automaticamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void naoApresentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.apresentaToolStripMenuItem_Click()", Util.Global.TipoLog.DETALHADO);

            if (lockchange)
                return;
            lockchange = true;

            tsp_apresenta.Checked = false;
            tsp_naoApresenta.Checked = !tsp_apresenta.Checked;
            DataBase.Connection.SetApresentaInformacao(Informacao.NAOAPRESENTAR);
            Util.Global.ApresentaInformacao = DataBase.Connection.GetApresentaInformacao();

            lockchange = false;
        }

        /// <summary>
        /// Evento lançado quando selecionado para carregar o treeview automaticamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspSim_CheckedChanged(object sender, EventArgs e)
        {
            Util.Global.CarregarAutomaticamente = tspSim.Checked ? Automatico.Automatico : Automatico.Manual;
        }

        /// <summary>
        /// Evento lançado quando selecionado para carrefar o treeview de forma manual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspNao_CheckedChanged(object sender, EventArgs e)
        {
            Util.Global.CarregarAutomaticamente = tspNao.Checked ? Automatico.Automatico : Automatico.Manual;
        }

        #endregion Eventos

        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        public FO_Principal()
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.FO_Principal()", Util.Global.TipoLog.DETALHADO);
            IniciaForm();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que faz a inicialização do Form
        /// </summary>
        public void IniciaForm()
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.IniciaForm()", Util.Global.TipoLog.DETALHADO);

            this.InitializeComponent();
            this.tspSim.Checked = Util.Global.CarregarAutomaticamente == Automatico.Automatico;
            this.tspNao.Checked = Util.Global.CarregarAutomaticamente == Automatico.Manual;
            this.lbl_valorVersao.Text = Regras.Versao.Version.DAO.Dercreator;
            this.CarregaMenuOpcoes();
            this.CarregaTreeView();
        }

        /// <summary>
        /// Método que carrega o menu de opções
        /// </summary>
        public void CarregaMenuOpcoes()
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.CarregaMenuOpcoes()", Util.Global.TipoLog.DETALHADO);

            lockchange = true;

            this.tsp_log_simples.Click += Tsp_log_simples_CheckedChanged;
            this.tsp_log_detalhado.Click += Tsp_log_detalhado_CheckedChanged;

            this.tsp_log_detalhado.Checked = Util.Global.log_system == Util.Global.TipoLog.DETALHADO;
            this.tsp_log_simples.Checked = !tsp_log_detalhado.Checked;

            this.tsp_apresenta.Checked = Util.Global.ApresentaInformacao == Informacao.APRESETAR;
            this.tsp_naoApresenta.Checked = !tsp_apresenta.Checked;

            lockchange = false;
        }

        /// <summary>
        /// Método que carrega o tree view
        /// </summary>
        private void CarregaTreeView()
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.CarregaTreeView()", Util.Global.TipoLog.DETALHADO);

            this.trv_projetos.Nodes.Clear();
            BarraDeCarregamento aguarde = new BarraDeCarregamento(this.BuscaTotalItensTreeView(), "Carregando TreeView");

            aguarde.Show();
            this.trv_projetos.Scrollable = true;

            this.trv_projetos.Nodes.Add(this.CarregaProjetos(ref aguarde));

            aguarde.Close();
            aguarde.Dispose();
            aguarde = null;
        }

        /// <summary>
        /// Método que retorna o total de itens no tree vies
        /// </summary>
        /// <returns></returns>
        public int BuscaTotalItensTreeView()
        {
            return 100;
        }

        /// <summary>
        /// Método que carrega os projetos cadastrados e os coloca no treeView
        /// </summary>
        private TreeNode CarregaProjetos(ref BarraDeCarregamento aguarde)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.CarregaProjetos()", Util.Global.TipoLog.DETALHADO);

            DbDataReader reader = DataBase.Connection.Select(new DAO.MD_Projeto().table.CreateCommandSQLTable());
            TreeNode projetos = new TreeNode("Projetos");

            while (reader.Read())
            {
                aguarde.AvancaBarra(1);
                Model.MD_Projeto project = new Model.MD_Projeto(int.Parse(reader["CODIGO"].ToString()));

                TreeNode node = new TreeNode(project.DAO.Nome);
                node.Tag = "projetos:" + project.DAO.Codigo;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;

                this.MontaMenuProjeto(project, ref node);

                if (project.DAO.StatusProjeto == Status.ATIVO)
                {
                    TreeNode tabela = new TreeNode("Tabelas");
                    tabela.Tag = "tabelas:" + project.DAO.Codigo; ;
                    this.MontaMenuTabela(project, ref tabela);
                    node.Nodes.Add(tabela);
                }

                projetos.Nodes.Add(node);
            }

            projetos.Tag = -1;
            projetos.Expand();
            reader.Close();

            return projetos;
        }

        /// <summary>
        /// Método que monta o meno do node
        /// </summary>
        /// <param name="node"></param>
        private void MontaMenuProjeto(Model.MD_Projeto project, ref TreeNode node)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.MontaMenuProjeto()", Util.Global.TipoLog.DETALHADO);

            ContextMenu menu = new ContextMenu();

            if (project.DAO.StatusProjeto == Status.ATIVO)
            {
                MenuItem item_editar = new MenuItem("Editar", item_editarProjeto_selected_Click);
                item_editar.Tag = project.DAO.Codigo;

                MenuItem item_excluir = new MenuItem("Excluir", item_excluirProjeto_selected_Click);
                item_excluir.Tag = project.DAO.Codigo;

                MenuItem item_buscarTabelasBanco = new MenuItem("Buscar tabelas de banco de dados", item_buscarTabelasBancoDados_selected_Click);
                item_buscarTabelasBanco.Tag = project.DAO.Codigo;

                MenuItem item_desativar = new MenuItem("Desativar", item_desativar_selected_Click);
                item_desativar.Tag = project.DAO.Codigo;

                MenuItem item_gerarDER = new MenuItem("Gerar DER", item_gerarDER_selected_Click);
                item_gerarDER.Tag = project.DAO.Codigo;

                MenuItem item_gerarScript = new MenuItem("Gerar Scripts", item_gerarScriptsProjeto_selected_Click);
                item_gerarScript.Tag = project.DAO.Codigo;

                MenuItem item_gerarclasses = new MenuItem("Gerar Classes - Comunicação BD", item_gerarClasses_selected_Click);
                item_gerarclasses.Tag = project.DAO.Codigo;

                menu.MenuItems.Add(item_buscarTabelasBanco);
                menu.MenuItems.Add(item_desativar);
                menu.MenuItems.Add(item_editar);
                menu.MenuItems.Add(item_excluir);
                menu.MenuItems.Add(item_gerarclasses);
                menu.MenuItems.Add(item_gerarDER);
                menu.MenuItems.Add(item_gerarScript);

            }
            else
            {
                MenuItem item_ativar = new MenuItem("Ativar", item_ativar_selected_Click);
                item_ativar.Tag = project.DAO.Codigo;

                menu.MenuItems.Add(item_ativar);
            }

            node.ContextMenu = menu;
        }

        /// <summary>
        /// Método que monta o meno do node
        /// </summary>
        /// <param name="node"></param>
        private void MontaMenuTabela(Model.MD_Projeto project, ref TreeNode node)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.MontaMenuTabela()", Util.Global.TipoLog.DETALHADO);

            ContextMenu menu = new ContextMenu();

            if (project.DAO.StatusProjeto == Status.ATIVO)
            {
                MenuItem item_buscarTabelasBanco = new MenuItem("Buscar tabelas de banco de dados", item_buscarTabelasBancoDados_selected_Click);
                item_buscarTabelasBanco.Tag = project.DAO.Codigo;

                MenuItem item_gerarDER = new MenuItem("Gerar DER", item_gerarDER_selected_Click);
                item_gerarDER.Tag = project.DAO.Codigo;

                MenuItem item_gerarScript = new MenuItem("Gerar Scripts", item_gerarScriptsProjeto_selected_Click);
                item_gerarScript.Tag = project.DAO.Codigo;

                menu.MenuItems.Add(item_buscarTabelasBanco);
                menu.MenuItems.Add(item_gerarDER);
                menu.MenuItems.Add(item_gerarScript);

            }
            else
            {
                MenuItem item_ativar = new MenuItem("Ativar", item_ativar_selected_Click);
                item_ativar.Tag = project.DAO.Codigo;

                menu.MenuItems.Add(item_ativar);
            }

            node.ContextMenu = menu;
        }

        /// <summary>
        /// Método que abre a janela de cadastro de projeto
        /// </summary>
        public void AbrirJanelaDeCadastroProjeto(Util.Enumerator.Tarefa tarefa, int codigo = -1)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirJanelaDeCadastroProjeto()", Util.Global.TipoLog.DETALHADO);

            Model.MD_Projeto proj = new Model.MD_Projeto(codigo);
            this.AbreJanela(new Visao.UC_CadastroProjeto(tarefa, proj, this), "Cadastro de Projeto", Telas.CADASTRO_ENTRADA);
        }

        /// <summary>
        /// Método que abre a janela de gerenciamento de tabelas
        /// </summary>
        /// <param name="codigo"></param>
        public void AbrirJanelaGerenciamentoTabelas(int codigo)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirJanelaGerenciamentoTabelas()", Util.Global.TipoLog.DETALHADO);

            Model.MD_Projeto proj = new Model.MD_Projeto(codigo);
            this.AbreJanela(new Visao.UC_ControleTabelas(this, new Model.MD_Projeto(codigo)), "Tabelas - Projeto: " + proj.DAO.Nome, Telas.CONTROLE_TABELAS);
        }

        /// <summary>
        /// Método que abre janela de cadastro de tabela
        /// </summary>
        /// <param name="project"></param>
        public void AbrirCadastroTabela(Model.MD_Projeto project, Tarefa tarefa, Visao.UC_ControleTabelas controletabelas = null, Model.MD_Tabela table = null)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirCadastroTabela()", Util.Global.TipoLog.DETALHADO);

            this.AbreJanela(new Visao.UC_CadastroTabela(tarefa, table == null ? new Model.MD_Tabela(-1, project.DAO.Codigo) : table, project, this, controletabelas), "Cadastro de Tabela", Telas.CADASTRO_TABELAS);
        }

        /// <summary>
        /// Método que abre a janela de cadastro de campo
        /// </summary>
        /// <param name="campo">Classe de instância do campo</param>
        /// <param name="tarefa"></param>
        public void AbrirCadastroCampo(Model.MD_Tabela tabela, Tarefa tarefa, UC_ControleTabelas controleTabelas = null, Model.MD_Campos campo = null)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirCadastroCampo()", Util.Global.TipoLog.DETALHADO);

            this.AbreJanela(new Visao.UC_CadastroCampos(tarefa, campo, tabela, this, controleTabelas), "Cadastro de Campos", Telas.CADASTRO_CAMPOS);
        }

        /// <summary>
        /// Método que abre a janela de cadastro de relação
        /// </summary>
        /// <param name="campo">Classe de instância do campo</param>
        /// <param name="tarefa"></param>
        public void AbrirCadastroRelacao(Model.MD_Campos campoOrigem, Tarefa tarefa, Model.MD_Relacao relacao = null)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirCadastroRelacao()", Util.Global.TipoLog.DETALHADO);

            Visao.FO_Relacionamento cadastro = null;

            if (relacao == null)
            {
                cadastro = new Visao.FO_Relacionamento(tarefa, campoOrigem, this);
            }
            else
            {
                cadastro = new Visao.FO_Relacionamento(tarefa, new Model.MD_Campos(relacao.DAO.CampoOrigem.Codigo, relacao.DAO.CampoOrigem.Tabela.Codigo, relacao.DAO.Projeto.Codigo), this, relacao);
            }

            cadastro.ShowDialog();
        }

        /// <summary>
        /// Método que abre a janela de cadastro de relação
        /// </summary>
        /// <param name="campo">Classe de instância do campo</param>
        /// <param name="tarefa"></param>
        public void AbrirDerNaAplicacao(Model.MD_Projeto projetoCorrente)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirDerNaAplicacao()", Util.Global.TipoLog.DETALHADO);

            Visao.UC_WEB web = new Visao.UC_WEB(Util.Global.app_DER_file_Table);
            this.AbreJanela(web, "DER - " + projetoCorrente.DAO.Nome, Util.Enumerator.Telas.CADASTRO_RELATORIO);
        }

        /// <summary>
        /// Método que abre a janela para visualização
        /// </summary>
        /// <param name="code">Código da janela a ser aberta</param>
        private void AbrirJanela(string code)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirJanela()", Util.Global.TipoLog.DETALHADO);

            string janela = code.Split(':')[0];

            if (janela.Equals("projetos"))
            {
                int cod = int.Parse(code.Split(':')[1]);
                this.AbrirJanelaDeCadastroProjeto(Tarefa.VISUALIZAR, cod);
            }
            else if (janela.Equals("tabelas"))
            {
                int projetos = int.Parse(code.Split(':')[1]);
                this.AbrirJanelaGerenciamentoTabelas(projetos);
            }
        }

        /// <summary>
        /// Método que abre uma nova aba no tab page
        /// </summary>
        /// <param name="control">User control a ser aberto dentro da page</param>
        /// <param name="titulo">Título da aba da página a ser aberta</param>
        private void AbreJanela(UserControl control, string titulo, Telas tag)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbreJanela()", Util.Global.TipoLog.DETALHADO);

            int index = 0;
            Telas tag_aberto = Telas.CADASTRO_ENTRADA;
            bool aberto = false;
            foreach (TabPage p in pages)
            {
                if ((int)p.Tag == (int)tag)
                {
                    tag_aberto = (Telas)p.Tag;
                    aberto = true;
                    break;
                }
                else index++;
            }

            if (aberto)
                FecharTela(tag_aberto);
            TabPage page = new TabPage(titulo);

            TabPage tabPage1 = new TabPage(titulo);
            tabPage1.Tag = (int)tag;
            pages.Add(tabPage1);

            tabPage1.Controls.Add(control);
            this.tbc_table_control.Controls.Add(tabPage1);
            this.tbc_table_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc_table_control.Name = titulo;

            index = 0;
            foreach (TabPage p in this.tbc_table_control.Controls)
            {
                if ((int)p.Tag == (int)tag)
                    break;
                index++;
            }

            this.tbc_table_control.TabIndex = index;
            this.tbc_table_control.SelectedIndex = index;
        }

        /// <summary>
        /// Método que fecha a tela
        /// </summary>
        /// <param name="tag"></param>
        public void FecharTela(Telas tag)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.FecharTela()", Util.Global.TipoLog.DETALHADO);

            if(pages.Count-1 > 0)
            {
                this.tbc_table_control.SelectedIndex = pages.Count-2;
            }

            int index = 0;
            foreach (TabPage p in pages)
            {
                if ((int)p.Tag == (int)tag)
                {
                    p.Dispose();
                    break;
                }
                else index++;
            }

            if (index < pages.Count)
            {
                pages.RemoveAt(index);
            }
        }

        /// <summary>
        /// Método que abre a busca de importação
        /// </summary>
        /// <param name="codigoProjeto">Código do projeto para se buscar a importação</param>
        private void BuscarImportacaoBancoDados(int codigoProjeto)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.BuscarImportacaoBancoDados()", Util.Global.TipoLog.DETALHADO);

            if (Regras.Importador.Importar(codigoProjeto))
            {
                Message.MensagemSucesso("Importação concluída sem erros!");
                CarregaTreeViewAutomaticamente();
            }
            else
            {
                Message.MensagemErro("Houve erros ao importar, verificar arquivo de log!");
                CarregaTreeViewAutomaticamente();
            }
        }

        /// <summary>
        /// Método que carrega o treeview se estiver automático
        /// </summary>
        public void CarregaTreeViewAutomaticamente()
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.CarregaTreeViewAutomaticamente()", Util.Global.TipoLog.DETALHADO);

            if (Util.Global.CarregarAutomaticamente == Automatico.Automatico)
            {
                this.CarregaTreeView();
            }
        }

        /// <summary>
        /// Método que abre a tela de configurações
        /// </summary>
        public void AbrirConfiguracoes()
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirConfiguracoes()", Util.Global.TipoLog.DETALHADO);

            FO_Configuracoes configuracoes = new FO_Configuracoes();
            configuracoes.Show();
        }

        /// <summary>
        /// Método que gera as classes de um projeto
        /// </summary>
        /// <param name="projeto"></param>
        public void GerarClasses(Model.MD_Projeto projeto)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.GerarClasses()", Util.Global.TipoLog.DETALHADO);

            string mensagemErro = string.Empty;
            List<Model.MD_Tabela> tabelas = projeto.GetTabelasProjeto();
            List<Model.MD_Tabela> tabelas_erro = projeto.GetTabelasProjeto();
            bool houveErro = false;

            if (tabelas.Count < 1)
            {
                Message.MensagemAlerta("Não há tabelas cadastradas para o projeto selecionado!");
            }
            else
            {
                BarraDeCarregamento barra = new BarraDeCarregamento(tabelas.Count * 2, "Gerando as classes");
                barra.Show();

                foreach (Model.MD_Tabela t in tabelas)
                {
                    barra.AvancaBarra(1);
                    if (!this.GerarClasse(t, ref mensagemErro))
                    {
                        tabelas_erro.Add(t);
                        houveErro = true;
                    }
                }

                barra.Close();
                barra.Dispose();
                barra = null;

                if (houveErro)
                {
                    string retorno = "Houve erro nas tabelas:" + Environment.NewLine;

                    foreach (Model.MD_Tabela t in tabelas_erro)
                    {
                        retorno += t.DAO.Nome + Environment.NewLine;
                    }

                    Message.MensagemAlerta(retorno);
                }
                else
                {
                    Message.MensagemSucesso("As classes foram geradas no diretórios: " + Util.Global.app_classesSaida_directory + "!");
                }
            }
        }

        /// <summary>
        /// Método que gera a classe da tabela passada por parâmetro
        /// </summary>
        /// <param name="tabela">Tabela a se gerar a classe</param>
        /// <param name="mensagem">mensagem caso tenha erro</param>
        /// <returns>True - sucesso; False - erro</returns>
        public bool GerarClasse(Model.MD_Tabela tabela, ref string mensagem)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.GerarClasse()", Util.Global.TipoLog.DETALHADO);

            DAO.MDN_Table table = Regras.ClassCreater.MontaTable(tabela);
            return Regras.ClassCreater.Create(table, ref mensagem);
        }

        /// <summary>
        /// Método que gera os scripts de banco
        /// </summary>
        /// <param name="projeto">Projeto para capturar as tabelas</param>
        public void GerarScriptBD(Model.MD_Projeto projeto, Model.MD_Tabela tabela)
        {
            FO_GerarScripts form = new FO_GerarScripts(projeto, tabela);
            form.Show();
        }

        /// <summary>
        /// Método que gera os scripts de banco
        /// </summary>
        /// <param name="projeto">Projeto para capturar as tabelas</param>
        public void GerarScriptBD(Model.MD_Projeto projeto)
        {
            FO_GerarScripts form = new FO_GerarScripts(projeto);
            form.Show();
        }

        /// <summary>
        /// Método que gera o relatório do projeto selecionado
        /// </summary>
        public void GerarDer(Model.MD_Projeto projetoCorrente)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.GerarDocumentoDER()", Util.Global.TipoLog.DETALHADO);

            if (Regras.DerCreator.Gerar(projetoCorrente))
            {
                Message.MensagemSucesso("Gerado com sucesso!");

                if (Message.MensagemConfirmaçãoYesNo("Deseja abrir o DER no Navegador?") == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Util.Global.app_DER_file_Table);
                }
                else
                {
                    Visao.UC_WEB web = new Visao.UC_WEB(Util.Global.app_DER_file_Table);
                    this.AbreJanela(web, "DER - " + projetoCorrente.DAO.Nome, Util.Enumerator.Telas.CADASTRO_RELATORIO);
                }
            }
            else
            {
                Message.MensagemErro("Houve erro ao gerar o relatório!");
            }
        }

        /// <summary>
        /// Método que abre o diretório para copiar os arquivos
        /// </summary>
        private void AbrirTelaSelecaoDestinoDirectoryArquivos(Util.Enumerator.ArquivosGerados arquivosGerados)
        {
            Util.CL_Files.WriteOnTheLog("FO_Principal.AbrirTelaSelecaoDestinoDirectoryArquivos()", Util.Global.TipoLog.DETALHADO);

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Selecionar o diretório de saída dos arquivos";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoSaida = string.Empty;
                caminhoSaida = dialog.SelectedPath.ToString();
                DirectoryInfo info = new DirectoryInfo(caminhoSaida);

                if (Regras.UtilHelper.GerarArquivos(arquivosGerados, info))
                {
                    Message.MensagemSucesso("Arquivos gerados com sucesso no diretório: " + info.FullName);
                }
                else
                {
                    Message.MensagemErro("Erro ao gerar os arquivos");
                }
            }
        }


        #endregion Métodos
        
    }
}
