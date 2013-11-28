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
    public class ClientWsAdminUsuarioSig
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
         * 1.- Buscar Persona Por Rut
         * 2.- Buscar Persona Por Nombre
         * 3.- Buscar Funcionario Por Rut
         * 4.- Buscar Funcionario Por Nombre Apellido
         * 5.- Buscar Paciente Por Rut
         * 6.- Buscar Paciente Por Nombre Apellido
         * 7.- Buscar Odontologo Por Rut
         * 8.- Buscar Odontologo Por Nombre Apellido
         * 9.- Listar Personas id nombre
         */
        #region Buscar Persona Por Rut
        public List<Persona> BuscarPersonaPorRut(string rut,string dv)
        {
            List<Persona> list = new List<Persona>();

            try
            {
                //{"indice":1,"rut":17897359,"dv":2}
                this.JsonParam ="send={\"indice\":1,\"rut\":"+rut+",\"dv\":"+dv+"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPersonaRut").ToList();
                foreach (var item in token)
                {
                    Persona persona = new Persona();
                    //{"idPersona":15,"idPerfil":1,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"},
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = persona.IdPerfil;
                    switch (num_perfil)
                    {
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
                    persona.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
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
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return list;
        }
        #endregion

        #region Buscar Persona Por Nombre
        public List<Persona> BuscarPersonaPorNombre(string nombre,string apellido)
        {
            List<Persona> list = new List<Persona>();

            try
            {
                String result = netclient.NetPost("ws-admin-usuario-sig.php", "send={\"indice\":2,\"nomPersona\":\""+nombre+"\",\"appPersona\":\""+apellido+"\"}");
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("busquedaPersonaNombre").ToList();
                foreach (var item in token)
                {
                    Persona persona = new Persona();
                    //{"idPersona":15,"idPerfil":1,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"},
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = persona.IdPerfil;
                    switch (num_perfil)
                    {
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
                    persona.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
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
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return list;
        }
        #endregion

        #region Buscar Funcionario Por Rut
        public List<Persona> BuscarFuncionarioPorRut(string rut)
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":3,\"rut\":"+rut+"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaFuncionarioRut").ToList();
                foreach (var item in token)
                {
                    Persona persona = new Persona();
                    //{"idPersona":15,"idPerfil":1,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"},
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = persona.IdPerfil;
                    switch (num_perfil)
                    {
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
                    persona.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
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
                throw new Exception(e + "| Error al Listar Funcionario");
            }
            return list;
        }
        #endregion

        #region Buscar Funcionario Por Nombre Apellido
        public List<Persona> BuscarFuncionarioPorNombreApellido(string nombre, string apellido)
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":4,\"nombre\":\""+nombre+"\",\"apellido\":\""+apellido+"\"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarFuncionarioNombre").ToList();
                foreach (var item in token)
                {
                    Persona persona = new Persona();
                    //{"idPersona":15,"idPerfil":1,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"},
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = persona.IdPerfil;
                    switch (num_perfil)
                    {
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
                    persona.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
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
                throw new Exception(e + "| Error al Listar Funcionario");
            }
            return list;
        }
        #endregion

        #region Buscar Paciente Por Rut
        public List<Persona> BuscarPacientePorRut(string rut)
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":5,\"rut\":"+rut+"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarPacienteRut").ToList();
                foreach (var item in token)
                {

                    Persona persona = new Persona();
                    //{"idPersona":15,"idPerfil":1,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"},
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = persona.IdPerfil;
                    switch (num_perfil)
                    {
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
                    persona.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
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
                throw new Exception(e + "| Error al Listar Pacientes");
            }
            return list;
        }
        #endregion

        #region Buscar Paciente Por Nombre Apellido
        public List<Persona> BuscarPacientePorNombreApellido(string nombre, string apellido)
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":6,\"nombre\":\""+nombre+"\",\"apellido\":\""+apellido+"\"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarPacienteNombre").ToList();
                foreach (var item in token)
                {
                    Persona persona = new Persona();
                    //{"idPersona":15,"idPerfil":1,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"},
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = persona.IdPerfil;
                    switch (num_perfil)
                    {
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
                    persona.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
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
                throw new Exception(e + "| Error al Listar Pacientes");
            }
            return list;
        }
        #endregion

        #region Buscar Odontologo Por Rut
        public List<Persona> BuscarOdontologoPorRut(string rut)
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":7,\"rut\":"+rut+"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarOdontologoRut").ToList();
                foreach (var item in token)
                {

                    Persona persona = new Persona();
                    //{"idPersona":15,"idPerfil":1,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"},
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = persona.IdPerfil;
                    switch (num_perfil)
                    {
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
                    persona.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
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
                throw new Exception(e + "| Error al Listar Odontologo");
            }
            return list;
        }
        #endregion

        #region Buscar Odontologo Por Nombre Apellido
        public List<Persona> BuscarOdontologoPorNombreApellido(string nombre, string apellido)
        {
            List<Persona> list = new List<Persona>();
            try
            {
                this.JsonParam = "send={\"indice\":8,\"nombre\":\""+nombre+"\",\"apellido\":\""+apellido+"\"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarOdontologoNombre").ToList();
                foreach (var item in token)
                {

                    Persona persona = new Persona();
                    //{"idPersona":15,"idPerfil":1,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"},
                    persona.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = persona.IdPerfil;
                    switch (num_perfil)
                    {
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
                    persona.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
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
                throw new Exception(e + "| Error al Listar Odontologo");
            }
            return list;
        }
        #endregion

        #endregion
    }
}
