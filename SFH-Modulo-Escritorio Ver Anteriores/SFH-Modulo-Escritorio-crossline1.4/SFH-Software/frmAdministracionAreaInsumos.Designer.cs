namespace SFH_Software
{
    partial class frmAdministracionAreaInsumos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionAreaInsumos));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridAreaInsumo = new System.Windows.Forms.DataGridView();
            this.IdAreaInsumos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreAreaInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripciondearea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Vergastos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtdes = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAreaInsumo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(573, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Administración Área Insumos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1289, 691);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de Área Insumo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridAreaInsumo);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(18, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1254, 432);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista Área Insumo";
            // 
            // dataGridAreaInsumo
            // 
            this.dataGridAreaInsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAreaInsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAreaInsumos,
            this.nombreAreaInsumo,
            this.descripciondearea,
            this.Editar,
            this.Eliminar,
            this.Vergastos});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridAreaInsumo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridAreaInsumo.Location = new System.Drawing.Point(34, 34);
            this.dataGridAreaInsumo.Name = "dataGridAreaInsumo";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dataGridAreaInsumo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridAreaInsumo.Size = new System.Drawing.Size(1197, 390);
            this.dataGridAreaInsumo.TabIndex = 4;
            this.dataGridAreaInsumo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAreaInsumo_CellContentClick);
            // 
            // IdAreaInsumos
            // 
            this.IdAreaInsumos.DataPropertyName = "IdAreaInsumo";
            this.IdAreaInsumos.HeaderText = "Id Area Insumo";
            this.IdAreaInsumos.Name = "IdAreaInsumos";
            // 
            // nombreAreaInsumo
            // 
            this.nombreAreaInsumo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreAreaInsumo.DataPropertyName = "NombreArea";
            this.nombreAreaInsumo.HeaderText = "Nombre Área";
            this.nombreAreaInsumo.Name = "nombreAreaInsumo";
            // 
            // descripciondearea
            // 
            this.descripciondearea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripciondearea.DataPropertyName = "DescripcionArea";
            this.descripciondearea.HeaderText = "Descripción";
            this.descripciondearea.Name = "descripciondearea";
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar Área Insumos";
            this.Editar.Name = "Editar";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar Área Insumos";
            this.Eliminar.Name = "Eliminar";
            // 
            // Vergastos
            // 
            this.Vergastos.HeaderText = "Ver Gastos";
            this.Vergastos.Name = "Vergastos";
            this.Vergastos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Vergastos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNom);
            this.groupBox2.Controls.Add(this.txtdes);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(18, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1254, 227);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar Insumo";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(665, 174);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(1);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(127, 36);
            this.btnNuevo.TabIndex = 60;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre de Área";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(519, 22);
            this.txtNom.MaxLength = 50;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(273, 20);
            this.txtNom.TabIndex = 15;
            this.txtNom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNom_KeyUp);
            // 
            // txtdes
            // 
            this.txtdes.Location = new System.Drawing.Point(519, 56);
            this.txtdes.Multiline = true;
            this.txtdes.Name = "txtdes";
            this.txtdes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdes.Size = new System.Drawing.Size(273, 98);
            this.txtdes.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(519, 174);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 36);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAdministracionAreaInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1284, 730);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionAreaInsumos";
            this.Text = "SFH - Administración Área Insumos";
            this.Load += new System.EventHandler(this.frmAdministracionAreaInsumos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAreaInsumo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtdes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dataGridAreaInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAreaInsumos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreAreaInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripciondearea;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewButtonColumn Vergastos;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}