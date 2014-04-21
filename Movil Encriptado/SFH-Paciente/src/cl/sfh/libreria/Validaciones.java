package cl.sfh.libreria;

import java.util.regex.Pattern;

import android.app.Activity;
import android.widget.Toast;

public class Validaciones
{
	public static boolean soloNumeros(Activity actividad, String texto)
	{
		if(!Pattern.matches("\\d{7}|\\d{8}", texto))
		{
		    Toast.makeText(actividad, "Debe ingresar rut sin guión ni dígito verificador", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
	}
	public static boolean apellidos(Activity actividad, String texto)
	{
		if(!Pattern.matches("^[a-zA-ZñÑ]*", texto)||texto.length()==0)
		{
		    Toast.makeText(actividad, "Debe ingresar su apellido", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
	}
	public static boolean nombres(Activity actividad, String texto)
	{
		if(!Pattern.matches("(\\p{L}+)(([ ])(\\p{L}+))?", texto)||texto.length()==0)
		{
		    Toast.makeText(actividad, "Debe ingresar sólo texto y máximo dos nombres", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
	}
	public static boolean soloTexto(Activity actividad, String texto)
	{
		if(!Pattern.matches("^[a-zA-ZñÑ]*$", texto))
		{
		    Toast.makeText(actividad, "Debe ingresar sólo texto", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
	}
	
	public static boolean mail(Activity actividad, String texto)
	{
		if(!Pattern.matches("^[a-zA-Z0-9._%+-]+@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,4}$", texto))
		{
		    Toast.makeText(actividad, "Debe ingresar un email válido", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
	}
	public static boolean rut(Activity actividad, String texto)
	{
		if(!Pattern.matches("\\b\\d{7,8}\\-[K|k|0-9]", texto))
		{
		    Toast.makeText(actividad, "Debe ingresar un rut válido", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true&&validarRut(actividad,texto);
	}
	private static boolean validarRut(Activity actividad, String texto)
	{
		String[]rutArreglo = texto.split("-");
		int rut = Integer.parseInt(rutArreglo[0]);
		char dv = rutArreglo[1].charAt(0);
		int m = 0, s = 1;
        for (; rut != 0; rut /= 10)
        {
            s = (s + rut % 10 * (9 - m++ % 6)) % 11;
        }
       if(dv == (char) (s != 0 ? s + 47 : 75))
       {
    	   return true;
       }
       Toast.makeText(actividad, "Debe ingresar un rut válido", Toast.LENGTH_SHORT).show();
       return false;
	}
	public static boolean fecha(Activity actividad, String texto)
	{
		if(!Pattern.matches("\\d{2}\\-\\d{2}\\-\\d{4}", texto))
		{
		    Toast.makeText(actividad, "Debe ingresar día-mes-año (01-01-1991)", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
	}
	public static boolean telefono(Activity actividad, String texto)
	{
		if(!Pattern.matches("0{0,2}([\\+]?[\\d]{1,3} ?)?([\\(]([\\d]{2,3})[)] ?)?[0-9][0-9 \\-]{6,}( ?([xX]|([eE]xt[\\.]?)) ?([\\d]{1,5}))?", texto))
		{
		    Toast.makeText(actividad, "Debe ingresar un teléfono valido", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
	}
	public static boolean direccion(Activity actividad, String texto)
	{
		if(!Pattern.matches("0{0,2}([\\+]?[\\d]{1,3} ?)?([\\(]([\\d]{2,3})[)] ?)?[0-9][0-9 \\-]{6,}( ?([xX]|([eE]xt[\\.]?)) ?([\\d]{1,5}))?", texto))
		{
		    Toast.makeText(actividad, "Debe ingresar un email válido", Toast.LENGTH_SHORT).show();
		    return false;
		}
		return true;
	}
}
