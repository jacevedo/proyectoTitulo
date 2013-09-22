using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Abono
    {
        #region Campos 
        private int idAbono;
        private int idTratamientoDental;
        private DateTime fechaAbono;
        private int monto;
        #endregion 

        #region Constructor
        public Abono() { 
        
        }
        #endregion

        #region Propiedad
        
        public int IdAbono
        {
            get { return idAbono; }
            set { idAbono = value; }
        }
        public int IdTratamientoDental
        {
            get { return idTratamientoDental; }
            set { idTratamientoDental = value; }
        }
        public DateTime FechaAbono
        {
            get { return fechaAbono; }
            set { fechaAbono = value; }
        }
        public int Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        #endregion
    }
}
