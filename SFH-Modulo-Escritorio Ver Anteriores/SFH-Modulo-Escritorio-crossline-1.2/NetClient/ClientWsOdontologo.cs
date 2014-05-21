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
    /*
     *insertar odontologo
     *modficar odontologo
     *desabilitar Odontologo
     *listar odontologo persona
     *buscar odontologos por nombre 
     *buscar odontologos por rut 
     */
    public class ClientWsOdontologo
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

        #region InsertarOdontolo
        public string InsertarOdontologo(Odontologo odontologo)
        {

            string odontologoInsertado = string.Empty;
            //{"indice":2,"idPersona":1,"especialidad":"Cirugia","habilitado":1}
            this.JsonParam = "{\"indice\":2,\"idPersona\":" + odontologo.IdPersona + ",\"especialidad\":\"" + odontologo.Especialidad + "\",\"habilitado\":1}";
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

        #region ModificarOdontologo
        public string ModificarOdontologo(Odontologo odontologo)
        {
            string odontologoModificado = string.Empty;
            //{"indice":6,"idOdontologo":2,"idPersona":1,"especialidad":"Cirugia"}
            this.JsonParam = "{\"indice\":6,\"idOdontologo\":" + odontologo.IdOdontologo + ",\"idPersona\":" + odontologo.IdPersona + ",\"especialidad\":\"" + odontologo.Especialidad + "\",\"habilitado\":1}";
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

        #region desabilitarHabilitarOdontologo

        public string DesabilitarHabilitarOdontologo(int id_odontologo, int estado)
        {
            string odontologoModificado = string.Empty;
            //{"indice":9,"idPaciente":1,"habilitado":1}
            this.JsonParam = "{\"indice\":10,\"idOdontologo\":" + id_odontologo + ",\"habilitado\":" + estado + "}";
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

        #region EliminarOdontologo
        public string EliminarOdontologo(int id_odontologo)
        {
            string odontologoEliminado = string.Empty;
            //{"indice":12,"idOdontologo":1}
            this.JsonParam = "{\"indice\":12,\"idOdontologo\":" + id_odontologo + "}";
            try
            {
                String result = netclient.NetPost("ws-admin-usuario-sig.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //resutadoHabilitar
                odontologoEliminado = jobject.SelectToken("resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al eliminar odontologo");
            }
            return odontologoEliminado;
        }
        #endregion

        #region ListarOdontologo
        public List<Odontologo> ListarOdontologo()
        {
            List<Odontologo> list = new List<Odontologo>();
            try
            {
                this.JsonParam = "{\"indice\":17}";
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

        #region Buscar Odontologo Por Rut
        public List<Odontologo> BuscarOdontologoPorRut(string rut)
        {
            List<Odontologo> list = new List<Odontologo>();
            try
            {
                this.JsonParam = "{\"indice\":7,\"rut\":" + rut + "}";
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
                this.JsonParam = "{\"indice\":8,\"nombre\":\"" + nombre + "\",\"apellido\":\"" + apellido + "\"}";
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
    }
}
