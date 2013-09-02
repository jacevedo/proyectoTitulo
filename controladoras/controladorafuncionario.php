<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/funcionario.php';

class ControladoraFuncionario
{
	function crearFuncionario($idFuncionario,$idPersona,$puestoTrabajo)
	{

	}
	public function insertarFuncionario(Funcionario $funcionario)
	{
		$conexion = new MySqlCon();
	
		$idPersona = $funcionario->idPersona;
		$puestoTrabajo = $funcionario->puestoTrabajo;
		$funcionarioHabilitado = $funcionario->funcionarioHabilitado;
		
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `funcionario` (`ID_FUNCIONARIO`,`ID_PERSONA`,`PUESTO_DE_TRABAJO`,`FUNCIONARIO_HABILITADO`) VALUES (null, ?, ?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isi',$idPersona, $puestoTrabajo,$funcionarioHabilitado);
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
	public function modificarFuncionario(Funcionario $funcionario)
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
				return "Funcionario Modificado";
			}
			else
			{
				$conexion->close();
	        	return "Error no se modifico el funcionario";
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Actualizar Usuarios");
        }

	}
	public function desabilitarFuncionario(Funcionario $funcionario)
	{
		$conexion = new MySqlCon();
		$idFuncionario = $funcionario->idFuncionario;
		$funcionarioHabilitado = $funcionario->funcionarioHabilitado;
		
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `funcionario` SET `FUNCIONARIO_HABILITADO` = ? WHERE `ID_FUNCIONARIO` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('ii',$funcionarioHabilitado,$idPaciente);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Funcionario Desabilitado";
			}
			else
			{
				$conexion->close();
	        	return "Error, no se desabilito el funcionario";
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Actualizar Usuarios");
        }
	}
	public function listarFuncionario()
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
        		$sentencia->bind_result($idFuncionario,$idPersona,$puestoTrabajo,$funcionarioHabilitado);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$funcionario = new Funcionario();
					$funcionario->initClass($idFuncionario,$idPersona,$puestoTrabajo,$funcionarioHabilitado);
        			$this->datos[$indice] = $funcionario;
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