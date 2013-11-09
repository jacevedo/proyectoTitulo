﻿using System;
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

   public class ClientWsPaciente
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

       #region InsertarPaciente
        public string InsertarPaciente(Paciente paciente)
        {
            string pacienteInsertado = string.Empty;
            //{"indice":3,"idPersona":1,"fechaIngreso":"2013-04-12","habilitado":1}
            String fechaIngreso = paciente.FechaIngreso.Year + "-" + paciente.FechaIngreso.Month + "-" + paciente.FechaIngreso.Day;
            this.JsonParam = "send={\"indice\":3,\"idPersona\":" + paciente.IdPersona + ",\"fechaIngreso\":\"" + fechaIngreso + "\",\"habilitado\":1}";
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
       
       #region ModificarPaciente
        public string ModificarPaciente(Paciente paciente)
        {
            string pacienteModificado = string.Empty;
            //{"indice":7,"idPaciente":1,"idPersona":1,"fechaIngreso":"2013-04-12"}
            String fechaIngreso = paciente.FechaIngreso.Year + "-" + paciente.FechaIngreso.Month + "-" + paciente.FechaIngreso.Day;
            this.JsonParam = "send={\"indice\":7,\"idPaciente\":" + paciente.IdPaciente + ",\"idPersona\":" + paciente.IdPersona + ",\"fechaIngreso\":\"" + fechaIngreso + "\"}";
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
      
       #region desabilitarHabilitarPaciente

        public string DesabilitarHabilitarPaciente(int id, int est)
        {
         
            string pacienteModificado = string.Empty;
            //{"indice":9,"idPaciente":1,"habilitado":1}
            
            this.JsonParam = "send={\"indice\":9,\"idPaciente\":" + id + ",\"habilitado\":" +  est + "}";
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
       
       #region Buscar Paciente Por Rut
        public List<Paciente> BuscarPacientePorRut(string rut)
        {
            List<Paciente> list = new List<Paciente>();
            try
            {
                this.JsonParam = "send={\"indice\":5,\"rut\":" + rut + "}";
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
                this.JsonParam = "send={\"indice\":6,\"nombre\":\"" + nombre + "\",\"apellido\":\"" + apellido + "\"}";
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
    }
}
