using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Persona
    {
        #region Campos
        private int idPersona;
        private int idPerfil;
        private string nomperfil;
        private int rut;
        private string dv;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private DateTime fechaNacimiento;
        
        #endregion

        #region Constructor
        public Persona() { }
        public Persona(int _idpersona)
        {
            this.IdPersona = _idpersona;
        }
        #endregion

        #region Propiedad

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        public string Nomperfil
        {
            get { return nomperfil; }
            set { nomperfil = value; }
        }

        public int Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        public string Dv
        {
            get { return dv; }
            set { dv = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }

        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        #endregion
    }
}
