namespace SFH_Software
{
    partial class frmListarHistorialdeReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarHistorialdeReportes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.datagridhistorial = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbxHastaFecha = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbxDesdeFecha = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IdPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nomperfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdReporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoReporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.query = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechainicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechatermino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridhistorial)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(3, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1141, 666);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listar Historial de Reportes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datagridhistorial);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(9, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1126, 544);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Historial de Reportes";
            // 
            // datagridhistorial
            // 
            this.datagridhistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridhistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPersona,
            this.IdPerfil,
            this.Nomperfil,
            this.IdReporte,
            this.Rut,
            this.Dv,
            this.Nombre,
            this.ApellidoPaterno,
            this.ApellidoMaterno,
            this.FechaCreacion,
            this.TipoReporte,
            this.FechaNacimiento,
            this.query,
            this.fechainicio,
            this.fechatermino});
            this.datagridhistorial.Location = new System.Drawing.Point(73, 19);
            this.datagridhistorial.Name = "datagridhistorial";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.datagridhistorial.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridhistorial.Size = new System.Drawing.Size(968, 519);
            this.datagridhistorial.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.cmbxHastaFecha);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnBuscar);
            this.groupBox4.Controls.Add(this.cmbxDesdeFecha);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Location = new System.Drawing.Point(219, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(677, 100);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "v";
            this.groupBox4.Text = "Filtrar Historial";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(350, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 36);
            this.button1.TabIndex = 61;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(487, 51);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(1);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(127, 36);
            this.btnBuscar.TabIndex = 58;
            this.btnBuscar.Text = "Mostar Historial";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(523, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Listar Historial de Reportes";
            // 
            // IdPersona
            // 
            this.IdPersona.DataPropertyName = "IdPersona";
            this.IdPersona.HeaderText = "IdPersona";
            this.IdPersona.Name = "IdPersona";
            this.IdPersona.Visible = false;
            // 
            // IdPerfil
            // 
            this.IdPerfil.DataPropertyName = "IdPerfil";
            this.IdPerfil.HeaderText = "IdPerfil";
            this.IdPerfil.Name = "IdPerfil";
            this.IdPerfil.Visible = false;
            // 
            // Nomperfil
            // 
            this.Nomperfil.DataPropertyName = "Nomperfil";
            this.Nomperfil.HeaderText = "Nomperfil";
            this.Nomperfil.Name = "Nomperfil";
            this.Nomperfil.Visible = false;
            // 
            // IdReporte
            // 
            this.IdReporte.DataPropertyName = "IdReporte";
            this.IdReporte.HeaderText = "IdReporte";
            this.IdReporte.Name = "IdReporte";
            this.IdReporte.Visible = false;
            // 
            // Rut
            // 
            this.Rut.DataPropertyName = "Rut";
            this.Rut.HeaderText = "Rut";
            this.Rut.Name = "Rut";
            // 
            // Dv
            // 
            this.Dv.DataPropertyName = "Dv";
            this.Dv.HeaderText = "Dv";
            this.Dv.Name = "Dv";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // ApellidoPaterno
            // 
            this.ApellidoPaterno.DataPropertyName = "ApellidoPaterno";
            this.ApellidoPaterno.HeaderText = "ApellidoPaterno";
            this.ApellidoPaterno.Name = "ApellidoPaterno";
            // 
            // ApellidoMaterno
            // 
            this.ApellidoMaterno.DataPropertyName = "ApellidoMaterno";
            this.ApellidoMaterno.HeaderText = "ApellidoMaterno";
            this.ApellidoMaterno.Name = "ApellidoMaterno";
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "FechaCreacion";
            this.FechaCreacion.HeaderText = "FechaCreacion";
            this.FechaCreacion.Name = "FechaCreacion";
            // 
            // TipoReporte
            // 
            this.TipoReporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TipoReporte.DataPropertyName = "TipoReporte";
            this.TipoReporte.HeaderText = "TipoReporte";
            this.TipoReporte.Name = "TipoReporte";
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.DataPropertyName = "FechaNacimiento";
            this.FechaNacimiento.HeaderText = "FechaNacimiento";
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.Visible = false;
            // 
            // query
            // 
            this.query.DataPropertyName = "Query";
            this.query.HeaderText = "query";
            this.query.Name = "query";
            this.query.Visible = false;
            // 
            // fechainicio
            // 
            this.fechainicio.DataPropertyName = "Fecha_inicio";
            this.fechainicio.HeaderText = "fechainicio";
            this.fechainicio.Name = "fechainicio";
            this.fechainicio.Visible = false;
            // 
            // fechatermino
            // 
            this.fechatermino.DataPropertyName = "Fecha_termino";
            this.fechatermino.HeaderText = "fechatermino";
            this.fechatermino.Name = "fechatermino";
            this.fechatermino.Visible = false;
            // 
            // frmListarHistorialdeReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1156, 710);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListarHistorialdeReportes";
            this.Text = "SFH - Listar Historial de Reportes";
            this.Load += new System.EventHandler(this.frmListarHistorialdeReportes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridhistorial)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView datagridhistorial;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbxHastaFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbxDesdeFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomperfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn query;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechainicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechatermino;
    }
}