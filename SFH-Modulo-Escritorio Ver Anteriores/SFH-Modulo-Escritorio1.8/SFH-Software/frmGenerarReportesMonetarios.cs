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
    public partial class frmGenerarReportesMonetarios : Form
    {
        #region Campos
        ClientWsDataReportes client_data = new ClientWsDataReportes();
        ClientWsReportes client_repo = new ClientWsReportes();
        List<Abono> list_abns = new List<Abono>();
        List<Gastos> list_gastos = new List<Gastos>();

        #endregion

        #region Propiedades

        #endregion

        #region Metodos
        private void CargarComboDesde()
        {
            this.cmbxDesdeFecha.DataSource = client_data.ListarAbonosFechasAntNueva();
            this.cmbxDesdeFecha.ValueMember = "IdAbono";
            this.cmbxDesdeFecha.DisplayMember = "FechaAbono";
        }
        private void CargarComboHasta()
        {
            this.cmbxHastaFecha.DataSource = client_data.ListarAbonosFechasNuevaAnt();
            this.cmbxHastaFecha.ValueMember = "IdAbono";
            this.cmbxHastaFecha.DisplayMember = "FechaAbono";
        }
        private void LimpiarControles()
        {
            this.cmbxDesdeFecha.ResetText();
            this.cmbxHastaFecha.ResetText();
            this.CargarComboDesde();
            this.CargarComboHasta();
        }
        private Boolean RegistrarReporte() {
            return true;
        }

        #endregion


        public frmGenerarReportesMonetarios()
        {
            InitializeComponent();
        }

        private void frmGenerarReportesMonetarios_Load(object sender, EventArgs e)
        {
            this.CargarComboDesde();
            this.CargarComboHasta();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void btnGeneraReporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Reportes Monetarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DateTime fecha_inicio = Convert.ToDateTime(this.cmbxDesdeFecha.Text.ToString());
            DateTime fecha_termino = Convert.ToDateTime(this.cmbxHastaFecha.Text.ToString());
            this.list_abns = this.client_data.ListarAbonosporFechas(fecha_inicio,fecha_termino);
            
            if (list_abns.Count.Equals(0))
            {
                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Reportes Monetarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                this.list_gastos = this.client_data.ListarGastosporFechas(fecha_inicio,fecha_termino);
                if (list_gastos.Count > 0) {
                    MessageBox.Show("Registros : " + list_abns.Count + " Totales y Gastos " + list_gastos.Count + " ", "SFH Administración de Clínica - Reportes Monetarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            this.LimpiarControles();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

      
      
    }
}
