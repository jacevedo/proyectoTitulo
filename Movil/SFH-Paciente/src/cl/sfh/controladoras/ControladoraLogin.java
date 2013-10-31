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
			JSONObject segundoObjetoJson = objetoJson.getJSONObject("resultado");
			String key = segundoObjetoJson.getString("key");
			int codigoAcceso = segundoObjetoJson.getInt("codAcceso");
			int idPaciente = segundoObjetoJson.getInt("idPaciente");
			Login loginObjeto = new Login(key, codigoAcceso, idPaciente);
			return loginObjeto;
		} 
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
			return new Login("", -1,-1);
		}
		
	}
}
