using System;
using System.Collections.Generic;
using System.Collections;
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
        ClientWsReportes client_repo = new ClientWsReportes();
        List<DateTime> list_fechas = new List<DateTime>();
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
        private void GenerarReporte(List<Cita> list_citas)
        {
            int i = 0; int j = 1; int iguales = 0;
            this.chtGrafico.Titles.Add(" Reportes Pacientes  " + DateTime.Now);
            ArrayList list_iguales = new ArrayList();
           //this.chtGrafico.ChartAreas[0].Area3DStyle.Enable3D = true;
           //this.chtGrafico.ChartAreas[0].AxisX.LabelStyle.Format = DateTime;
            foreach (Cita cita in list_citas){

                this.list_fechas.Add(cita.Fecha);
            }
            SortedSet<DateTime> set = new SortedSet<DateTime>(list_fechas);

            foreach (DateTime val in set) {
                iguales = 0;
                foreach (Cita cita in list_citas) {
                    if (cita.Fecha == val) {
                        ++iguales;
                    }
                }
                list_iguales.Add(iguales);
            }
            
            int x = list_fechas.Count;
            int y = set.Count;
            foreach (DateTime val in set)
            {
                Series serie = new Series();
                Legend legend = new Legend();
                serie.Legend = val.ToString();
                legend.Name = "Hora-" + val;
                legend.Title = "Horas de atencion";
                this.chtGrafico.Legends.Add(legend);
                serie = this.chtGrafico.Series.Add(val.ToString());
                serie.Points.AddXY(j, list_iguales[i]);
                ++i; ++j;
                
            }
            chtGrafico.Update();
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
                this.GenerarReporte(list_citas);
                MessageBox.Show("Registros : " + list_citas.Count + " Totales", "SFH Administración de Clínica - Reportes de Pacientes Atendidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.LimpiarControles();
        }

  
    }
}
