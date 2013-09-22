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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionTratamiento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CalendarSeguimiento = new System.Windows.Forms.MonthCalendar();
            this.btnGuardarTratamiento = new System.Windows.Forms.Button();
            this.btnAdminCli = new System.Windows.Forms.Button();
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
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tratamientodentalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIdTratamiento = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTratamiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tratamientodentalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1098, 559);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de tratamiento dental";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblIdTratamiento);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.btnGuardarTratamiento);
            this.groupBox2.Controls.Add(this.btnAdminCli);
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
            this.groupBox2.Text = "Crear presupuesto";
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
            this.btnGuardarTratamiento.Location = new System.Drawing.Point(195, 148);
            this.btnGuardarTratamiento.Margin = new System.Windows.Forms.Padding(1);
            this.btnGuardarTratamiento.Name = "btnGuardarTratamiento";
            this.btnGuardarTratamiento.Size = new System.Drawing.Size(127, 36);
            this.btnGuardarTratamiento.TabIndex = 13;
            this.btnGuardarTratamiento.Text = "Guardar";
            this.btnGuardarTratamiento.UseVisualStyleBackColor = false;
            this.btnGuardarTratamiento.Click += new System.EventHandler(this.btnGuardarTratamiento_Click);
            // 
            // btnAdminCli
            // 
            this.btnAdminCli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdminCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnAdminCli.ForeColor = System.Drawing.Color.White;
            this.btnAdminCli.Location = new System.Drawing.Point(20, 148);
            this.btnAdminCli.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdminCli.Name = "btnAdminCli";
            this.btnAdminCli.Size = new System.Drawing.Size(129, 36);
            this.btnAdminCli.TabIndex = 11;
            this.btnAdminCli.Text = "Cancelar";
            this.btnAdminCli.UseVisualStyleBackColor = false;
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
            this.groupBox6.Text = "Descripción de Tratamineto";
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
            this.calendarCreacion.Location = new System.Drawing.Point(12, 12);
            this.calendarCreacion.Name = "calendarCreacion";
            this.calendarCreacion.TabIndex = 0;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(141, 57);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(181, 20);
            this.txtValorTotal.TabIndex = 23;
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
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(6, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1086, 332);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de Tratamientos";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // GridTratamiento
            // 
            this.GridTratamiento.AutoGenerateColumns = false;
            this.GridTratamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTratamiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTratamientoDentalDataGridViewTextBoxColumn,
            this.idFichaDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.tratamientoDataGridViewTextBoxColumn,
            this.fechaSeguimientoDataGridViewTextBoxColumn,
            this.valorTotalDataGridViewTextBoxColumn,
            this.editar});
            this.GridTratamiento.DataSource = this.tratamientodentalBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridTratamiento.DefaultCellStyle = dataGridViewCellStyle1;
            this.GridTratamiento.Location = new System.Drawing.Point(6, 43);
            this.GridTratamiento.Name = "GridTratamiento";
            this.GridTratamiento.Size = new System.Drawing.Size(1074, 283);
            this.GridTratamiento.TabIndex = 11;
            this.GridTratamiento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTratamiento_CellContentClick);
            // 
            // idTratamientoDentalDataGridViewTextBoxColumn
            // 
            this.idTratamientoDentalDataGridViewTextBoxColumn.DataPropertyName = "IdTratamientoDental";
            this.idTratamientoDentalDataGridViewTextBoxColumn.HeaderText = "IdTratamientoDental";
            this.idTratamientoDentalDataGridViewTextBoxColumn.Name = "idTratamientoDentalDataGridViewTextBoxColumn";
            // 
            // idFichaDataGridViewTextBoxColumn
            // 
            this.idFichaDataGridViewTextBoxColumn.DataPropertyName = "IdFicha";
            this.idFichaDataGridViewTextBoxColumn.HeaderText = "IdFicha";
            this.idFichaDataGridViewTextBoxColumn.Name = "idFichaDataGridViewTextBoxColumn";
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "FechaCreacion";
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
            this.fechaSeguimientoDataGridViewTextBoxColumn.HeaderText = "FechaSeguimiento";
            this.fechaSeguimientoDataGridViewTextBoxColumn.Name = "fechaSeguimientoDataGridViewTextBoxColumn";
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            this.valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            this.valorTotalDataGridViewTextBoxColumn.HeaderText = "ValorTotal";
            this.valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar tratamiento";
            this.editar.Name = "editar";
            this.editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tratamientodentalBindingSource
            // 
            this.tratamientodentalBindingSource.DataSource = typeof(ObjectsBeans.Tratamientodental);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(600, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Gonzalo Guerra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(391, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Listado Tratamiento dental :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(430, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Administración de tratamiento dental";
            // 
            // lblIdTratamiento
            // 
            this.lblIdTratamiento.AutoSize = true;
            this.lblIdTratamiento.Location = new System.Drawing.Point(71, 97);
            this.lblIdTratamiento.Name = "lblIdTratamiento";
            this.lblIdTratamiento.Size = new System.Drawing.Size(0, 13);
            this.lblIdTratamiento.TabIndex = 28;
            // 
            // frmAdministracionTratamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1122, 612);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionTratamiento";
            this.Text = "AdministracionTratamiento";
            this.Load += new System.EventHandler(this.frmAdministracionTratamiento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTratamiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tratamientodentalBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnAdminCli;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.MonthCalendar CalendarSeguimiento;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtDescTratamiento;
        private System.Windows.Forms.DataGridView GridTratamiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource tratamientodentalBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTratamientoDentalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFichaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tratamientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSeguimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.Label lblIdTratamiento;
    }
}