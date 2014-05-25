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
        frmMenu menu;
        ClientWsAdminUsuario client_usuario = new ClientWsAdminUsuario();
        ClientWsAdminUsuarioSig client_busqueda = new ClientWsAdminUsuarioSig();
        ClientWsAddUsuario client_addUusario = new ClientWsAddUsuario();
        ClientWsPassDatosdeContacto client_pass_dat = new ClientWsPassDatosdeContacto();
        //usuarios 
        ClientWsFuncionario client_fun = new ClientWsFuncionario();
        ClientWsOdontologo cliente_odontologo = new ClientWsOdontologo();
        ClientWsPaciente cliente_paciente = new ClientWsPaciente();
        
        List<Persona> list_persona = new List<Persona>();
        Validaciones validaciones = new Validaciones();
        private int id_persona;
        private int id_perfil_nat;

        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn verdatoscontacto;
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
        
        private bool validarformulario()
        {
            if (validaciones.RutValido(txtrut.Text.ToString(), txtdv.Text.ToString()) == true
                & validaciones.EsSoloTexto(txtnom) == true & validaciones.EsSoloTexto(txtapellpater) == true
                & validaciones.EsSoloTexto(txtApeMat) == true & validaciones.ValidarClave(txtpass) == true
                & validaciones.ValidarClaves(txtpass, txtpass2) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string EliminarPerfiles(int indxPerfil, int param_idPersona)
        {
            string res = string.Empty;
            switch(indxPerfil)
            {
                case 1:
                    res = cliente_odontologo.EliminarOdontologo(param_idPersona);
                    break;
                case 2:
                    res = cliente_odontologo.EliminarOdontologo(param_idPersona);
                    break;
                case 3:
                    res = client_fun.EliminarFuncionario(param_idPersona);
                    break;
                case 4:
                    res = cliente_paciente.EliminarPaciente(param_idPersona);
                    break;
            }
            return res;
        }

        private string InsertarPerfiles(int indxPerfil, int param_idPersona)
        {
            string res = string.Empty;
            switch (indxPerfil)
            {
                case 1:
                    Odontologo odo = new Odontologo();
                    odo.IdPersona = param_idPersona;
                    odo.Especialidad = "Ingrese Especialidad";
                    res = cliente_odontologo.InsertarOdontologo(odo);
                    break;
                case 2:
                  Odontologo odonto = new Odontologo();
                    odonto.IdPersona = param_idPersona;
                    odonto.Especialidad = "Ingrese Especialidad";
                    res = cliente_odontologo.InsertarOdontologo(odonto);
                    break;
                case 3:
                    Funcionario funcionario = new Funcionario(); 
                    funcionario.IdPersona = param_idPersona;
                    funcionario.PuestoTrabajo = "Ingrese Puesto de Trabajo";
                    res = client_fun.InsertarFuncionario(funcionario);
                    break;
                case 4:
                    Paciente paciente = new Paciente();
                    paciente.IdPersona = param_idPersona;
                    paciente.FechaIngreso = DateTime.Now;
                    res = cliente_paciente.InsertarPaciente(paciente);
                    break;
            }
            return res;
        }

        private void LimpiarControles()
        {
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
            this.btnNuevo.Text = "Ingresar Usuarios";
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
            this.txtpass.Text = "asdcasco";
            this.txtpass2.Text = "asdcasco";
            btnNuevo.Text = "Guardar Cambios";
        }

        private Datoscontacto DatosContactoDefault()
        {
            Datoscontacto contacto = new Datoscontacto();
            contacto.IdComuna = 1;
            contacto.FonoFijo = "Ej:7349980";
            contacto.FonoCelular = "Ej:94802233";
            contacto.Mail = "Ingrese su Email";
            contacto.Direccion = "Ingrese su Dirección";
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
            this.cmbxBuscar.Items.Insert(0, "Seleccione Tipo de Búsqueda");
            this.cmbxBuscar.Items.Insert(1, "Buscar Persona Por Rut");
            this.cmbxBuscar.Items.Insert(2, "Buscar Persona Por Nombre");
            this.cmbxBuscar.Items.Insert(3, "Buscar Funcionario Por Rut");
            this.cmbxBuscar.Items.Insert(4, "Buscar Funcionario Por Nombre Apellido");
            this.cmbxBuscar.Items.Insert(5, "Buscar Paciente Por Rut");
            this.cmbxBuscar.Items.Insert(6, "Buscar Paciente Por Nombre Apellido");
            this.cmbxBuscar.Items.Insert(7, "Buscar Odontólogo Por Rut");
            this.cmbxBuscar.Items.Insert(8, "Buscar Odontólogo Por Nombre Apellido");
            this.cmbxBuscar.SelectedItem = "Seleccione Tipo de Búsqueda";
        }
        private void PoblarComboPerfil()
        {
            this.cmbxPerfil.Items.Clear();
            this.cmbxPerfil.Items.Insert(0, "Seleccione Tipo de Perfil");
            this.cmbxPerfil.Items.Insert(1, "Administrador");
            this.cmbxPerfil.Items.Insert(2, "Odontólogo");
            this.cmbxPerfil.Items.Insert(3, "Asistente");
            this.cmbxPerfil.Items.Insert(4, "Paciente");
            this.cmbxPerfil.SelectedItem = "Seleccione Tipo de Perfil";
        }
        private void ManejodeControles (bool txtdv, bool labelv)
        {
            if (txtdv == false | labelv == false)
            {
                this.txtdvbusqueda.Visible = false;
                this.lblguion.Visible = false;
                this.txtBuscar.MaxLength = 100;
                this.txtBuscar.Text = string.Empty;
                this.txtdvbusqueda.Text = string.Empty;
            }
            else if (txtdv == true | labelv == true)
            {
                this.txtdvbusqueda.Visible = true;
                this.lblguion.Visible = true;
                this.txtBuscar.MaxLength = 8;
                this.txtBuscar.Text = string.Empty;
                this.txtdvbusqueda.Text = string.Empty;
            }
       }


        private void PoblarBotonesGrilla() 
        {
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
            this.verdatoscontacto.HeaderText = "Ver Datos de Contacto";
            this.verdatoscontacto.Name = "verdatoscontactos";

            this.datagriPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.verdatoscontacto});
        }
        #endregion

        public frmAdministracionUsuarios(frmMenu menu)
        {
            InitializeComponent();
            this.menu = menu;
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.verdatoscontacto = new System.Windows.Forms.DataGridViewButtonColumn(); 
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
            btnNuevo.Text = "Ingresar Usuarios";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
            switch (this.cmbxBuscar.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("Debes seleccionar una opción de búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datagriPersona.DataSource = this.client_usuario.ListarDatosPersona();
                    break;
                case 1:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        this.list_persona = this.client_busqueda.BuscarPersonaPorRut(this.txtBuscar.Text.ToString(), this.txtdvbusqueda.Text.ToString());
                        if (list_persona.Count.Equals(0))
                        {
                            MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            datagriPersona.DataSource = this.list_persona;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        string[] nombreapellido_persona = txtBuscar.Text.ToString().Split(' ');
                        if (nombreapellido_persona.Length == 2)
                        {
                            this.list_persona = this.client_busqueda.BuscarPersonaPorNombre(nombreapellido_persona[0].ToString(), nombreapellido_persona[1].ToString());
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                        else
                        {
                            this.list_persona = this.client_busqueda.BuscarPersonaPorNombre(txtBuscar.Text.ToString(), " ");
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 3:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        this.list_persona = this.client_busqueda.BuscarFuncionarioPorRut(this.txtBuscar.Text.ToString().ToString());
                        if (list_persona.Count.Equals(0))
                        {
                            MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            datagriPersona.DataSource = this.list_persona;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 4:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        string[] nombreapellido_funcionario = txtBuscar.Text.ToString().Split(' ');
                        if (nombreapellido_funcionario.Length == 2)
                        {
                            this.list_persona = this.client_busqueda.BuscarFuncionarioPorNombreApellido(nombreapellido_funcionario[0].ToString(), nombreapellido_funcionario[1].ToString());
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                        else
                        {
                            this.list_persona = this.client_busqueda.BuscarFuncionarioPorNombreApellido(txtBuscar.Text.ToString(), " ");
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 5:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        this.list_persona = this.client_busqueda.BuscarPacientePorRut(txtBuscar.Text.ToString());
                        if (list_persona.Count.Equals(0))
                        {
                            MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            datagriPersona.DataSource = this.list_persona;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 6:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        string[] nombreapellido_paciente = txtBuscar.Text.ToString().Split(' ');
                        if (nombreapellido_paciente.Length == 2)
                        {
                            this.list_persona = this.client_busqueda.BuscarPacientePorNombreApellido(nombreapellido_paciente[0].ToString(), nombreapellido_paciente[1].ToString());
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                        else
                        {
                            this.list_persona = this.client_busqueda.BuscarPacientePorNombreApellido(txtBuscar.Text.ToString(), " ");
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 7:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        this.list_persona = this.client_busqueda.BuscarOdontologoPorRut(txtBuscar.Text.ToString());
                        if (list_persona.Count.Equals(0))
                        {
                            MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            datagriPersona.DataSource = this.list_persona;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 8:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        string[] nombreapellido_Odontologo = txtBuscar.Text.ToString().Split(' ');
                        if (nombreapellido_Odontologo.Length == 2)
                        {
                            this.list_persona = this.client_busqueda.BuscarOdontologoPorNombreApellido(nombreapellido_Odontologo[0].ToString(), nombreapellido_Odontologo[1].ToString());
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                        else {

                            this.list_persona = this.client_busqueda.BuscarOdontologoPorNombreApellido(txtBuscar.Text.ToString(), " ");
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Usuarios")
            {
                if (txtrut.Text != "")
                {
                    List<Persona> list = this.client_usuario.ListarDatosPersona();
                    int patron = Convert.ToInt32(txtrut.Text.ToString());
                    Persona result = list.Find(delegate(Persona per) { return per.Rut == patron; });
                    if (result != null)
                    {
                        MessageBox.Show("El usuario " + result.Nombre + " " + result.ApellidoPaterno + " ya posee una cuenta dentro del sistema", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        try
                        {
                            if (this.validarformulario()) {
                                Persona persona = new Persona();
                                persona.IdPerfil = Convert.ToInt32(this.cmbxPerfil.SelectedIndex);
                                persona.Rut = int.Parse(this.txtrut.Text);
                                persona.Dv = this.txtdv.Text;
                                persona.Nombre = this.txtnom.Text;
                                persona.ApellidoPaterno = this.txtapellpater.Text;
                                persona.ApellidoMaterno = this.txtApeMat.Text;
                                persona.FechaNacimiento = mcFechaNac.SelectionStart;
                                if (txtpass.ToString() == txtpass2.ToString())
                                {
                                    String id_per = client_usuario.InsertarPersona(persona);
                                    if (id_per != string.Empty)
                                    {
                                        Pass pass = new Pass();
                                        pass.IdPersona = int.Parse(id_per);
                                        pass.Passtext = txtpass.Text.ToString();
                                        pass.FechaCaducidad = mcFechadeCaducidad.SelectionStart;
                                        Datoscontacto contacto = this.DatosContactoDefault();
                                        String id_dat = this.client_pass_dat.InsertarDatosdeContacto(contacto);
                                        if (id_dat != string.Empty)
                                        {
                                            String id_pass = this.client_pass_dat.InsertarPass(pass);
                                            if (id_pass != string.Empty)
                                            {
                                                datagriPersona.DataSource = this.client_usuario.ListarDatosPersona();
                                                this.LimpiarControles();
                                                MessageBox.Show("Usuario registrado correctamente.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Contraseña NO fue ingresada.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Datos de Contacto NO fueron ingresados.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Persona NO fue ingresada.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Contraseñas ingresadas no coinciden.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                try
                {
                    if (this.validarformulario()) {
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
                        string mod_persona = this.client_usuario.ModificarPersona(persona);
                        if (mod_persona != string.Empty)
                        {
                            string elim = this.EliminarPerfiles(this.Id_perfil_nat, Id_persona);
                            if (elim != string.Empty)
                            {
                                string ins = this.InsertarPerfiles(persona.IdPerfil, Id_persona);
                                if (ins != string.Empty)
                                {
                                    string mod = this.client_pass_dat.ModificarPass(pass);
                                    if (mod != string.Empty)
                                    {
                                        datagriPersona.DataSource = this.client_usuario.ListarDatosPersona();
                                        this.LimpiarControles();
                                        MessageBox.Show("Usuario modificado correctamente.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Contraseña NO fue modificada.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Perfil NO fue modificado.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Perfil anterior NO fue eliminado.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contraseñas ingresadas no coinciden.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    Persona persona = datagriPersona.Rows[e.RowIndex].DataBoundItem as Persona;
                    menu.MostrarForm("Administración Datos de Contacto",  new frmDatosDeContacto(persona.IdPersona));
                    break;
            }
        }

        private void txtdv_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.RutValido(txtrut.Text.ToString(),txtdv.Text.ToString()))
            {
                errorProvider1.SetError(txtdv, String.Empty);
                txtdv.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtdv, "El nombre no puede contener números y caracteres especiales");
                txtdv.BackColor = Color.MistyRose;
            }
        }

        private void txtnom_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsSoloTexto(txtnom))
            {
                errorProvider1.SetError(txtnom, String.Empty);
                txtnom.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtnom, "El nombre no puede contener números y caracteres especiales");
                txtnom.BackColor = Color.MistyRose;
            }
        }

        private void txtapellpater_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsSoloTexto(txtapellpater))
            {
                errorProvider1.SetError(txtapellpater, String.Empty);
                txtapellpater.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtapellpater, "El apellido paterno no puede contener números y caracteres especiales");
                txtapellpater.BackColor = Color.MistyRose;
            }
        }

        private void txtApeMat_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsSoloTexto(txtApeMat))
            {
                errorProvider1.SetError(txtApeMat, String.Empty);
                txtApeMat.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtApeMat, "El apellido materno no puede contener números y caracteres especiales");
                txtApeMat.BackColor = Color.MistyRose;
            }
        }

        private void txtpass_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.ValidarClave(txtpass))
            {
                errorProvider1.SetError(txtpass, String.Empty);
                txtpass.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtpass, "La contraseña debe contener a lo menos 7 caracteres");
                txtpass.BackColor = Color.MistyRose;
            }
        }

        private void txtpass2_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.ValidarClaves(txtpass,txtpass2)) {
                errorProvider1.SetError(txtpass2, String.Empty);
                txtpass2.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtpass2, "La contraseñas debe coincidir entre si");
                txtpass2.BackColor = Color.MistyRose;
            }
        }
       
    }
}
