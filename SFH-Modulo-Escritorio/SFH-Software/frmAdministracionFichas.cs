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
    public partial class frmAdministracionFichas : Form
    {
        #region Campos
        ClientWsFichaPresupuesto client_fichas = new ClientWsFichaPresupuesto();
        List<Fichadental> result = new List<Fichadental>();
        #endregion

        #region Metodos
        private void PoblarComboEstado() {
            this.cmbxestado.Items.Clear();
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.DESHABILITADO), "Deshabilitado");
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.HABILITADO), "Habilitado");

            //this.cmbxestado.
        }
        private void PoblarComboBusqueda() {
            this.cmbxBuscar.Items.Clear();
            this.cmbxBuscar.Items.Insert(0, "Seleccione tipo de búsqueda");
            this.cmbxBuscar.Items.Insert(1, "Numero de ficha");
            this.cmbxBuscar.Items.Insert(2, "Numero de Persona");
            this.cmbxBuscar.SelectedItem = "Seleccione tipo de búsqueda";
        }
        private void PoblarComboPacientes() { 
        //listar paciente persona
        }
        private void PoblarComboOdontologo() { 
        //listar odontologo persona
        }


        #endregion

        public frmAdministracionFichas()
        {
            InitializeComponent();
        }

      
        private void frmAdministracionFichas_Load(object sender, EventArgs e)
        {
           //Cargar Combox 
            this.PoblarComboBusqueda();
            this.PoblarComboEstado();

           //Cargar Grillas 
            dataGridView1.DataSource = this.client_fichas.ListarFichas();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            switch (this.cmbxBuscar.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("Debes seleccionar una opción de búsqueda", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.result = this.client_fichas.BuscarFichasPorId(int.Parse(txtBuscar.Text.ToString()));
                  
                    if (result.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dataGridView1.DataSource = this.result;
                    }
                    break;
                case 2:
                    MessageBox.Show("El sistema sfh está realizando su búsqueda", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.result = this.client_fichas.BuscarFichasPorIdPersona(int.Parse(txtBuscar.Text.ToString()));
                  
                    if (result.Count.Equals(0))
                    {
                        MessageBox.Show("Esta búsqueda no ha arrojado resultados", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dataGridView1.DataSource = this.result;
                    }
                    break;
            }
        }

       

       

     
      
    }
}
