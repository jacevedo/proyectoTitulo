using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Insumos 
    {
        /*
         CREATE TABLE IF NOT EXISTS `insumos` (
   `ID_INSUMO` int(11) NOT NULL AUTO_INCREMENT,
   `ID_AREA_INSUMO` int(11) DEFAULT NULL,
   `ID_GASTOS` int(11) DEFAULT NULL,
     `NOMBRE_INSUMO` varchar(50) DEFAULT NULL,
     `CANTIDAD` float DEFAULT NULL,
     `DESCRIPCION_INSUMO` text,
      `UNIDAD_DE_MEDIDA_INSUMO` varchar(20) DEFAULT NULL,
       PRIMARY KEY (`ID_INSUMO`),
       KEY `INDEX_INSUMOS_1` (`ID_AREA_INSUMO`),
       KEY `INDEX_INSUMOS_2` (`ID_GASTOS`)
        ) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

         */
        #region Campos
        private int idInsumos;
        private int idAreaInsumo;
        private int idGastos_insumo;
        private string nomInsumos;
        private int cantidad;
        private string descripcionInsumo;
        private string unidadMedida;
        private string conceptoGasto;
        private string nomAreaInsumo;
        #endregion

        #region Constructor
        public Insumos() {}
      
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
       
        public string ConceptoGasto
        {
            get { return conceptoGasto; }
            set { conceptoGasto = value; }
        }

        public string NomAreaInsumo
        {
            get { return nomAreaInsumo; }
            set { nomAreaInsumo = value; }
        }
        #endregion
    }
}
