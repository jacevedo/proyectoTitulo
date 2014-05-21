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
    public partial class frmOdontologo : Form
    {
        ClientWsAdminUsuario client_users = new ClientWsAdminUsuario();
        ClientWsOdontologo client_odontologo = new ClientWsOdontologo();
        List<Odontologo> list_persona = new List<Odontologo>();
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private int id_odontologo;
        public int Id_odontologo
        {
            get { return id_odontologo; }
            set { id_odontologo = value; }
        }

        private void ModificarUsuarios(DataGridViewCellEventArgs e)
        {
            Odontologo odontologo = datagriPersona.Rows[e.RowIndex].DataBoundItem as Odontologo;
            this.Id_odontologo = odontologo.IdOdontologo;
            cmbxUsuario.SelectedValue = odontologo.IdPersona;
            txtesp.Text = odontologo.Especialidad;
            cmbxestado.SelectedIndex = Convert.ToInt32(odontologo.OdontologoHabilitado);
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
                this.btnNuevo.Text = "Ingresar Odontologo";
                this.txtesp.Text = String.Empty;
                this.datagriPersona.Columns.RemoveAt(13);
                this.Editar.Name = String.Empty;
            }
            else
            {
                this.btnNuevo.Text = "Ingresar Odontologo";
                this.txtesp.Text = String.Empty;
            }
        }

        private void PoblarComboEstado()
        {
            this.cmbxestado.Items.Clear();
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.DESHABILITADO), "Deshabilitado");
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.HABILITADO), "Habilitado");
            //this.cmbxestado.Items.Insert(2, "Seleccione tipo de estado");
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
            this.cmbxBuscar.Items.Insert(1, "Buscar Odontologo Por Rut");
            this.cmbxBuscar.Items.Insert(2, "Buscar Odontologo Por Nombre Apellido");
            this.cmbxBuscar.SelectedItem = "Seleccione tipo de búsqueda";
        }

        private void PoblarComboPersona()
        {
            //this.cmbxUsuario.DataSource = client_users.ListarPersonas();
            this.cmbxUsuario.DataSource = client_users.ListarOdontologoPersona();
            this.cmbxUsuario.ValueMember = "IdPersona";
            this.cmbxUsuario.DisplayMember = "Nombre";
        }

        public frmOdontologo()
        {
            InitializeComponent();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();   
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
            this.datagriPersona.DataSource = this.client_odontologo.ListarOdontologo();
           
        }

        private void frmOdontologo_Load(object sender, EventArgs e)
        {
            this.PoblarComboEstado();
            this.PoblarComboPersona();
            this.PoblarComboBusqueda();
            //poblamiento de grilla
             this.PoblarGrilla();
            this.btnNuevo.Text = "Ingresar Odontologo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (this.cmbxBuscar.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("Debes seleccionar una opción de búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControles();
                    datagriPersona.DataSource = this.client_odontologo.ListarOdontologo();
                    break;
                case 1:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControles();
                    try
                    {
                        this.list_persona = this.client_odontologo.BuscarOdontologoPorRut(this.txtBuscar.Text.ToString());
                        if (list_persona.Count.Equals(0))
                        {
                            MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            datagriPersona.DataSource = this.list_persona;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControles();
                    try
                    {
                        string[] nombreapellido_persona = txtBuscar.Text.ToString().Split(' ');
                        if (nombreapellido_persona.Length == 2)
                        {
                            this.list_persona = this.client_odontologo.BuscarOdontologoPorNombreApellido(nombreapellido_persona[0].ToString(), nombreapellido_persona[1].ToString());
                            if (list_persona.Count.Equals(0))
                            {
                                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                datagriPersona.DataSource = this.list_persona;
                            }
                        }
                        else
                        {
                            this.list_persona = this.client_odontologo.BuscarOdontologoPorNombreApellido(txtBuscar.Text.ToString(), " ");
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
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Odontologo")
            {
                if (cmbxUsuario.SelectedValue.ToString() != "")
                {
                    List<Odontologo> list = this.client_odontologo.ListarOdontologo();
                    int patron = Convert.ToInt32(cmbxUsuario.SelectedValue.ToString());
                    Odontologo result = list.Find(delegate(Odontologo odot) { return odot.IdPersona == patron; });
                    if (result != null)
                    {
                        if (MessageBox.Show("El odontólogo " + result.Nombre + " " + result.ApellidoPaterno + " ya se encuentra registrado en el sistema, ¿Desea modificar su información con la recién ingresada?", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                Odontologo odontologo = new Odontologo();
                                odontologo.IdOdontologo = result.IdOdontologo;
                                odontologo.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                                odontologo.Especialidad = txtesp.Text;
                                if (this.client_odontologo.ModificarOdontologo(odontologo) != "")
                                {
                                    String deshab = string.Empty;
                                    switch (cmbxestado.SelectedIndex)
                                    {
                                        case 0:
                                            deshab = this.client_odontologo.DesabilitarHabilitarOdontologo(this.Id_odontologo, 0);
                                            break;

                                        case 1:
                                            deshab = this.client_odontologo.DesabilitarHabilitarOdontologo(this.Id_odontologo, 1);
                                            break;
                                    }
                                    this.LimpiarControles();
                                    datagriPersona.DataSource = this.client_odontologo.ListarOdontologo();
                                    MessageBox.Show("Odontólogo modificado correctamente.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (deshab == string.Empty)
                                    {
                                        MessageBox.Show("Estado del odontólogo NO fue modificado.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            Odontologo odontologo = new Odontologo();
                            odontologo.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                            odontologo.Especialidad = txtesp.Text;
                            String insert_odonto = this.client_odontologo.InsertarOdontologo(odontologo);
                            if (insert_odonto != string.Empty)
                            {
                                this.LimpiarControles();
                                datagriPersona.DataSource = this.client_odontologo.ListarOdontologo();
                                MessageBox.Show("Odontologo ingresado correctamente.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                          
            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                try
                {
                    Odontologo odontologo = new Odontologo();
                    odontologo.IdOdontologo = this.Id_odontologo;
                    odontologo.IdPersona = Convert.ToInt32(cmbxUsuario.SelectedValue);
                    odontologo.Especialidad = txtesp.Text;
                    if (this.client_odontologo.ModificarOdontologo(odontologo) != "")
                    {
                        String deshab_odonto = string.Empty;
                        switch (cmbxestado.SelectedIndex)
                        {
                            case 0:
                                deshab_odonto = this.client_odontologo.DesabilitarHabilitarOdontologo(this.Id_odontologo, 0);
                                break;

                            case 1:
                                deshab_odonto = this.client_odontologo.DesabilitarHabilitarOdontologo(this.Id_odontologo, 1);
                                break;
                        }
                        this.LimpiarControles();
                        datagriPersona.DataSource = this.client_odontologo.ListarOdontologo();
                        MessageBox.Show("Odontologo modificado satisfactoriamente", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deshab_odonto == string.Empty)
                        {
                            MessageBox.Show("Estado del odontólogo NO fue modificado.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbxestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxestado.SelectedIndex == 0)
            {
                if (cmbxUsuario.SelectedValue.ToString() != "")
                {
                    if (MessageBox.Show("¿Desea deshabilitar al usuario " + cmbxUsuario.SelectedText + " ?", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        this.cmbxestado.SelectedItem = "Habilitado";
                    }
                }
                else
                {

                    if (MessageBox.Show("¿Desea deshabilitar al usuario?", "SFH Administración de Usuarios del Sistema - Administración de Odontólogos.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
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

      
    }
}
