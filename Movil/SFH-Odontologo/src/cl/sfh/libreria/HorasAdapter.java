package cl.sfh.libreria;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;

import cl.sfh.Odontologo.R;

/**
 * Created by jacevedo on 24-06-13.
 */
public class HorasAdapter extends BaseAdapter
{
    ArrayList<Horas> horas;
    Activity activity;

    public HorasAdapter(ArrayList<Horas> horas, Activity activity)
    {
        this.horas = horas;
        this.activity = activity;
    }

    @Override
    public int getCount()
    {
        return horas.size();
    }

    @Override
    public Object getItem(int position)
    {
        return horas.get(position);
    }

    @Override
    public long getItemId(int position)
    {
        return horas.get(position).getId();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent)
    {
        View v = convertView;

        if(convertView == null){
            LayoutInflater inf = (LayoutInflater) activity.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            v = inf.inflate(R.layout.hora, null);
        }

        Horas hora = horas.get(position);

        //Rellenamos el nombre
        TextView txtHora = (TextView) v.findViewById(R.id.txtHora);
        txtHora.setText(hora.getHora());

        TextView txtNomPaciente = (TextView)v.findViewById(R.id.txtNomPaciente);
        txtNomPaciente.setText(hora.getNomPaciente());

        // Retornamos la vista
        return v;
    }
}
