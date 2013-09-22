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
        private static  String ipServer = "http://192.168.191.136/";
        private string jsonParam;
        #endregion

        #region Propiedades
        public string JsonParam
        {
            get { return jsonParam; }
            set { jsonParam = value; }
        }
        #endregion

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
                    //"idFicha":1,"idPaciente":"Ada Tatus","idOdontologo":" ","fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":0},
                    ficha.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    ficha.NombrePaciente = item.SelectToken("idPaciente").ToString();
                    ficha.NombreOdontologo = item.SelectToken("idOdontologo").ToString();
                    ficha.FechaIngreso = Convert.ToDateTime(item.SelectToken("fechaIngreso").ToString());
                    ficha.Anamnesis = item.SelectToken("anamnesis").ToString();
                    ficha.Habilitada = Convert.ToInt32(item.SelectToken("habilitada").ToString());
                    list.Add(ficha);
                }

               }

               catch(Exception e){
                    throw new Exception(e + "| Error al Listar Fichas");
               }
                 return list;
        }

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
                    //"idFicha":1,"idPaciente":"Ada Tatus","idOdontologo":" ","fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":0},
                    ficha.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    ficha.NombrePaciente = item.SelectToken("idPaciente").ToString();
                    ficha.NombreOdontologo = item.SelectToken("idOdontologo").ToString();
                    ficha.FechaIngreso = Convert.ToDateTime(item.SelectToken("fechaIngreso").ToString());
                    ficha.Anamnesis = item.SelectToken("anamnesis").ToString();
                    ficha.Habilitada = Convert.ToInt32(item.SelectToken("habilitada").ToString());
                    list.Add(ficha);
                }

            }

            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return list;
        }

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
                    //{"code":4,"FichaIdPersona":[{"idFicha":4,"idPaciente":4,"idOdontologo":4,"fechaIngreso":"2013-08-12","anamnesis":"Diabetes","habilitada":0}]}
                    ficha.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    ficha.NombrePaciente = item.SelectToken("idPaciente").ToString();
                    ficha.NombreOdontologo = item.SelectToken("idOdontologo").ToString();
                    ficha.FechaIngreso = Convert.ToDateTime(item.SelectToken("fechaIngreso").ToString());
                    ficha.Anamnesis = item.SelectToken("anamnesis").ToString();
                    ficha.Habilitada = Convert.ToInt32(item.SelectToken("habilitada").ToString());
                    list.Add(ficha);
                }

            }

            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return list;
        }

        public string InsertarFichaDental(Fichadental ficha)
        {
            string fichaInsertada = string.Empty;
            //{"indice":1,"idPaciente":1,"idOdontologo":1,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":0}
            this.JsonParam = "send={\"indice\":1,\"idPaciente\":\"" + ficha.IdPaciente + "\", \"idOdontologo\":\"" + ficha.IdOdontologo + "\",\"fechaIngreso\":\"" + ficha.FechaIngreso + "\",\"anamnesis\":\"" + ficha.Anamnesis + "\",\"habilitada\":" + ficha.Anamnesis + "}";
            try
            {
                String result = netclient.NetPost(ipServer + "sfhwebservice/webService/ws-ficha-presupuesto.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idFichaInsertada":8}
                fichaInsertada = jobject.SelectToken("idTratamientoInsertada").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Fichas");
            }
            return fichaInsertada;
        }

        public string ModificarFichaDental(Fichadental ficha)
        {
            string fichaModificada = string.Empty;
            //{"indice":2,"idFicha":1,"idPaciente":1,"idOdontologo":1,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina"}
            this.JsonParam = "send={\"indice\":2,\"idFicha\":" + ficha.IdFicha + ",\"idPaciente\":" + ficha.IdPaciente + ",\"idOdontologo\":\"" + ficha.IdOdontologo + "\",\"fechaIngreso\":\"" + ficha.FechaIngreso + "\",\"anamnesis\":\"" + ficha.Anamnesis + "}";
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
    }
}
