package cl.sfh.Odontologo;

import android.os.Bundle;
import android.app.Activity;
import android.view.View;
import android.widget.Button;
import android.content.Intent;
import android.view.View.OnClickListener;

public class MenuAplicacion extends Activity implements OnClickListener
{
    private Button btnVerHorario;
    private Button btnVerFicha;
    private Button btnCerrarSesion;
    private Button btnEditarCuenta;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.menu);
        inicializarElementos();
    }

    private void inicializarElementos()
    {
        btnVerHorario = (Button)findViewById(R.id.btnHorario);
        btnVerFicha = (Button)findViewById(R.id.btnVerFicha);
        btnCerrarSesion = (Button)findViewById(R.id.btnCerrarSesion);
        btnEditarCuenta = (Button)findViewById(R.id.btnEditarCuentas);

        btnEditarCuenta.setOnClickListener(this);
        btnVerHorario.setOnClickListener(this);
        btnVerFicha.setOnClickListener(this);
        btnCerrarSesion.setOnClickListener(this);
    }


    @Override
    public void onClick(View v)
    {
        Intent i;
        switch (v.getId())
        {
            case R.id.btnHorario:
                i = new Intent("cl.sfh.Odontologo.HorasCargadas");
                startActivity(i);
                break;
            case R.id.btnVerFicha:
                i = new Intent("cl.sfh.Odontologo.ListaPaciente");
                startActivity(i);
                break;
            case R.id.btnCerrarSesion:
                i = new Intent("cl.sfh.Odontologo.MainActivity");
                startActivity(i);
                finish();
                break;
            case R.id.btnEditarCuentas:
                i = new Intent("cl.sfh.Odontologo.EditarCuenta");
                startActivity(i);
                break;
        }
    }
}
