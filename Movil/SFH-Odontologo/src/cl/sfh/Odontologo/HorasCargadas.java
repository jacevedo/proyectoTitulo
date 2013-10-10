package cl.sfh.Odontologo;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.widget.ListView;

import java.util.ArrayList;

import cl.sfh.libreria.*;

public class HorasCargadas extends Activity
{
    ListView lstHorasCargadas;

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
        ArrayList<Horas> hora = new ArrayList<Horas>();
        hora.add(new Horas(0L,"12:00 PM","Juan Peres"));
        hora.add(new Horas(1L,"13:00 PM","Pedro Molina"));
        hora.add(new Horas(2L,"14:00 PM","Pablo Marmol"));

        HorasAdapter adapter = new HorasAdapter(hora,this);
        lstHorasCargadas.setAdapter(adapter);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        return true;
    }
    
}
