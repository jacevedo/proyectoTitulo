using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class RegionContacto
    {
        #region Campos
        private int idRegion;
        private string nombreRegion;
        private string numeroRegionRomano;
        #endregion

        #region Constructor
        public RegionContacto() { }
        #endregion

        #region Propiedades

        public int IdRegion
        {
            get { return idRegion; }
            set { idRegion = value; }
        }

        public string NombreRegion
        {
            get { return nombreRegion; }
            set { nombreRegion = value; }
        }

        public string NumeroRegionRomano
        {
            get { return numeroRegionRomano; }
            set { numeroRegionRomano = value; }
        }
        #endregion
    }
}
