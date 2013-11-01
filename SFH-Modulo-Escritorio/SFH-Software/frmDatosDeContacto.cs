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
        List<RegionContacto> list_region = new List<RegionContacto>();
        List<Comuna> list_comuna = new List<Comuna>();

        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }
        private void LimpiarControles()
        {
            //combo box 
            this.PoblarComboRegion();
            this.txtTelefono.Text = string.Empty;
            this.txtCelular.Text = string.Empty;
            this.txtdir.Text = string.Empty;
            this.txtmail.Text = string.Empty;
            this.btnNuevo.Text = "Ingresar Gastos";

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

        public frmDatosDeContacto()
        {
            InitializeComponent();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void frmDatosDeContacto_Load(object sender, EventArgs e)
        {
            this.PoblarComboRegion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

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

    }
}
