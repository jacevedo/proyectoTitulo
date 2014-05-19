namespace SFH_Software
{
    partial class frmAdministracionFichas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionFichas));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.datagridFicha = new System.Windows.Forms.DataGridView();
            this.idficha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOdontologo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anamnesis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.odontologo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.presupuesto = new System.Windows.Forms.DataGridViewButtonColumn();
            this.orden = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tratamiento = new System.Windows.Forms.DataGridViewButtonColumn();
            this.estado_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbxBuscar = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cmbxestado = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbxPaciente = new System.Windows.Forms.ComboBox();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxOdontologo = new System.Windows.Forms.ComboBox();
            this.txtOdontologo = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.mcFechaIngreso = new System.Windows.Forms.MonthCalendar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtAnamnesis = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridFicha)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(541, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Administración de Ficha Dental";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1233, 726);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de Ficha Dental";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datagridFicha);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(9, 325);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1218, 384);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de Fichas Dentales";
            // 
            // datagridFicha
            // 
            this.datagridFicha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridFicha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idficha,
            this.idpaciente,
            this.idOdontologo,
            this.fecha,
            this.anamnesis,
            this.estado,
            this.paciente,
            this.odontologo,
            this.editar,
            this.presupuesto,
            this.orden,
            this.tratamiento,
            this.estado_num});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridFicha.DefaultCellStyle = dataGridViewCellStyle1;
            this.datagridFicha.Location = new System.Drawing.Point(6, 82);
            this.datagridFicha.Name = "datagridFicha";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.datagridFicha.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.datagridFicha.Size = new System.Drawing.Size(1206, 298);
            this.datagridFicha.TabIndex = 16;
            this.datagridFicha.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridFicha_CellContentClick);
            // 
            // idficha
            // 
            this.idficha.DataPropertyName = "IdFicha";
            this.idficha.HeaderText = "Nro de Ficha";
            this.idficha.Name = "idficha";
            // 
            // idpaciente
            // 
            this.idpaciente.DataPropertyName = "IdPaciente";
            this.idpaciente.HeaderText = "IdPaciente";
            this.idpaciente.Name = "idpaciente";
            this.idpaciente.Visible = false;
            // 
            // idOdontologo
            // 
            this.idOdontologo.DataPropertyName = "IdOdontologo";
            this.idOdontologo.HeaderText = "IdOdontologo";
            this.idOdontologo.Name = "idOdontologo";
            this.idOdontologo.Visible = false;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "FechaIngreso";
            this.fecha.HeaderText = "Fecha de Ingreso";
            this.fecha.Name = "fecha";
            // 
            // anamnesis
            // 
            this.anamnesis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.anamnesis.DataPropertyName = "Anamnesis";
            this.anamnesis.HeaderText = "Anamnesis";
            this.anamnesis.Name = "anamnesis";
            // 
            // estado
            // 
            this.estado.DataPropertyName = "Habilitada";
            this.estado.HeaderText = "Estado Actual";
            this.estado.Name = "estado";
            // 
            // paciente
            // 
            this.paciente.DataPropertyName = "NombrePaciente";
            this.paciente.HeaderText = "Nombre Paciente";
            this.paciente.Name = "paciente";
            // 
            // odontologo
            // 
            this.odontologo.DataPropertyName = "NombreOdontologo";
            this.odontologo.HeaderText = "Nombre Odontologo";
            this.odontologo.Name = "odontologo";
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar Ficha";
            this.editar.Name = "editar";
            // 
            // presupuesto
            // 
            this.presupuesto.HeaderText = "Ver Presupuestos";
            this.presupuesto.Name = "presupuesto";
            // 
            // orden
            // 
            this.orden.HeaderText = "Ver Orden Dental";
            this.orden.Name = "orden";
            // 
            // tratamiento
            // 
            this.tratamiento.HeaderText = "Ver Tratamientos";
            this.tratamiento.Name = "tratamiento";
            // 
            // estado_num
            // 
            this.estado_num.DataPropertyName = "EstadoPaciente";
            this.estado_num.HeaderText = "estado numerico";
            this.estado_num.Name = "estado_num";
            this.estado_num.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBuscar);
            this.groupBox4.Controls.Add(this.cmbxBuscar);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtBuscar);
            this.groupBox4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Location = new System.Drawing.Point(275, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(610, 63);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Búsqueda de Fichas";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(467, 14);
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
            this.cmbxBuscar.Size = new System.Drawing.Size(170, 21);
            this.cmbxBuscar.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Buscar Por";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(277, 26);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(170, 20);
            this.txtBuscar.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox9);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(9, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1232, 300);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingreso de Ficha Dental ";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cmbxestado);
            this.groupBox9.ForeColor = System.Drawing.Color.White;
            this.groupBox9.Location = new System.Drawing.Point(544, 229);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(316, 65);
            this.groupBox9.TabIndex = 61;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Seleccionar Estado";
            // 
            // cmbxestado
            // 
            this.cmbxestado.FormattingEnabled = true;
            this.cmbxestado.Location = new System.Drawing.Point(43, 25);
            this.cmbxestado.Name = "cmbxestado";
            this.cmbxestado.Size = new System.Drawing.Size(231, 21);
            this.cmbxestado.TabIndex = 61;
            this.cmbxestado.SelectedIndexChanged += new System.EventHandler(this.cmbxestado_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(1026, 245);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 36);
            this.btnCancelar.TabIndex = 60;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(875, 245);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(1);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(127, 36);
            this.btnNuevo.TabIndex = 59;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.cmbxPaciente);
            this.groupBox8.Controls.Add(this.txtPaciente);
            this.groupBox8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox8.Location = new System.Drawing.Point(6, 19);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(263, 204);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Paciente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Paciente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Seleccionar";
            // 
            // cmbxPaciente
            // 
            this.cmbxPaciente.FormattingEnabled = true;
            this.cmbxPaciente.Location = new System.Drawing.Point(84, 48);
            this.cmbxPaciente.Name = "cmbxPaciente";
            this.cmbxPaciente.Size = new System.Drawing.Size(161, 21);
            this.cmbxPaciente.TabIndex = 3;
            this.cmbxPaciente.SelectedIndexChanged += new System.EventHandler(this.cmbxPaciente_SelectedIndexChanged);
            this.cmbxPaciente.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbxPaciente_MouseClick);
            // 
            // txtPaciente
            // 
            this.txtPaciente.Location = new System.Drawing.Point(84, 95);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(161, 20);
            this.txtPaciente.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.cmbxOdontologo);
            this.groupBox7.Controls.Add(this.txtOdontologo);
            this.groupBox7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox7.Location = new System.Drawing.Point(275, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(263, 204);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Odontólogo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Odontólogo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Seleccionar";
            // 
            // cmbxOdontologo
            // 
            this.cmbxOdontologo.FormattingEnabled = true;
            this.cmbxOdontologo.Location = new System.Drawing.Point(84, 48);
            this.cmbxOdontologo.Name = "cmbxOdontologo";
            this.cmbxOdontologo.Size = new System.Drawing.Size(161, 21);
            this.cmbxOdontologo.TabIndex = 2;
            this.cmbxOdontologo.SelectedIndexChanged += new System.EventHandler(this.cmbxOdontologo_SelectedIndexChanged);
            this.cmbxOdontologo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbxOdontologo_MouseClick);
            // 
            // txtOdontologo
            // 
            this.txtOdontologo.Location = new System.Drawing.Point(84, 95);
            this.txtOdontologo.Name = "txtOdontologo";
            this.txtOdontologo.Size = new System.Drawing.Size(161, 20);
            this.txtOdontologo.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.mcFechaIngreso);
            this.groupBox6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox6.Location = new System.Drawing.Point(866, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(278, 204);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Fecha de Ingreso";
            // 
            // mcFechaIngreso
            // 
            this.mcFechaIngreso.Location = new System.Drawing.Point(24, 25);
            this.mcFechaIngreso.Name = "mcFechaIngreso";
            this.mcFechaIngreso.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtAnamnesis);
            this.groupBox5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox5.Location = new System.Drawing.Point(544, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(316, 204);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Anamnesis";
            // 
            // txtAnamnesis
            // 
            this.txtAnamnesis.Location = new System.Drawing.Point(8, 25);
            this.txtAnamnesis.MaxLength = 100;
            this.txtAnamnesis.Multiline = true;
            this.txtAnamnesis.Name = "txtAnamnesis";
            this.txtAnamnesis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAnamnesis.Size = new System.Drawing.Size(302, 162);
            this.txtAnamnesis.TabIndex = 0;
            // 
            // frmAdministracionFichas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1257, 750);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionFichas";
            this.Text = "SFH - Administración de Fichas";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.frmAdministracionFichas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridFicha)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbxBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.MonthCalendar mcFechaIngreso;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbxPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxOdontologo;
        private System.Windows.Forms.TextBox txtOdontologo;
        private System.Windows.Forms.TextBox txtAnamnesis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox cmbxestado;
        private System.Windows.Forms.DataGridView datagridFicha;
        private System.Windows.Forms.DataGridViewTextBoxColumn idficha;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOdontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn anamnesis;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn odontologo;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.DataGridViewButtonColumn presupuesto;
        private System.Windows.Forms.DataGridViewButtonColumn orden;
        private System.Windows.Forms.DataGridViewButtonColumn tratamiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_num;


    }
}