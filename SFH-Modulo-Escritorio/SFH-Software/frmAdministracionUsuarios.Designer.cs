namespace SFH_Software
{
    partial class frmAdministracionUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionUsuarios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbxBuscar = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.datagriPersona = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAdminCli = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtnom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtrut = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtapellpater = new System.Windows.Forms.TextBox();
            this.txtdv = new System.Windows.Forms.TextBox();
            this.cmbxPerfil = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApeMat = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.mcFechaNac = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagriPersona)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1212, 769);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de cuentas de usuario ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.datagriPersona);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(6, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1196, 483);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista  usuarios ";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnBuscar);
            this.groupBox7.Controls.Add(this.cmbxBuscar);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.txtBuscar);
            this.groupBox7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox7.Location = new System.Drawing.Point(299, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(685, 66);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Búsqueda de fichas";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(543, 17);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(1);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(127, 36);
            this.btnBuscar.TabIndex = 58;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbxBuscar
            // 
            this.cmbxBuscar.FormattingEnabled = true;
            this.cmbxBuscar.Location = new System.Drawing.Point(90, 26);
            this.cmbxBuscar.Name = "cmbxBuscar";
            this.cmbxBuscar.Size = new System.Drawing.Size(236, 21);
            this.cmbxBuscar.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Buscar Por";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(348, 26);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(170, 20);
            this.txtBuscar.TabIndex = 2;
            // 
            // datagriPersona
            // 
            this.datagriPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagriPersona.Location = new System.Drawing.Point(6, 91);
            this.datagriPersona.Name = "datagriPersona";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.datagriPersona.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagriPersona.Size = new System.Drawing.Size(1184, 386);
            this.datagriPersona.TabIndex = 0;
            this.datagriPersona.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1196, 252);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox11);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtpass);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.btnAdminCli);
            this.groupBox5.Controls.Add(this.textBox7);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.textBox6);
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.comboBox2);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(632, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(558, 221);
            this.groupBox5.TabIndex = 70;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datos de contatcto";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(344, 131);
            this.textBox11.MaxLength = 60;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(181, 20);
            this.textBox11.TabIndex = 64;
            this.textBox11.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(344, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 20);
            this.textBox1.TabIndex = 58;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(286, 138);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 63;
            this.label16.Text = "Confirmar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Dirección";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(344, 94);
            this.txtpass.MaxLength = 60;
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(181, 20);
            this.txtpass.TabIndex = 62;
            this.txtpass.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(395, 172);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 36);
            this.button2.TabIndex = 13;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(277, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 61;
            this.label15.Text = "Contraseña";
            // 
            // btnAdminCli
            // 
            this.btnAdminCli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdminCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnAdminCli.ForeColor = System.Drawing.Color.White;
            this.btnAdminCli.Location = new System.Drawing.Point(253, 172);
            this.btnAdminCli.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdminCli.Name = "btnAdminCli";
            this.btnAdminCli.Size = new System.Drawing.Size(129, 36);
            this.btnAdminCli.TabIndex = 11;
            this.btnAdminCli.Text = "Cancelar";
            this.btnAdminCli.UseVisualStyleBackColor = false;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(344, 59);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(181, 20);
            this.textBox7.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Email";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(121, 94);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(145, 20);
            this.textBox5.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Region";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(121, 131);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(145, 20);
            this.textBox6.TabIndex = 43;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Comuna";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(119, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(145, 21);
            this.comboBox2.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "Teléfono fijo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 57;
            this.label11.Text = "Teléfono celular";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtnom);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtrut);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtapellpater);
            this.groupBox4.Controls.Add(this.txtdv);
            this.groupBox4.Controls.Add(this.cmbxPerfil);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtApeMat);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(6, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(336, 221);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos de Usuario";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 60;
            this.label14.Text = "Perfil de Usuario";
            // 
            // txtnom
            // 
            this.txtnom.Location = new System.Drawing.Point(128, 97);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(180, 20);
            this.txtnom.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre de usuario";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 68;
            this.label12.Text = "Apellido Paterno";
            // 
            // txtrut
            // 
            this.txtrut.Location = new System.Drawing.Point(129, 59);
            this.txtrut.Name = "txtrut";
            this.txtrut.Size = new System.Drawing.Size(128, 20);
            this.txtrut.TabIndex = 38;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Rut";
            // 
            // txtapellpater
            // 
            this.txtapellpater.Location = new System.Drawing.Point(130, 138);
            this.txtapellpater.Name = "txtapellpater";
            this.txtapellpater.Size = new System.Drawing.Size(180, 20);
            this.txtapellpater.TabIndex = 67;
            // 
            // txtdv
            // 
            this.txtdv.Location = new System.Drawing.Point(277, 59);
            this.txtdv.Name = "txtdv";
            this.txtdv.Size = new System.Drawing.Size(33, 20);
            this.txtdv.TabIndex = 41;
            // 
            // cmbxPerfil
            // 
            this.cmbxPerfil.FormattingEnabled = true;
            this.cmbxPerfil.Location = new System.Drawing.Point(129, 16);
            this.cmbxPerfil.Name = "cmbxPerfil";
            this.cmbxPerfil.Size = new System.Drawing.Size(179, 21);
            this.cmbxPerfil.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Apellido Materno";
            // 
            // txtApeMat
            // 
            this.txtApeMat.Location = new System.Drawing.Point(128, 181);
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.Size = new System.Drawing.Size(180, 20);
            this.txtApeMat.TabIndex = 65;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.mcFechaNac);
            this.groupBox6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox6.Location = new System.Drawing.Point(348, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(277, 221);
            this.groupBox6.TabIndex = 65;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Fecha de Nacimiento";
            // 
            // mcFechaNac
            // 
            this.mcFechaNac.Location = new System.Drawing.Point(28, 35);
            this.mcFechaNac.Name = "mcFechaNac";
            this.mcFechaNac.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(495, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Administración de cuentas de usuario ";
            // 
            // frmAdministracionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1217, 799);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionUsuarios";
            this.Text = "Administracion Usuarios";
            this.Load += new System.EventHandler(this.frmAdministracionUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagriPersona)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAdminCli;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbxPerfil;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtdv;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtrut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtapellpater;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApeMat;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.MonthCalendar mcFechaNac;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView datagriPersona;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbxBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuscar;
        
    }
}