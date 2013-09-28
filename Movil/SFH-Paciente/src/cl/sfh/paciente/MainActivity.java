package cl.sfh.paciente;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.content.Intent;

public class MainActivity extends Activity implements OnClickListener
{
    private Button btnEntrar;
    private Button btnNuevaCuenta;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
        btnEntrar = (Button)findViewById(R.id.btnEntrar);
        btnNuevaCuenta = (Button)findViewById(R.id.btnNuevaCuenta);

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
                i = new Intent("cl.sfh.paciente.Menu");
                startActivity(i);
                finish();
                break;
            case R.id.btnNuevaCuenta:
                i = new Intent("cl.sfh.paciente.NuevaCuenta");
                startActivity(i);
                break;
        }
    }
}
