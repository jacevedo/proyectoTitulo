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
		$password = $pass->contrasena;
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
	      		if($sentencia->affected_rows)
	      		{
		        	$conexion->close();
					return "Modificado";
				}
				else
				{
					return "No se modifico nada";
				}
			}
			else
			{
				$conexion->close();
	        	return "No Modificado";
	        }
		}
		catch(Exception $e)
		{
			return "Exception";
			throw new $e("Error al insertar abono.");
		}
	}
	public function modificarPassConConfirmacion(Pass $passObjeto)
	{

		$conexion = new MySqlCon();
		$idPersona = $pass->idPersona;
		$password = $pass->contrasena;
		$fechaCaducidad = $pass->fechaCaducidad;
		$hasher = new PasswordHash(8, false);	
		$passHash = $hasher->HashPassword($password);
		if($this->validarPass($idPersona,$passAntigua))
		{
			return "holasssss";
			/*try
			{
				$this->SqlQuery='';
		        $this->SqlQuery='UPDATE pass SET PASS=?,FECHA_CADUCIDAD=? WHERE ID_PERSONA=?;';
		        $sentencia=$conexion->prepare($this->SqlQuery);
		        $sentencia->bind_param('ssi', $passHash, $fechaCaducidad, $idPersona);
		      	if($sentencia->execute())
		      	{
		      		if($sentencia->affected_rows)
		      		{
			        	$conexion->close();
						return "Modificado";
					}
					else
					{
						return "No se modifico nada";
					}
				}
				else
				{
					$conexion->close();
		        	return "No Modificado";
		        }
			}
			catch(Exception $e)
			{
				return "Exception";
				throw new $e("Error al insertar abono.");
			}*/
		}
		else
		{
			return "chaooooss";
		}
	}
	public function validarPass($usuario,$pass)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT per.ID_PERSONA, pa.PASS FROM persona per, pass pa WHERE per.ID_PERSONA = ? AND per.ID_PERSONA = pa.ID_PERSONA";

		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$usuario);

		   	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona,$usuarioBD,$passBD,$codAcceso,$idPaciente,$habilitado);	
        		
    			$hasher = new PasswordHash(8, false);	
	        	if($sentencia->fetch())
	        	{
	        		if($hasher->CheckPassword($pass, $passBD))
				    {
		        		$conexion->close();
		        		return true;
		        	}
	        	}
		      	else
        		{
        			$conexion->close();
        			return false;
        		}	        		
        	}
        	else
        	{
        		$conexion->close();
        		return false;
        	}
	        	
       		$conexion->close();
		}
		catch(Exception $e)
		{
			$conexion->close();
			return false;
		}
	}
	public function buscarIdPersona($id)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM pass WHERE ID_PERSONA=? ";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$id);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $pass, $fechaCaducidad);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$passP = new Pass();
					$passP->initClass($idPersona,$pass,$fechaCaducidad);
        			$this->datos[$indice] = $passP;
        			
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