using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Datoscontacto : Persona
    {
        #region Campos
        private int idPersona_dat;
        private int idComuna;
        private string fonoFijo;
        private string fonoCelular;
        private string direccion;
        private string mail;
        private string nomComuna;
        private int idcomuna;
        //se captura cuando se registra el usuario
        private DateTime fechaIngreso;
        #endregion

        #region Constructor
        public Datoscontacto() { 
        }
         public Datoscontacto(int _idPersona)
            : base(_idPersona){
               
         }
        #endregion

        #region Propiedad

         public int IdPersona_dat
         {
             get { return idPersona_dat; }
             set { idPersona_dat = value; }
         }

        public int IdComuna
        {
            get { return idComuna; }
            set { idComuna = value; }
        }

        public string FonoFijo
        {
            get { return fonoFijo; }
            set { fonoFijo = value; }
        }

        public string FonoCelular
        {
            get { return fonoCelular; }
            set { fonoCelular = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public string NomComuna
        {
            get { return nomComuna; }
            set { nomComuna = value; }
        }

        public int Idcomuna
        {
            get { return idcomuna; }
            set { idcomuna = value; }
        }
        #endregion
    }
}
