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
   public class ClientWsAddUsuario
    {
        /*
         *Contiene la opciones para insertar, listar y modificar
         *Personas, Ododntologos, Funcionario, Pacientes
         *Opciones:
         * 1.- insertar Usuario con datos de Contacto
         * 2.- buscar Usuario por rut
         * 3.- listar Region
         * 4.- listar Comuna por Region
         * 5.- modificar Usuario
         * 6.- buscar comuna por id
         */
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

        #region InsertarPersona
        public string insertarPersonaDatosdeContacto(Persona persona, Datoscontacto datoscontacto,Pass pass)
        {
            string personaInsertada = string.Empty;
            String fechaNacimiento = persona.FechaNacimiento.Year + "-" + persona.FechaNacimiento.Month + "-" + persona.FechaNacimiento.Day;
            String fechaIngreso = datoscontacto.FechaIngreso.Year + "-" + datoscontacto.FechaIngreso.Month + "-" + datoscontacto.FechaIngreso.Day;
            String fechaCaducidad = pass.FechaCaducidad.Year + "-" + pass.FechaCaducidad.Month + "-" + pass.FechaCaducidad.Day;
            //{"indice":1,"idPerfil":4,"rut":17897359,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12",    "pass":"asdcasco","idComuna":2,"fonoFijo":"0227780184","celular":"+56976087240","Direccion":"antonio Varas 666","mail":"asd@asd.com","fechaIngreso":"2013-02-02"}
            this.JsonParam = "send={\"indice\":1,\"idPerfil\":" + persona.IdPerfil + ",\"rut\":" + persona.Rut + ",\"dv\":" + persona.Dv + ",\"nombre\":\"" + persona.Nombre + "\",\"appPaterno\":\"" + persona.ApellidoPaterno + "\",\"appMaterno\":\"" + persona.ApellidoMaterno + "\",\"fechaNac\":\"" + fechaNacimiento + "\",\"pass\":\"" + pass.Passtext + "\",\"idComuna\":" + datoscontacto.IdComuna + ",\"fonoFijo\":\"" + datoscontacto.FonoFijo + "\",\"celular\":\"" + datoscontacto.FonoCelular + "\",\"Direccion\":\"" + datoscontacto.Direccion + "\",\"mail\":\"" + datoscontacto.Mail + "\",\"fechaIngreso\":\"" + fechaIngreso + "\",\"fechaCaducidad\":\""+fechaCaducidad+"\"}";
            try
            {
                String result = netclient.NetPost("ws-add-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //Retorna {"idPersonaInsertada":id};	
                personaInsertada = jobject.SelectToken("resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Persona");
            }
            return personaInsertada;
        }
        #endregion

        #region ListarRegiones 
        public List<RegionContacto> ListarRegiones()
        {
            List<RegionContacto> list = new List<RegionContacto>();
            try
            {
                this.JsonParam = "send={\"indice\":3}";
                String result = netclient.NetPost("ws-add-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaRegiones").ToList();
                foreach (var item in token)
                {
                    RegionContacto region = new RegionContacto();
                    //{"idRegion":1,"nombreRegion":"REGI\u00d3N DE TARAPAC\u00c1","numeroRegionRomano":"I"}
                    region.IdRegion = Convert.ToInt32(item.SelectToken("idRegion").ToString());
                    region.NombreRegion = item.SelectToken("nombreRegion").ToString();
                    region.NumeroRegionRomano = item.SelectToken("numeroRegionRomano").ToString();
                    list.Add(region);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Region");
            }
            return list;
        }
        #endregion

        #region ListarComunaIdRegiones
        public List<Comuna> ListarComunaIdRegiones(int id_region)
        {
            List<Comuna> list = new List<Comuna>();
            try
            {
                this.JsonParam = "send={\"indice\":4,\"idRegion\":"+id_region+"}";
                String result = netclient.NetPost("ws-add-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaComuna").ToList();
                foreach (var item in token)
                {
                    Comuna comuna = new Comuna();
                    //{"idComuna":297,"idRegion":13,"nombreComuna":"Cerro Navia"}
                    comuna.IdComuna = Convert.ToInt32(item.SelectToken("idComuna").ToString());
                    comuna.IdRegion = Convert.ToInt32(item.SelectToken("idRegion").ToString());
                    comuna.NombreComuna = item.SelectToken("nombreComuna").ToString();
                    list.Add(comuna);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Comuna");
            }
            return list;
        }
        #endregion

        #region ModificarPersona
        public string ModificarPersona(Persona persona, Datoscontacto datoscontacto, Pass pass)
        {
            string fechaNacimiento = persona.FechaNacimiento.Year + "-" + persona.FechaNacimiento.Month + "-" + persona.FechaNacimiento.Day;
            string fechaIngreso = datoscontacto.FechaIngreso.Year + "-" + datoscontacto.FechaIngreso.Month + "-" + datoscontacto.FechaIngreso.Day;
            string personaModificada = string.Empty;
            // {"indice":5,"idPersona":1,"idPerfil":4,"rut":17897359,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12","idComuna":2,"fonoFijo":"0227780184","celular":"+56976087240","direccion":"antonio Varas 666","mail":"asd@asd.com","fechaIngreso":"2013-02-02"}
            this.JsonParam = "send={\"indice\":5,\"idPersona\":" + persona.IdPersona + ",\"idPerfil\":" + persona.IdPerfil + ",\"rut\":" + persona.Rut + ",\"dv\":" + persona.Dv + ",\"nombre\":\"" + persona.Nombre + "\",\"appPaterno\":\"" + persona.ApellidoPaterno + "\",\"appMaterno\":\"" + persona.ApellidoMaterno + "\",\"fechaNac\":\"" + fechaNacimiento + "\",\"pass\":\"" + pass.Passtext + "\",\"idComuna\":" + datoscontacto.IdComuna + ",\"fonoFijo\":\"" + datoscontacto.FonoFijo + "\",\"celular\":\"" + datoscontacto.FonoCelular + "\",\"Direccion\":\"" + datoscontacto.Direccion + "\",\"mail\":\"" + datoscontacto.Mail + "\",\"fechaIngreso\":\"" + fechaIngreso + "\"}";
            try
            {
                String result = netclient.NetPost("ws-add-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //Retorna {"idPersonaInsertada":id};	
                personaModificada = jobject.SelectToken("resultadoPersona").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al modificar Persona");
            }
            return personaModificada;
        }
        #endregion
        //{"code":9,"resultado":{"idPersona":1,"idComuna":2,"fonoFijo":"+567685932","fonoCelular":"+343849482","direccion":"antonio varas 666","mail":"varas@varas.cl","fechaIngreso":"2013-08-02"}}
        #region ListarComunaIdRegiones
        public List<Datoscontacto> ListarDatosDeContacto(int persona)
        {
            List<Datoscontacto> list = new List<Datoscontacto>();
            try
            {
                this.JsonParam = "send={\"indice\":9,\"idPersona\":" + persona+ "}";
                String result = netclient.NetPost("ws-add-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("resultado").ToList();
                Datoscontacto datos = new Datoscontacto();
                foreach (var item in token)
                {
                    
                    //{"code":9,"resultado":{"idPersona":1,"idComuna":2,"fonoFijo":"+567685932","fonoCelular":"+343849482","direccion":"antonio varas 666","mail":"varas@varas.cl","fechaIngreso":"2013-08-02"}}
                    datos.IdPersona_dat = int.Parse(item.SelectToken("idPersona").ToString());
                    datos.IdComuna = Convert.ToInt32(item.SelectToken("idComuna").ToString());
                    datos.FonoFijo = item.SelectToken("fonoFijo").ToString();
                    datos.FonoCelular = item.SelectToken("fonoCelular").ToString();
                    datos.Direccion = item.SelectToken("direccion").ToString();
                    datos.Mail = item.SelectToken("mail").ToString();
                    datos.FechaIngreso = Convert.ToDateTime(item.SelectToken("fechaIngreso").ToString());
                    list.Add(datos);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Datos de contacto");
            }
            return list;
        }
        #endregion
    }
}
