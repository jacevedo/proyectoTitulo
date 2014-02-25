package cl.sfh.libreria;

import org.json.JSONObject;

import android.util.Base64;
import android.util.Log;

public class Encoding
{
	public String encriptar(String json)
	{
		byte[] bites = json.getBytes();
		byte[] encodedBytes = Base64.encode(bites, Base64.DEFAULT);
		String resultado = new String(encodedBytes);
		int largoJson = resultado.length();
		String salt = generarSalt(453);
		return grabarSalt(resultado,salt,largoJson);
	}
	public String desencriptar(String base64)
	{
		String realBase = quitarSalt(base64);
		return new String(Base64.decode(realBase, Base64.DEFAULT));
	}
	private String quitarSalt(String base64)
	{
		String primeraBase = base64.substring(3, 7);
		String segundaBase = base64.substring(9, 13);
		String terceraBase = base64.substring(15, 17);
		String cuartaBase = base64.substring(19,base64.length()-5);
		Log.e("cuartaBase",cuartaBase);
		String [] cuartaBaseArreglo = cuartaBase.split("=");
		return primeraBase + segundaBase + terceraBase + cuartaBase;
	}
	private String generarSalt(int largo)
	{
		String largoString = largo +"";
		String dicc = "0a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z";
		String salt = "";
		int[] datos = new int[10];
		datos[0] = Integer.parseInt(largoString.charAt(0) +"");
		datos[1] = Integer.parseInt(largoString.charAt(1) +"");
		datos[2] = Integer.parseInt(largoString.charAt(2) +"");
		datos[3] = Integer.parseInt(largoString.charAt(2) +"");
		datos[4] = Integer.parseInt(largoString.charAt(1) +"");
		datos[5] = Integer.parseInt(largoString.charAt(0) +"");
		datos[6] = datos[0] + datos[1] + datos[2];
		datos[7] = datos[6] * 2;
		datos[8] = datos[7] * 2;
 		datos[9] = datos[8] * datos[8];
 		for (int i = 0; i < datos.length; i++)
		{
 			if(datos[i]>dicc.length())
 			{
	 			int primerosDigitosOctava = Integer.parseInt((datos[i]+"").substring(0, 2));
				int segundosOctava = Integer.parseInt((datos[i]+"").substring(1, 2));
				if(segundosOctava ==0 &&primerosDigitosOctava >= dicc.length() )
				{
					segundosOctava = 5;
				}
				while(primerosDigitosOctava >= dicc.length())
				{
					primerosDigitosOctava = primerosDigitosOctava - segundosOctava;
				}
				salt  = salt + dicc.charAt(primerosDigitosOctava);
 			}
 			else
 			{
 				salt  = salt + dicc.charAt(datos[i]);
 			}
			
		}
		return salt;
	}
	private String grabarSalt(String string, String salt,int largoJson)
	{
		String primera = string.substring(0,4);
		String segunda = string.substring(4 , 8);
		String tercera = string.substring(8, 10);
		String finalTexto = string.substring(10);
		String primeraSalt = salt.substring(0,2);
		String segundaSalt = salt.substring(3,5);
		String terceraSalt = salt.substring(4,6);
		String cuartaSalt = salt.substring(6,8);
		String quintaSalt = salt.substring(8);
		
		
		
		String encriptacion = primeraSalt + primera + terceraSalt + segunda + cuartaSalt + tercera + quintaSalt + finalTexto + segundaSalt;
		String primeraLargo = (largoJson+"").substring(0, 1);
		String segundaLargo = (largoJson+"").substring( 1, 2);
		
		encriptacion = primeraLargo + encriptacion + segundaLargo;
		
		return encriptacion;
	}	
}
