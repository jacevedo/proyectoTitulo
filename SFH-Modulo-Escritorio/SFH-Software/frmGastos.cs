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
    public partial class frmGastos : Form
    {
        #region Campos
        ClientWsGastos client_gastos = new ClientWsGastos();
        ClientWsAdminUsuario client_users = new ClientWsAdminUsuario();
        List<Gastos> result = new List<Gastos>();
        private int id_gastos;
        private frmMenu frmMenu;

        public int Id_gastos
        {
            get { return id_gastos; }
            set { id_gastos = value; }
        }
        #endregion

        public frmGastos(frmMenu frmMenu)
        {
            InitializeComponent();
            this.frmMenu = frmMenu;
        }

        #region Metodos 
        private void PoblarCombosPersona()
        {
            this.cmbxpersona.DataSource = client_users.ListarPersonas();
            this.cmbxpersona.ValueMember = "IdPersona";
            this.cmbxpersona.DisplayMember = "Nombre";

            this.cmbxPersonaBusqueda.DataSource = client_users.ListarPersonas();
            this.cmbxPersonaBusqueda.ValueMember = "IdPersona";
            this.cmbxPersonaBusqueda.DisplayMember = "Nombre";
        }

        private void ModificarGastos(DataGridViewCellEventArgs e)
        {
            Gastos gasto = dataGridGastos.Rows[e.RowIndex].DataBoundItem as Gastos;
            this.Id_gastos = gasto.IdGastos;
            this.txtMonto.Text = gasto.MontoGastos.ToString();
            this.txtDescuento.Text = gasto.DescuentoGastos.ToString();
            this.txtConcept.Text = gasto.ConceptodeGastos.ToString();
            btnNuevo.Text = "Guardar Cambios";
        }
        private void LimpiarControles()
        {
            this.txtMonto.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
            this.txtConcept.Text = string.Empty;
            btnNuevo.Text = "Ingresar Gastos";
        }
        #endregion

        private void frmGastos_Load(object sender, EventArgs e)
        {
            //Cargar Grillas 
            this.dataGridGastos.DataSource = this.client_gastos.ListarGastos();
            btnNuevo.Text = "Ingresar Gastos";
            this.PoblarCombosPersona();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int param = Convert.ToInt32(this.cmbxPersonaBusqueda.SelectedValue);
            MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.result = this.client_gastos.ListarGastosporIdpersona(param);

            if (result.Count.Equals(0))
            {
                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.dataGridGastos.DataSource = this.result;
            }
            
        }

        private void dataGridGastos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.ModificarGastos(e);
                    break;
                case 1:
                    if (MessageBox.Show("¿Desea eliminar este registro de gasto?", "SFH Administración de Clínica - Administración de Gastos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Gastos gasto = dataGridGastos.Rows[e.RowIndex].DataBoundItem as Gastos;
                        this.client_gastos.EliminarGastos(gasto.IdGastos);
                        this.dataGridGastos.DataSource = this.client_gastos.ListarGastos();
                        MessageBox.Show("Gasto eliminado del sistema", "SFH Administración de Clínica - Administración de  Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            case 2:
                   frmAdministracionDeInsumos insumo = new frmAdministracionDeInsumos(frmMenu);
                    this.frmMenu.MostrarForm("Administración de reportes e insumos", insumo);
                    break;

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Gastos")
            {
                Gastos gasto = new Gastos();
                gasto.IdPersona = Convert.ToInt32(cmbxpersona.SelectedValue);
                gasto.ConceptodeGastos = txtConcept.Text.ToString();
                gasto.MontoGastos = int.Parse(txtMonto.Text.ToString());
                gasto.DescuentoGastos = int.Parse(txtDescuento.Text.ToString());
                this.client_gastos.InsertarGatos(gasto);
                this.dataGridGastos.DataSource = this.client_gastos.ListarGastos();
                this.LimpiarControles();
                MessageBox.Show("Gasto registrado satisfactoriamente", "SFH Administración de Clínica - Administración de Área insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                Gastos gasto = new Gastos();
                gasto.IdGastos = this.Id_gastos;
                gasto.IdPersona = Convert.ToInt32(cmbxpersona.SelectedValue);
                gasto.ConceptodeGastos = txtConcept.Text.ToString();
                gasto.MontoGastos = int.Parse(txtMonto.Text.ToString());
                gasto.DescuentoGastos = int.Parse(txtDescuento.Text.ToString());
                this.client_gastos.ModificarGastos(gasto);
                this.dataGridGastos.DataSource = this.client_gastos.ListarGastos();
                this.LimpiarControles();
                MessageBox.Show("Gasto modificado satisfactoriamente", "SFH Administración de Clínica - Administración de Área insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

       

       


    }
}
