
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
       
        /*
* 1.- insertar Persona

* 5.- modificarPersona
* 7.- modificar Paciente
* 9.- desabilitar Paciente
* 12.- Listar Personas
* 13.- Listar Paciente-
* 15.- Listar Funcionario-
* 16.- Listar Pacientes Herencia
        */
        #region InsertarPersona
        public string InsertarPersona(Persona persona) {
            string personaInsertada = string.Empty;
            String fechaNacimiento = persona.FechaNacimiento.Year + "-" + persona.FechaNacimiento.Month + "-" + persona.FechaNacimiento.Day;
            //{"indice":1,"idPerfil":1,"rut":17897359,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12"}
            this.JsonParam = "send={\"indice\":1,\"idPerfil\":"+persona.IdPerfil+",\"rut\":"+persona.Rut+",\"dv\":"+persona.Dv+",\"nombre\":\""+persona.Nombre+"\",\"appPaterno\":\""+persona.ApellidoPaterno+"\",\"appMaterno\":\""+persona.ApellidoMaterno+"\",\"fechaNac\":\""+fechaNacimiento+"\"}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                personaInsertada = jobject.SelectToken("idPersonaInsertada").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Persona");
            }
            return personaInsertada;
        }
        #endregion

        #region ModificarPersona
        public string ModificarPersona(Persona persona)
        {
            string personaModificado = string.Empty;
            String fechaNacimiento = persona.FechaNacimiento.Year + "-" + persona.FechaNacimiento.Month + "-" + persona.FechaNacimiento.Day;
            //{"indice":5,"idPersona":20,"idPerfil":1,"rut":11111111,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12"}
            this.JsonParam = "send={\"indice\":5,\"idPersona\":"+persona.IdPersona+",\"idPerfil\":" + persona.IdPerfil + ",\"rut\":" + persona.Rut + ",\"dv\":" + persona.Dv + ",\"nombre\":\"" + persona.Nombre + "\",\"appPaterno\":\"" + persona.ApellidoPaterno + "\",\"appMaterno\":\"" + persona.ApellidoMaterno + "\",\"fechaNac\":\"" + fechaNacimiento + "\"}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //resultado
                personaModificado = jobject.SelectToken("resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Modificar Persona");
            }
            return personaModificado;
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

        #region ListarPersonas
        public List<Persona> ListarPersonas()
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":12}";
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
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

        #region ListarDatosPersona
        public List<Persona> ListarDatosPersona()
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":12}";
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPersonas").ToList();
                foreach (var item in token)
                {
                    Persona persona = new Persona();
                    //{"idPersona":15,"idPerfil":1,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"},
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = persona.IdPerfil;
                    switch (num_perfil) { 
                        case 1:
                            persona.Nomperfil = "Administrador";
                            break;
                        case 2:
                            persona.Nomperfil = "Doctor";
                            break;
                        case 3:
                            persona.Nomperfil = "Asistente";
                            break;
                        case 4:
                            persona.Nomperfil = "Paciente";
                            break;
                    
                    }
                    persona.Rut  = Convert.ToInt32(item.SelectToken("rut").ToString());
                    persona.Dv = item.SelectToken("dv").ToString();
                    persona.Nombre = item.SelectToken("nombre").ToString();
                    persona.ApellidoPaterno = item.SelectToken("apellidoPaterno").ToString();
                    persona.ApellidoMaterno = item.SelectToken("apellidoMaterno").ToString();
                    persona.FechaNacimiento = Convert.ToDateTime(item.SelectToken("fechaNacimiento").ToString());
                    list.Add(persona);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Personas");
            }
            return list;
        }
        #endregion

        #region ListarPacientePersonas
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


        #endregion

    }
}
