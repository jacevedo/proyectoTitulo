package cl.sfh.Odontologo;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.widget.TextView;

public class Ficha extends Activity
{
    private TextView txtNombre;
    private TextView txtAppPaterno;
    private TextView txtAppMaterno;
    private TextView txtFechaNacimiento;
    private TextView txtAnamnesis;
    private TextView txtUltimoProcedimiento;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.ficha);
        Bundle bundle = getIntent().getExtras();
        inicializarElementos(bundle);
    }

    private void inicializarElementos(Bundle bundle)
    {
        txtAnamnesis = (TextView)findViewById(R.id.txtAnamnesis);
        txtNombre = (TextView)findViewById(R.id.txtNombre);
        txtAppPaterno = (TextView)findViewById(R.id.txtAppPaterno);
        txtAppMaterno  = (TextView)findViewById(R.id.txtAppMaterno);
        txtFechaNacimiento = (TextView)findViewById(R.id.txtFechaNacimento);
        txtUltimoProcedimiento = (TextView)findViewById(R.id.txtUltimoProcedimiento);

        txtAnamnesis.setText(bundle.getString("anamnesis"));
        txtNombre.setText(bundle.getString("nombrePaciente"));
        txtAppPaterno.setText(bundle.getString("apellidoPaterno"));
        txtAppMaterno.setText(bundle.getString("apellidoMaterno"));
        txtFechaNacimiento.setText(bundle.getString("fechaNacimiento"));
        int contador = bundle.getInt("cantTratamientos");
        String tratamientos="";
        
        for(int i=0;i!=contador;i++)
        {
        	tratamientos = tratamientos+ bundle.getString("tratamiento"+i)+"\n";
        }
        
        txtUltimoProcedimiento.setText(tratamientos);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        return true;
    }
}
