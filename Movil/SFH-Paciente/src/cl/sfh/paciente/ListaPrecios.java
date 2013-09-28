package cl.sfh.paciente;

import android.app.Activity;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

import cl.sfh.controlaodas.ControladoraListaPrecios;
import cl.sfh.entidades.ListaPreciosEntidad;
import cl.sfh.libreria.ItemAdapter;

public class ListaPrecios extends Activity implements
		AdapterView.OnItemClickListener
{
	private ListView listaMain;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.lista_precios);
		inicializarElementos();
	}

	private void inicializarElementos()
	{
		listaMain = (ListView) findViewById(R.id.lstPrecios);
		new Asincrono(listaMain).execute();
	}

	@Override
	public boolean onCreateOptionsMenu(android.view.Menu menu)
	{
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onItemClick(AdapterView<?> parent, View view, int position,
			long id)
	{

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
		protected ArrayList<ListaPreciosEntidad> doInBackground(
				String... params)
		{
			ControladoraListaPrecios precios = new ControladoraListaPrecios();
			ArrayList<ListaPreciosEntidad> listarPrecio = precios
					.listarPrecios();
			return listarPrecio;
		}

		@Override
		protected void onPostExecute(ArrayList<ListaPreciosEntidad> result)
		{
			ItemAdapter adapter = new ItemAdapter(ListaPrecios.this, result);
			lista.setAdapter(adapter);
			//lista.setOnItemClickListener(ListaPrecios.this);
			super.onPostExecute(result);
		}

	}
}
