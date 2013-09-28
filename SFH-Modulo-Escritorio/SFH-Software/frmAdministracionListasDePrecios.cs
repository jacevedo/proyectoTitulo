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
    public partial class frmAdministracionListasDePrecios : Form
    {
        #region Campos
        ClientWsPreciosInsumos client_precio = new ClientWsPreciosInsumos();
        List<Listadeprecio> result = new List<Listadeprecio>();
        #endregion

        public frmAdministracionListasDePrecios()
        {
            InitializeComponent();
        }

        private void frmAdministracionListasDePrecios_Load(object sender, EventArgs e)
        {
            //Cargar Grillas 
            this.dataGridPrecio.DataSource = this.client_precio.ListarPrecios();
            btnNuevo.Text = "Ingresar Ficha";
        }
        

    }
}
