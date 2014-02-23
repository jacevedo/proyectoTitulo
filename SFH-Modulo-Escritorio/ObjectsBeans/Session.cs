using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Session
    {
        #region Campos
        //{"resultado":{"idPersona":11,"idOdontologo":4,"key":"$2a$08$W04EZdtv\/Y6mhCqRLVya4Ot\/w5RSwf2BcQ95ShS1uycSOkojHpUG.","codAcceso":706,"habilitado":"Usuario Habilitado"}}
        private int id_persona;

        private int id_odontologo;

        private string key;

        private int cod_acceso;

        private string habilitado;

        private Boolean secdat;

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
        #endregion
    }
}
