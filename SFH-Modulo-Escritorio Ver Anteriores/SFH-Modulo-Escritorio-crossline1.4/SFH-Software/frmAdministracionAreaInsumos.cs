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
    public partial class frmAdministracionAreaInsumos : Form
    {
        #region Campos
        ClientWsAreaInsumoListas client_areainsumo = new ClientWsAreaInsumoListas();
        List<Areainsumo> result = new List<Areainsumo>();
        private int id_area_insumo;
        frmMenu menu;
        Validaciones validaciones = new Validaciones();
        public int Id_area_insumo
        {
            get { return id_area_insumo; }
            set { id_area_insumo = value; }
        }
       
        #endregion
        #region Metodos 
        private void LimpiarControles() {
            this.txtNom.Text = string.Empty;
            this.txtdes.Text = string.Empty;
            this.btnNuevo.Text = "Ingresar Área Insumos";
        }
        #endregion
        public frmAdministracionAreaInsumos(frmMenu menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

        private void frmAdministracionAreaInsumos_Load(object sender, EventArgs e)
        {
            //Cargar Grillas 
            this.dataGridAreaInsumo.DataSource = this.client_areainsumo.ListarAreaInsumos();
            btnNuevo.Text = "Ingresar Área Insumos";
        }


        private void dataGridAreaInsumo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.ModidificarAreaInsumo(e);
                    break;
                case 1:
                    Areainsumo areainsumo = dataGridAreaInsumo.Rows[e.RowIndex].DataBoundItem as Areainsumo;
                    if (MessageBox.Show("¿Desea eliminar el área seleccionada?", "SFH Administración de Clínica - Administración de Área Insumos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        
                        this.client_areainsumo.EliminarAreaInsumo(areainsumo.IdAreaInsumo);
                        this.dataGridAreaInsumo.DataSource = this.client_areainsumo.ListarAreaInsumos();
                        MessageBox.Show("Área eliminada correctamente.", "SFH Administración de Clínica - Administración de Área Insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2:
                       frmGastos gastos = new frmGastos(this.menu);
                       this.menu.MostrarForm("Administración de Gastos", gastos);
                    break;
            }
        }
        private void ModidificarAreaInsumo(DataGridViewCellEventArgs e)
        {
            Areainsumo areainsumo = dataGridAreaInsumo.Rows[e.RowIndex].DataBoundItem as Areainsumo;
            this.Id_area_insumo = areainsumo.IdAreaInsumo;
            this.txtNom.Text = areainsumo.NombreArea.ToString();
            this.txtdes.Text = areainsumo.DescripcionArea.ToString();
            btnNuevo.Text = "Guardar Cambios";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Área Insumos")
            {
                try
                {
                    if (this.validaciones.EsSoloTexto(txtNom) == true)
                    {
                        String resultadoI = string.Empty;
                        Areainsumo areainsumo = new Areainsumo();
                        areainsumo.NombreArea = txtNom.Text.ToString();
                        areainsumo.DescripcionArea = txtdes.Text.ToString();
                        if (areainsumo.NombreArea == string.Empty || areainsumo.DescripcionArea == string.Empty)
                        {
                            MessageBox.Show("Debe ingresar todos campos.", "SFH Administración de Clínica - Administración de Área Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            resultadoI = this.client_areainsumo.InsertarAreaInsumos(areainsumo);
                            if (resultadoI != string.Empty)
                            {
                                this.dataGridAreaInsumo.DataSource = this.client_areainsumo.ListarAreaInsumos();
                                this.LimpiarControles();
                                MessageBox.Show("Área insumos insertada correctamente.", "SFH Administración de Clínica - Administración de Área Insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Área Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Área Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                try
                {
                    if (this.validaciones.EsSoloTexto(txtNom))
                    {
                        String resultadoM = string.Empty;
                        Areainsumo areainsumo = new Areainsumo();
                        areainsumo.IdAreaInsumo = this.Id_area_insumo;
                        areainsumo.NombreArea = txtNom.Text.ToString();
                        areainsumo.DescripcionArea = txtdes.Text.ToString();
                        resultadoM = this.client_areainsumo.ModificarAreaInsumo(areainsumo);
                        if (resultadoM != string.Empty)
                        {
                            this.dataGridAreaInsumo.DataSource = this.client_areainsumo.ListarAreaInsumos();
                            this.LimpiarControles();
                            btnNuevo.Text = "Ingresar Área insumos";
                            MessageBox.Show("Área insumos modificada correctamente.", "SFH Administración de Clínica - Administración de Área Insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Área Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Se produjo un error, vuelva a intentarlo.", "SFH Administración de Clínica - Administración de Área Insumos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        private void txtNom_KeyUp(object sender, KeyEventArgs e)
        {
            if (validaciones.EsSoloTexto(txtNom))
            {
                errorProvider1.SetError(txtNom, String.Empty);
                txtNom.BackColor = Color.Honeydew;
            }
            else
            {
                errorProvider1.SetError(txtNom, "El nombre no puede contener números y caracteres especiales");
                txtNom.BackColor = Color.MistyRose;
            }
        }
    }
}
