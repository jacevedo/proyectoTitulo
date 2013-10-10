<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/session.php';

class ControladoraLogin
{
	private $SqlQuery;
	private $datos;


	public function validarUsusario($usuario, $pass)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT per.ID_PERSONA, per.RUT, pa.PASS FROM persona per, pass pa WHERE per.RUT = ? AND per.ID_PERSONA = pa.ID_PERSONA";
			
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$usuario);
		   	$sentencia->bind_result($idPersona,$usuarioBD, $passBD);	
        	$sentencia->execute();
        	if($sentencia->fetch())
        	{
        		$conexion->close();
        		$hasher = new PasswordHash(8, false);	
        		if($hasher->CheckPassword($pass, $passBD))
		        {
		        	$session = new Session();
					date_default_timezone_set('America/Argentina/Buenos_Aires');
		        	$hoy = date("Y-m-d H:i:s",time());
		        	$keyDesencriptada = $idPersona.$hoy;
		        	$keyHashada = $hasher->HashPassword($keyDesencriptada);
		        	$session->initClass(0, $idPersona, $keyHashada,$hoy,null);
		        	$datos = $this->insertSession($session);
		        	

		        }			
		        else
		        {
		        	$datos = "Usuario o Contrasena no correcta";
		        }
				$indice=0;     
				
      		}
       		
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar ordenes");
		}
		return $datos;
	}
	private function insertSession(Session $session)
	{
		$conexion = new MySqlCon();
		$idPersona = $session->idPersona;
		$keyHashada = $session->keySession;
		$horaFechaIngreso = $session->fechaHoraIngreso;
		$datos = '';
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery="INSERT INTO session (ID_SESSION, ID_PERSONA, KEY_SESSION, FECHA_HORA_INGRESO, FECHA_HORA_CADUCIDAD) VALUES (NULL ,?,?,?,?)";
			$sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isss', $idPersona, $keyHashada,$horaFechaIngreso,$horaFechaIngreso);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				if($sentencia->insert_id!=-1)
				{
					$datos = $keyHashada;
				}
				else
				{
					$datos = "Error en el inicio de session";
				}
			}
			else
			{
				$conexion->close();
	        	$datos = "Error en el inicio de session";
	        }

		}
		catch(Exception $e)
		{
			throw new $e("Error al listar ordenes");
		}
		return $datos;
	}
}
?>