package cl.sfh.Odontologo;

import cl.sfh.controladoras.ControladoraPaciente;
import cl.sfh.entidades.Pacientes;
import cl.sfh.entidades.Tratamiento;
import cl.sfh.libreria.*;
import android.app.Activity;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Parcelable;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.content.Intent;

import java.util.ArrayList;

public class ListaPaciente extends Activity implements AdapterView.OnItemClickListener, OnClickListener
{
    private ListView lstPaciente;
    private ArrayList<Pacientes> pacientes;
    private EditText edtFiltro;
    private Button btnBuscar;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.lista_pacientes);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
        lstPaciente = (ListView)findViewById(R.id.lstPacientes);
        edtFiltro = (EditText)findViewById(R.id.edtFiltrar);
        btnBuscar = (Button)findViewById(R.id.btnBuscar);
        btnBuscar.setOnClickListener(this);
        new BuscarPacientes().execute();
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id)
    {
           Intent i = new Intent("cl.sfh.Odontologo.Ficha");
           i.putExtra("nombrePaciente",pacientes.get(position).getNombre());
           i.putExtra("apellidoPaterno",pacientes.get(position).getAppPaterno());
           i.putExtra("apellidoMaterno",pacientes.get(position).getAppMaterno());
           i.putExtra("fechaNacimiento",pacientes.get(position).getFechaNacimiento());
           i.putExtra("anamnesis",pacientes.get(position).getAnamnesis());
           int contador = 0;
           if(pacientes.get(position).getListaTratamientos().size()!=0)
           {
        	   for (Tratamiento tratamiento : pacientes.get(position).getListaTratamientos())
				{
        		   i.putExtra("tratamiento"+contador, tratamiento.getTratamiento());
        		   contador++;
				}
        	   i.putExtra("cantTratamientos", contador);
           }
           else
           {
        	   i.putExtra("cantTratamientos", 0);
           }
           startActivity(i);
    }
    class BuscarPacientes extends AsyncTask<String, Void, ArrayList<Pacientes>>
    {
		@Override
		protected ArrayList<Pacientes> doInBackground(String... params)
		{
			ControladoraPaciente controlPaciente = new ControladoraPaciente();
			ArrayList<Pacientes> paciente = controlPaciente.buscarPacientes(1);
			return paciente;
		}

		@Override
		protected void onPostExecute(ArrayList<Pacientes> result)
		{
			pacientes = result;
			PacientesAdapter adapterPaciente = new PacientesAdapter(pacientes,ListaPaciente.this);
		    lstPaciente.setAdapter(adapterPaciente);
		    lstPaciente.setOnItemClickListener(ListaPaciente.this);
			super.onPostExecute(result);
		}
    	
    }
    class BuscarPacientesFiltro extends AsyncTask<String, Void, ArrayList<Pacientes>>
    {
		@Override
		protected ArrayList<Pacientes> doInBackground(String... params)
		{
			ControladoraPaciente controlPaciente = new ControladoraPaciente();
			ArrayList<Pacientes> paciente = controlPaciente.buscarListaFiltro(params[0]);
			return paciente;
		}

		@Override
		protected void onPostExecute(ArrayList<Pacientes> result)
		{
			pacientes = result;
			PacientesAdapter adapterPaciente = new PacientesAdapter(pacientes,ListaPaciente.this);
		    lstPaciente.setAdapter(adapterPaciente);
		    lstPaciente.setOnItemClickListener(ListaPaciente.this);
			super.onPostExecute(result);
		}
    	
    }
	@Override
	public void onClick(View v)
	{
		switch (v.getId())
		{
			case R.id.btnBuscar:
				String persona = edtFiltro.getText().toString();
				new BuscarPacientesFiltro().execute(persona);
			break;
		}
		
		
	}
}
