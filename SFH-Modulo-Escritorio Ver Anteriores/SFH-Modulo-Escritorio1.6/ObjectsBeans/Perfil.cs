using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Perfil
    {
        #region Campos
        private int idPerfil;
        private string nomPerfil;
        #endregion

        #region Constructor
        public Perfil() { }
        public Perfil(int _idperfil) {
            this.IdPerfil = _idperfil;
        }
        #endregion

        #region Propiedad

        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        public string NomPerfil
        {
            get { return nomPerfil; }
            set { nomPerfil = value; }
        }
        #endregion
    }
}
