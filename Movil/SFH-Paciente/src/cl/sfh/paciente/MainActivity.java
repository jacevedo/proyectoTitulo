package cl.sfh.paciente;


import cl.sfh.controladoras.ControladoraLogin;
import cl.sfh.entidades.Login;
import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.app.ProgressDialog;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;

public class MainActivity extends Activity implements OnClickListener
{
    private Button btnEntrar;
    private Button btnNuevaCuenta;
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
    	txtUsuario = (EditText)findViewById(R.id.txtUsuario);
    	txtPass = (EditText)findViewById(R.id.txtAppPaterno);
        btnEntrar = (Button)findViewById(R.id.btnEntrar);
        btnNuevaCuenta = (Button)findViewById(R.id.btnNuevaCuenta);
        dialogo = new ProgressDialog(MainActivity.this);
		dialogo.setMessage("Cargando Lista Precio");
		dialogo.setTitle("Cargando");
        btnEntrar.setOnClickListener(this);
        btnNuevaCuenta.setOnClickListener(this);
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
        Intent i;
        switch (v.getId())
        {
            case R.id.btnEntrar:
            	dialogo.show();
        		String usuario = txtUsuario.getText().toString();
        		String pass = txtPass.getText().toString();
        		new Asincrono().execute(usuario, pass);
                break;
            case R.id.btnNuevaCuenta:
                i = new Intent("cl.sfh.paciente.NuevaCuenta");
                startActivity(i);
                break;
        }
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
	        editor.putInt("idPaciente", result.getIdPaciente());
	        editor.commit();
			if(result.getCodAcceso()==704)
			{
				Intent i;
				i = new Intent("cl.sfh.paciente.Menu");
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
}
