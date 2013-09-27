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
        ClientWsAdminUsuario client_users = new ClientWsAdminUsuario();
        List<Fichadental> result = new List<Fichadental>();
        private int id_ficha_modificar;
        frmMenu menu;
        #endregion
        
        #region Propiedades
        public int Id_ficha_modificar
        {
            get { return id_ficha_modificar; }
            set { id_ficha_modificar = value; }
        }
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
            cmbxPaciente.DataSource = client_users.ListarPacientePersona();
            cmbxPaciente.ValueMember = "IdPersona";
            cmbxPaciente.DisplayMember = "Nombre";
 
        }
        private void PoblarComboOdontologo() {
            cmbxOdontologo.DataSource = client_users.ListarOdontologoPersona();
            cmbxOdontologo.ValueMember = "IdPersona";
            cmbxOdontologo.DisplayMember = "Nombre";
        }

        private void LimpiarControles() {

            this.txtPaciente.Text = string.Empty;
            this.txtOdontologo.Text = string.Empty;
            this.txtAnamnesis.Text = string.Empty;
            this.mcFechaIngreso.ResetText();
            
        }
        #endregion

        public frmAdministracionFichas(frmMenu menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

      
        private void frmAdministracionFichas_Load(object sender, EventArgs e)
        {
           //Cargar Combox 
            this.PoblarComboBusqueda();
            this.PoblarComboEstado();
            this.PoblarComboPacientes();
            this.PoblarComboOdontologo();
           //Cargar Grillas 
            datagridFicha.DataSource = this.client_fichas.ListarFichas();
            btnNuevo.Text = "Ingresar Ficha";

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
                    datagridFicha.DataSource = this.client_fichas.ListarFichas();
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
                        datagridFicha.DataSource = this.result;
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
                        datagridFicha.DataSource = this.result;
                    }
                    break;
            }
        }

       
        private void cmbxPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string texto = cmbxPaciente.Text;
            txtPaciente.Text = texto;
        }

        private void cmbxOdontologo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string texto = cmbxOdontologo.Text;
            txtOdontologo.Text = texto;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //{"indice":1,"idPaciente":1,"idOdontologo":1,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":0}
            if (btnNuevo.Text.ToString().Trim() == "Ingresar Ficha")
            {
                Fichadental ficha = new Fichadental();
                ficha.IdPaciente = Convert.ToInt32(cmbxPaciente.SelectedValue.ToString());
                ficha.IdOdontologo = Convert.ToInt32(cmbxOdontologo.SelectedValue.ToString());
                ficha.Anamnesis = txtAnamnesis.Text.ToString();
                ficha.FechaIngreso = mcFechaIngreso.SelectionStart;
                ficha.EstadoPaciente = 1;
                this.client_fichas.InsertarFichaDental(ficha);
                datagridFicha.DataSource = this.client_fichas.ListarFichas();
                this.LimpiarControles();
                MessageBox.Show("Ficha insertada satisfactoriamente", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (btnNuevo.Text.ToString().Trim() == "Guardar Cambios")
            {
                Fichadental ficha = new Fichadental();
                ficha.IdFicha = this.Id_ficha_modificar;
                ficha.IdPaciente = Convert.ToInt32(cmbxPaciente.SelectedValue.ToString());
                ficha.IdOdontologo = Convert.ToInt32(cmbxOdontologo.SelectedValue.ToString());
                ficha.Anamnesis = txtAnamnesis.Text.ToString();
                ficha.FechaIngreso = mcFechaIngreso.SelectionStart;
                this.client_fichas.ModificarFichaDental(ficha);
                datagridFicha.DataSource = this.client_fichas.ListarFichas();
                this.LimpiarControles();
                btnNuevo.Text = "Ingresar Ficha";
                MessageBox.Show("Ficha modificada satisfactoriamente", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void datagridFicha_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex) { 
                case 0:
                    this.ModificarEstado(e);
                    break;
                case 1:
                    this.ModidificarFicha(e);
                    break;
                case 2:
                    Fichadental ficha = datagridFicha.Rows[e.RowIndex].DataBoundItem as Fichadental;
                    menu.MostrarForm("Administración de presupuesto dental",  new frmAdministracionPresupuesto(ficha.IdFicha,ficha.NombrePaciente));
                    break;
                case 3:
                    menu.MostrarForm("Administración de orden de laboratorio", new frmAdministracionOrdenLab());
                    break;
                case 4:
                    menu.MostrarForm("Administración de tratamiento dental", new frmAdministracionTratamiento(menu));
                    break;
            
            }

           
        }
        private void ModificarEstado(DataGridViewCellEventArgs e)
        {
            Fichadental ficha = datagridFicha.Rows[e.RowIndex].DataBoundItem as Fichadental;
            ficha.EstadoPaciente = Convert.ToInt32(cmbxestado.Index);
            this.client_fichas.CambiarEstadoFicha(ficha);
            datagridFicha.DataSource = this.client_fichas.ListarFichas();
            MessageBox.Show("Estado de Ficha modificado satisfactoriamente", "SFH Administración de Clínica - Administración de Fichas Dentales", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ModidificarFicha(DataGridViewCellEventArgs e) {
            Fichadental ficha = datagridFicha.Rows[e.RowIndex].DataBoundItem as Fichadental;
            this.Id_ficha_modificar = ficha.IdFicha;
            txtPaciente.Text = ficha.NombrePaciente.ToString();
            txtOdontologo.Text = ficha.NombreOdontologo.ToString();
            txtAnamnesis.Text = ficha.Anamnesis.ToString();
            mcFechaIngreso.SelectionStart = ficha.FechaIngreso;
            mcFechaIngreso.SelectionEnd = ficha.FechaIngreso;
            cmbxPaciente.SelectedValue =  ficha.IdPaciente;
            cmbxOdontologo.SelectedValue =  ficha.IdOdontologo;
            btnNuevo.Text = "Guardar Cambios";
        }
      
    }
}
