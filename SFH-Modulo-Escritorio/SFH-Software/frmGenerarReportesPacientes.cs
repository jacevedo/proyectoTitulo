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

        
    }
}
