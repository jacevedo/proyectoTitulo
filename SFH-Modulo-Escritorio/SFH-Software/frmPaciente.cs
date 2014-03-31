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
    public partial class frmPaciente : Form
    {

        ClientWsAdminUsuario client_users = new ClientWsAdminUsuario();
        ClientWsPaciente clients_paciente = new ClientWsPaciente();
        List<Paciente> list_persona = new List<Paciente>();
        private int id_paciente;
        public int Id_paciente
        {
            get { return id_paciente; }
            set { id_paciente = value; }
        }

        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        public frmPaciente()
        {
            InitializeComponent();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();    
        }
        private void ManejodeControles(bool txtdv, bool labelv)
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
        private void PoblarComboEstado()
        {
            this.cmbxestado.Items.Clear();
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.DESHABILITADO), "Deshabilitado");
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.HABILITADO), "Habilitado");
            this.cmbxestado.SelectedItem = "Habilitado";
        }

        private void PoblarComboBusqueda()
        {
            /*    
         * 5.- Buscar Paciente Por Rut
         * 6.- Buscar Paciente Por Nombre Apellido
         
         */
            this.cmbxBuscar.Items.Clear();
            this.cmbxBuscar.Items.Insert(0, "Seleccione tipo de búsqueda");
            this.cmbxBuscar.Items.Insert(1, "Buscar Paciente Por Rut");
            this.cmbxBuscar.Items.Insert(2, "Buscar Paciente Por Nombre Apellido");
            this.cmbxBuscar.SelectedItem = "Seleccione tipo de búsqueda";
        }



        private void PoblarBotonesGrilla()
        {
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.datagriPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});

        }
        private void LimpiarControles()
        {
            if (this.Editar.Name.Equals("Editar"))
            {
                this.btnNuevo.Text = "Ingresar Paciente";
                this.datagriPersona.Columns.RemoveAt(13);
                this.Editar.Name = String.Empty;
            }
            else {
                this.btnNuevo.Text = "Ingresar Paciente";
            }
            
        }

        public void PoblarGrilla() {
            this.datagriPersona.DataSource = this.clients_paciente.ListarPacientes();
        }

        private void PoblarComboPersona()
        {
            this.cmbxUsuario.DataSource = client_users.ListarPersonas();
            this.cmbxUsuario.ValueMember = "IdPersona";
            this.cmbxUsuario.DisplayMember = "Nombre";
        }

        private void ModificarUsuarios(DataGridViewCellEventArgs e)
        {
            Paciente paciente = datagriPersona.Rows[e.RowIndex].DataBoundItem as Paciente;
            this.Id_paciente = paciente.IdPaciente;
            this.cmbxUsuario.SelectedValue = Convert.ToInt32(paciente.IdPersona);
            this.cmbxestado.SelectedIndex = Convert.ToInt32(paciente.HabilitadoPaciente);
            this.mcFechadeIngreso.SelectionStart = paciente.FechaIngreso;
            this.mcFechadeIngreso.SelectionEnd = paciente.FechaIngreso;
            btnNuevo.Text = "Guardar Cambios";
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            //poblamiento de combobox
            this.PoblarComboEstado();
            this.PoblarComboPersona();
            this.PoblarComboBusqueda();
            //poblamiento de grilla
            this.PoblarGrilla();
            this.btnNuevo.Text = "Ingresar Paciente";

        }

        private void datagriPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Editar.Name.Equals("Editar"))
            {
                switch (e.ColumnIndex)
                {
                    case 13:
                        this.ModificarUsuarios(e);
                        break;
                }
            }
            else
            {
                this.PoblarBotonesGrilla();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Paciente")
            {
                if (cmbxUsuario.SelectedValue.ToString() != "")
                {
                    //datagriPersona.DataSource = 
                    List<Paciente> list = this.clients_paciente.ListarPacientes();
                    int patron = Convert.ToInt32(cmbxUsuario.SelectedValue.ToString());
                    Paciente result = list.Find(delegate(Paciente pac) { return pac.IdPersona == patron; });
                    if (result != null)
                    {
                        if (MessageBox.Show("El paciente " + result.Nombre + " " + result.ApellidoPaterno + " ya se encuentra registrado dentro del sistema, ¿Desea Modificar su información con la recién ingresada?", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Paciente paciente = new Paciente();
                            paciente.IdPaciente = result.IdPaciente;
                            paciente.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                            paciente.FechaIngreso = mcFechadeIngreso.SelectionStart;
                            if (this.clients_paciente.ModificarPaciente(paciente) != "")
                            {
                                switch (cmbxestado.SelectedIndex)
                                {
                                    case 0:
                                        this.clients_paciente.DesabilitarHabilitarPaciente(this.Id_paciente, 0);
                                        break;

                                    case 1:
                                        this.clients_paciente.DesabilitarHabilitarPaciente(this.Id_paciente, 1);
                                        break;
                                }

                            }

                            this.LimpiarControles();
                            datagriPersona.DataSource = this.clients_paciente.ListarPacientes();
                            MessageBox.Show("Paciente modificado satisfactoriamente", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        Paciente paciente = new Paciente();
                        paciente.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                        paciente.FechaIngreso = mcFechadeIngreso.SelectionStart;
                        this.clients_paciente.InsertarPaciente(paciente);
                        this.LimpiarControles();
                        datagriPersona.DataSource = this.clients_paciente.ListarPacientes();
                        MessageBox.Show("Paciente registrado satisfactoriamente", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
            
                Paciente paciente = new Paciente();
                paciente.IdPaciente = this.Id_paciente;
                paciente.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                paciente.FechaIngreso = mcFechadeIngreso.SelectionStart;
                if (this.clients_paciente.ModificarPaciente(paciente) != "") {
                    switch(cmbxestado.SelectedIndex){
                        case 0:
                            this.clients_paciente.DesabilitarHabilitarPaciente(this.Id_paciente,0);
                        break;

                        case 1:
                             this.clients_paciente.DesabilitarHabilitarPaciente(this.Id_paciente,1);
                        break;
                }
                    
                }

                this.LimpiarControles();
                datagriPersona.DataSource = this.clients_paciente.ListarPacientes();
                MessageBox.Show("Paciente modificado satisfactoriamente", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (this.cmbxBuscar.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("Debes seleccionar una opción de búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datagriPersona.DataSource = this.clients_paciente.ListarPacientes();
                    
                    break;
                case 1:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControles();
                    this.list_persona = this.clients_paciente.BuscarPacientePorRut(this.txtBuscar.Text.ToString());
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
                    this.LimpiarControles();
                    if (nombreapellido_persona.Length == 2)
                    {
                        this.list_persona = this.clients_paciente.BuscarPacientePorNombreApellido(nombreapellido_persona[0].ToString(), nombreapellido_persona[1].ToString());
                    }
                    else
                    {
                        this.list_persona = this.clients_paciente.BuscarPacientePorNombreApellido(nombreapellido_persona[0].ToString(), "");
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
                    this.ManejodeControles(false, false);
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

        private void cmbxestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxestado.SelectedIndex == 0)
            {
                if (cmbxUsuario.SelectedValue.ToString() != "")
                {
                    if (MessageBox.Show("¿Desea deshabilitar al usuario " + cmbxUsuario.SelectedText + " ?", "SFH Administración de Clínica - Administración de Ficha Dental.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        this.cmbxestado.SelectedItem = "Habilitado";
                    }
                }
                else
                {

                    if (MessageBox.Show("¿Desea deshabilitar al usuario que está creando?", "SFH Administración de Clínica - Administración de Ficha Dental.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        this.cmbxestado.SelectedItem = "Habilitado";
                    }
                }
            }
        }
    }
}
