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
    public partial class frmDatosDeContacto : Form
    {
        private int id_persona;
        ClientWsAddUsuario client_addUusario = new ClientWsAddUsuario();
        ClientWsPassDatosdeContacto client_datos = new ClientWsPassDatosdeContacto();
        ClientWsAdminUsuario client_users = new ClientWsAdminUsuario();
        List<RegionContacto> list_region = new List<RegionContacto>();
        List<Comuna> list_comuna = new List<Comuna>();
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        
      
        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }

        private void ModificarUsuarios(int e)
        {
            Datoscontacto contacto = datagriPersona.Rows[e].DataBoundItem as Datoscontacto;
            this.Id_persona = contacto.IdPersona;
            this.cmbxUsuario.SelectedValue = this.Id_persona;
            this.txtTelefono.Text = contacto.FonoFijo;
            this.txtCelular.Text = contacto.FonoCelular;
            this.txtdir.Text = contacto.Direccion;
            this.txtmail.Text = contacto.Mail;
            this.mcfechaIngreso.SelectionStart = contacto.FechaIngreso;
            this.mcfechaIngreso.SelectionEnd = contacto.FechaIngreso;
            btnNuevo.Text = "Guardar Cambios";
        }

        private void CargarDatosUsuario(int e)
        {
            List<Datoscontacto> list = this.client_datos.ListarPersonasDatosDeContacto();
            Datoscontacto result = list.Find(delegate(Datoscontacto dat) { return dat.IdPersona == e; });
            if (result != null)
            {
                this.Id_persona = result.IdPersona;
                this.cmbxUsuario.SelectedValue = this.Id_persona;
                this.txtTelefono.Text = result.FonoFijo;
                this.txtCelular.Text = result.FonoCelular;
                this.txtdir.Text = result.Direccion;
                this.txtmail.Text = result.Mail;
                this.mcfechaIngreso.SelectionStart = result.FechaIngreso;
                this.mcfechaIngreso.SelectionEnd = result.FechaIngreso;
                btnNuevo.Text = "Guardar Cambios";
            }
            else
            {
                MessageBox.Show("Se produjo un error, no se pudo cargar los datos del usuario seleccionado.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControles()
        {
            if (this.Editar.Name.Equals("Editar"))
            {
                this.PoblarComboRegion();
                this.txtTelefono.Text = string.Empty;
                this.txtCelular.Text = string.Empty;
                this.txtdir.Text = string.Empty;
                this.txtmail.Text = string.Empty;
                this.btnNuevo.Text = "Ingresar Datos de Contacto";
                this.datagriPersona.Columns.RemoveAt(18);
                this.Editar.Name = String.Empty;
            }
            else {
                this.PoblarComboRegion();
                this.txtTelefono.Text = string.Empty;
                this.txtCelular.Text = string.Empty;
                this.txtdir.Text = string.Empty;
                this.txtmail.Text = string.Empty;
                this.btnNuevo.Text = "Ingresar Datos de Contacto";
            }
        }

        private void PoblarComboPersona() 
        {
            this.cmbxUsuario.DataSource = client_users.ListarPersonas();
            this.cmbxUsuario.ValueMember = "IdPersona";
            this.cmbxUsuario.DisplayMember = "Nombre";
        }
        private void PoblarComboRegion()
        {
            this.cmbxRegion.DataSource = client_addUusario.ListarRegiones();
            this.cmbxRegion.ValueMember = "IdRegion";
            this.cmbxRegion.DisplayMember = "NombreRegion";
        }

        private void PoblarComboComuna(int id_region)
        {
            this.cmbxComuna.DataSource = client_addUusario.ListarComunaIdRegiones(id_region);
            this.cmbxComuna.ValueMember = "IdComuna";
            this.cmbxComuna.DisplayMember = "NombreComuna";
        }
        private void PoblarBotonesGrilla()
        {
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.datagriPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});
        }

        private void PoblarGrillaDatosDeContacto()
        {
            datagriPersona.DataSource = this.client_datos.ListarPersonasDatosDeContacto();
            this.PoblarBotonesGrilla();
        }
       
        
        public frmDatosDeContacto()
        {
            InitializeComponent();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();      
        }

        public frmDatosDeContacto(int id)
        {
            InitializeComponent();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id_persona = id;
        }

        
        private void frmDatosDeContacto_Load(object sender, EventArgs e)
        {
            this.PoblarComboRegion();
            this.PoblarComboPersona();
            this.PoblarGrillaDatosDeContacto();
            this.btnNuevo.Text = "Ingresar Datos de Contacto";
            if (this.id_persona != 0)
            {
                this.CargarDatosUsuario(id_persona);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            if (btnNuevo.Text.ToString().Trim() == "Ingresar Datos de Contacto")
            {
                if (cmbxUsuario.SelectedValue.ToString() != "")
                {
                    //datagriPersona.DataSource = 
                    List<Datoscontacto> list = this.client_datos.ListarPersonasDatosDeContacto();
                    int patron = Convert.ToInt32(cmbxUsuario.SelectedValue.ToString());
                    Datoscontacto result = list.Find(delegate(Datoscontacto dat) { return dat.IdPersona == patron; });
                    if (result != null)
                    {
                        if (MessageBox.Show("El paciente " + result.Nombre + " " + result.ApellidoPaterno + " tiene registrado sus datos de contacto dentro del sistema, ¿Desea reemplazarlos con los recién ingresados?", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                Datoscontacto datos = new Datoscontacto();
                                datos.IdPersona_dat = Convert.ToInt32(this.cmbxUsuario.SelectedValue);
                                datos.IdComuna = Convert.ToInt32(this.cmbxComuna.SelectedValue);
                                datos.FonoFijo = txtTelefono.Text;
                                datos.FonoCelular = txtCelular.Text;
                                datos.Mail = txtmail.Text;
                                datos.Direccion = txtdir.Text;
                                datos.FechaIngreso = mcfechaIngreso.SelectionStart;
                                String id_datos_m = client_datos.ModificarDatosdeContacto(datos);
                                if (id_datos_m != string.Empty)
                                {
                                    this.LimpiarControles();
                                    datagriPersona.DataSource = this.client_datos.ListarPersonasDatosDeContacto();
                                    MessageBox.Show("Datos de contacto modificado satisfactoriamente", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
  
                    }
                    else
                    {
                        try
                        {
                            Datoscontacto datos = new Datoscontacto();
                            datos.IdPersona_dat = Convert.ToInt32(this.cmbxUsuario.SelectedValue);
                            datos.IdComuna = Convert.ToInt32(this.cmbxComuna.SelectedValue);
                            datos.FonoFijo = txtTelefono.Text;
                            datos.FonoCelular = txtCelular.Text;
                            datos.Mail = txtmail.Text;
                            datos.Direccion = txtdir.Text;
                            datos.FechaIngreso = mcfechaIngreso.SelectionStart;
                            String id_datos_i = client_datos.InsertarDatosdeContacto(datos);
                            if (id_datos_i != string.Empty)
                            {
                                this.LimpiarControles();
                                datagriPersona.DataSource = this.client_datos.ListarPersonasDatosDeContacto();
                                MessageBox.Show("Datos de contacto registrados satisfactoriamente", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Datoscontacto datos = new Datoscontacto();
                    datos.IdPersona_dat = Convert.ToInt32(this.cmbxUsuario.SelectedValue);
                    datos.IdComuna = Convert.ToInt32(this.cmbxComuna.SelectedValue);
                    datos.FonoFijo = txtTelefono.Text;
                    datos.FonoCelular = txtCelular.Text;
                    datos.Mail = txtmail.Text;
                    datos.Direccion = txtdir.Text;
                    datos.FechaIngreso = mcfechaIngreso.SelectionStart;
                    String datos_mod = client_datos.ModificarDatosdeContacto(datos);
                    if (datos_mod != string.Empty)
                    {
                        this.LimpiarControles();
                        datagriPersona.DataSource = this.client_datos.ListarPersonasDatosDeContacto();

                        MessageBox.Show("Usuario modificado satisfactoriamente", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Usuarios del Sistema - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux = 0;
            RegionContacto region = cmbxRegion.SelectedValue as RegionContacto;
            if (region != null)
            {
                aux = region.IdRegion;
                this.PoblarComboComuna(aux);
            }
            else
            {
                aux = Convert.ToInt32(cmbxRegion.SelectedValue.ToString());
                this.PoblarComboComuna(aux);
            }
        }

        private void cmbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux = 0;
            Persona persona = this.cmbxUsuario.SelectedValue as Persona;
            if (persona != null)
            {
                aux = persona.IdPersona;
            }
            else
            {
                aux = Convert.ToInt32(this.cmbxUsuario.SelectedValue.ToString());
            }
        }

        private void datagriPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.ModificarUsuarios(e.RowIndex);
                    break;
            }
        }
    }
}
