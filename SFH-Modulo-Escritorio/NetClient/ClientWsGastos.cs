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
    public class ClientWsGastos
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

        #region InsertarGatos
        public string InsertarGatos(Gastos gasto)
        {
            string gastoInsertado = string.Empty;
            //{"indice":1,"idPersona":1,"conceptoGasto":"Colacion","montoGasto":2000,"descuentoGasto":0}
            this.JsonParam = "send={\"indice\":1,\"idPersona\":"+gasto.IdPersona+",\"conceptoGasto\":\""+gasto.ConceptodeGastos+"\",\"montoGasto\":"+gasto.MontoGastos+",\"descuentoGasto\":"+gasto.DescuentoGastos+ "}";
            try
            {
                String result = netclient.NetPost("ws-gastos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idGastoInsertado":5}
                gastoInsertado = jobject.SelectToken("idGastoInsertado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Gastos");
            }
            return gastoInsertado;
        }
        #endregion

        #region ModificarGastos
        public string ModificarGastos(Gastos gasto)
        {
            string gastoModificado = string.Empty;
            //{"indice":2,"idGasto":4,"idPersona":1,"conceptoGasto":"Colacionjsjjss","montoGasto":2000,"descuentoGasto":14}
            this.JsonParam = "send={\"indice\":1,\"idGasto\":"+gasto.IdGastos+",\"idPersona\":"+gasto.IdPersona+",\"conceptoGasto\":\""+gasto.ConceptodeGastos+"\",\"montoGasto\":"+gasto.MontoGastos+",\"descuentoGasto\":"+gasto.DescuentoGastos+ "}";
            try
            {
                String result = netclient.NetPost("ws-gastos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":7,"Modificado":"Modificado"}
                gastoModificado = jobject.SelectToken("idGastoModificado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Modificar Gasto");
            }
            return gastoModificado;
        }
        #endregion


        #region ListarGastos

        public List<Gastos> ListarGastos()
        {
            List<Gastos> list = new List<Gastos>();
            try
            {
                this.JsonParam = "send={\"indice\":3}";
                String result = netclient.NetPost("ws-gastos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaGastos").ToList();
                foreach (var item in token)
                {
                    Gastos gasto = new Gastos();
                    //{"idGastos":2,"idPersona":1,"conceptoGasto":"","montoGastos":30000,"descuentoGastos":40000,"nomPersona":"Ada","apellidoPersona":"Tatus"}
                    gasto.IdGastos = Convert.ToInt32(item.SelectToken("idGastos").ToString());
                    gasto.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    gasto.ConceptodeGastos = item.SelectToken("conceptoGasto").ToString();
                    gasto.MontoGastos = Convert.ToInt32(item.SelectToken("montoGastos").ToString());
                    gasto.DescuentoGastos = Convert.ToInt32(item.SelectToken("descuentoGastos").ToString());
                    gasto.Nombre = item.SelectToken("nomPersona").ToString();
                    gasto.Apellido = item.SelectToken("apellidoPersona").ToString();
                    list.Add(gasto);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Gastos");
            }
            return list;
        }
        #endregion


        #region ListarGastos

        public List<Gastos> ListarGastos(int id_gastos)
        {
            List<Gastos> list = new List<Gastos>();
            try
            {
                this.JsonParam = "send={\"indice\":4,\"idPersona\":"+id_gastos+"}";
                String result = netclient.NetPost("ws-gastos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaGastos").ToList();
                foreach (var item in token)
                {
                    Gastos gasto = new Gastos();
                    //{"idGastos":2,"idPersona":1,"conceptoGasto":"","montoGastos":30000,"descuentoGastos":40000,"nomPersona":"Ada","apellidoPersona":"Tatus"}
                    gasto.IdGastos = Convert.ToInt32(item.SelectToken("idGastos").ToString());
                    gasto.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    gasto.ConceptodeGastos = item.SelectToken("conceptoGasto").ToString();
                    gasto.MontoGastos = Convert.ToInt32(item.SelectToken("montoGastos").ToString());
                    gasto.DescuentoGastos = Convert.ToInt32(item.SelectToken("descuentoGastos").ToString());
                    gasto.Nombre = item.SelectToken("nomPersona").ToString();
                    gasto.Apellido = item.SelectToken("apellidoPersona").ToString();
                    list.Add(gasto);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Gastos");
            }
            return list;
        }
        #endregion

        #region EliminarGasto
        public string EliminarGasto(int idgasto)
        {
            string gastoEliminado = string.Empty;
            //{"indice":5,"idPrecio":12}
            this.JsonParam = "send={\"indice\":5,\"idPrecio\":" + idgasto + "}";
            try
            {
                String result = netclient.NetPost("ws-gastos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":5,"Eliminado":"Eliminado"}
                gastoEliminado = jobject.SelectToken("Eliminado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al eliminar Gasto");
            }
            return gastoEliminado;
        }
        #endregion

    }
}
