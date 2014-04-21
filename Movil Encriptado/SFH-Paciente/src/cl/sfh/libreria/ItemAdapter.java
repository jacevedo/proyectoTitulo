package cl.sfh.libreria;

import cl.sfh.entidades.ListaPreciosEntidad;
import cl.sfh.paciente.R;
import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.view.LayoutInflater;
import android.content.Context;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by jacevedo on 24-06-13.
 */
public class ItemAdapter extends BaseAdapter
{
	private Activity actividad;
	private ArrayList<ListaPreciosEntidad> item;

	public ItemAdapter(Activity actividad, ArrayList<ListaPreciosEntidad> item)
	{
		this.actividad = actividad;
		this.item = item;
	}

	@Override
	public int getCount()
	{
		return item.size();
	}

	@Override
	public Object getItem(int position)
	{
		return item.get(position);
	}

	@Override
	public long getItemId(int position)
	{
		return item.get(position).getIdPrecio();
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		View v = convertView;
		// Asociamos el layout de la lista que hemos creado
		if (convertView == null)
		{
			LayoutInflater inf = (LayoutInflater) actividad.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			v = inf.inflate(R.layout.item, null);
		}
		// Creamos un objeto directivo
		ListaPreciosEntidad dir = item.get(position);
		// Rellenamos el nombre
		TextView nombre = (TextView) v.findViewById(R.id.txtProcedimiento);
		nombre.setText(dir.getComentario());
		// Rellenamos el cargo
		TextView cargo = (TextView) v.findViewById(R.id.txtPrecio);
		cargo.setText(dir.getValorTotal() + "");
		// Retornamos la vista
		return v;
	}
}
