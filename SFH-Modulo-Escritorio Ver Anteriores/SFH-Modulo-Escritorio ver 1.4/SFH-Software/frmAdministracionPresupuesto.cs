using NetClient;
using ObjectsBeans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SFH_Software
{
    public partial class frmAdministracionPresupuesto : Form
    {
        ClientWsFichaPresupuesto clientePresupuesto = new ClientWsFichaPresupuesto();
        List<Presupuesto> listaPresupuestos = new List<Presupuesto>();
        int idFicha=-1;
        public frmAdministracionPresupuesto()
        {
            InitializeComponent();
            this.Load += frmAdministracionPresupuesto_Load;
        }
        public frmAdministracionPresupuesto(int idFicha)
        {
            InitializeComponent();
            this.Load += frmAdministracionPresupuesto_Load;
        }


        void frmAdministracionPresupuesto_Load(object sender, EventArgs e)
        {
            if (idFicha != -1)
            {
                listaPresupuestos = clientePresupuesto.listadoPresupuestoPorPaciente(1);
            }
            else
            {
                listaPresupuestos = clientePresupuesto.listadoPresupuestoPorFicha(idFicha);
            }
            cmbPersona.DataSource = clientePresupuesto.listaPersonaFichaNombre();
            grillaPresupuesto.DataSource = listaPresupuestos;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Presupuesto presupuesto = grillaPresupuesto.Rows[e.RowIndex].DataBoundItem as Presupuesto;
                if (e.ColumnIndex == 5)
                {
                    txtValorTotal.Text = presupuesto.ValorTotal.ToString();
                    cmbPersona.SelectedValue = presupuesto.IdFicha;
                    calendarioCreacion.SelectionStart = presupuesto.FechaPresupuesto;
                    calendarioCreacion.SelectionEnd = presupuesto.FechaPresupuesto;
                    lblIdPresupuesto.Text = presupuesto.IdPresupuesto.ToString();
                    btnGuardar.Text = "Modificar";
                }
            }
        }

        private void btnAdminCli_Click(object sender, EventArgs e)
        {
            listaPresupuestos = null;
            listaPresupuestos = clientePresupuesto.listadoPresupuestoPorFicha(Convert.ToInt32(cmbPersona.SelectedValue));
            grillaPresupuesto.DataSource = null;
            grillaPresupuesto.DataSource = listaPresupuestos;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Guardar")
            {
                try
                {
                    Presupuesto presupuesto = new Presupuesto();
                    presupuesto.IdFicha = Convert.ToInt32(cmbPersona.SelectedValue);
                    presupuesto.ValorTotal = Convert.ToInt32(txtValorTotal.Text.ToString());
                    presupuesto.FechaPresupuesto = calendarioCreacion.SelectionStart;
                    presupuesto.IdPresupuesto = Convert.ToInt32(clientePresupuesto.insertarPresupuesto(presupuesto));
                    limpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al insertar");
                }

            }
            else if (btnGuardar.Text == "Modificar")
            {
                Presupuesto presupuesto = new Presupuesto();
                presupuesto.IdFicha = Convert.ToInt32(cmbPersona.SelectedValue);
                presupuesto.ValorTotal = Convert.ToInt32(txtValorTotal.Text.ToString());
                presupuesto.FechaPresupuesto = calendarioCreacion.SelectionStart;
                presupuesto.IdPresupuesto = Convert.ToInt32(lblIdPresupuesto.Text.ToString());
                if (clientePresupuesto.modificarPresupuesto(presupuesto) == "Modificado")
                {
                    for (int i = 0; i < listaPresupuestos.Count; i++)
                    {
                        if (listaPresupuestos.ElementAt(i).IdPresupuesto == presupuesto.IdPresupuesto)
                        {
                            listaPresupuestos.RemoveAt(i);
                            listaPresupuestos.Insert(i, presupuesto);
                            grillaPresupuesto.DataSource = null;
                            grillaPresupuesto.DataSource = listaPresupuestos;
                            break;
                        }

                    }
                    limpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Hubo un problema al modificar El presupuesto");
                }
                btnGuardar.Text = "Guardar";
            }

        }

        private void limpiarFormulario()
        {
            txtValorTotal.Text = "";
            calendarioCreacion.SelectionStart = DateTime.Today;
            calendarioCreacion.SelectionEnd = DateTime.Today;
        }

       
    }
}
