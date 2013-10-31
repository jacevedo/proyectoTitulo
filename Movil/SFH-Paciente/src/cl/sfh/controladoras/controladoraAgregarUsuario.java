package cl.sfh.controladoras;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;

import cl.sfh.entidades.DatosContacto;
import cl.sfh.entidades.Pass;
import cl.sfh.entidades.Persona;
import cl.sfh.libreria.JSONParser;

public class controladoraAgregarUsuario
{
	String mensajeEnviar;
	public String crearCuenta(Persona per, DatosContacto datos, Pass pass)
	{
		mensajeEnviar = "{\"indice\":1,\"idPerfil\":"+per.getIdPerfil()+",\"rut\":"+per.getRut()+",\"dv\":"+per.getDv()+
						",\"nombre\":\""+per.getNombre()+"\",\"appPaterno\":\""+per.getAppPaterno()+"\","+
						"\"appMaterno\":\""+per.getAppMaterno()+"\",\"fechaNac\":\""+per.getFechaNacimiento()+
						"\",\"pass\":\""+pass.getPass()+"\",\"idComuna\":"+datos.getIdComuna()+
						",\"fonoFijo\":\""+datos.getFonoFijo()+"\",\"celular\":\""+datos.getFonoCelular()+
						"\",\"Direccion\":\""+datos.getDireccion()+"\",\"mail\":\""+datos.getMail()+"\","+
						"\"fechaIngreso\":\""+datos.getFechaIngreso()+"\"}";
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
