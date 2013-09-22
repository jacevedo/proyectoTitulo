using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Fichadental
    {
        #region Campos
        private int idFicha;
        private int idPaciente;
        private int idOdontologo;
        private DateTime fechaIngreso;
        private string anamnesis;
        private int habilitada;
        #endregion

        #region Constructor
        public Fichadental() { }
        #endregion

        #region Propiedad

        public int IdFicha
        {
            get { return idFicha; }
            set { idFicha = value; }
        }

        public int IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public int IdOdontologo
        {
            get { return idOdontologo; }
            set { idOdontologo = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public string Anamnesis
        {
            get { return anamnesis; }
            set { anamnesis = value; }
        }

        public int Habilitada
        {
            get { return habilitada; }
            set { habilitada = value; }
        }
        #endregion
    }
}
