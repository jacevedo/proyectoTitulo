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
    public partial class frmFuncionario : Form
    {
        ClientWsAdminUsuario client_users = new ClientWsAdminUsuario();
        ClientWsFuncionario client_fun = new ClientWsFuncionario();
        List<Funcionario> list_persona = new List<Funcionario>();
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private int id_funcionario;
        public int Id_funcionario
        {
            get { return id_funcionario; }
            set { id_funcionario = value; }
        }

        public frmFuncionario()
        {
            InitializeComponent();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();   
        }
        private void ModificarUsuarios(DataGridViewCellEventArgs e)
        {
            Funcionario funcionario = datagriPersona.Rows[e.RowIndex].DataBoundItem as Funcionario;
            this.Id_funcionario = funcionario.IdFuncionario;
            cmbxUsuario.SelectedValue = funcionario.IdFuncionario;
            txtPuesto.Text = funcionario.PuestoTrabajo;
            cmbxestado.SelectedIndex = Convert.ToInt32(funcionario.Estado_funcionario);
            btnNuevo.Text = "Guardar Cambios";
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

        private void LimpiarControles()
        {
            if (this.Editar.Name.Equals("Editar"))
            {
                this.btnNuevo.Text = "Ingresar Funcionario";
                this.datagriPersona.Columns.RemoveAt(13);
                this.Editar.Name = String.Empty;
            }
            else
            {
                this.btnNuevo.Text = "Ingresar Funcionario";
            }

        }

        private void PoblarComboEstado()
        {

            this.cmbxestado.Items.Clear();
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.DESHABILITADO), "Deshabilitado");
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.HABILITADO), "Habilitado");
            this.cmbxestado.Items.Insert(2, "Seleccione tipo de estado");
            this.cmbxestado.SelectedItem = "Seleccione tipo de estado";
        }

        private void PoblarComboBusqueda()
        {
            /*    
         * 5.- Buscar Paciente Por Rut
         * 6.- Buscar Paciente Por Nombre Apellido
         
         */
            this.cmbxBuscar.Items.Clear();
            this.cmbxBuscar.Items.Insert(0, "Seleccione tipo de búsqueda");
            this.cmbxBuscar.Items.Insert(1, "Buscar Funcionario Por Rut");
            this.cmbxBuscar.Items.Insert(2, "Buscar Funcionario Por Nombre Apellido");
            this.cmbxBuscar.SelectedItem = "Seleccione tipo de búsqueda";
        }

        private void PoblarComboPersona()
        {
            this.cmbxUsuario.DataSource = client_users.ListarPersonas();
            this.cmbxUsuario.ValueMember = "IdPersona";
            this.cmbxUsuario.DisplayMember = "Nombre";
        }
        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            this.PoblarComboEstado();
            this.PoblarComboPersona();
            this.PoblarComboBusqueda();
            //poblamiento de grilla
            this.PoblarGrilla();
            this.btnNuevo.Text = "Ingresar Funcionario";
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
        public void PoblarGrilla()
        {
            this.datagriPersona.DataSource = this.client_fun.ListarFuncionario();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (this.cmbxBuscar.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("Debes seleccionar una opción de búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControles();
                    datagriPersona.DataSource = this.client_fun.ListarFuncionario();
                    
                    break;
                case 1:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de cuentas de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControles();
                    this.list_persona = this.client_fun.BuscarFuncionarioPorRut(this.txtBuscar.Text.ToString());
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
                    this.LimpiarControles();
                    string[] nombreapellido_persona = txtBuscar.Text.ToString().Split(' ');
                    if (nombreapellido_persona.Length == 2)
                    {
                        this.list_persona = this.client_fun.BuscarFuncionarioPorNombreApellido(nombreapellido_persona[0].ToString(), nombreapellido_persona[1].ToString());
                    }
                    else
                    {
                        this.list_persona = this.client_fun.BuscarFuncionarioPorNombreApellido(nombreapellido_persona[0].ToString(), "");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Funcionario")
            {
                Funcionario funcionario = new Funcionario();
                funcionario.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                funcionario.PuestoTrabajo = txtPuesto.Text;
                this.client_fun.InsertarFuncionario(funcionario);
                this.LimpiarControles();
                datagriPersona.DataSource = this.client_fun.ListarFuncionario();
                MessageBox.Show("Paciente registrado satisfactoriamente", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {

                Funcionario funcionario = new Funcionario();
                funcionario.IdFuncionario = this.Id_funcionario;
                funcionario.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                funcionario.PuestoTrabajo = txtPuesto.Text;
                if (this.client_fun.ModificarFuncionario(funcionario) != "")
                {
                    switch (cmbxestado.SelectedIndex)
                    {
                        case 0:
                            this.client_fun.DesabilitarHabilitarFuncionario(this.Id_funcionario, 0);
                            break;

                        case 1:
                            this.client_fun.DesabilitarHabilitarFuncionario(this.Id_funcionario, 1);
                            break;
                    }

                }

                this.LimpiarControles();
                datagriPersona.DataSource = this.client_fun.ListarFuncionario();
                MessageBox.Show("Paciente modificado satisfactoriamente", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


    }
}
