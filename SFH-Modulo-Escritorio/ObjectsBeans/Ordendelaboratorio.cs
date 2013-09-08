using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Ordendelaboratorio
    {
        #region Campos
        private int idOrdenLaboratorio;
        private string clinica;
        private string bd;
        private string bi;
        private string pd;
        private string pi;
        private DateTime fechaEntrega;
        private DateTime horaEntrega;
        private string color;
        private EstadoOrdenLaboratorio estadodeorden;
        #endregion

        #region Constructor
        public Ordendelaboratorio() { }
        #endregion

        #region Propiedad

        public int IdOrdenLaboratorio
        {
            get { return idOrdenLaboratorio; }
            set { idOrdenLaboratorio = value; }
        }
        public string Clinica
        {
            get { return clinica; }
            set { clinica = value; }
        }
        public string Bd
        {
            get { return bd; }
            set { bd = value; }
        }
        public string Bi
        {
            get { return bi; }
            set { bi = value; }
        }
        public string Pd
        {
            get { return pd; }
            set { pd = value; }
        }
        public string Pi
        {
            get { return pi; }
            set { pi = value; }
        }
        
        public DateTime HoraEntrega
        {
            get { return horaEntrega; }
            set { horaEntrega = value; }
        }

        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public EstadoOrdenLaboratorio Estadodeorden
        {
            get { return estadodeorden; }
            set { estadodeorden = value; }
        }
        #endregion
    }
}
