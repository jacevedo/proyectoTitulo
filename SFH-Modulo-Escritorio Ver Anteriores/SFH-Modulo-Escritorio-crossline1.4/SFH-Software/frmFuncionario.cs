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
        ClientWsAdminUsuarioSig client_person = new ClientWsAdminUsuarioSig();
        List<Funcionario> list_persona = new List<Funcionario>();
        List<Persona> list_persona_funcionario = new List<Persona>();
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        Validaciones validaciones = new Validaciones();
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
            cmbxUsuario.SelectedValue = funcionario.IdPersona;
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
                this.txtPuesto.Text = String.Empty;
            }
            else
            {
                this.btnNuevo.Text = "Ingresar Funcionario";
                this.txtPuesto.Text = String.Empty;
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
            this.cmbxBuscar.Items.Insert(1, "Buscar Funcionario Por Rut");
            this.cmbxBuscar.Items.Insert(2, "Buscar Funcionario Por Nombre Apellido");
            this.cmbxBuscar.SelectedItem = "Seleccione tipo de búsqueda";
        }

        private void PoblarComboPersona()
        {
            this.cmbxUsuario.DataSource = client_person.ListarPersonasFuncionario();
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
                    MessageBox.Show("Debes seleccionar una opción de búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControles();
                    datagriPersona.DataSource = this.client_fun.ListarFuncionario();
                    break;
                case 1:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControles();
                    try
                    {
                        List<Funcionario> lista_result = new List<Funcionario>();
                        lista_result = this.client_fun.BuscarFuncionarioPorRut(this.txtBuscar.Text.ToString());
                        this.list_persona = lista_result;
                        if (list_persona.Count.Equals(0))
                        {
                            MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            datagriPersona.DataSource = this.list_persona;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControles();
                    try
                    {
                        string[] nombreapellido_persona = txtBuscar.Text.ToString().Split(' ');
                        List<Funcionario> lista_result = new List<Funcionario>();
                        if (nombreapellido_persona.Length == 2)
                        {
                            lista_result = this.client_fun.BuscarFuncionarioPorNombreApellido(nombreapellido_persona[0].ToString(), nombreapellido_persona[1].ToString());
                            this.list_persona = lista_result;
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                        else
                        {
                            this.list_persona = this.client_fun.BuscarFuncionarioPorNombreApellido(txtBuscar.Text.ToString(), " ");
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
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void datagriPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 13:
                    this.ModificarUsuarios(e);
                    break;
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
                if (cmbxUsuario.SelectedValue.ToString() != "")
                {
                    List<Funcionario> list = this.client_fun.ListarFuncionario();
                    int patron = Convert.ToInt32(cmbxUsuario.SelectedValue.ToString());
                    Funcionario result = list.Find(delegate(Funcionario fun) { return fun.IdPersona == patron; });
                    if (result != null)
                    {
                        if (MessageBox.Show("El Funcionario " + result.Nombre + " " + result.ApellidoPaterno + " ya se encuentra registrado dentro del sistema, ¿Desea modificar su información con la recién ingresada?", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                if (validaciones.EsSoloTexto(txtPuesto)) {
                                    Funcionario funcionario = new Funcionario();
                                    funcionario.IdFuncionario = result.IdFuncionario;
                                    funcionario.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue.ToString());
                                    funcionario.PuestoTrabajo = txtPuesto.Text.ToString();
                                    if (this.client_fun.ModificarFuncionario(funcionario) != "")
                                    {
                                        String deshab = string.Empty;
                                        switch (cmbxestado.SelectedIndex)
                                        {
                                            case 0:
                                                deshab = this.client_fun.DesabilitarHabilitarFuncionario(this.Id_funcionario, 0);
                                                break;

                                            case 1:
                                                deshab = this.client_fun.DesabilitarHabilitarFuncionario(this.Id_funcionario, 1);
                                                break;
                                        }
                                        this.LimpiarControles();
                                        datagriPersona.DataSource = this.client_fun.ListarFuncionario();
                                        MessageBox.Show("Funcionario modificado correctamente.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        if (deshab == string.Empty)
                                        {
                                            MessageBox.Show("Estado del funcionario NO fue modificado.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            if (validaciones.EsSoloTexto(txtPuesto))
                            {
                                Funcionario funcionario = new Funcionario();
                                funcionario.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                                funcionario.PuestoTrabajo = txtPuesto.Text;
                                String id_func = this.client_fun.InsertarFuncionario(funcionario);
                                if (id_func != string.Empty)
                                {
                                    this.LimpiarControles();
                                    datagriPersona.DataSource = this.client_fun.ListarFuncionario();
                                    MessageBox.Show("Funcionario ingresado correctamente.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                try
                {
                    if (validaciones.EsSoloTexto(txtPuesto))
                    {
                        Funcionario funcionario = new Funcionario();
                        funcionario.IdFuncionario = this.Id_funcionario;
                        funcionario.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                        funcionario.PuestoTrabajo = txtPuesto.Text;
                        String resultadoM = this.client_fun.ModificarFuncionario(funcionario);
                        if (resultadoM != "")
                        {
                            String deshab = string.Empty;
                            switch (cmbxestado.SelectedIndex)
                            {
                                case 0:
                                    deshab = this.client_fun.DesabilitarHabilitarFuncionario(this.Id_funcionario, 0);
                                    break;

                                case 1:
                                    deshab = this.client_fun.DesabilitarHabilitarFuncionario(this.Id_funcionario, 1);
                                    break;
                            }
                            this.LimpiarControles();
                            datagriPersona.DataSource = this.client_fun.ListarFuncionario();
                            MessageBox.Show("Funcionario modificado correctamente.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (deshab == string.Empty)
                            {
                                MessageBox.Show("Estado del funcionario NO fue modificado.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbxestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxestado.SelectedIndex == 0)
            {
                if (cmbxUsuario.SelectedValue.ToString() != "")
                {
                    if (MessageBox.Show("¿Desea deshabilitar al usuario " + cmbxUsuario.SelectedText.ToString() + " ?", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        this.cmbxestado.SelectedItem = "Habilitado";
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Desea deshabilitar al usuario?", "SFH Administración de Usuarios del Sistema - Administración de Funcionarios.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        this.cmbxestado.SelectedItem = "Habilitado";
                    }
                }
            }
        }

        private void datagriPersona_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.Editar.Name.Equals("Editar"))
            {
                this.PoblarBotonesGrilla();
            }
        }

        private void txtPuesto_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsSoloTexto(txtPuesto))
            {
                errorProvider1.SetError(txtPuesto, String.Empty);
                txtPuesto.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtPuesto, "Solo se aceptan cadenas alfabéticas");
                txtPuesto.BackColor = Color.MistyRose;
            }
        }
    }
}
