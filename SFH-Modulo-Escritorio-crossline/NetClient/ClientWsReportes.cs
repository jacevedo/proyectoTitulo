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
    public class ClientWsReportes
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

        #region Metodos 
       
        #region Ingresar Reporte


        #endregion 

        #region Listar Reportes  -->Historial de reportes
        public List<Reporte> ListarReportes()
        {
            List<Reporte> list = new List<Reporte>();
            try
            {
                this.JsonParam = "{\"indice\":8}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("reportes").ToList();

                foreach (var item in token)
                {
                    //{"rut":"17231233","dv":"2","nombre":"Ada","appPaterno":"Tatus","appMaterno":"Boren","idReporte":2,"fechaCreacion":"2013-10-24","tipoReporte":"Reporte Alumno"}
                    Reporte reporte = new Reporte();
                    reporte.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
                    reporte.Dv = item.SelectToken("dv").ToString();
                    reporte.Nombre = item.SelectToken("nombre").ToString();
                    reporte.ApellidoPaterno = item.SelectToken("appPaterno").ToString();
                    reporte.ApellidoMaterno = item.SelectToken("appMaterno").ToString();
                    reporte.IdReporte = Convert.ToInt32(item.SelectToken("idReporte").ToString());
                    reporte.FechaCreacion = Convert.ToDateTime(item.SelectToken("fechaCreacion").ToString());
                    reporte.TipoReporte = item.SelectToken("tipoReporte").ToString();
                    list.Add(reporte);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Reportes");
            }
            return list;
        }
        #endregion

        #region Listar Reportes por Fechas -->Historial de reportes 
        public List<Reporte> ListarReportesFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Reporte> list = new List<Reporte>();
            try
            {
                string fechaSend = fecha1.Year + "-" + fecha1.Month + "-" + fecha1.Day;
                string fechaSend2 = fecha2.Year + "-" + fecha2.Month + "-" + fecha2.Day;
                this.JsonParam = "{\"indice\":9,\"fechaInicio\":\"" + fechaSend + "\",\"fechaTermino\":\"" + fechaSend2 + "\"}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("reportes").ToList();

                foreach (var item in token)
                {
                    //{"rut":"17231233","dv":"2","nombre":"Ada","appPaterno":"Tatus","appMaterno":"Boren","idReporte":2,"fechaCreacion":"2013-10-24","tipoReporte":"Reporte Alumno"}
                    Reporte reporte = new Reporte();
                    reporte.Rut = Convert.ToInt32(item.SelectToken("rut").ToString());
                    reporte.Dv = item.SelectToken("dv").ToString();
                    reporte.Nombre = item.SelectToken("nombre").ToString();
                    reporte.ApellidoPaterno = item.SelectToken("appPaterno").ToString();
                    reporte.ApellidoMaterno = item.SelectToken("appMaterno").ToString();
                    reporte.IdReporte = Convert.ToInt32(item.SelectToken("idReporte").ToString());
                    reporte.FechaCreacion = Convert.ToDateTime(item.SelectToken("fechaCreacion").ToString());
                    reporte.TipoReporte = item.SelectToken("tipoReporte").ToString();
                    list.Add(reporte);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Reportes");
            }
            return list;
        }
        #endregion

        #region Listar fechas Antiguas --> nuevas
        public List<Reporte> ListarReportesFechasAntNueva()
        {
            List<Reporte> list = new List<Reporte>();
            try
            {
                this.JsonParam = "{\"indice\":10}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("reportes").ToList();

                foreach (var item in token)
                {
                    Reporte repo = new Reporte();
                    //,{"idReporte":1,"fechaCreacion":"2013-09-10"}
                    repo.IdReporte = Convert.ToInt32(item.SelectToken("idReporte").ToString());
                    repo.FechaCreacion = Convert.ToDateTime(item.SelectToken("fechaCreacion").ToString());
                    list.Add(repo);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Reportes");
            }
            return list;
        }
        #endregion

        #region Listar fechas nuevas --> antiguas
        public List<Reporte> ListarReportesFechasNuevaAnt()
        {
            List<Reporte> list = new List<Reporte>();
            try
            {
                this.JsonParam = "{\"indice\":11}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("reportes").ToList();

                foreach (var item in token)
                {
                    Reporte repo = new Reporte();
                    //,{"idReporte":1,"fechaCreacion":"2013-09-10"}
                    repo.IdReporte = Convert.ToInt32(item.SelectToken("idReporte").ToString());
                    repo.FechaCreacion = Convert.ToDateTime(item.SelectToken("fechaCreacion").ToString());
                    list.Add(repo);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Reportes");
            }
            return list;
        }
        #endregion

        #endregion
    }
}
