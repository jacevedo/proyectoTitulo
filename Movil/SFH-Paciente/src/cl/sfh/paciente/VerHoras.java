package cl.sfh.paciente;


import java.util.ArrayList;

import cl.sfh.controladoras.ControladoraHorario;
import cl.sfh.entidades.HorasTomadas;
import cl.sfh.entidades.Login;
import cl.sfh.libreria.ItemAdapterHorario;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.widget.ListView;
import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;

public class VerHoras extends Activity 
{
	private ListView listaHorasTomadas;
	private ArrayList<HorasTomadas> horario;
	private int idPaciente;
	
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.ver_horas_tomadas);
        
        inicializarElementos();
    }

    private void inicializarElementos()
    {
    	listaHorasTomadas = (ListView)findViewById(R.id.lstHoras);
    	SharedPreferences preferencias = getSharedPreferences("datos",Context.MODE_PRIVATE);
    	idPaciente = preferencias.getInt("idPaciente", -1);
    	new Asincrono().execute(idPaciente);
    }

	class Asincrono extends	AsyncTask<Integer, Login,ArrayList<HorasTomadas>>
	{
			
		@Override
		protected void onPreExecute()
		{
			super.onPreExecute();
		}

		@Override
		protected ArrayList<HorasTomadas> doInBackground(Integer... params)
		{
			ArrayList<HorasTomadas> horasTomadas = new ArrayList<HorasTomadas>();
			ControladoraHorario controlHorario = new ControladoraHorario();
			horasTomadas =  controlHorario.listaHorasTomadas(params[0]);
			return horasTomadas;
		}

		@Override
		protected void onPostExecute(ArrayList<HorasTomadas> result)
		{
			ItemAdapterHorario adapterHorario = new ItemAdapterHorario(VerHoras.this, result);
			listaHorasTomadas.setAdapter(adapterHorario);
			super.onPostExecute(result);
		}	
	}
}
