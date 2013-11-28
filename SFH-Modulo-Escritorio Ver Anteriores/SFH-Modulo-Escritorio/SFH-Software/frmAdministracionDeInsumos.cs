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
    public partial class frmAdministracionDeInsumos : Form
    {
        #region Campos
        ClientWsPreciosInsumos client_precio = new ClientWsPreciosInsumos();
        ClientWsGastos client_gastos = new ClientWsGastos();
        ClientWsAreaInsumoListas client_areainsumo = new ClientWsAreaInsumoListas();
        List<Insumos> result = new List<Insumos>();
        frmMenu menu;
        private int id_insumo;

        public int Idinsumo
        {
            get { return id_insumo; }
            set { id_insumo = value; }
        }
        #endregion

        #region Metodos 
        private void PoblarComboBusqueda()
        {

            this.cmbxBuscar.Items.Clear();
            this.cmbxBuscar.Items.Insert(0, "Seleccione tipo de búsqueda");
            this.cmbxBuscar.Items.Insert(1, "Numero de insumo");
            this.cmbxBuscar.Items.Insert(2, "Nombre insumo");
            this.cmbxBuscar.Items.Insert(3, "Area Insumo");
            this.cmbxBuscar.SelectedItem = "Seleccione tipo de búsqueda";
        }

        private void PoblarComboAreaInsumo()
        {
            this.cmbxAreaInsumo.DataSource = client_areainsumo.ListarAreaInsumos();
            this.cmbxAreaInsumo.ValueMember = "IdAreaInsumo";
            this.cmbxAreaInsumo.DisplayMember = "NombreArea";

            this.cmbxAreaInsumos.DataSource = client_areainsumo.ListarAreaInsumos();
            this.cmbxAreaInsumos.ValueMember = "IdAreaInsumo";
            this.cmbxAreaInsumos.DisplayMember = "NombreArea";
        }
        private void PoblarComboCostos() {
            this.cmbxGastos.DataSource = client_areainsumo.ListarGastos();
            this.cmbxGastos.ValueMember = "IdGastos";
            this.cmbxGastos.DisplayMember = "ConceptodeGastos";

            
        }
        private void ModificarInsumos(DataGridViewCellEventArgs e)
        {
            Insumos insumo = dataGridInsumos.Rows[e.RowIndex].DataBoundItem as Insumos;
            this.cmbxAreaInsumo.SelectedValue = insumo.IdAreaInsumo;
            this.cmbxGastos.SelectedValue = insumo.IdGastos_insumo;
            this.Idinsumo = insumo.IdInsumos;
            this.txtnom.Text = insumo.NomInsumos.ToString();
            this.txtcantidad.Text = insumo.Cantidad.ToString();
            this.txtunidadmedida.Text = insumo.UnidadMedida.ToString();
            this.txtDescripcion.Text = insumo.DescripcionInsumo.ToString();
            btnNuevo.Text = "Guardar Cambios";
        }
        private void LimpiarControles() {
            this.txtnom.Text = string.Empty;
            this.txtcantidad.Text = string.Empty;
            this.txtunidadmedida.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            btnNuevo.Text = "Ingresar Insumos";
        }
        #endregion


        public frmAdministracionDeInsumos(frmMenu menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

        private void frmAdministracionDeInsumos_Load(object sender, EventArgs e)
        {
            this.dataGridInsumos.DataSource = this.client_precio.ListarInsumos();
            this.PoblarComboAreaInsumo();
            this.PoblarComboCostos();
            this.PoblarComboBusqueda();
            this.btnNuevo.Text = "Ingresar Insumos";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (this.cmbxBuscar.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("Debes seleccionar una opción de búsqueda", "SFH Administración de Clínica - Administración de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica -  Administración de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.result = this.client_precio.ListarInsumosPorId(int.Parse(txtBuscar.Text.ToString()));

                    if (result.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica -  Administración de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.dataGridInsumos.DataSource = this.result;
                    }
                    break;
                case 2:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.result = this.client_precio.ListarInsumosPorNombre(txtBuscar.Text.ToString());

                    if (result.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.dataGridInsumos.DataSource = this.result;
                    }
                    break;
                case 3:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.result = this.client_precio.ListarInsumosPorIdareaInsumos(Convert.ToInt32(cmbxAreaInsumos.SelectedValue));
                    if (result.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.dataGridInsumos.DataSource = this.result;
                    }
                    break;
            }
        }

        private void dataGridInsumos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    this.ModificarInsumos(e);
                    break;
                case 1:
                  /*  if (MessageBox.Show("¿Desea eliminar este registro de gasto?", "SFH Administración de Clínica - Administración de Gastos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Insumos insumo = dataGridInsumos.Rows[e.RowIndex].DataBoundItem as Insumos;
                        this.client_precio.(insumo.IdInsumos);
                        this.dataGridGastos.DataSource = this.client_gastos.ListarGastos();
                        MessageBox.Show("Gasto eliminado del sistema", "SFH Administración de Clínica - Administración de  Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                    break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Insumos")
            {
                Insumos insumo = new Insumos();
                insumo.IdAreaInsumo = Convert.ToInt32(this.cmbxAreaInsumo.SelectedValue);
                insumo.IdGastos_insumo =  Convert.ToInt32(this.cmbxGastos.SelectedValue);
                insumo.NomInsumos = this.txtnom.Text;
                insumo.Cantidad = int.Parse(this.txtcantidad.Text.ToString());
                insumo.UnidadMedida = this.txtunidadmedida.Text.ToString();
                insumo.DescripcionInsumo = this.txtDescripcion.Text.ToString();
                this.client_precio.InsertarInsumo(insumo);
                this.dataGridInsumos.DataSource = this.client_precio.ListarInsumos();
                this.LimpiarControles();
                MessageBox.Show("Insumo registrado satisfactoriamente", "SFH Administración de Clínica - Administración de Área insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                Insumos insumo = new Insumos();
                insumo.IdInsumos = this.Idinsumo;
                insumo.IdAreaInsumo = Convert.ToInt32(this.cmbxAreaInsumo.SelectedValue);
                insumo.IdGastos_insumo = Convert.ToInt32(this.cmbxGastos.SelectedValue);
                insumo.NomInsumos = this.txtnom.Text;
                insumo.Cantidad = int.Parse(this.txtcantidad.Text.ToString());
                insumo.UnidadMedida = this.txtunidadmedida.Text.ToString();
                insumo.DescripcionInsumo = this.txtDescripcion.Text.ToString();
                this.client_precio.ModificarInsumo(insumo);
                this.dataGridInsumos.DataSource = this.client_precio.ListarInsumos();
                this.LimpiarControles();
                MessageBox.Show("Insumo modificado satisfactoriamente", "SFH Administración de Clínica - Administración de Área insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }
       
    }
}