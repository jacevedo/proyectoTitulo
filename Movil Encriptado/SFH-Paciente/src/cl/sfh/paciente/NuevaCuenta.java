package cl.sfh.paciente;

import static cl.sfh.libreria.Validaciones.*;

import java.util.ArrayList;
import java.util.Date;

import cl.sfh.controladoras.ControladoraEditarDatosContacto;
import cl.sfh.controladoras.controladoraAgregarUsuario;
import cl.sfh.entidades.Comunas;
import cl.sfh.entidades.DatosContacto;
import cl.sfh.entidades.Pass;
import cl.sfh.entidades.Persona;
import cl.sfh.entidades.Region;
import cl.sfh.paciente.EditarCuenta.obtenerComunas;
import android.app.Activity;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;
import android.widget.AdapterView.OnItemSelectedListener;

public class NuevaCuenta extends Activity implements OnClickListener, OnItemSelectedListener, OnFocusChangeListener
{
	private EditText txtNombre;
	private EditText txtAppPaterno;
	private EditText txtAppMaterno;
	private EditText txtRut;
	private EditText txtFechaNacimiento;
	private EditText txtDireccion;
	private Spinner spRegion;
	private Spinner spComuna;
	private EditText txtFonoFijo;
	private EditText txtCelular;
	private EditText txtEmail;
	private EditText txtContrasena;
	private EditText txtConfirmarContrasena;
	private Button btnCrearUsuario;
	private ArrayList<Region> regionGlobal;
	private ArrayList<Comunas> comunasGlobal;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.nueva_cuenta);
        new obtenerRegiones().execute(0,0);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
    	txtNombre = (EditText)findViewById(R.id.txtNombre);
    	txtAppPaterno = (EditText)findViewById(R.id.txtAppPaterno);
    	txtAppMaterno = (EditText)findViewById(R.id.txtAppMaterno);
    	txtRut = (EditText)findViewById(R.id.txtRut);
    	txtFechaNacimiento = (EditText)findViewById(R.id.txtFechaNacimiento);
    	txtDireccion = (EditText)findViewById(R.id.txtDireccion);
    	spRegion = (Spinner)findViewById(R.id.spRegionesNvaCta);
    	spComuna = (Spinner)findViewById(R.id.spComunaNvaCta);
    	txtFonoFijo = (EditText)findViewById(R.id.txtTelefonoFijo);
    	txtCelular = (EditText)findViewById(R.id.txtCelular);
    	txtEmail = (EditText)findViewById(R.id.edtMail);
    	txtContrasena = (EditText)findViewById(R.id.txtPassNueva);
    	txtConfirmarContrasena = (EditText)findViewById(R.id.txtPassNuevaConfirmar);
    	btnCrearUsuario = (Button)findViewById(R.id.btnCrearCuenta);
    	btnCrearUsuario.setOnClickListener(this);
    	
    	txtNombre.setOnFocusChangeListener(this);
    	txtAppPaterno.setOnFocusChangeListener(this);
    	txtAppMaterno.setOnFocusChangeListener(this);
    	txtRut.setOnFocusChangeListener(this);
    	txtFechaNacimiento.setOnFocusChangeListener(this);
    	spRegion.setOnFocusChangeListener(this);
    	spComuna.setOnFocusChangeListener(this);
    	txtFonoFijo.setOnFocusChangeListener(this);
    	txtCelular.setOnFocusChangeListener(this);
    	txtEmail.setOnFocusChangeListener(this);
    	txtContrasena.setOnFocusChangeListener(this);
    	txtConfirmarContrasena.setOnFocusChangeListener(this);
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
			case R.id.btnCrearCuenta:
				String mail = txtEmail.getText().toString();
				String nombre = txtNombre.getText().toString();
				String appPaterno = txtAppMaterno.getText().toString();
				String appMaterno = txtAppMaterno.getText().toString();
				String rutVariable = txtRut.getText().toString();
				String fechaNacimiento = txtFechaNacimiento.getText().toString();
				String telefonoFijo = txtFonoFijo.getText().toString();
				String celular = txtCelular.getText().toString();
				
				if(nombres(this,nombre)&&apellidos(this,appPaterno)&&apellidos(this,appMaterno)&&rut(this,rutVariable)&&fecha(this,fechaNacimiento)
						&&(telefono(this,telefonoFijo)||telefono(this,celular))&&mail(this,mail)
						&&txtConfirmarContrasena.getText().toString().compareToIgnoreCase(txtContrasena.getText().toString())==0&&txtConfirmarContrasena.getText().length()!=0)
				{
					int idComuna = 0 ;
					for (Comunas comuna : comunasGlobal)
					{
						if(spComuna.getSelectedItem().toString().compareToIgnoreCase(comuna.getNomComuna())==0)
						{
							idComuna=comuna.getIdComuna();
							break;
						}
					}
					Log.e("idComuna", idComuna+"");
					String[] rut = txtRut.getText().toString().split("-");
					String[] fecha = txtFechaNacimiento.getText().toString().split("-");
					String fechaMostrar = fecha[2]+"-"+fecha[1]+"-"+fecha[0];
					Persona per = new Persona(0, 4, Integer.parseInt(rut[0]), rut[1] , txtNombre.getText().toString(), txtAppPaterno.getText().toString(), txtAppMaterno.getText().toString(), fechaMostrar);
					DatosContacto datoContacto = new DatosContacto(0, idComuna, txtFonoFijo.getText().toString(), txtCelular.getText().toString(), txtDireccion.getText().toString(), txtEmail.getText().toString(), new Date().toString());
					Pass contrasena = new Pass(0, txtConfirmarContrasena.getText().toString(), "2014-12-12");
					new InsertarUsuario().execute(per,datoContacto,contrasena);
				}
			break;
		}
    }
    class BusquedaComunas extends AsyncTask<Void, Void, Void>
    {
		@Override
		protected Void doInBackground(Void... params)
		{
			// TODO Auto-generated method stub
			return null;
		}
    }
    class InsertarUsuario extends AsyncTask<Object, Void, String>
    {
		@Override
		protected void onPreExecute()
		{
			// TODO Auto-generated method stub
			super.onPreExecute();
		}

		@Override
		protected String doInBackground(Object... params)
		{
			Log.e("entre","entre");
			Persona per = (Persona) params[0];
			DatosContacto datos = (DatosContacto)params[1];
			Pass contrasena = (Pass)params[2];
			controladoraAgregarUsuario controladora = new controladoraAgregarUsuario(NuevaCuenta.this);
			String resultado = controladora.crearCuenta(per, datos, contrasena);
			// TODO Auto-generated method stub
			return resultado;
		}
		
		@Override
		protected void onPostExecute(String result)
		{
			// TODO Auto-generated method stu
			if(result.compareToIgnoreCase("Todos los datos fueron insertados")==0)
			{
				Toast.makeText(NuevaCuenta.this,"Datos insertado correctamente", Toast.LENGTH_SHORT).show();
				finish();
			}
			else
			{
				Toast.makeText(NuevaCuenta.this,"Error al insertar los datos", Toast.LENGTH_SHORT).show();
			}
			super.onPostExecute(result);
		}
    }
    
	@Override
	public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
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
			
			ArrayAdapter<Comunas> listaEpinnerComunas = new ArrayAdapter<Comunas>(NuevaCuenta.this, android.R.layout.simple_spinner_item, comunasForSpinner);
			listaEpinnerComunas.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			spComuna.setAdapter(listaEpinnerComunas);
		}
	}

	@Override
	public void onNothingSelected(AdapterView<?> arg0)
	{
		// TODO Auto-generated method stub
	}
	
	class obtenerComunas extends AsyncTask<Integer, Void, ArrayList<Object>>
    {
		@Override
		protected ArrayList<Object> doInBackground(Integer... params)
		{
			ArrayList<Object> listaObjetos = new ArrayList<Object>();
			ControladoraEditarDatosContacto controladoraEditarDatos = new ControladoraEditarDatosContacto(NuevaCuenta.this);
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
			
			ArrayAdapter<Comunas> listaEpinnerComunas = new ArrayAdapter<Comunas>(NuevaCuenta.this, android.R.layout.simple_spinner_item, comunaForSpinner);
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
			spRegion.setOnItemSelectedListener(NuevaCuenta.this);
			super.onPostExecute(result);
		}
    }
	
    class obtenerRegiones extends AsyncTask<Integer, Void, ArrayList<Object>>
    {
		@Override
		protected ArrayList<Object> doInBackground(Integer... params)
		{
			ArrayList<Object> listaObjeto = new ArrayList<Object>();
			ControladoraEditarDatosContacto controladoraEditarDatos = new ControladoraEditarDatosContacto(NuevaCuenta.this);
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
			ArrayAdapter<Region> listaEpinnerRegiones= new ArrayAdapter<Region>(NuevaCuenta.this, android.R.layout.simple_spinner_item, region);
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
    
	@Override
	public void onFocusChange(View v, boolean hasFocus)
	{
		String texto = ((EditText)v).getText().toString();
		if(!hasFocus)
		{
			switch (v.getId())
			{
				case R.id.edtMail:
					mail(this,texto);
				break;
				case R.id.txtNombre:
					nombres(this,texto);
					break;
				case R.id.txtAppPaterno:
					apellidos(this,texto);
					break;
				case R.id.txtAppMaterno:
					apellidos(this,texto);
					break;
				case R.id.txtRut:
					rut(this,texto);
					break;
				case R.id.txtFechaNacimiento:
					fecha(this,texto);
					break;
				case R.id.txtTelefonoFijo:
					telefono(this,texto);
					break;
				case R.id.txtCelular:
					telefono(this,texto);
					break;
			}
		}
	}
}
