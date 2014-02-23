namespace SFH_Software
{
    partial class frmMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Administración de ficha dental");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Administración de presupuesto dental");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Administración de orden de laboratorio");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Administración de tratamiento dental");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Administración de insumos");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Administración de listas de precios por tratamiento");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Administración de área insumos");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Administración de gastos");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Administración de clínicas", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Administración de usuarios");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Administración de datos de contacto");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Administración de pacientes");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Administración de odontólogos");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Administración de funcionarios");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Administración de usuarios del sistema", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Generar Reporte Pacientes");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Generar Reportes Monetarios");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Listar Historial de Reportes");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Reportes y estadísticas", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cittEnrolaPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeFichaDentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDePresupuestoDentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeOrdenDeLaboratorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeTratamientoDentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeReportesEInsumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeÁreaInsumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeGatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdministracióndedatosdecontactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdministracióndepacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeOdontólogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeFuncionariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripReportesyestadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReportePacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReportesMonetariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarHistorialDeReportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeViewMenu = new System.Windows.Forms.TreeView();
            this.btnAdminUser = new System.Windows.Forms.Button();
            this.btnAdminCli = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.tabControlMenu = new MdiTabControl.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cittEnrolaPersonaToolStripMenuItem,
            this.seguridadToolStripMenuItem,
            this.toolStripReportesyestadisticas,
            this.usuarioToolStripMenuItem,
            this.acercaDeToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1125, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cittEnrolaPersonaToolStripMenuItem
            // 
            this.cittEnrolaPersonaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administraciónDeFichaDentalToolStripMenuItem,
            this.administraciónDePresupuestoDentalToolStripMenuItem,
            this.administraciónDeOrdenDeLaboratorioToolStripMenuItem,
            this.administraciónDeTratamientoDentalToolStripMenuItem,
            this.administraciónDeReportesEInsumosToolStripMenuItem,
            this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem,
            this.administraciónDeÁreaInsumosToolStripMenuItem,
            this.administraciónDeGatosToolStripMenuItem});
            this.cittEnrolaPersonaToolStripMenuItem.Name = "cittEnrolaPersonaToolStripMenuItem";
            this.cittEnrolaPersonaToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.cittEnrolaPersonaToolStripMenuItem.Text = "Administración de clínica";
            // 
            // administraciónDeFichaDentalToolStripMenuItem
            // 
            this.administraciónDeFichaDentalToolStripMenuItem.Name = "administraciónDeFichaDentalToolStripMenuItem";
            this.administraciónDeFichaDentalToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.administraciónDeFichaDentalToolStripMenuItem.Text = "Administración de ficha dental";
            this.administraciónDeFichaDentalToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeFichaDentalToolStripMenuItem_Click);
            // 
            // administraciónDePresupuestoDentalToolStripMenuItem
            // 
            this.administraciónDePresupuestoDentalToolStripMenuItem.Name = "administraciónDePresupuestoDentalToolStripMenuItem";
            this.administraciónDePresupuestoDentalToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.administraciónDePresupuestoDentalToolStripMenuItem.Text = "Administración de presupuesto dental";
            this.administraciónDePresupuestoDentalToolStripMenuItem.Click += new System.EventHandler(this.administraciónDePresupuestoDentalToolStripMenuItem_Click);
            // 
            // administraciónDeOrdenDeLaboratorioToolStripMenuItem
            // 
            this.administraciónDeOrdenDeLaboratorioToolStripMenuItem.Name = "administraciónDeOrdenDeLaboratorioToolStripMenuItem";
            this.administraciónDeOrdenDeLaboratorioToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.administraciónDeOrdenDeLaboratorioToolStripMenuItem.Text = "Administración de orden de laboratorio";
            this.administraciónDeOrdenDeLaboratorioToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeOrdenDeLaboratorioToolStripMenuItem_Click);
            // 
            // administraciónDeTratamientoDentalToolStripMenuItem
            // 
            this.administraciónDeTratamientoDentalToolStripMenuItem.Name = "administraciónDeTratamientoDentalToolStripMenuItem";
            this.administraciónDeTratamientoDentalToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.administraciónDeTratamientoDentalToolStripMenuItem.Text = "Administración de tratamiento dental";
            this.administraciónDeTratamientoDentalToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeTratamientoDentalToolStripMenuItem_Click);
            // 
            // administraciónDeReportesEInsumosToolStripMenuItem
            // 
            this.administraciónDeReportesEInsumosToolStripMenuItem.Name = "administraciónDeReportesEInsumosToolStripMenuItem";
            this.administraciónDeReportesEInsumosToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.administraciónDeReportesEInsumosToolStripMenuItem.Text = "Administración de reportes e insumos";
            this.administraciónDeReportesEInsumosToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeReportesEInsumosToolStripMenuItem_Click);
            // 
            // administraciónDeListasDePreciosPorTratamientoToolStripMenuItem
            // 
            this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem.Name = "administraciónDeListasDePreciosPorTratamientoToolStripMenuItem";
            this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem.Text = "Administración de listas de precios por tratamiento";
            this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem_Click);
            // 
            // administraciónDeÁreaInsumosToolStripMenuItem
            // 
            this.administraciónDeÁreaInsumosToolStripMenuItem.Name = "administraciónDeÁreaInsumosToolStripMenuItem";
            this.administraciónDeÁreaInsumosToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.administraciónDeÁreaInsumosToolStripMenuItem.Text = "Administración de área insumos";
            this.administraciónDeÁreaInsumosToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeÁreaInsumosToolStripMenuItem_Click);
            // 
            // administraciónDeGatosToolStripMenuItem
            // 
            this.administraciónDeGatosToolStripMenuItem.Name = "administraciónDeGatosToolStripMenuItem";
            this.administraciónDeGatosToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.administraciónDeGatosToolStripMenuItem.Text = "Administración de gastos";
            this.administraciónDeGatosToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeGatosToolStripMenuItem_Click);
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearUsuarioToolStripMenuItem,
            this.AdministracióndedatosdecontactoToolStripMenuItem,
            this.AdministracióndepacientesToolStripMenuItem,
            this.administraciónDeOdontólogosToolStripMenuItem,
            this.administraciónDeFuncionariosToolStripMenuItem});
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(225, 20);
            this.seguridadToolStripMenuItem.Text = "Administración de usuarios del sistema";
            // 
            // crearUsuarioToolStripMenuItem
            // 
            this.crearUsuarioToolStripMenuItem.Name = "crearUsuarioToolStripMenuItem";
            this.crearUsuarioToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.crearUsuarioToolStripMenuItem.Text = "Administración de usuarios";
            this.crearUsuarioToolStripMenuItem.Click += new System.EventHandler(this.crearUsuarioToolStripMenuItem_Click);
            // 
            // AdministracióndedatosdecontactoToolStripMenuItem
            // 
            this.AdministracióndedatosdecontactoToolStripMenuItem.Name = "AdministracióndedatosdecontactoToolStripMenuItem";
            this.AdministracióndedatosdecontactoToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.AdministracióndedatosdecontactoToolStripMenuItem.Text = "Administración de datos de contacto";
            this.AdministracióndedatosdecontactoToolStripMenuItem.Click += new System.EventHandler(this.AdministracióndedatosdecontactoToolStripMenuItem_Click);
            // 
            // AdministracióndepacientesToolStripMenuItem
            // 
            this.AdministracióndepacientesToolStripMenuItem.Name = "AdministracióndepacientesToolStripMenuItem";
            this.AdministracióndepacientesToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.AdministracióndepacientesToolStripMenuItem.Text = "Administración de  pacientes ";
            this.AdministracióndepacientesToolStripMenuItem.Click += new System.EventHandler(this.AdministracióndepacientesToolStripMenuItem_Click);
            // 
            // administraciónDeOdontólogosToolStripMenuItem
            // 
            this.administraciónDeOdontólogosToolStripMenuItem.Name = "administraciónDeOdontólogosToolStripMenuItem";
            this.administraciónDeOdontólogosToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.administraciónDeOdontólogosToolStripMenuItem.Text = "Administración de odontólogos";
            this.administraciónDeOdontólogosToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeOdontólogosToolStripMenuItem_Click);
            // 
            // administraciónDeFuncionariosToolStripMenuItem
            // 
            this.administraciónDeFuncionariosToolStripMenuItem.Name = "administraciónDeFuncionariosToolStripMenuItem";
            this.administraciónDeFuncionariosToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.administraciónDeFuncionariosToolStripMenuItem.Text = "Administración de funcionarios";
            this.administraciónDeFuncionariosToolStripMenuItem.Click += new System.EventHandler(this.administraciónDeFuncionariosToolStripMenuItem_Click);
            // 
            // toolStripReportesyestadisticas
            // 
            this.toolStripReportesyestadisticas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarReportePacientesToolStripMenuItem,
            this.generarReportesMonetariosToolStripMenuItem,
            this.listarHistorialDeReportesToolStripMenuItem});
            this.toolStripReportesyestadisticas.Name = "toolStripReportesyestadisticas";
            this.toolStripReportesyestadisticas.Size = new System.Drawing.Size(137, 20);
            this.toolStripReportesyestadisticas.Text = "Reportes y estadísticas";
            // 
            // generarReportePacientesToolStripMenuItem
            // 
            this.generarReportePacientesToolStripMenuItem.Name = "generarReportePacientesToolStripMenuItem";
            this.generarReportePacientesToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.generarReportePacientesToolStripMenuItem.Text = "Generar Reporte Pacientes";
            this.generarReportePacientesToolStripMenuItem.Click += new System.EventHandler(this.generarReportePacientesToolStripMenuItem_Click);
            // 
            // generarReportesMonetariosToolStripMenuItem
            // 
            this.generarReportesMonetariosToolStripMenuItem.Name = "generarReportesMonetariosToolStripMenuItem";
            this.generarReportesMonetariosToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.generarReportesMonetariosToolStripMenuItem.Text = "Generar Reportes Monetarios";
            this.generarReportesMonetariosToolStripMenuItem.Click += new System.EventHandler(this.generarReportesMonetariosToolStripMenuItem_Click);
            // 
            // listarHistorialDeReportesToolStripMenuItem
            // 
            this.listarHistorialDeReportesToolStripMenuItem.Name = "listarHistorialDeReportesToolStripMenuItem";
            this.listarHistorialDeReportesToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.listarHistorialDeReportesToolStripMenuItem.Text = "Listar Historial de Reportes";
            this.listarHistorialDeReportesToolStripMenuItem.Click += new System.EventHandler(this.listarHistorialDeReportesToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSessionToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // cerrarSessionToolStripMenuItem
            // 
            this.cerrarSessionToolStripMenuItem.Name = "cerrarSessionToolStripMenuItem";
            this.cerrarSessionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.cerrarSessionToolStripMenuItem.Text = "Cerrar Session";
            this.cerrarSessionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSessionToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de ";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.salirToolStripMenuItem.Text = "Salir ";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // treeViewMenu
            // 
            this.treeViewMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewMenu.Location = new System.Drawing.Point(19, 239);
            this.treeViewMenu.Name = "treeViewMenu";
            treeNode1.Name = "ndAdministración de ficha dental";
            treeNode1.Text = "Administración de ficha dental";
            treeNode2.Name = "ndAdministración de presupuesto dental";
            treeNode2.Text = "Administración de presupuesto dental";
            treeNode3.Name = "ndAdministración de orden de laboratorio";
            treeNode3.Text = "Administración de orden de laboratorio";
            treeNode4.Name = "ndAdministración de tratamiento dental";
            treeNode4.Text = "Administración de tratamiento dental";
            treeNode5.Name = "ndAdministración de reportes e insumos";
            treeNode5.Text = "Administración de insumos";
            treeNode6.Name = "ndAdministración de listas de precios por tratamiento";
            treeNode6.Text = "Administración de listas de precios por tratamiento";
            treeNode7.Name = "Administración de área insumos";
            treeNode7.Text = "Administración de área insumos";
            treeNode8.Name = "Administración de gastos";
            treeNode8.Text = "Administración de gastos";
            treeNode9.Name = "adminCli";
            treeNode9.Text = "Administración de clínicas";
            treeNode10.Name = "Administraciondeusuarios";
            treeNode10.Text = "Administración de usuarios";
            treeNode11.Name = "Datosdecontacto";
            treeNode11.Text = "Administración de datos de contacto";
            treeNode12.Name = "Pacientes";
            treeNode12.Text = "Administración de pacientes";
            treeNode13.Name = "Odontologos";
            treeNode13.Text = "Administración de odontólogos";
            treeNode14.Name = "Funcionarios";
            treeNode14.Text = "Administración de funcionarios";
            treeNode15.Name = "AdminUser";
            treeNode15.Text = "Administración de usuarios del sistema";
            treeNode16.Name = "GenerarReportePacientes";
            treeNode16.Text = "Generar Reporte Pacientes";
            treeNode17.Name = "GenerarReportesMonetarios";
            treeNode17.Text = "Generar Reportes Monetarios";
            treeNode18.Name = "ListarHistorialdeReportes";
            treeNode18.Text = "Listar Historial de Reportes";
            treeNode19.Name = "AdminRep";
            treeNode19.Text = "Reportes y estadísticas";
            this.treeViewMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode15,
            treeNode19});
            this.treeViewMenu.Size = new System.Drawing.Size(246, 234);
            this.treeViewMenu.TabIndex = 7;
            this.treeViewMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewMenu_NodeMouseDoubleClick);
            // 
            // btnAdminUser
            // 
            this.btnAdminUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdminUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnAdminUser.ForeColor = System.Drawing.Color.White;
            this.btnAdminUser.Location = new System.Drawing.Point(19, 517);
            this.btnAdminUser.Name = "btnAdminUser";
            this.btnAdminUser.Size = new System.Drawing.Size(246, 36);
            this.btnAdminUser.TabIndex = 9;
            this.btnAdminUser.Text = "Administración de usuarios";
            this.btnAdminUser.UseVisualStyleBackColor = false;
            this.btnAdminUser.Click += new System.EventHandler(this.btnAdminUser_Click);
            // 
            // btnAdminCli
            // 
            this.btnAdminCli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdminCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnAdminCli.ForeColor = System.Drawing.Color.White;
            this.btnAdminCli.Location = new System.Drawing.Point(19, 477);
            this.btnAdminCli.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdminCli.Name = "btnAdminCli";
            this.btnAdminCli.Size = new System.Drawing.Size(246, 36);
            this.btnAdminCli.TabIndex = 10;
            this.btnAdminCli.Text = "Administración de Clínica";
            this.btnAdminCli.UseVisualStyleBackColor = false;
            this.btnAdminCli.Click += new System.EventHandler(this.btnAdminCli_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(19, 555);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(246, 36);
            this.btnReportes.TabIndex = 11;
            this.btnReportes.Text = "Reportes y Estadísticas";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // tabControlMenu
            // 
            this.tabControlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMenu.BackColor = System.Drawing.Color.DarkGray;
            this.tabControlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabControlMenu.BackHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.tabControlMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.tabControlMenu.BorderColorDisabled = System.Drawing.SystemColors.ControlLight;
            this.tabControlMenu.ControlButtonBackHighColor = System.Drawing.Color.White;
            this.tabControlMenu.ControlButtonBackLowColor = System.Drawing.Color.White;
            this.tabControlMenu.ControlButtonBorderColor = System.Drawing.Color.White;
            this.tabControlMenu.Location = new System.Drawing.Point(7, 19);
            this.tabControlMenu.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMenu.MenuRenderer = null;
            this.tabControlMenu.Name = "tabControlMenu";
            this.tabControlMenu.Size = new System.Drawing.Size(797, 577);
            this.tabControlMenu.TabBackHighColor = System.Drawing.SystemColors.MenuBar;
            this.tabControlMenu.TabBackHighColorDisabled = System.Drawing.Color.White;
            this.tabControlMenu.TabBackLowColor = System.Drawing.Color.White;
            this.tabControlMenu.TabBackLowColorDisabled = System.Drawing.Color.White;
            this.tabControlMenu.TabBorderEnhanced = true;
            this.tabControlMenu.TabCloseButtonImage = null;
            this.tabControlMenu.TabCloseButtonImageDisabled = null;
            this.tabControlMenu.TabCloseButtonImageHot = null;
            this.tabControlMenu.TabGlassGradient = true;
            this.tabControlMenu.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.treeViewMenu);
            this.groupBox1.Controls.Add(this.btnReportes);
            this.groupBox1.Controls.Add(this.btnAdminCli);
            this.groupBox1.Controls.Add(this.btnAdminUser);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 603);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SFH - Sistema de Fichas Médicas y Toma de Horas";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tabControlMenu);
            this.groupBox2.Location = new System.Drawing.Point(302, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(811, 603);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1125, 659);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cittEnrolaPersonaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSessionToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeViewMenu;
        private System.Windows.Forms.Button btnAdminUser;
        private System.Windows.Forms.Button btnAdminCli;
        private System.Windows.Forms.Button btnReportes;
        private MdiTabControl.TabControl tabControlMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeFichaDentalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDePresupuestoDentalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeOrdenDeLaboratorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeTratamientoDentalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeReportesEInsumosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeListasDePreciosPorTratamientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeÁreaInsumosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeGatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdministracióndedatosdecontactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdministracióndepacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeOdontólogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeFuncionariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripReportesyestadisticas;
        private System.Windows.Forms.ToolStripMenuItem generarReportePacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarReportesMonetariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarHistorialDeReportesToolStripMenuItem;
    }
}