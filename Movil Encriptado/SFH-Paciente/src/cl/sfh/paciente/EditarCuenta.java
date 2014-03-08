package cl.sfh.paciente;

import static cl.sfh.libreria.Validaciones.*;

import java.util.ArrayList;

import cl.sfh.controladoras.ControladoraEditarDatosContacto;
import cl.sfh.entidades.Comunas;
import cl.sfh.entidades.DatosContactoEditar;
import cl.sfh.entidades.Region;
import android.R.integer;
import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TabHost;
import android.widget.Toast;

public class EditarCuenta extends Activity implements OnClickListener, OnItemSelectedListener, OnFocusChangeListener
{
	private EditText edtNombre;
	private EditText edtApellidoPaterno;
	private EditText edtApellidoMaterno;
	private EditText edtFonoFijo;
	private EditText edtFonoCelular;
	private EditText edtDireccion;
	private EditText edtCorreo;
	private Spinner spRegion;
	private Spinner spComuna;
	private int rut;
	private ArrayList<Region> regionGlobal;
	private ArrayList<Comunas> comunasGlobal;
	private TabHost tabs;
	private DatosContactoEditar datosEditar;
	private Button btnGuardarDatosPersona;
	private Button btnGuardarDatosContacto;
	
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.editar_cuenta);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
    	Resources res = getResources();
    	tabs = (TabHost)findViewById(android.R.id.tabhost);
    	tabs.setup();
    	TabHost.TabSpec spec=tabs.newTabSpec("mitab1");
    	spec.setContent(R.id.tab1);
    	spec.setIndicator("Datos Personales",
    	    res.getDrawable(android.R.drawable.ic_btn_speak_now));
    	tabs.addTab(spec);
    	 
    	spec=tabs.newTabSpec("mitab2");
    	spec.setContent(R.id.tab2);
    	spec.setIndicator("Datos de Contacto",
    	    res.getDrawable(android.R.drawable.ic_dialog_map));
    	tabs.addTab(spec);
    	 
    	tabs.setCurrentTab(0);
    	
    	
    	
    	edtNombre = (EditText)findViewById(R.id.edtNombre);
    	edtApellidoPaterno = (EditText)findViewById(R.id.edtAppPaterno);
    	edtApellidoMaterno = (EditText)findViewById(R.id.edtAppMaterno);
    	edtFonoFijo = (EditText)findViewById(R.id.edtFonoFijo);
    	edtFonoCelular = (EditText)findViewById(R.id.edtFonoCelular);
    	edtDireccion = (EditText)findViewById(R.id.edtDireccion);
    	edtCorreo = (EditText)findViewById(R.id.edtCorreo);
    	spRegion = (Spinner)findViewById(R.id.spRegion);
    	spComuna = (Spinner)findViewById(R.id.edtMail);
    	btnGuardarDatosPersona = (Button)findViewById(R.id.btnEditarPersona);
    	btnGuardarDatosContacto = (Button)findViewById(R.id.btnDatosContacto);
    	btnGuardarDatosPersona.setOnClickListener(this);
    	btnGuardarDatosContacto.setOnClickListener(this);
    	SharedPreferences preferencias = getSharedPreferences("datos",Context.MODE_PRIVATE);
        rut = preferencias.getInt("rutPersona", -1);
       
        edtNombre.setOnFocusChangeListener(this);
    	edtApellidoPaterno.setOnFocusChangeListener(this);
    	edtApellidoMaterno.setOnFocusChangeListener(this);
    	edtFonoFijo.setOnFocusChangeListener(this);
    	edtFonoCelular.setOnFocusChangeListener(this);
    	edtDireccion.setOnFocusChangeListener(this);
    	edtCorreo.setOnFocusChangeListener(this);
    	
        
        new obtenerInformacion().execute(rut);
        
        
       
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
			case R.id.btnEditarPersona:
			
				String nombre = edtNombre.getText().toString();
				String appPaterno = edtApellidoPaterno.getText().toString();
				String appMaterno = edtApellidoMaterno.getText().toString();
				if(nombres(this,nombre)&&apellidos(this,appPaterno)&&apellidos(this,appMaterno))
				{
					new guardarDatosPersona().execute(datosEditar.getIdPersona()+"",datosEditar.getPerfil()+"",datosEditar.getRut()+"",datosEditar.getDv(),nombre,appPaterno,appMaterno,datosEditar.getFechaNacimiento());
				}
			break;
			case R.id.btnDatosContacto:
				//{"indice":8,"idPersona":1,"idComuna":2,"fonoFijo":"0227780184","celular":"+56976087240","direccion":"antonio Varas 666","mail":"asd@asd.com","fechaIngreso":"2013-02-02"}
				String fonoFijo = edtFonoFijo.getText().toString();
				String fonoCelular = edtFonoCelular.getText().toString();
				String direccion = edtDireccion.getText().toString();
				String correoElectronico = edtCorreo.getText().toString();
				if((telefono(this,fonoFijo)||telefono(this,fonoCelular))&&mail(this,correoElectronico))
				{
					int idComuna = -1;
					for (Comunas comuna : comunasGlobal)
					{
						if(spComuna.getSelectedItem().toString().compareToIgnoreCase(comuna.getNomComuna())==0)
						{
							idComuna=comuna.getIdComuna();
							break;
						}
					}
					
					new guardarDatosContacto().execute(datosEditar.getIdPersona()+"",idComuna+"",fonoFijo,fonoCelular,direccion,correoElectronico,datosEditar.getFechaIngreso());
				}
				
			break;
		}
    }
    @Override
	public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2,
			long arg3)
	{
    	Spinner spiner = (Spinner)arg0;
		if(spiner.getTag().toString().compareToIgnoreCase("region")==0&&arg2!=0)
		{
			int idRegion=-1;
			for (Region region : regionGlobal)
			{
				if(region.getNomRegion().compareToIgnoreCase(spiner.getItemAtPosition(arg2).toString())==0)
				{
					
					idRegion = region.getIdRegion();
					break;
					
				}
				
			}
			ArrayList<Comunas> comunasForSpinner = new ArrayList<Comunas>();
			Log.e("asd", idRegion+"");
			for (Comunas comunas : comunasGlobal)
			{
				
				if(comunas.getIdRegion()==idRegion)
				{
					comunasForSpinner.add(comunas);
				}
			}
			ArrayAdapter<Comunas> listaEpinnerComunas = new ArrayAdapter<Comunas>(EditarCuenta.this, android.R.layout.simple_spinner_item, comunasForSpinner);
			listaEpinnerComunas.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			spComuna.setAdapter(listaEpinnerComunas);
		}
		
	}

	@Override
	public void onNothingSelected(AdapterView<?> arg0)
	{
		// TODO Auto-generated method stub
		
	}
    class guardarDatosPersona extends AsyncTask<String, Void, String>
    {

		@Override
		protected String doInBackground(String... params)
		{
			int idPersona = Integer.parseInt(params[0]);
			int idPerfil = Integer.parseInt(params[1]);
			int rut = Integer.parseInt(params[2]);
			String dv = params[3];
			String nombre = params[4];
			String appPaterno =params[5];
			String appMaterno = params[6];
			String fechaNacimiento = params[7];
			ControladoraEditarDatosContacto editar = new ControladoraEditarDatosContacto(EditarCuenta.this);
			String resultado = editar.editarPersona(idPersona, idPerfil,rut, dv, nombre, appPaterno, appMaterno, fechaNacimiento);
			
			return resultado;
		}

		@Override
		protected void onPostExecute(String result)
		{
			Toast.makeText(EditarCuenta.this,result, Toast.LENGTH_SHORT).show();
			super.onPostExecute(result);
		}
    	
    }
    class guardarDatosContacto extends AsyncTask<String, Void, String>
    {

		@Override
		protected String doInBackground(String... params)
		{
			int idPersona = Integer.parseInt(params[0]);
			int idComuna = Integer.parseInt(params[1]);
			String fonoFijo = params[2];
			String fonoCelular = params[3];
			String direccion = params[4];
			String correo = params[5];
			String fechaIngreso = params[6];
			ControladoraEditarDatosContacto editar = new ControladoraEditarDatosContacto(EditarCuenta.this);
			String resultado = editar.editarDatosContactos(idPersona, idComuna, fonoFijo, fonoCelular, direccion, correo, fechaIngreso);
			return resultado;
		}

		@Override
		protected void onPostExecute(String result)
		{
			Toast.makeText(EditarCuenta.this, result, Toast.LENGTH_SHORT).show();
			super.onPostExecute(result);
		}
    	
    }
    class obtenerComunas extends AsyncTask<Integer, Void, ArrayList<Object>>
    {

		@Override
		protected ArrayList<Object> doInBackground(Integer... params)
		{
			ArrayList<Object> listaObjetos = new ArrayList<Object>();
			ControladoraEditarDatosContacto controladoraEditarDatos = new ControladoraEditarDatosContacto(EditarCuenta.this);
			listaObjetos.add(controladoraEditarDatos.obtenerComunas());
			Log.e("asd",  params[0]+"");
			Log.e("asd",  params[1]+"");
			listaObjetos.add(params[0]);
			listaObjetos.add(params[1]);
			return listaObjetos;
		}

		@SuppressWarnings("unchecked")
		@Override
		protected void onPostExecute(ArrayList<Object> result)
		{
			ArrayList<Comunas> comuna = (ArrayList<Comunas>)result.get(0);
			comunasGlobal = comuna;
			ArrayList<Comunas> comunaForSpinner = new ArrayList<Comunas>();
			Log.e("asd",(Integer)result.get(1)+"");
			for (Comunas comunas : comuna)
			{
				if(comunas.getIdRegion() == (Integer)result.get(1))
				{
					comunaForSpinner.add(comunas);
				}
			}
			
			ArrayAdapter<Comunas> listaEpinnerComunas = new ArrayAdapter<Comunas>(EditarCuenta.this, android.R.layout.simple_spinner_item, comunaForSpinner);
			listaEpinnerComunas.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			spComuna.setAdapter(listaEpinnerComunas);
			for(int i=0;i<comunaForSpinner.size();i++)
			{
				if(comunaForSpinner.get(i).getIdComuna()==(Integer)result.get(2))
				{
					spComuna.setSelection(i);
					break;
				}
		
			}
			spRegion.setOnItemSelectedListener(EditarCuenta.this);
			super.onPostExecute(result);
		}
		
    	
    }
    class obtenerRegiones extends AsyncTask<Integer, Void, ArrayList<Object>>
    {

		@Override
		protected ArrayList<Object> doInBackground(Integer... params)
		{
			ArrayList<Object> listaObjeto = new ArrayList<Object>();
			ControladoraEditarDatosContacto controladoraEditarDatos = new ControladoraEditarDatosContacto(EditarCuenta.this);
			listaObjeto.add(controladoraEditarDatos.obtenerRegiones());
			listaObjeto.add(params[0]);
			listaObjeto.add(params[1]);
			return listaObjeto;
		}

		@SuppressWarnings("unchecked")
		@Override
		protected void onPostExecute(ArrayList<Object> result)
		{
			ArrayList<Region> region = (ArrayList<Region>)result.get(0);
			regionGlobal = region;
			ArrayAdapter<Region> listaEpinnerRegiones= new ArrayAdapter<Region>(EditarCuenta.this, android.R.layout.simple_spinner_item, region);
			listaEpinnerRegiones.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			spRegion.setAdapter(listaEpinnerRegiones);
			for(int i=0;i<region.size();i++)
			{
				if(region.get(i).getIdRegion()==(Integer)result.get(1))
				{
					spRegion.setSelection(i);
					break;
				}
		
			}
			Log.e("asd", result.get(1)+"");
			new obtenerComunas().execute((Integer)result.get(1),(Integer)result.get(2));
			super.onPostExecute(result);
		}
    	
    }
    class obtenerInformacion extends AsyncTask<Integer, Void, DatosContactoEditar>
    {
    	@Override
		protected void onPreExecute()
		{
			// TODO Auto-generated method stub
			super.onPreExecute();
		}
		@Override
		protected DatosContactoEditar doInBackground(Integer... params)
		{
			int rut = params[0];
			if(rut!=-1)
			{
				ControladoraEditarDatosContacto controladoraEditarDatos = new ControladoraEditarDatosContacto(EditarCuenta.this);
				DatosContactoEditar editar = controladoraEditarDatos.obtenerDatosContaco(rut);
				return editar;
			}
			else
			{
				return null;
			}
		}

		@Override
		protected void onPostExecute(DatosContactoEditar result)
		{
			if(result!=null)
			{
				datosEditar = result;
				edtNombre.setText(result.getNombre());
				edtApellidoPaterno.setText(result.getApellidoPaterno());
				edtCorreo.setText(result.getCorreo());
				edtDireccion.setText(result.getDireccion());
				edtFonoCelular.setText(result.getFonoCelular());
				edtFonoFijo.setText(result.getFonoFijo());
				edtApellidoMaterno.setText(result.getApellidoMaterno());
				new obtenerRegiones().execute(result.getRegion(),result.getComuna());
				
			}
			else
			{
				Toast.makeText(EditarCuenta.this, "No se encontraron datos", Toast.LENGTH_SHORT).show();
			}
			super.onPostExecute(result);
		}

		
		
    }
	@Override
	public void onFocusChange(View v, boolean hasFocus)
	{
		String texto = ((EditText)v).getText().toString();
		if(!hasFocus)
		{
			switch (v.getId())
			{
				case R.id.edtNombre:
					nombres(this,texto);
				break;
				case R.id.edtAppPaterno:
					apellidos(this,texto);
					break;
				case R.id.edtAppMaterno:
					apellidos(this,texto);
					break;
				case R.id.edtFonoFijo:
					telefono(this,texto);
					break;
				case R.id.edtFonoCelular:
					telefono(this,texto);
					break;
				case R.id.edtCorreo:
					mail(this,texto);
					break;
			}
		}
		
	}
	
}
