using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace RESTHeper
{
    public static class RESTHeper
    {
        public static string Ejecutar(string Url, string Datos, string Metodo)
        {
            string json= "[]";
            try
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(Datos);

                HttpWebRequest request;
                request = WebRequest.Create(Url) as HttpWebRequest;
                request.Timeout = 10 * 1000;
                request.Method = Metodo;
                request.ContentLength = data.Length;
                request.ContentType = "text/json";
                Stream postStream = request.GetRequestStream();
                postStream.Write(data, 0, data.Length);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());

                json = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ClearJSON(json);
        }

        public static string ClearJSON(string Json) {
            if (Json.IndexOf("{\"code\":12\",\"listaPersonas\":") > -1)
            {
                Json = Json.Replace("{\"code\":12\",\"listaPersonas\":", "");
                Json = Json.Remove(Json.Length - 1);
            }
            return Json;
        }
    }
}
