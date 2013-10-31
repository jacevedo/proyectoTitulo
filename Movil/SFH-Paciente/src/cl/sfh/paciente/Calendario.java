package cl.sfh.paciente;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import java.util.*;

import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.GridView;
import android.widget.Toast;

import java.util.ArrayList;

import cl.sfh.libreria.DiasCalendario;
import cl.sfh.libreria.GrillaAdapter;

public class Calendario extends Activity implements OnClickListener, AdapterView.OnItemClickListener
{
    private GridView grilla;
    private Button btnMesSiguiente;
    private Button btnMesAnterior;
    private Button btnMesMesActual;
    ArrayList<DiasCalendario> diasCalendarios = new ArrayList<DiasCalendario>();
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.calendario_root);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
        grilla = (GridView)findViewById(R.id.grCalendario);
         mesActual(Calendar.getInstance());

        btnMesSiguiente = (Button)findViewById(R.id.btnMesSiguiente);
        btnMesAnterior = (Button)findViewById(R.id.btnMesAnterior);
        btnMesMesActual = (Button)findViewById(R.id.btnMesActual);

        btnMesAnterior.setOnClickListener(this);
        btnMesSiguiente.setOnClickListener(this);
        btnMesMesActual.setOnClickListener(this);


        grilla.setOnItemClickListener(this);
    }


    public void cargarMesAnterior(int mes,int ano)
    {
        Calendar calendarioo = GregorianCalendar.getInstance();
        calendarioo.setFirstDayOfWeek(1);
        calendarioo.set(ano,mes,
                calendarioo.getActualMinimum(Calendar.DAY_OF_MONTH),calendarioo.get(Calendar.HOUR_OF_DAY),
                calendarioo.get(Calendar.MINUTE),calendarioo.get(Calendar.SECOND));
        int primerDia = calendarioo.get(Calendar.DAY_OF_WEEK)-2;
        calendarioo.set(calendarioo.get(Calendar.YEAR),calendarioo.get(Calendar.MONTH)-1,
                calendarioo.getActualMinimum(Calendar.DAY_OF_MONTH),calendarioo.get(Calendar.HOUR_OF_DAY),
                calendarioo.get(Calendar.MINUTE),calendarioo.get(Calendar.SECOND));
        int ultimoDia = calendarioo.getActualMaximum(Calendar.DAY_OF_MONTH);
        int diaPartida = ultimoDia-primerDia+1;
        
        for(int i=0; i < primerDia;i++)
        {
            diasCalendarios.add(new DiasCalendario(diaPartida,diaPartida,mes,ano,4));
            diaPartida++;
        }

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }


    @Override
    public void onClick(View v)
    {
        switch (v.getId())
        {
            case R.id.btnMesAnterior:
                mesAnterior(GregorianCalendar.getInstance());
                break;
            case R.id.btnMesActual:
                mesActual(GregorianCalendar.getInstance());
                break;
            case R.id.btnMesSiguiente:
                mesSiguiente(GregorianCalendar.getInstance());
                break;
        }
    }
    public void mesAnterior(Calendar calendario)
    {

    }
    public void mesActual(Calendar calendario)
    {
        diasCalendarios.clear();
        diasCalendarios = new ArrayList<DiasCalendario>();

        cargarMesAnterior(calendario.get(Calendar.MONTH),calendario.get(Calendar.YEAR));
        calendario.setFirstDayOfWeek(1);



        int dias = calendario.getActualMaximum(Calendar.DAY_OF_MONTH);
        int mes = calendario.get(Calendar.MONTH)+1;
        int year = calendario.get(Calendar.YEAR);

        DiasCalendario diaGrilla;
        for(int i=0;i!=dias;i++)
        {

            diaGrilla = new DiasCalendario(i+1,i+1,mes,year,(int)(Math.random()*3)+1);
            diasCalendarios.add(diaGrilla);
        }
        GrillaAdapter grillaAdaptador = new GrillaAdapter(diasCalendarios,this);
        grilla.setAdapter(grillaAdaptador);
    }
    public void mesSiguiente(Calendar calendario)
    {
        diasCalendarios.clear();
        diasCalendarios = new ArrayList<DiasCalendario>();
        Calendar calendarioSiguiente = GregorianCalendar.getInstance();
        calendarioSiguiente.set(calendario.get(Calendar.YEAR),calendario.get(Calendar.MONTH)+1,
                calendario.get(Calendar.DAY_OF_MONTH),calendario.get(Calendar.HOUR_OF_DAY),
                calendario.get(Calendar.MINUTE),calendario.get(Calendar.SECOND));

        cargarMesAnterior(calendarioSiguiente.get(Calendar.MONTH), calendarioSiguiente.get(Calendar.YEAR));
        calendario.setFirstDayOfWeek(1);

        

        int dias = calendarioSiguiente.getActualMaximum(Calendar.DAY_OF_MONTH);
        int mes = calendario.get(Calendar.MONTH)+1;
        int year = calendario.get(Calendar.YEAR);
        
        DiasCalendario diaGrilla;
        for(int i=0;i!=dias;i++)
        {

            diaGrilla = new DiasCalendario(i+1,i+1,mes,year,(int)(Math.random()*3)+1);
            diasCalendarios.add(diaGrilla);
        }
        GrillaAdapter grillaAdaptador = new GrillaAdapter(diasCalendarios,this);
        grilla.setAdapter(grillaAdaptador);

    }
    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id)
    {
    	String fecha =  obtenerFecha(diasCalendarios.get(position).getDia(),
    			diasCalendarios.get(position).getMes(),
    			diasCalendarios.get(position).getYear());
    	Toast.makeText(this, fecha, Toast.LENGTH_SHORT).show();
        Intent i = new Intent("cl.sfh.paciente.TomaHora");
        i.putExtra("fecha", fecha);
        startActivity(i);
    }

	private String obtenerFecha(int dia, int mes, int year)
	{
		String diaString;
		String mesString;
		String yearString = year+"";
		if(dia<10 )
		{
			diaString="0"+dia;
		}
		else
		{
			diaString = dia+"";
		}
		if(mes<10 )
		{
			mesString="0"+mes;
		}
		else
		{
			mesString = mes+"";
		}
		return yearString+"-"+mesString+"-"+diaString;
		
	}
}
