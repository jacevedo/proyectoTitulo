using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Paciente : Persona
    {
        #region Campos
        private int idPaciente;
        private int idPersonaPaciente;
        private DateTime fechaIngreso;
        private EstadoPersona habilitadoPaciente;
        #endregion

        #region Constructores
        public Paciente() { }
        public Paciente(int _idpersona) : base(_idpersona) { 
        }
        #endregion

        #region Propiedades

        public int IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public int IdPersonaPaciente
        {
            get { return idPersonaPaciente; }
            set { idPersonaPaciente = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public EstadoPersona HabilitadoPaciente
        {
            get { return habilitadoPaciente; }
            set { habilitadoPaciente = value; }
        }
        #endregion
    }
}
