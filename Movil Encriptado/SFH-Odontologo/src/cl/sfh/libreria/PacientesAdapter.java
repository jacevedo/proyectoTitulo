package cl.sfh.libreria;

import cl.sfh.Odontologo.R;
import cl.sfh.entidades.Pacientes;
import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;

public class PacientesAdapter extends BaseAdapter
{
    ArrayList<Pacientes> pacientes;
    Activity activity;

    public PacientesAdapter(ArrayList<Pacientes> pacientes, Activity activity)
    {
        this.pacientes = pacientes;
        this.activity = activity;
    }

    @Override
    public int getCount()
    {
        return pacientes.size();
    }

    @Override
    public Object getItem(int position)
    {
        return pacientes.get(position);
    }

    @Override
    public long getItemId(int position)
    {
        return pacientes.get(position).getId();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent)
    {
        View v = convertView;
        if(convertView == null)
        {
            LayoutInflater inf = (LayoutInflater) activity.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            v = inf.inflate(R.layout.item_lista, null);
        }

        // Creamos un objeto directivo
        Pacientes paciente = pacientes.get(position);

        //Rellenamos el nombre
        TextView nombre = (TextView) v.findViewById(R.id.txtNombre);
        nombre.setText(paciente.getNombre()+" " + paciente.getAppPaterno() + " " + paciente.getAppMaterno());

        // Retornamos la vista
        return v;
    }
}
