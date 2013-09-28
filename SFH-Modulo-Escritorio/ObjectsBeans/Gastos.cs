using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
  public class Gastos
    {
        #region Campos
        private int idGastos;
        private int idPersona;
        private int montoGastos;
        private int descuentoGastos;

        #endregion

        #region Constructor
        public Gastos(){
        }
        public Gastos(int _idgastos)
        {
            this.IdGastos = _idgastos;
        }
        #endregion

        #region Propiedad

        public int IdGastos
        {
            get { return idGastos; }
            set { idGastos = value; }
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public int MontoGastos
        {
            get { return montoGastos; }
            set { montoGastos = value; }
        }
        public int DescuentoGastos
        {
            get { return descuentoGastos; }
            set { descuentoGastos = value; }
        }
        #endregion
    }
}
