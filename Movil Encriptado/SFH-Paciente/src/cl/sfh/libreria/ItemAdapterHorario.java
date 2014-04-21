package cl.sfh.libreria;

import cl.sfh.entidades.HorasTomadas;
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
public class ItemAdapterHorario extends BaseAdapter
{
	private Activity actividad;
	private ArrayList<HorasTomadas> item;

	public ItemAdapterHorario(Activity actividad, ArrayList<HorasTomadas> item)
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
		return item.get(position).getIdOdontologo();
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		View v = convertView;
		// Asociamos el layout de la lista que hemos creado
		if (convertView == null)
		{
			LayoutInflater inf = (LayoutInflater) actividad.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			v = inf.inflate(R.layout.item_horario, null);
		}
		// Creamos un objeto directivo
		HorasTomadas dir = item.get(position);
		
		TextView nomOdontologo = (TextView) v.findViewById(R.id.txtOdontologoHorario);
		nomOdontologo.setText(dir.getNomOdontologo());
		
		TextView fecha = (TextView) v.findViewById(R.id.TxtFechaHorario);
		fecha.setText(dir.getFecha());
		
		TextView hora = (TextView) v.findViewById(R.id.txtHoraHorario);
		hora.setText(dir.getHora());
		// Retornamos la vista
		return v;
	}
}
