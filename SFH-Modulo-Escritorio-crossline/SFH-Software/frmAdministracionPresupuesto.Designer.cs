namespace SFH_Software
{
    partial class frmAdministracionPresupuesto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionPresupuesto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grillaPresupuesto = new System.Windows.Forms.DataGridView();
            this.presupuestoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblIdPresupuesto = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.calendarioCreacion = new System.Windows.Forms.MonthCalendar();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.cmbPersona = new System.Windows.Forms.ComboBox();
            this.personaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.idPresupuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPacienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFichaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaPresupuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.presupuestoBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1247, 644);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de presupuesto dental";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grillaPresupuesto);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(18, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1210, 404);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de presupuesto";
            // 
            // grillaPresupuesto
            // 
            this.grillaPresupuesto.AllowUserToAddRows = false;
            this.grillaPresupuesto.AllowUserToDeleteRows = false;
            this.grillaPresupuesto.AutoGenerateColumns = false;
            this.grillaPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaPresupuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPresupuestoDataGridViewTextBoxColumn,
            this.idPacienteDataGridViewTextBoxColumn,
            this.valorTotalDataGridViewTextBoxColumn,
            this.idFichaDataGridViewTextBoxColumn,
            this.fechaPresupuestoDataGridViewTextBoxColumn,
            this.editar});
            this.grillaPresupuesto.DataSource = this.presupuestoBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaPresupuesto.DefaultCellStyle = dataGridViewCellStyle1;
            this.grillaPresupuesto.Location = new System.Drawing.Point(189, 57);
            this.grillaPresupuesto.Name = "grillaPresupuesto";
            this.grillaPresupuesto.ReadOnly = true;
            this.grillaPresupuesto.Size = new System.Drawing.Size(746, 328);
            this.grillaPresupuesto.TabIndex = 0;
            this.grillaPresupuesto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // presupuestoBindingSource
            // 
            this.presupuestoBindingSource.DataSource = typeof(ObjectsBeans.Presupuesto);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.lblIdPresupuesto);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.txtValorTotal);
            this.groupBox2.Controls.Add(this.cmbPersona);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(18, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1210, 204);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crear presupuesto";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(575, 153);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 36);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblIdPresupuesto
            // 
            this.lblIdPresupuesto.AutoSize = true;
            this.lblIdPresupuesto.Location = new System.Drawing.Point(655, 53);
            this.lblIdPresupuesto.Name = "lblIdPresupuesto";
            this.lblIdPresupuesto.Size = new System.Drawing.Size(0, 13);
            this.lblIdPresupuesto.TabIndex = 25;
            this.lblIdPresupuesto.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.calendarioCreacion);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(724, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 185);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fecha de Creación";
            // 
            // calendarioCreacion
            // 
            this.calendarioCreacion.Location = new System.Drawing.Point(12, 17);
            this.calendarioCreacion.Name = "calendarioCreacion";
            this.calendarioCreacion.TabIndex = 0;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(389, 80);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(201, 20);
            this.txtValorTotal.TabIndex = 23;
            // 
            // cmbPersona
            // 
            this.cmbPersona.DataSource = this.personaBindingSource;
            this.cmbPersona.DisplayMember = "Nombre";
            this.cmbPersona.FormattingEnabled = true;
            this.cmbPersona.Location = new System.Drawing.Point(389, 41);
            this.cmbPersona.Name = "cmbPersona";
            this.cmbPersona.Size = new System.Drawing.Size(201, 21);
            this.cmbPersona.TabIndex = 19;
            this.cmbPersona.ValueMember = "IdPersona";
            // 
            // personaBindingSource
            // 
            this.personaBindingSource.DataSource = typeof(ObjectsBeans.Persona);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Valor Total                  $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Paciente";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(252, 153);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(1);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(143, 36);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Ingresar Presupuesto";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(420, 153);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(1);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(129, 36);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(479, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Administración de presupuesto dental";
            // 
            // idPresupuestoDataGridViewTextBoxColumn
            // 
            this.idPresupuestoDataGridViewTextBoxColumn.DataPropertyName = "IdPresupuesto";
            this.idPresupuestoDataGridViewTextBoxColumn.HeaderText = "IdPresupuesto";
            this.idPresupuestoDataGridViewTextBoxColumn.Name = "idPresupuestoDataGridViewTextBoxColumn";
            this.idPresupuestoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idPacienteDataGridViewTextBoxColumn
            // 
            this.idPacienteDataGridViewTextBoxColumn.DataPropertyName = "IdPaciente";
            this.idPacienteDataGridViewTextBoxColumn.HeaderText = "IdPaciente";
            this.idPacienteDataGridViewTextBoxColumn.Name = "idPacienteDataGridViewTextBoxColumn";
            this.idPacienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPacienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            this.valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            this.valorTotalDataGridViewTextBoxColumn.HeaderText = "ValorTotal";
            this.valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            this.valorTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idFichaDataGridViewTextBoxColumn
            // 
            this.idFichaDataGridViewTextBoxColumn.DataPropertyName = "IdFicha";
            this.idFichaDataGridViewTextBoxColumn.HeaderText = "IdFicha";
            this.idFichaDataGridViewTextBoxColumn.Name = "idFichaDataGridViewTextBoxColumn";
            this.idFichaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaPresupuestoDataGridViewTextBoxColumn
            // 
            this.fechaPresupuestoDataGridViewTextBoxColumn.DataPropertyName = "FechaPresupuesto";
            this.fechaPresupuestoDataGridViewTextBoxColumn.HeaderText = "FechaPresupuesto";
            this.fechaPresupuestoDataGridViewTextBoxColumn.Name = "fechaPresupuestoDataGridViewTextBoxColumn";
            this.fechaPresupuestoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar Presupuestos";
            this.editar.Name = "editar";
            this.editar.ReadOnly = true;
            this.editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmAdministracionPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1271, 683);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionPresupuesto";
            this.Text = "AdministracionPresupuesto";
            this.Load += new System.EventHandler(this.frmAdministracionPresupuesto_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaPresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.presupuestoBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.personaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPersona;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.DataGridView grillaPresupuesto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.MonthCalendar calendarioCreacion;
        private System.Windows.Forms.BindingSource personaBindingSource;
        private System.Windows.Forms.BindingSource presupuestoBindingSource;
        private System.Windows.Forms.Label lblIdPresupuesto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPresupuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPacienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFichaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaPresupuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn editar;


    }
}