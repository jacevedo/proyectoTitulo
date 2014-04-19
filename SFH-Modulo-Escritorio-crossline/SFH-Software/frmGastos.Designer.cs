namespace SFH_Software
{
    partial class frmGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGastos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridGastos = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbxPersonaBusqueda = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbxpersona = new System.Windows.Forms.ComboBox();
            this.txtConcept = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MntCalendarGastos = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.idgastos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentogasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conceptogasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechasGastos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.verinsumos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGastos)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1268, 832);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de Gastos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridGastos);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(20, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1228, 517);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de Gastos";
            // 
            // dataGridGastos
            // 
            this.dataGridGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idgastos,
            this.idpersona,
            this.monto,
            this.descuentogasto,
            this.conceptogasto,
            this.nombre,
            this.apellido,
            this.FechasGastos,
            this.editar,
            this.eliminar,
            this.verinsumos});
            this.dataGridGastos.Location = new System.Drawing.Point(21, 85);
            this.dataGridGastos.Name = "dataGridGastos";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridGastos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridGastos.Size = new System.Drawing.Size(1190, 426);
            this.dataGridGastos.TabIndex = 4;
            this.dataGridGastos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridGastos_CellContentClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBuscar);
            this.groupBox4.Controls.Add(this.cmbxPersonaBusqueda);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Location = new System.Drawing.Point(265, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(610, 66);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Búsqueda de insumos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(385, 17);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(1);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(127, 36);
            this.btnBuscar.TabIndex = 58;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbxPersonaBusqueda
            // 
            this.cmbxPersonaBusqueda.FormattingEnabled = true;
            this.cmbxPersonaBusqueda.Location = new System.Drawing.Point(191, 26);
            this.cmbxPersonaBusqueda.Name = "cmbxPersonaBusqueda";
            this.cmbxPersonaBusqueda.Size = new System.Drawing.Size(170, 21);
            this.cmbxPersonaBusqueda.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(83, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Ver Gastos de";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.MntCalendarGastos);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbxpersona);
            this.groupBox2.Controls.Add(this.txtConcept);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDescuento);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtMonto);
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(20, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1228, 278);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingresar gastos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Concepto de gasto";
            // 
            // cmbxpersona
            // 
            this.cmbxpersona.FormattingEnabled = true;
            this.cmbxpersona.Location = new System.Drawing.Point(178, 40);
            this.cmbxpersona.Name = "cmbxpersona";
            this.cmbxpersona.Size = new System.Drawing.Size(215, 21);
            this.cmbxpersona.TabIndex = 39;
            // 
            // txtConcept
            // 
            this.txtConcept.Location = new System.Drawing.Point(178, 79);
            this.txtConcept.Multiline = true;
            this.txtConcept.Name = "txtConcept";
            this.txtConcept.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConcept.Size = new System.Drawing.Size(215, 94);
            this.txtConcept.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Persona";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(433, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Descuento";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(562, 76);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(215, 20);
            this.txtDescuento.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Monto del gasto     $";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(562, 37);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(215, 20);
            this.txtMonto.TabIndex = 14;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(1002, 222);
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
            this.btnCancel.Location = new System.Drawing.Point(852, 222);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 36);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(539, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Administración de gastos";
            // 
            // MntCalendarGastos
            // 
            this.MntCalendarGastos.Location = new System.Drawing.Point(900, 40);
            this.MntCalendarGastos.Name = "MntCalendarGastos";
            this.MntCalendarGastos.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(807, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Fecha de gasto";
            // 
            // idgastos
            // 
            this.idgastos.DataPropertyName = "IdGastos";
            this.idgastos.HeaderText = "Id Gastos";
            this.idgastos.Name = "idgastos";
            // 
            // idpersona
            // 
            this.idpersona.DataPropertyName = "IdPersona";
            this.idpersona.HeaderText = "Id Persona";
            this.idpersona.Name = "idpersona";
            this.idpersona.Visible = false;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "MontoGastos";
            this.monto.HeaderText = "Monto gasto";
            this.monto.Name = "monto";
            // 
            // descuentogasto
            // 
            this.descuentogasto.DataPropertyName = "DescuentoGastos";
            this.descuentogasto.HeaderText = "Descuento Gasto";
            this.descuentogasto.Name = "descuentogasto";
            // 
            // conceptogasto
            // 
            this.conceptogasto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.conceptogasto.DataPropertyName = "ConceptodeGastos";
            this.conceptogasto.HeaderText = "Concepto gasto";
            this.conceptogasto.Name = "conceptogasto";
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "Apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            // 
            // FechasGastos
            // 
            this.FechasGastos.DataPropertyName = "FechaGastos";
            this.FechasGastos.HeaderText = "Fechas de Gastos";
            this.FechasGastos.Name = "FechasGastos";
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar gastos";
            this.editar.Name = "editar";
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar gasto";
            this.eliminar.Name = "eliminar";
            // 
            // verinsumos
            // 
            this.verinsumos.HeaderText = "Ver insumos";
            this.verinsumos.Name = "verinsumos";
            this.verinsumos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.verinsumos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1293, 874);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGastos";
            this.Text = "frmGastos";
            this.Load += new System.EventHandler(this.frmGastos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGastos)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbxPersonaBusqueda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbxpersona;
        private System.Windows.Forms.TextBox txtConcept;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridGastos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar MntCalendarGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idgastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuentogasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn conceptogasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechasGastos;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.DataGridViewButtonColumn eliminar;
        private System.Windows.Forms.DataGridViewButtonColumn verinsumos;
    }
}