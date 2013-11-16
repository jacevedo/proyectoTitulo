using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SFH_Software
{
    public partial class frmGenerarReportesPacientes : Form
    {
        public frmGenerarReportesPacientes()
        {
            InitializeComponent();
        }

        private void frmAdministracionDeReporteria_Load(object sender, EventArgs e)
        {
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
