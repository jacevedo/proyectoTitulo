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

        public Session RecuperarSession(string rut, string pass)
        {
            Session session = new Session();
            String result;
            try {
                
                this.JsonParam = "{\"indice\":3,\"usuario\":"+rut+",\"pass\":\""+pass+"\"}";
                result = netclient.NetPost("ws-login.php", this.JsonParam);
                if (result!="{\"resultado\":\"\"}")
                {
                   var jobject = JObject.Parse(result);
                   if (jobject.SelectToken("resultado").SelectToken("habilitado").ToString() == "Usuario Habilitado")
                   {

                       session.Id_persona = Convert.ToInt32(jobject.SelectToken("resultado").SelectToken("idPersona").ToString());
                       session.Id_odontologo = Convert.ToInt32(jobject.SelectToken("resultado").SelectToken("idOdontologo").ToString());
                       session.Key = jobject.SelectToken("resultado").SelectToken("key").ToString();
                       session.Cod_acceso = Convert.ToInt32(jobject.SelectToken("resultado").SelectToken("codAcceso").ToString());
                       session.Habilitado = jobject.SelectToken("resultado").SelectToken("habilitado").ToString();
                       session.Rut = rut;
                       session.Secdat = true;
                       SharedPreferences.preferences.Key = session.Key;
                   }
                   else
                   {
                       session.Secdat = true;
                       session.Habilitado = jobject.SelectToken("resultado").SelectToken("habilitado").ToString();
                   }
                }
                else
                   {
                       session = this.RecuperarSessionAsistente(rut,pass);
                       session.Secdat = false;
                   }
                }
            
            catch (Exception e){
                session.Secdat = false;

                throw new Exception("Se produjo un error, vuelva a intentarlo." + e);
            }
            
             return session;
        }

        #endregion

        #region RecuperarSessionAsistente
        public Session RecuperarSessionAsistente(string rut, string pass) {
            Session session = new Session();
            try
            {
                this.JsonParam = "{\"indice\":2,\"usuario\":" + rut + ",\"pass\":\"" + pass + "\"}";
                String result = netclient.NetPost("ws-login.php", this.JsonParam);
                if (result != "{\"resultado\":\"\"}")
                {
                    var jobject = JObject.Parse(result);
                    if (jobject.SelectToken("resultado").SelectToken("habilitado").ToString() == "Usuario Habilitado")
                    {
                        session.Id_persona = Convert.ToInt32(jobject.SelectToken("resultado").SelectToken("idPersona").ToString());
                        session.Key = jobject.SelectToken("resultado").SelectToken("key").ToString();
                        session.Cod_acceso = Convert.ToInt32(jobject.SelectToken("resultado").SelectToken("codAcceso").ToString());
                        session.Habilitado = jobject.SelectToken("resultado").SelectToken("habilitado").ToString();
                        session.Rut = rut;
                        session.Secdat = true;
                        SharedPreferences.preferences.Key = session.Key;
                    }
                    else {
                        session.Secdat = true;
                        session.Habilitado = jobject.SelectToken("resultado").SelectToken("habilitado").ToString();
                    }
                }
                else
                {
                    session.Secdat = false;
                }
            }

            catch
            {
                session.Secdat = false;
                throw new Exception("Error al intentar iniciar session :( ... Vuelva a intentarlo ");
            }

            return session;
        
        }
        #endregion

        #region RecuperarDatosDeUsuarioConectado
        public Persona RecuperarDatosDeUsuarioConectado(string rut)
        {
            Persona persona = new Persona();
            try {
                this.JsonParam = "{\"indice\":2,\"rut\":"+rut+"}";
                String result = netclient.NetPost("ws-add-usuario.php", this.JsonParam);
                if (result!="{\"code\":2}")
                {
                var jobject = JObject.Parse(result);
                persona.Rut = Convert.ToInt32(jobject.SelectToken("datosPersona").SelectToken("rut").ToString());
                persona.Nombre = jobject.SelectToken("datosPersona").SelectToken("nombre").ToString();
                persona.ApellidoPaterno = jobject.SelectToken("datosPersona").SelectToken("apellidoPaterno").ToString();
                persona.ApellidoMaterno = jobject.SelectToken("datosPersona").SelectToken("apellidoMaterno").ToString();
                }else{
                    persona.Nombre = "Sin Nombre";
                    persona.Rut = 212;
                  }
                }
            
            catch(Exception ){
                persona.Nombre = "Sin Nombre";
                persona.Rut = 212;
                throw new Exception("Error al intentar iniciar session :( ... Vuelva a intentarlo ");
            }
            
             return persona;
        }

        #endregion
        
    }
}
