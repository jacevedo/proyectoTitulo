using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Listadeprecio
    {
        #region Campos
        private int idPrecios;
        private string comentario;
        private string valorNeto;
        private string valorIva;
        private string valortotal;

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

        public string ValorIva
        {
            get { return valorIva; }
            set { valorIva = value; }
        }

        public string Valortotal
        {
            get { return valortotal; }
            set { valortotal = value; }
        }

        #endregion
    }
}
