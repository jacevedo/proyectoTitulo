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

        private void ModificarUsuarios(DataGridViewCellEventArgs e)
        {
            btnNuevo.Text = "Guardar Cambios";
        }

        private void LimpiarControles()
        {
            
            this.PoblarComboRegion();
            this.txtTelefono.Text = string.Empty;
            this.txtCelular.Text = string.Empty;
            this.txtdir.Text = string.Empty;
            this.txtmail.Text = string.Empty;
            this.btnNuevo.Text = "Ingresar Gastos";

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
        private void PoblarGrillaDatosDeContacto(int id_persona) {
            
            datagriPersona.DataSource = this.client_addUusario.ListarDatosDeContacto(id_persona);

        }
        private void PoblarBotonesGrid() {
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.datagriPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});

        }
        
        public frmDatosDeContacto()
        {
            InitializeComponent();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
           
        }

        
        private void frmDatosDeContacto_Load(object sender, EventArgs e)
        {
            this.PoblarComboRegion();
            this.PoblarComboPersona();
            //this.PoblarGrillaDatosDeContacto(1);
            //this.PoblarBotonesGrid();
            this.btnNuevo.Text = "Ingresar Gastos";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            if (btnNuevo.Text.ToString().Trim() == "Ingresar Gastos")
            {
                Datoscontacto datos = new Datoscontacto();
                datos.IdPersona_dat = Convert.ToInt32(this.cmbxUsuario.SelectedValue);
                datos.IdComuna = Convert.ToInt32(this.cmbxComuna.SelectedValue);
                datos.FonoFijo = txtTelefono.Text;
                datos.FonoCelular = txtCelular.Text;
                datos.Mail = txtmail.Text;
                datos.Direccion = txtdir.Text;
                datos.FechaIngreso = mcfechaIngreso.SelectionStart;
                client_datos.InsertarDatosdeContacto(datos);
                datagriPersona.DataSource = this.client_users.ListarDatosPersona();
                this.LimpiarControles();
                MessageBox.Show("Usuario registrado satisfactoriamente", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                Datoscontacto datos = new Datoscontacto();
                datos.IdPersona_dat = Convert.ToInt32(this.cmbxUsuario.SelectedValue);
                datos.IdComuna = Convert.ToInt32(this.cmbxComuna.SelectedValue);
                datos.FonoFijo = txtTelefono.Text;
                datos.FonoCelular = txtCelular.Text;
                datos.Mail = txtmail.Text;
                datos.Direccion = txtdir.Text;
                datos.FechaIngreso = mcfechaIngreso.SelectionStart;
                client_datos.ModificarDatosdeContacto(datos);
                this.LimpiarControles();
                MessageBox.Show("Usuario modificado satisfactoriamente", "SFH Administración de Clínica - Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void datagriPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.ModificarUsuarios(e);
                    break;
              
            }
        }

        private void cmbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux = 0;
            Persona persona = this.cmbxUsuario.SelectedValue as Persona;
            if (persona != null)
            {
                aux = persona.IdPersona;
                //this.PoblarGrillaDatosDeContacto(aux); 
            }
            else
            {
                aux = Convert.ToInt32(this.cmbxUsuario.SelectedValue.ToString());
                this.PoblarGrillaDatosDeContacto(aux);
            }
        }

    }
}
