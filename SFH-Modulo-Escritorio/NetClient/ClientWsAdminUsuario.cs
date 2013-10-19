
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
* 2.- insertar Odontologo
* 3.- insertar Paciente
* 4.- insertar Funcionario
* 5.- modificarPersona
* 6.- modificar Odontologo
* 7.- modificar Paciente
* 8.- modificar Funcionario
* 9.- desabilitar Paciente
* 10 .- desabilitar Odontologo
* 11.- desabilitar Funcionario
* 12.- Listar Personas
* 13.- Listar Paciente-
* 14.- Listar Odontologo-
* 15.- Listar Funcionario-
* 16.- Listar Pacientes Herencia
* 17.- Listar Odontologo Herencia
* 18.- Listar Funcionario Herencia
        */
        #region InsertarPersona
        public string InsertarPersona(Persona persona) {
            string personaInsertada = string.Empty;
            //{"indice":1,"idPerfil":1,"rut":17897359,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12"}
            this.JsonParam = "send={\"indice\":1,\"idPerfil\":"+persona.IdPerfil+",\"rut\":"+persona.Rut+",\"dv\":"+persona.Dv+",\"nombre\":\""+persona.Nombre+"\",\"appPaterno\":\""+persona.ApellidoPaterno+"\",\"appMaterno\":\""+persona.ApellidoMaterno+"\",\"fechaNac\":\""+persona.FechaNacimiento+"\"}";
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

        #region InsertarOdontolo
        public string InsertarOdontolo(Odontologo odontologo) {

            string odontologoInsertado = string.Empty;
            //{"indice":2,"idPersona":1,"especialidad":"Cirugia","habilitado":1}
            this.JsonParam = "send={\"indice\":2,\"idPersona\":"+odontologo.IdPersona+",\"especialidad\":\""+odontologo.Especialidad+"\",\"habilitado\":1}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                odontologoInsertado = jobject.SelectToken("idOdontologoInsertado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Odontologo");
            }
            return odontologoInsertado;
        }
        #endregion

        #region InsertarPaciente
        public string InsertarPaciente(Paciente paciente) {
            string pacienteInsertado = string.Empty;
            //{"indice":3,"idPersona":1,"fechaIngreso":"2013-04-12","habilitado":1}
            this.JsonParam = "send={\"indice\":3,\"idPersona\":"+paciente.IdPersona+",\"fechaIngreso\":\""+paciente.FechaIngreso+"\",\"habilitado\":1}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                pacienteInsertado = jobject.SelectToken("idPacienteInsertado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Paciente");
            }
            return pacienteInsertado;
        }
        #endregion

        #region InsertarFuncionario
        public string InsertarFuncionario(Funcionario funcionario) {
            string funcionarioInsertado = string.Empty;
            //{"indice":4,"idPersona":1,"puestoTrabajo":"Administrador","habilitado":1}
            this.JsonParam = "send={\"indice\":4,\"idPersona\":"+funcionario.IdPersona+",\"puestoTrabajo\":\""+funcionario.PuestoTrabajo+"\",\"habilitado\":1}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                funcionarioInsertado = jobject.SelectToken("idFuncionarioInsertado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Funcionario");
            }
            return funcionarioInsertado;
        }
        #endregion

        #region ModificarPersona
        public string ModificarPersona(Persona persona)
        {
            string personaModificado = string.Empty;
            //{"indice":5,"idPersona":20,"idPerfil":1,"rut":11111111,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12"}
            this.JsonParam = "send={\"indice\":5,\"idPersona\":"+persona.IdPersona+",\"idPerfil\":" + persona.IdPerfil + ",\"rut\":" + persona.Rut + ",\"dv\":" + persona.Dv + ",\"nombre\":\"" + persona.Nombre + "\",\"appPaterno\":\"" + persona.ApellidoPaterno + "\",\"appMaterno\":\"" + persona.ApellidoMaterno + "\",\"fechaNac\":\"" + persona.FechaNacimiento + "\"}";
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

        #region ModificarOdontologo
        public string ModificarOdontologo(Odontologo odontologo)
        {
            string odontologoModificado = string.Empty;
            //{"indice":6,"idOdontologo":2,"idPersona":1,"especialidad":"Cirugia"}
            this.JsonParam = "send={\"indice\":6,\"idOdontologo\":"+odontologo.IdOdontologo+",\"idPersona\":" + odontologo.IdPersona + ",\"especialidad\":\"" + odontologo.Especialidad + "\",\"habilitado\":1}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //resultado
                odontologoModificado = jobject.SelectToken("resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Modificar Odontologo");
            }
            return odontologoModificado;
        }
        #endregion

        #region ModificarPaciente
        public string ModificarPaciente(Paciente paciente)
        {
            string pacienteModificado = string.Empty;
            //{"indice":7,"idPaciente":1,"idPersona":1,"fechaIngreso":"2013-04-12"}
            this.JsonParam = "send={\"indice\":7,\"idPaciente\":"+paciente.IdPaciente+",\"idPersona\":" + paciente.IdPersona + ",\"fechaIngreso\":\"" + paciente.FechaIngreso + "\",\"habilitado\":1}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //resultado
                pacienteModificado = jobject.SelectToken("resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Modificar Odontologo");
            }
            return pacienteModificado;
        }
        #endregion

        #region ModificarFuncionario
        public string ModificarFuncionario(Funcionario funcionario)
        {
            string funcionarioModifcar = string.Empty;
            //{"indice":8,"idFuncionario":2,"idPersona":1,"puestoTrabajo":"Administrador"}
            this.JsonParam = "send={\"indice\":8,\"idFuncionario\":"+funcionario.IdFuncionario+",\"idPersona\":" + funcionario.IdPersona + ",\"puestoTrabajo\":\"" + funcionario.PuestoTrabajo + "\",\"habilitado\":1}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                funcionarioModifcar = jobject.SelectToken("resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Modificar Funcionario");
            }
            return funcionarioModifcar;
        }
        #endregion
       
        #region desabilitarHabilitarPaciente

        public string DesabilitarHabilitarPaciente(Paciente paciente)
        {
            string pacienteModificado = string.Empty;
            //{"indice":9,"idPaciente":1,"habilitado":1}
            this.JsonParam = "send={\"indice\":9,\"idPaciente\":"+paciente.IdPaciente+",\"habilitado\":"+paciente.HabilitadoPaciente+"}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //resutadoHabilitar
                pacienteModificado = jobject.SelectToken("resutadoHabilitar").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al desabilitar paciente");
            }
            return pacienteModificado;
        }
       #endregion

        #region desabilitarHabilitarOdontologo

        public string DesabilitarHabilitarOdontologo(Odontologo odontologo)
        {
            string odontologoModificado = string.Empty;
            //{"indice":9,"idPaciente":1,"habilitado":1}
            this.JsonParam = "send={\"indice\":10,\"idOdontologo\":"+odontologo.IdOdontologo+",\"habilitado\":1}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //resutadoHabilitar
                odontologoModificado = jobject.SelectToken("resutadoHabilitar").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al desabilitar odontologo");
            }
            return odontologoModificado;
        }
        #endregion

        #region desabilitarHabilitarFuncionario

        public string DesabilitarHabilitarFuncionario(Funcionario funcionario)
        {
            string funcionarioModificado = string.Empty;
            //{"indice":9,"idPaciente":1,"habilitado":1}
            this.JsonParam = "send={\"indice\":11,\"idFuncionario\":"+funcionario.IdFuncionario+",\"isDesabilitado\":"+funcionario.Estado_funcionario+"}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //resutadoHabilitar
                funcionarioModificado = jobject.SelectToken("resutadoHabilitar").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al desabilitar funcionario");
            }
            return funcionarioModificado;
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

        #region ListarPacientes
        public List<Paciente> ListarPacientes()
        {
            List<Paciente> list = new List<Paciente>();
            try
            {
                this.JsonParam = "send={\"indice\":16}";
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPacienteHerencia").ToList();
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
                    else if(estado.Equals(1)){
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

        #region ListarOdontologo
        public List<Odontologo> ListarOdontologo()
        {
            List<Odontologo> list = new List<Odontologo>();
            try
            {
                this.JsonParam = "send={\"indice\":17}";
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaOdontologoHerencia").ToList();
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

        #region ListarFuncionario
        public List<Funcionario> ListarFuncionario()
        {
            List<Funcionario> list = new List<Funcionario>();
            try
            {
                this.JsonParam = "send={\"indice\":18}";
                String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaFuncionarioHerencia").ToList();
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
