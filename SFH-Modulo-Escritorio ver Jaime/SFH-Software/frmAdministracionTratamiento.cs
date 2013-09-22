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
    public partial class frmAdministracionTratamiento : Form
    {
        List<Tratamientodental> listaTratamiento = new List<Tratamientodental>();
        ClientWsTratamientoAbono clienteTratamiento =  new ClientWsTratamientoAbono();
        int idFicha;
        public frmAdministracionTratamiento(int idFicha)
        {
            InitializeComponent();
            this.idFicha = idFicha;
            this.Load+=frmAdministracionTratamiento_Load;
        }

        private void frmAdministracionTratamiento_Load(object sender, EventArgs e)
        {
            listaTratamiento = clienteTratamiento.ListarTratamientoIdFicha(idFicha);
            GridTratamiento.DataSource = listaTratamiento;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardarTratamiento_Click(object sender, EventArgs e)
        {
            if (btnGuardarTratamiento.Text.Trim() == "Guardar")
            {
                Tratamientodental tratamiento = new Tratamientodental();
                tratamiento.FechaCreacion = calendarCreacion.SelectionStart;
                tratamiento.Tratamiento = txtDescTratamiento.Text.ToString();
                tratamiento.ValorTotal = Convert.ToInt32(txtValorTotal.Text.ToString());
                tratamiento.FechaSeguimiento = CalendarSeguimiento.SelectionStart;
                tratamiento.IdFicha = 3;
                tratamiento.IdTratamientoDental = clienteTratamiento.InsertarTratamiento(tratamiento);
                listaTratamiento.Add(tratamiento);

                GridTratamiento.DataSource = null;
                GridTratamiento.DataSource = listaTratamiento;
            }
            else if (btnGuardarTratamiento.Text.Trim() == "Modificar")
            {
                Tratamientodental tratamiento = new Tratamientodental();
                tratamiento.FechaCreacion = calendarCreacion.SelectionStart;
                tratamiento.Tratamiento = txtDescTratamiento.Text.ToString();
                tratamiento.ValorTotal = Convert.ToInt32(txtValorTotal.Text.ToString());
                tratamiento.FechaSeguimiento = CalendarSeguimiento.SelectionStart;
                tratamiento.IdFicha = 3;
                tratamiento.IdTratamientoDental = Convert.ToInt32(lblIdTratamiento.Text.ToString());
                if (clienteTratamiento.ModificarTratamiento(tratamiento) == "Modificado")
                {
                    txtDescTratamiento.Text = "";
                    txtValorTotal.Text = "";
                    lblIdTratamiento.Text = "";
                    btnGuardarTratamiento.Text = "Guardar";
                    for (int i = 0; i < listaTratamiento.Count;i++ )
                    {
                        if (listaTratamiento.ElementAt(i).IdTratamientoDental == tratamiento.IdTratamientoDental)
                        {
                            listaTratamiento.RemoveAt(i);
                            listaTratamiento.Insert(i,tratamiento);
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hubo un Error, Intentelo mas tarde");
                }
               
                GridTratamiento.DataSource = null;
                GridTratamiento.DataSource = listaTratamiento;
            }

        }

        private void GridTratamiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Tratamientodental tratamiento = GridTratamiento.Rows[e.RowIndex].DataBoundItem as Tratamientodental;
            txtDescTratamiento.Text = tratamiento.Tratamiento;
            txtValorTotal.Text = tratamiento.ValorTotal.ToString();
            calendarCreacion.SelectionStart = tratamiento.FechaCreacion;
            CalendarSeguimiento.SelectionStart = tratamiento.FechaSeguimiento; 
            calendarCreacion.SelectionEnd = tratamiento.FechaCreacion;
            CalendarSeguimiento.SelectionEnd = tratamiento.FechaSeguimiento;
            cmbFicha.Text = tratamiento.IdFicha.ToString();
            lblIdTratamiento.Text = tratamiento.IdTratamientoDental.ToString();
            btnGuardarTratamiento.Text = "Modificar";
        }
    }
}
