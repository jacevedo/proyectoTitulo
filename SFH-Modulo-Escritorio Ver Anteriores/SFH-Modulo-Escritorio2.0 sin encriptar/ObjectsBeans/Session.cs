using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Session
    {
        #region Campos
       
        private int id_persona;

        private int id_odontologo;

        private string key;

        private int cod_acceso;

        private string habilitado;

        private Boolean secdat;

        private string rut;

       
        #endregion

        #region Propiedades
        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }

        public int Id_odontologo
        {
            get { return id_odontologo; }
            set { id_odontologo = value; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public int Cod_acceso
        {
            get { return cod_acceso; }
            set { cod_acceso = value; }
        }

        public string Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        public Boolean Secdat
        {
            get { return secdat; }
            set { secdat = value; }
        }
        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }
        #endregion
    }
}
