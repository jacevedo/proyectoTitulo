package cl.sfh.controladoras;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;
import cl.sfh.entidades.DatosContacto;
import cl.sfh.entidades.Pass;
import cl.sfh.entidades.Persona;
import cl.sfh.libreria.JSONParser;

public class controladoraAgregarUsuario
{
	private String mensajeEnviar;
	private String key;
	public controladoraAgregarUsuario(Activity actividad)
	{
		SharedPreferences preferencias = actividad.getSharedPreferences("datos",Context.MODE_PRIVATE);
		key = preferencias.getString("key",	"");
	}
	public String crearCuenta(Persona per, DatosContacto datos, Pass pass)
	{
		Log.e("pass",pass.getPass());
		mensajeEnviar = "{\"indice\":10,\"idPerfil\":"+per.getIdPerfil()+",\"rut\":"+per.getRut()+",\"dv\":"+per.getDv()+
						",\"nombre\":\""+per.getNombre()+"\",\"appPaterno\":\""+per.getAppPaterno()+"\","+
						"\"appMaterno\":\""+per.getAppMaterno()+"\",\"fechaNac\":\""+per.getFechaNacimiento()+
						"\",\"pass\":\""+pass.getPass()+"\",\"idComuna\":"+datos.getIdComuna()+
						",\"fonoFijo\":\""+datos.getFonoFijo()+"\",\"celular\":\""+datos.getFonoCelular()+
						"\",\"direccion\":\""+datos.getDireccion()+"\",\"mail\":\""+datos.getMail()+"\","+
						"\"fechaIngreso\":\""+datos.getFechaIngreso()+"\",\"fechaCaducidad\":\""+pass.getFechaCaducidad()+"\",\"key\":\""+key+"\"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-add-usuario.php","POST", parametros);
		try
		{
			JSONObject login = objetoJson.getJSONObject("resultado");
			String resultado  = login.getString("resultado");
			return resultado;
		} 
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
			return  "";
		}	
	}
}
