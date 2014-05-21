namespace SFH_Software
{
    partial class frmAdministracionTratamiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionTratamiento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAbono = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdTratamiento = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CalendarSeguimiento = new System.Windows.Forms.MonthCalendar();
            this.btnGuardarTratamiento = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtDescTratamiento = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.calendarCreacion = new System.Windows.Forms.MonthCalendar();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.cmbFicha = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GridTratamiento = new System.Windows.Forms.DataGridView();
            this.idTratamientoDentalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFichaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tratamientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSeguimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAbonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Abonos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tratamientodentalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTratamiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tratamientodentalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1100, 606);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de Tratamiento Dental";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAbono);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblIdTratamiento);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.btnGuardarTratamiento);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.txtValorTotal);
            this.groupBox2.Controls.Add(this.cmbFicha);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1086, 196);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crear Presupuesto";
            // 
            // lblAbono
            // 
            this.lblAbono.AutoSize = true;
            this.lblAbono.Location = new System.Drawing.Point(195, 100);
            this.lblAbono.Name = "lblAbono";
            this.lblAbono.Size = new System.Drawing.Size(0, 13);
            this.lblAbono.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 29;
            // 
            // lblIdTratamiento
            // 
            this.lblIdTratamiento.AutoSize = true;
            this.lblIdTratamiento.Location = new System.Drawing.Point(71, 101);
            this.lblIdTratamiento.Name = "lblIdTratamiento";
            this.lblIdTratamiento.Size = new System.Drawing.Size(0, 13);
            this.lblIdTratamiento.TabIndex = 28;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CalendarSeguimiento);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(837, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(243, 180);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fecha de Seguimiento";
            // 
            // CalendarSeguimiento
            // 
            this.CalendarSeguimiento.Location = new System.Drawing.Point(10, 15);
            this.CalendarSeguimiento.Name = "CalendarSeguimiento";
            this.CalendarSeguimiento.TabIndex = 0;
            // 
            // btnGuardarTratamiento
            // 
            this.btnGuardarTratamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardarTratamiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnGuardarTratamiento.ForeColor = System.Drawing.Color.White;
            this.btnGuardarTratamiento.Location = new System.Drawing.Point(46, 148);
            this.btnGuardarTratamiento.Margin = new System.Windows.Forms.Padding(1);
            this.btnGuardarTratamiento.Name = "btnGuardarTratamiento";
            this.btnGuardarTratamiento.Size = new System.Drawing.Size(127, 36);
            this.btnGuardarTratamiento.TabIndex = 13;
            this.btnGuardarTratamiento.Text = "Ingresar Tratamiento";
            this.btnGuardarTratamiento.UseVisualStyleBackColor = false;
            this.btnGuardarTratamiento.Click += new System.EventHandler(this.btnGuardarTratamiento_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(193, 148);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 36);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtDescTratamiento);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(593, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(238, 180);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Descripción del Tratamineto";
            // 
            // txtDescTratamiento
            // 
            this.txtDescTratamiento.Location = new System.Drawing.Point(6, 19);
            this.txtDescTratamiento.Multiline = true;
            this.txtDescTratamiento.Name = "txtDescTratamiento";
            this.txtDescTratamiento.Size = new System.Drawing.Size(226, 155);
            this.txtDescTratamiento.TabIndex = 24;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.calendarCreacion);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(340, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(247, 180);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fecha de Creación";
            // 
            // calendarCreacion
            // 
            this.calendarCreacion.Location = new System.Drawing.Point(12, 14);
            this.calendarCreacion.Name = "calendarCreacion";
            this.calendarCreacion.TabIndex = 0;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(141, 57);
            this.txtValorTotal.MaxLength = 11;
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(181, 20);
            this.txtValorTotal.TabIndex = 23;
            this.txtValorTotal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValorTotal_KeyUp);
            // 
            // cmbFicha
            // 
            this.cmbFicha.FormattingEnabled = true;
            this.cmbFicha.Location = new System.Drawing.Point(141, 22);
            this.cmbFicha.Name = "cmbFicha";
            this.cmbFicha.Size = new System.Drawing.Size(181, 21);
            this.cmbFicha.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Valor Total                  $";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ficha de Paciente";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GridTratamiento);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(6, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1086, 370);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de Tratamientos";
            // 
            // GridTratamiento
            // 
            this.GridTratamiento.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridTratamiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridTratamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTratamiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTratamientoDentalDataGridViewTextBoxColumn,
            this.idFichaDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.tratamientoDataGridViewTextBoxColumn,
            this.fechaSeguimientoDataGridViewTextBoxColumn,
            this.valorTotalDataGridViewTextBoxColumn,
            this.totalAbonoDataGridViewTextBoxColumn,
            this.editar,
            this.Abonos});
            this.GridTratamiento.DataSource = this.tratamientodentalBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridTratamiento.DefaultCellStyle = dataGridViewCellStyle5;
            this.GridTratamiento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridTratamiento.Location = new System.Drawing.Point(6, 19);
            this.GridTratamiento.Name = "GridTratamiento";
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.GridTratamiento.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.GridTratamiento.Size = new System.Drawing.Size(1074, 345);
            this.GridTratamiento.TabIndex = 11;
            this.GridTratamiento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTratamiento_CellContentClick);
            // 
            // idTratamientoDentalDataGridViewTextBoxColumn
            // 
            this.idTratamientoDentalDataGridViewTextBoxColumn.DataPropertyName = "IdTratamientoDental";
            this.idTratamientoDentalDataGridViewTextBoxColumn.HeaderText = "Id Tratamiento";
            this.idTratamientoDentalDataGridViewTextBoxColumn.Name = "idTratamientoDentalDataGridViewTextBoxColumn";
            // 
            // idFichaDataGridViewTextBoxColumn
            // 
            this.idFichaDataGridViewTextBoxColumn.DataPropertyName = "IdFicha";
            this.idFichaDataGridViewTextBoxColumn.HeaderText = "Id Ficha";
            this.idFichaDataGridViewTextBoxColumn.Name = "idFichaDataGridViewTextBoxColumn";
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "Fecha Creación";
            this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            // 
            // tratamientoDataGridViewTextBoxColumn
            // 
            this.tratamientoDataGridViewTextBoxColumn.DataPropertyName = "Tratamiento";
            this.tratamientoDataGridViewTextBoxColumn.HeaderText = "Tratamiento";
            this.tratamientoDataGridViewTextBoxColumn.Name = "tratamientoDataGridViewTextBoxColumn";
            // 
            // fechaSeguimientoDataGridViewTextBoxColumn
            // 
            this.fechaSeguimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaSeguimiento";
            this.fechaSeguimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Seguimiento";
            this.fechaSeguimientoDataGridViewTextBoxColumn.Name = "fechaSeguimientoDataGridViewTextBoxColumn";
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            this.valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            this.valorTotalDataGridViewTextBoxColumn.HeaderText = "Valor Total";
            this.valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            // 
            // totalAbonoDataGridViewTextBoxColumn
            // 
            this.totalAbonoDataGridViewTextBoxColumn.DataPropertyName = "TotalAbono";
            this.totalAbonoDataGridViewTextBoxColumn.HeaderText = "Total Abono";
            this.totalAbonoDataGridViewTextBoxColumn.Name = "totalAbonoDataGridViewTextBoxColumn";
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar Tratamiento";
            this.editar.Name = "editar";
            this.editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.editar.Text = "Editar Tratamiento";
            // 
            // Abonos
            // 
            this.Abonos.HeaderText = "Ver Abonos";
            this.Abonos.Name = "Abonos";
            this.Abonos.Text = "Editar Abono";
            // 
            // tratamientodentalBindingSource
            // 
            this.tratamientodentalBindingSource.DataSource = typeof(ObjectsBeans.Tratamientodental);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(430, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Administración de Tratamiento Dental";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAdministracionTratamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1124, 650);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionTratamiento";
            this.Text = "SFH - Administración de Tratamientos";
            this.Load += new System.EventHandler(this.frmAdministracionTratamiento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridTratamiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tratamientodentalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.MonthCalendar calendarCreacion;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.ComboBox cmbFicha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardarTratamiento;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.MonthCalendar CalendarSeguimiento;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtDescTratamiento;
        private System.Windows.Forms.DataGridView GridTratamiento;
        private System.Windows.Forms.Label lblIdTratamiento;
        private System.Windows.Forms.BindingSource tratamientodentalBindingSource;
        private System.Windows.Forms.Label lblAbono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTratamientoDentalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFichaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tratamientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSeguimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAbonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.DataGridViewButtonColumn Abonos;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}