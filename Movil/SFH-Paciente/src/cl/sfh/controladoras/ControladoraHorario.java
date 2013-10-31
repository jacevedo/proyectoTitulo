package cl.sfh.controladoras;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import cl.sfh.entidades.Horario;
import cl.sfh.libreria.JSONParser;

public class ControladoraHorario
{
	String mensajeEnviar ="";
	public ArrayList<Horario> getHorarioPorDia(String fecha)
	{
		ArrayList<Horario> listaHorario = new ArrayList<Horario>();
	
		mensajeEnviar = "{\"indice\":1,\"fecha\":\""+fecha+" 13:13:00\"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-horario.php",
														"POST", parametros);
		try
		{
			JSONArray arregloJson = objetoJson.getJSONArray("listaHorarios");
			
			for(int i=0;i<arregloJson.length();i++)
			{
				JSONObject objetoJsonFor = (JSONObject) arregloJson.get(i);
				JSONObject arregloHorario = objetoJsonFor.getJSONObject("horario");
				String key = objetoJsonFor.getString("numKeys");
				String[]keys = key.split(",");
				ArrayList<String> arregloString = new ArrayList<String>();
				for (String string : keys)
				{
					arregloString.add(arregloHorario.getString("hora-"+string));
				}
				//{"idPrecios":4,"comentario":"Urgencia. Tratamiento Inicial 1 Sesion","valorNeto":14500,"valorIva":2755,"valorTotal":14500}
				
				Horario entidad = new Horario(
						objetoJsonFor.getInt("idOdontologo"), objetoJsonFor.getString("nomOdontologo"),
						arregloString);
				listaHorario.add(entidad);
				
			}
		} 
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return listaHorario;
	}
	public String tomarHora(int idPaciente, int idOdontologo, String fecha, String horaInicio, int estado)
	{
		String resultado="";
		mensajeEnviar = "{\"indice\":1,\"idPaciente\":"+idPaciente+",\"idOdontologo\":"+idOdontologo+",\"fecha\":\""+fecha+"\",\"horaInicio\":\""+horaInicio+"\",\"estado\":"+estado+"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-cita.php",
				"POST", parametros);
		try
		{
			resultado = objetoJson.getString("resultado");
		}
		catch(JSONException ex)
		{
			ex.printStackTrace();
		}
		return resultado;
	}
}
