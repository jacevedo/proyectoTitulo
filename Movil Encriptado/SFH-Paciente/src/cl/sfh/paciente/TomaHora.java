package cl.sfh.paciente;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.ArrayList;

import cl.sfh.controladoras.ControladoraHorario;
import cl.sfh.entidades.Horario;

public class TomaHora extends Activity implements OnClickListener, OnItemSelectedListener
{
    private Spinner spnHoras;
    private Spinner spnDoctores;
    private Button btnGuardar;
    private String fecha;
    private ArrayList<Horario> horarios;
    private int idPaciente;
    private int idOdontologo;
    
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.tomar_hora);
        Bundle bundle = getIntent().getExtras();
        fecha = bundle.getString("fecha");
        SharedPreferences preferencias = getSharedPreferences("datos",Context.MODE_PRIVATE);
        idPaciente = preferencias.getInt("idPaciente", -1);
        
        inicializarElementos();
        Toast.makeText(this, fecha, Toast.LENGTH_SHORT).show();
         new obtenerHorarioYDoctores().execute(fecha);
    }

    private void inicializarElementos()
    {
        spnHoras = (Spinner)findViewById(R.id.spnHorasDisponibles);
        spnDoctores = (Spinner)findViewById(R.id.spnDoctores);
        btnGuardar = (Button)findViewById(R.id.btnGuardarHora);
        
        btnGuardar.setOnClickListener(this);
        spnDoctores.setOnItemSelectedListener(this);     
    }
    
    @Override
	public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
	{
    	Spinner spiner = (Spinner)arg0;
		if(arg2!=0)
		{
			Toast.makeText(this, (CharSequence) spiner.getItemAtPosition(arg2), Toast.LENGTH_SHORT).show();
			for (Horario hora : horarios)
			{
				if(((String)spiner.getItemAtPosition(arg2)).compareToIgnoreCase(hora.getNomOdontologo()+" id: "+hora.getIdOdontologo())==0)
				{
					idOdontologo = hora.getIdOdontologo();
					llenarHoras(hora.getHorario());
					break;
				}
			}
		}
	}

	@Override
	public void onNothingSelected(AdapterView<?> arg0)
	{
		
	}

    private void llenarHoras(ArrayList<String> horas)
    {
        ArrayAdapter<CharSequence> adapter = null;
        adapter = new ArrayAdapter <CharSequence> (this, android.R.layout.simple_spinner_item );
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        for (String hora : horas)
		{
        	adapter.add(hora);
		}
        spnHoras.setAdapter(adapter);
    }

    @Override
    public void onClick(View v)
    {
        switch (v.getId())
        {
            case R.id.btnGuardarHora:
              	tomarHora();
            break;
        }
    }
    
    private void tomarHora()
	{
		int idPacienteInterno = idPaciente;
		int idOdontologoInterno = idOdontologo;
		String horaInterna = (String) spnHoras.getSelectedItem();
		String fechaInterna = fecha;
		int estado = 0;
		if(idPacienteInterno!=-1)
		{
			new ReservarHora().execute(idPacienteInterno+"",idOdontologoInterno+"",horaInterna,fechaInterna,estado+"");
		}
		else
		{
			Toast.makeText(this, "Inicie sesi—n nuevamente", Toast.LENGTH_SHORT).show();
		}
	}
	class ReservarHora extends AsyncTask<String, Void, String>
    {
		@Override
		protected void onPreExecute()
		{
			// TODO Auto-generated method stub
			super.onPreExecute();
		}

		@Override
		protected String doInBackground(String... params)
		{
			ControladoraHorario control = new ControladoraHorario(TomaHora.this);
			int idPaciente =Integer.parseInt(params[0]);
			int idOdontologo = Integer.parseInt(params[1]);
			String hora = params[2];
			String fecha = params [3];
			int estado = Integer.parseInt(params[4]);
			String resultado  = control.tomarHora(idPaciente, idOdontologo, fecha, hora, estado);
			return resultado;
		}
		
		@Override
		protected void onPostExecute(String result)
		{
			if(result.compareToIgnoreCase("Ya existe la Cita")==0)
			{
				Toast.makeText(TomaHora.this, "Hora no disponible", Toast.LENGTH_SHORT).show();
			}
			else
			{
				Toast.makeText(TomaHora.this,"Tu hora a sido tomada",Toast.LENGTH_SHORT).show();
                Intent i = new Intent("cl.sfh.paciente.Menu");
                i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                startActivity(i);
			}
			super.onPostExecute(result);
		}
    }
	
    class obtenerHorarioYDoctores extends AsyncTask<String, Void, ArrayList<Horario>>
    {
    	@Override
		protected void onPreExecute()
		{
			// TODO Auto-generated method stub
			super.onPreExecute();
		}
    	
		@Override
		protected ArrayList<Horario> doInBackground(String... params)
		{
			ArrayList<Horario> listaHorarios;
			ControladoraHorario controlHorario = new ControladoraHorario(TomaHora.this);
			listaHorarios = controlHorario.getHorarioPorDia(params[0]);
			
			return listaHorarios;
		}

		@Override
		protected void onPostExecute(ArrayList<Horario> result)
		{
			horarios = result;
			ArrayAdapter<CharSequence> adapter = null;

	        adapter = new ArrayAdapter <CharSequence> (TomaHora.this, android.R.layout.simple_spinner_item );
	        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
	        adapter.add("Seleccione Odont—logo");
	        for (Horario horario : result)
			{
				adapter.add(horario.getNomOdontologo()+" id: "+horario.getIdOdontologo());
		    }
			spnDoctores.setAdapter(adapter);
			super.onPostExecute(result);
		}
    }
	

}
