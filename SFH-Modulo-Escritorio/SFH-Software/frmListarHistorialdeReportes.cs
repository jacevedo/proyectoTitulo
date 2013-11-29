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
    public partial class frmListarHistorialdeReportes : Form
    {
        #region Campos
        ClientWsDataReportes client_data = new ClientWsDataReportes();
        ClientWsReportes client_repo = new ClientWsReportes();
        List<Reporte> list_repo = new List<Reporte>();
        #endregion

        #region Propiedades
        private void PoblarGrilla() {
            datagridhistorial.DataSource = client_repo.ListarReportes();
            
        }
        private void CargarComboDesde()
        {
            this.cmbxDesdeFecha.DataSource = client_repo.ListarReportesFechasAntNueva();
            this.cmbxDesdeFecha.ValueMember = "IdReporte";
            this.cmbxDesdeFecha.DisplayMember = "FechaCreacion";
        }
        private void CargarComboHasta()
        {
            this.cmbxHastaFecha.DataSource = client_repo.ListarReportesFechasNuevaAnt();
            this.cmbxHastaFecha.ValueMember = "IdReporte";
            this.cmbxHastaFecha.DisplayMember = "FechaCreacion";
        }
        private void LimpiarControles() {
            this.cmbxDesdeFecha.ResetText();
            this.cmbxHastaFecha.ResetText();
            this.CargarComboDesde();
            this.CargarComboHasta();
        
        }
        #endregion
       
        #region Metodos

        #endregion
        
        public frmListarHistorialdeReportes()
        {
            InitializeComponent();
        }

        private void frmListarHistorialdeReportes_Load(object sender, EventArgs e)
        {
            this.PoblarGrilla();
            this.CargarComboDesde();
            this.CargarComboHasta();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Historial de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DateTime fecha_desde = Convert.ToDateTime(this.cmbxDesdeFecha.Text.ToString());
            DateTime fecha_hasta = Convert.ToDateTime(this.cmbxHastaFecha.Text.ToString());
            this.list_repo = this.client_repo.ListarReportesFechas(fecha_desde,fecha_hasta);
            if (this.list_repo.Count.Equals(0))
            {
                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Historial de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.datagridhistorial.DataSource = this.list_repo;
                this.LimpiarControles();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }
    }
}
