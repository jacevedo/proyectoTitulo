using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Piezadental
    {
        #region Campos
        private int idPieza;
        private int idTratamientoDental;
        private int idOrdenLaboratorio;
        private int idTipoPieza;
        private string nombrePieza;
        private string descripcionPieza;
        private int periodoPieza;
        #endregion

        #region Constructor
        public Piezadental() { }
        #endregion

        #region Propiedad

        public int IdPieza
        {
            get { return idPieza; }
            set { idPieza = value; }
        }

        public int IdTratamientoDental
        {
            get { return idTratamientoDental; }
            set { idTratamientoDental = value; }
        }

        public int IdOrdenLaboratorio
        {
            get { return idOrdenLaboratorio; }
            set { idOrdenLaboratorio = value; }
        }

        public int IdTipoPieza
        {
            get { return idTipoPieza; }
            set { idTipoPieza = value; }
        }

        public string NombrePieza
        {
            get { return nombrePieza; }
            set { nombrePieza = value; }
        }

        public string DescripcionPieza
        {
            get { return descripcionPieza; }
            set { descripcionPieza = value; }
        }

        public int PeriodoPieza
        {
            get { return periodoPieza; }
            set { periodoPieza = value; }
        }
        #endregion
    }
}
