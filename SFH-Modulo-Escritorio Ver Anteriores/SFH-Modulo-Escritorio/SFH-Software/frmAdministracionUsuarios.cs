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
        ClientWsAddUsuario client_addUusario = new ClientWsAddUsuario();
        ClientWsPassDatosdeContacto client_pass_dat = new ClientWsPassDatosdeContacto();
        //usuarios 
        ClientWsFuncionario client_fun = new ClientWsFuncionario();
        ClientWsOdontologo cliente_odontologo = new ClientWsOdontologo();
        ClientWsPaciente cliente_paciente = new ClientWsPaciente();
        
        List<Persona> list_persona = new List<Persona>();
    
        private int id_persona;
        private int id_perfil_nat;

        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn verdatoscontacto;
        private System.Windows.Forms.DataGridViewButtonColumn verpaciente;
        private System.Windows.Forms.DataGridViewButtonColumn verOdontologo;
        private System.Windows.Forms.DataGridViewButtonColumn verfuncionario;
        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }

        public int Id_perfil_nat
        {
            get { return id_perfil_nat; }
            set { id_perfil_nat = value; }
        }
        #endregion

        #region Metodos 
        private void EliminarPerfiles(int indxPerfil, int param_idPersona) {
          switch(indxPerfil){
              case 1:
                  cliente_odontologo.EliminarOdontologo(param_idPersona);
                  break;
              case 2:
                  cliente_odontologo.EliminarOdontologo(param_idPersona);
                  break;
              case 3:
                  client_fun.EliminarFuncionario(param_idPersona);
                  break;
              case 4:
                  cliente_paciente.EliminarPaciente(param_idPersona);
                  break;
         }
        }

        private void InsertarPerfiles(int indxPerfil, int param_idPersona)
        {
            switch (indxPerfil)
            {
                case 1:
                    Odontologo odo = new Odontologo();
                    odo.IdPersona = param_idPersona;
                    odo.Especialidad = "Ingrese Especialidad";
                    cliente_odontologo.InsertarOdontologo(odo);
                    break;
                case 2:
                  Odontologo odonto = new Odontologo();
                    odonto.IdPersona = param_idPersona;
                    odonto.Especialidad = "Ingrese Especialidad";
                    cliente_odontologo.InsertarOdontologo(odonto);
                    break;
                case 3:
                    Funcionario funcionario = new Funcionario(); 
                    funcionario.IdPersona = param_idPersona;
                    funcionario.PuestoTrabajo = "Ingrese puesto de trabajo";
                    client_fun.InsertarFuncionario(funcionario);
                    break;
                case 4:
                    Paciente paciente = new Paciente();
                    paciente.IdPersona = param_idPersona;
                    paciente.FechaIngreso = DateTime.Now;
                    cliente_paciente.InsertarPaciente(paciente);
                    break;
            }
        }

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
            this.txtpass.Text = string.Empty;
            this.txtpass2.Text = string.Empty;
            this.btnNuevo.Text = "Ingresar Gastos";

        }

        private void ModificarUsuarios(DataGridViewCellEventArgs e)
        {
            Persona persona = datagriPersona.Rows[e.RowIndex].DataBoundItem as Persona;
            this.Id_persona = persona.IdPersona;
            this.cmbxPerfil.SelectedValue = persona.IdPerfil;
            this.Id_perfil_nat = persona.IdPerfil;
            this.txtrut.Text = persona.Rut.ToString();
            this.txtdv.Text = persona.Dv;
            this.txtnom.Text = persona.Nombre;
            this.txtapellpater.Text = persona.ApellidoPaterno;
            this.txtApeMat.Text = persona.ApellidoMaterno;
            this.mcFechaNac.SelectionStart = persona.FechaNacimiento;
            this.mcFechaNac.SelectionEnd = persona.FechaNacimiento;
            this.txtpass.Text = "1234";
            this.txtpass2.Text = "1234";
            btnNuevo.Text = "Guardar Cambios";
        }

        private Datoscontacto DatosContactoDefault() {
            Datoscontacto contacto = new Datoscontacto();
            contacto.IdComuna = 1;
            contacto.FonoFijo = "Ej:9999999";
            contacto.FonoCelular = "Ej:99999999";
            contacto.Mail = "Ingrese su Mail";
            contacto.Direccion = "Ingrese su direccion";
            contacto.FechaIngreso = Convert.ToDateTime("1991-12-12");
            return contacto;
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
            this.cmbxPerfil.Items.Insert(2, "Odontologo");
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
                this.txtdvbusqueda.Text = string.Empty;
            }
            else if (txtdv == true | labelv == true) {
                
                this.txtdvbusqueda.Visible = true;
                this.lblguion.Visible = true;
                this.txtBuscar.MaxLength = 8;
                this.txtBuscar.Text = string.Empty;
                this.txtdvbusqueda.Text = string.Empty;
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
            // ver contacto
            // 
            this.verdatoscontacto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.verdatoscontacto.HeaderText = "Ver datos de contacto";
            this.verdatoscontacto.Name = "verdatoscontactos";
            // 
            // ver paciente
            // 
            this.verpaciente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.verpaciente.HeaderText = "Ver paciente";
            this.verpaciente.Name = "verpaciente";
            // 
            // ver odontologo
            // 
            this.verOdontologo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.verOdontologo.HeaderText = "Ver odontologo";
            this.verOdontologo.Name = "verodontologo";
            // 
            // ver funcionario
            // 
            this.verfuncionario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.verfuncionario.HeaderText = "Ver funcionario";
            this.verfuncionario.Name = "verfuncionario";

            this.datagriPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.verdatoscontacto,
            this.verpaciente,
            this.verOdontologo,
            this.verfuncionario});
        }
        #endregion

        public frmAdministracionUsuarios()
        {
            InitializeComponent();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.verdatoscontacto = new System.Windows.Forms.DataGridViewButtonColumn();
            this.verpaciente = new System.Windows.Forms.DataGridViewButtonColumn();
            this.verOdontologo =  new System.Windows.Forms.DataGridViewButtonColumn();
            this.verfuncionario =  new System.Windows.Forms.DataGridViewButtonColumn(); 
           
        }

        private void frmAdministracionUsuarios_Load(object sender, EventArgs e)
        {
            //grilla persona default 
            this.datagriPersona.DataSource = this.client_usuario.ListarDatosPersona();
            this.PoblarBotonesGrilla();
            //combo box 
            this.PoblarComboBusqueda();
            this.PoblarComboPerfil();
            //boton
            btnNuevo.Text = "Ingresar Gastos";
           
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
                    }
                    break;

                case 3:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.list_persona = this.client_busqueda.BuscarFuncionarioPorRut(this.txtBuscar.Text.ToString().ToString());
                    if (list_persona.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_persona;
                    }
                    break;
                case 4:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                    string[] nombreapellido_funcionario = txtBuscar.Text.ToString().Split(' ');
                    if (nombreapellido_funcionario.Length == 2)
                    {
                        this.list_persona = this.client_busqueda.BuscarFuncionarioPorNombreApellido(nombreapellido_funcionario[0].ToString(), nombreapellido_funcionario[1].ToString());
                    }
                    else {
                        this.list_persona = this.client_busqueda.BuscarFuncionarioPorNombreApellido(nombreapellido_funcionario[0].ToString(),"");
                    }

                    if (list_persona.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_persona;
                        
                    }
                    break;

                case 5:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.list_persona = this.client_busqueda.BuscarPacientePorRut(txtBuscar.Text.ToString());
                    if (list_persona.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_persona;
                        
                    }
                    break;
                case 6:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string[] nombreapellido_paciente = txtBuscar.Text.ToString().Split(' ');
                    if (nombreapellido_paciente.Length == 2)
                    {
                        this.list_persona = this.client_busqueda.BuscarPacientePorNombreApellido(nombreapellido_paciente[0].ToString(), nombreapellido_paciente[1].ToString());
                    }
                    else{
                        this.list_persona = this.client_busqueda.BuscarPacientePorNombreApellido(nombreapellido_paciente[0].ToString(),"");
                    }
                    if (list_persona.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_persona;
                        
                    }
                    break;

                case 7:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.list_persona = this.client_busqueda.BuscarOdontologoPorRut(txtBuscar.Text.ToString());
                    if (list_persona.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_persona;
                        
                    }
                    break;
                case 8:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string[] nombreapellido_Odontologo = txtBuscar.Text.ToString().Split(' ');
                    if (nombreapellido_Odontologo.Length == 2)
                    {
                        this.list_persona = this.client_busqueda.BuscarOdontologoPorNombreApellido(nombreapellido_Odontologo[0].ToString(), nombreapellido_Odontologo[1].ToString());
                    }
                    else {
                        this.list_persona = this.client_busqueda.BuscarOdontologoPorNombreApellido(nombreapellido_Odontologo[0].ToString(),"");
                    }
                    if (list_persona.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        datagriPersona.DataSource = this.list_persona;
                        
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
            this.LimpiarControles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Gastos")
            {
                
                Persona persona = new Persona();
                persona.IdPerfil = Convert.ToInt32(this.cmbxPerfil.SelectedIndex);
                persona.Rut = int.Parse(this.txtrut.Text);
                persona.Dv = this.txtdv.Text;
                persona.Nombre = this.txtnom.Text;
                persona.ApellidoPaterno = this.txtapellpater.Text;
                persona.ApellidoMaterno = this.txtApeMat.Text;
                persona.FechaNacimiento = mcFechaNac.SelectionStart;
                if(txtpass.ToString()==txtpass2.ToString()){
                String id_per = client_usuario.InsertarPersona(persona);
                Pass pass = new Pass();
                pass.IdPersona = int.Parse(id_per);
                pass.Passtext = txtpass.Text.ToString();
                pass.FechaCaducidad = mcFechadeCaducidad.SelectionStart;
                Datoscontacto contacto = this.DatosContactoDefault();
                this.client_addUusario.insertarPersonaDatosdeContacto(persona,contacto, pass);
                }
                datagriPersona.DataSource = this.client_usuario.ListarDatosPersona();
                this.LimpiarControles();
                MessageBox.Show("Usuario registrado satisfactoriamente", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                Persona persona = new Persona();
                persona.IdPersona = this.Id_persona;
                persona.IdPerfil = Convert.ToInt32(this.cmbxPerfil.SelectedIndex);
                persona.Rut = int.Parse(this.txtrut.Text);
                persona.Dv = this.txtdv.Text;
                persona.Nombre = this.txtnom.Text;
                persona.ApellidoPaterno = this.txtapellpater.Text;
                persona.ApellidoMaterno = this.txtApeMat.Text;
                persona.FechaNacimiento = mcFechaNac.SelectionStart;
                if (txtpass.ToString() == txtpass2.ToString())
                {
                    Pass pass = new Pass();
                    pass.IdPersona = Id_persona;
                    pass.Passtext = txtpass.Text.ToString();
                    pass.FechaCaducidad = mcFechadeCaducidad.SelectionStart;
                    this.client_usuario.ModificarPersona(persona);
                    this.EliminarPerfiles(this.Id_perfil_nat, Id_persona);
                    this.InsertarPerfiles(persona.IdPerfil,Id_persona);
                    this.client_pass_dat.ModificarPass(pass);
                }
                datagriPersona.DataSource = this.client_usuario.ListarDatosPersona();
                this.LimpiarControles();
                MessageBox.Show("Usuario modificado satisfactoriamente", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

       

        private void datagriPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.ModificarUsuarios(e); 
                    break;
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:

                    break;
                case 4:

                    break;

            }
        }

        

       
    }
}
