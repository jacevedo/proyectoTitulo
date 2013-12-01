package cl.sfh.controladoras;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.util.Log;
import cl.sfh.entidades.Comunas;
import cl.sfh.entidades.DatosContactoEditar;
import cl.sfh.entidades.Region;
import cl.sfh.libreria.JSONParser;

public class ControladoraEditarDatosContacto
{
	String mensajeEnviar;
	public DatosContactoEditar obtenerDatosContaco(int rut)
	{
		mensajeEnviar = "{\"indice\":2,\"rut\":"+rut+"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-add-usuario.php","POST", parametros);
		Log.e("asd",objetoJson.toString());
		
		try
		{
			
			String datosContactoString = objetoJson.getString("datosContacto");
			String fonoCelular = "";
			String direccion = "";
			String correo = "";
			String fechaIngreso = "";
			String fonoFijo = "";
			int comuna = -1;
			int region = -1;		
			
			JSONObject datosPersona = objetoJson.getJSONObject("datosPersona");
			int perfil = datosPersona.getInt("idPerfil");
			String dv = datosPersona.getString("dv");
			String apellidoMaterno = datosPersona.getString("apellidoMaterno");
			String fechaNacimiento = datosPersona.getString("fechaNacimiento");
			int idPersona = datosPersona.getInt("idPersona");
			String nombre = datosPersona.getString("nombre");
			String appPaterno 	= datosPersona.getString("apellidoPaterno");
			
			if(datosContactoString.compareToIgnoreCase("No hay datos de contacto")!=0)
			{
				JSONObject datosContactoJson = objetoJson.getJSONObject("datosContacto");
				fonoCelular = datosContactoJson.getString("fonoCelular");
				direccion = datosContactoJson.getString("direccion");
				correo = datosContactoJson.getString("mail");
				fechaIngreso = datosContactoJson.getString("fechaIngreso");
				fonoFijo = datosContactoJson.getString("fonoFijo");
				JSONObject datoComuna = objetoJson.getJSONObject("datoComuna");
				comuna = datoComuna.getInt("idComuna");
				region = datoComuna.getInt("idRegion");		
			}
			
			DatosContactoEditar datosContacto = new DatosContactoEditar(idPersona,rut,perfil, dv, nombre, appPaterno,
					apellidoMaterno, fechaNacimiento, fechaIngreso, fonoFijo, fonoCelular, direccion, comuna,
					region, correo);
			return datosContacto;
		} 
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
	}
	public ArrayList<Region> obtenerRegiones()
	{
		ArrayList<Region> listaRegiones = new ArrayList<Region>();
		mensajeEnviar = "{\"indice\":3}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-add-usuario.php","POST", parametros);
		Log.e("asd",objetoJson.toString());
		
		try
		{
			JSONArray arreglo = objetoJson.getJSONArray("listaRegiones");
			if(arreglo.length()!=0)
			{
				Region regionInicial = new Region(-1, "Seleccione Region", "P");
				listaRegiones.add(regionInicial);
				for (int i = 0; i < arreglo.length(); i++)
				{
					JSONObject objetoJsonFor = (JSONObject)arreglo.get(i);
					int idRegion = objetoJsonFor.getInt("idRegion");
					String nomRegion = objetoJsonFor.getString("nombreRegion");
					String numRegionRomano = objetoJsonFor.getString("numeroRegionRomano");
					Region region = new Region(idRegion, nomRegion, numRegionRomano);
					listaRegiones.add(region);
					
				}
			}
			else
			{
				Region regionInicial = new Region(-1, "No pudimos encontrar Regiones", "P");
				listaRegiones.add(regionInicial);
			}
			return listaRegiones;
		} 
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			Region regionInicial = new Region(-1, "No pudimos encontrar Regiones", "P");
			listaRegiones.add(regionInicial);
			return listaRegiones;
		}
	}
	public ArrayList<Comunas> obtenerComunas()
	{
		ArrayList<Comunas> listaComunas = new ArrayList<Comunas>();
		mensajeEnviar = "{\"indice\":7}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-add-usuario.php","POST", parametros);

		
		try
		{
			JSONArray arreglo = objetoJson.getJSONArray("datoComuna");
			if(arreglo.length()!=0)
			{
				Comunas comunaInicial  = new Comunas(-1, -1, "Seleccione Comuna");
				listaComunas.add(comunaInicial);
				for (int i = 0; i < arreglo.length(); i++)
				{
					JSONObject objetoJsonFor = (JSONObject)arreglo.get(i);
					int idComuna = objetoJsonFor.getInt("idComuna");
					int idRegion = objetoJsonFor.getInt("idRegion");
					String nomComuna = objetoJsonFor.getString("nombreComuna");
					Comunas comuna  = new Comunas(idComuna, idRegion, nomComuna);
					listaComunas.add(comuna);
					
				}
			}
			else
			{
				Comunas comunaInicial  = new Comunas(-1, -1, "No pudimos encontrarComunas");
				listaComunas.add(comunaInicial);
			}
			return listaComunas;
		} 
		catch (JSONException e)
		{
			Comunas comunaInicial  = new Comunas(-1, -1, "No pudimos encontrarComunas");
			listaComunas.add(comunaInicial);
			return listaComunas;
		}
	}
	public String editarPersona(int idPersona, int perfil, int rut, String dv, String nombre, String appPaterno, String appMaterno, String fechaNacimiento)
	{
		mensajeEnviar = "{\"indice\":5,\"idPersona\":"+idPersona+",\"idPerfil\":"+perfil+",\"rut\":"+rut+",\"dv\":\""+dv+"\",\"nombre\":\""+nombre+"\",\"appPaterno\":\""+appPaterno+"\",\"appMaterno\":\""+appMaterno+"\",\"fechaNac\":\""+fechaNacimiento+"\"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-admin-usuario","POST", parametros);
		try
		{
			return objetoJson.getString("resultado");
		}
		catch(JSONException ex)
		{
			return "error";
		}
	}
	
	//"indice":8,"idPersona":1,"idComuna":2,"fonoFijo":"0227780184","celular":"+56976087240","direccion":"antonio Varas 666","mail":"asd@asd.com","fechaIngreso":"2013-02-02"}
	public String editarDatosContactos(int idPersona, int idComuna, String fonoFijo,String fonoCelular,String direccion, String mail, String fechaIngreso)
	{
		mensajeEnviar = "{\"indice\":8,\"idPersona\":"+idPersona+",\"idComuna\":"+idComuna+",\"fonoFijo\":\""+fonoFijo+"\",\"celular\":\""+fonoCelular+"\",\"direccion\":\""+direccion+"\",\"mail\":\""+mail+"\",\"fechaIngreso\":\""+fechaIngreso+"\"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-add-usuario.php","POST", parametros);
		try
		{
			return objetoJson.getString("resultado");
		}
		catch(JSONException ex)
		{
			return "error";
		}
	}
	
}
