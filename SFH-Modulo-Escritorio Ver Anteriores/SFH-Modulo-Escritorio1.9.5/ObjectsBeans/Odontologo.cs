using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Odontologo : Persona
    {
        #region Campos
        private int idOdontologo;
        private int idPersonaOdontologo;
        private string especialidad;
        private EstadoPersona odontologoHabilitado;
        #endregion

        #region Constructor
        public Odontologo() { }
        public Odontologo(int _idpersona):base(_idpersona) { }
        #endregion

        #region Propiedad

        public int IdOdontologo
        {
            get { return idOdontologo; }
            set { idOdontologo = value; }
        }

        public int IdPersonaOdontologo
        {
            get { return idPersonaOdontologo; }
            set { idPersonaOdontologo = value; }
        }

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public EstadoPersona OdontologoHabilitado
        {
            get { return odontologoHabilitado; }
            set { odontologoHabilitado = value; }
        }
        #endregion
    }
}
