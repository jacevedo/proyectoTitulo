package cl.sfh.Odontologo;

import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.view.Menu;
import android.widget.ListView;
import java.util.ArrayList;

import cl.sfh.controladoras.ControladoraHorario;
import cl.sfh.entidades.Horario;
import cl.sfh.libreria.*;

public class HorasCargadas extends Activity
{
    private ListView lstHorasCargadas;
    private int idOdontologo;
    
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.horas_cargadas);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
        lstHorasCargadas = (ListView)findViewById(R.id.lstHorasCargadas);
        SharedPreferences preferencias = getSharedPreferences("datos",Context.MODE_PRIVATE);
        idOdontologo = preferencias.getInt("idOdontologo", -1);
        
        new busquedaHoras().execute(idOdontologo);   
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        return true;
    }
    
    class busquedaHoras extends AsyncTask<Integer, Void, ArrayList<Horario>>
    {
		@Override
		protected ArrayList<Horario> doInBackground(Integer... params)
		{
			ControladoraHorario controlHorario = new ControladoraHorario(HorasCargadas.this);
			ArrayList<Horario> listaHoras = controlHorario.obtenerHorarioIdOdontologo(params[0]);
			return listaHoras;
		}

		@Override
		protected void onPostExecute(ArrayList<Horario> result)
		{
			// TODO Auto-generated method stub
			HorasAdapter adapter = new HorasAdapter(result,HorasCargadas.this);
	        lstHorasCargadas.setAdapter(adapter);
			super.onPostExecute(result);
		}
    } 
}
