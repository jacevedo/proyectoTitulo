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
    public partial class frmAdministracionListasDePrecios : Form
    {
        #region Campos
        ClientWsPreciosInsumos client_precio = new ClientWsPreciosInsumos();
        List<Listadeprecio> result = new List<Listadeprecio>();
        private int idprecio;
        Validaciones validaciones = new Validaciones();
        public int Idprecio
        {
            get { return idprecio; }
            set { idprecio = value; }
        }
        #endregion
        #region Metodos
        private bool validarformulario()
        {

            if (validaciones.EsSoloafanumerico(txtNom) == true & validaciones.EsNumero(txtvalorneto) == true){
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        public frmAdministracionListasDePrecios()
        {
            InitializeComponent();
        }

        private void LimpiarControles() {
            this.txtNom.Text = string.Empty;
            this.txtvalorneto.Text = string.Empty;
            btnNuevo.Text = "Ingresar Precio";
        }
        private void frmAdministracionListasDePrecios_Load(object sender, EventArgs e)
        {
            //Cargar Grillas 
            this.dataGridPrecio.DataSource = this.client_precio.ListarPrecios();
            btnNuevo.Text = "Ingresar Precio";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.validaciones.EsSoloafanumerico(txtBuscar) == true)
            {
                MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    this.result = this.client_precio.BuscarPreciosPorNombre(txtBuscar.Text.ToString());

                    if (result.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dataGridPrecio.DataSource = this.result;
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridPrecio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.ModidificarPrecio(e);
                    break;
                case 1:
                    Listadeprecio listaprecio = dataGridPrecio.Rows[e.RowIndex].DataBoundItem as Listadeprecio;
                    if (MessageBox.Show("¿Desea eliminar el precio seleccionado?", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        client_precio.EliminarPrecio(listaprecio.IdPrecios);
                        this.dataGridPrecio.DataSource = this.client_precio.ListarPrecios();
                        MessageBox.Show("Precio eliminado correctamente.", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }
        private void ModidificarPrecio(DataGridViewCellEventArgs e)
        {
            Listadeprecio listaprecio = dataGridPrecio.Rows[e.RowIndex].DataBoundItem as Listadeprecio;
            this.Idprecio = listaprecio.IdPrecios;
            this.txtNom.Text = listaprecio.Comentario.ToString();
            this.txtvalorneto.Text = listaprecio.ValorNeto.ToString();
            btnNuevo.Text = "Guardar Cambios";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Precio")
            {
                try
                {
                    if (this.validarformulario())
                    {
                        String resultadoI = string.Empty;
                        Listadeprecio precio = new Listadeprecio();
                        precio.Comentario = txtNom.Text.ToString();
                        precio.ValorNeto = txtvalorneto.Text.ToString();

                        resultadoI = client_precio.InsertarPrecio(precio);
                        if (resultadoI != string.Empty)
                        {
                            dataGridPrecio.DataSource = client_precio.ListarPrecios();
                            this.LimpiarControles();
                            MessageBox.Show("Precio insertado correctamente.", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                try
                {
                    if (this.validarformulario())
                    {
                        string resultadoM = string.Empty;
                        Listadeprecio precio = new Listadeprecio();
                        precio.IdPrecios = this.Idprecio;
                        precio.Comentario = txtNom.Text.ToString();
                        precio.ValorNeto = txtvalorneto.Text.ToString();
                        resultadoM = client_precio.ModificarPrecio(precio);
                        if (resultadoM != string.Empty)
                        {
                            dataGridPrecio.DataSource = client_precio.ListarPrecios();
                            this.LimpiarControles();
                            btnNuevo.Text = "Ingresar Ficha";
                            MessageBox.Show("Precio modificado correctamente.", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             }
        }

        private void txtNom_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsSoloafanumerico(txtNom))
            {
                errorProvider1.SetError(txtNom, String.Empty);
                txtNom.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtNom, "El contenido debe ser alfa numérico");
                txtNom.BackColor = Color.MistyRose;
            }
        }

        private void txtvalorneto_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsNumero(txtvalorneto))
            {
                errorProvider1.SetError(txtvalorneto, String.Empty);
                txtvalorneto.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtvalorneto, "Debe ingresar un número entero");
                txtvalorneto.BackColor = Color.MistyRose;
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsSoloafanumerico(txtBuscar))
            {
                errorProvider1.SetError(txtBuscar, String.Empty);
                txtBuscar.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtBuscar, "El contenido debe ser alfa numérico");
                txtBuscar.BackColor = Color.MistyRose;
            }
        }
    }
}
