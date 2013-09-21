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
        #endregion

        #region Metodos
        private void PoblarComboEstado() {
            this.cmbxestado.Items.Clear();
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.DESHABILITADO), "Deshabilitado");
            this.cmbxestado.Items.Insert(Convert.ToInt32(EstadoPersona.HABILITADO), "Habilitado");
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

       

     
      
    }
}
