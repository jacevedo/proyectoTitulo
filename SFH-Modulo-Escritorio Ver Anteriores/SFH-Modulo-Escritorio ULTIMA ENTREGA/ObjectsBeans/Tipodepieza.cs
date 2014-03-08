using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Tipodepieza
    {
        #region Campos
        private int idTipoPieza;
        private string nombreCientificoPieza;
        private string descripcion;
        #endregion

        #region Constructor
        public Tipodepieza() { }
        #endregion

        #region Propiedades

        public int IdTipoPieza
        {
            get { return idTipoPieza; }
            set { idTipoPieza = value; }
        }

        public string NombreCientificoPieza
        {
            get { return nombreCientificoPieza; }
            set { nombreCientificoPieza = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion
    }
}
