using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Funcionario : Persona
    {
        #region Campos
        private int idFuncionario;
        private int idPersonafuncionario;
        private string puestoTrabajo;
        private EstadoPersona estado_funcionario;
        #endregion

        #region Constructor

        public Funcionario() { 
        }
        public Funcionario(int _idPersona)
            : base(_idPersona){ }
       
        #endregion

        #region Propiedad
        public int IdFuncionario
        {
            get { return idFuncionario; }
            set { idFuncionario = value; }
        }
        public int IdPersonafun
        {
            get { return idPersonafuncionario; }
            set { idPersonafuncionario = value; }
        }
        public string PuestoTrabajo
        {
            get { return puestoTrabajo; }
            set { puestoTrabajo = value; }
        }

        public EstadoPersona Estado_funcionario
        {
            get { return estado_funcionario; }
            set { estado_funcionario = value; }
        }
        #endregion

    }
}
