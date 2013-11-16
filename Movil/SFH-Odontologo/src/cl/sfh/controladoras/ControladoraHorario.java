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

import cl.sfh.entidades.Horario;
import cl.sfh.entidades.Login;
import cl.sfh.libreria.JSONParser;

public class ControladoraHorario
{
	String mensajeEnviar;
	public ArrayList<Horario> obtenerHorarioIdOdontologo(int idOdontologo)
	{
		ArrayList<Horario> listaHorarios = new ArrayList<Horario>();
		Calendar calendarioo = GregorianCalendar.getInstance();
		String fecha=calendarioo.get(Calendar.YEAR)+"-"+calendarioo.get(Calendar.MONTH)+"-"+calendarioo.get(Calendar.DAY_OF_YEAR);
		
		
		mensajeEnviar = "{\"indice\":4,\"idOdontologo\":"+idOdontologo+",\"fecha\":\""+fecha+"\"}";
		JSONParser parser = new JSONParser();
		List<NameValuePair> parametros = new ArrayList<NameValuePair>();
		parametros.add(new BasicNameValuePair("send", mensajeEnviar));
		JSONObject objetoJson = parser.makeHttpRequest("ws-cita.php","POST", parametros);
		try
		{
			
			if(objetoJson.getString("resultado").compareToIgnoreCase("")!=0)
			{
				JSONArray objetoResultado = objetoJson.getJSONArray("resultado");
				for (int i = 0; i < objetoResultado.length(); i++)
				{
					JSONObject objetoSegundo = (JSONObject) objetoResultado.getJSONObject(i);
					int idHorario = objetoSegundo.getInt("idCita");
					String fechaCompleta = objetoSegundo.getString("fecha");
					String horaCompleta = objetoSegundo.getString("horaInicio");
					String[] soloFecha = fechaCompleta.split(" ");
					String[] soloHora = horaCompleta.split(" ");
					String nomPaciente = objetoSegundo.getString("nomPaciente");
					String appPaternoPaciente = objetoSegundo.getString("appPaternoPaciente");
					String appMaternoPaciente = objetoSegundo.getString("appMaternoPaciente");
					String nomCompleto = nomPaciente+" " + appPaternoPaciente+" "+ appMaternoPaciente;
					
					Horario horario = new Horario(idHorario, soloFecha[0], soloHora[0], nomCompleto);
					listaHorarios.add(horario);
				}
			}
			else
			{
				//return new Login("", -1,-1);
			}
		}
		catch (JSONException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
			//return new Login("", -1,-1);
		}
		return listaHorarios;
	}
}
