<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/paciente.php';
require_once '../pojos/persona.php';
 class ControladoraDoctor
{
	function CrearDoctor($idOdontologo,Persona $persona, $especialidad)
	{

	}

	function InsertarDoctor(Odontologo $doctor)
	{
		$conexion = new MySqlCon();
		$idPersona = $doctor->idOdontologo;
		$especialidad = $doctor->especialidad;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO  `odontologo` (`ID_ODONTOLOGO` ,`ID_PERSONA` ,`ESPECIALIDAD`) VALUES (NULL ,  ?,  ?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('is',$idPersona,$especialidad);
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
         throw new $e("Error al Registrar Odontologo");
        }

	}

	function ModificarDoctor(Odontologo $doctor)
	{
		$conexion = new MySqlCon();
		$idOdontologo = $doctor->idOdontologo;
		$idPersona = $doctor->idPersona;
		$especialidad = $doctor->especialidad;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `odontologo` SET `ID_PERSONA` = ?, `ESPECIALIDAD` = ? WHERE `ID_ODONTOLOGO` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isi',$idPersona,$especialidad,$idOdontologo);
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

	function ListarDoctores()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `odontologo`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idOdontologo,$idPersona,$especialidad);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$doctor = new Odontologo();
					$doctor->initClass($idOdontologo,$idPersona,$especialidad);
        			$this->datos[$indice] = $doctor;
        			
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

	function EliminarDoctor(Odontologo $doctor)
	{
		$conexion = new MySqlCon();
		try 
		{  
			$idOdontologo = $doctor->idOdontologo;
        	$this->SqlQuery='';
        	$this->SqlQuery='DELETE FROM `odontologo` WHERE `ID_ODONTOLOGO` = ?';
        	$sentencia=$conexion->prepare($this->SqlQuery); 
        	$sentencia->bind_param('i',$idPaciente);
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
        	throw new $e("Error al Eliminar Odontologo");
        }
	}
}
?>