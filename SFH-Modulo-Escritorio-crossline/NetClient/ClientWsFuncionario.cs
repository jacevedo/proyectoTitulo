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
   public  class ClientWsFuncionario
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

       #region InsertarFuncionario
       public string InsertarFuncionario(Funcionario funcionario)
       {
           string funcionarioInsertado = string.Empty;
           //{"indice":4,"idPersona":1,"puestoTrabajo":"Administrador","habilitado":1}
           this.JsonParam = "{\"indice\":4,\"idPersona\":" + funcionario.IdPersona + ",\"puestoTrabajo\":\"" + funcionario.PuestoTrabajo + "\",\"habilitado\":1}";
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

       #region ModificarFuncionario
       public string ModificarFuncionario(Funcionario funcionario)
       {
           string funcionarioModifcar = string.Empty;
           //{"indice":8,"idFuncionario":2,"idPersona":1,"puestoTrabajo":"Administrador"}
           this.JsonParam = "{\"indice\":8,\"idFuncionario\":" + funcionario.IdFuncionario + ",\"idPersona\":" + funcionario.IdPersona + ",\"puestoTrabajo\":\"" + funcionario.PuestoTrabajo + "\",\"habilitado\":1}";
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

       #region desabilitarHabilitarFuncionario

       public string DesabilitarHabilitarFuncionario(int id_funcionario, int estado)
       {
           string funcionarioModificado = string.Empty;
           //{"indice":9,"idPaciente":1,"habilitado":1}
           this.JsonParam = "{\"indice\":11,\"idFuncionario\":" + id_funcionario + ",\"isDesabilitado\":" + estado + "}";
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

       #region EliminarFuncionario
       public string EliminarFuncionario(int id_funcionario)
       {
           string funcionarioEliminado = string.Empty;
           //{"indice":12,"idOdontologo":1}
           this.JsonParam = "{\"indice\":13,\"idFuncionario\":" + id_funcionario + "}";
           try
           {
               String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
               var jobject = JObject.Parse(result);
               //resutadoHabilitar
               funcionarioEliminado = jobject.SelectToken("resultado").ToString();
           }
           catch (Exception e)
           {
               throw new Exception(e + "| Error al eliminar funcionario");
           }
           return funcionarioEliminado;
       }
       #endregion

       #region ListarFuncionario
       public List<Funcionario> ListarFuncionario()
       {
           List<Funcionario> list = new List<Funcionario>();
           try
           {
               this.JsonParam = "{\"indice\":18}";
               String result = netclient.NetPost("ws-admin-usuario.php", this.JsonParam);
               var jobject = JObject.Parse(result);
               var token = jobject.SelectToken("listaFuncionarioHerencia").ToList();
               foreach (var item in token)
               {

                   Funcionario funcionario = new Funcionario();
                   //{"idFuncionario":2,"idPersona":3,"puestoTrabajo":"Asistente Dental",
                   //"funcionarioHabilitado":null,"idPerfil":3,"rut":"9878987","dv":"4","nombre":"Nicolas","apellidoPaterno":"Palma",
                   //"apellidoMaterno":"Silva","fechaNacimiento":"1987-05-27"}
                   funcionario.IdFuncionario = Convert.ToInt32(item.SelectToken("idFuncionario").ToString());
                   funcionario.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                   funcionario.PuestoTrabajo = item.SelectToken("puestoTrabajo").ToString();
                   int estado = Convert.ToInt32(item.SelectToken("funcionarioHabilitado").ToString());
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

       #region Buscar Funcionario Por Rut
       public List<Funcionario> BuscarFuncionarioPorRut(string rut)
       {
           List<Funcionario> list = new List<Funcionario>();
           try
           {
               this.JsonParam = "{\"indice\":3,\"rut\":" + rut + "}";
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
                   int estado = Convert.ToInt32(item.SelectToken("funcionarioHabilitado").ToString());
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
               this.JsonParam = "{\"indice\":4,\"nombre\":\"" + nombre + "\",\"apellido\":\"" + apellido + "\"}";
               String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
               var jobject = JObject.Parse(result);
               var token = jobject.SelectToken("buscarFuncionarioNombre").ToList();
               foreach (var item in token)
               {

                   Funcionario funcionario = new Funcionario();
                   //{"idFuncionario":2,"idPersona":3,"puestoTrabajo":"Asistente Dental",
                   //"funcionarioHabilitado":null,"idPerfil":3,"rut":"9878987","dv":"4","nombre":"Nicolas","apellidoPaterno":"Palma",
                   //"apellidoMaterno":"Silva","fechaNacimiento":"1987-05-27"}
                   funcionario.IdFuncionario = Convert.ToInt32(item.SelectToken("idFuncionario").ToString());
                   funcionario.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                   funcionario.PuestoTrabajo = item.SelectToken("puestoTrabajo").ToString();
                   int estado = Convert.ToInt32(item.SelectToken("funcionarioHabilitado").ToString());
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
    }
}
