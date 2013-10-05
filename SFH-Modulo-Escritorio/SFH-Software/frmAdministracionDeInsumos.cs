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
        ClientWsGastos client_gastos = new ClientWsGastos();
        ClientWsAreaInsumoListas client_areainsumo = new ClientWsAreaInsumoListas();
        List<Insumos> result = new List<Insumos>();
        private int idinsumo;

        public int Idinsumo
        {
            get { return idinsumo; }
            set { idinsumo = value; }
        }
        #endregion

        #region Metodos 
        private void PoblarComboBusqueda()
        {

            this.cmbxBuscar.Items.Clear();
            this.cmbxBuscar.Items.Insert(0, "Seleccione tipo de búsqueda");
            this.cmbxBuscar.Items.Insert(1, "Numero de insumo");
            this.cmbxBuscar.Items.Insert(2, "Nombre insumo");
            this.cmbxBuscar.Items.Insert(3, "Numero de Gasto");
            this.cmbxBuscar.SelectedItem = "Seleccione tipo de búsqueda";
        }

        private void PoblarComboAreaInsumo()
        {
            this.cmbxAreaInsumo.DataSource = client_areainsumo.ListarAreaInsumos();
            this.cmbxAreaInsumo.ValueMember = "IdAreaInsumo";
            this.cmbxAreaInsumo.DisplayMember = "NombreArea";
        }
        private void PoblarComboCostos() {
            this.cmbxGastos.DataSource = client_areainsumo.ListarGastos();
            this.cmbxGastos.ValueMember = "IdGastos";
            this.cmbxGastos.DisplayMember = "ConceptodeGastos";

            this.cmbxGastos2.DataSource = client_areainsumo.ListarGastos();
            this.cmbxGastos2.ValueMember = "IdGastos";
            this.cmbxGastos2.DisplayMember = "ConceptodeGastos";
        }
        #endregion


        public frmAdministracionDeInsumos()
        {
            InitializeComponent();
        }

        private void frmAdministracionDeInsumos_Load(object sender, EventArgs e)
        {
            this.dataGridInsumos.DataSource = this.client_precio.ListarInsumos();
            this.PoblarComboAreaInsumo();
            this.PoblarComboCostos();
            this.PoblarComboBusqueda();
        }
       
    }
}
