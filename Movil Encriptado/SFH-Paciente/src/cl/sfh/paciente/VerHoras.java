package cl.sfh.paciente;

import static cl.sfh.libreria.Validaciones.apellidos;
import static cl.sfh.libreria.Validaciones.mail;
import static cl.sfh.libreria.Validaciones.nombres;
import static cl.sfh.libreria.Validaciones.telefono;

import java.util.ArrayList;
import java.util.regex.Pattern;

import cl.sfh.controladoras.ControladoraHorario;
import cl.sfh.entidades.HorasTomadas;
import cl.sfh.entidades.Login;
import cl.sfh.libreria.ItemAdapterHorario;
import cl.sfh.paciente.MainActivity.Asincrono;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;
import android.widget.AdapterView.OnItemSelectedListener;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;

public class VerHoras extends Activity implements OnClickListener
{
	private ListView listaHorasTomadas;
	private ArrayList<HorasTomadas> horario;
	private int idPaciente;
	private Button btnBuscar;
	private EditText edtBusqueda;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.ver_horas_tomadas);
        
        inicializarElementos();
    }

    private void inicializarElementos()
    {
    	edtBusqueda = (EditText)findViewById(R.id.txtBusqueda);
    	btnBuscar = (Button)findViewById(R.id.btnBuscar);
    	listaHorasTomadas = (ListView)findViewById(R.id.lstHoras);
    	
    	SharedPreferences preferencias = getSharedPreferences("datos",Context.MODE_PRIVATE);
    	idPaciente = preferencias.getInt("idPaciente", -1);
    	
    	btnBuscar.setOnClickListener(this);
    	
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
			ControladoraHorario controlHorario = new ControladoraHorario(VerHoras.this);
			horasTomadas =  controlHorario.listaHorasTomadas(params[0]);
			Log.e("PARAM",""+params[0]);
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
	
	public void onClick(View v)
    {
        switch (v.getId())
        {
            case R.id.btnBuscar:
            	String fecha = edtBusqueda.getText().toString();
            	if(validarFecha(fecha))
            	{
            		new Asincrono2().execute(String.valueOf(idPaciente), fecha);
            	}
            	else
            	{
            		Toast.makeText(VerHoras.this, "Debe ingresar una fecha válida", Toast.LENGTH_LONG).show();
            	}
            break;
        }
    }
	
	class Asincrono2 extends AsyncTask<String, Login,ArrayList<HorasTomadas>>
	{
		@Override
		protected void onPreExecute()
		{
			super.onPreExecute();
		}

		protected ArrayList<HorasTomadas> doInBackground(String... params)
		{
			ArrayList<HorasTomadas> horasTomadas = new ArrayList<HorasTomadas>();
			ControladoraHorario controlHorario = new ControladoraHorario(VerHoras.this);
			horasTomadas =  controlHorario.listaHorasTomadasFecha(Integer.parseInt(params[0]), params[1]);
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
	
	boolean validarFecha(String texto)
	{
		if(!Pattern.matches("\\d{2}\\-\\d{2}\\-\\d{4}", texto))
		{
		    Toast.makeText(VerHoras.this, "Debe ingresar una fecha válida día-mes-año (01-01-1991)", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
	}
}
