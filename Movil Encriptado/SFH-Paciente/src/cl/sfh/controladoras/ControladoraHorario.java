package cl.sfh.controladoras;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;
import cl.sfh.entidades.Horario;
import cl.sfh.entidades.HorasTomadas;
import cl.sfh.libreria.JSONParser;

public class ControladoraHorario
{
	private String mensajeEnviar ="";
	private String key;
	public ControladoraHorario(Activity actividad)
	{
		SharedPreferences preferencias = actividad.getSharedPreferences("datos",Context.MODE_PRIVATE);
		key = preferencias.getString("key",	"");
	}
	public ArrayList<Horario> getHorarioPorDia(String fecha)
	{
		ArrayList<Horario> listaHorario = new ArrayList<Horario>();
	
		mensajeEnviar = "{\"indice\":1,\"fecha\":\""+fecha+" 13:13:00\",\"key\":\""+key+"\"}";
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
		mensajeEnviar = "{\"indice\":1,\"idPaciente\":"+idPaciente+",\"idOdontologo\":"+idOdontologo+",\"fecha\":\""+fecha+"\",\"horaInicio\":\""+horaInicio+"\",\"estado\":"+estado+",\"key\":\""+key+"\"}";
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
	public ArrayList<HorasTomadas> listaHorasTomadas(int idPaciente)
	{
		ArrayList<HorasTomadas> listadoHoras =  new ArrayList<HorasTomadas>();
		Calendar calendarioo = GregorianCalendar.getInstance();
		
		String fecha=calendarioo.get(Calendar.YEAR)+"-"+(calendarioo.get(Calendar.MONTH)+1)+"-"+calendarioo.get(Calendar.DAY_OF_MONTH);
		mensajeEnviar = "{\"indice\":3,\"idPaciente\":"+idPaciente+",\"fecha\":\""+fecha+"\",\"key\":\""+key+"\"}";
		Log.e("fecha",fecha.toString());
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-cita.php","POST", parametros);
		
		try
		{
			JSONArray arreglo = objetoJson.getJSONArray("resultado");
			if(arreglo.length()>0)
			{
				Log.e("asd", "fecha: " + fecha);
				Log.e("asd", "id Paciente: " + idPaciente);
				Log.e("asd", "Resultado: " +objetoJson.toString());
				for (int i = 0; i < arreglo.length(); i++)
				{
					JSONObject objetoFor = (JSONObject)arreglo.get(i);
					String horaInicio = objetoFor.getString("horaInicio");
					String fechaJson = objetoFor.getString("fecha");
					String nombre = objetoFor.getString("nomOdontologo");
					String apellidoPaterno = objetoFor.getString("appPaternoOdontologo");
					String apellidoMaterno = objetoFor.getString("appMaternoOdontologo");
					String nombreCompleto = nombre +" " + apellidoPaterno +" " +apellidoMaterno;
					int idOdontologo = objetoFor.getInt("idOdontologo");
					String[] horaFiltro = horaInicio.split(" ");
					HorasTomadas horario = new HorasTomadas(nombreCompleto, idOdontologo, fechaJson, horaFiltro[1]);
					listadoHoras.add(horario);
				}
			}
		}
		catch(JSONException ex)
		{
			ex.printStackTrace();
		}
		return listadoHoras;
	}
}
