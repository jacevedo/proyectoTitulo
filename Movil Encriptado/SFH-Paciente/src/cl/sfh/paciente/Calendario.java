package cl.sfh.paciente;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;

import java.util.*;

import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.GridView;
import android.widget.TextView;
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
    public int mesesMas;
    public int mesesMenos;
    ArrayList<DiasCalendario> diasCalendarios = new ArrayList<DiasCalendario>();
    public TextView txtNombreMes;
    
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.calendario_root);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
    	txtNombreMes = (TextView)findViewById(R.id.txtNombreMes);
    	
    	mesesMas = 0;
    	mesesMenos = 0;

        grilla = (GridView)findViewById(R.id.grCalendario);
        mesActual(Calendar.getInstance());
        
        btnMesSiguiente = (Button)findViewById(R.id.btnMesSiguiente);
        btnMesAnterior = (Button)findViewById(R.id.btnMesAnteriorCalendario);
        btnMesMesActual = (Button)findViewById(R.id.btnMesActual);

        btnMesAnterior.setOnClickListener(this);
        btnMesSiguiente.setOnClickListener(this);
        btnMesMesActual.setOnClickListener(this);

        grilla.setOnItemClickListener(this);
    }


    public void cargarMesAnterior(int mes,int ano)
    {
        Calendar calendarioo = GregorianCalendar.getInstance();
        calendarioo.setFirstDayOfWeek(Calendar.MONDAY);
        calendarioo.set(ano,mes,calendarioo.getActualMinimum(Calendar.DAY_OF_MONTH),calendarioo.get(Calendar.HOUR_OF_DAY),calendarioo.get(Calendar.MINUTE),calendarioo.get(Calendar.SECOND));
        int primerDia = calendarioo.get(Calendar.DAY_OF_WEEK)-2;
        
        Log.e("primerDia", primerDia+"");
        calendarioo.set(calendarioo.get(Calendar.YEAR),calendarioo.get(Calendar.MONTH)-1,calendarioo.getActualMinimum(Calendar.DAY_OF_MONTH),calendarioo.get(Calendar.HOUR_OF_DAY),calendarioo.get(Calendar.MINUTE),calendarioo.get(Calendar.SECOND));
        if(primerDia==-1)
        {
        	primerDia=6;
        }
        
        int ultimoDia = calendarioo.getActualMaximum(Calendar.DAY_OF_MONTH);
        int diaPartida = ultimoDia-primerDia+1;
        Log.e("primerDia", calendarioo.getFirstDayOfWeek()+"");
        
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
            case R.id.btnMesAnteriorCalendario:
            	mesesMas = mesesMas - 1;
            	Log.e("Menos","."+mesesMas);
                mesAnterior(GregorianCalendar.getInstance(),mesesMas);
                break;
            case R.id.btnMesActual:
            	mesesMas = 0;
                mesesMenos = 0;
                mesActual(GregorianCalendar.getInstance());
              
                break;
            case R.id.btnMesSiguiente:
            	mesesMas = mesesMas + 1;
            	Log.e("Mas","."+mesesMas);
                mesSiguiente(GregorianCalendar.getInstance(),mesesMas);
                break;
        }
    }
    
    public void mesAnterior(Calendar calendario,int meses)
    {
    	diasCalendarios.clear();
        diasCalendarios = new ArrayList<DiasCalendario>();
        Calendar calendarioSiguiente = GregorianCalendar.getInstance();
        calendarioSiguiente.set(calendario.get(Calendar.YEAR),calendario.get(Calendar.MONTH)+meses,calendario.get(Calendar.DAY_OF_MONTH),calendario.get(Calendar.HOUR_OF_DAY),calendario.get(Calendar.MINUTE),calendario.get(Calendar.SECOND));
        cargarMesAnterior(calendarioSiguiente.get(Calendar.MONTH), calendarioSiguiente.get(Calendar.YEAR));
        calendario.setFirstDayOfWeek(1);        

        int dias = calendarioSiguiente.getActualMaximum(Calendar.DAY_OF_MONTH);
        int mes = calendario.get(Calendar.MONTH)+1;
        int year = calendario.get(Calendar.YEAR);
        
        int newMes = mes + meses;
        setNombreMes(newMes);
        Log.e("MES ANTERIOR", "mes"+newMes);
        Log.e("MESES", ":"+meses);
        
        DiasCalendario diaGrilla;
        for(int i=0;i!=dias;i++)
        {
            diaGrilla = new DiasCalendario(i+1,i+1,mes,year,(int)(Math.random()*3)+1);
            diasCalendarios.add(diaGrilla);
        }
        
        GrillaAdapter grillaAdaptador = new GrillaAdapter(diasCalendarios,this);
        grilla.setAdapter(grillaAdaptador);
        if(meses==0)
        {
        	btnMesAnterior.setEnabled(false);
        }
    }
    
    public void mesActual(Calendar calendario)
    {
        diasCalendarios.clear();
        diasCalendarios = new ArrayList<DiasCalendario>();

        cargarMesAnterior(calendario.get(Calendar.MONTH),calendario.get(Calendar.YEAR));
        calendario.setFirstDayOfWeek(Calendar.MONDAY);

        int dias = calendario.getActualMaximum(Calendar.DAY_OF_MONTH);
        int mes = calendario.get(Calendar.MONTH)+1;
        int year = calendario.get(Calendar.YEAR);
        
        setNombreMes(mes);
        Log.e("MES ACTUAL", "mes"+mes);

        DiasCalendario diaGrilla;
        for(int i=0;i!=dias;i++)
        {
            diaGrilla = new DiasCalendario(i+1,i+1,mes,year,(int)(Math.random()*3)+1);
            diasCalendarios.add(diaGrilla);
        }
        
        GrillaAdapter grillaAdaptador = new GrillaAdapter(diasCalendarios,this);
        grilla.setAdapter(grillaAdaptador);
    }
    
    public void mesSiguiente(Calendar calendario,int mesSiguiente)
    {
        diasCalendarios.clear();
        diasCalendarios = new ArrayList<DiasCalendario>();
        Calendar calendarioSiguiente = GregorianCalendar.getInstance();
        calendarioSiguiente.set(calendario.get(Calendar.YEAR),calendario.get(Calendar.MONTH)+mesSiguiente,calendario.get(Calendar.DAY_OF_MONTH),calendario.get(Calendar.HOUR_OF_DAY),calendario.get(Calendar.MINUTE),calendario.get(Calendar.SECOND));

        cargarMesAnterior(calendarioSiguiente.get(Calendar.MONTH), calendarioSiguiente.get(Calendar.YEAR));
        calendario.setFirstDayOfWeek(1);

        int dias = calendarioSiguiente.getActualMaximum(Calendar.DAY_OF_MONTH);
        int mes = calendario.get(Calendar.MONTH)+1;
        int year = calendario.get(Calendar.YEAR);
        
        int newMes = mes + mesSiguiente;
        setNombreMes(newMes);
        Log.e("MES SIGUIENTE", "mes"+newMes);
        Log.e("MESSS", ":"+mesSiguiente);
        
        DiasCalendario diaGrilla;
        for(int i=0;i!=dias;i++)
        {
            diaGrilla = new DiasCalendario(i+1,i+1,mes,year,(int)(Math.random()*3)+1);
            diasCalendarios.add(diaGrilla);
        }
        
        btnMesAnterior.setEnabled(true);
        GrillaAdapter grillaAdaptador = new GrillaAdapter(diasCalendarios,this);
        grilla.setAdapter(grillaAdaptador);
    }
    
    public void setNombreMes(int mes)
    {
    	if(mes == 1)
    	{ txtNombreMes.setText("Enero"); }
    	else if(mes == 2)
    	{ txtNombreMes.setText("Febrero"); }
    	else if(mes == 3)
    	{ txtNombreMes.setText("Marzo"); }
    	else if(mes == 4)
    	{ txtNombreMes.setText("Abril"); }
    	else if(mes == 5)
    	{ txtNombreMes.setText("Mayo"); }
    	else if(mes == 6)
    	{ txtNombreMes.setText("Junio"); }
    	else if(mes == 7)
    	{ txtNombreMes.setText("Julio"); }
    	else if(mes == 8)
    	{ txtNombreMes.setText("Agosto"); }
    	else if(mes == 9)
    	{ txtNombreMes.setText("Septiembre"); }
    	else if(mes == 10)
    	{ txtNombreMes.setText("Octubre"); }
    	else if(mes == 11)
    	{ txtNombreMes.setText("Noviembre"); }
    	else if(mes == 12)
    	{ txtNombreMes.setText("Diciembre"); }
    }
    
    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id)
    {
    	String fecha =  obtenerFecha(diasCalendarios.get(position).getDia(),diasCalendarios.get(position).getMes()+mesesMas,diasCalendarios.get(position).getYear());
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
