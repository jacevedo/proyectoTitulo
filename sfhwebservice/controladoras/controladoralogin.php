<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/pass.php';

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
        		$hasher = new PasswordHash(8, false);	
        		if($hasher->CheckPassword($pass, $passBD))
		        {
		        	$datos = insertSession($idPersona, $usuarioBD, $passBD);
		        }			
		        else
		        {
		        	$datos = "Usuario o Contrasena no correcta";
		        }
				$indice=0;     
				
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar ordenes");
		}
		return $datos;
	}
	function insertSession($idPersona, $usuarioBD, $passBD)
	
}
?>