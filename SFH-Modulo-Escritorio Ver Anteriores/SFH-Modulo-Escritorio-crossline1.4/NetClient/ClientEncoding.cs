using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetClient
{
    class ClientEncoding
    {
        public String Encriptar(String json)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(json);
            String base64 = System.Convert.ToBase64String(plainTextBytes);
            int largoJson = base64.Length;
            String salt = GenerarSalt(453);
            return grabarSalt(base64,salt,largoJson);
        }
        public String Desencriptar(String base64) {
            String resultBase = quitarSalt(base64);
            var base64EncodedBytes = System.Convert.FromBase64String(resultBase);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        private String GenerarSalt(int largo)
        {
            String largoString = largo + "";
            String dicc = "0a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z";
            String salt = "";
            int[] datos = new int[10];
            datos[0] = int.Parse(largoString.ElementAt(0) + "");
            datos[1] = int.Parse(largoString.ElementAt(1) + "");
            datos[2] = int.Parse(largoString.ElementAt(2) + "");
            datos[3] = int.Parse(largoString.ElementAt(2) + "");
            datos[4] = int.Parse(largoString.ElementAt(1) + "");
            datos[5] = int.Parse(largoString.ElementAt(0) + "");
            datos[6] = datos[0] + datos[1] + datos[2];
            datos[7] = datos[6] * 2;
            datos[8] = datos[7] * 2;
            datos[9] = datos[8] * datos[8];
            for (int i = 0; i < datos.Length; i++)
            {
                if (datos[i] > dicc.Length)
                {
                    int primerosDigitosOctava = int.Parse((datos[i] + "").Substring(0, 2));
                    int segundosOctava = int.Parse((datos[i] + "").Substring(1, 2));
                    if (segundosOctava == 0 && primerosDigitosOctava >= dicc.Length)
                    {
                        segundosOctava = 5;
                    }
                    while (primerosDigitosOctava >= dicc.Length)
                    {
                        primerosDigitosOctava = primerosDigitosOctava - segundosOctava;
                    }
                    salt = salt + dicc.ElementAt(primerosDigitosOctava);
                }
                else
                {
                    salt = salt + dicc.ElementAt(datos[i]);
                }

            }
            return salt;
        }

        private String quitarSalt(String base64)
        {
            String primeraBase = base64.Substring(3, 4);
            String segundaBase = base64.Substring(9, 4);
            String terceraBase = base64.Substring(15, 2);
            String cuartaBase = base64.Substring(19, base64.Length - 23);
            String[] cuartaBaseArreglo = cuartaBase.Split('=');
            return primeraBase + segundaBase + terceraBase + cuartaBase;
        }

        private String grabarSalt(String param, String salt,int largoJson){
		String primera = param.Substring(0,4);
		String segunda = param.Substring(4 , 4);
		String tercera = param.Substring(8, 2);
		String finalTexto = param.Substring(10);
		String primeraSalt = salt.Substring(0,2);
		String segundaSalt = salt.Substring(3,2);
		String terceraSalt = salt.Substring(4,2);
		String cuartaSalt = salt.Substring(6,2);
		String quintaSalt = salt.Substring(8);
		String encriptacion = primeraSalt + primera + terceraSalt + segunda + cuartaSalt + tercera + quintaSalt + finalTexto + segundaSalt;
		String primeraLargo = (largoJson + "").Substring(0, 1);
		String segundaLargo = (largoJson + "").Substring( 1, 1);
		encriptacion = primeraLargo + encriptacion + segundaLargo;		
		return encriptacion;
        }	

    }
}
