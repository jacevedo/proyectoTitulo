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
using System.Windows.Forms.DataVisualization.Charting;
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
        private void GenerarReporte(List<Abono> param_lista_abonos, List<Gastos> param_lista_gastos,DateTime desde , DateTime hasta)
        {
            this.chart1.Titles.Clear();
            int montoAbono = 0;
            int montoGastos =0;
            int montoTotal = 0;
            this.chart1.Titles.Add(" Reportes Monetario - Generado el día: " + DateTime.Now + System.Environment.NewLine + " " + System.Environment.NewLine + "Desde el día " + desde + " hasta el día " + hasta);
            foreach (Abono abono in param_lista_abonos)
            {
                montoAbono += abono.Monto;
                montoTotal += montoAbono;
            }
            foreach (Gastos gastos in param_lista_gastos)
            {
                montoGastos += gastos.MontoGastos;
                montoTotal  += montoGastos;
            }
            int[] yValues = {montoAbono, montoGastos};
            string[] xValues = { "Total Abonos: $" + montoAbono.ToString(), "Gastos Totales: $" + montoGastos.ToString()};
            chart1.Series[0].Points.DataBindXY(xValues, yValues);
            chart1.Series[0].ChartType = SeriesChartType.Doughnut;
            chart1.Series[0]["PieLabelStyle"] = "Outside";
            chart1.Series[0]["DoughnutRadius"] = "30";
            chart1.Series[0].Points[1]["Exploded"] = "true";
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.Series[0]["PieDrawingStyle"] = "SoftEdge";
            MessageBox.Show("Monto de ingreso Clinica: $" + montoAbono.ToString() + System.Environment.NewLine + "Monto de egreso por gasto: $" + montoGastos.ToString() + " " + System.Environment.NewLine + " " + System.Environment.NewLine + "Desde el día " + desde + " hasta el día "+ hasta, "SFH Administración de Reportes y Estadísticas - Reportes Monetarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            chart1.UpdateAnnotations();
            chart1.Update();
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
            MessageBox.Show("El sistema sfh está generando su reporte", "SFH Administración de Reportes y Estadísticas - Reportes Monetarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DateTime fecha_inicio = Convert.ToDateTime(this.cmbxDesdeFecha.Text.ToString());
            DateTime fecha_termino = Convert.ToDateTime(this.cmbxHastaFecha.Text.ToString());
            this.list_abns = this.client_data.ListarAbonosporFechas(fecha_inicio, fecha_termino);

            if (list_abns.Count.Equals(0))
            {
                MessageBox.Show("Esta operación no ha arrojado resultados", "SFH Administración de Reportes y Estadísticas - Reportes Monetarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.list_gastos = this.client_data.ListarGastosporFechas(fecha_inicio, fecha_termino);
                if (list_gastos.Count > 0)
                {
                    this.GenerarReporte(list_abns, list_gastos, fecha_inicio, fecha_termino);
                }
            }
            this.LimpiarControles();
        }
      
    }
}
