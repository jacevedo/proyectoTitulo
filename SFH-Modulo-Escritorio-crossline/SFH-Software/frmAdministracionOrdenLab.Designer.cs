namespace SFH_Software
{
    partial class frmAdministracionOrdenLab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionOrdenLab));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GrillaOrden = new System.Windows.Forms.DataGridView();
            this.numeroOrdenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomPacienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomOdontologoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrdenLaboratorioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOdontologoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPacienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinicaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.biDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadodeordenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditarCarrera = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ordendelaboratorioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblIdOrden = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.calendarEntrega = new System.Windows.Forms.MonthCalendar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CalendarCreacion = new System.Windows.Forms.MonthCalendar();
            this.label12 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtHoraEntrega = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBI = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNomOdontologo = new System.Windows.Forms.ComboBox();
            this.personaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cmbNomPaciente = new System.Windows.Forms.ComboBox();
            this.personaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtLaboratorio = new System.Windows.Forms.TextBox();
            this.txtNumOrden = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAdminCli = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordendelaboratorioBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personaBindingSource1)).BeginInit();
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
            this.groupBox1.Size = new System.Drawing.Size(1010, 720);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de Orden de Laboratorio";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GrillaOrden);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(23, 412);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(968, 299);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de ordenes";
            // 
            // GrillaOrden
            // 
            this.GrillaOrden.AllowUserToDeleteRows = false;
            this.GrillaOrden.AllowUserToOrderColumns = true;
            this.GrillaOrden.AutoGenerateColumns = false;
            this.GrillaOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaOrden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroOrdenDataGridViewTextBoxColumn,
            this.nomPacienteDataGridViewTextBoxColumn,
            this.nomOdontologoDataGridViewTextBoxColumn,
            this.idOrdenLaboratorioDataGridViewTextBoxColumn,
            this.idOdontologoDataGridViewTextBoxColumn,
            this.idPacienteDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.clinicaDataGridViewTextBoxColumn,
            this.bdDataGridViewTextBoxColumn,
            this.biDataGridViewTextBoxColumn,
            this.pdDataGridViewTextBoxColumn,
            this.piDataGridViewTextBoxColumn,
            this.horaEntregaDataGridViewTextBoxColumn,
            this.fechaEntregaDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.estadodeordenDataGridViewTextBoxColumn,
            this.btnEditarCarrera});
            this.GrillaOrden.DataSource = this.ordendelaboratorioBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrillaOrden.DefaultCellStyle = dataGridViewCellStyle1;
            this.GrillaOrden.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GrillaOrden.Location = new System.Drawing.Point(16, 25);
            this.GrillaOrden.Name = "GrillaOrden";
            this.GrillaOrden.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.GrillaOrden.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GrillaOrden.Size = new System.Drawing.Size(936, 257);
            this.GrillaOrden.TabIndex = 1;
            this.GrillaOrden.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaOrden_CellContentClick);
            // 
            // numeroOrdenDataGridViewTextBoxColumn
            // 
            this.numeroOrdenDataGridViewTextBoxColumn.DataPropertyName = "NumeroOrden";
            this.numeroOrdenDataGridViewTextBoxColumn.HeaderText = "No Orden";
            this.numeroOrdenDataGridViewTextBoxColumn.Name = "numeroOrdenDataGridViewTextBoxColumn";
            this.numeroOrdenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomPacienteDataGridViewTextBoxColumn
            // 
            this.nomPacienteDataGridViewTextBoxColumn.DataPropertyName = "NomPaciente";
            this.nomPacienteDataGridViewTextBoxColumn.HeaderText = "Nombre Paciente";
            this.nomPacienteDataGridViewTextBoxColumn.Name = "nomPacienteDataGridViewTextBoxColumn";
            this.nomPacienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomOdontologoDataGridViewTextBoxColumn
            // 
            this.nomOdontologoDataGridViewTextBoxColumn.DataPropertyName = "NomOdontologo";
            this.nomOdontologoDataGridViewTextBoxColumn.HeaderText = "Nombre Odontólogo";
            this.nomOdontologoDataGridViewTextBoxColumn.Name = "nomOdontologoDataGridViewTextBoxColumn";
            this.nomOdontologoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idOrdenLaboratorioDataGridViewTextBoxColumn
            // 
            this.idOrdenLaboratorioDataGridViewTextBoxColumn.DataPropertyName = "IdOrdenLaboratorio";
            this.idOrdenLaboratorioDataGridViewTextBoxColumn.HeaderText = "IdOrdenLaboratorio";
            this.idOrdenLaboratorioDataGridViewTextBoxColumn.Name = "idOrdenLaboratorioDataGridViewTextBoxColumn";
            this.idOrdenLaboratorioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idOrdenLaboratorioDataGridViewTextBoxColumn.Visible = false;
            // 
            // idOdontologoDataGridViewTextBoxColumn
            // 
            this.idOdontologoDataGridViewTextBoxColumn.DataPropertyName = "IdOdontologo";
            this.idOdontologoDataGridViewTextBoxColumn.HeaderText = "IdOdontologo";
            this.idOdontologoDataGridViewTextBoxColumn.Name = "idOdontologoDataGridViewTextBoxColumn";
            this.idOdontologoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idOdontologoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idPacienteDataGridViewTextBoxColumn
            // 
            this.idPacienteDataGridViewTextBoxColumn.DataPropertyName = "IdPaciente";
            this.idPacienteDataGridViewTextBoxColumn.HeaderText = "IdPaciente";
            this.idPacienteDataGridViewTextBoxColumn.Name = "idPacienteDataGridViewTextBoxColumn";
            this.idPacienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPacienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "Fecha Creación";
            this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            this.fechaCreacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clinicaDataGridViewTextBoxColumn
            // 
            this.clinicaDataGridViewTextBoxColumn.DataPropertyName = "Clinica";
            this.clinicaDataGridViewTextBoxColumn.HeaderText = "Laboratorio";
            this.clinicaDataGridViewTextBoxColumn.Name = "clinicaDataGridViewTextBoxColumn";
            this.clinicaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bdDataGridViewTextBoxColumn
            // 
            this.bdDataGridViewTextBoxColumn.DataPropertyName = "Bd";
            this.bdDataGridViewTextBoxColumn.HeaderText = "BD";
            this.bdDataGridViewTextBoxColumn.Name = "bdDataGridViewTextBoxColumn";
            this.bdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // biDataGridViewTextBoxColumn
            // 
            this.biDataGridViewTextBoxColumn.DataPropertyName = "Bi";
            this.biDataGridViewTextBoxColumn.HeaderText = "BI";
            this.biDataGridViewTextBoxColumn.Name = "biDataGridViewTextBoxColumn";
            this.biDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pdDataGridViewTextBoxColumn
            // 
            this.pdDataGridViewTextBoxColumn.DataPropertyName = "Pd";
            this.pdDataGridViewTextBoxColumn.HeaderText = "PD";
            this.pdDataGridViewTextBoxColumn.Name = "pdDataGridViewTextBoxColumn";
            this.pdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // piDataGridViewTextBoxColumn
            // 
            this.piDataGridViewTextBoxColumn.DataPropertyName = "Pi";
            this.piDataGridViewTextBoxColumn.HeaderText = "PI";
            this.piDataGridViewTextBoxColumn.Name = "piDataGridViewTextBoxColumn";
            this.piDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // horaEntregaDataGridViewTextBoxColumn
            // 
            this.horaEntregaDataGridViewTextBoxColumn.DataPropertyName = "HoraEntrega";
            this.horaEntregaDataGridViewTextBoxColumn.HeaderText = "Hora Entrega";
            this.horaEntregaDataGridViewTextBoxColumn.Name = "horaEntregaDataGridViewTextBoxColumn";
            this.horaEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaEntregaDataGridViewTextBoxColumn
            // 
            this.fechaEntregaDataGridViewTextBoxColumn.DataPropertyName = "FechaEntrega";
            this.fechaEntregaDataGridViewTextBoxColumn.HeaderText = "Fecha Entrega";
            this.fechaEntregaDataGridViewTextBoxColumn.Name = "fechaEntregaDataGridViewTextBoxColumn";
            this.fechaEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "Color";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            this.colorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadodeordenDataGridViewTextBoxColumn
            // 
            this.estadodeordenDataGridViewTextBoxColumn.DataPropertyName = "Estadodeorden";
            this.estadodeordenDataGridViewTextBoxColumn.HeaderText = "Estado Orden";
            this.estadodeordenDataGridViewTextBoxColumn.Name = "estadodeordenDataGridViewTextBoxColumn";
            this.estadodeordenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnEditarCarrera
            // 
            this.btnEditarCarrera.HeaderText = "Editar Orden";
            this.btnEditarCarrera.Name = "btnEditarCarrera";
            this.btnEditarCarrera.ReadOnly = true;
            // 
            // ordendelaboratorioBindingSource
            // 
            this.ordendelaboratorioBindingSource.DataSource = typeof(ObjectsBeans.Ordendelaboratorio);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbEstado);
            this.groupBox2.Controls.Add(this.lblIdOrden);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtColor);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtHoraEntrega);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtPI);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPD);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtBI);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtBD);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbNomOdontologo);
            this.groupBox2.Controls.Add(this.cmbNomPaciente);
            this.groupBox2.Controls.Add(this.txtLaboratorio);
            this.groupBox2.Controls.Add(this.txtNumOrden);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.btnAdminCli);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(23, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(968, 393);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(705, 76);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(148, 21);
            this.cmbEstado.TabIndex = 38;
            // 
            // lblIdOrden
            // 
            this.lblIdOrden.AutoSize = true;
            this.lblIdOrden.Location = new System.Drawing.Point(745, 143);
            this.lblIdOrden.Name = "lblIdOrden";
            this.lblIdOrden.Size = new System.Drawing.Size(0, 13);
            this.lblIdOrden.TabIndex = 37;
            this.lblIdOrden.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.calendarEntrega);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(407, 143);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(274, 202);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fecha de Entrega";
            // 
            // calendarEntrega
            // 
            this.calendarEntrega.Location = new System.Drawing.Point(25, 25);
            this.calendarEntrega.Name = "calendarEntrega";
            this.calendarEntrega.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CalendarCreacion);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(105, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(270, 202);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fecha Creación";
            // 
            // CalendarCreacion
            // 
            this.CalendarCreacion.Location = new System.Drawing.Point(20, 25);
            this.CalendarCreacion.Name = "CalendarCreacion";
            this.CalendarCreacion.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(626, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Estado";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(705, 45);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(148, 20);
            this.txtColor.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(625, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Color";
            // 
            // txtHoraEntrega
            // 
            this.txtHoraEntrega.Location = new System.Drawing.Point(705, 16);
            this.txtHoraEntrega.Name = "txtHoraEntrega";
            this.txtHoraEntrega.Size = new System.Drawing.Size(148, 20);
            this.txtHoraEntrega.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(622, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Hora Entrega";
            // 
            // txtPI
            // 
            this.txtPI.Location = new System.Drawing.Point(459, 108);
            this.txtPI.Name = "txtPI";
            this.txtPI.Size = new System.Drawing.Size(148, 20);
            this.txtPI.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(417, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "PI";
            // 
            // txtPD
            // 
            this.txtPD.Location = new System.Drawing.Point(459, 76);
            this.txtPD.Name = "txtPD";
            this.txtPD.Size = new System.Drawing.Size(148, 20);
            this.txtPD.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(417, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "PD";
            // 
            // txtBI
            // 
            this.txtBI.Location = new System.Drawing.Point(459, 45);
            this.txtBI.Name = "txtBI";
            this.txtBI.Size = new System.Drawing.Size(148, 20);
            this.txtBI.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "BI";
            // 
            // txtBD
            // 
            this.txtBD.Location = new System.Drawing.Point(459, 16);
            this.txtBD.Name = "txtBD";
            this.txtBD.Size = new System.Drawing.Size(148, 20);
            this.txtBD.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "BD";
            // 
            // cmbNomOdontologo
            // 
            this.cmbNomOdontologo.DataSource = this.personaBindingSource1;
            this.cmbNomOdontologo.DisplayMember = "Nombre";
            this.cmbNomOdontologo.FormattingEnabled = true;
            this.cmbNomOdontologo.Location = new System.Drawing.Point(260, 76);
            this.cmbNomOdontologo.Name = "cmbNomOdontologo";
            this.cmbNomOdontologo.Size = new System.Drawing.Size(148, 21);
            this.cmbNomOdontologo.TabIndex = 20;
            this.cmbNomOdontologo.ValueMember = "IdPersona";
            // 
            // personaBindingSource1
            // 
            this.personaBindingSource1.DataSource = typeof(ObjectsBeans.Persona);
            // 
            // cmbNomPaciente
            // 
            this.cmbNomPaciente.DataSource = this.personaBindingSource;
            this.cmbNomPaciente.DisplayMember = "Nombre";
            this.cmbNomPaciente.FormattingEnabled = true;
            this.cmbNomPaciente.Location = new System.Drawing.Point(260, 43);
            this.cmbNomPaciente.Name = "cmbNomPaciente";
            this.cmbNomPaciente.Size = new System.Drawing.Size(148, 21);
            this.cmbNomPaciente.TabIndex = 19;
            this.cmbNomPaciente.ValueMember = "IdPersona";
            // 
            // personaBindingSource
            // 
            this.personaBindingSource.DataSource = typeof(ObjectsBeans.Persona);
            // 
            // txtLaboratorio
            // 
            this.txtLaboratorio.Location = new System.Drawing.Point(260, 108);
            this.txtLaboratorio.Name = "txtLaboratorio";
            this.txtLaboratorio.Size = new System.Drawing.Size(148, 20);
            this.txtLaboratorio.TabIndex = 18;
            // 
            // txtNumOrden
            // 
            this.txtNumOrden.Location = new System.Drawing.Point(260, 13);
            this.txtNumOrden.Name = "txtNumOrden";
            this.txtNumOrden.Size = new System.Drawing.Size(148, 20);
            this.txtNumOrden.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Laboratorio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nombre Odontólogo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre Paciente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Número Orden";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(694, 307);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(1);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(127, 36);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Ingresar Orden";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAdminCli
            // 
            this.btnAdminCli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdminCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(93)))), ((int)(((byte)(129)))));
            this.btnAdminCli.ForeColor = System.Drawing.Color.White;
            this.btnAdminCli.Location = new System.Drawing.Point(823, 307);
            this.btnAdminCli.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdminCli.Name = "btnAdminCli";
            this.btnAdminCli.Size = new System.Drawing.Size(129, 36);
            this.btnAdminCli.TabIndex = 11;
            this.btnAdminCli.Text = "Cancelar";
            this.btnAdminCli.UseVisualStyleBackColor = false;
            this.btnAdminCli.Click += new System.EventHandler(this.btnAdminCli_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(332, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Administración de Orden de Laboratorio";
            // 
            // frmAdministracionOrdenLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(200)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1031, 750);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministracionOrdenLab";
            this.Text = "SFH - Administración Orden de Laboratorio";
            this.Load += new System.EventHandler(this.frmAdministracionOrdenLab_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordendelaboratorioBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.personaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView GrillaOrden;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAdminCli;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource ordendelaboratorioBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNomOdontologo;
        private System.Windows.Forms.ComboBox cmbNomPaciente;
        private System.Windows.Forms.TextBox txtLaboratorio;
        private System.Windows.Forms.TextBox txtNumOrden;
        private System.Windows.Forms.TextBox txtPI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtHoraEntrega;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.MonthCalendar calendarEntrega;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.MonthCalendar CalendarCreacion;
        private System.Windows.Forms.BindingSource personaBindingSource;
        private System.Windows.Forms.BindingSource personaBindingSource1;
        private System.Windows.Forms.Label lblIdOrden;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroOrdenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomPacienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomOdontologoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenLaboratorioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOdontologoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPacienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinicaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn biDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn piDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadodeordenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditarCarrera;
    }
}