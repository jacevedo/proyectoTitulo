package cl.sfh.paciente;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import java.io.File;


public class TomaHora extends Activity implements OnClickListener
{
    private Spinner spnHoras;
    private Spinner spnDoctores;
    private Button btnGuardar;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.tomar_hora);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
        spnHoras = (Spinner)findViewById(R.id.spnHorasDisponibles);
        spnDoctores = (Spinner)findViewById(R.id.spnDoctores);
        btnGuardar = (Button)findViewById(R.id.btnGuardarHora);
        llenarHoras();
        llenarDoctores();
        btnGuardar.setOnClickListener(this);

    }

    private void llenarHoras()
    {
        ArrayAdapter<CharSequence> adapter = null;

        adapter =new ArrayAdapter <CharSequence> (this, android.R.layout.simple_spinner_item );
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        int contador= 0;
        int horas=13;
        while (contador <5)
        {

            String horaAtencion = horas+":00 hrs";
            adapter.add(horaAtencion);
            contador++;
            horas++;
        }

        spnHoras.setAdapter(adapter);
    }

    private void llenarDoctores()
    {
        ArrayAdapter<CharSequence> adapter = null;

        adapter =new ArrayAdapter <CharSequence> (this, android.R.layout.simple_spinner_item );
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        adapter.add("Dra: Pamela Acevedo");
        adapter.add("Dr: Ariel Garrido");
        adapter.add("Dr: German Garrido");


        spnDoctores.setAdapter(adapter);
    }


    @Override
    public void onClick(View v)
    {
        switch (v.getId())
        {
            case R.id.btnGuardarHora:
                Toast.makeText(this,"Tu hora a sido Tomada",Toast.LENGTH_SHORT).show();
                Intent i = new Intent("cl.sfh.paciente.Menu");
                i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                startActivity(i);
                break;
        }
    }



}
