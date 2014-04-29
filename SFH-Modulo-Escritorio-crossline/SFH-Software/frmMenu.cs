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
    public partial class frmMenu : Form
    {
        #region Campos
        private static int i;
        string[] pantallas = new string[100];
        frmAcerca acer = new frmAcerca();
        private Session session = new Session();
        private ClientWsLogin login = new ClientWsLogin();
        private Persona persona = new Persona();
        private string exp0,exp1,exp2;
        #endregion

        #region Propiedades
        #endregion

        #region Metodos
        private void PerfilamientoDeInterfaz(int codAcceso) {
            switch (codAcceso) {
                case 707:
                    this.seguridadToolStripMenuItem.Visible = true;
                    this.toolStripReportesyestadisticas.Visible = true;
                    this.administraciónDeFichaDentalToolStripMenuItem.Visible = true;
                    this.administraciónDePresupuestoDentalToolStripMenuItem.Visible = true;
                    this.administraciónDeOrdenDeLaboratorioToolStripMenuItem.Visible = true;
                    this.administraciónDeTratamientoDentalToolStripMenuItem.Visible = true;
                    this.administraciónDeReportesEInsumosToolStripMenuItem.Visible = true;
                    this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem.Visible = true;
                    this.administraciónDeÁreaInsumosToolStripMenuItem.Visible = true;
                    this.administraciónDeGatosToolStripMenuItem.Visible = true;
                    break;
                case 706:
                    //Odontologo
                    this.seguridadToolStripMenuItem.Visible = true;
                    this.toolStripReportesyestadisticas.Visible = true;
                    this.administraciónDeFichaDentalToolStripMenuItem.Visible = true;
                    this.administraciónDePresupuestoDentalToolStripMenuItem.Visible = true;
                    this.administraciónDeOrdenDeLaboratorioToolStripMenuItem.Visible = true;
                    this.administraciónDeTratamientoDentalToolStripMenuItem.Visible = true;
                    this.administraciónDeReportesEInsumosToolStripMenuItem.Visible = true;
                    this.administraciónDeListasDePreciosPorTratamientoToolStripMenuItem.Visible = true;
                    this.administraciónDeÁreaInsumosToolStripMenuItem.Visible = true;
                    this.administraciónDeGatosToolStripMenuItem.Visible = true;
                    break;
                case 705:
                    //asistente
                    this.administraciónDeFichaDentalToolStripMenuItem.Visible = true;
                    this.administraciónDePresupuestoDentalToolStripMenuItem.Visible = true;
                    this.administraciónDeOrdenDeLaboratorioToolStripMenuItem.Visible = true;
                    this.administraciónDeTratamientoDentalToolStripMenuItem.Visible = true;
                    this.administraciónDeReportesEInsumosToolStripMenuItem.Visible = true;
                    this.treeViewMenu.Nodes[2].Remove();
                    this.treeViewMenu.Nodes[1].Remove();
                    this.treeViewMenu.Nodes.Remove(this.treeViewMenu.Nodes[0].Nodes[7]);
                    this.treeViewMenu.Nodes.Remove(this.treeViewMenu.Nodes[0].Nodes[6]);
                    this.treeViewMenu.Nodes.Remove(this.treeViewMenu.Nodes[0].Nodes[5]);
                    this.btnAdminUser.Visible = false;
                    this.btnReportes.Visible = false;
                    break;
                default:
                     this.persona = null;
                     this.session = null;
                     this.Dispose();
                     frmLogin log = new frmLogin();
                     log.ShowDialog();
                    break;
            }
        }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Se produjo un error al crear la pantala, vuelva a intentarlo.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
          
        }
        #endregion

        public frmMenu(Session session_param)
        {
            this.session = session_param;
            this.exp0 = ""; this.exp1 = ""; this.exp2="";
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "SFH Administración de Clínica - Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
            if (MessageBox.Show("¿Desea cerrar esta sesión?", "SFH Administración de Clínica - Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.persona = null;
                this.session = null;
                this.Dispose();
                frmLogin log = new frmLogin();
                log.ShowDialog();
            }
        }
        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.persona = null;
            this.session = null;
            Application.Exit();
        }

        private void btnAdminCli_Click(object sender, EventArgs e)
        {
            if(this.exp0.Equals(""))
            {
                this.treeViewMenu.Nodes[0].Expand();
                this.exp0 = "1";
            }
            else if(exp0.Equals("1"))
            {
                this.treeViewMenu.Nodes[0].Collapse();
                this.exp0 = "";
            }
        }

        private void treeViewMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Administración Ficha Dental":
                    frmAdministracionFichas fich = new frmAdministracionFichas(this);
                    this.MostrarForm(e.Node.Text.ToString(),fich);
                    break;
                case "Administración Presupuesto Dental":
                    frmAdministracionPresupuesto presu = new frmAdministracionPresupuesto(1,"Totales");
                    this.MostrarForm(e.Node.Text.ToString(), presu);
                    break;
                case "Administración Orden de Laboratorio":
                    frmAdministracionOrdenLab orden = new frmAdministracionOrdenLab();
                    this.MostrarForm(e.Node.Text.ToString(), orden);
                    break;
                case "Administración Tratamiento Dental":
                    frmAdministracionTratamiento trata = new frmAdministracionTratamiento(this);
                    this.MostrarForm(e.Node.Text.ToString(), trata);
                    break;
                case "Administración Insumos":
                    frmAdministracionDeInsumos insumo = new frmAdministracionDeInsumos(this);
                    this.MostrarForm(e.Node.Text.ToString(),insumo);
                    break;
                case "Administración Precios Tratamientos":
                    frmAdministracionListasDePrecios listaprecio = new frmAdministracionListasDePrecios();
                    this.MostrarForm(e.Node.Text.ToString(), listaprecio);
                    break;
                case "Administración Usuarios":
                    frmAdministracionUsuarios adminuser = new frmAdministracionUsuarios(this);
                    this.MostrarForm(e.Node.Text.ToString(), adminuser);
                    break;
                case "Administración Área Insumos":
                    frmAdministracionAreaInsumos areainsumo = new frmAdministracionAreaInsumos(this);
                    this.MostrarForm(e.Node.Text.ToString(), areainsumo);
                    break;
                case "Administración Gastos":
                    frmGastos gastos = new frmGastos(this);
                    this.MostrarForm(e.Node.Text.ToString(), gastos);
                    break;
                case "Administración Datos de Contacto":
                    frmDatosDeContacto datosdecontacto = new frmDatosDeContacto();
                    this.MostrarForm(e.Node.Text.ToString(), datosdecontacto);
                    break;
                case "Administración Pacientes":
                    frmPaciente pacientes = new frmPaciente();
                    this.MostrarForm(e.Node.Text.ToString(), pacientes);
                    break;
                case "Administración Odontólogos":
                    frmOdontologo odontologos = new frmOdontologo();
                    this.MostrarForm(e.Node.Text.ToString(), odontologos);
                    break;
                case "Administración Funcionarios":
                    frmFuncionario funcionario = new frmFuncionario();
                    this.MostrarForm(e.Node.Text.ToString(), funcionario);
                    break;
                case "Generar Reporte Pacientes":
                    frmGenerarReportesPacientes report = new frmGenerarReportesPacientes();
                    this.MostrarForm(e.Node.Text.ToString(), report);
                    break;
                case "Generar Reportes Monetarios":
                    frmGenerarReportesMonetarios reportMon = new frmGenerarReportesMonetarios();
                    this.MostrarForm(e.Node.Text.ToString(), reportMon);
                    break;
                case "Listar Historial de Reportes":
                    frmListarHistorialdeReportes histReport= new frmListarHistorialdeReportes();
                    this.MostrarForm(e.Node.Text.ToString(), histReport);
                    break;
            }
        }

        private void btnAdminUser_Click(object sender, EventArgs e)
        {
            if (this.exp1.Equals(""))
            {
                this.treeViewMenu.Nodes[1].Expand();
                this.exp1 = "1";
            }
            else if (exp1.Equals("1"))
            {
                this.treeViewMenu.Nodes[1].Collapse();
                this.exp1 = "";
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (this.exp2.Equals(""))
            {
                this.treeViewMenu.Nodes[2].Expand();
                this.exp2 = "1";
            }
            else if (exp2.Equals("1"))
            {
                this.treeViewMenu.Nodes[2].Collapse();
                this.exp2 = "";
            }
                    
        }

        private void administraciónDeFichaDentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministracionFichas fich = new frmAdministracionFichas(this);
            this.MostrarForm("Administración Ficha Dental", fich);
        }

        private void administraciónDePresupuestoDentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministracionPresupuesto presu = new frmAdministracionPresupuesto(1, "Totales");
            this.MostrarForm("Administración Presupuesto Dental", presu);                  
        }

        private void administraciónDeOrdenDeLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministracionOrdenLab orden = new frmAdministracionOrdenLab();
            this.MostrarForm("Administración Orden de Laboratorio", orden);                    
        }

        private void administraciónDeTratamientoDentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministracionTratamiento trata = new frmAdministracionTratamiento(this);
            this.MostrarForm( "Administración Tratamiento Dental", trata);                    
        }

        private void administraciónDeReportesEInsumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministracionDeInsumos insumo = new frmAdministracionDeInsumos(this);
            this.MostrarForm("Administración Insumos", insumo);                
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministracionUsuarios adminuser = new frmAdministracionUsuarios(this);
            this.MostrarForm("Administración Usuarios", adminuser);
        }

        private void administraciónDeListasDePreciosPorTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            frmAdministracionListasDePrecios listaprecio = new frmAdministracionListasDePrecios();
            this.MostrarForm("Administración Precios Tratamientos", listaprecio);
        }

        private void administraciónDeÁreaInsumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministracionAreaInsumos areaInsumos = new frmAdministracionAreaInsumos(this);
            this.MostrarForm("Administración Área Insumos ", areaInsumos);
        }

        private void administraciónDeGatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGastos gastos = new frmGastos(this);
            this.MostrarForm("Administración Gastos", gastos);
        }

        private void AdministracióndedatosdecontactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatosDeContacto datosdeContacto = new frmDatosDeContacto();
            this.MostrarForm("Administración Datos de Contacto", datosdeContacto);
        }

        private void AdministracióndepacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaciente paciente = new frmPaciente();
            this.MostrarForm("Administración Pacientes ", paciente);
        }

        private void administraciónDeOdontólogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOdontologo odontologo = new frmOdontologo();
            this.MostrarForm("Administración Odontólogos ", odontologo);
        }

        private void administraciónDeFuncionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncionario funcionarios = new frmFuncionario();
            this.MostrarForm("Administración Funcionarios ", funcionarios);
        }

        private void generarReportePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenerarReportesPacientes reportPaciente = new frmGenerarReportesPacientes();
            this.MostrarForm("Generar Reporte Pacientes ", reportPaciente);
        }

        private void generarReportesMonetariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenerarReportesMonetarios reportMonetario = new frmGenerarReportesMonetarios();
            this.MostrarForm("Generar Reportes Monetarios ", reportMonetario);
        }

        private void listarHistorialDeReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListarHistorialdeReportes reportHistorial = new frmListarHistorialdeReportes();
            this.MostrarForm("Listar Historial de Reportes ", reportHistorial);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.PerfilamientoDeInterfaz(session.Cod_acceso);
            this.persona = this.login.RecuperarDatosDeUsuarioConectado(this.session.Rut);
            this.usuarioToolStripMenuItem.Text = persona.Nombre + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno;
            this.Refresh();
        }
    }
}
