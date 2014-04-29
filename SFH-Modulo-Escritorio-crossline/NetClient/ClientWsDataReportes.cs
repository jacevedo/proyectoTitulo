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
   public  class ClientWsDataReportes
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

        #region Listar Citas por Fechas --> reportes de pacinetes 
        public List<Cita> ListarCitasporFechas(DateTime fecha1,DateTime fecha2)
        {
            List<Cita> list = new List<Cita>();
            try
            {
                string fechaSend = fecha1.Year + "-" + fecha1.Month + "-" + fecha1.Day;
                string fechaSend2 = fecha2.Year + "-" + fecha2.Month + "-" + fecha2.Day;
                this.JsonParam = "{\"indice\":1,\"fechaInicio\":\"" + fechaSend + "\",\"fechaTermino\":\"" + fechaSend2 + "\"}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("citas").ToList();
                
                foreach (var item in token)
                {
                    //{"idCita":5,"idOdontologo":2,"idPaciente":1,"horaInicio":"2014-00-00 00:00:00","fecha":"2013-08-25","estado":0,"nomPaciente":null,"appPaternoPaciente":null,"appMaternoPaciente":null,"nomOdontologo":null,"appPaternoOdontologo":null,"appMaternoOdontologo":null}
                    Cita cita = new Cita();
                    cita.IdCita = Convert.ToInt32(item.SelectToken("idCita").ToString());
                    cita.IdOdontologo = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
                    cita.IdPaciente = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    cita.HoraInicio = Convert.ToDateTime(item.SelectToken("horaInicio").ToString());
                    cita.Fecha = Convert.ToDateTime(item.SelectToken("fecha").ToString());
                    list.Add(cita);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Citas");
            }
            return list;
        }
        #endregion

        #region Listar fechas Antiguas --> nuevas 
        public List<Cita> ListarCitasFechasAntNueva()
        {
            List<Cita> list = new List<Cita>();
            try
            {
                this.JsonParam = "{\"indice\":2}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("citas").ToList();
                foreach (var item in token)
                {
                    Cita cita = new Cita();
                    //{"idCita":5,"idOdontologo":2,"idPaciente":1,"horaInicio":"2014-00-00 00:00:00","fecha":"2013-08-25","estado":0,"nomPaciente":null,"appPaternoPaciente":null,"appMaternoPaciente":null,"nomOdontologo":null,"appPaternoOdontologo":null,"appMaternoOdontologo":null}
                    cita.IdCita = Convert.ToInt32(item.SelectToken("idCita").ToString());
                    cita.Fecha = Convert.ToDateTime(item.SelectToken("fecha").ToString());
                    list.Add(cita);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Citas");
            }
            return list;
        }
        #endregion

        #region Listar fechas Nuevas --> antiguas 
        public List<Cita> ListarCitasFechasNuevaAnt()
        {
            List<Cita> list = new List<Cita>();
            try
            {
                this.JsonParam = "{\"indice\":3}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("citas").ToList();
              
                foreach (var item in token)
                {
                    Cita cita = new Cita();
                    //{"idCita":5,"idOdontologo":2,"idPaciente":1,"horaInicio":"2014-00-00 00:00:00","fecha":"2013-08-25","estado":0,"nomPaciente":null,"appPaternoPaciente":null,"appMaternoPaciente":null,"nomOdontologo":null,"appPaternoOdontologo":null,"appMaternoOdontologo":null}
                    cita.IdCita = Convert.ToInt32(item.SelectToken("idCita").ToString());
                    cita.Fecha = Convert.ToDateTime(item.SelectToken("fecha").ToString());
                    list.Add(cita);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Citas");
            }
            return list;
        }
        #endregion

        #region Listar Abonos por Fechas --> reportes monetarios
        public List<Abono> ListarAbonosporFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Abono> list = new List<Abono>();
            try
            {
                string fechaSend = fecha1.Year + "-" + fecha1.Month + "-" + fecha1.Day;
                string fechaSend2 = fecha2.Year + "-" + fecha2.Month + "-" + fecha2.Day;
                this.JsonParam = "{\"indice\":4,\"fechaInicio\":\"" + fechaSend + "\",\"fechaTermino\":\"" + fechaSend2 + "\"}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("abonos").ToList();
               
                foreach (var item in token)
                {
                    Abono abono = new Abono();
                  // {"idAbono":4,"idTratamientoDental":4,"fechaAbono":"2013-08-19","monto":9000}
                    abono.IdAbono = Convert.ToInt32(item.SelectToken("idAbono").ToString());
                    abono.IdTratamientoDental = Convert.ToInt32(item.SelectToken("idTratamientoDental").ToString());
                    abono.FechaAbono = Convert.ToDateTime(item.SelectToken("fechaAbono").ToString());
                    abono.Monto = Convert.ToInt32(item.SelectToken("monto").ToString());

                    list.Add(abono);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Abonos");
            }
            return list;
        }
        #endregion

        #region Listar fechas Antiguas --> nuevas
        public List<Abono> ListarAbonosFechasAntNueva()
        {
            List<Abono> list = new List<Abono>();
            try
            {
                this.JsonParam = "{\"indice\":5}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("abonos").ToList();
                
                foreach (var item in token)
                {
                    Abono abono = new Abono();
                    //{"idAbono":1,"fecha":"1991-12-12"},{"idAbono":2,"fecha":"2013-06-24"},{"idAbono":4,"fecha":"2013-08-19"}
                    abono.IdAbono = Convert.ToInt32(item.SelectToken("idAbono").ToString());
                    abono.FechaAbono = Convert.ToDateTime(item.SelectToken("fecha").ToString());
                    list.Add(abono);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Abonos");
            }
            return list;
        }
        #endregion

        #region Listar fechas nuevas --> antiguas
        public List<Abono> ListarAbonosFechasNuevaAnt()
        {
            List<Abono> list = new List<Abono>();
            try
            {
                this.JsonParam = "{\"indice\":6}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("abonos").ToList();
               
                foreach (var item in token)
                {
                    Abono abono = new Abono();
                    //{"idAbono":1,"fecha":"1991-12-12"},{"idAbono":2,"fecha":"2013-06-24"},{"idAbono":4,"fecha":"2013-08-19"}
                    abono.IdAbono = Convert.ToInt32(item.SelectToken("idAbono").ToString());
                    abono.FechaAbono = Convert.ToDateTime(item.SelectToken("fecha").ToString());
                    list.Add(abono);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e + "| Error al Listar Abonos");
            }
            return list;
        }
        #endregion

        #region Listar Abonos por Fechas --> reportes monetarios
        public List<Gastos> ListarGastosporFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Gastos> list = new List<Gastos>();
            try
            {
                string fechaSend = fecha1.Year + "-" + fecha1.Month + "-" + fecha1.Day;
                string fechaSend2 = fecha2.Year + "-" + fecha2.Month + "-" + fecha2.Day;
                this.JsonParam = "{\"indice\":7,\"fechaInicio\":\"" + fechaSend + "\",\"fechaTermino\":\"" + fechaSend2 + "\"}";
                String result = netclient.NetPost("ws-reportes.php", this.JsonParam);
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("gastos").ToList();
                foreach (var item in token)
                {
                    //{"idGastos":2,"idPersona":1,"conceptoGasto":"Colacion casa","montoGastos":2000,"descuentoGastos":0,"nomPersona":"","apellidoPersona":"","fechaGasto":"2013-11-16"}
                    Gastos gasto = new Gastos();
                    gasto.IdGastos = Convert.ToInt32(item.SelectToken("idGastos").ToString());
                    gasto.IdPersona = Convert.ToInt32(item.SelectToken("idPersona").ToString());
                    gasto.ConceptodeGastos = item.SelectToken("conceptoGasto").ToString();
                    gasto.MontoGastos = Convert.ToInt32(item.SelectToken("montoGastos").ToString());
                    gasto.DescuentoGastos = Convert.ToInt32(item.SelectToken("descuentoGastos").ToString());
                    gasto.FechaGastos = Convert.ToDateTime(item.SelectToken("fechaGasto").ToString());
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

    }
}
