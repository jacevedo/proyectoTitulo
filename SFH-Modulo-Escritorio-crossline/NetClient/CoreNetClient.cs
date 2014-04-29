using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace NetClient
{
    public class CoreNetClient
    {
        ClientEncoding en = new ClientEncoding();
        SharedPreferences preferences = SharedPreferences.preferences;
        public String NetPost(String nom_page,String paramdata)
        {
            String request_post = string.Empty;

            /*Segmento de prueba 
            String url = "http://192.168.106.134/sfhwebservice/webService/" + nom_page;
            String url = "http://192.168.106.134/sfhwebservice/webServiceencriptado/" + nom_page;*/
            /*Segmento de produccion*/
            String url = "http://sfh.crossline.cl/webServiceencriptado/" + nom_page;
           
            try 
            {
                String paramdataKey = string.Empty;
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                if (preferences.Key != "")
                {
                    // ",\"nombre\":\""
                    paramdataKey = paramdata.Substring(0,paramdata.Length-1)+",\"key\":\""+preferences.Key+" \"}";
                    paramdata = string.Empty;
                    paramdata = paramdataKey;
                }
                String param_encript =  en.Encriptar(paramdata);
                string postData = "send=" + param_encript;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                request_post = en.Desencriptar(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch(Exception e)
            {               
                    throw new Exception("Error: No se ha podido establecer la comunicación con el servidor" + e);
            }
            return request_post;
        }
    }
}
