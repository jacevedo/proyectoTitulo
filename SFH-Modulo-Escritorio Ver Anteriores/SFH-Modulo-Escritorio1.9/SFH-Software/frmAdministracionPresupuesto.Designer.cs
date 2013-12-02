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
            this.lblnom = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grillaPresupuesto = new System.Windows.Forms.DataGridView();
            this.idPresupuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPacienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFichaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaPresupuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.presupuestoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblIdPresupuesto = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.calendarioCreacion = new System.Windows.Forms.MonthCalendar();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.cmbPersona = new System.Windows.Forms.ComboBox();
            this.personaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAdminCli = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBox3.Controls.Add(this.lblnom);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.grillaPresupuesto);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(18, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1210, 404);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de presupuesto";
            // 
            // lblnom
            // 
            this.lblnom.AutoSize = true;
            this.lblnom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnom.ForeColor = System.Drawing.Color.White;
            this.lblnom.Location = new System.Drawing.Point(711, 16);
            this.lblnom.Name = "lblnom";
            this.lblnom.Size = new System.Drawing.Size(0, 24);
            this.lblnom.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(460, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Listado presupuesto dental :";
            // 
            // grillaPresupuesto
            // 
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
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grillaPresupuesto.DefaultCellStyle = dataGridViewCellStyle1;
            this.grillaPresupuesto.Location = new System.Drawing.Point(216, 57);
            this.grillaPresupuesto.Name = "grillaPresupuesto";
            this.grillaPresupuesto.Size = new System.Drawing.Size(746, 328);
            this.grillaPresupuesto.TabIndex = 0;
            this.grillaPresupuesto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idPresupuestoDataGridViewTextBoxColumn
            // 
            this.idPresupuestoDataGridViewTextBoxColumn.DataPropertyName = "IdPresupuesto";
            this.idPresupuestoDataGridViewTextBoxColumn.HeaderText = "IdPresupuesto";
            this.idPresupuestoDataGridViewTextBoxColumn.Name = "idPresupuestoDataGridViewTextBoxColumn";
            // 
            // idPacienteDataGridViewTextBoxColumn
            // 
            this.idPacienteDataGridViewTextBoxColumn.DataPropertyName = "IdPaciente";
            this.idPacienteDataGridViewTextBoxColumn.HeaderText = "IdPaciente";
            this.idPacienteDataGridViewTextBoxColumn.Name = "idPacienteDataGridViewTextBoxColumn";
            this.idPacienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            this.valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            this.valorTotalDataGridViewTextBoxColumn.HeaderText = "ValorTotal";
            this.valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            // 
            // idFichaDataGridViewTextBoxColumn
            // 
            this.idFichaDataGridViewTextBoxColumn.DataPropertyName = "IdFicha";
            this.idFichaDataGridViewTextBoxColumn.HeaderText = "IdFicha";
            this.idFichaDataGridViewTextBoxColumn.Name = "idFichaDataGridViewTextBoxColumn";
            // 
            // fechaPresupuestoDataGridViewTextBoxColumn
            // 
            this.fechaPresupuestoDataGridViewTextBoxColumn.DataPropertyName = "FechaPresupuesto";
            this.fechaPresupuestoDataGridViewTextBoxColumn.HeaderText = "FechaPresupuesto";
            this.fechaPresupuestoDataGridViewTextBoxColumn.Name = "fechaPresupuestoDataGridViewTextBoxColumn";
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar Presupuestos";
            this.editar.Name = "editar";
            this.editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // presupuestoBindingSource
            // 
            this.presupuestoBindingSource.DataSource = typeof(ObjectsBeans.Presupuesto);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblIdPresupuesto);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.txtValorTotal);
            this.groupBox2.Controls.Add(this.cmbPersona);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.btnAdminCli);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(18, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1210, 212);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crear presupuesto";
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
            this.groupBox4.Location = new System.Drawing.Point(673, 16);
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
            this.txtValorTotal.Location = new System.Drawing.Point(432, 80);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(201, 20);
            this.txtValorTotal.TabIndex = 23;
            // 
            // cmbPersona
            // 
            this.cmbPersona.DataSource = this.personaBindingSource;
            this.cmbPersona.DisplayMember = "Nombre";
            this.cmbPersona.FormattingEnabled = true;
            this.cmbPersona.Location = new System.Drawing.Point(432, 41);
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
            this.label2.Location = new System.Drawing.Point(296, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Valor Total                  $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 41);
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
            this.btnGuardar.Location = new System.Drawing.Point(299, 146);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(1);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(127, 36);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAdminCli
            // 
            this.btnAdminCli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdminCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnAdminCli.ForeColor = System.Drawing.Color.White;
            this.btnAdminCli.Location = new System.Drawing.Point(504, 146);
            this.btnAdminCli.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdminCli.Name = "btnAdminCli";
            this.btnAdminCli.Size = new System.Drawing.Size(129, 36);
            this.btnAdminCli.TabIndex = 11;
            this.btnAdminCli.Text = "Buscar";
            this.btnAdminCli.UseVisualStyleBackColor = false;
            this.btnAdminCli.Click += new System.EventHandler(this.btnAdminCli_Click);
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
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Button btnAdminCli;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPersona;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.DataGridView grillaPresupuesto;
        private System.Windows.Forms.Label lblnom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.MonthCalendar calendarioCreacion;
        private System.Windows.Forms.BindingSource personaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPresupuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPacienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFichaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaPresupuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.BindingSource presupuestoBindingSource;
        private System.Windows.Forms.Label lblIdPresupuesto;


    }
}