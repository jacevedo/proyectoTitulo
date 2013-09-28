package cl.sfh.controlaodas;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.util.Log;
import cl.sfh.entidades.ListaPreciosEntidad;
import cl.sfh.libreria.JSONParser;

public class ControladoraListaPrecios
{
	private String mensajeEnviar;
	public ArrayList<ListaPreciosEntidad> listarPrecios()
	{
		ArrayList<ListaPreciosEntidad> listaPrecios = new ArrayList<ListaPreciosEntidad>();
		mensajeEnviar = "{\"indice\":3}";
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
			Log.e("arreglos", arregloJson.get(0)+"");
		} 
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return listaPrecios;
	}
	public ArrayList<String> listarPrecios(int i)
	{
		Log.e("Controladora", "Entre");
		ArrayList<String> lista  = new ArrayList<String>();
		JSONObject jsonEnviar = new JSONObject();
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", "{\"indice\":3}"));
		JSONObject objetoJson = parser.makeHttpRequest("ws-precios-insumos.php",
														"POST", parametros);
		Log.e("Controladora", "Volvi");
		lista.add(objetoJson.toString());
		return lista;
	}
}
