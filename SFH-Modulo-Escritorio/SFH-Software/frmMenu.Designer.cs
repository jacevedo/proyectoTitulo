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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Administración de clínicas", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Administración de usuarios");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Reportes y estadísticas");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cittEnrolaPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeFichaDentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDePresupuestoDentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeOrdenDeLaboratorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeTratamientoDentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeReportesEInsumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem});
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
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearUsuarioToolStripMenuItem});
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(163, 20);
            this.seguridadToolStripMenuItem.Text = "Administración de usuarios";
            // 
            // crearUsuarioToolStripMenuItem
            // 
            this.crearUsuarioToolStripMenuItem.Name = "crearUsuarioToolStripMenuItem";
            this.crearUsuarioToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.crearUsuarioToolStripMenuItem.Text = "Crear Usuarios";
            this.crearUsuarioToolStripMenuItem.Click += new System.EventHandler(this.crearUsuarioToolStripMenuItem_Click);
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
            treeNode7.Name = "adminCli";
            treeNode7.Text = "Administración de clínicas";
            treeNode8.Name = "AdminUser";
            treeNode8.Text = "Administración de usuarios";
            treeNode9.Name = "AdminRep";
            treeNode9.Text = "Reportes y estadísticas";
            this.treeViewMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.treeViewMenu.Size = new System.Drawing.Size(246, 234);
            this.treeViewMenu.TabIndex = 7;
            this.treeViewMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMenu_AfterSelect);
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
            this.tabControlMenu.Alignment = MdiTabControl.TabControl.TabAlignment.Top;
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
            this.tabControlMenu.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.tabControlMenu.TabBackHighColor = System.Drawing.SystemColors.MenuBar;
            this.tabControlMenu.TabBackHighColorDisabled = System.Drawing.Color.White;
            this.tabControlMenu.TabBackLowColor = System.Drawing.Color.White;
            this.tabControlMenu.TabBackLowColorDisabled = System.Drawing.Color.White;
            this.tabControlMenu.TabBorderEnhanced = true;
            this.tabControlMenu.TabBorderEnhanceWeight = MdiTabControl.TabControl.Weight.Medium;
            this.tabControlMenu.TabCloseButtonImage = null;
            this.tabControlMenu.TabCloseButtonImageDisabled = null;
            this.tabControlMenu.TabCloseButtonImageHot = null;
            this.tabControlMenu.TabGlassGradient = true;
            this.tabControlMenu.TabIndex = 12;
            this.tabControlMenu.TabsDirection = MdiTabControl.TabControl.FlowDirection.LeftToRight;
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
    }
}