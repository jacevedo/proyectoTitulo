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
        public String NetPost(String url,String paramdata) {
            String request_post = string.Empty;
            try {
                
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                string postData = paramdata;
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
                request_post = responseFromServer;
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch{
                
                throw new Exception("Error: No se ha podido establecer la comunicación con el servidor");
            
            }
            return request_post;
        }
    }
}
