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
    #region Listado de metodos 
    /*
*Contiene la opciones para insertar, listar y modificar
*Fichas y presupuestos
*Opciones:
*Opciones:
* 1.- insertar Ficha Dental
* 2.- Modificar Ficha Dental
* 3.- Buscar Ficha Por ID
* 4.- Buscar Ficha Por ID Persona
* 5.- Listar Fichas
* 6.- Deshabilitar Ficha
* 7.- insertar Presupuesto
* 8.- modificar Presupuesto
* 9.- buscar por id
* 10.- buscar por id persona
* 11.- listar
*/

    #endregion
    public class ClientWsFichaPresupuesto
    {
        #region Campos
        CoreNetClient netclient = new CoreNetClient();
        private static String ipServer = "http://192.168.137.111/";
        private string jsonParam;
        #endregion

        #region Propiedades
        public string JsonParam
        {
            get { return jsonParam; }
            set { jsonParam = value; }
        }
        #endregion
   #region ListarFichas

        public List<Fichadental> ListarFichas() { 
          List<Fichadental> list = new List<Fichadental>();
          try{
                this.JsonParam = "send={\"indice\":12}";
                String result = netclient.NetPost(ipServer + "sfhwebservice/webService/ws-ficha-presupuesto.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("ListaFicha").ToList();
                foreach (var item in token)
                {
                    Fichadental ficha = new Fichadental();
                    //{"idFicha":1,"idPaciente":1,"idOdontologo":3,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":"desabilitado","nomPaciente":"Ada Tatus","nomOdontologo":"Camila Carrizo"}
                    ficha.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    ficha.IdPaciente = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    ficha.IdOdontologo = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
                    ficha.FechaIngreso = Convert.ToDateTime(item.SelectToken("fechaIngreso").ToString());
                    ficha.Anamnesis = item.SelectToken("anamnesis").ToString();
                    ficha.Habilitada = item.SelectToken("habilitada").ToString();
                    ficha.NombrePaciente = item.SelectToken("nomPaciente").ToString();
                    ficha.NombreOdontologo = item.SelectToken("nomOdontologo").ToString();
                    list.Add(ficha);
                }

              }
               catch(Exception e){
                    throw new Exception(e + "| Error al Listar Fichas");
               }
                 return list;
        }
        #endregion

        #region BuscarFichasPorId
        public List<Fichadental> BuscarFichasPorId(int numFicha) {
            List<Fichadental> list = new List<Fichadental>();
            try
            {
                this.JsonParam = "send={\"indice\":3,\"idFicha\":" + numFicha + "}";
                String result = netclient.NetPost(ipServer + "sfhwebservice/webService/ws-ficha-presupuesto.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("FichaPorID").ToList();
                foreach (var item in token)
                {
                    Fichadental ficha = new Fichadental();
                    //{"idFicha":1,"idPaciente":1,"idOdontologo":3,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":"desabilitado","nomPaciente":"Ada Tatus","nomOdontologo":"Camila Carrizo"}
                    ficha.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    ficha.IdPaciente = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    ficha.IdOdontologo = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
                    ficha.FechaIngreso = Convert.ToDateTime(item.SelectToken("fechaIngreso").ToString());
                    ficha.Anamnesis = item.SelectToken("anamnesis").ToString();
                    ficha.Habilitada = item.SelectToken("habilitada").ToString();
                    ficha.NombrePaciente = item.SelectToken("nomPaciente").ToString();
                    ficha.NombreOdontologo = item.SelectToken("nomOdontologo").ToString();
                    list.Add(ficha);
                }

            }

            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return list;
        }
        #endregion

        #region BuscarFichasPorIdPersona
        public List<Fichadental> BuscarFichasPorIdPersona(int param)
        {
            List<Fichadental> list = new List<Fichadental>();
            try
            {
                this.JsonParam = "send={\"indice\":4,\"idPersona\":" + param + "}";
                String result = netclient.NetPost(ipServer + "sfhwebservice/webService/ws-ficha-presupuesto.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("FichaIdPersona").ToList();
                foreach (var item in token)
                {
                    Fichadental ficha = new Fichadental();
                    //{"idFicha":1,"idPaciente":1,"idOdontologo":3,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":"desabilitado","nomPaciente":"Ada Tatus","nomOdontologo":"Camila Carrizo"}
                    ficha.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    ficha.IdPaciente = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    ficha.IdOdontologo = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
                    ficha.FechaIngreso = Convert.ToDateTime(item.SelectToken("fechaIngreso").ToString());
                    ficha.Anamnesis = item.SelectToken("anamnesis").ToString();
                    ficha.Habilitada = item.SelectToken("habilitada").ToString();
                    ficha.NombrePaciente = item.SelectToken("nomPaciente").ToString();
                    ficha.NombreOdontologo = item.SelectToken("nomOdontologo").ToString();
                    list.Add(ficha);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return list;
        }
        #endregion

        #region InsertarFichaDental
        public string InsertarFichaDental(Fichadental ficha)
        {
            string fichaInsertada = string.Empty;
            string fechaAEnviar = ficha.FechaIngreso.Year + "-" + ficha.FechaIngreso.Month + "-" + ficha.FechaIngreso.Day;
            //{"indice":1,"idPaciente":1,"idOdontologo":1,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":0}
            this.JsonParam = "send={\"indice\":1,\"idPaciente\":" + ficha.IdPaciente + ", \"idOdontologo\":" + ficha.IdOdontologo + ",\"fechaIngreso\":\"" + fechaAEnviar + "\",\"anamnesis\":\"" + ficha.Anamnesis + "\",\"habilitada\":" + ficha.EstadoPaciente + "}";
            try
            {
                String result = netclient.NetPost(ipServer + "sfhwebservice/webService/ws-ficha-presupuesto.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idFichaInsertada":8}
                fichaInsertada = jobject.SelectToken("idFichaInsertada").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Fichas");
            }
            return fichaInsertada;
        }
        #endregion

        #region ModificarFichaDental
        public string ModificarFichaDental(Fichadental ficha)
        {
            string fichaModificada = string.Empty;
            string fechaAEnviar = ficha.FechaIngreso.Year + "-" + ficha.FechaIngreso.Month + "-" + ficha.FechaIngreso.Day;
            //{"indice":2,"idFicha":1,"idPaciente":1,"idOdontologo":1,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina"}
            this.JsonParam = "send={\"indice\":2,\"idFicha\":" + ficha.IdFicha + ",\"idPaciente\":" + ficha.IdPaciente + ",\"idOdontologo\":" + ficha.IdOdontologo + ",\"fechaIngreso\":\"" + fechaAEnviar + "\",\"anamnesis\":\"" + ficha.Anamnesis + "\"}";
            try
            {
                String result = netclient.NetPost(ipServer + "sfhwebservice/webService/ws-ficha-presupuesto.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idTratamientoInsertada":10}
                fichaModificada = jobject.SelectToken("Resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return fichaModificada;
        }
        #endregion

        public string CambiarEstadoFicha(Fichadental ficha) {
            string fichaModificada = string.Empty;
            //{"indice":6,"idFicha":3,"habilitada":1}
            this.JsonParam = "send={\"indice\":6,\"idFicha\":" + ficha.IdFicha + ",\"habilitada\":" + ficha.EstadoPaciente + "}";
            try
            {
                String result = netclient.NetPost(ipServer + "sfhwebservice/webService/ws-ficha-presupuesto.php", this.JsonParam);
                var jobject = JObject.Parse(result);
               //{"code":6,"resultado":"Modificado"}
                fichaModificada = jobject.SelectToken("resultado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return fichaModificada;
        }

        

        
        public List<Presupuesto> listadoPresupuestoPorPaciente(int idPaciente)
        {
            List<Presupuesto> listaPresupuesto = new List<Presupuesto>();
            //{"indice":10,"idPaciente":3}
            this.JsonParam = "send={\"indice\":10,\"idPaciente\":" +idPaciente + "}";
            try
            {
                String result = netclient.NetPost(ipServer + "proyectoTitulo/sfhwebservice/webService/ws-ficha-presupuesto.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idTratamientoInsertada":10}
                var token = jobject.SelectToken("PresupuestoIDPaciente").ToList();
                foreach (var item in token)
                {
                    Presupuesto presupuesto = new Presupuesto();
                    //{"code":4,"FichaIdPersona":[{"idFicha":4,"idPaciente":4,"idOdontologo":4,"fechaIngreso":"2013-08-12","anamnesis":"Diabetes","habilitada":0}]}
                    presupuesto.IdPresupuesto = Convert.ToInt32(item.SelectToken("idPresupuesto").ToString());
                    presupuesto.ValorTotal = Convert.ToInt32(item.SelectToken("valorTotal").ToString());
                    presupuesto.FechaPresupuesto = Convert.ToDateTime(item.SelectToken("fechaPresupuesto").ToString());
                    presupuesto.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    presupuesto.IdPaciente = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    listaPresupuesto.Add(presupuesto);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return listaPresupuesto;
        }
        public List<Presupuesto> listadoPresupuestoPorFicha(int idFicha)
        {
            List<Presupuesto> listaPresupuesto = new List<Presupuesto>();
            //{"indice":10,"idPaciente":3}
            this.JsonParam = "send={\"indice\":14,\"idFicha\":" + idFicha + "}";
            try
            {
                String result = netclient.NetPost(ipServer + "proyectoTitulo/sfhwebservice/webService/ws-ficha-presupuesto.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idTratamientoInsertada":10}
                var token = jobject.SelectToken("PresupuestoIDPaciente").ToList();
                foreach (var item in token)
                {
                    Presupuesto presupuesto = new Presupuesto();
                    //{"code":4,"FichaIdPersona":[{"idFicha":4,"idPaciente":4,"idOdontologo":4,"fechaIngreso":"2013-08-12","anamnesis":"Diabetes","habilitada":0}]}
                    presupuesto.IdPresupuesto = Convert.ToInt32(item.SelectToken("idPresupuesto").ToString());
                    presupuesto.ValorTotal = Convert.ToInt32(item.SelectToken("valorTotal").ToString());
                    presupuesto.FechaPresupuesto = Convert.ToDateTime(item.SelectToken("fechaPresupuesto").ToString());
                    presupuesto.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    //presupuesto.IdPaciente = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    listaPresupuesto.Add(presupuesto);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return listaPresupuesto;
        }
        public List<Persona> listaPersonaFichaNombre()
        {
            List<Persona> listaPersona = new List<Persona>();
            try
            {
                String result = netclient.NetPost( ipServer + "/proyectoTitulo/sfhwebservice/webService/ws-ficha-presupuesto.php", "send={\"indice\":13}");
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("PresupuestoIDPaciente").ToList();
                foreach (var item in token)
                {
                    Persona personaFake = new Persona();
                    personaFake.IdPersona = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    personaFake.Nombre = item.SelectToken("nomPersona").ToString() + " " + item.SelectToken("appPersona").ToString();
                    listaPersona.Add(personaFake);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return listaPersona;
        }
        public string insertarPresupuesto(Presupuesto presupuesto)
        {
            //{"indice":7,"idFicha":3,"valorTotal":10000,"fechaPresupuesto":"1991-12-12"}
            try
            {
                string fecha = presupuesto.FechaPresupuesto.Year + "-" + presupuesto.FechaPresupuesto.Month + "-" + presupuesto.FechaPresupuesto.Day;
                String result = netclient.NetPost(ipServer + "/proyectoTitulo/sfhwebservice/webService/ws-ficha-presupuesto.php", "send={\"indice\":7,\"idFicha\":"+presupuesto.IdFicha+",\"valorTotal\":"+presupuesto.ValorTotal+",\"fechaPresupuesto\":\""+fecha+"\"}");
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("idPresupuestoInsertado").ToString();
                return token;
            }
            catch (Exception e)
            {
                    
            }
            return "";
        }
        public string modificarPresupuesto(Presupuesto presupuesto)
        {
            //{"indice":8,"idPresupuesto":1,"idFicha":3,"valorTotal":10000,"fechaPresupuesto":"1991-12-12"}
            try
            {
                string fecha = presupuesto.FechaPresupuesto.Year + "-" + presupuesto.FechaPresupuesto.Month + "-" + presupuesto.FechaPresupuesto.Day;
                String result = netclient.NetPost(ipServer + "/proyectoTitulo/sfhwebservice/webService/ws-ficha-presupuesto.php", "send={\"indice\":8,\"idFicha\":" + presupuesto.IdFicha + ",\"idPresupuesto\":"+presupuesto.IdPresupuesto+",\"valorTotal\":" + presupuesto.ValorTotal + ",\"fechaPresupuesto\":\"" + fecha + "\"}");
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("modificado").ToString();
                return token;
            }
            catch (Exception e)
            {

            }
            return "";
        }
    }
}
