using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Cita
    {
        #region Campos
        private int idCita;
        private int idOdontologo;
        private int idPaciente;
        private DateTime horaInicio;
        private DateTime horaTermino;
        private DateTime fecha;
        #endregion

        #region Constructor
        public Cita(){
        }
        #endregion

        #region Propiedad

        public int IdCita
        {
            get { return idCita; }
            set { idCita = value; }
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

        public DateTime HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        public DateTime HoraTermino
        {
            get { return horaTermino; }
            set { horaTermino = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        #endregion
    }
}
