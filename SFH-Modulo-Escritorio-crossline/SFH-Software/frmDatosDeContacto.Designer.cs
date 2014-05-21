namespace SFH_Software
{
    partial class frmDatosDeContacto
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatosDeContacto));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.datagriPersona = new System.Windows.Forms.DataGridView();
            this.IdPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nomperfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPersona_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdComuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FonoFijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FonoCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomComuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idcomuna1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mcfechaIngreso = new System.Windows.Forms.MonthCalendar();
            this.lblusuario = new System.Windows.Forms.Label();
            this.cmbxUsuario = new System.Windows.Forms.ComboBox();
            this.txtdir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.cmbxRegion = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbxComuna = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagriPersona)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(520, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Administración de Datos de Contacto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(4, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1266, 679);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de Datos de Contacto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datagriPersona);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(8, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1250, 428);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de datos de contacto usuarios";
            // 
            // datagriPersona
            // 
            this.datagriPersona.AllowUserToDeleteRows = false;
            this.datagriPersona.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagriPersona.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.datagriPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagriPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPersona,
            this.IdPerfil,
            this.Nomperfil,
            this.Rut,
            this.Dv,
            this.Nombre,
            this.ApellidoPaterno,
            this.ApellidoMaterno,
            this.FechaNacimiento,
            this.IdPersona_dat,
            this.IdComuna,
            this.FonoFijo,
            this.FonoCelular,
            this.Direccion,
            this.Mail,
            this.NomComuna,
            this.Idcomuna1,
            this.FechaIngreso});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagriPersona.DefaultCellStyle = dataGridViewCellStyle5;
            this.datagriPersona.Location = new System.Drawing.Point(6, 19);
            this.datagriPersona.Name = "datagriPersona";
            this.datagriPersona.ReadOnly = true;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.datagriPersona.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.datagriPersona.Size = new System.Drawing.Size(1238, 403);
            this.datagriPersona.TabIndex = 0;
            this.datagriPersona.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagriPersona_CellContentClick);
            this.datagriPersona.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagriPersona_CellMouseEnter);
            // 
            // IdPersona
            // 
            this.IdPersona.DataPropertyName = "IdPersona";
            this.IdPersona.HeaderText = "IdPersona";
            this.IdPersona.Name = "IdPersona";
            this.IdPersona.ReadOnly = true;
            this.IdPersona.Visible = false;
            // 
            // IdPerfil
            // 
            this.IdPerfil.DataPropertyName = "IdPerfil";
            this.IdPerfil.HeaderText = "IdPerfil";
            this.IdPerfil.Name = "IdPerfil";
            this.IdPerfil.ReadOnly = true;
            this.IdPerfil.Visible = false;
            // 
            // Nomperfil
            // 
            this.Nomperfil.DataPropertyName = "Nomperfil";
            this.Nomperfil.HeaderText = "Nomperfil";
            this.Nomperfil.Name = "Nomperfil";
            this.Nomperfil.ReadOnly = true;
            this.Nomperfil.Visible = false;
            // 
            // Rut
            // 
            this.Rut.DataPropertyName = "Rut";
            this.Rut.HeaderText = "Rut";
            this.Rut.Name = "Rut";
            this.Rut.ReadOnly = true;
            // 
            // Dv
            // 
            this.Dv.DataPropertyName = "Dv";
            this.Dv.HeaderText = "Dv";
            this.Dv.Name = "Dv";
            this.Dv.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // ApellidoPaterno
            // 
            this.ApellidoPaterno.DataPropertyName = "ApellidoPaterno";
            this.ApellidoPaterno.HeaderText = "ApellidoPaterno";
            this.ApellidoPaterno.Name = "ApellidoPaterno";
            this.ApellidoPaterno.ReadOnly = true;
            // 
            // ApellidoMaterno
            // 
            this.ApellidoMaterno.DataPropertyName = "ApellidoMaterno";
            this.ApellidoMaterno.HeaderText = "ApellidoMaterno";
            this.ApellidoMaterno.Name = "ApellidoMaterno";
            this.ApellidoMaterno.ReadOnly = true;
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.DataPropertyName = "FechaNacimiento";
            this.FechaNacimiento.HeaderText = "FechaNacimiento";
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.ReadOnly = true;
            this.FechaNacimiento.Visible = false;
            // 
            // IdPersona_dat
            // 
            this.IdPersona_dat.DataPropertyName = "IdPersona_dat";
            this.IdPersona_dat.HeaderText = "IdPersona_dat";
            this.IdPersona_dat.Name = "IdPersona_dat";
            this.IdPersona_dat.ReadOnly = true;
            this.IdPersona_dat.Visible = false;
            // 
            // IdComuna
            // 
            this.IdComuna.DataPropertyName = "IdComuna";
            this.IdComuna.HeaderText = "IdComuna";
            this.IdComuna.Name = "IdComuna";
            this.IdComuna.ReadOnly = true;
            this.IdComuna.Visible = false;
            // 
            // FonoFijo
            // 
            this.FonoFijo.DataPropertyName = "FonoFijo";
            this.FonoFijo.HeaderText = "FonoFijo";
            this.FonoFijo.Name = "FonoFijo";
            this.FonoFijo.ReadOnly = true;
            // 
            // FonoCelular
            // 
            this.FonoCelular.DataPropertyName = "FonoCelular";
            this.FonoCelular.HeaderText = "FonoCelular";
            this.FonoCelular.Name = "FonoCelular";
            this.FonoCelular.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            // 
            // Mail
            // 
            this.Mail.DataPropertyName = "Mail";
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            // 
            // NomComuna
            // 
            this.NomComuna.DataPropertyName = "NomComuna";
            this.NomComuna.HeaderText = "NomComuna";
            this.NomComuna.Name = "NomComuna";
            this.NomComuna.ReadOnly = true;
            // 
            // Idcomuna1
            // 
            this.Idcomuna1.DataPropertyName = "Idcomuna";
            this.Idcomuna1.HeaderText = "Idcomuna2";
            this.Idcomuna1.Name = "Idcomuna1";
            this.Idcomuna1.ReadOnly = true;
            this.Idcomuna1.Visible = false;
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.DataPropertyName = "FechaIngreso";
            this.FechaIngreso.HeaderText = "FechaIngreso";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.mcfechaIngreso);
            this.groupBox5.Controls.Add(this.lblusuario);
            this.groupBox5.Controls.Add(this.cmbxUsuario);
            this.groupBox5.Controls.Add(this.txtdir);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.btnNuevo);
            this.groupBox5.Controls.Add(this.btnCancelar);
            this.groupBox5.Controls.Add(this.txtmail);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtTelefono);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtCelular);
            this.groupBox5.Controls.Add(this.cmbxRegion);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.cmbxComuna);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(151, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(965, 217);
            this.groupBox5.TabIndex = 71;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datos de Contatcto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Fecha de Ingreso";
            // 
            // mcfechaIngreso
            // 
            this.mcfechaIngreso.Location = new System.Drawing.Point(726, 26);
            this.mcfechaIngreso.Name = "mcfechaIngreso";
            this.mcfechaIngreso.TabIndex = 62;
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.Location = new System.Drawing.Point(44, 29);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(43, 13);
            this.lblusuario.TabIndex = 61;
            this.lblusuario.Text = "Usuario";
            // 
            // cmbxUsuario
            // 
            this.cmbxUsuario.FormattingEnabled = true;
            this.cmbxUsuario.Location = new System.Drawing.Point(116, 26);
            this.cmbxUsuario.Name = "cmbxUsuario";
            this.cmbxUsuario.Size = new System.Drawing.Size(203, 21);
            this.cmbxUsuario.TabIndex = 60;
            this.cmbxUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbxUsuario_SelectedIndexChanged);
            // 
            // txtdir
            // 
            this.txtdir.Location = new System.Drawing.Point(432, 60);
            this.txtdir.MaxLength = 50;
            this.txtdir.Name = "txtdir";
            this.txtdir.Size = new System.Drawing.Size(181, 20);
            this.txtdir.TabIndex = 58;
            this.txtdir.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdir_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Dirección";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(495, 166);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(1);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(127, 36);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(352, 166);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 36);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtmail
            // 
            this.txtmail.Location = new System.Drawing.Point(432, 97);
            this.txtmail.MaxLength = 50;
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(181, 20);
            this.txtmail.TabIndex = 44;
            this.txtmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtmail_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(374, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Email";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(119, 138);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 42;
            this.txtTelefono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTelefono_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Región";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(432, 26);
            this.txtCelular.MaxLength = 10;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(181, 20);
            this.txtCelular.TabIndex = 43;
            this.txtCelular.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCelular_KeyUp);
            // 
            // cmbxRegion
            // 
            this.cmbxRegion.FormattingEnabled = true;
            this.cmbxRegion.Location = new System.Drawing.Point(116, 60);
            this.cmbxRegion.Name = "cmbxRegion";
            this.cmbxRegion.Size = new System.Drawing.Size(203, 21);
            this.cmbxRegion.TabIndex = 56;
            this.cmbxRegion.SelectedIndexChanged += new System.EventHandler(this.cmbxRegion_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Comuna";
            // 
            // cmbxComuna
            // 
            this.cmbxComuna.FormattingEnabled = true;
            this.cmbxComuna.Location = new System.Drawing.Point(117, 97);
            this.cmbxComuna.Name = "cmbxComuna";
            this.cmbxComuna.Size = new System.Drawing.Size(202, 21);
            this.cmbxComuna.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "Teléfono Fijo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(339, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 57;
            this.label11.Text = "Teléfono Celular";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDatosDeContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1272, 715);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDatosDeContacto";
            this.Text = "SFH - Datos de Contacto";
            this.Load += new System.EventHandler(this.frmDatosDeContacto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagriPersona)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtdir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.ComboBox cmbxRegion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbxComuna;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.ComboBox cmbxUsuario;
        private System.Windows.Forms.MonthCalendar mcfechaIngreso;
        private System.Windows.Forms.DataGridView datagriPersona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomperfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPersona_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComuna;
        private System.Windows.Forms.DataGridViewTextBoxColumn FonoFijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FonoCelular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomComuna;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idcomuna1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}