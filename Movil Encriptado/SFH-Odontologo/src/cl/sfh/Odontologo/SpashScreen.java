package cl.sfh.Odontologo;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.view.Display;
import android.view.Menu;
import android.view.Window;
import android.widget.ImageView;
import android.widget.ProgressBar;

import java.util.jar.JarEntry;

public class SpashScreen extends Activity {

    ImageView imgLogo;
    Display display;
    Bitmap fotoLogo;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        setContentView(R.layout.splashscreen);
        display = getWindowManager().getDefaultDisplay();
        inicializarElementos();
    }

    private void inicializarElementos()
    {
 
        fotoLogo = BitmapFactory.decodeResource(getResources(), R.drawable.logo);
        Bitmap logo = redimensionarImagen(fotoLogo);
        imgLogo = (ImageView)findViewById(R.id.imgLogo);
        imgLogo.setImageBitmap(logo);
        new asincrono().execute();
    }
    private Bitmap redimensionarImagen(Bitmap bm)
    {
        int ancho = display.getWidth();  //Ancho Pantalla
        int alto = display.getHeight(); //Alto Pantalla.
        bm = Bitmap.createScaledBitmap(bm, (ancho*40)/100, (alto*24)/100, true);
        return bm;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        return true;
    }
    class asincrono extends AsyncTask<String, String, String>
    {

        @Override
        protected String doInBackground(String... params)
        {
            try
            {
                Thread.sleep(3000);
            }
            catch (InterruptedException e)
            {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        protected void onPostExecute(String s)
        {
            Intent i = new Intent("cl.sfh.Odontologo.MainActivity");
            startActivity(i);
            finish();
        }
    }
    
}
