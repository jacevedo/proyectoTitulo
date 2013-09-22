using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectsBeans
{
   public class Accesos
   {
       #region Campos
       private int codAcceso;
       private string descripcionAcceso;
       #endregion

       #region Constructor
       public Accesos(){
       }
       #endregion

       #region Propiedades
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
