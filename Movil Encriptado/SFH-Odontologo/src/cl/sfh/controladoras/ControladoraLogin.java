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
		mensajeEnviar = "{\"indice\":3,\"usuario\":"+usuario+",\"pass\":\""+pass+"\"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-login.php","POST", parametros);
		try
		{
			if(objetoJson.getString("resultado").compareToIgnoreCase("")!=0)
			{
				JSONObject objetoResultado = objetoJson.getJSONObject("resultado");
				if(objetoResultado.getString("habilitado").compareToIgnoreCase("Usuario Habilitado")==0)
				{
					String key = objetoResultado.getString("key");
					int codigoAcceso = objetoResultado.getInt("codAcceso");
					int idPersona = objetoResultado.getInt("idPersona");
					int idOdontologo = objetoResultado.getInt("idOdontologo");
					Login loginObjeto = new Login(key, codigoAcceso, idPersona,idOdontologo);
					return loginObjeto;
				}
				else
				{
					return new Login("", -1,-1,-1);
				}
			}
			else
			{
				return new Login("", -1,-1,-1);
			}
		}
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
			return new Login("", -1,-1,-1);
		}
	}
}
