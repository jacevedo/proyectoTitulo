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
    public partial class frmAdministracionOrdenLab : Form
    {
        ClientWsOrdenLaboratorio clienteOrden = new ClientWsOrdenLaboratorio();
        List<Ordendelaboratorio> listaOrden = new List<Ordendelaboratorio>();
        Validaciones validaciones = new Validaciones();
        
        public frmAdministracionOrdenLab()
        {
            InitializeComponent();
        }
        #region Metodos 
        private bool validarformulario() {
            
            if (validaciones.EsNumero(txtNumOrden) == true & validaciones.EsSoloafanumerico(txtLaboratorio) == true
                & validaciones.EsNumero(txtBD) == true & validaciones.EsNumero(txtBI) == true
                & validaciones.EsNumero(txtPD) == true & validaciones.EsNumero(txtPI) == true
                & validaciones.EsHora(txtHoraEntrega) == true & validaciones.EsSoloTexto(txtColor) == true){
                return true;

            }else{

                return false;
            }
        }
        #endregion

        private void GuardarOrden()
        {
            try
            {
                if(this.validarformulario()){
                Ordendelaboratorio orden = new Ordendelaboratorio();
                orden.IdOdontologo = Convert.ToInt32(cmbNomOdontologo.SelectedValue);
                orden.IdPaciente = Convert.ToInt32(cmbNomPaciente.SelectedValue);
                orden.NumeroOrden = Convert.ToInt32(txtNumOrden.Text);
                orden.Clinica = txtLaboratorio.Text;
                orden.Bd = txtBD.Text;
                orden.Bi = txtBI.Text;
                orden.Pd = txtPD.Text;
                orden.Pi = txtPI.Text;
                orden.HoraEntrega = txtHoraEntrega.Text;
                orden.Color = txtColor.Text;
                orden.Estadodeorden = obtenerEstado();
                orden.FechaCreacion = CalendarCreacion.SelectionStart;
                orden.FechaEntrega = calendarEntrega.SelectionStart;
                orden.IdOrdenLaboratorio = Convert.ToInt32(clienteOrden.insertarOrden(orden));
                if (orden.IdOrdenLaboratorio > 0)
                {
                    this.listaOrden = clienteOrden.ListarOrdenLaboratorio();
                    GrillaOrden.DataSource = listaOrden;
                    limpiarFormulario();
                    MessageBox.Show("Orden de laboratorio ingresada correctamente.", "SFH Administración de Clínica - Administración de Orden de Laboratorio Dental", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Orden de Laboratorio Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }      
              }
            }
            catch
            {
                MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Orden de Laboratorio Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private EstadoOrdenLaboratorio obtenerEstado()
        {
            EstadoOrdenLaboratorio status;
            Enum.TryParse<EstadoOrdenLaboratorio>(cmbEstado.SelectedValue.ToString(), out status);
            return status;
        }

        private void modificarOrdenGuardar()
        {
            try
            {
                if (this.validarformulario())
                {
                    Ordendelaboratorio orden = new Ordendelaboratorio();
                    orden.IdOrdenLaboratorio = Convert.ToInt32(lblIdOrden.Text.ToString());
                    orden.IdOdontologo = Convert.ToInt32(cmbNomOdontologo.SelectedValue);
                    orden.IdPaciente = Convert.ToInt32(cmbNomPaciente.SelectedValue);
                    orden.NumeroOrden = Convert.ToInt32(txtNumOrden.Text);
                    orden.Clinica = txtLaboratorio.Text;
                    orden.Bd = txtBD.Text;
                    orden.Bi = txtBI.Text;
                    orden.Pd = txtPD.Text;
                    orden.Pi = txtPI.Text;
                    orden.HoraEntrega = txtHoraEntrega.Text;
                    orden.Color = txtColor.Text;
                    orden.Estadodeorden = obtenerEstado();
                    orden.FechaCreacion = CalendarCreacion.SelectionStart;
                    orden.FechaEntrega = calendarEntrega.SelectionStart;
                    orden.NomOdontologo = (cmbNomOdontologo.SelectedItem as Persona).Nombre;
                    orden.NomPaciente = (cmbNomPaciente.SelectedItem as Persona).Nombre;
                    if (clienteOrden.modificarOrden(orden) == "Ok")
                    {
                        for (int i = 0; i < listaOrden.Count; i++)
                        {
                            if (listaOrden.ElementAt(i).IdOrdenLaboratorio == orden.IdOrdenLaboratorio)
                            {
                                listaOrden.RemoveAt(i);
                                listaOrden.Insert(i, orden);
                                GrillaOrden.DataSource = null;
                                GrillaOrden.DataSource = listaOrden;
                                limpiarFormulario();
                                MessageBox.Show("Orden de Laboratorio modificada correctamente.", "SFH Administración de Clínica - Administración de Orden de Laboratorio Dental", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnGuardar.Text = string.Empty;
                                btnGuardar.Text = "Ingresar Orden";
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Orden de Laboratorio Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Orden de Laboratorio Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarFormulario()
        {
            cmbNomOdontologo.SelectedValue = 0;
            cmbNomPaciente.SelectedValue = 0;
            txtNumOrden.Text = "";
            txtLaboratorio.Text = "";
            txtBD.Text = "";
            txtBI.Text = "";
            txtPD.Text = "";
            txtPI.Text = "";
            txtHoraEntrega.Text = "";
            txtColor.Text = "";
            //txtEstado.Text = "";
            btnGuardar.Text = string.Empty;
            btnGuardar.Text = "Ingresar Orden";
            CalendarCreacion.SelectionStart = DateTime.Today;
            CalendarCreacion.SelectionEnd = DateTime.Today;
            calendarEntrega.SelectionStart = DateTime.Today;
            calendarEntrega.SelectionEnd = DateTime.Today;
        }

        private void GrillaOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 16)
            {
                modificarOrden(e);
            } 
        }

        private void modificarOrden(DataGridViewCellEventArgs e)
        {
            Ordendelaboratorio orden = GrillaOrden.Rows[e.RowIndex].DataBoundItem as Ordendelaboratorio;
            cmbNomOdontologo.SelectedValue = orden.IdOdontologo;
            cmbNomPaciente.SelectedValue = orden.IdPaciente;
            txtNumOrden.Text = orden.NumeroOrden.ToString();
            txtLaboratorio.Text = orden.Clinica;
            txtBD.Text = orden.Bd;
            txtBI.Text = orden.Bi;
            txtPD.Text = orden.Pd;
            txtPI.Text = orden.Pi;
            txtHoraEntrega.Text = orden.HoraEntrega;
            txtColor.Text = orden.Color;
            //txtEstado.Text = orden.Estadodeorden.ToString();
            CalendarCreacion.SelectionStart = orden.FechaCreacion;
            CalendarCreacion.SelectionEnd = orden.FechaCreacion;
            calendarEntrega.SelectionStart = orden.FechaEntrega;
            calendarEntrega.SelectionEnd = orden.FechaEntrega;
            lblIdOrden.Text = orden.IdOrdenLaboratorio.ToString();
            btnGuardar.Text = string.Empty;
            btnGuardar.Text = "Guardar Cambios";
            
        }

        private void frmAdministracionOrdenLab_Load(object sender, EventArgs e)
        {
            listaOrden = clienteOrden.ListarOrdenLaboratorio();
            List<Persona> listaPaciente = clienteOrden.listaPacientes();
            List<Persona> listaOdontologo = clienteOrden.listaOdontologo();
            cmbNomPaciente.DataSource = listaPaciente;
            cmbNomOdontologo.DataSource = listaOdontologo;
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoOrdenLaboratorio));
            GrillaOrden.DataSource = listaOrden;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Guardar Cambios")
            {
                modificarOrdenGuardar();
            }
            else if (btnGuardar.Text == "Ingresar Orden")
            {
                GuardarOrden();
            }
        }

        private void btnAdminCli_Click(object sender, EventArgs e)
        {
            this.limpiarFormulario();
        }

        private void txtNumOrden_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsNumero(txtNumOrden))
            {
                errorProvider1.SetError(txtNumOrden, String.Empty);
                txtNumOrden.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtNumOrden, "Los identificadores deben ser numéricos");
                txtNumOrden.BackColor = Color.MistyRose;
            }
        }

        private void txtLaboratorio_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsSoloafanumerico(txtLaboratorio))
            {
                errorProvider1.SetError(txtLaboratorio, String.Empty);
                txtLaboratorio.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtLaboratorio, "El contenido debe ser alfa numérico");
                txtLaboratorio.BackColor = Color.MistyRose;
            }
        }

        private void txtBD_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsNumero(txtBD))
            {
                errorProvider1.SetError(txtBD, String.Empty);
                txtBD.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtBD, "Los identificadores deben ser numéricos");
                txtBD.BackColor = Color.MistyRose;
            }
        }

        private void txtBI_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsNumero(txtBI))
            {
                errorProvider1.SetError(txtBI, String.Empty);
                txtBI.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtBI, "Los identificadores deben ser numéricos");
                txtBI.BackColor = Color.MistyRose;
            }
        }

        private void txtPD_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsNumero(txtPD))
            {
                errorProvider1.SetError(txtPD, String.Empty);
                txtPD.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtPD, "Los identificadores deben ser numéricos");
                txtPD.BackColor = Color.MistyRose;
            }
        }

        private void txtPI_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsNumero(txtPI))
            {
                errorProvider1.SetError(txtPI, String.Empty);
                txtPI.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtPI, "Los identificadores deben ser numéricos");
                txtPI.BackColor = Color.MistyRose;
            }
        }

        private void txtHoraEntrega_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsHora(txtHoraEntrega))
            {
                errorProvider1.SetError(txtHoraEntrega, String.Empty);
                txtHoraEntrega.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtHoraEntrega, "El Formato de hora debe ser el siguiente hh:mm");
                txtHoraEntrega.BackColor = Color.MistyRose;
            }
        }

        private void txtColor_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsSoloTexto(txtColor))
            {
                errorProvider1.SetError(txtColor, String.Empty);
                txtColor.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtColor, "El contenido ingresado debe ser alfa numérico");
                txtColor.BackColor = Color.MistyRose;
            }
        }
    }
}
