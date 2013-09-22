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
        		$sentencia->bind_result($idPersona, $idPerfil, $idOdontologo, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $especialidad,$odontologoHabilitado);
				$indice=0;     
				while($sentencia->fetch())
				{
					$doctor = new Odontologo();
					$doctor->initClassDatosCompletos($idPersona, $idPerfil, $idOdontologo, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $especialidad,$odontologoHabilitado);
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
	public function habilitarDesabilitarOdontologo(Odontologo $doctor)
	{
		$conexion = new MySqlCon();
		$idOdontologo = $doctor->idOdontologo;
		$habilitado = $doctor->odontologoHabilitado;
		
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE odontologo SET ODONTOLOGO_HABILITADO = ? WHERE ID_ODONTOLOGO = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('ii',$habilitado,$idOdontologo);
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
					$doctor->initClassOdontologo($idOdontologo,$idPersona,$especialidad,$odontologoHabilitado);
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
	public function buscarOdontologoPorNombreApellido($nombre, $appPaterno)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT od.ID_ODONTOLOGO, od.ID_PERSONA, pe.ID_PERFIL, od.ESPECIALIDAD, od.ODONTOLOGO_HABILITADO, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO, pe.APELLIDO_MATERNO, pe.FECHA_NAC FROM odontologo od, persona pe WHERE pe.NOMBRE LIKE ? AND pe.APELLIDO_PATERNO LIKE ? AND od.ID_PERSONA = pe.ID_PERSONA";
			$sentencia=$conexion->prepare($this->SqlQuery);
		   	$nombreParam = "%".$nombre."%";
		   	$appPaternoParam = "%".$appPaterno."%";
		   	$sentencia->bind_param('ss',$nombreParam,$appPaternoParam);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idOdontologo, $idPersona, $idPerfil, $especialidad, $habilitado, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$odontologo = new Odontologo();
					$odontologo->initClassDatosCompletos($idPersona, $idPerfil, $idOdontologo, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento, $especialidad,$habilitado);
        			$this->datos[$indice] = $odontologo;
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
	public function buscarOdontologoPorRut($rut)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT od.ID_ODONTOLOGO, od.ID_PERSONA, pe.ID_PERFIL, od.ESPECIALIDAD, od.ODONTOLOGO_HABILITADO, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO, pe.APELLIDO_MATERNO, pe.FECHA_NAC FROM odontologo od, persona pe WHERE od.ID_PERSONA = pe.ID_PERSONA AND pe.RUT=?";
		    $sentencia = $conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$rut);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idOdontologo, $idPersona, $idPerfil, $especialidad, $habilitado, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$odontologo = new Odontologo();
					$odontologo->initClassDatosCompletos($idPersona, $idPerfil, $idOdontologo, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento, $especialidad,$habilitado);
        			$this->datos[$indice] = $odontologo;
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
 	public function listarOdontologoIdNombre()
 	{
 		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT od.id_odontologo, per.nombre, per.APELLIDO_PATERNO FROM odontologo od, persona per WHERE od.id_persona = per.id_persona";
			$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $nomPersona, $appPersona);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$datosPersona["idOdontologo"] = $idPersona;
					$datosPersona["nomPersona"] = $nomPersona;
					$datosPersona["appPersona"] = $appPersona;
        			$this->datos[$indice] = $datosPersona;
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