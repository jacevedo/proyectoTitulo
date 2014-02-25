package cl.sfh.controladoras;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import cl.sfh.entidades.ListaPreciosEntidad;
import cl.sfh.libreria.JSONParser;

public class ControladoraListaPrecios
{
	private String mensajeEnviar;
	private String key;
	public ControladoraListaPrecios(Activity actividad)
	{
		SharedPreferences preferencias = actividad.getSharedPreferences("datos",Context.MODE_PRIVATE);
		key = preferencias.getString("key",	"");
	}
	public ArrayList<ListaPreciosEntidad> listarPrecios()
	{
		ArrayList<ListaPreciosEntidad> listaPrecios = new ArrayList<ListaPreciosEntidad>();
		mensajeEnviar = "{\"indice\":3,\"key\":\""+key+"\"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-precios-insumos.php",
														"POST", parametros);
		
		try
		{
			JSONArray arregloJson = objetoJson.getJSONArray("listaPrecios");
			for(int i=0;i<arregloJson.length();i++)
			{
				//{"idPrecios":4,"comentario":"Urgencia. Tratamiento Inicial 1 Sesion","valorNeto":14500,"valorIva":2755,"valorTotal":14500}
				JSONObject objetoJsonFor = (JSONObject) arregloJson.get(i);
				ListaPreciosEntidad entidad = new ListaPreciosEntidad(
						objetoJsonFor.getInt("idPrecios"), objetoJsonFor.getString("comentario"),
						objetoJsonFor.getInt("valorNeto"), objetoJsonFor.getInt("valorIva"),
						objetoJsonFor.getInt("valorTotal"));
				listaPrecios.add(entidad);
				
			}
		} 
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return listaPrecios;
	}
	public ArrayList<ListaPreciosEntidad> listarPreciosNombres(String nombre)
	{
		ArrayList<ListaPreciosEntidad> listaPrecios = new ArrayList<ListaPreciosEntidad>();
		mensajeEnviar ="{\"indice\":4,\"nombre\":\""+nombre+"\",\"key\":\""+key+"\"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-precios-insumos.php",
														"POST", parametros);
		try
		{
			JSONArray arregloJson = objetoJson.getJSONArray("listaPrecios");
			for(int i=0;i<arregloJson.length();i++)
			{
				//{"idPrecios":4,"comentario":"Urgencia. Tratamiento Inicial 1 Sesion","valorNeto":14500,"valorIva":2755,"valorTotal":14500}
				JSONObject objetoJsonFor = (JSONObject) arregloJson.get(i);
				ListaPreciosEntidad entidad = new ListaPreciosEntidad(
						objetoJsonFor.getInt("idPrecios"), objetoJsonFor.getString("comentario"),
						objetoJsonFor.getInt("valorNeto"), objetoJsonFor.getInt("valorIva"),
						objetoJsonFor.getInt("valorTotal"));
				listaPrecios.add(entidad);
				
			}
		} 
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return listaPrecios;
	}
	
}
