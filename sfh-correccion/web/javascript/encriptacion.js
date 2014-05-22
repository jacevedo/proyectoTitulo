function encriptar(json)
{
 	var jsonBase = btoa(json);
 	var largoJson = jsonBase.length;
 	var saltGenerada = generarSalt(453)+"";
 	var jsonSalt  = grabarSalt(jsonBase,saltGenerada,largoJson);
 	return jsonSalt;
}
function desencriptar(encriptado)
{
	var jsonEncriptado = quitarSalt(encriptado);
	var jsonString = atob(jsonEncriptado);
	return jsonString;
}
function quitarSalt(base64)
{
	var primeraBase = base64.substring(3, 7);
	var segundaBase = base64.substring(9, 13);
	var terceraBase = base64.substring(15, 17);
	var cuartaBase = base64.substring(19,base64.length-4);
	return primeraBase + segundaBase + terceraBase + cuartaBase;
}
function grabarSalt(jsonEncriptado, saltJson, largoJson)
{
	var primera = jsonEncriptado.substring(0,4);
	var segunda = jsonEncriptado.substring(4 , 8);
	var tercera = jsonEncriptado.substring(8, 10);
	var finalTexto = jsonEncriptado.substring(10);
	var primeraSalt = (saltJson+"").substring(0,2);
	var segundaSalt = (saltJson+"").substring(3,5);
	var terceraSalt = (saltJson+"").substring(4,6);
	var cuartaSalt = (saltJson+"").substring(6,8);
	var quintaSalt = (saltJson+"").substring(8);
	
	
	
	
	var encriptacion = primeraSalt + primera + terceraSalt + segunda + cuartaSalt + tercera + quintaSalt + finalTexto + segundaSalt;
	var primeraLargo = (largoJson+"").substring(0, 1);
	var segundaLargo = (largoJson+"").substring( 1, 2);
	
	encriptacion = primeraLargo + encriptacion + segundaLargo;
	
	return encriptacion;
}	
function generarSalt(largo)
{
	var largoString = largo +"";
	var dicc = "0a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z";
	var salt = "";
	var datos = new Array();
	datos[0] = largoString.charAt(0);
	datos[1] = largoString.charAt(1);
	datos[2] = largoString.charAt(2);
	datos[3] = largoString.charAt(2);
	datos[4] = largoString.charAt(1);
	datos[5] = largoString.charAt(0);
	datos[6] = parseInt(datos[0]) + parseInt(datos[1]) + parseInt(datos[2]);
	datos[7] = parseInt(datos[6]) * 2;
	datos[8] = parseInt(datos[7]) * 2;
	datos[9] = parseInt(datos[8]) * parseInt(datos[8]);
	for (var i = 0; i < datos.length; i++)
	{
			if(datos[i]>dicc.length)
			{
 				var primerosDigitosOctava = (datos[i]+"").substring(0, 1);
				var segundosOctava = (datos[i]+"").substring(1, 2);
				
			
				if(segundosOctava ==0 &&primerosDigitosOctava >= dicc.length )
				{
					segundosOctava = 5;
				}
				while(primerosDigitosOctava >= dicc.length)
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