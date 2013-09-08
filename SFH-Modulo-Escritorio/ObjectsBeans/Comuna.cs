using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Comuna
    {
        #region Campos
        private int idComuna;
        private int idRegion;
        private string nombreComuna;
        #endregion

        #region Constructor
        public Comuna() { 
        
        }
        #endregion

        #region Propiedad

        public int IdComuna
        {
            get { return idComuna; }
            set { idComuna = value; }
        }

        public int IdRegion
        {
            get { return idRegion; }
            set { idRegion = value; }
        }

        public string NombreComuna
        {
            get { return nombreComuna; }
            set { nombreComuna = value; }
        }
        #endregion
    }
}
