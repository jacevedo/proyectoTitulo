using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace EjemploConsumoRest
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
           
            InitializeComponent();
            
        }
        /*
        private void Form1_Load(object sender, EventArgs e)
        {

            String url = "http://192.168.1.216/proyectoTitulo/sfhwebservice/webService/ws-admin-usuario.php?send=" + "{\"indice\":12}";
            //string send = "send={"+'"'+"indice"+'"'+":12}";
            string send = "";
            string resp = RESTHeper.RESTHeper.Ejecutar(url, send, "GET");
            List<Persona> lstEstudiante = resp.DeserializarJsonTo<List<Persona>>();
            dgvEstudiantes.DataSource = lstEstudiante;
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {

            
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://192.168.191.136/sfhwebservice/webService/ws-admin-usuario.php");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "send={\"indice\":12}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);
            // Clean up the streams.
           //String x = RESTHeper.RESTHeper.ClearJSON(responseFromServer);
           //List<Persona> lstEstudiante = x.DeserializarJsonTo<List<Persona>>();
           //dgvEstudiantes.DataSource = lstEstudiante;
            //reader.Close();
           // dataStream.Close();
           // response.Close();
            var jobject =  JObject.Parse(responseFromServer);
            var token = jobject.SelectToken("listaPersonas").ToList();
            List<Persona> lista = new List<Persona>();
            MessageBox.Show(token.Count.ToString(), "--.---");
            foreach (var item in token)
            {

                MessageBox.Show(item.SelectToken("nombre").ToString(), "--.---");
                Persona per = JsonConvert.DeserializeObject<Persona>(item.ToString());
                lista.Add(per);
            }

           
            
        
        }


    }
}
