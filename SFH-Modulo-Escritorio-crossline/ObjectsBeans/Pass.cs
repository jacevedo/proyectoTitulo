using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Pass : Persona
    {
        #region Campos
        private int idPersonaPass;
        private string passtext;
        private DateTime fechaCaducidad;
        #endregion

        #region Constructor
        public Pass() { }
        public Pass(int _idPersona) : base(_idPersona) { }
        #endregion

        #region Propiedad

        public int IdPersonaPass
        {
            get { return idPersonaPass; }
            set { idPersonaPass = value; }
        }

        public string Passtext
        {
            get { return passtext; }
            set { passtext = value; }
        }

        public DateTime FechaCaducidad
        {
            get { return fechaCaducidad; }
            set { fechaCaducidad = value; }
        }
        #endregion
    }
}
