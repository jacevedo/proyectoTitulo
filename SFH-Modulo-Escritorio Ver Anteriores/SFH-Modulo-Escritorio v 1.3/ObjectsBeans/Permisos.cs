using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
    public class Permisos : Perfil
    {
        #region Campos
        private int idPerfilAccesos;
        private int codAcceso;
        private string descripcionAcceso;
        #endregion

        #region Constructor
        public Permisos() { }
        public Permisos(int _idPerfil) : base(_idPerfil) { }
        #endregion

        #region Propiedades

        public int IdPerfilAccesos
        {
            get { return idPerfilAccesos; }
            set { idPerfilAccesos = value; }
        }

        public int CodAcceso
        {
            get { return codAcceso; }
            set { codAcceso = value; }
        }

        public string DescripcionAcceso
        {
            get { return descripcionAcceso; }
            set { descripcionAcceso = value; }
        }
        #endregion
    }
}
