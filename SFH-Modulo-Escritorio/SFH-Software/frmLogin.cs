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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu men = new frmMenu();
            men.ShowDialog();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
