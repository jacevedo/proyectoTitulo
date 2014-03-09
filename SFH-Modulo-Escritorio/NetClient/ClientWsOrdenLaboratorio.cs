using Newtonsoft.Json.Linq;
using ObjectsBeans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetClient
{
    public class ClientWsOrdenLaboratorio
    {
        #region Campos
        CoreNetClient netclient = new CoreNetClient();
        #endregion

        public List<Ordendelaboratorio> ListarOrdenLaboratorio()
        {
            List<Ordendelaboratorio> list = new List<Ordendelaboratorio>();
            try
            {
                String result = netclient.NetPost("ws-admin-orden.php", "{\"indice\":4}");
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("ListadoOrden").ToList();
                foreach (var item in token)
                {
                    //{"idOrdenLaboratorio":1,"idOdontologo":1,"idPaciente":2,"numOrden":123123,"clinica":"Santa Ana",
                    //"bd":"10","bi":"11","pd":"20","pi":"21","fechaCreacion":"2013-09-06","fechaEntrega":"2013-10-26",
                    //"horaEntrega":"14:00:00","color":"Blanco","estado":"Rechazada","nomPaciente":"Lissete Salcedo",
                    //"nomOdontologo":"asdasd asdasd"}
                   
                    Ordendelaboratorio orden = new Ordendelaboratorio();
                    orden.IdOrdenLaboratorio = Convert.ToInt32(item.SelectToken("idOrdenLaboratorio").ToString());
                    orden.IdOdontologo = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
                    orden.IdPaciente = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    orden.NumeroOrden = Convert.ToInt32(item.SelectToken("numOrden").ToString());
                    orden.Clinica = item.SelectToken("clinica").ToString();
                    orden.Bd = item.SelectToken("bd").ToString();
                    orden.Bi = item.SelectToken("bi").ToString();
                    orden.Pd = item.SelectToken("pd").ToString();
                    orden.Pi = item.SelectToken("pi").ToString();
                    orden.FechaCreacion = Convert.ToDateTime(item.SelectToken("fechaCreacion").ToString());
                    orden.FechaEntrega = Convert.ToDateTime(item.SelectToken("fechaEntrega").ToString());
                    orden.HoraEntrega = item.SelectToken("horaEntrega").ToString();
                    orden.Color = item.SelectToken("color").ToString();
                    orden.Estadodeorden = EstadoOrdenLaboratorio.ENVIADA;
                    orden.NomPaciente = item.SelectToken("nomPaciente").ToString();
                    orden.NomOdontologo = item.SelectToken("nomOdontologo").ToString();
                    list.Add(orden);
                }

            }
            catch (Exception e)
            {

            }
            return list;
        }
        public string insertarOrden(Ordendelaboratorio orden)
        {
            string fechaCreacionEnviar = orden.FechaCreacion.Year + "-" + orden.FechaCreacion.Month + "-" + orden.FechaCreacion.Day;
            string fechaRecepcionEnviar = orden.FechaEntrega.Year + "-" + orden.FechaEntrega.Month + "-" + orden.FechaEntrega.Day;
            string jsonAEnviar = "{\"indice\":1,\"idOdontologo\":" + orden.IdOdontologo + ",\"idPaciente\":" + orden.IdPaciente + ",\"numOrden\":" + orden.NumeroOrden + ",\"clinica\":\"" + orden.Clinica + "\",\"bd\":\"" + orden.Bd + "\",\"bi\":\"" + orden.Bi + "\",\"pd\":\"" + orden.Pd + "\",\"pi\":\"" + orden.Pi + "\",\"fechaCreacion\":\"" + fechaCreacionEnviar + "\",\"fechaEntrega\":\"" + fechaRecepcionEnviar + "\",\"horaEntrega\":\"" + orden.HoraEntrega + "\",\"color\":\"" + orden.Color + "\",\"estado\":\"" + orden.Estadodeorden + "\"}";
            try
            {
                String result = netclient.NetPost("ws-admin-orden.php", jsonAEnviar);
                var jobject = JObject.Parse(result);
                return jobject.SelectToken("idOrdenInsertada").ToString();
            }
            catch(Exception e)
            {

            }

            return "";
        }
        public string modificarOrden(Ordendelaboratorio orden)
        {
            //{"indice":2,"idOrden":5,"idOdontologo":3,"idPaciente":2,"numOrden":1,"clinica":"Santa","bd":"10","bi":"11",
            //"pd":"20","pi":"21","fechaCreacion":"2013-08-26","fechaEntrega":"2013-09-26","horaEntrega":"16:00","color":"Blanco","estado":"Recibida"}
            string fechaCreacionEnviar = orden.FechaCreacion.Year+"-"+orden.FechaCreacion.Month+"-"+orden.FechaCreacion.Day;
            string fechaRecepcionEnviar = orden.FechaEntrega.Year+"-"+orden.FechaEntrega.Month+"-"+orden.FechaEntrega.Day;
            string jsonAEnviar = "{\"indice\":2,\"idOrden\":" + orden.IdOrdenLaboratorio + ",\"idOdontologo\":" + orden.IdOdontologo + ",\"idPaciente\":" + orden.IdPaciente + ",\"numOrden\":" + orden.NumeroOrden + ",\"clinica\":\"" + orden.Clinica + "\",\"bd\":\"" + orden.Bd + "\",\"bi\":\"" + orden.Bi + "\",\"pd\":\"" + orden.Pd + "\",\"pi\":\"" + orden.Pi + "\",\"fechaCreacion\":\"" + fechaCreacionEnviar + "\",\"fechaEntrega\":\"" + fechaRecepcionEnviar + "\",\"horaEntrega\":\"10:00\",\"color\":\"" + orden.Color + "\",\"estado\":\"" + orden.Estadodeorden + "\"}";
                //"{\"indice\":2,\"idOrden\":5,\"idOdontologo\":3,\"idPaciente\":2,\"numOrden\":1,\"clinica\":\"Santa\",\"bd\":\"10\",\"bi\":\"11\",\"pd\":\"20\",\"pi\":\"21\",\"fechaCreacion\":\"2013-08-26\",\"fechaEntrega\":\"2013-09-26\",\"horaEntrega\":\"16:00\",\"color\":\"Blanco\",\"estado\":\"Recibida\"}";
            //string jsonAEnviar = "{\"indice\":4}";
            try
            {
                String result = netclient.NetPost("ws-admin-orden.php", jsonAEnviar);
                var jobject = JObject.Parse(result);
                return jobject.SelectToken("resultado").ToString();
            }
            catch (Exception e)
            {
            }
            return "";
        }
        public List<Persona> listaPacientes()
        {
            List<Persona>listaPersona = new List<Persona>();
            try
            {
                String result = netclient.NetPost("ws-admin-usuario-sig.php", "{\"indice\":9}");
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPersonas").ToList();
                foreach (var item in token)
                {
                    Persona personaFake = new Persona();
                    personaFake.IdPersona = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    personaFake.Nombre = item.SelectToken("nomPersona").ToString() + " " + item.SelectToken("appPersona").ToString();
                    listaPersona.Add(personaFake);
                }
            }
            catch (Exception e)
            {
            }
            return listaPersona;

        }
        public List<Persona> listaOdontologo()
        {
            List<Persona> listaPersona = new List<Persona>();
            try
            {
                String result = netclient.NetPost("ws-admin-usuario-sig.php", "{\"indice\":10}");
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPersonas").ToList();
                foreach (var item in token)
                {
                    Persona personaFake = new Persona();
                    personaFake.IdPersona = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
                    personaFake.Nombre = item.SelectToken("nomPersona").ToString() + " " + item.SelectToken("appPersona").ToString();
                    listaPersona.Add(personaFake);
                }
            }
            catch (Exception e)
            {
            }
            return listaPersona;
        }

    }
}
