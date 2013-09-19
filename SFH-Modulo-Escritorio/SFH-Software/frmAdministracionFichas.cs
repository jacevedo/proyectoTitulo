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


        public frmAdministracionFichas()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAdministracionFichas_Load(object sender, EventArgs e)
        {
           // data
            //= this.client_fichas.ListarFichas();
            dataGridView1.DataSource = this.client_fichas.ListarFichas();
        }
      
    }
}
