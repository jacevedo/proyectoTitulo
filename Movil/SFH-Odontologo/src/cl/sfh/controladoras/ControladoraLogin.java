package cl.sfh.controladoras;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;

import cl.sfh.entidades.Login;
import cl.sfh.libreria.JSONParser;

public class ControladoraLogin
{
	String mensajeEnviar;
	public Login loginKey(int usuario, String pass)
	{
		mensajeEnviar = "{\"indice\":1,\"usuario\":"+usuario+",\"pass\":\""+pass+"\"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-login.php","POST", parametros);
		try
		{
			JSONObject login = objetoJson.getJSONObject("Resultado");
			String key = login.getString("key");
			int codigoAcceso = login.getInt("codAcceso");
			Login loginObjeto = new Login(key, codigoAcceso);
			return loginObjeto;
			
			
		} 
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
			return new Login("", -1);
		}
		
	}
}
