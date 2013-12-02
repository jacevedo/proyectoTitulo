using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Tratamientodental
    {
        #region Campos
        private int idTratamientoDental;
        private int idFicha;
        private DateTime fechaCreacion;
        private string tratamiento;
        private DateTime fechaSeguimiento;
        private int valorTotal;
        private int totalAbono;
        #endregion

        #region Constructor
        public Tratamientodental() { }
        #endregion

        #region Propiedad

        public int IdTratamientoDental
        {
            get { return idTratamientoDental; }
            set { idTratamientoDental = value; }
        }
        public int TotalAbono
        {
            get { return totalAbono; }
            set { totalAbono = value; }
        }
        public int IdFicha
        {
            get { return idFicha; }
            set { idFicha = value; }
        }

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }

        public string Tratamiento
        {
            get { return tratamiento; }
            set { tratamiento = value; }
        }

        public DateTime FechaSeguimiento
        {
            get { return fechaSeguimiento; }
            set { fechaSeguimiento = value; }
        }

        public int ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }
        #endregion
    }
}
