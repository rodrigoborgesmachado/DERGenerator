namespace Visao
{
    partial class UC_ControleTabelas
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pan_tot = new System.Windows.Forms.Panel();
            this.pan_formularioGeral = new System.Windows.Forms.Panel();
            this.gpb_cadastroGeral = new System.Windows.Forms.GroupBox();
            this.pan_campos = new System.Windows.Forms.Panel();
            this.grb_campos = new System.Windows.Forms.GroupBox();
            this.pan_tabelaCampos = new System.Windows.Forms.Panel();
            this.btn_visualizarCampo = new System.Windows.Forms.Button();
            this.btn_removerCampo = new System.Windows.Forms.Button();
            this.btn_editarCampo = new System.Windows.Forms.Button();
            this.btn_adicionarCampo = new System.Windows.Forms.Button();
            this.btn_visualizarRelacao = new System.Windows.Forms.Button();
            this.dgv_campos = new System.Windows.Forms.DataGridView();
            this.btn_incluirCampo = new System.Windows.Forms.Button();
            this.btn_incluirRelacionamento = new System.Windows.Forms.Button();
            this.pan_filtroCampos = new System.Windows.Forms.Panel();
            this.grb_filtroCampos = new System.Windows.Forms.GroupBox();
            this.btn_buscarCompleta = new System.Windows.Forms.Button();
            this.btn_buscarCampo = new System.Windows.Forms.Button();
            this.tbx_filtroCampo = new System.Windows.Forms.TextBox();
            this.lbl_nomeCodigoCampo = new System.Windows.Forms.Label();
            this.pan_tabelas = new System.Windows.Forms.Panel();
            this.grb_tabelas = new System.Windows.Forms.GroupBox();
            this.pan_tabelaTabelas = new System.Windows.Forms.Panel();
            this.btn_visualizarTabela = new System.Windows.Forms.Button();
            this.btn_removerTabela = new System.Windows.Forms.Button();
            this.btn_editarTabela = new System.Windows.Forms.Button();
            this.btn_addTabela = new System.Windows.Forms.Button();
            this.dgv_tabelas = new System.Windows.Forms.DataGridView();
            this.btn_incluirTabela = new System.Windows.Forms.Button();
            this.pan_filtroTabela = new System.Windows.Forms.Panel();
            this.grb_filtroTabela = new System.Windows.Forms.GroupBox();
            this.btn_completaTabela = new System.Windows.Forms.Button();
            this.btn_buscarTabela = new System.Windows.Forms.Button();
            this.tbx_filtroTabela = new System.Windows.Forms.TextBox();
            this.lbl_codigoDescricaoTabela = new System.Windows.Forms.Label();
            this.btn_gerarScripts = new System.Windows.Forms.Button();
            this.btn_gerarDER = new System.Windows.Forms.Button();
            this.pan_botton = new System.Windows.Forms.Panel();
            this.pan_top = new System.Windows.Forms.Panel();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.pan_tot.SuspendLayout();
            this.pan_formularioGeral.SuspendLayout();
            this.gpb_cadastroGeral.SuspendLayout();
            this.pan_campos.SuspendLayout();
            this.grb_campos.SuspendLayout();
            this.pan_tabelaCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_campos)).BeginInit();
            this.pan_filtroCampos.SuspendLayout();
            this.grb_filtroCampos.SuspendLayout();
            this.pan_tabelas.SuspendLayout();
            this.grb_tabelas.SuspendLayout();
            this.pan_tabelaTabelas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tabelas)).BeginInit();
            this.pan_filtroTabela.SuspendLayout();
            this.grb_filtroTabela.SuspendLayout();
            this.pan_botton.SuspendLayout();
            this.pan_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_tot
            // 
            this.pan_tot.AutoScroll = true;
            this.pan_tot.Controls.Add(this.pan_formularioGeral);
            this.pan_tot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_tot.Location = new System.Drawing.Point(0, 20);
            this.pan_tot.Name = "pan_tot";
            this.pan_tot.Size = new System.Drawing.Size(740, 507);
            this.pan_tot.TabIndex = 19;
            // 
            // pan_formularioGeral
            // 
            this.pan_formularioGeral.AllowDrop = true;
            this.pan_formularioGeral.AutoScroll = true;
            this.pan_formularioGeral.Controls.Add(this.gpb_cadastroGeral);
            this.pan_formularioGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_formularioGeral.Location = new System.Drawing.Point(0, 0);
            this.pan_formularioGeral.Name = "pan_formularioGeral";
            this.pan_formularioGeral.Size = new System.Drawing.Size(740, 507);
            this.pan_formularioGeral.TabIndex = 0;
            // 
            // gpb_cadastroGeral
            // 
            this.gpb_cadastroGeral.Controls.Add(this.pan_campos);
            this.gpb_cadastroGeral.Controls.Add(this.pan_tabelas);
            this.gpb_cadastroGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpb_cadastroGeral.Location = new System.Drawing.Point(0, 0);
            this.gpb_cadastroGeral.Name = "gpb_cadastroGeral";
            this.gpb_cadastroGeral.Size = new System.Drawing.Size(740, 507);
            this.gpb_cadastroGeral.TabIndex = 0;
            this.gpb_cadastroGeral.TabStop = false;
            this.gpb_cadastroGeral.Text = "Gerenciamento de tabelas";
            // 
            // pan_campos
            // 
            this.pan_campos.AutoScroll = true;
            this.pan_campos.Controls.Add(this.grb_campos);
            this.pan_campos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_campos.Location = new System.Drawing.Point(341, 19);
            this.pan_campos.Name = "pan_campos";
            this.pan_campos.Size = new System.Drawing.Size(396, 485);
            this.pan_campos.TabIndex = 1;
            // 
            // grb_campos
            // 
            this.grb_campos.Controls.Add(this.pan_tabelaCampos);
            this.grb_campos.Controls.Add(this.pan_filtroCampos);
            this.grb_campos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_campos.Location = new System.Drawing.Point(0, 0);
            this.grb_campos.Name = "grb_campos";
            this.grb_campos.Size = new System.Drawing.Size(396, 485);
            this.grb_campos.TabIndex = 0;
            this.grb_campos.TabStop = false;
            this.grb_campos.Text = "Campos";
            // 
            // pan_tabelaCampos
            // 
            this.pan_tabelaCampos.Controls.Add(this.btn_visualizarCampo);
            this.pan_tabelaCampos.Controls.Add(this.btn_removerCampo);
            this.pan_tabelaCampos.Controls.Add(this.btn_editarCampo);
            this.pan_tabelaCampos.Controls.Add(this.btn_adicionarCampo);
            this.pan_tabelaCampos.Controls.Add(this.btn_visualizarRelacao);
            this.pan_tabelaCampos.Controls.Add(this.dgv_campos);
            this.pan_tabelaCampos.Controls.Add(this.btn_incluirCampo);
            this.pan_tabelaCampos.Controls.Add(this.btn_incluirRelacionamento);
            this.pan_tabelaCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_tabelaCampos.Location = new System.Drawing.Point(3, 115);
            this.pan_tabelaCampos.Name = "pan_tabelaCampos";
            this.pan_tabelaCampos.Size = new System.Drawing.Size(390, 367);
            this.pan_tabelaCampos.TabIndex = 19;
            // 
            // btn_visualizarCampo
            // 
            this.btn_visualizarCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_visualizarCampo.BackgroundImage = DERGenerator.Properties.Resources.eye_100px20x20;
            this.btn_visualizarCampo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_visualizarCampo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_visualizarCampo.Location = new System.Drawing.Point(367, 84);
            this.btn_visualizarCampo.Name = "btn_visualizarCampo";
            this.btn_visualizarCampo.Size = new System.Drawing.Size(20, 20);
            this.btn_visualizarCampo.TabIndex = 30;
            this.btn_visualizarCampo.UseVisualStyleBackColor = true;
            this.btn_visualizarCampo.Click += new System.EventHandler(this.btn_visualizarCampo_Click);
            // 
            // btn_removerCampo
            // 
            this.btn_removerCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_removerCampo.BackgroundImage = DERGenerator.Properties.Resources.close_outline_100px20x20;
            this.btn_removerCampo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_removerCampo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_removerCampo.Location = new System.Drawing.Point(367, 58);
            this.btn_removerCampo.Name = "btn_removerCampo";
            this.btn_removerCampo.Size = new System.Drawing.Size(20, 20);
            this.btn_removerCampo.TabIndex = 27;
            this.btn_removerCampo.UseVisualStyleBackColor = true;
            this.btn_removerCampo.Click += new System.EventHandler(this.btn_removerCampo_Click);
            // 
            // btn_editarCampo
            // 
            this.btn_editarCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editarCampo.BackgroundImage = DERGenerator.Properties.Resources.lead_pencil_100px20x20;
            this.btn_editarCampo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_editarCampo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_editarCampo.Location = new System.Drawing.Point(367, 32);
            this.btn_editarCampo.Name = "btn_editarCampo";
            this.btn_editarCampo.Size = new System.Drawing.Size(20, 20);
            this.btn_editarCampo.TabIndex = 26;
            this.btn_editarCampo.UseVisualStyleBackColor = true;
            this.btn_editarCampo.Click += new System.EventHandler(this.btn_editarCampo_Click);
            // 
            // btn_adicionarCampo
            // 
            this.btn_adicionarCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_adicionarCampo.BackgroundImage = DERGenerator.Properties.Resources.plus20x20;
            this.btn_adicionarCampo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_adicionarCampo.Location = new System.Drawing.Point(367, 6);
            this.btn_adicionarCampo.Name = "btn_adicionarCampo";
            this.btn_adicionarCampo.Size = new System.Drawing.Size(20, 20);
            this.btn_adicionarCampo.TabIndex = 25;
            this.btn_adicionarCampo.UseVisualStyleBackColor = true;
            this.btn_adicionarCampo.Click += new System.EventHandler(this.btn_adicionarCampo_Click);
            // 
            // btn_visualizarRelacao
            // 
            this.btn_visualizarRelacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_visualizarRelacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_visualizarRelacao.Location = new System.Drawing.Point(50, 335);
            this.btn_visualizarRelacao.Name = "btn_visualizarRelacao";
            this.btn_visualizarRelacao.Size = new System.Drawing.Size(117, 29);
            this.btn_visualizarRelacao.TabIndex = 18;
            this.btn_visualizarRelacao.Text = "Visualizar Relação";
            this.btn_visualizarRelacao.UseVisualStyleBackColor = true;
            this.btn_visualizarRelacao.Click += new System.EventHandler(this.btn_visualizarRelacao_Click);
            // 
            // dgv_campos
            // 
            this.dgv_campos.AllowUserToAddRows = false;
            this.dgv_campos.AllowUserToDeleteRows = false;
            this.dgv_campos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_campos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_campos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_campos.BackgroundColor = System.Drawing.Color.White;
            this.dgv_campos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_campos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_campos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_campos.EnableHeadersVisualStyles = false;
            this.dgv_campos.Location = new System.Drawing.Point(3, 6);
            this.dgv_campos.MultiSelect = false;
            this.dgv_campos.Name = "dgv_campos";
            this.dgv_campos.RowHeadersVisible = false;
            this.dgv_campos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_campos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_campos.ShowCellErrors = false;
            this.dgv_campos.ShowCellToolTips = false;
            this.dgv_campos.Size = new System.Drawing.Size(358, 323);
            this.dgv_campos.StandardTab = true;
            this.dgv_campos.TabIndex = 15;
            // 
            // btn_incluirCampo
            // 
            this.btn_incluirCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_incluirCampo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_incluirCampo.Location = new System.Drawing.Point(290, 335);
            this.btn_incluirCampo.Name = "btn_incluirCampo";
            this.btn_incluirCampo.Size = new System.Drawing.Size(97, 29);
            this.btn_incluirCampo.TabIndex = 16;
            this.btn_incluirCampo.Text = "Incluir Campo";
            this.btn_incluirCampo.UseVisualStyleBackColor = true;
            this.btn_incluirCampo.Click += new System.EventHandler(this.btn_incluirCampo_Click);
            // 
            // btn_incluirRelacionamento
            // 
            this.btn_incluirRelacionamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_incluirRelacionamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_incluirRelacionamento.Location = new System.Drawing.Point(173, 335);
            this.btn_incluirRelacionamento.Name = "btn_incluirRelacionamento";
            this.btn_incluirRelacionamento.Size = new System.Drawing.Size(106, 29);
            this.btn_incluirRelacionamento.TabIndex = 17;
            this.btn_incluirRelacionamento.Text = "Incluir Relação";
            this.btn_incluirRelacionamento.UseVisualStyleBackColor = true;
            this.btn_incluirRelacionamento.Click += new System.EventHandler(this.btn_incluirRelacionamento_Click);
            // 
            // pan_filtroCampos
            // 
            this.pan_filtroCampos.Controls.Add(this.grb_filtroCampos);
            this.pan_filtroCampos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_filtroCampos.Location = new System.Drawing.Point(3, 19);
            this.pan_filtroCampos.Name = "pan_filtroCampos";
            this.pan_filtroCampos.Size = new System.Drawing.Size(390, 96);
            this.pan_filtroCampos.TabIndex = 18;
            // 
            // grb_filtroCampos
            // 
            this.grb_filtroCampos.Controls.Add(this.btn_buscarCompleta);
            this.grb_filtroCampos.Controls.Add(this.btn_buscarCampo);
            this.grb_filtroCampos.Controls.Add(this.tbx_filtroCampo);
            this.grb_filtroCampos.Controls.Add(this.lbl_nomeCodigoCampo);
            this.grb_filtroCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_filtroCampos.Location = new System.Drawing.Point(0, 0);
            this.grb_filtroCampos.Name = "grb_filtroCampos";
            this.grb_filtroCampos.Size = new System.Drawing.Size(390, 96);
            this.grb_filtroCampos.TabIndex = 1;
            this.grb_filtroCampos.TabStop = false;
            this.grb_filtroCampos.Text = "Filtro";
            // 
            // btn_buscarCompleta
            // 
            this.btn_buscarCompleta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscarCompleta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_buscarCompleta.Location = new System.Drawing.Point(309, 61);
            this.btn_buscarCompleta.Name = "btn_buscarCompleta";
            this.btn_buscarCompleta.Size = new System.Drawing.Size(75, 29);
            this.btn_buscarCompleta.TabIndex = 61;
            this.btn_buscarCompleta.Text = "Completa";
            this.btn_buscarCompleta.UseVisualStyleBackColor = true;
            this.btn_buscarCompleta.Click += new System.EventHandler(this.btn_buscarCompleta_Click);
            // 
            // btn_buscarCampo
            // 
            this.btn_buscarCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscarCampo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_buscarCampo.Location = new System.Drawing.Point(229, 61);
            this.btn_buscarCampo.Name = "btn_buscarCampo";
            this.btn_buscarCampo.Size = new System.Drawing.Size(75, 29);
            this.btn_buscarCampo.TabIndex = 60;
            this.btn_buscarCampo.Text = "Buscar";
            this.btn_buscarCampo.UseVisualStyleBackColor = true;
            this.btn_buscarCampo.Click += new System.EventHandler(this.btn_buscarCampo_Click);
            // 
            // tbx_filtroCampo
            // 
            this.tbx_filtroCampo.Location = new System.Drawing.Point(123, 16);
            this.tbx_filtroCampo.Name = "tbx_filtroCampo";
            this.tbx_filtroCampo.Size = new System.Drawing.Size(187, 23);
            this.tbx_filtroCampo.TabIndex = 59;
            // 
            // lbl_nomeCodigoCampo
            // 
            this.lbl_nomeCodigoCampo.AutoSize = true;
            this.lbl_nomeCodigoCampo.Location = new System.Drawing.Point(12, 19);
            this.lbl_nomeCodigoCampo.Name = "lbl_nomeCodigoCampo";
            this.lbl_nomeCodigoCampo.Size = new System.Drawing.Size(105, 16);
            this.lbl_nomeCodigoCampo.TabIndex = 58;
            this.lbl_nomeCodigoCampo.Text = "Nome ou código:";
            // 
            // pan_tabelas
            // 
            this.pan_tabelas.AutoScroll = true;
            this.pan_tabelas.Controls.Add(this.grb_tabelas);
            this.pan_tabelas.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_tabelas.Location = new System.Drawing.Point(3, 19);
            this.pan_tabelas.Name = "pan_tabelas";
            this.pan_tabelas.Size = new System.Drawing.Size(338, 485);
            this.pan_tabelas.TabIndex = 0;
            // 
            // grb_tabelas
            // 
            this.grb_tabelas.Controls.Add(this.pan_tabelaTabelas);
            this.grb_tabelas.Controls.Add(this.pan_filtroTabela);
            this.grb_tabelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_tabelas.Location = new System.Drawing.Point(0, 0);
            this.grb_tabelas.Name = "grb_tabelas";
            this.grb_tabelas.Size = new System.Drawing.Size(338, 485);
            this.grb_tabelas.TabIndex = 0;
            this.grb_tabelas.TabStop = false;
            this.grb_tabelas.Text = "Tabelas";
            // 
            // pan_tabelaTabelas
            // 
            this.pan_tabelaTabelas.Controls.Add(this.btn_visualizarTabela);
            this.pan_tabelaTabelas.Controls.Add(this.btn_removerTabela);
            this.pan_tabelaTabelas.Controls.Add(this.btn_editarTabela);
            this.pan_tabelaTabelas.Controls.Add(this.btn_addTabela);
            this.pan_tabelaTabelas.Controls.Add(this.dgv_tabelas);
            this.pan_tabelaTabelas.Controls.Add(this.btn_incluirTabela);
            this.pan_tabelaTabelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_tabelaTabelas.Location = new System.Drawing.Point(3, 115);
            this.pan_tabelaTabelas.Name = "pan_tabelaTabelas";
            this.pan_tabelaTabelas.Size = new System.Drawing.Size(332, 367);
            this.pan_tabelaTabelas.TabIndex = 17;
            // 
            // btn_visualizarTabela
            // 
            this.btn_visualizarTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_visualizarTabela.BackgroundImage = DERGenerator.Properties.Resources.eye_100px20x20;
            this.btn_visualizarTabela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_visualizarTabela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_visualizarTabela.Location = new System.Drawing.Point(307, 84);
            this.btn_visualizarTabela.Name = "btn_visualizarTabela";
            this.btn_visualizarTabela.Size = new System.Drawing.Size(20, 20);
            this.btn_visualizarTabela.TabIndex = 30;
            this.btn_visualizarTabela.UseVisualStyleBackColor = true;
            this.btn_visualizarTabela.Click += new System.EventHandler(this.btn_visualizarTabela_Click);
            // 
            // btn_removerTabela
            // 
            this.btn_removerTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_removerTabela.BackgroundImage = DERGenerator.Properties.Resources.close_outline_100px20x20;
            this.btn_removerTabela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_removerTabela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_removerTabela.Location = new System.Drawing.Point(307, 58);
            this.btn_removerTabela.Name = "btn_removerTabela";
            this.btn_removerTabela.Size = new System.Drawing.Size(20, 20);
            this.btn_removerTabela.TabIndex = 24;
            this.btn_removerTabela.UseVisualStyleBackColor = true;
            this.btn_removerTabela.Click += new System.EventHandler(this.btn_removerTabela_Click);
            // 
            // btn_editarTabela
            // 
            this.btn_editarTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editarTabela.BackgroundImage = DERGenerator.Properties.Resources.lead_pencil_100px20x20;
            this.btn_editarTabela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_editarTabela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_editarTabela.Location = new System.Drawing.Point(307, 32);
            this.btn_editarTabela.Name = "btn_editarTabela";
            this.btn_editarTabela.Size = new System.Drawing.Size(20, 20);
            this.btn_editarTabela.TabIndex = 23;
            this.btn_editarTabela.UseVisualStyleBackColor = true;
            this.btn_editarTabela.Click += new System.EventHandler(this.btn_editarTabela_Click);
            // 
            // btn_addTabela
            // 
            this.btn_addTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addTabela.BackgroundImage = DERGenerator.Properties.Resources.plus20x20;
            this.btn_addTabela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_addTabela.Location = new System.Drawing.Point(307, 6);
            this.btn_addTabela.Name = "btn_addTabela";
            this.btn_addTabela.Size = new System.Drawing.Size(20, 20);
            this.btn_addTabela.TabIndex = 22;
            this.btn_addTabela.UseVisualStyleBackColor = true;
            this.btn_addTabela.Click += new System.EventHandler(this.btn_addTabela_Click);
            // 
            // dgv_tabelas
            // 
            this.dgv_tabelas.AllowUserToAddRows = false;
            this.dgv_tabelas.AllowUserToDeleteRows = false;
            this.dgv_tabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_tabelas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_tabelas.BackgroundColor = System.Drawing.Color.White;
            this.dgv_tabelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_tabelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_tabelas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_tabelas.EnableHeadersVisualStyles = false;
            this.dgv_tabelas.Location = new System.Drawing.Point(3, 6);
            this.dgv_tabelas.MultiSelect = false;
            this.dgv_tabelas.Name = "dgv_tabelas";
            this.dgv_tabelas.RowHeadersVisible = false;
            this.dgv_tabelas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_tabelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_tabelas.ShowCellErrors = false;
            this.dgv_tabelas.ShowCellToolTips = false;
            this.dgv_tabelas.Size = new System.Drawing.Size(301, 323);
            this.dgv_tabelas.StandardTab = true;
            this.dgv_tabelas.TabIndex = 14;
            this.dgv_tabelas.SelectionChanged += new System.EventHandler(this.dgv_tabelas_SelectionChanged);
            // 
            // btn_incluirTabela
            // 
            this.btn_incluirTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_incluirTabela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_incluirTabela.Location = new System.Drawing.Point(232, 335);
            this.btn_incluirTabela.Name = "btn_incluirTabela";
            this.btn_incluirTabela.Size = new System.Drawing.Size(97, 29);
            this.btn_incluirTabela.TabIndex = 15;
            this.btn_incluirTabela.Text = "Incluir Tabela";
            this.btn_incluirTabela.UseVisualStyleBackColor = true;
            this.btn_incluirTabela.Click += new System.EventHandler(this.btn_incluirTabela_Click);
            // 
            // pan_filtroTabela
            // 
            this.pan_filtroTabela.Controls.Add(this.grb_filtroTabela);
            this.pan_filtroTabela.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_filtroTabela.Location = new System.Drawing.Point(3, 19);
            this.pan_filtroTabela.Name = "pan_filtroTabela";
            this.pan_filtroTabela.Size = new System.Drawing.Size(332, 96);
            this.pan_filtroTabela.TabIndex = 16;
            // 
            // grb_filtroTabela
            // 
            this.grb_filtroTabela.Controls.Add(this.btn_completaTabela);
            this.grb_filtroTabela.Controls.Add(this.btn_buscarTabela);
            this.grb_filtroTabela.Controls.Add(this.tbx_filtroTabela);
            this.grb_filtroTabela.Controls.Add(this.lbl_codigoDescricaoTabela);
            this.grb_filtroTabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_filtroTabela.Location = new System.Drawing.Point(0, 0);
            this.grb_filtroTabela.Name = "grb_filtroTabela";
            this.grb_filtroTabela.Size = new System.Drawing.Size(332, 96);
            this.grb_filtroTabela.TabIndex = 0;
            this.grb_filtroTabela.TabStop = false;
            this.grb_filtroTabela.Text = "Filtro";
            // 
            // btn_completaTabela
            // 
            this.btn_completaTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_completaTabela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_completaTabela.Location = new System.Drawing.Point(252, 61);
            this.btn_completaTabela.Name = "btn_completaTabela";
            this.btn_completaTabela.Size = new System.Drawing.Size(75, 29);
            this.btn_completaTabela.TabIndex = 57;
            this.btn_completaTabela.Text = "Completa";
            this.btn_completaTabela.UseVisualStyleBackColor = true;
            this.btn_completaTabela.Click += new System.EventHandler(this.btn_completaTabela_Click);
            // 
            // btn_buscarTabela
            // 
            this.btn_buscarTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscarTabela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_buscarTabela.Location = new System.Drawing.Point(172, 61);
            this.btn_buscarTabela.Name = "btn_buscarTabela";
            this.btn_buscarTabela.Size = new System.Drawing.Size(75, 29);
            this.btn_buscarTabela.TabIndex = 56;
            this.btn_buscarTabela.Text = "Buscar";
            this.btn_buscarTabela.UseVisualStyleBackColor = true;
            this.btn_buscarTabela.Click += new System.EventHandler(this.btn_buscarTabela_Click);
            // 
            // tbx_filtroTabela
            // 
            this.tbx_filtroTabela.Location = new System.Drawing.Point(117, 16);
            this.tbx_filtroTabela.Name = "tbx_filtroTabela";
            this.tbx_filtroTabela.Size = new System.Drawing.Size(187, 23);
            this.tbx_filtroTabela.TabIndex = 37;
            // 
            // lbl_codigoDescricaoTabela
            // 
            this.lbl_codigoDescricaoTabela.AutoSize = true;
            this.lbl_codigoDescricaoTabela.Location = new System.Drawing.Point(6, 19);
            this.lbl_codigoDescricaoTabela.Name = "lbl_codigoDescricaoTabela";
            this.lbl_codigoDescricaoTabela.Size = new System.Drawing.Size(105, 16);
            this.lbl_codigoDescricaoTabela.TabIndex = 36;
            this.lbl_codigoDescricaoTabela.Text = "Nome ou código:";
            // 
            // btn_gerarScripts
            // 
            this.btn_gerarScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_gerarScripts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_gerarScripts.Location = new System.Drawing.Point(538, 3);
            this.btn_gerarScripts.Name = "btn_gerarScripts";
            this.btn_gerarScripts.Size = new System.Drawing.Size(96, 29);
            this.btn_gerarScripts.TabIndex = 8;
            this.btn_gerarScripts.Text = "Gerar Scripts";
            this.btn_gerarScripts.UseVisualStyleBackColor = true;
            this.btn_gerarScripts.Click += new System.EventHandler(this.btn_gerarScripts_Click);
            // 
            // btn_gerarDER
            // 
            this.btn_gerarDER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_gerarDER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_gerarDER.Location = new System.Drawing.Point(640, 3);
            this.btn_gerarDER.Name = "btn_gerarDER";
            this.btn_gerarDER.Size = new System.Drawing.Size(97, 29);
            this.btn_gerarDER.TabIndex = 7;
            this.btn_gerarDER.Text = "Gerar DER";
            this.btn_gerarDER.UseVisualStyleBackColor = true;
            this.btn_gerarDER.Click += new System.EventHandler(this.btn_gerarDER_Click);
            // 
            // pan_botton
            // 
            this.pan_botton.Controls.Add(this.btn_gerarScripts);
            this.pan_botton.Controls.Add(this.btn_gerarDER);
            this.pan_botton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_botton.Location = new System.Drawing.Point(0, 527);
            this.pan_botton.Name = "pan_botton";
            this.pan_botton.Size = new System.Drawing.Size(740, 35);
            this.pan_botton.TabIndex = 20;
            // 
            // pan_top
            // 
            this.pan_top.Controls.Add(this.btn_fechar);
            this.pan_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_top.Location = new System.Drawing.Point(0, 0);
            this.pan_top.Name = "pan_top";
            this.pan_top.Size = new System.Drawing.Size(740, 20);
            this.pan_top.TabIndex = 21;
            // 
            // btn_fechar
            // 
            this.btn_fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_fechar.BackColor = System.Drawing.Color.Red;
            this.btn_fechar.BackgroundImage = DERGenerator.Properties.Resources.window_close_100px20x20;
            this.btn_fechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_fechar.Location = new System.Drawing.Point(720, 0);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(20, 20);
            this.btn_fechar.TabIndex = 17;
            this.btn_fechar.UseVisualStyleBackColor = false;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // UC_ControleTabelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.pan_tot);
            this.Controls.Add(this.pan_botton);
            this.Controls.Add(this.pan_top);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Name = "UC_ControleTabelas";
            this.Size = new System.Drawing.Size(740, 562);
            this.pan_tot.ResumeLayout(false);
            this.pan_formularioGeral.ResumeLayout(false);
            this.gpb_cadastroGeral.ResumeLayout(false);
            this.pan_campos.ResumeLayout(false);
            this.grb_campos.ResumeLayout(false);
            this.pan_tabelaCampos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_campos)).EndInit();
            this.pan_filtroCampos.ResumeLayout(false);
            this.grb_filtroCampos.ResumeLayout(false);
            this.grb_filtroCampos.PerformLayout();
            this.pan_tabelas.ResumeLayout(false);
            this.grb_tabelas.ResumeLayout(false);
            this.pan_tabelaTabelas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tabelas)).EndInit();
            this.pan_filtroTabela.ResumeLayout(false);
            this.grb_filtroTabela.ResumeLayout(false);
            this.grb_filtroTabela.PerformLayout();
            this.pan_botton.ResumeLayout(false);
            this.pan_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Panel pan_tot;
        private System.Windows.Forms.Panel pan_formularioGeral;
        private System.Windows.Forms.GroupBox gpb_cadastroGeral;
        private System.Windows.Forms.Button btn_gerarScripts;
        private System.Windows.Forms.Button btn_gerarDER;
        private System.Windows.Forms.Panel pan_botton;
        private System.Windows.Forms.Panel pan_top;
        private System.Windows.Forms.Panel pan_tabelas;
        private System.Windows.Forms.Panel pan_campos;
        private System.Windows.Forms.GroupBox grb_tabelas;
        private System.Windows.Forms.GroupBox grb_campos;
        private System.Windows.Forms.DataGridView dgv_tabelas;
        private System.Windows.Forms.Button btn_incluirCampo;
        private System.Windows.Forms.DataGridView dgv_campos;
        private System.Windows.Forms.Button btn_incluirTabela;
        private System.Windows.Forms.Button btn_incluirRelacionamento;
        private System.Windows.Forms.Panel pan_filtroTabela;
        private System.Windows.Forms.Panel pan_tabelaTabelas;
        private System.Windows.Forms.GroupBox grb_filtroTabela;
        private System.Windows.Forms.Panel pan_filtroCampos;
        private System.Windows.Forms.GroupBox grb_filtroCampos;
        private System.Windows.Forms.Panel pan_tabelaCampos;
        private System.Windows.Forms.TextBox tbx_filtroTabela;
        private System.Windows.Forms.Label lbl_codigoDescricaoTabela;
        private System.Windows.Forms.Button btn_buscarCompleta;
        private System.Windows.Forms.Button btn_buscarCampo;
        private System.Windows.Forms.TextBox tbx_filtroCampo;
        private System.Windows.Forms.Label lbl_nomeCodigoCampo;
        private System.Windows.Forms.Button btn_completaTabela;
        private System.Windows.Forms.Button btn_buscarTabela;
        private System.Windows.Forms.Button btn_visualizarRelacao;
        private System.Windows.Forms.Button btn_removerTabela;
        private System.Windows.Forms.Button btn_editarTabela;
        private System.Windows.Forms.Button btn_addTabela;
        private System.Windows.Forms.Button btn_removerCampo;
        private System.Windows.Forms.Button btn_editarCampo;
        private System.Windows.Forms.Button btn_adicionarCampo;
        private System.Windows.Forms.Button btn_visualizarCampo;
        private System.Windows.Forms.Button btn_visualizarTabela;
    }
}
