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
    public partial class frmLogin : Form
    {
        #region Campos
        ClientWsLogin login = new ClientWsLogin();
        #endregion
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
           Session session = new Session();
            if (!txtuser.Text.ToString().Equals(""))
            {
                if (!txtdv.Text.ToString().Equals(""))
                {
                    if (!txtpass.Text.ToString().Equals(""))
                    {
                        session = this.login.RecuperarSession(txtuser.Text.ToString(),txtpass.Text.ToString());
                        if (session.Secdat.Equals(true)){

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
                        MessageBox.Show("No se ha podido iniciar la sesión.Para ingresar al sistema debe digitar su contraseña.", "SFH Administración de Clínica - Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtuser.Focus();
                        Refresh();
                    }
                }
                else {
                    MessageBox.Show("No se ha podido iniciar la sesión.Debe ingresar su digito verificador.", "SFH Administración de Clínica - Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtdv.Focus();
                    Refresh();
                }
            }
            else
            {
                MessageBox.Show("No se ha podido iniciar la sesión. Para ingresar al sistema debe digitar su run.", "SFH Administración de Clínica - Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
