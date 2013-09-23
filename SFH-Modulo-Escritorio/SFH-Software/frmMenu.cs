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
    public partial class frmMenu : Form
    {


        #region Campos
        private static int i;
        string[] pantallas = new string[100];
        frmAcerca acer = new frmAcerca();
        #endregion

        #region Propiedades
        #endregion

        #region Metodos
        public void MostrarForm(string nombre, Form frm)
        {
            //Muetra pantalla si esta repetida
          
            Random r = new Random();
            string key = "";
           try
           {
               for (int x = 0; pantallas.Length > x ; x++)
               {
                   if (pantallas[x] != nombre)
                   {
                       pantallas[x] = nombre;
                       //i += 0;
                       key = "f" + i.ToString();
                       frm.BackColor = this.BackColor;
                       frm.Text = nombre;
                       frm.AutoScroll = true;
                       frm.Name = nombre;
                       tabControlMenu.TabPages.Add(frm);
                       frm.Dock = System.Windows.Forms.DockStyle.Fill;               
                   }
                   break;
               }
               return;  
           }
           catch (Exception ex) { MessageBox.Show(ex.Message, "Problemas al crear pantalla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
          
        }
        #endregion

        public frmMenu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea salir?", "SFH Administración de Clínica - Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcerca acer = new frmAcerca();
            acer.ShowDialog();
        }

        private void cerrarSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea cerrar esta sesión?", "SFH Administración de Clínica - Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Dispose();
                frmLogin log = new frmLogin();
                log.ShowDialog();
            }
        }
        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAdminCli_Click(object sender, EventArgs e)
        {
            treeViewMenu.ExpandAll();
            
        }

        private void treeViewMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text)
            {

                case "Administración de ficha dental":
                    frmAdministracionFichas fich = new frmAdministracionFichas(this);
                    this.MostrarForm(e.Node.Text.ToString(),fich);
                    break;
                case "Administración de presupuesto dental":
                    frmAdministracionPresupuesto presu = new frmAdministracionPresupuesto();
                    this.MostrarForm(e.Node.Text.ToString(), presu);
                    break;
                case "Administración de orden de laboratorio":
                    frmAdministracionOrdenLab orden = new frmAdministracionOrdenLab();
                    this.MostrarForm(e.Node.Text.ToString(), orden);
                    break;
                case "Administración de tratamiento dental":
                    frmAdministracionTratamiento trata = new frmAdministracionTratamiento(this);
                    this.MostrarForm(e.Node.Text.ToString(), trata);
                    break;
                case "Administración de insumos":
                    frmAdministracionDeInsumos insumo = new frmAdministracionDeInsumos();
                    this.MostrarForm(e.Node.Text.ToString(),insumo);
                    break;
                case "Administración de listas de precios por tratamiento":
                    frmAdministracionListasDePrecios listaprecio = new frmAdministracionListasDePrecios();
                    this.MostrarForm(e.Node.Text.ToString(), listaprecio);
                    break;
                case "Administración de usuarios":
                    frmAdministracionUsuarios adminuser = new frmAdministracionUsuarios();
                    this.MostrarForm(e.Node.Text.ToString(), adminuser);
                    break;

                case "Reportes y estadísticas":
                    frmAdministracionDeReporteria report = new frmAdministracionDeReporteria();
                    this.MostrarForm(e.Node.Text.ToString(), report);
                    break;
            }
        }

        private void btnAdminUser_Click(object sender, EventArgs e)
        {
            
                   frmAdministracionUsuarios adminuser = new frmAdministracionUsuarios();
                   this.MostrarForm("Administración de usuarios", adminuser);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
             
                  frmAdministracionDeReporteria report = new frmAdministracionDeReporteria();
                  this.MostrarForm("Reportes y estadísticas", report);
                    
        }

        private void administraciónDeFichaDentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
               
                   frmAdministracionFichas fich = new frmAdministracionFichas(this);
                   this.MostrarForm("Administración de ficha dental", fich);
                
        }

        private void administraciónDePresupuestoDentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                   frmAdministracionPresupuesto presu = new frmAdministracionPresupuesto();
                   this.MostrarForm("Administración de presupuesto dental", presu);
                  
        }

        private void administraciónDeOrdenDeLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                    frmAdministracionOrdenLab orden = new frmAdministracionOrdenLab();
                    this.MostrarForm("Administración de orden de laboratorio", orden);
                    
        }

        private void administraciónDeTratamientoDentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                    frmAdministracionTratamiento trata = new frmAdministracionTratamiento(this);
                    this.MostrarForm( "Administración de tratamiento dental", trata);
                    
        }

        private void administraciónDeReportesEInsumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
              
                    frmAdministracionDeInsumos insumo = new frmAdministracionDeInsumos();
                    this.MostrarForm("Administración de reportes e insumos", insumo);
                
        }


        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministracionUsuarios adminuser = new frmAdministracionUsuarios();
            this.MostrarForm("Administración de usuarios", adminuser);
        }

        private void administraciónDeListasDePreciosPorTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
                    frmAdministracionListasDePrecios listaprecio = new frmAdministracionListasDePrecios();
                    this.MostrarForm("Administración de listas de precios por tratamiento", listaprecio);

        }

        private void treeViewMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

    }
}
