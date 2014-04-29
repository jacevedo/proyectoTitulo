namespace SFH_Software
{
    partial class frmAbonos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbonos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GrillaAbonos = new System.Windows.Forms.DataGridView();
            this.abonoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblIdTratamiento = new System.Windows.Forms.Label();
            this.lblIdAbono = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.calendarAbono = new System.Windows.Forms.MonthCalendar();
            this.btnGuardarAbono = new System.Windows.Forms.Button();
            this.btnAdminCli = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumTratamiento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.idAbonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTratamientoDentalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAbonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAbonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abonoBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(36, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1136, 477);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración Abonos";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GrillaAbonos);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(233, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(683, 206);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de Abonos";
            // 
            // GrillaAbonos
            // 
            this.GrillaAbonos.AutoGenerateColumns = false;
            this.GrillaAbonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaAbonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAbonoDataGridViewTextBoxColumn,
            this.idTratamientoDentalDataGridViewTextBoxColumn,
            this.fechaAbonoDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn,
            this.btnEditar,
            this.btnEliminar});
            this.GrillaAbonos.DataSource = this.abonoBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaAbonos.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaAbonos.Location = new System.Drawing.Point(6, 19);
            this.GrillaAbonos.Name = "GrillaAbonos";
            this.GrillaAbonos.ReadOnly = true;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.GrillaAbonos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaAbonos.Size = new System.Drawing.Size(671, 181);
            this.GrillaAbonos.TabIndex = 0;
            this.GrillaAbonos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaAbonos_CellContentClick);
            // 
            // abonoBindingSource
            // 
            this.abonoBindingSource.DataSource = typeof(ObjectsBeans.Abono);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblIdTratamiento);
            this.groupBox2.Controls.Add(this.lblIdAbono);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.btnGuardarAbono);
            this.groupBox2.Controls.Add(this.btnAdminCli);
            this.groupBox2.Controls.Add(this.txtMonto);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblNumTratamiento);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(232, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 225);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Abono";
            // 
            // lblIdTratamiento
            // 
            this.lblIdTratamiento.AutoSize = true;
            this.lblIdTratamiento.Location = new System.Drawing.Point(135, 165);
            this.lblIdTratamiento.Name = "lblIdTratamiento";
            this.lblIdTratamiento.Size = new System.Drawing.Size(0, 13);
            this.lblIdTratamiento.TabIndex = 18;
            this.lblIdTratamiento.Visible = false;
            // 
            // lblIdAbono
            // 
            this.lblIdAbono.AutoSize = true;
            this.lblIdAbono.Location = new System.Drawing.Point(19, 165);
            this.lblIdAbono.Name = "lblIdAbono";
            this.lblIdAbono.Size = new System.Drawing.Size(0, 13);
            this.lblIdAbono.TabIndex = 17;
            this.lblIdAbono.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.calendarAbono);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox4.Location = new System.Drawing.Point(391, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(276, 203);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fecha";
            // 
            // calendarAbono
            // 
            this.calendarAbono.Location = new System.Drawing.Point(28, 24);
            this.calendarAbono.Name = "calendarAbono";
            this.calendarAbono.TabIndex = 4;
            // 
            // btnGuardarAbono
            // 
            this.btnGuardarAbono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardarAbono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnGuardarAbono.ForeColor = System.Drawing.Color.White;
            this.btnGuardarAbono.Location = new System.Drawing.Point(186, 108);
            this.btnGuardarAbono.Margin = new System.Windows.Forms.Padding(1);
            this.btnGuardarAbono.Name = "btnGuardarAbono";
            this.btnGuardarAbono.Size = new System.Drawing.Size(127, 36);
            this.btnGuardarAbono.TabIndex = 15;
            this.btnGuardarAbono.Text = "Guardar";
            this.btnGuardarAbono.UseVisualStyleBackColor = false;
            this.btnGuardarAbono.Click += new System.EventHandler(this.btnGuardarAbono_Click);
            // 
            // btnAdminCli
            // 
            this.btnAdminCli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdminCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnAdminCli.ForeColor = System.Drawing.Color.White;
            this.btnAdminCli.Location = new System.Drawing.Point(11, 108);
            this.btnAdminCli.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdminCli.Name = "btnAdminCli";
            this.btnAdminCli.Size = new System.Drawing.Size(129, 36);
            this.btnAdminCli.TabIndex = 14;
            this.btnAdminCli.Text = "Cancelar";
            this.btnAdminCli.UseVisualStyleBackColor = false;
            this.btnAdminCli.Click += new System.EventHandler(this.btnAdminCli_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(138, 40);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monto Abonado";
            // 
            // lblNumTratamiento
            // 
            this.lblNumTratamiento.AutoSize = true;
            this.lblNumTratamiento.Location = new System.Drawing.Point(144, 16);
            this.lblNumTratamiento.Name = "lblNumTratamiento";
            this.lblNumTratamiento.Size = new System.Drawing.Size(0, 13);
            this.lblNumTratamiento.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(524, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Administración de Abonos Monetarios";
            // 
            // idAbonoDataGridViewTextBoxColumn
            // 
            this.idAbonoDataGridViewTextBoxColumn.DataPropertyName = "IdAbono";
            this.idAbonoDataGridViewTextBoxColumn.HeaderText = "Abono";
            this.idAbonoDataGridViewTextBoxColumn.Name = "idAbonoDataGridViewTextBoxColumn";
            this.idAbonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idTratamientoDentalDataGridViewTextBoxColumn
            // 
            this.idTratamientoDentalDataGridViewTextBoxColumn.DataPropertyName = "IdTratamientoDental";
            this.idTratamientoDentalDataGridViewTextBoxColumn.HeaderText = "Tratamiento";
            this.idTratamientoDentalDataGridViewTextBoxColumn.Name = "idTratamientoDentalDataGridViewTextBoxColumn";
            this.idTratamientoDentalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaAbonoDataGridViewTextBoxColumn
            // 
            this.fechaAbonoDataGridViewTextBoxColumn.DataPropertyName = "FechaAbono";
            this.fechaAbonoDataGridViewTextBoxColumn.FillWeight = 120F;
            this.fechaAbonoDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaAbonoDataGridViewTextBoxColumn.Name = "fechaAbonoDataGridViewTextBoxColumn";
            this.fechaAbonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnEditar
            // 
            this.btnEditar.HeaderText = "Editar";
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ReadOnly = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "Eliminar";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            // 
            // frmAbonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1208, 553);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAbonos";
            this.Text = "SFH - Abonos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAbonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abonoBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource abonoBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView GrillaAbonos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNumTratamiento;
        private System.Windows.Forms.MonthCalendar calendarAbono;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGuardarAbono;
        private System.Windows.Forms.Button btnAdminCli;
        private System.Windows.Forms.Label lblIdTratamiento;
        private System.Windows.Forms.Label lblIdAbono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAbonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTratamientoDentalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAbonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
    }
}