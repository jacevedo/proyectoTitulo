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
        #region Campos
        ClientWsFichaPresupuesto clientePresupuesto = new ClientWsFichaPresupuesto();
        List<Presupuesto> listaPresupuestos = new List<Presupuesto>();
        private int idFicha;
        private string nombre;
        Validaciones validaciones = new Validaciones();
        bool valido = false;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int IdFicha
        {
            get { return idFicha; }
            set { idFicha = value; }
        }
        #endregion

        #region Metodos 
        private void LimpiarControles()
        {
            this.txtValorTotal.Text = string.Empty;
            this.calendarioCreacion.SelectionStart = DateTime.Today;
            this.calendarioCreacion.SelectionEnd = DateTime.Today;
            btnGuardar.Text = string.Empty;
            btnGuardar.Text = "Ingresar Presupuesto";
        }
        #endregion

        public frmAdministracionPresupuesto(int idFicha, string nombre)
        {
            this.IdFicha = idFicha;
            this.Nombre = nombre;
            InitializeComponent();
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
                    btnGuardar.Text = string.Empty;
                    btnGuardar.Text = "Guardar Cambios";
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Ingresar Presupuesto")
            {
                try
                {
                    if (this.valido)
                    {
                        Presupuesto presupuesto = new Presupuesto();
                        presupuesto.IdFicha = Convert.ToInt32(cmbPersona.SelectedValue.ToString());
                        presupuesto.ValorTotal = Convert.ToInt32(txtValorTotal.Text.ToString());
                        presupuesto.FechaPresupuesto = calendarioCreacion.SelectionStart;
                        presupuesto.IdPresupuesto = Convert.ToInt32(clientePresupuesto.insertarPresupuesto(presupuesto));
                        if (presupuesto.IdPresupuesto != 0)
                        {
                            listaPresupuestos = clientePresupuesto.listadoPresupuestoPorPaciente(presupuesto.IdFicha);
                            grillaPresupuesto.DataSource = listaPresupuestos;
                            MessageBox.Show("Presupuesto insertado correctamente.", "SFH Administración de Clínica - Administración de Presupuesto Dental", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiarFormulario();
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Presupuesto Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Presupuesto Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnGuardar.Text == "Guardar Cambios")
            {
                try
                {
                    if (this.valido)
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
                            btnGuardar.Text = string.Empty;
                            btnGuardar.Text = "Ingresar Presupuesto";
                            MessageBox.Show("Presupuesto modificado correctamente.", "SFH Administración de Clínica - Administración de Presupuesto Dental", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Presupuesto Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Presupuesto Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limpiarFormulario()
        {
            txtValorTotal.Text = string.Empty;
            calendarioCreacion.SelectionStart = DateTime.Today;
            calendarioCreacion.SelectionEnd = DateTime.Today;
        }

        private void frmAdministracionPresupuesto_Load_1(object sender, EventArgs e)
        {
            cmbPersona.DataSource = clientePresupuesto.listaPersonaFichaNombre();
            if (idFicha == 1)
            {
                listaPresupuestos = clientePresupuesto.listadoPresupuestoPorFicha(Convert.ToInt32(cmbPersona.SelectedValue));
            }
            else
            {
                listaPresupuestos = null;
                listaPresupuestos = clientePresupuesto.listadoPresupuestoPorFicha(this.idFicha);
                grillaPresupuesto.DataSource = null;
            }

            grillaPresupuesto.DataSource = listaPresupuestos;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarFormulario();
            grillaPresupuesto.DataSource = null;
            grillaPresupuesto.DataSource = listaPresupuestos;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Nombre = this.cmbPersona.Text;
            listaPresupuestos = null;
            grillaPresupuesto.DataSource = null;
            listaPresupuestos = clientePresupuesto.listadoPresupuestoPorFicha(Convert.ToInt32(cmbPersona.SelectedValue));
            if (listaPresupuestos != null)
            {
                grillaPresupuesto.DataSource = listaPresupuestos;
            }
            else {
                MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de Presupuesto Dental", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtValorTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValorTotal_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsNumero(txtValorTotal))
            {
                errorProvider1.SetError(txtValorTotal, String.Empty);
                txtValorTotal.BackColor = Color.Honeydew;
                this.valido = true;
            }
            else
            {
                errorProvider1.SetError(txtValorTotal, "Debe ingresar un valor numérico");
                txtValorTotal.BackColor = Color.MistyRose;
                this.valido = false;
            }
        }
    }
}
