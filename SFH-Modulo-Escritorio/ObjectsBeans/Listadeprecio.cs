using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    class Listadeprecio
    {
        #region Campos
        private int idPrecios;
        private string comentario;
        private string valorNeto;
        #endregion

        #region Constructor
        public Listadeprecio() { }
        #endregion

        #region Propiedad

        public int IdPrecios
        {
            get { return idPrecios; }
            set { idPrecios = value; }
        }

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        public string ValorNeto
        {
            get { return valorNeto; }
            set { valorNeto = value; }
        }
        #endregion
    }
}
