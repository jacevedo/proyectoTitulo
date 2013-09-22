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
    public partial class frmAbonos : Form
    {
        int idTratamientoDental;
        ClientWsTratamientoAbono wsAbono = new ClientWsTratamientoAbono();
        List<Abono> listaAbono = new List<Abono>();
        public frmAbonos(int idTratamientoDental)
        {
            InitializeComponent();
            this.idTratamientoDental = idTratamientoDental;
            this.Load += frmAbonos_Load;
        }

        void frmAbonos_Load(object sender, EventArgs e)
        {
            listaAbono =  wsAbono.ListarAbonoPorTratamiento(idTratamientoDental);
            GrillaAbonos.DataSource = listaAbono;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarAbono_Click(object sender, EventArgs e)
        {
            if (btnGuardarAbono.Text.ToString() == "Guardar")
            {
                Abono abono = new Abono();
                abono.IdTratamientoDental = idTratamientoDental;
                abono.Monto = Convert.ToInt32(txtMonto.Text.ToString());
                abono.FechaAbono = calendarAbono.SelectionStart;
                abono.IdAbono = wsAbono.InsertarAbono(abono);
                listaAbono.Add(abono);

                GrillaAbonos.DataSource = null;
                GrillaAbonos.DataSource = listaAbono;
            }
            else if (btnGuardarAbono.Text.ToString() == "Modificar")
            {
                
                    Abono abono = new Abono();
                    abono.IdTratamientoDental = Convert.ToInt32(lblIdTratamiento.Text.ToString());
                    abono.Monto = Convert.ToInt32(txtMonto.Text.ToString());
                    abono.FechaAbono = calendarAbono.SelectionStart;
                    abono.IdAbono = Convert.ToInt32(lblIdAbono.Text.ToString());

                    if (wsAbono.ModificarAbono(abono) == "Modificado")
                    {
                        for (int i = 0; i < listaAbono.Count; i++)
                        {
                            if (listaAbono.ElementAt(i).IdAbono == abono.IdAbono)
                            {
                                listaAbono.RemoveAt(i);
                                listaAbono.Insert(i, abono);
                                break;
                            }
                        }
                        GrillaAbonos.DataSource = null;
                        GrillaAbonos.DataSource = listaAbono;
                    }
                    else
                    {
                        MessageBox.Show("hubo un error al modificar el Abono, intente mas tarde");
                    }
                    btnGuardarAbono.Text = "Guardar";
            }
        }

        private void GrillaAbonos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                ModificarAbono(e);
            } 
            else if (e.ColumnIndex == 5)
            {
                Abono abono = GrillaAbonos.Rows[e.RowIndex].DataBoundItem as Abono;
                if (MessageBox.Show("¿Deseas eliminar este abono?", "Eliminar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (wsAbono.EliminarAbono(abono) != "Eliminado")
                    {
                        MessageBox.Show("Hubo un error");
                    }
                    else
                    {
                        for (int i = 0; i < listaAbono.Count; i++)
                        {
                            if (listaAbono.ElementAt(i).IdAbono == abono.IdAbono)
                            {
                                listaAbono.RemoveAt(i);
                                GrillaAbonos.DataSource = null;
                                GrillaAbonos.DataSource = listaAbono;
                            }
                        }
                    }
                }
                else
                {
                    // user clicked no
                }

            }
        }

        private void ModificarAbono(DataGridViewCellEventArgs e)
        {
            Abono abono = GrillaAbonos.Rows[e.RowIndex].DataBoundItem as Abono;
            txtMonto.Text = abono.Monto.ToString();
            calendarAbono.SelectionStart = abono.FechaAbono;
            calendarAbono.SelectionEnd = abono.FechaAbono;
            lblIdAbono.Text = abono.IdAbono.ToString();
            lblIdTratamiento.Text = abono.IdTratamientoDental.ToString();
            btnGuardarAbono.Text = "Modificar";
        }

    }
}
