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
   public  class ClientWsAdminUsuario
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

        #region Metodos 
       
        #region ListarPacientePersona

        public List<Persona> ListarPacientePersona()
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":9}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPersonas").ToList();
                foreach (var item in token)
                {
                    Persona persona = new Persona();
                    //{"idPaciente":1,"nomPersona":"Ada","appPersona":"Tatus"}
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    persona.Nombre = item.SelectToken("nomPersona").ToString() + item.SelectToken("appPersona").ToString();
                    list.Add(persona);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return list;
        }
        #endregion

        #region ListarOdontologoPersona
        public List<Persona> ListarOdontologoPersona()
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":10}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPersonas").ToList();
                foreach (var item in token)
                {
                    Persona persona = new Persona();
                    //{"idOdontologo":2,"nomPersona":"Ada","appPersona":"Tatus"}
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
                    persona.Nombre = item.SelectToken("nomPersona").ToString() + item.SelectToken("appPersona").ToString();
                    list.Add(persona);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return list;
        }
        #endregion

        #endregion

    }
}
