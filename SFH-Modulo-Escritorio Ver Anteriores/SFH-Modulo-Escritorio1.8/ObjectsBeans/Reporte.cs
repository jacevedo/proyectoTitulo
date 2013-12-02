using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Reporte : Persona
    {
        #region Campos
        private int idReporte;
        private int idPersona;
        private DateTime fechaCreacion;
        private string tipoReporte;
        #endregion

        #region Constructor
        #endregion

        #region Propiedades

        public int IdReporte
        {
            get { return idReporte; }
            set { idReporte = value; }
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }

        public string TipoReporte
        {
            get { return tipoReporte; }
            set { tipoReporte = value; }
        }
        #endregion
    }
}
