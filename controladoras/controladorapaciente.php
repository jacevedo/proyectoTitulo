<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/paciente.php';

class ControladoraPaciente
{
	private $SqlQuery;
	private $datos;

	public function crearPaciente(Persona $persona, $fechaIngreso)
	{

	}
	public function insertarPaciente(Paciente $paciente)
	{
		$conexion = new MySqlCon();
		$idPersona = $paciente->idPersona;
		$fechaIngreso = $paciente->fechaIngreso;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `paciente` (`ID_PACIENTE` ,`ID_PERSONA` ,`FECHA_INGRESO`) VALUES (null,  ?,  ?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('is',$idPersona,$fechaIngreso);
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
         throw new $e("Error al Registrar Usuarios");
        }
	}
	public function listarPacientes()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `paciente`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPaciente,$idPersona,$fechaIngreso,$habilitadoPaciente);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$paciente = new Paciente();
					$paciente->initClass($idPaciente,$idPersona,$fechaIngreso,$habilitadoPaciente);
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

	public function modificarPacientes(Paciente $pacientes)
	{
		$conexion = new MySqlCon();
		$idPersona = $pacientes->idPersona;
		$fechaIngreso = $pacientes->fechaIngreso;
		$idPaciente = $pacientes->idPaciente;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `paciente` SET `ID_PERSONA` = ?, `FECHA_INGRESO` = ? WHERE `ID_PACIENTE` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isi',$idPersona,$fechaIngreso,$idPaciente);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Modificado";
			}
			else
			{
				$conexion->close();
	        	return "no modifique";
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Actualizar Usuarios");
        }
	}
}

?>