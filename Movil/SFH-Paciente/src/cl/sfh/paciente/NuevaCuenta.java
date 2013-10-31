package cl.sfh.paciente;

import java.util.Date;

import cl.sfh.controladoras.controladoraAgregarUsuario;
import cl.sfh.entidades.DatosContacto;
import cl.sfh.entidades.Pass;
import cl.sfh.entidades.Persona;
import android.app.Activity;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class NuevaCuenta extends Activity implements OnClickListener
{
	private EditText txtNombre;
	private EditText txtAppPaterno;
	private EditText txtAppMaterno;
	private EditText txtRut;
	private EditText txtFechaNacimiento;
	private EditText txtDireccion;
	private EditText txtComuna;
	private EditText txtFonoFijo;
	private EditText txtCelular;
	private EditText txtEmail;
	private EditText txtContrasena;
	private EditText txtConfirmarContrasena;
	private Button btnCrearUsuario;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.nueva_cuenta);
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
    	txtComuna = (EditText)findViewById(R.id.txtComuna);
    	txtFonoFijo = (EditText)findViewById(R.id.txtTelefonoFijo);
    	txtCelular = (EditText)findViewById(R.id.txtCelular);
    	txtEmail = (EditText)findViewById(R.id.txtMail);
    	txtContrasena = (EditText)findViewById(R.id.txtPassNueva);
    	txtConfirmarContrasena = (EditText)findViewById(R.id.txtPassNuevaConfirmar);
    	btnCrearUsuario = (Button)findViewById(R.id.btnCrearCuenta);
    	btnCrearUsuario.setOnClickListener(this);
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
				if(txtConfirmarContrasena.getText().toString().compareToIgnoreCase(txtContrasena.getText().toString())==0)
				{
					String[] rut = txtRut.getText().toString().split("-");
					Persona per = new Persona(0, 4, Integer.parseInt(rut[0]), rut[1] , txtNombre.getText().toString(), txtAppPaterno.getText().toString(), txtAppMaterno.getText().toString(), txtFechaNacimiento.getText().toString());
					DatosContacto datoContacto = new DatosContacto(0, Integer.parseInt(txtComuna.getText().toString()), txtFonoFijo.getText().toString(), txtCelular.getText().toString(), txtDireccion.getText().toString(), txtEmail.getText().toString(), new Date().toString());
					Pass contrasena = new Pass(0, txtConfirmarContrasena.getText().toString(), "2013-12-12");
					new InsertarUsuario().execute(per,datoContacto,contrasena);
				}
				else
				{
					Toast.makeText(this, "Debe tener Ambas Contraseñas iguales", Toast.LENGTH_SHORT).show();
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
			Persona per = (Persona) params[0];
			DatosContacto datos = (DatosContacto)params[1];
			Pass contrasena = (Pass)params[2];
			controladoraAgregarUsuario controladora = new controladoraAgregarUsuario();
			String resultado = controladora.crearCuenta(per, datos, contrasena);
			// TODO Auto-generated method stub
			return resultado;
		}
		@Override
		protected void onPostExecute(String result)
		{
			// TODO Auto-generated method stu
			if(result.compareToIgnoreCase("")==0)
			{
				Toast.makeText(NuevaCuenta.this,"Datos insertado Correctamente", Toast.LENGTH_SHORT).show();
			}
			else if(result.compareToIgnoreCase("")==0)
			{
				Toast.makeText(NuevaCuenta.this,"Datos insertado Correctamente", Toast.LENGTH_SHORT).show();
			}
			else if(result.compareToIgnoreCase("")==0)
			{
				Toast.makeText(NuevaCuenta.this,"Datos insertado Correctamente", Toast.LENGTH_SHORT).show();
			}
			super.onPostExecute(result);
		}

		
    }
    
}
