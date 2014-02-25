package cl.sfh.Odontologo;


import java.util.regex.Pattern;

import cl.sfh.controladoras.ControladoraLogin;
import cl.sfh.entidades.Login;
import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.app.ProgressDialog;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;

public class MainActivity extends Activity implements OnClickListener, OnFocusChangeListener
{
    private Button btnEntrar;
    private EditText txtUsuario;
    private EditText txtPass;
    private ProgressDialog dialogo;

    
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
        btnEntrar =(Button)findViewById(R.id.btnEntrar);
        txtUsuario = (EditText)findViewById(R.id.txtUsuario);
    	txtPass = (EditText)findViewById(R.id.txtContrasena);
    	dialogo = new ProgressDialog(MainActivity.this);
		dialogo.setMessage("Iniciando Sesion...");
		dialogo.setTitle("Cargando");
        btnEntrar.setOnClickListener(this);
        txtUsuario.setOnFocusChangeListener(this);

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
            case R.id.btnEntrar:
            	String texto = txtUsuario.getText().toString();
            	if(validarUsuario(texto) && txtPass.getText().toString().length()!=0)
            	{
	            	dialogo.show();
	        		String usuario = txtUsuario.getText().toString();
	        		String pass = txtPass.getText().toString();
	        		new Asincrono().execute(usuario, pass);
            	}
                break;
        }
    }
    private boolean validarUsuario(String user)
    {
    	
		
		if(!Pattern.matches("\\d{7}|\\d{8}", user))
		{
		    Toast.makeText(this, "debe ingresar su rut sin guion ni digito verificador", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
    }
    class Asincrono extends	AsyncTask<String, Login,Login>
	{
			
		@Override
		protected void onPreExecute()
		{
			super.onPreExecute();
		}

		@Override
		protected Login doInBackground(String... params)
		{
			ControladoraLogin controlLogin = new ControladoraLogin();
			Login login = controlLogin.loginKey(Integer.parseInt(params[0]), params[1]);
			
			return login;
		}

		@Override
		protected void onPostExecute(Login result)
		{
			
			dialogo.dismiss();
			SharedPreferences preferencias = getSharedPreferences("datos",Context.MODE_PRIVATE);
			Editor editor=preferencias.edit();
	        editor.putInt("idPersona", result.getIdPersona());
	        editor.putInt("idOdontologo", result.getIdOdontologo());
	        editor.putInt("rutPersona", Integer.parseInt(txtUsuario.getText().toString()));
	        editor.putString("key", result.getKey());
	        editor.commit();
			if(result.getCodAcceso()==706||result.getCodAcceso()==707)
			{
				 Intent i;
				 i = new Intent("cl.sfh.Odontologo.MenuAplicacion");
		         startActivity(i);
		         finish();
			}
			else
			{
				Toast.makeText(MainActivity.this, "Usuario y/o Contraseña Incorrecto", Toast.LENGTH_SHORT).show();
			}
			super.onPostExecute(result);
		}	
	}
	@Override
	public void onFocusChange(View v, boolean hasFocus)
	{
		if(!hasFocus)
		{
			String texto = txtUsuario.getText().toString();
			validarUsuario(texto);
		}
	}
}
