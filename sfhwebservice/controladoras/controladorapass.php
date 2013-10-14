<?php
require_once '../bdmysql/MySqlCon.php'; 
require '../phpass/PasswordHash.php';
require_once '../pojos/pass.php';

class ControladoraPass
{
	private $SqlQuery;
	private $datos;

	public function insertarPass(Pass $passObjeto)
	{
		$conexion = new MySqlCon();
		$idPersona = $passObjeto->idPersona;
		$password = $passObjeto->contrasena;
		$fechaCaducidad = $passObjeto->fechaCaducidad;
		echo($password);
		$hasher = new PasswordHash(8, false);	
		$passHash = $hasher->HashPassword($password);
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `pass`(`ID_PERSONA`,`PASS`,`FECHA_CADUCIDAD`) VALUES (?,?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iss', $idPersona, $passHash, $fechaCaducidad);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Password Registrada";
			}
			else
			{
				$conexion->close();
	        	return false;
	        }
		}
		catch(Exception $e)
		{
			return false;
			throw new $e("Error al insertar tratamiento.");
		}
	}

	public function modificarPass(Pass $pass)
	{
		$conexion = new MySqlCon();
		$idPersona = $pass->idPersona;
		$password = $pass->pass;
		$fechaCaducidad = $pass->fechaCaducidad;
		$hasher = new PasswordHash(8, false);	
		$passHash = $hasher->HashPassword($password);
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='UPDATE pass SET PASS=?,FECHA_CADUCIDAD=? WHERE ID_PERSONA=?;';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('ssi', $passHash, $fechaCaducidad, $idPersona);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return $sentencia->insert_id;
			}
			else
			{
				$conexion->close();
	        	return false;
	        }
		}
		catch(Exception $e)
		{
			return false;
			throw new $e("Error al insertar abono.");
		}
	}
	public function buscarIdPersona($idPersona)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM pass WHERE ID_PERSONA=? ";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$idPersona);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $pass, $fechaCaducidad);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$pass = new PASS();
					$pass->initClass($idPersona,$pass,$fechaCaducidad);
        			$this->datos[$indice] = $pass;
        			
        			$indice++;
				}
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar pacientes");
        }
        return $this->datos;
	}
}
?>