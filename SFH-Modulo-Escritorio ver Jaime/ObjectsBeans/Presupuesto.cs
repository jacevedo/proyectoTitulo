using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Presupuesto
    {
        #region Campos
        private int idPresupuesto;
        private int valorTotal;
        private int idFicha;
        private DateTime fechaPresupuesto;
        #endregion

        #region Constructor
        public Presupuesto() { } 
        #endregion

        #region Propiedades

        public int IdPresupuesto
        {
            get { return idPresupuesto; }
            set { idPresupuesto = value; }
        }

        public int ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }

        public int IdFicha
        {
            get { return idFicha; }
            set { idFicha = value; }
        }

        public DateTime FechaPresupuesto
        {
            get { return fechaPresupuesto; }
            set { fechaPresupuesto = value; }
        }
        #endregion
    }
}
