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
        #endregion

        public List<Fichadental> ListarFichas() { 
            List<Fichadental> list = new List<Fichadental>();
            
            try{
                String result = netclient.NetPost("http://192.168.191.136/sfhwebservice/webService/ws-ficha-presupuesto.php", "send={\"indice\":}");
                var jobject = JObject.Parse(result);
                var token = jobject.SelectToken("ListaFicha").ToList();
                foreach (var item in token)
                {
                    Fichadental ficha = new Fichadental();
                    //"idFicha":1,"idPaciente":1,"idOdontologo":1,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":0}
                    ficha.IdFicha = Convert.ToInt32(item.SelectToken("idFicha").ToString());
                    ficha.IdPaciente = Convert.ToInt32(item.SelectToken("idPaciente").ToString());
                    ficha.IdOdontologo = Convert.ToInt32(item.SelectToken("idOdontologo").ToString());
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
    }
}
