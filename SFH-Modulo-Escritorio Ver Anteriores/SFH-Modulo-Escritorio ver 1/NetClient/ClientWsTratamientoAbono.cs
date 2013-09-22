using Newtonsoft.Json.Linq;
using ObjectsBeans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NetClient
{
    #region Listado de metodos
    /*
    *Contiene la opciones para insertar, listar y modificar
    *Tratamientos y Abonos
    *Opciones:
    * 1.- insertar Tratamiento
    * 2.- Modificar Tratamiento
    * 3.- Buscar tratamiento por Rut
    */

    #endregion
    public class ClientWsTratamientoAbono
    {
        #region Campos
        CoreNetClient netclient = new CoreNetClient();
        string ipServer = "192.168.0.21";
        #endregion
        
        public List<Tratamientodental> ListarTratamientoIdFicha(int idFicha)
        {
            List<Tratamientodental> list = new List<Tratamientodental>();

            try
            {
                String result = netclient.NetPost("http://"+ipServer+"/proyectoTitulo/sfhwebservice/webService/ws-tratamiento-abono.php", "send={\"indice\":10,\"idFicha\":"+idFicha+"}");
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listadoTratamiento").ToList();
                foreach (var item in token)
                {
                    Tratamientodental tratamiento = new Tratamientodental();
                     
                    ////idTratamientoDental":3,"idFicha":3,"fechaCreacion":"2013-07-02","tratamiento":"Tratamiento Conducto","fechaSeguimiento":"2013-07-05","valorTotal":50000
                    tratamiento.IdTratamientoDental = Convert.ToInt32(item.SelectToken("idTratamientoDental").ToString());
                    tratamiento.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    tratamiento.FechaCreacion = Convert.ToDateTime(item.SelectToken("fechaCreacion").ToString());
                    tratamiento.Tratamiento = item.SelectToken("tratamiento").ToString();
                    tratamiento.FechaSeguimiento = Convert.ToDateTime(item.SelectToken("fechaSeguimiento").ToString());
                    tratamiento.ValorTotal = Convert.ToInt32(item.SelectToken("valorTotal").ToString());
                    if (item.SelectToken("totalAbono") == null ||item.SelectToken("totalAbono").ToString() == "null" || item.SelectToken("totalAbono").ToString()=="")
                    {
                        tratamiento.TotalAbono = 0;
                    }
                    else
                    {
                        tratamiento.TotalAbono = Convert.ToInt32(item.SelectToken("totalAbono").ToString());
                    }
                   
                    list.Add(tratamiento);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return list;
        }
        public int InsertarTratamiento(Tratamientodental tratamiento)
        {
            //{"indice":1,"idFicha":1,"fechaCreacion":"1991-12-12","tratamiento":"extraccion","fechaSeguimiento":"1991-12-12","valorTotal":100000}
            string fechaCreacionEnviar = tratamiento.FechaCreacion.Year + "-" + tratamiento.FechaCreacion.Month + "-" + tratamiento.FechaCreacion.Day;
            string fechaCreacionSeguimiento = tratamiento.FechaSeguimiento.Year + "-" + tratamiento.FechaSeguimiento.Month + "-" + tratamiento.FechaSeguimiento.Day;
            string jsonAEnviar = "send={\"indice\":1,\"idFicha\":\"" + tratamiento.IdFicha + "\", \"fechaCreacion\":\""+fechaCreacionEnviar+"\",\"tratamiento\":\""+tratamiento.Tratamiento+"\",\"fechaSeguimiento\":\""+fechaCreacionSeguimiento+"\",\"valorTotal\":"+tratamiento.ValorTotal+"}";
            try
            {
                String result = netclient.NetPost("http://" + ipServer + "/proyectoTitulo/sfhwebservice/webService/ws-tratamiento-abono.php", jsonAEnviar);
                var jobject = JObject.Parse(result);
                //{"code":1,"idTratamientoInsertada":10}
                return Convert.ToInt32(jobject.SelectToken("idTratamientoInsertada").ToString());
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public string ModificarTratamiento(Tratamientodental tratamiento)
        {
            //{"indice":2,"idTratamientoDental":10,"idFicha":1,"fechaCreacion":"1991-12-12","tratamiento":"extraccion","fechaSeguimiento":"1991-12-12","valorTotal":100000}
            string fechaCreacionEnviar = tratamiento.FechaCreacion.Year + "-" + tratamiento.FechaCreacion.Month + "-" + tratamiento.FechaCreacion.Day;
            string fechaCreacionSeguimiento = tratamiento.FechaSeguimiento.Year + "-" + tratamiento.FechaSeguimiento.Month + "-" + tratamiento.FechaSeguimiento.Day;
            string jsonAEnviar = "send={\"indice\":2,\"idTratamientoDental\":" + tratamiento.IdTratamientoDental + ",\"idFicha\":" + tratamiento.IdFicha + ",\"fechaCreacion\":\"" + fechaCreacionEnviar + "\",\"tratamiento\":\"" + tratamiento.Tratamiento + "\",\"fechaSeguimiento\":\"" + fechaCreacionSeguimiento + "\",\"valorTotal\":" + tratamiento.ValorTotal + "}";
            try
            {
                String result = netclient.NetPost("http://"+ipServer+"/proyectoTitulo/sfhwebservice/webService/ws-tratamiento-abono.php", jsonAEnviar);
                var jobject = JObject.Parse(result);
                //{"code":1,"idTratamientoInsertada":10}
                return jobject.SelectToken("Resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
        }
        public List<Abono> ListarAbonoPorTratamiento(int idTratamiento)
        {
            List<Abono> list = new List<Abono>();
            //{"indice":1,"idFicha":1,"fechaCreacion":"1991-12-12","tratamiento":"extraccion","fechaSeguimiento":"1991-12-12","valorTotal":100000}
            string jsonAEnviar = "send={\"indice\":8,\"idTratamiento\":"+idTratamiento+"}";
            try
            {
                String result = netclient.NetPost("http://"+ipServer+"/proyectoTitulo/sfhwebservice/webService/ws-tratamiento-abono.php",jsonAEnviar);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaAbono").ToList();
                foreach (var item in token)
                {
                    Abono abono = new Abono();

                    ////"idAbono":1,"idTratamientoDental":3,"fechaAbono":"1991-12-12","monto":10000
                    abono.IdAbono = Convert.ToInt32(item.SelectToken("idAbono").ToString());
                    abono.IdTratamientoDental = Convert.ToInt32(item.SelectToken("idTratamientoDental").ToString());
                    abono.FechaAbono = Convert.ToDateTime(item.SelectToken("fechaAbono").ToString());
                    abono.Monto = Convert.ToInt32(item.SelectToken("monto").ToString());
                    list.Add(abono);
                }

            }
            catch
            {
            }
            return list;
        }
        public int InsertarAbono(Abono abono)
        {
            //{"indice":5,"idTratamientoDental":3,"fechaAbono":"1991-12-12","monto":1000}
            string fechaAEnviar = abono.FechaAbono.Year + "-" + abono.FechaAbono.Month + "-" + abono.FechaAbono.Day;
            string jsonAEnviar = "send={\"indice\":5,\"idTratamientoDental\":" + abono.IdTratamientoDental + ",\"fechaAbono\":\"" + fechaAEnviar + "\",\"monto\":" + abono.Monto + "}";
            try
            {
                
                String result = netclient.NetPost("http://"+ipServer+"/proyectoTitulo/sfhwebservice/webService/ws-tratamiento-abono.php", jsonAEnviar);
                var jobject = JObject.Parse(result);
                //{"code":1,"idTratamientoInsertada":10}
                return Convert.ToInt32(jobject.SelectToken("idAbonoInsertado").ToString());
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public string ModificarAbono(Abono abono)
        {
            //{"indice":6,"idAbono":1,"idTratamientoDental":3,"fechaAbono":"1991-12-12","monto":10000}
            string fechaAEnviar = abono.FechaAbono.Year + "-" + abono.FechaAbono.Month + "-" + abono.FechaAbono.Day;
            string jsonAEnviar = "send={\"indice\":6,\"idAbono\":" + abono.IdAbono + ",\"idTratamientoDental\":" + abono.IdTratamientoDental + ",\"fechaAbono\":\"" + fechaAEnviar + "\",\"monto\":" + abono.Monto + "}";
            try
            {
                String result = netclient.NetPost("http://"+ipServer+"/proyectoTitulo/sfhwebservice/webService/ws-tratamiento-abono.php", jsonAEnviar);
                var jobject = JObject.Parse(result);
                //{"code":1,"idTratamientoInsertada":10}
                return jobject.SelectToken("Resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
        }
        public string EliminarAbono(Abono abono)
        {
            //{"indice":11,"idAbono":3}
            string jsonAEnviar = "send={\"indice\":11,\"idAbono\":"+abono.IdAbono+"}";
            try
            {
                String result = netclient.NetPost("http://" + ipServer + "/proyectoTitulo/sfhwebservice/webService/ws-tratamiento-abono.php", jsonAEnviar);
                var jobject = JObject.Parse(result);
                //{"code":11,"eliminado":"eliminado"}
                return jobject.SelectToken("eliminado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
        }
       
    }
}
