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
    public class ClientWsPassDatosdeContacto
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

        /*
       *Contiene la opciones para insertar, listar y modificar
       *Tratamientos y Abonos
       *Opciones:
       * 1.- insertar pass
       * 2.- Modificar pass
       * 3.- Listar pass por idPersona
       * 4.- Insertar Datos Contacto
       * 5.- Modificar Datos Contacto
       * 6.- Buscar Datos por idPersona
       */
        #region InsertarPass
        public string InsertarPass(Pass pass)
        {
            string passInsertada = string.Empty;
            String fechaCaducidad = pass.FechaCaducidad.Year + "-" + pass.FechaCaducidad.Month + "-" + pass.FechaCaducidad.Day;
            //{"indice":1,"idPersona":3,"pass":"asdasd","fechaCaducidad":"2013-12-12"}
            this.JsonParam = "send={\"indice\":1,\"idPersona\":" + pass.IdPersona + ",\"pass\":\"" + pass.Passtext + "\",\"fechaCaducidad\":\"" + fechaCaducidad + "\"}";
            try
            {
                String result = netclient.NetPost("ws-pass-datos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                passInsertada = jobject.SelectToken("Resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Pass");
            }
            return passInsertada;
        }
        #endregion

        #region ModificarPass
        public string ModificarPass(Pass pass)
        {
            string passInsertada = string.Empty;
              String fechaCaducidad = pass.FechaCaducidad.Year + "-" + pass.FechaCaducidad.Month + "-" + pass.FechaCaducidad.Day;
            //{"indice":2,"idPersona":3,"pass":"asdasd","fechaCaducidad":"2013-12-12"}
            this.JsonParam = "send={\"indice\":2,\"idPersona\":" + pass.IdPersona + ",\"pass\":\"" + pass.Passtext + "\",\"fechaCaducidad\":\"" + fechaCaducidad + "\"}";
            try
            {
                String result = netclient.NetPost("ws-pass-datos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                passInsertada = jobject.SelectToken("Resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Modificarr Pass");
            }
            return passInsertada;
        }
        #endregion






    }
}
