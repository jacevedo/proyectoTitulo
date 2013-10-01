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

        public int Idprecio
        {
            get { return idprecio; }
            set { idprecio = value; }
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
            MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridPrecio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.ModidificarPrecio(e);
                    break;
                case 1:
                    Listadeprecio listaprecio = dataGridPrecio.Rows[e.RowIndex].DataBoundItem as Listadeprecio;
                    if (MessageBox.Show("¿Desea eliminar este precio?", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        client_precio.EliminarPrecio(listaprecio.IdPrecios);
                        this.dataGridPrecio.DataSource = this.client_precio.ListarPrecios();
                        MessageBox.Show("Precio eliminado del sistema", "SFH Administración de Clínica - Administración de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Precio")
            {
                Listadeprecio precio = new Listadeprecio();
                precio.Comentario = txtNom.Text.ToString();
                precio.ValorNeto = txtvalorneto.Text.ToString();
                client_precio.InsertarPrecio(precio);
                dataGridPrecio.DataSource = client_precio.ListarPrecios();
                this.LimpiarControles();
                MessageBox.Show("Precio insertada satisfactoriamente", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                Listadeprecio precio = new Listadeprecio();
                precio.IdPrecios = this.Idprecio;
                precio.Comentario = txtNom.Text.ToString();
                precio.ValorNeto = txtvalorneto.Text.ToString();
                client_precio.ModificarPrecio(precio);
                dataGridPrecio.DataSource = client_precio.ListarPrecios();
                this.LimpiarControles();
                btnNuevo.Text = "Ingresar Ficha";
                MessageBox.Show("Precio modificado satisfactoriamente", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
             }
        }

        
       

    }
}
