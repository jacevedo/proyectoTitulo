<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/odontologo.php';
require_once '../pojos/persona.php';
 class ControladoraDoctor
{
	function CrearDoctor($idOdontologo,Persona $persona, $especialidad)
	{

	}

	public function insertarDoctor(Odontologo $doctor)
	{
		$conexion = new MySqlCon();
		$idPersona = $doctor->idPersona;
		$especialidad = $doctor->especialidad;
		$habilitado  = $doctor->odontologoHabilitado;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO  `odontologo` (`ID_ODONTOLOGO` ,`ID_PERSONA` ,`ESPECIALIDAD`,`ODONTOLOGO_HABILITADO`) VALUES (NULL ,  ?,  ?, ?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isi',$idPersona,$especialidad,$habilitado);
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
         throw new $e("Error al Registrar Odontologo");
        }

	}

	public function listarDoctoresPersona()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pe.ID_PERSONA, pe.ID_PERFIL, od.ID_ODONTOLOGO, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO,".
								"pe.APELLIDO_MATERNO, pe.FECHA_NAC, od.ESPECIALIDAD, od.ODONTOLOGO_HABILITADO FROM odontologo od, persona pe ".
								"WHERE od.ID_PERSONA = pe.ID_PERSONA";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->initClassDatosCompletos($idPersona, $idPerfil, $idOdontologo, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $especialidad,$odontologoHabilitado);
				$indice=0;     
				while($sentencia->fetch())
				{
					$doctor = new Odontologo();
					$doctor->initClass($idOdontologo,$idPersona,$especialidad,$odontologoHabilitado);
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
	public function modificarDoctor(Odontologo $doctor)
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
				return "modificado";
			}
			else
			{
				$conexion->close();
	        	return "No modificado";
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Actualizar Usuarios");
        }
	}

	public function listarDoctores()
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
        		$sentencia->bind_result($idOdontologo,$idPersona,$especialidad,$odontologoHabilitado);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$doctor = new Odontologo();
					$doctor->initClass($idOdontologo,$idPersona,$especialidad,$odontologoHabilitado);
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
}
?>