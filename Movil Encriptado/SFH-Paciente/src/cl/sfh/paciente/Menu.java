package cl.sfh.paciente;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;

public class Menu extends Activity implements OnClickListener
{
    private Button btnEditarCuenta;
    private Button btnListaPrecios;
    private Button btnTomarHora;
    private Button btnVerHorasTomadas;
    private Button btnCerrarSesion;
    
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.menu);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
        btnEditarCuenta = (Button)findViewById(R.id.btnModificarCuenta);
        btnListaPrecios = (Button)findViewById(R.id.btnVerPrecios);
        btnTomarHora = (Button)findViewById(R.id.btnTomarHora);
        btnVerHorasTomadas = (Button)findViewById(R.id.btnVerHorasTomadas);
        btnCerrarSesion = (Button)findViewById(R.id.btnCerrarSesion);

        btnCerrarSesion.setOnClickListener(this);
        btnEditarCuenta.setOnClickListener(this);
        btnListaPrecios.setOnClickListener(this);
        btnTomarHora.setOnClickListener(this);
        btnVerHorasTomadas.setOnClickListener(this);
    }

    @Override
    public boolean onCreateOptionsMenu(android.view.Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public void onClick(View v)
    {
        Intent i;
        switch (v.getId())
        {
            case R.id.btnModificarCuenta:
                i = new Intent("cl.sfh.paciente.EditarCuenta");
                startActivity(i);
                break;
            case R.id.btnVerPrecios:
                i= new Intent("cl.sfh.paciente.ListaPrecios");
                startActivity(i);
                break;
            case R.id.btnTomarHora:
                i = new Intent("cl.sfh.paciente.Calendario");
                startActivity(i);
                break;
            case R.id.btnVerHorasTomadas:
                i = new Intent("cl.sfh.paciente.VerHoras");
                startActivity(i);
                break;
            case R.id.btnCerrarSesion:
            	SharedPreferences preferencias = getSharedPreferences("datos",Context.MODE_PRIVATE);
				Editor editor=preferencias.edit();
		        editor.putInt("idPaciente",-1);
		        editor.putInt("idPersona", -1);
		        editor.putInt("rutPersona", -1);
		        editor.commit();
            	i = new Intent("cl.sfh.paciente.MainActivity");
                startActivity(i);
                finish();
                break;
        }
    }
}
