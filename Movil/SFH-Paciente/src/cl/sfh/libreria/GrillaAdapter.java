package cl.sfh.libreria;

import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;

import cl.sfh.paciente.R;


/**
 * Created by jacevedo on 24-06-13.
 */
public class GrillaAdapter extends BaseAdapter
{
    ArrayList<DiasCalendario> dias;
    private Activity act;
    public GrillaAdapter(ArrayList<DiasCalendario> dias,Activity act)
    {
        this.dias=dias;
        this.act=act;
    }

    @Override
    public int getCount()
    {
        return dias.size();
    }

    @Override
    public Object getItem(int position)
    {
        return dias.get(position);
    }

    @Override
    public long getItemId(int position)
    {
        return dias.get(position).getId();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent)
    {

        View v = convertView;

        //Asociamos el layout de la lista que hemos creado
        if(convertView == null){
            LayoutInflater inf = (LayoutInflater) act.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            v = inf.inflate(R.layout.cuadro_grilla, null);
        }
        TextView diaNumero = (TextView) v.findViewById(R.id.txtNumero);
        diaNumero.setText(dias.get(position).getDia()+"");

        switch (dias.get(position).getEstado())
        {
            case 1:
                diaNumero.setBackgroundColor(Color.parseColor("#375D81"));
                diaNumero.setTextColor(Color.GREEN);
                break;
            case 2:
                diaNumero.setBackgroundColor(Color.parseColor("#375D81"));
                diaNumero.setTextColor(Color.YELLOW);
                break;
            case 3:
                diaNumero.setBackgroundColor(Color.parseColor("#375D81"));
                diaNumero.setTextColor(Color.RED);
                diaNumero.setTextColor(Color.RED);
                break;
        }


        return v;
    }
}
