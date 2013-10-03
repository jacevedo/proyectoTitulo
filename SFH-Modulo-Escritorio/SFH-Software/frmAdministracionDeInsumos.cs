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
    public partial class frmAdministracionDeInsumos : Form
    {
        #region Campos
        ClientWsPreciosInsumos client_precio = new ClientWsPreciosInsumos();
        List<Insumos> result = new List<Insumos>();
        private int idinsumo;

        public int Idinsumo
        {
            get { return idinsumo; }
            set { idinsumo = value; }
        }
        #endregion

        public frmAdministracionDeInsumos()
        {
            InitializeComponent();
        }

        private void frmAdministracionDeInsumos_Load(object sender, EventArgs e)
        {
            this.dataGridInsumos.DataSource = this.client_precio.ListarInsumos();
        }
       
    }
}
