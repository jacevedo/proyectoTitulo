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
    public class ClientWsAreaInsumoListas
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

        #region InsertarAreaInsumos
        public string InsertarAreaInsumos(Areainsumo area)
        {
            string areaInsumoInsertada = string.Empty;
            //{"indice":1,"nomArea":"Oficina","descripcion":"asd"}
            this.JsonParam = "{\"indice\":1,\"nomArea\":\""+area.NombreArea+"\",\"descripcion\":\""+area.DescripcionArea+"\"}";
            try
            {
                String result = netclient.NetPost("ws-area-insumo-listas.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"listaAreaInsumo":8}
                areaInsumoInsertada = jobject.SelectToken("listaAreaInsumo").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Area Insumos");
            }
            return areaInsumoInsertada;
        }
        #endregion

        #region ModificarAreaInsumo
        public string ModificarAreaInsumo(Areainsumo area)
        {
            string areaInsumoModificada = string.Empty;
            //{"indice":2,"idAreaInsumo":3,"nomArea":"Oficina","descripcion":"asd"}

            this.JsonParam = "{\"indice\":2,\"idAreaInsumo\":"+area.IdAreaInsumo+",\"nomArea\":\""+area.NombreArea+"\",\"descripcion\":\""+area.DescripcionArea+"\"}";
            try
            {
                String result = netclient.NetPost("ws-area-insumo-listas.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":2,"Modificado":"Modificado"}
                areaInsumoModificada = jobject.SelectToken("Modificado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Modificar Area Insumos");
            }
            return areaInsumoModificada;
        }
        #endregion

        #region EliminarAreaInsumo
        public string EliminarAreaInsumo(int idAreaInsumo)
        {
            string areaInsumoEliminado = string.Empty;
            //{"indice":3,"idAreaInsumo":3}
            this.JsonParam = "{\"indice\":3,\"idAreaInsumo\":" + idAreaInsumo + "}";
            try
            {
                String result = netclient.NetPost("ws-area-insumo-listas.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":3,"Eliminado":"Eliminado"}
                areaInsumoEliminado = jobject.SelectToken("Eliminado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al eliminar AreaInsumo");
            }
            return areaInsumoEliminado;
        }
        #endregion   

        #region ListarAreaInsumos

        public List<Areainsumo> ListarAreaInsumos()
        {
            List<Areainsumo> list = new List<Areainsumo>();
            try
            {
                this.JsonParam = "{\"indice\":4}";
                String result = netclient.NetPost("ws-area-insumo-listas.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("ListaAreaInsumo").ToList();
                foreach (var item in token)
                {
                    Areainsumo area = new Areainsumo();

                    //{"idAreaInsumo":1,"nombreArea":"Oficina","descripcionArea":"Insumos de Oficina"}
                    area.IdAreaInsumo = Convert.ToInt32(item.SelectToken("idAreaInsumo").ToString());
                    area.NombreArea = item.SelectToken("nombreArea").ToString();
                    area.DescripcionArea = item.SelectToken("descripcionArea").ToString();
                    list.Add(area);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Area Insumo");
            }
            return list;
        }
        #endregion

        #region ListarAreaInsumosIdNombre

        public List<Areainsumo> ListarAreaInsumosIdNombre()
        {
            List<Areainsumo> list = new List<Areainsumo>();
            try
            {
                this.JsonParam = "{\"indice\":5}";
                String result = netclient.NetPost("ws-area-insumo-listas.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaAreaInsuno").ToList();
                foreach (var item in token)
                {
                    Areainsumo area = new Areainsumo();

                    //{"idAreaInsumo":1,"nombreArea":"Oficina"}
                    area.IdAreaInsumo = Convert.ToInt32(item.SelectToken("idAreaInsumo").ToString());
                    area.NombreArea = item.SelectToken("nombreArea").ToString();
                    list.Add(area);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Area Insumo");
            }
            return list;
        }
        #endregion

        #region ListarGastos

        public List<Gastos> ListarGastos()
        {
            List<Gastos> list = new List<Gastos>();
            try
            {
                this.JsonParam = "{\"indice\":6}";
                String result = netclient.NetPost("ws-area-insumo-listas.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaGastos").ToList();
                foreach (var item in token)
                {
                    Gastos gastos = new Gastos();
                    //{"idGasto":1,"concepto":""}
                    gastos.IdGastos = Convert.ToInt32(item.SelectToken("idGasto").ToString());
                    gastos.ConceptodeGastos = item.SelectToken("concepto").ToString();
                    list.Add(gastos);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Gastos");
            }
            return list;
        }
        #endregion

        #region ListarInsumosIdNombre

        public List<Insumos> ListarInsumosIdNombre()
        {
            List<Insumos> list = new List<Insumos>();
            try
            {
                this.JsonParam = "{\"indice\":7}";
                String result = netclient.NetPost("ws-area-insumo-listas.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaInsumos").ToList();
                foreach (var item in token)
                {
                    Insumos insumo = new Insumos();
                    //{"idInsumos":1,"nomInsumos":"Jeringas"}
                    insumo.IdInsumos = Convert.ToInt32(item.SelectToken("idInsumos").ToString());
                    insumo.NomInsumos = item.SelectToken("nomInsumos").ToString();
                    list.Add(insumo);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Insumo");
            }
            return list;
        }
        #endregion
    }
}
