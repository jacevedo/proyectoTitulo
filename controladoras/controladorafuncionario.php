<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/funcionario.php';

class ControladoraFuncionario
{
	function crearFuncionario($idFuncionario,$idPersona,$puestoTrabajo)
	{

	}
	function insertarFuncionario(Funcionario $funcionario)
	{
		$conexion = new MySqlCon();
	
		$idPersona = $funcionario->idPersona;
		$puestoTrabajo = $funcionario->puestoTrabajo;
		
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `funcionario` (`ID_FUNCIONARIO` ,`ID_PERSONA` ,`PUESTO_DE_TRABAJO`) VALUES (null, ?, ?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('is',$idPersona, $puestoTrabajo);
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
			throw new $e("Error al ingresar orden.");
		}
	}
	function modificarFuncionario(Funcionario $funcionario)
	{
		$conexion = new MySqlCon();
		$idFuncionario = $funcionario->idFuncionario;
		$idPersona = $funcionario->idPersona;
		$puestoTrabajo = $funcionario->puestoTrabajo;
		
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `funcionario` SET `ID_PERSONA` = ?, `PUESTO_DE_TRABAJO` = ? WHERE `ID_FUNCIONARIO` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isi',$idPersona,$puestoTrabajo,$idPaciente);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return true;
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
         throw new $e("Error al Actualizar Usuarios");
        }

	}
	function eliminarFuncionario(Funcionario $funcionario)
	{
		$conexion = new MySqlCon();
		try 
		{  
			$idFuncionario = $funcionario->idFuncionario;
        	$this->SqlQuery='';
        	$this->SqlQuery='DELETE FROM `funcionario` WHERE `ID_FUNCIONARIO` = ?';
        	$sentencia=$conexion->prepare($this->SqlQuery); 
        	$sentencia->bind_param('i',$idFuncionario);
			if($sentencia->execute())
			{
        		$conexion->close();
				return true;
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
        	throw new $e("Error al Eliminar Usuario");
        }
	}
	function listarFuncionario()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `funcionario`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFuncionario,$idPersona,$puestoTrabajo);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$funcionario = new Funcionario();
					$funcionario->initClass($idFuncionario,$idPersona,$puestoTrabajo);
        			$this->datos[$indice] = $paciente;
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