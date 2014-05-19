namespace SFH_Software
{
    partial class frmOdontologo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOdontologo));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.datagriPersona = new System.Windows.Forms.DataGridView();
            this.IdOdontologo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPersonaOdontologo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OdontologoHabilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nomperfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblguion = new System.Windows.Forms.Label();
            this.txtdvbusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbxBuscar = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxestado = new System.Windows.Forms.ComboBox();
            this.cmbxUsuario = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtesp = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagriPersona)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(483, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Administración de Datos de Odontólogos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(6, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1249, 684);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de Datos de Odontólogos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datagriPersona);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(6, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1237, 490);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de Odontólogos";
            // 
            // datagriPersona
            // 
            this.datagriPersona.AllowUserToAddRows = false;
            this.datagriPersona.AllowUserToDeleteRows = false;
            this.datagriPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagriPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOdontologo,
            this.IdPersonaOdontologo,
            this.Rut,
            this.Dv,
            this.Nombre,
            this.ApellidoPaterno,
            this.ApellidoMaterno,
            this.Especialidad,
            this.OdontologoHabilitado,
            this.FechaNacimiento,
            this.IdPersona,
            this.IdPerfil,
            this.Nomperfil});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagriPersona.DefaultCellStyle = dataGridViewCellStyle1;
            this.datagriPersona.Location = new System.Drawing.Point(6, 82);
            this.datagriPersona.Name = "datagriPersona";
            this.datagriPersona.ReadOnly = true;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.datagriPersona.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.datagriPersona.Size = new System.Drawing.Size(1225, 402);
            this.datagriPersona.TabIndex = 0;
            this.datagriPersona.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagriPersona_CellContentClick);
            // 
            // IdOdontologo
            // 
            this.IdOdontologo.DataPropertyName = "IdOdontologo";
            this.IdOdontologo.HeaderText = "IdOdontologo";
            this.IdOdontologo.Name = "IdOdontologo";
            this.IdOdontologo.ReadOnly = true;
            this.IdOdontologo.Visible = false;
            // 
            // IdPersonaOdontologo
            // 
            this.IdPersonaOdontologo.DataPropertyName = "IdPersonaOdontologo";
            this.IdPersonaOdontologo.HeaderText = "IdPersonaOdontologo";
            this.IdPersonaOdontologo.Name = "IdPersonaOdontologo";
            this.IdPersonaOdontologo.ReadOnly = true;
            this.IdPersonaOdontologo.Visible = false;
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
            // Especialidad
            // 
            this.Especialidad.DataPropertyName = "Especialidad";
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.ReadOnly = true;
            // 
            // OdontologoHabilitado
            // 
            this.OdontologoHabilitado.DataPropertyName = "OdontologoHabilitado";
            this.OdontologoHabilitado.HeaderText = "OdontologoHabilitado";
            this.OdontologoHabilitado.Name = "OdontologoHabilitado";
            this.OdontologoHabilitado.ReadOnly = true;
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.DataPropertyName = "FechaNacimiento";
            this.FechaNacimiento.HeaderText = "FechaNacimiento";
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.ReadOnly = true;
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
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblguion);
            this.groupBox7.Controls.Add(this.txtdvbusqueda);
            this.groupBox7.Controls.Add(this.btnBuscar);
            this.groupBox7.Controls.Add(this.cmbxBuscar);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.txtBuscar);
            this.groupBox7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox7.Location = new System.Drawing.Point(244, 10);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(715, 66);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Búsqueda de Odontólogos";
            // 
            // lblguion
            // 
            this.lblguion.AutoSize = true;
            this.lblguion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblguion.Location = new System.Drawing.Point(501, 29);
            this.lblguion.Name = "lblguion";
            this.lblguion.Size = new System.Drawing.Size(12, 16);
            this.lblguion.TabIndex = 60;
            this.lblguion.Text = "-";
            this.lblguion.Visible = false;
            // 
            // txtdvbusqueda
            // 
            this.txtdvbusqueda.Location = new System.Drawing.Point(517, 26);
            this.txtdvbusqueda.MaxLength = 1;
            this.txtdvbusqueda.Name = "txtdvbusqueda";
            this.txtdvbusqueda.Size = new System.Drawing.Size(38, 20);
            this.txtdvbusqueda.TabIndex = 59;
            this.txtdvbusqueda.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(574, 17);
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
            this.cmbxBuscar.SelectedIndexChanged += new System.EventHandler(this.cmbxBuscar_SelectedIndexChanged);
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
            this.txtBuscar.MaxLength = 8;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(147, 20);
            this.txtBuscar.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbxestado);
            this.groupBox2.Controls.Add(this.cmbxUsuario);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtesp);
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1237, 163);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingreso Odontólogos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(745, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Habilitar/Deshabilitar";
            // 
            // cmbxestado
            // 
            this.cmbxestado.FormattingEnabled = true;
            this.cmbxestado.Location = new System.Drawing.Point(856, 56);
            this.cmbxestado.Name = "cmbxestado";
            this.cmbxestado.Size = new System.Drawing.Size(215, 21);
            this.cmbxestado.TabIndex = 40;
            this.cmbxestado.SelectedIndexChanged += new System.EventHandler(this.cmbxestado_SelectedIndexChanged);
            // 
            // cmbxUsuario
            // 
            this.cmbxUsuario.FormattingEnabled = true;
            this.cmbxUsuario.Location = new System.Drawing.Point(159, 56);
            this.cmbxUsuario.Name = "cmbxUsuario";
            this.cmbxUsuario.Size = new System.Drawing.Size(215, 21);
            this.cmbxUsuario.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(107, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Persona";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Especialidad";
            // 
            // txtesp
            // 
            this.txtesp.Location = new System.Drawing.Point(491, 56);
            this.txtesp.Name = "txtesp";
            this.txtesp.Size = new System.Drawing.Size(215, 20);
            this.txtesp.TabIndex = 14;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(953, 114);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(1);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(127, 36);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(816, 114);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 36);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmOdontologo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1267, 725);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOdontologo";
            this.Text = "SFH - Odontólogo";
            this.Load += new System.EventHandler(this.frmOdontologo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagriPersona)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbxestado;
        private System.Windows.Forms.ComboBox cmbxUsuario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtesp;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView datagriPersona;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblguion;
        private System.Windows.Forms.TextBox txtdvbusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbxBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOdontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPersonaOdontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn OdontologoHabilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomperfil;
    }
}