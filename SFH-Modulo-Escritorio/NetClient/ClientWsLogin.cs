using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObjectsBeans;

namespace NetClient
{
    public class ClientWsLogin
    {
        #region Campos
        CoreNetClient netclient = new CoreNetClient();
        private string jsonParam;
        #endregion

        #region Propiedades
        public string JsonParam
        {
            get { return jsonParam; }
            set { jsonParam = value; }
        }
        #endregion

        #region RecuperarSession

        public Session RecuperarSession(string rut,string pass) {
            Session session = new Session();
            try {
                
                this.JsonParam = "send={\"indice\":3,\"usuario\":"+rut+",\"pass\":\""+pass+"\"}";
                String result = netclient.NetPost("ws-login.php", this.JsonParam);
                if (result!="{\"resultado\":\"\"}")
                {
                var jobject = JObject.Parse(result);
                    session.Id_persona = Convert.ToInt32(jobject.SelectToken("resultado").SelectToken("idPersona").ToString());
                    session.Id_odontologo = Convert.ToInt32(jobject.SelectToken("resultado").SelectToken("idOdontologo").ToString());
                    session.Key = jobject.SelectToken("resultado").SelectToken("key").ToString();
                    session.Cod_acceso = Convert.ToInt32(jobject.SelectToken("resultado").SelectToken("codAcceso").ToString());
                    session.Habilitado = jobject.SelectToken("resultado").SelectToken("habilitado").ToString();
                    session.Secdat = true;
                }
                else
                   {
                       session.Secdat = false;
                   }
                }
            
            catch(Exception e){
                session.Secdat = false;
                throw new Exception("Error al intentar iniciar session :( ... Vuelva a intentarlo ");
            }
            
             return session;
        }

        #endregion
        
    }
}
