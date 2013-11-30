using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NetClient;
using ObjectsBeans;
namespace SFH_Software
{
    public partial class frmGenerarReportesPacientes : Form
    {
        #region Campos 
        ClientWsDataReportes client_data = new ClientWsDataReportes();
        ClientWsDataReportes client_repo = new ClientWsDataReportes();
        List<Cita> list_citas = new List<Cita>();
        #endregion 

        #region Propiedades
        
        #endregion 

        #region Metodos
        private void CargarComboDesde() {
            this.cmbxDesdeFecha.DataSource = client_data.ListarCitasFechasAntNueva();
            this.cmbxDesdeFecha.ValueMember = "IdPaciente";
            this.cmbxDesdeFecha.DisplayMember = "Fecha";
        }
        private void CargarComboHasta() {
            this.cmbxHastaFecha.DataSource = client_data.ListarCitasFechasNuevaAnt();
            this.cmbxHastaFecha.ValueMember = "IdPaciente";
            this.cmbxHastaFecha.DisplayMember = "Fecha";
        }
        private void LimpiarControles()
        {
            this.cmbxDesdeFecha.ResetText();
            this.cmbxHastaFecha.ResetText();
            this.CargarComboDesde();
            this.CargarComboHasta();
        }

        #endregion

        public frmGenerarReportesPacientes()
        {
            InitializeComponent();
        }

        private void frmAdministracionDeReporteria_Load(object sender, EventArgs e)
        {

            //Carga ComboBox 
            this.CargarComboDesde();
            this.CargarComboHasta();

            // Arreglos del Grafico
            string[] seriesArray = { "Categoria 1", "Categoria 2", "Categoria 3" };
            int[] pointsArray = { Convert.ToInt32(690), Convert.ToInt32(811), Convert.ToInt32(745) };
            // Se modifica la Paleta de Colores a utilizar por el control.
           // this.chart1.Palette = ChartColorPalette.SeaGreen;
            // Se agrega un titulo al Grafico.
            this.chart1.Titles.Add("Categorias");
            // Agregar las Series al Grafico.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Aqui se agregan las series o Categorias.
                Series series = this.chart1.Series.Add(seriesArray[i]);
                // Aqui se agregan los Valores.
                series.Points.Add(pointsArray[i]);
            } 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Reportes de Pacientes Atendidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DateTime fecha_inicio = Convert.ToDateTime(this.cmbxDesdeFecha.Text.ToString());
            DateTime fecha_termino = Convert.ToDateTime(this.cmbxHastaFecha.Text.ToString());
            this.list_citas = this.client_data.ListarCitasporFechas(fecha_inicio, fecha_termino);

            if (list_citas.Count.Equals(0))
            {
                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Reportes de Pacientes Atendidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Registros : " + list_citas.Count + " Totales", "SFH Administración de Clínica - Reportes de Pacientes Atendidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.LimpiarControles();
        }
      
    }
}
