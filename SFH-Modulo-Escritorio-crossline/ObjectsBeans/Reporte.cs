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
        private string query;
        private DateTime fecha_inicio;
        private DateTime fecha_termino;

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
        public string Query
        {
            get { return query; }
            set { query = value; }
        }
        public DateTime Fecha_inicio
        {
            get { return fecha_inicio; }
            set { fecha_inicio = value; }
        }

        public DateTime Fecha_termino
        {
            get { return fecha_termino; }
            set { fecha_termino = value; }
        }

        
        #endregion
    }
}
