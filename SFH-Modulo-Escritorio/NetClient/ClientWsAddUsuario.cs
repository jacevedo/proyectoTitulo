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
    class ClientWsAddUsuario
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
            //{"indice":1,"idPerfil":4,"rut":17897359,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12",    "pass":"asdcasco","idComuna":2,"fonoFijo":"0227780184","celular":"+56976087240","Direccion":"antonio Varas 666","mail":"asd@asd.com","fechaIngreso":"2013-02-02"}
            this.JsonParam = "send={\"indice\":1,\"idPerfil\":" + persona.IdPerfil + ",\"rut\":" + persona.Rut + ",\"dv\":" + persona.Dv + ",\"nombre\":\"" + persona.Nombre + "\",\"appPaterno\":\"" + persona.ApellidoPaterno + "\",\"appMaterno\":\"" + persona.ApellidoMaterno + "\",\"fechaNac\":\"" + persona.FechaNacimiento + ",\"pass\":\""+pass.Passtext+"\",\"idComuna\":"+datoscontacto.IdComuna+",\"fonoFijo\":\""+datoscontacto.FonoFijo+"\",\"celular\":\""+datoscontacto.FonoCelular+"\",\"Direccion\":\""+datoscontacto.Direccion+"\",\"mail\":\""+datoscontacto.Mail+"\",\"fechaIngreso\":\""+datoscontacto.FechaIngreso+"\"}";
            try
            {
                String result = netclient.NetPost("ws-add-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //Retorna {"idPersonaInsertada":id};	
                personaInsertada = jobject.SelectToken("idPersonaInsertada").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Persona");
            }
            return personaInsertada;
        }
        #endregion

        #region ListarRegiones 
        public List<Region> ListarRegiones()
        {
            List<Region> list = new List<Region>();
            try
            {
                this.JsonParam = "send={\"indice\":3}";
                String result = netclient.NetPost("ws-add-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPersonas").ToList();
                foreach (var item in token)
                {
                    Persona persona = new Persona();
                    //{"idPaciente":1,"nomPersona":"Ada","appPersona":"Tatus"}
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.Nombre = item.SelectToken("nombre").ToString() + item.SelectToken("apellidoPaterno").ToString();
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

    }
}
