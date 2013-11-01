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

        #region InsertarDatos
        public string InsertarDatosdeContacto(Datoscontacto datos)
        {
            string datosInsertado = string.Empty;
            String fechaIngreso = datos.FechaIngreso.Year + "-" + datos.FechaIngreso.Month + "-" + datos.FechaIngreso.Day;
            //{"indice":4,"idPersona":17,"idComuna":21,"fonoFijo":"+976509346","fonoCelular":"+56984678325","direccion":"San Martin","mail":"ada@gmail.com","fechaIngreso":"2013-10-09"}
            this.JsonParam = "send={\"indice\":4,\"idPersona\":"+datos.IdPersona_dat + ",\"idComuna\":"+datos.IdComuna+",\"fonoFijo\":\""+datos.FonoFijo+"\",\"fonoCelular\":\""+datos.FonoCelular+"\",\"direccion\":\""+datos.Direccion+"\",\"mail\":\""+datos.Mail+"\",\"fechaIngreso\":\""+fechaIngreso+"\"}";
            try
            {
                String result = netclient.NetPost("ws-pass-datos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                datosInsertado = jobject.SelectToken("Resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Datos de Contacto");
            }
            return datosInsertado;
        }
        #endregion

        #region ModificarDatos
        public string ModificarDatosdeContacto(Datoscontacto datos)
        {
            string datosModificados = string.Empty;
            String fechaIngreso = datos.FechaIngreso.Year + "-" + datos.FechaIngreso.Month + "-" + datos.FechaIngreso.Day;
            //{"indice":5,"idPersona":17,"idComuna":21,"fonoFijo":"+976509346","fonoCelular":"+56984678325","direccion":"San Agustin","mail":"ada@hotmail.com","fechaIngreso":"2013-10-10"}
            this.JsonParam = "send={\"indice\":5,\"idPersona\":" + datos.IdPersona_dat + ",\"idComuna\":" + datos.IdComuna + ",\"fonoFijo\":\"" + datos.FonoFijo + "\",\"fonoCelular\":\"" + datos.FonoCelular + "\",\"direccion\":\"" + datos.Direccion + "\",\"mail\":\"" + datos.Mail + "\",\"fechaIngreso\":\"" + fechaIngreso + "\"}";
            try
            {
                String result = netclient.NetPost("ws-pass-datos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                datosModificados = jobject.SelectToken("Resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Datos de Contacto");
            }
            return datosModificados;
        }
        #endregion
    }
}
