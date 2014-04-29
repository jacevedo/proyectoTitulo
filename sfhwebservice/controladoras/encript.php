<?php
require_once '../bdmysql/MySqlCon.php'; 
class Encript
{
	private $SqlQuery;
	public function encriptar($json)
	{
		$largoJson = 453;
		$jsonString = json_encode($json);
		$salt = $this->generarSalt();
		$encriptado = base64_encode($jsonString);
		
		return $this->grabarSalt($encriptado,$salt,$largoJson);
	}
	private function desencriptar($base64)
	{
		$realBase = $this->quitarSalt($base64);
		return base64_decode($realBase);
	}
	public function validarSinKey($base64)
	{
		$realBase = $this->quitarSalt($base64);
        
		return base64_decode($realBase);
	}
	public function validarkey($base64)
	{
		$jsonDesencriptar = $this->desencriptar($base64);
		$json = json_decode($jsonDesencriptar);
		error_log("json: datos: ".$jsonDesencriptar); 
		$key = $json->{'key'};
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT se.FECHA_HORA_CADUCIDAD FROM session se WHERE se.KEY_SESSION = ?";

		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$key);
		   	if($sentencia->execute())
        	{
        		$sentencia->bind_result($FECHA_HORA_CADUCIDAD);	
        		if($sentencia->fetch())
	        	{
	        		return  $jsonDesencriptar;    		
	        	}
	        	else
	        	{
	        		return -1;
	        	}
      		}
      		else
      		{
      			return -2;
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar ordenes");
			return -3;
		}

	}
	private function quitarSalt($base64)
	{
		$primeraBase = substr($base64, 3, 4);
		$segundaBase = substr($base64, 9, 4);
		$terceraBase = substr($base64, 15, 2);
		$cuartaBase = substr($base64, 19,strlen($base64)-22);

		return $primeraBase.$segundaBase.$terceraBase.$cuartaBase;
	}
	private function generarSalt()
	{
		$largo = "453";

		$dicc = "0a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z";
		$datos;
		$datos[0] = $largo[0];
		$datos[1] = $largo[1];
		$datos[2] = $largo[2];
		$datos[3] = $largo[2];
		$datos[4] = $largo[1];
		$datos[5] = $largo[0];
		$datos[6] = $largo[1] + $largo[2] + $largo[0];
		$datos[7] = $datos[6] * 2;
		$datos[8] = $datos[7] + $datos[7]; 
		$datos[9] = $datos[8] * $datos[8];
		$salt = "";
		for ($i=0; $i<count($datos); ++$i)
		{
			$largoDicc = strlen($dicc);
			if($datos[$i]>= $largoDicc)
			{	
				$variable = substr($datos[$i], 0, 2);
				$variableDos = substr($datos[$i], 0, 1);
				if($variableDos==0)
				{
					$variableDos=5;
				}
				while($variable >= $largoDicc)
				{
					$variable = $variable - $variableDos;
				}
				$salt = $salt . $dicc[$variable]; 
			}
			else
			{
				$salt = $salt . $dicc[$datos[$i]]; 
			}
		}
		return $salt;
	}
	private function grabarSalt($string, $salt, $largoJson)
	{
		$primera = substr($string,0,4);
		$segunda = substr($string, 4, 4);
		$tercera = substr($string, 8, 2);
		$final = substr($string, 10);
		$primeraSalt = substr($salt, 0,2);
		$segundaSalt = substr($salt, 2,2);
		$terceraSalt = substr($salt, 4,2);
		$cuartaSalt = substr($salt, 6,2);
		$quintaSalt = substr($salt, 8,2);
		$encriptacion = $primeraSalt . $primera. $terceraSalt . $segunda . $cuartaSalt. $tercera.$quintaSalt.$final.$segundaSalt;
		$primeraLargo = substr($largoJson, 0, 1);
		$segundaLargo = substr($largoJson, 1, 2);
		$encriptacion = $primeraLargo.$encriptacion.$segundaLargo;
		return $encriptacion;
	}	
}