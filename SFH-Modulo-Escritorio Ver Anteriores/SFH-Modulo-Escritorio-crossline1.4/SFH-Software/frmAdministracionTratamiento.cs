﻿using System;
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
    public partial class frmAdministracionTratamiento : Form
    {
        List<Tratamientodental> listaTratamiento = new List<Tratamientodental>();
        ClientWsTratamientoAbono clienteTratamiento =  new ClientWsTratamientoAbono();
        ClientWsFichaPresupuesto clienteFicha = new ClientWsFichaPresupuesto();
        int idFicha = 3;
        frmMenu menu;
        Validaciones validaciones = new Validaciones();
        bool valido = false;
        public frmAdministracionTratamiento(int idFicha)
        {
            InitializeComponent();
            this.idFicha = idFicha;
        }
        public frmAdministracionTratamiento(frmMenu menu)
        {
            InitializeComponent();
            this.menu = menu;
        }
        public void CargarCmbxFicha() {
            this.cmbFicha.DataSource = this.clienteFicha.ListarFichas();
            this.cmbFicha.ValueMember = "IdFicha";
            this.cmbFicha.DisplayMember = "NombrePaciente";
        }
        public void Limpiar() {
            txtDescTratamiento.Text = "";
            txtValorTotal.Text = "";
            lblIdTratamiento.Text = "";
            btnGuardarTratamiento.Text = string.Empty;
            btnGuardarTratamiento.Text = "Ingresar Tratamiento";
            calendarCreacion.SelectionStart = DateTime.Today;
            CalendarSeguimiento.SelectionStart = DateTime.Today;
            calendarCreacion.SelectionEnd = DateTime.Today;
            CalendarSeguimiento.SelectionEnd = DateTime.Today;
        }

        private void btnGuardarTratamiento_Click(object sender, EventArgs e)
        {
            if (btnGuardarTratamiento.Text.Trim() == "Ingresar Tratamiento")
            {
                try
                {
                    if (this.valido)
                    {
                        Tratamientodental tratamiento = new Tratamientodental();
                        tratamiento.FechaCreacion = calendarCreacion.SelectionStart;
                        tratamiento.Tratamiento = txtDescTratamiento.Text.ToString();
                        tratamiento.ValorTotal = Convert.ToInt32(txtValorTotal.Text.ToString());
                        tratamiento.FechaSeguimiento = CalendarSeguimiento.SelectionStart;
                        tratamiento.IdFicha = Convert.ToInt32(cmbFicha.SelectedValue.ToString());
                        tratamiento.IdTratamientoDental = clienteTratamiento.InsertarTratamiento(tratamiento);
                        if (tratamiento.IdTratamientoDental != 0)
                        {
                            listaTratamiento.Add(tratamiento);
                            listaTratamiento = clienteTratamiento.ListarTratamientoIdFicha(Convert.ToInt32(cmbFicha.SelectedValue.ToString()));
                            GridTratamiento.DataSource = null;
                            GridTratamiento.DataSource = listaTratamiento;
                            MessageBox.Show("Tratamiento ingresado correctamente.", "SFH Administración de Clínica - Administración de Tratamiento Dental", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Tratamiento Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Tratamiento Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnGuardarTratamiento.Text.Trim() == "Guardar Cambios")
            {
                try
                {
                    if (this.valido)
                    {
                        Tratamientodental tratamiento = new Tratamientodental();
                        tratamiento.FechaCreacion = calendarCreacion.SelectionStart;
                        tratamiento.Tratamiento = txtDescTratamiento.Text.ToString();
                        tratamiento.ValorTotal = Convert.ToInt32(txtValorTotal.Text.ToString());
                        tratamiento.FechaSeguimiento = CalendarSeguimiento.SelectionStart;
                        tratamiento.IdFicha = Convert.ToInt32(cmbFicha.SelectedValue.ToString());
                        tratamiento.TotalAbono = Convert.ToInt32(lblAbono.Text.ToString());
                        tratamiento.IdTratamientoDental = Convert.ToInt32(lblIdTratamiento.Text.ToString());

                        if (clienteTratamiento.ModificarTratamiento(tratamiento) == "Modificado")
                        {
                            txtDescTratamiento.Text = "";
                            txtValorTotal.Text = "";
                            lblIdTratamiento.Text = "";
                            btnGuardarTratamiento.Text = string.Empty;
                            btnGuardarTratamiento.Text = "Ingresar Tratamiento";
                            MessageBox.Show("Tratamiento modificado correctamente.", "SFH Administración de Clínica - Administración de Tratamiento Dental", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int i = 0; i < listaTratamiento.Count; i++)
                            {
                                if (listaTratamiento.ElementAt(i).IdTratamientoDental == tratamiento.IdTratamientoDental)
                                {
                                    listaTratamiento.RemoveAt(i);
                                    listaTratamiento.Insert(i, tratamiento);
                                    break;
                                }
                            }
                            listaTratamiento = clienteTratamiento.ListarTratamientoIdFicha(Convert.ToInt32(cmbFicha.SelectedValue.ToString()));
                            GridTratamiento.DataSource = null;
                            GridTratamiento.DataSource = listaTratamiento;
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Tratamiento Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Tratamiento Dental", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void GridTratamiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
            if (e.ColumnIndex == 7)
            {
                ModificarTratamiento(e);
                
            }
            if (e.ColumnIndex == 8)
            {
                Tratamientodental tratamiento = GridTratamiento.Rows[e.RowIndex].DataBoundItem as Tratamientodental;
                menu.MostrarForm("Administración Abonos", new frmAbonos(tratamiento.IdTratamientoDental));
            }
        }

        private void ModificarTratamiento(DataGridViewCellEventArgs e)
        {
            Tratamientodental tratamiento = GridTratamiento.Rows[e.RowIndex].DataBoundItem as Tratamientodental;
            cmbFicha.SelectedValue = tratamiento.IdFicha; 
            txtDescTratamiento.Text = tratamiento.Tratamiento;
            txtValorTotal.Text = tratamiento.ValorTotal.ToString();
            calendarCreacion.SelectionStart = tratamiento.FechaCreacion;
            CalendarSeguimiento.SelectionStart = tratamiento.FechaSeguimiento;
            calendarCreacion.SelectionEnd = tratamiento.FechaCreacion;
            CalendarSeguimiento.SelectionEnd = tratamiento.FechaSeguimiento;
            cmbFicha.Text = tratamiento.IdFicha.ToString();
            lblIdTratamiento.Text = tratamiento.IdTratamientoDental.ToString();
            lblAbono.Text = tratamiento.TotalAbono.ToString();
            btnGuardarTratamiento.Text = string.Empty;
            btnGuardarTratamiento.Text = "Guardar Cambios";
        }

        private void frmAdministracionTratamiento_Load(object sender, EventArgs e)
        {
            this.CargarCmbxFicha();
            listaTratamiento = this.clienteTratamiento.ListarTratamientoIdFicha(idFicha);
            GridTratamiento.DataSource = listaTratamiento;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
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