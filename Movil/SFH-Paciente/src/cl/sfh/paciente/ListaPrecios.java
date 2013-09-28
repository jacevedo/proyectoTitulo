package cl.sfh.paciente;

import android.app.Activity;
import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

import cl.sfh.controlaodas.ControladoraListaPrecios;
import cl.sfh.entidades.ListaPreciosEntidad;
import cl.sfh.libreria.ItemAdapter;

public class ListaPrecios extends Activity implements OnClickListener
{
	private ListView listaMain;
	private EditText txtBuscar;
	private Button btnBuscar;
	private ProgressDialog dialogo;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.lista_precios);
		dialogo = new ProgressDialog(ListaPrecios.this);
		dialogo.setMessage("Cargando Lista Precio");
		dialogo.setTitle("Cargando");
		dialogo.show();
		inicializarElementos();
	}

	private void inicializarElementos()
	{
		txtBuscar = (EditText)findViewById(R.id.txtBusqueda);
		btnBuscar = (Button)findViewById(R.id.btnBuscar);
		listaMain = (ListView) findViewById(R.id.lstPrecios);
		btnBuscar.setOnClickListener(this);
		
		new Asincrono(listaMain).execute();
	}
	@Override
	public void onClick(View v)
	{
		switch (v.getId())
		{
			case R.id.btnBuscar:
				dialogo.show();
				new BusquedaAsincrona(listaMain,txtBuscar).execute();
				break;
		}
	}
	
	class Asincrono extends
			AsyncTask<String, String, ArrayList<ListaPreciosEntidad>>
	{
		
		ListView lista;
		
		public Asincrono(ListView lista)
		{
			
			
			this.lista = lista;
		}
		
		@Override
		protected void onPreExecute()
		{
			// TODO Auto-generated method stub
			super.onPreExecute();
		}

		@Override
		protected ArrayList<ListaPreciosEntidad> doInBackground(String... params)
		{
			ControladoraListaPrecios precios = new ControladoraListaPrecios();
			ArrayList<ListaPreciosEntidad> listarPrecio = precios
					.listarPrecios();
			return listarPrecio;
		}

		@Override
		protected void onPostExecute(ArrayList<ListaPreciosEntidad> result)
		{
			dialogo.dismiss();
			ItemAdapter adapter = new ItemAdapter(ListaPrecios.this, result);
			lista.setAdapter(adapter);
			
			super.onPostExecute(result);
		}

	}
	class BusquedaAsincrona extends AsyncTask<String, String, ArrayList<ListaPreciosEntidad>>
	{
		ListView lista;
		EditText texto;
		public BusquedaAsincrona(ListView lista,EditText texto)
		{
			this.lista = lista;
			this.texto = texto;
		}

		@Override
		protected ArrayList<ListaPreciosEntidad> doInBackground(String... params)
		{
			ControladoraListaPrecios precios = new ControladoraListaPrecios();
			ArrayList<ListaPreciosEntidad> listarPrecio = precios.listarPreciosNombres(
																	texto.getText().toString());
			return listarPrecio;
		}

		@Override
		protected void onPostExecute(ArrayList<ListaPreciosEntidad> result)
		{
			dialogo.dismiss();
			ItemAdapter adapter = new ItemAdapter(ListaPrecios.this, result);
			lista.setAdapter(adapter);
			super.onPostExecute(result);
		}

	}
	

}
