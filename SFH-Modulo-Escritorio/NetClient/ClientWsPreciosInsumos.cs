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
    public class ClientWsPreciosInsumos
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

        #region ListarPrecios

        public List<Listadeprecio>ListarPrecios()
        {
            List<Listadeprecio> list = new List<Listadeprecio>();
            try
            {
                this.JsonParam = "send={\"indice\":3}";
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPrecios").ToList();
                foreach (var item in token)
                {
                    Listadeprecio precio = new Listadeprecio();
                    //{"idPrecios":4,"comentario":"Urgencia. Tratamiento Inicial 1 Sesion","valorNeto":14500,"valorIva":2755,"valorTotal":14500}
                    precio.IdPrecios = Convert.ToInt32(item.SelectToken("idPrecios").ToString());
                    precio.Comentario = item.SelectToken("comentario").ToString();
                    precio.ValorNeto = item.SelectToken("valorNeto").ToString();
                    precio.ValorIva = item.SelectToken("valorIva").ToString();
                    precio.Valortotal = item.SelectToken("valorTotal").ToString();
                    list.Add(precio);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Precios");
            }
            return list;
        }
        #endregion
      

        #region InsertarPrecio
        public string InsertarPrecio(Listadeprecio precio)
        {
            string precioInsertado = string.Empty;
            //{"indice":1,"Comentario":"Procedimiento","ValorNeto":12000}
            this.JsonParam = "send={\"indice\":1,\"Comentario\":\"" + precio.Comentario + "\",\"ValorNeto:" + precio.ValorNeto + "}";
            try
            {
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":1,"idPrecioInsertado":31}
                precioInsertado = jobject.SelectToken("idPrecioInsertado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Precio");
            }
            return precioInsertado;
        }
        #endregion

        #region ModificarPrecio
        public string ModificarPrecio(Listadeprecio precio)
        {
            string precioModificado = string.Empty;
            //{"indice":2,"idPrecio":2,"Comentario":"asd","ValorNeto":130}
            this.JsonParam = "send={\"indice\":2,\"idPrecio\":" + precio.IdPrecios + ",\"Comentario\":\"" + precio.Comentario + "\",\"ValorNeto:" + precio.ValorNeto + "}";
            try
            {
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":2,"Modificado":"Modificado"}
                precioModificado = jobject.SelectToken("Modificado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Modificar Precio");
            }
            return precioModificado;
        }
        #endregion

        #region BuscarPreciosPorNombre
        public List<Listadeprecio> BuscarPreciosPorNombre(string nombre)
        {
            List<Listadeprecio> list = new List<Listadeprecio>();
            try
            {
                //{"indice":4,"nombre":"Urgencia"}
                this.JsonParam = "send={\"indice\":4,\"nombre\":\"" + nombre + "\"}";
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("listaPrecios").ToList();
                foreach (var item in token)
                {
                    Listadeprecio precio = new Listadeprecio();
                    //{"code":4,"listaPrecios":[{"idPrecios":4,"comentario":"Urgencia. Tratamiento Inicial 1 Sesion","valorNeto":14500,"valorIva":2755,"valorTotal":14500}]}
                    precio.IdPrecios = Convert.ToInt32(item.SelectToken("idPrecios").ToString());
                    precio.Comentario = item.SelectToken("comentario").ToString();
                    precio.ValorNeto = item.SelectToken("valorNeto").ToString();
                    precio.ValorIva = item.SelectToken("valorIva").ToString();
                    precio.Valortotal = item.SelectToken("valorTotal").ToString();
                    list.Add(precio);
                }

            }

            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Precios");
            }
            return list;
        }
        #endregion

        #region EliminarPrecio
        public string EliminarPrecio(int idprecio)
        {
            string precioEliminado= string.Empty;
            //{"indice":5,"idPrecio":12}
            this.JsonParam = "send={\"indice\":5,\"idPrecio\":" + idprecio + "}";
            try
            {
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":5,"Eliminado":"Eliminado"}
                precioEliminado = jobject.SelectToken("Eliminado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al eliminar Precio");
            }
            return precioEliminado;
        }
        #endregion

        #region InsertarInsumo
        public string InsertarInsumo(Insumos insumo)
        {
            string precioInsertado = string.Empty;
            //{"indice":6,"idAreaInsumo":3,"idGasto":1,"nomInsumo":"Jeringas 10 ML", "Cantidad":10, "descInsumo": "Compra al por mayor","unidadMedida":10}
            this.JsonParam = "send={\"indice\":6,\"idAreaInsumo\":"+insumo.IdAreaInsumo+",\"idGasto\":"+ insumo.IdGastos +",\"nomInsumo\":\""+insumo.NomInsumos+"\",\"Cantidad\":\"" +insumo.Cantidad+ "\",\"descInsumo\":\"" +insumo.DescripcionInsumo+"\",\"unidadMedida\":"+insumo.UnidadMedida+"}";
            try
            {
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":6,"idInsertado":4}
                precioInsertado = jobject.SelectToken("idInsertado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al insertar Insumos");
            }
            return precioInsertado;
        }
        #endregion

        #region ModificarInsumo
        public string ModificarInsumo(Insumos insumo)
        {
            string precioModificado = string.Empty;
            //{"indice":7,"idInsumo":2,"idAreaInsumo":3,"idGasto":1,"nomInsumo":"Jeringas 15 ML", "Cantidad":10,"descInsumo": "Compra al por mayor", "unidadMedida":10}
            this.JsonParam = "send={\"indice\":7,\"idInsumo\":"+insumo.IdInsumos+",\"idAreaInsumo\":" + insumo.IdAreaInsumo + ",\"idGasto\":" + insumo.IdGastos + ",\"nomInsumo\":\"" + insumo.NomInsumos + "\",\"Cantidad\":\"" + insumo.Cantidad + "\",\"descInsumo\":\"" + insumo.DescripcionInsumo + "\",\"unidadMedida\":" + insumo.UnidadMedida + "}";
            try
            {
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                //{"code":7,"Modificado":"Modificado"}
                precioModificado = jobject.SelectToken("Modificado").ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Modificar Insumo");
            }
            return precioModificado;
        }
        #endregion

        #region ListarInsumos

        public List<Insumos> ListarInsumos()
        {
            List<Insumos> list = new List<Insumos>();
            try
            {
                this.JsonParam = "send={\"indice\":8}";
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("ListaInsumos").ToList();
                foreach (var item in token)
                {
                    Insumos insumo = new Insumos();
                    //{"idInsumos":1,"idAreaInsumo":3,"idGastos":1,"nomInsumos":"Jeringas","cantidad":3,"descripcionInsumo":"Compra de Jeringas","unidadMedida":"Unidad","nomAreaInsumo":"Jeringas","conceptoGasto":""}
                    insumo.IdInsumos = Convert.ToInt32(item.SelectToken("idAreaInsumo").ToString());
                    insumo.IdAreaInsumo = Convert.ToInt32(item.SelectToken("idGastos").ToString());
                    insumo.NomInsumos = item.SelectToken("nomInsumos").ToString();
                    insumo.Cantidad = Convert.ToInt32(item.SelectToken("cantidad").ToString());
                    insumo.DescripcionInsumo = item.SelectToken("descripcionInsumo").ToString();
                    insumo.UnidadMedida = item.SelectToken("unidadMedida").ToString();
                    insumo.NomAreaInsumo = item.SelectToken("nomAreaInsumo").ToString();
                    insumo.ConceptoGasto = item.SelectToken("conceptoGasto").ToString();
                    list.Add(insumo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Insumos");
            }
            return list;
        }
        #endregion

        #region ListarInsumosPorId

        public List<Insumos> ListarInsumosPorId(int idInsumo)
        {
            List<Insumos> list = new List<Insumos>();
            try
            {
                //{"indice":9,"idAreaInsumo":3}
                this.JsonParam = "send={\"indice\":9,\"idAreaInsumo\":"+idInsumo+"}";
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("ListaInsumos").ToList();
                foreach (var item in token)
                {
                    Insumos insumo = new Insumos();
                    //{"idInsumos":1,"idAreaInsumo":3,"idGastos":1,"nomInsumos":"Jeringas","cantidad":3,"descripcionInsumo":"Compra de Jeringas","unidadMedida":"Unidad","nomAreaInsumo":"Jeringas","conceptoGasto":""}
                    insumo.IdInsumos = Convert.ToInt32(item.SelectToken("idAreaInsumo").ToString());
                    insumo.IdAreaInsumo = Convert.ToInt32(item.SelectToken("idGastos").ToString());
                    insumo.NomInsumos = item.SelectToken("nomInsumos").ToString();
                    insumo.Cantidad = Convert.ToInt32(item.SelectToken("cantidad").ToString());
                    insumo.DescripcionInsumo = item.SelectToken("descripcionInsumo").ToString();
                    insumo.UnidadMedida = item.SelectToken("unidadMedida").ToString();
                    insumo.NomAreaInsumo = item.SelectToken("nomAreaInsumo").ToString();
                    insumo.ConceptoGasto = item.SelectToken("conceptoGasto").ToString();
                    list.Add(insumo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Insumos");
            }
            return list;
        }
        #endregion

        #region ListarInsumosPorId

        public List<Insumos> ListarInsumosPorIdGastos(int idGasto)
        {
            List<Insumos> list = new List<Insumos>();
            try
            {
                //{"indice":10,"idAreaInsumo":3}
                this.JsonParam = "send={\"indice\":10,\"idAreaInsumo\":" + idGasto + "}";
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("ListaInsumos").ToList();
                foreach (var item in token)
                {
                    Insumos insumo = new Insumos();
                    //{"idInsumos":1,"idAreaInsumo":3,"idGastos":1,"nomInsumos":"Jeringas","cantidad":3,"descripcionInsumo":"Compra de Jeringas","unidadMedida":"Unidad","nomAreaInsumo":"Jeringas","conceptoGasto":""}
                    insumo.IdInsumos = Convert.ToInt32(item.SelectToken("idAreaInsumo").ToString());
                    insumo.IdAreaInsumo = Convert.ToInt32(item.SelectToken("idGastos").ToString());
                    insumo.NomInsumos = item.SelectToken("nomInsumos").ToString();
                    insumo.Cantidad = Convert.ToInt32(item.SelectToken("cantidad").ToString());
                    insumo.DescripcionInsumo = item.SelectToken("descripcionInsumo").ToString();
                    insumo.UnidadMedida = item.SelectToken("unidadMedida").ToString();
                    insumo.NomAreaInsumo = item.SelectToken("nomAreaInsumo").ToString();
                    insumo.ConceptoGasto = item.SelectToken("conceptoGasto").ToString();
                    list.Add(insumo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Insumos");
            }
            return list;
        }
        #endregion


        #region ListarInsumosPorNombre

        public List<Insumos> ListarInsumosPorNombre(string nombre)
        {
            List<Insumos> list = new List<Insumos>();
            try
            {
                //{"indice":10,"idAreaInsumo":3}
                this.JsonParam = "send={\"indice\":11,\"idAreaInsumo\":\""+ nombre +"\"}";
                String result = netclient.NetPost("ws-precios-insumos.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("ListaInsumos").ToList();
                foreach (var item in token)
                {
                    Insumos insumo = new Insumos();
                    //{"idInsumos":1,"idAreaInsumo":3,"idGastos":1,"nomInsumos":"Jeringas","cantidad":3,"descripcionInsumo":"Compra de Jeringas","unidadMedida":"Unidad","nomAreaInsumo":"Jeringas","conceptoGasto":""}
                    insumo.IdInsumos = Convert.ToInt32(item.SelectToken("idAreaInsumo").ToString());
                    insumo.IdAreaInsumo = Convert.ToInt32(item.SelectToken("idGastos").ToString());
                    insumo.NomInsumos = item.SelectToken("nomInsumos").ToString();
                    insumo.Cantidad = Convert.ToInt32(item.SelectToken("cantidad").ToString());
                    insumo.DescripcionInsumo = item.SelectToken("descripcionInsumo").ToString();
                    insumo.UnidadMedida = item.SelectToken("unidadMedida").ToString();
                    insumo.NomAreaInsumo = item.SelectToken("nomAreaInsumo").ToString();
                    insumo.ConceptoGasto = item.SelectToken("conceptoGasto").ToString();
                    list.Add(insumo);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Insumos");
            }
            return list;
        }
        #endregion
    }
}
