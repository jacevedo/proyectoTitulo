using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Datoscontacto
    {
        #region Campos
        private int idPersona;
        private int idComuna;
        private int fonoFijo;
        private int fonoCelular;
        private int direccion;
        private string mail;
        private DateTime fechaIngreso;
        #endregion

        #region Constructor
        public Datoscontacto() { 
        }
        #endregion

        #region Propiedad

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public int IdComuna
        {
            get { return idComuna; }
            set { idComuna = value; }
        }

        public int FonoFijo
        {
            get { return fonoFijo; }
            set { fonoFijo = value; }
        }

        public int FonoCelular
        {
            get { return fonoCelular; }
            set { fonoCelular = value; }
        }

        public int Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        #endregion
    }
}
