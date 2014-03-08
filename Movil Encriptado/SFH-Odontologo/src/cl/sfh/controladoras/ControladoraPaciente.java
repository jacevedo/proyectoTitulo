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
import android.util.Log;
import cl.sfh.entidades.DatosContactoEditar;
import cl.sfh.entidades.Pacientes;
import cl.sfh.entidades.Tratamiento;
import cl.sfh.libreria.JSONParser;

public class ControladoraPaciente
{
	private String mensajeEnviar;
	private String key;
	
	public ControladoraPaciente(Activity actividad)
	{
		SharedPreferences preferencias = actividad.getSharedPreferences("datos",Context.MODE_PRIVATE);
		key = preferencias.getString("key", "");
	}
	
	public ArrayList<Pacientes> buscarPacientes(int ventana)
	{
		mensajeEnviar = "{\"indice\":12,\"cantPaciente\":"+ventana+",\"key\":\""+key+"\"}";
		ArrayList<Pacientes> listaPacientes = new ArrayList<Pacientes>();
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-tratamiento-abono.php","POST", parametros);
		try
		{
			JSONArray arregloObjetos = objetoJson.getJSONArray("lista");
			ArrayList<Pacientes> arregloPacientes = new ArrayList<Pacientes>();
			for(int i=0;i<arregloObjetos.length();i++)
			{
				ArrayList<Tratamiento> arregloTratamiento = new ArrayList<Tratamiento>();
				JSONObject arregloFor = (JSONObject)arregloObjetos.get(i);
				JSONObject persona = arregloFor.getJSONObject("persona");	
				JSONArray tratamientos = arregloFor.getJSONArray("tratamiento");
				String amamnesis = arregloFor.getString("amamnesis");
				for (int j = 0; j < tratamientos.length(); j++)
				{
					JSONObject objetoTratamientoFor = (JSONObject)tratamientos.get(j);
					int idTratamiento = objetoTratamientoFor.getInt("idTratamientoDental");
					int idFicha = objetoTratamientoFor.getInt("idFicha");
					String fechaCreacion = objetoTratamientoFor.getString("fechaCreacion");
					String tratamiento = objetoTratamientoFor.getString("tratamiento");
					String fechaSeguimiento = objetoTratamientoFor.getString("fechaSeguimiento");
					int valorTotal = objetoTratamientoFor.getInt("valorTotal");
					arregloTratamiento.add(new Tratamiento(idTratamiento, idFicha, fechaCreacion, tratamiento, fechaSeguimiento, valorTotal));
				}
				int idPaciente = persona.getInt("idPaciente");
				String nombre = persona.getString("nombre");
				String appPaterno = persona.getString("apellidoPaterno");
				String appMaterno = persona.getString("apellidoMaterno");
				String fechaNacimiento = persona.getString("fechaNacimiento"); 
				Pacientes paciente = new Pacientes(idPaciente, nombre, appPaterno, appMaterno, fechaNacimiento, amamnesis, arregloTratamiento);
				listaPacientes.add(paciente);
			}
		}
		catch(JSONException e)
		{
			
		}		
		return listaPacientes;
	}
	public ArrayList<Pacientes> buscarListaFiltro(String nomPaciente)
	{
		mensajeEnviar = "{\"indice\":13,\"nomPaciente\":\""+nomPaciente+"\",\"key\":\""+key+"\"}";
		ArrayList<Pacientes> listaPacientes = new ArrayList<Pacientes>();
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-tratamiento-abono.php","POST", parametros);
		try
		{
			JSONArray arregloObjetos = objetoJson.getJSONArray("lista");
			ArrayList<Pacientes> arregloPacientes = new ArrayList<Pacientes>();
			for(int i=0;i<arregloObjetos.length();i++)
			{
				ArrayList<Tratamiento> arregloTratamiento = new ArrayList<Tratamiento>();
				JSONObject arregloFor = (JSONObject)arregloObjetos.get(i);
				JSONObject persona = arregloFor.getJSONObject("persona");	
				JSONArray tratamientos = arregloFor.getJSONArray("tratamiento");
				String amamnesis = arregloFor.getString("amamnesis");
				for (int j = 0; j < tratamientos.length(); j++)
				{
					JSONObject objetoTratamientoFor = (JSONObject)tratamientos.get(j);
					int idTratamiento = objetoTratamientoFor.getInt("idTratamientoDental");
					int idFicha = objetoTratamientoFor.getInt("idFicha");
					String fechaCreacion = objetoTratamientoFor.getString("fechaCreacion");
					String tratamiento = objetoTratamientoFor.getString("tratamiento");
					String fechaSeguimiento = objetoTratamientoFor.getString("fechaSeguimiento");
					int valorTotal = objetoTratamientoFor.getInt("valorTotal");
					arregloTratamiento.add(new Tratamiento(idTratamiento, idFicha, fechaCreacion, tratamiento, fechaSeguimiento, valorTotal));
				}
				int idPaciente = persona.getInt("idPaciente");
				String nombre = persona.getString("nombre");
				String appPaterno = persona.getString("apellidoPaterno");
				String appMaterno = persona.getString("apellidoMaterno");
				String fechaNacimiento = persona.getString("fechaNacimiento"); 
				Pacientes paciente = new Pacientes(idPaciente, nombre, appPaterno, appMaterno, fechaNacimiento, amamnesis, arregloTratamiento);
				listaPacientes.add(paciente);
			}
		}
		catch(JSONException e)
		{
			
		}		
		return listaPacientes;
	}
}
