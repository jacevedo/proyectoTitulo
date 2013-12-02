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

namespace SFH_Software
{
    public partial class frmAdministracionTratamiento : Form
    {
        List<Tratamientodental> listaTratamiento = new List<Tratamientodental>();
        ClientWsTratamientoAbono clienteTratamiento =  new ClientWsTratamientoAbono();
        int idFicha = 3;
        frmMenu menu;
        public frmAdministracionTratamiento(int idFicha)
        {
            InitializeComponent();
            this.idFicha = idFicha;
            this.Load+=frmAdministracionTratamiento_Load;
        }
        public frmAdministracionTratamiento(frmMenu menu)
        {
            InitializeComponent();
            
            this.Load += frmAdministracionTratamiento_Load;
            this.menu = menu;
        }

        private void frmAdministracionTratamiento_Load(object sender, EventArgs e)
        {
            listaTratamiento = this.clienteTratamiento.ListarTratamientoIdFicha(idFicha);
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
                tratamiento.TotalAbono = Convert.ToInt32(lblAbono.Text.ToString());
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
            if (e.ColumnIndex == 7)
            {
                ModificarTratamiento(e);
                
            }
            if (e.ColumnIndex == 8)
            {
                Tratamientodental tratamiento = GridTratamiento.Rows[e.RowIndex].DataBoundItem as Tratamientodental;
                //frmAbonos abono = new frmAbonos(tratamiento.IdTratamientoDental);
                //abono.ShowDialog();
                menu.MostrarForm("Administración de abonos monetarios", new frmAbonos(tratamiento.IdTratamientoDental));
            }
        }

        private void ModificarTratamiento(DataGridViewCellEventArgs e)
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
            lblAbono.Text = tratamiento.TotalAbono.ToString();
            btnGuardarTratamiento.Text = "Modificar";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            listaTratamiento = clienteTratamiento.ListarTratamientoIdFicha(idFicha);
            GridTratamiento.DataSource = null;
            GridTratamiento.DataSource = listaTratamiento;
        }
    }
}
