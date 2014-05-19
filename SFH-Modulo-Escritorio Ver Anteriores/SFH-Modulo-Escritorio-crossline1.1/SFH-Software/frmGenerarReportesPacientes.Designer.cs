namespace SFH_Software
{
    partial class frmGenerarReportesPacientes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarReportesPacientes));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chtGrafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbxHastaFecha = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btngenerar = new System.Windows.Forms.Button();
            this.cmbxDesdeFecha = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtGrafico)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(574, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Generar Reportes Pacientes";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(3, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1264, 684);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generar Reportes Pacientes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chtGrafico);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(9, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1249, 559);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reporte Generado";
            // 
            // chtGrafico
            // 
            chartArea1.Name = "ChartArea1";
            this.chtGrafico.ChartAreas.Add(chartArea1);
            this.chtGrafico.Location = new System.Drawing.Point(17, 16);
            this.chtGrafico.Name = "chtGrafico";
            this.chtGrafico.Size = new System.Drawing.Size(1216, 534);
            this.chtGrafico.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCancelar);
            this.groupBox4.Controls.Add(this.cmbxHastaFecha);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btngenerar);
            this.groupBox4.Controls.Add(this.cmbxDesdeFecha);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Location = new System.Drawing.Point(270, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(677, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "v";
            this.groupBox4.Text = "Herramienta de Reportes";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(350, 56);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 36);
            this.btnCancelar.TabIndex = 61;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbxHastaFecha
            // 
            this.cmbxHastaFecha.FormattingEnabled = true;
            this.cmbxHastaFecha.Location = new System.Drawing.Point(445, 19);
            this.cmbxHastaFecha.Name = "cmbxHastaFecha";
            this.cmbxHastaFecha.Size = new System.Drawing.Size(170, 21);
            this.cmbxHastaFecha.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Hasta";
            // 
            // btngenerar
            // 
            this.btngenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btngenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btngenerar.ForeColor = System.Drawing.Color.White;
            this.btngenerar.Location = new System.Drawing.Point(487, 56);
            this.btngenerar.Margin = new System.Windows.Forms.Padding(1);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(127, 36);
            this.btngenerar.TabIndex = 58;
            this.btngenerar.Text = "Generar Reporte";
            this.btngenerar.UseVisualStyleBackColor = false;
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // cmbxDesdeFecha
            // 
            this.cmbxDesdeFecha.FormattingEnabled = true;
            this.cmbxDesdeFecha.Location = new System.Drawing.Point(129, 19);
            this.cmbxDesdeFecha.Name = "cmbxDesdeFecha";
            this.cmbxDesdeFecha.Size = new System.Drawing.Size(170, 21);
            this.cmbxDesdeFecha.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Desde";
            // 
            // frmGenerarReportesPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1270, 722);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGenerarReportesPacientes";
            this.Text = "SFH - Administracion de Reportería";
            this.Load += new System.EventHandler(this.frmAdministracionDeReporteria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtGrafico)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbxHastaFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btngenerar;
        private System.Windows.Forms.ComboBox cmbxDesdeFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtGrafico;


    }
}