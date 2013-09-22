using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Insumos : Gastos
    {
        #region Campos
        private int idInsumos;
        private int idAreaInsumo;
        private int idGastos_insumo;
        private string nomInsumos;
        private int cantidad;
        private string descripcionInsumo;
        private string unidadMedida;
        #endregion

        #region Constructor
        public Insumos() {}
        public Insumos(int _idgastos):base(_idgastos) { }
        #endregion

        #region Propiedad
        public int IdInsumos
        {
            get { return idInsumos; }
            set { idInsumos = value; }
        }

        public int IdAreaInsumo
        {
            get { return idAreaInsumo; }
            set { idAreaInsumo = value; }
        }

        public int IdGastos_insumo
        {
            get { return idGastos_insumo; }
            set { idGastos_insumo = value; }
        }

        public string NomInsumos
        {
            get { return nomInsumos; }
            set { nomInsumos = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public string DescripcionInsumo
        {
            get { return descripcionInsumo; }
            set { descripcionInsumo = value; }
        }

        public string UnidadMedida
        {
            get { return unidadMedida; }
            set { unidadMedida = value; }
        }
        #endregion
    }
}
