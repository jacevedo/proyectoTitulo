package cl.sfh.Odontologo;

import cl.sfh.libreria.*;
import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.content.Intent;

import java.util.ArrayList;

public class ListaPaciente extends Activity implements AdapterView.OnItemClickListener
{
    ListView lstPaciente;
    ArrayList<Pacientes> pacientes;

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
        pacientes = new ArrayList<Pacientes>();
        pacientes.add(new Pacientes(1,"Juan","Peres","Barrasa","asdasdasd","12-12-2012","aspirina"));
        pacientes.add(new Pacientes(1,"Daniel","Torres","Araya","asdasdasd","12-12-2012","aspirina"));
        pacientes.add(new Pacientes(1,"Jaime","Acevedo","Cerna","asdasdasd","12-12-2012","aspirina"));
        pacientes.add(new Pacientes(1,"Viviana","Garrido","Sanches","asdasdasd","12-12-2012","aspirina"));
        pacientes.add(new Pacientes(1,"Daniel","Montero","Peres","asdasdasd","12-12-2012","aspirina"));
        pacientes.add(new Pacientes(1,"David","Soto","Mataluna","asdasdasd","12-12-2012","aspirina"));
        PacientesAdapter adapterPaciente = new PacientesAdapter(pacientes,this);
        lstPaciente.setAdapter(adapterPaciente);
        lstPaciente.setOnItemClickListener(this);

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
           Intent i = new Intent("cl.sfh.sfhdoctor.Ficha");
           i.putExtra("nombrePaciente",pacientes.get(position).getNombre());
           i.putExtra("apellidoPaterno",pacientes.get(position).getAppPaterno());
           i.putExtra("apellidoMaterno",pacientes.get(position).getAppMaterno());
           i.putExtra("ultimoProcedimiento",pacientes.get(position).getUltimoProcedimiento());
           i.putExtra("fechaNacimiento",pacientes.get(position).getFechaNacimiento());
           i.putExtra("anamnesis",pacientes.get(position).getAnamnesis());
           startActivity(i);
    }
}
