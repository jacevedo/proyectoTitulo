using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetClient;
using ObjectsBeans;

namespace SFH_Software
{
    public partial class frmAdministracionUsuarios : Form
    {
        #region Campos 
        ClientWsAdminUsuario client_usuario = new ClientWsAdminUsuario();
        ClientWsAdminUsuarioSig client_busqueda = new ClientWsAdminUsuarioSig();
        List<Persona> list_persona = new List<Persona>();
        List<Odontologo> list_odontologo = new List<Odontologo>();
        List<Paciente> list_paciente = new List<Paciente>();
        List<Funcionario> list_funcionario = new List<Funcionario>();
        private int id_persona;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn habilitar;
        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }

        #endregion

        #region Metodos 

        private void LimpiarControles() {
            //combo box 
            this.PoblarComboBusqueda();
            this.PoblarComboPerfil();
            this.txtrut.Text = string.Empty;
            this.txtdv.Text = string.Empty;
            this.txtnom.Text = string.Empty;
            this.txtapellpater.Text = string.Empty;
            this.txtApeMat.Text = string.Empty;
            this.mcFechaNac.ResetText();


        }
        private void PoblarComboBusqueda()
        {
            /*    
         * 1.- Buscar Persona Por Rut
         * 2.- Buscar Persona Por Nombre
         * 3.- Buscar Funcionario Por Rut
         * 4.- Buscar Funcionario Por Nombre Apellido
         * 5.- Buscar Paciente Por Rut
         * 6.- Buscar Paciente Por Nombre Apellido
         * 7.- Buscar Odontologo Por Rut
         * 8.- Buscar Odontologo Por Nombre Apellido
         */
            this.cmbxBuscar.Items.Clear();
            this.cmbxBuscar.Items.Insert(0, "Seleccione tipo de búsqueda");
            this.cmbxBuscar.Items.Insert(1, "Buscar Persona Por Rut");
            this.cmbxBuscar.Items.Insert(2, "Buscar Persona Por Nombre");
            this.cmbxBuscar.Items.Insert(3, "Buscar Funcionario Por Rut");
            this.cmbxBuscar.Items.Insert(4, "Buscar Funcionario Por Nombre Apellido");
            this.cmbxBuscar.Items.Insert(5, "Buscar Paciente Por Rut");
            this.cmbxBuscar.Items.Insert(6, "Buscar Paciente Por Nombre Apellido");
            this.cmbxBuscar.Items.Insert(7, "Buscar Odontologo Por Rut");
            this.cmbxBuscar.Items.Insert(8, "Buscar Odontologo Por Nombre Apellido");
            this.cmbxBuscar.SelectedItem = "Seleccione tipo de búsqueda";
        }
        private void PoblarComboPerfil() {
            this.cmbxPerfil.Items.Clear();
            this.cmbxPerfil.Items.Insert(0, "Seleccione tipo de perfil");
            this.cmbxPerfil.Items.Insert(1, "Administrador");
            this.cmbxPerfil.Items.Insert(2, "Doctor");
            this.cmbxPerfil.Items.Insert(3, "Asistente");
            this.cmbxPerfil.Items.Insert(4, "Paciente");
            this.cmbxPerfil.SelectedItem = "Seleccione tipo de perfil";
        }
        private void ManejodeControles (bool txtdv, bool labelv){
            if (txtdv == false | labelv == false) {
   
                this.txtdvbusqueda.Visible = false;
                this.lblguion.Visible = false;
                this.txtBuscar.MaxLength = 100;
                this.txtBuscar.Text = string.Empty;
            }
            else if (txtdv == true | labelv == true) {
                
                this.txtdvbusqueda.Visible = true;
                this.lblguion.Visible = true;
                this.txtBuscar.MaxLength = 8;
                this.txtBuscar.Text = string.Empty;
            }
        
       }
        private void PoblarBotonesGrilla() {
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            // 
            // habilitar
            // 
            this.habilitar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.habilitar.HeaderText = "Habilitar/Deshabilitar";
            this.habilitar.Name = "habilitar";

            this.datagriPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.habilitar});
        }
        #endregion

        public frmAdministracionUsuarios()
        {
            InitializeComponent();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.habilitar = new System.Windows.Forms.DataGridViewButtonColumn();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmAdministracionUsuarios_Load(object sender, EventArgs e)
        {
            //grilla persona default 
            this.datagriPersona.DataSource = this.client_usuario.ListarDatosPersona();
            this.PoblarBotonesGrilla();
            //combo box 
            this.PoblarComboBusqueda();
            this.PoblarComboPerfil();
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*    
        * 1.- Buscar Pe
             * rsona Por Rut
        * 2.- Buscar Persona Por Nombre
        * 3.- Buscar Funcionario Por Rut
        * 4.- Buscar Funcionario Por Nombre Apellido
        * 5.- Buscar Paciente Por Rut
        * 6.- Buscar Paciente Por Nombre Apellido
        * 7.- Buscar Odontologo Por Rut
        * 8.- Buscar Odontologo Por Nombre Apellido
        */
            switch (this.cmbxBuscar.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("Debes seleccionar una opción de búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datagriPersona.DataSource = this.client_usuario.ListarDatosPersona();
                    this.PoblarBotonesGrilla();
                    break;
                case 1:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.list_persona = this.client_busqueda.BuscarPersonaPorRut( this.txtBuscar.Text.ToString(),this.txtdvbusqueda.Text.ToString());
                    if (list_persona.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_persona;
                        this.PoblarBotonesGrilla();
                    }
                    break;
                case 2:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string[] nombreapellido_persona = txtBuscar.Text.ToString().Split(' ');
                    if (nombreapellido_persona.Length == 2)
                    {
                        this.list_persona = this.client_busqueda.BuscarPersonaPorNombre(nombreapellido_persona[0].ToString(), nombreapellido_persona[1].ToString());
                    }
                    else {
                        this.list_persona = this.client_busqueda.BuscarPersonaPorNombre(nombreapellido_persona[0].ToString(), "");
                    }
                    if (list_persona.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_persona;
                        this.PoblarBotonesGrilla();
                    }
                    break;

                case 3:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.list_funcionario = this.client_busqueda.BuscarFuncionarioPorRut(this.txtBuscar.Text.ToString().ToString());
                    if (list_funcionario.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_funcionario;
                        this.PoblarBotonesGrilla();
                    }
                    break;
                case 4:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                    string[] nombreapellido_funcionario = txtBuscar.Text.ToString().Split(' ');
                    if (nombreapellido_funcionario.Length == 2)
                    {
                        this.list_funcionario = this.client_busqueda.BuscarFuncionarioPorNombreApellido(nombreapellido_funcionario[0].ToString(), nombreapellido_funcionario[1].ToString());
                    }
                    else {
                        this.list_funcionario = this.client_busqueda.BuscarFuncionarioPorNombreApellido(nombreapellido_funcionario[0].ToString(),"");
                    }

                    if (list_funcionario.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_funcionario;
                        this.PoblarBotonesGrilla();
                    }
                    break;

                case 5:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.list_paciente = this.client_busqueda.BuscarPacientePorRut(txtBuscar.Text.ToString());
                    if (list_paciente.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_paciente;
                        this.PoblarBotonesGrilla();
                    }
                    break;
                case 6:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string[] nombreapellido_paciente = txtBuscar.Text.ToString().Split(' ');
                    if (nombreapellido_paciente.Length == 2)
                    {
                        this.list_paciente = this.client_busqueda.BuscarPacientePorNombreApellido(nombreapellido_paciente[0].ToString(), nombreapellido_paciente[1].ToString());
                    }
                    else{
                        this.list_paciente = this.client_busqueda.BuscarPacientePorNombreApellido(nombreapellido_paciente[0].ToString(),"");
                    }
                    if (list_paciente.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_paciente;
                        this.PoblarBotonesGrilla();
                    }
                    break;

                case 7:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.list_odontologo = this.client_busqueda.BuscarOdontologoPorRut(txtBuscar.Text.ToString());
                    if (list_odontologo.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_odontologo;
                        this.PoblarBotonesGrilla();
                    }
                    break;
                case 8:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string[] nombreapellido_Odontologo = txtBuscar.Text.ToString().Split(' ');
                    if (nombreapellido_Odontologo.Length == 2)
                    {
                        this.list_odontologo = this.client_busqueda.BuscarOdontologoPorNombreApellido(nombreapellido_Odontologo[0].ToString(), nombreapellido_Odontologo[1].ToString());
                    }
                    else {
                        this.list_odontologo = this.client_busqueda.BuscarOdontologoPorNombreApellido(nombreapellido_Odontologo[0].ToString(),"");
                    }
                    if (list_odontologo.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_odontologo;
                        this.PoblarBotonesGrilla();
                    }
                    break;

            }
        }

        private void cmbxBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbxBuscar.SelectedIndex)
            {
                case 0:
                    this.ManejodeControles(false,false);
                    break;
                case 1:
                    this.ManejodeControles(true, true);
                    break;
                case 2:
                    this.ManejodeControles(false, false);
                    break;
                case 3:
                    this.ManejodeControles(true, true);                    
                    break;
                case 4:
                    this.ManejodeControles(false, false);
                    break;
                case 5:
                    this.ManejodeControles(true, true);
                    break;
                case 6:
                    this.ManejodeControles(false, false);
                    break;
                case 7:
                    this.ManejodeControles(true, true);                   
                    break;
                case 8:
                    this.ManejodeControles(false, false);
                    break;



            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

      

    }
}
