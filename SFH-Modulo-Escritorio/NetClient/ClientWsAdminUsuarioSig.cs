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
                   /* persona.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
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
                    persona.FechaNacimiento = Convert.ToDateTime(item.SelectToken("fechaNacimiento").ToString());*/
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

                    //{"idPersona":29,"idPerfil":4,"rut":"17897359","dv":"2","nombre":"ada","apellidoPaterno":"wonk","apellidoMaterno":"asturias","fechaNacimiento":"1991-12-12"}}
                    Persona persona = new Persona();
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
        public List<Funcionario> BuscarFuncionarioPorRut(string rut)
        {
            List<Funcionario> list = new List<Funcionario>();
            try
            {
                this.JsonParam = "send={\"indice\":3,\"rut\":"+rut+"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaFuncionarioRut").ToList();
                foreach (var item in token)
                {

                    Funcionario funcionario = new Funcionario();
                    //{"idFuncionario":2,"idPersona":3,"puestoTrabajo":"Asistente Dental",
                    //"funcionarioHabilitado":null,"idPerfil":3,"rut":"9878987","dv":"4","nombre":"Nicolas","apellidoPaterno":"Palma",
                    //"apellidoMaterno":"Silva","fechaNacimiento":"1987-05-27"}
                    funcionario.IdFuncionario = Convert.ToInt32(item.SelectToken("idFuncionario").ToString());
                    funcionario.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    funcionario.PuestoTrabajo = item.SelectToken("puestoTrabajo").ToString();
                    int estado = Convert.ToInt32(item.SelectToken("habilitadoPaciente").ToString());
                    funcionario.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = funcionario.IdPerfil;
                    switch (num_perfil)
                    {
                        case 1:
                            funcionario.Nomperfil = "Administrador";
                            break;
                        case 2:
                            funcionario.Nomperfil = "Doctor";
                            break;
                        case 3:
                            funcionario.Nomperfil = "Asistente";
                            break;
                        case 4:
                            funcionario.Nomperfil = "Paciente";
                            break;

                    }
                    funcionario.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
                    funcionario.Dv = item.SelectToken("dv").ToString();
                    funcionario.Nombre = item.SelectToken("nombre").ToString();
                    funcionario.ApellidoPaterno = item.SelectToken("apellidoPaterno").ToString();
                    funcionario.ApellidoMaterno = item.SelectToken("apellidoMaterno").ToString();
                    funcionario.FechaNacimiento = Convert.ToDateTime(item.SelectToken("fechaNacimiento").ToString());

                    if (estado.Equals(0))
                    {
                        funcionario.Estado_funcionario = EstadoPersona.DESHABILITADO;
                    }
                    else if (estado.Equals(1))
                    {
                        funcionario.Estado_funcionario = EstadoPersona.HABILITADO;
                    }
                    list.Add(funcionario);
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
        public List<Funcionario> BuscarFuncionarioPorNombreApellido(string nombre, string apellido)
        {
            List<Funcionario> list = new List<Funcionario>();
            try
            {
                this.JsonParam = "send={\"indice\":4,\"nombre\":\""+nombre+"\",\"apellido\":\""+apellido+"\"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarFuncionarioNombre").ToList();
                foreach (var item in token)
                {

                    Funcionario funcionario = new Funcionario();
                    //{"idFuncionario":2,"idPersona":3,"puestoTrabajo":"Asistente Dental",
                    //"funcionarioHabilitado":null,"idPerfil":3,"rut":"9878987","dv":"4","nombre":"Nicolas","apellidoPaterno":"Palma",
                    //"apellidoMaterno":"Silva","fechaNacimiento":"1987-05-27"}
                    funcionario.IdFuncionario = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    funcionario.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    funcionario.PuestoTrabajo = item.SelectToken("fechaIngreso").ToString();
                    int estado = Convert.ToInt32(item.SelectToken("habilitadoPaciente").ToString());
                    funcionario.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = funcionario.IdPerfil;
                    switch (num_perfil)
                    {
                        case 1:
                            funcionario.Nomperfil = "Administrador";
                            break;
                        case 2:
                            funcionario.Nomperfil = "Doctor";
                            break;
                        case 3:
                            funcionario.Nomperfil = "Asistente";
                            break;
                        case 4:
                            funcionario.Nomperfil = "Paciente";
                            break;

                    }
                    funcionario.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
                    funcionario.Dv = item.SelectToken("dv").ToString();
                    funcionario.Nombre = item.SelectToken("nombre").ToString();
                    funcionario.ApellidoPaterno = item.SelectToken("apellidoPaterno").ToString();
                    funcionario.ApellidoMaterno = item.SelectToken("apellidoMaterno").ToString();
                    funcionario.FechaNacimiento = Convert.ToDateTime(item.SelectToken("fechaNacimiento").ToString());

                    if (estado.Equals(0))
                    {
                        funcionario.Estado_funcionario = EstadoPersona.DESHABILITADO;
                    }
                    else if (estado.Equals(1))
                    {
                        funcionario.Estado_funcionario = EstadoPersona.HABILITADO;
                    }
                    list.Add(funcionario);
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
        public List<Paciente> BuscarPacientePorRut(string rut)
        {
            List<Paciente> list = new List<Paciente>();
            try
            {
                this.JsonParam = "send={\"indice\":5,\"rut\":"+rut+"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarPacienteRut").ToList();
                foreach (var item in token)
                {

                    Paciente paciente = new Paciente();
                    //"idPaciente":1,"idPersona":1,"fechaIngreso":"2013-04-12",
                    //"habilitadoPaciente":1,"idPerfil":1,"rut":"17231233","dv":"2","nombre":"Ada","apellidoPaterno":"Tatus",
                    //"apellidoMaterno":"Boren","fechaNacimiento":"1991-08-06"
                    paciente.IdPaciente = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    paciente.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    paciente.FechaIngreso = Convert.ToDateTime(item.SelectToken("fechaIngreso").ToString());
                    int estado = Convert.ToInt32(item.SelectToken("habilitadoPaciente").ToString());
                    paciente.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = paciente.IdPerfil;
                    switch (num_perfil)
                    {
                        case 1:
                            paciente.Nomperfil = "Administrador";
                            break;
                        case 2:
                            paciente.Nomperfil = "Doctor";
                            break;
                        case 3:
                            paciente.Nomperfil = "Asistente";
                            break;
                        case 4:
                            paciente.Nomperfil = "Paciente";
                            break;
                    }
                    paciente.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
                    paciente.Dv = item.SelectToken("dv").ToString();
                    paciente.Nombre = item.SelectToken("nombre").ToString();
                    paciente.ApellidoPaterno = item.SelectToken("apellidoPaterno").ToString();
                    paciente.ApellidoMaterno = item.SelectToken("apellidoMaterno").ToString();
                    paciente.FechaNacimiento = Convert.ToDateTime(item.SelectToken("fechaNacimiento").ToString());

                    if (estado.Equals(0))
                    {
                        paciente.HabilitadoPaciente = EstadoPersona.DESHABILITADO;
                    }
                    else if (estado.Equals(1))
                    {
                        paciente.HabilitadoPaciente = EstadoPersona.HABILITADO;
                    }
                    list.Add(paciente);
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
        public List<Paciente> BuscarPacientePorNombreApellido(string nombre, string apellido)
        {
            List<Paciente> list = new List<Paciente>();
            try
            {
                this.JsonParam = "send={\"indice\":6,\"nombre\":\""+nombre+"\",\"apellido\":\""+apellido+"\"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarPacienteNombre").ToList();
                foreach (var item in token)
                {
                    Paciente paciente = new Paciente();
                    //"idPaciente":1,"idPersona":1,"fechaIngreso":"2013-04-12",
                    //"habilitadoPaciente":1,"idPerfil":1,"rut":"17231233","dv":"2","nombre":"Ada","apellidoPaterno":"Tatus",
                    //"apellidoMaterno":"Boren","fechaNacimiento":"1991-08-06"
                    paciente.IdPaciente = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    paciente.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    paciente.FechaIngreso = Convert.ToDateTime(item.SelectToken("fechaIngreso").ToString());
                    int estado = Convert.ToInt32(item.SelectToken("habilitadoPaciente").ToString());
                    paciente.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = paciente.IdPerfil;
                    switch (num_perfil)
                    {
                        case 1:
                            paciente.Nomperfil = "Administrador";
                            break;
                        case 2:
                            paciente.Nomperfil = "Doctor";
                            break;
                        case 3:
                            paciente.Nomperfil = "Asistente";
                            break;
                        case 4:
                            paciente.Nomperfil = "Paciente";
                            break;
                    }
                    paciente.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
                    paciente.Dv = item.SelectToken("dv").ToString();
                    paciente.Nombre = item.SelectToken("nombre").ToString();
                    paciente.ApellidoPaterno = item.SelectToken("apellidoPaterno").ToString();
                    paciente.ApellidoMaterno = item.SelectToken("apellidoMaterno").ToString();
                    paciente.FechaNacimiento = Convert.ToDateTime(item.SelectToken("fechaNacimiento").ToString());

                    if (estado.Equals(0))
                    {
                        paciente.HabilitadoPaciente = EstadoPersona.DESHABILITADO;
                    }
                    else if (estado.Equals(1))
                    {
                        paciente.HabilitadoPaciente = EstadoPersona.HABILITADO;
                    }
                    list.Add(paciente);
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
        public List<Odontologo> BuscarOdontologoPorRut(string rut)
        {
            List<Odontologo> list = new List<Odontologo>();
            try
            {
                this.JsonParam = "send={\"indice\":7,\"rut\":"+rut+"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarOdontologoRut").ToList();
                foreach (var item in token)
                {

                    Odontologo odontologo = new Odontologo();
                    //{"idOdontologo":2,"idPersona":1,"especialidad":"Cirugia","odontologoHabilitado":null,"idPerfil":1,"rut":"17231233","dv":"2",
                    //"nombre":"Ada","apellidoPaterno":"Tatus","apellidoMaterno":"Boren","fechaNacimiento":"1991-08-06"}
                    odontologo.IdOdontologo = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
                    odontologo.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    odontologo.Especialidad = item.SelectToken("especialidad").ToString();
                    int estado = Convert.ToInt32(item.SelectToken("odontologoHabilitado").ToString());
                    odontologo.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = odontologo.IdPerfil;
                    switch (num_perfil)
                    {
                        case 1:
                            odontologo.Nomperfil = "Administrador";
                            break;
                        case 2:
                            odontologo.Nomperfil = "Doctor";
                            break;
                        case 3:
                            odontologo.Nomperfil = "Asistente";
                            break;
                        case 4:
                            odontologo.Nomperfil = "Paciente";
                            break;
                    }
                    odontologo.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
                    odontologo.Dv = item.SelectToken("dv").ToString();
                    odontologo.Nombre = item.SelectToken("nombre").ToString();
                    odontologo.ApellidoPaterno = item.SelectToken("apellidoPaterno").ToString();
                    odontologo.ApellidoMaterno = item.SelectToken("apellidoMaterno").ToString();
                    odontologo.FechaNacimiento = Convert.ToDateTime(item.SelectToken("fechaNacimiento").ToString());

                    if (estado.Equals(0))
                    {
                        odontologo.OdontologoHabilitado = EstadoPersona.DESHABILITADO;
                    }
                    else if (estado.Equals(1))
                    {
                        odontologo.OdontologoHabilitado = EstadoPersona.HABILITADO;
                    }
                    list.Add(odontologo);
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
        public List<Odontologo> BuscarOdontologoPorNombreApellido(string nombre, string apellido)
        {
            List<Odontologo> list = new List<Odontologo>();
            try
            {
                this.JsonParam = "send={\"indice\":8,\"nombre\":\""+nombre+"\",\"apellido\":\""+apellido+"\"}";
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("buscarOdontologoNombre").ToList();
                foreach (var item in token)
                {

                    Odontologo odontologo = new Odontologo();
                    //{"idOdontologo":2,"idPersona":1,"especialidad":"Cirugia","odontologoHabilitado":null,"idPerfil":1,"rut":"17231233","dv":"2",
                    //"nombre":"Ada","apellidoPaterno":"Tatus","apellidoMaterno":"Boren","fechaNacimiento":"1991-08-06"}
                    odontologo.IdOdontologo = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
                    odontologo.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    odontologo.Especialidad = item.SelectToken("especialidad").ToString();
                    int estado = Convert.ToInt32(item.SelectToken("odontologoHabilitado").ToString());
                    odontologo.IdPerfil = Convert.ToInt32(item.SelectToken("idPerfil").ToString());
                    int num_perfil = odontologo.IdPerfil;
                    switch (num_perfil)
                    {
                        case 1:
                            odontologo.Nomperfil = "Administrador";
                            break;
                        case 2:
                            odontologo.Nomperfil = "Doctor";
                            break;
                        case 3:
                            odontologo.Nomperfil = "Asistente";
                            break;
                        case 4:
                            odontologo.Nomperfil = "Paciente";
                            break;
                    }
                    odontologo.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
                    odontologo.Dv = item.SelectToken("dv").ToString();
                    odontologo.Nombre = item.SelectToken("nombre").ToString();
                    odontologo.ApellidoPaterno = item.SelectToken("apellidoPaterno").ToString();
                    odontologo.ApellidoMaterno = item.SelectToken("apellidoMaterno").ToString();
                    odontologo.FechaNacimiento = Convert.ToDateTime(item.SelectToken("fechaNacimiento").ToString());

                    if (estado.Equals(0))
                    {
                        odontologo.OdontologoHabilitado = EstadoPersona.DESHABILITADO;
                    }
                    else if (estado.Equals(1))
                    {
                        odontologo.OdontologoHabilitado = EstadoPersona.HABILITADO;
                    }
                    list.Add(odontologo);
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
