namespace SFH_Software
{
    partial class frmAdministracionListasDePrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionListasDePrecios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridCarrera = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAdminCli = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Id_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datGridIdCarrera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datGridNomCarrera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditarCarrera = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEliminarCarrera = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCarrera)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1010, 559);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de precios";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridCarrera);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(102, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(769, 298);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista de precios";
            // 
            // dataGridCarrera
            // 
            this.dataGridCarrera.AllowUserToOrderColumns = true;
            this.dataGridCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCarrera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_precio,
            this.datGridIdCarrera,
            this.datGridNomCarrera,
            this.btnEditarCarrera,
            this.btnEliminarCarrera});
            this.dataGridCarrera.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridCarrera.Location = new System.Drawing.Point(22, 19);
            this.dataGridCarrera.Name = "dataGridCarrera";
            this.dataGridCarrera.Size = new System.Drawing.Size(728, 265);
            this.dataGridCarrera.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnAdminCli);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(207, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 216);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Precio                        $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre Procedimiento";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(218, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(201, 20);
            this.textBox2.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(218, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 20);
            this.textBox1.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(292, 164);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 36);
            this.button2.TabIndex = 13;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnAdminCli
            // 
            this.btnAdminCli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdminCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnAdminCli.ForeColor = System.Drawing.Color.White;
            this.btnAdminCli.Location = new System.Drawing.Point(100, 164);
            this.btnAdminCli.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdminCli.Name = "btnAdminCli";
            this.btnAdminCli.Size = new System.Drawing.Size(129, 36);
            this.btnAdminCli.TabIndex = 11;
            this.btnAdminCli.Text = "Cancelar";
            this.btnAdminCli.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(316, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Administración de listas de precios por tratamiento";
            // 
            // Id_precio
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Id_precio.DefaultCellStyle = dataGridViewCellStyle1;
            this.Id_precio.HeaderText = "Id Precio";
            this.Id_precio.Name = "Id_precio";
            // 
            // datGridIdCarrera
            // 
            this.datGridIdCarrera.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datGridIdCarrera.DataPropertyName = "nom_precio";
            this.datGridIdCarrera.HeaderText = "Nombre";
            this.datGridIdCarrera.Name = "datGridIdCarrera";
            // 
            // datGridNomCarrera
            // 
            this.datGridNomCarrera.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datGridNomCarrera.DataPropertyName = "nombre_carrera";
            this.datGridNomCarrera.HeaderText = "Precio $";
            this.datGridNomCarrera.Name = "datGridNomCarrera";
            // 
            // btnEditarCarrera
            // 
            this.btnEditarCarrera.HeaderText = "Editar Precio";
            this.btnEditarCarrera.Name = "btnEditarCarrera";
            // 
            // btnEliminarCarrera
            // 
            this.btnEliminarCarrera.HeaderText = "Eliminar Precio";
            this.btnEliminarCarrera.Name = "btnEliminarCarrera";
            // 
            // frmAdministracionListasDePrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1034, 612);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionListasDePrecios";
            this.Text = "AdministracionListasDePrecios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCarrera)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAdminCli;
        private System.Windows.Forms.DataGridView dataGridCarrera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn datGridIdCarrera;
        private System.Windows.Forms.DataGridViewTextBoxColumn datGridNomCarrera;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditarCarrera;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminarCarrera;
    }
}