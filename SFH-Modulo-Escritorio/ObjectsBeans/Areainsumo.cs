using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    class Areainsumo
    {
        #region Campos
        private int idAreaInsumo;
        private string nombreArea;
        private string descripcionArea;
        #endregion

        #region Constructor
        public Areainsumo() { 
        
        }
        #endregion

        #region Propiedad

        public int IdAreaInsumo
        {
            get { return idAreaInsumo; }
            set { idAreaInsumo = value; }
        }
        public string NombreArea
        {
            get { return nombreArea; }
            set { nombreArea = value; }
        }

        public string DescripcionArea
        {
            get { return descripcionArea; }
            set { descripcionArea = value; }
        }
        #endregion
    }
}
