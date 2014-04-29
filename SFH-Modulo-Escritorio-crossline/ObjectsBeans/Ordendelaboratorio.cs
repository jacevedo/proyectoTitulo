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
        private int idOdontologo;
        private int idPaciente;
        private int numeroOrden;
        private string clinica;
        private string bd;
        private string bi;
        private string pd;
        private string pi;
        private DateTime fechaCreacion;
        private DateTime fechaEntrega;
        private string horaEntrega;
        private string color;
        private EstadoOrdenLaboratorio estadodeorden;
        private string nomPaciente;
        private string nomOdontologo;
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
        public int IdOdontologo
        {
            get { return idOdontologo; }
            set { idOdontologo = value; }
        }
        public int IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
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
        
        public string HoraEntrega
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
        public string NomPaciente
        {
            get { return nomPaciente; }
            set { nomPaciente = value; }
        }
        public string NomOdontologo
        {
            get { return nomOdontologo; }
            set { nomOdontologo = value; }
        }
        public int NumeroOrden
        {
            get { return numeroOrden; }
            set { numeroOrden = value; }
        }
        #endregion
    }
}
