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
            if (txtuser.Text.ToString().Equals("admin"))
            {
               
                if (txtpass.Text.ToString().Equals("admin"))
                {
                    this.Hide();
                    frmMenu men = new frmMenu();
                    men.ShowDialog();
                }
                else {
                    MessageBox.Show("No se ha podido iniciar la sesión. No se han proporcionado credenciales de autentificación válidas.", "SFH Administración de Clínica - Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtuser.Focus();
                    Refresh();
                }
            }
            else
            {
                MessageBox.Show("No se ha podido iniciar la sesión. No se han proporcionado credenciales de autentificación válidas.", "SFH Administración de Clínica - Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtuser.Focus();
                Refresh();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
