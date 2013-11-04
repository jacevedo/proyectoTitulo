<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/cita.php'; 
 class ControladoraCitas
{
	function listarCitas()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_CITA, ID_ODONTOLOGO AS IDODONTOLOGO, ID_PACIENTE AS IDPACIENTE, HORA_DE_INICIO, HORA_DE_TERMINO, FECHA, ESTADO, (SELECT NOMBRE FROM persona pe, odontologo od WHERE od.ID_PERSONA = pe.ID_PERSONA AND od.ID_ODONTOLOGO = IDODONTOLOGO ) AS NOMBRE_ODONTOLOGO, (SELECT APELLIDO_PATERNO FROM persona pe, odontologo od WHERE od.ID_PERSONA = pe.ID_PERSONA AND od.ID_ODONTOLOGO = IDODONTOLOGO ) AS APELLIDO_PATERNO_ODONTOLOGO, (SELECT APELLIDO_MATERNO FROM persona pe, odontologo od WHERE od.ID_PERSONA = pe.ID_PERSONA AND od.ID_ODONTOLOGO = IDODONTOLOGO ) AS APELLIDO_MATERNO_ODONTOLOGO, (SELECT NOMBRE FROM persona pe, paciente pa WHERE pa.ID_PERSONA = pe.ID_PERSONA AND pa.ID_PACIENTE = IDPACIENTE ) AS NOMBRE_PACIENTE,(SELECT APELLIDO_PATERNO FROM persona pe, paciente pa WHERE pa.ID_PERSONA = pe.ID_PERSONA AND pa.ID_PACIENTE = IDPACIENTE ) AS APELLIDO_PATERNO_PACIENTE,(SELECT APELLIDO_MATERNO FROM persona pe, paciente pa WHERE pa.ID_PERSONA = pe.ID_PERSONA AND pa.ID_PACIENTE = IDPACIENTE ) AS APELLIDO_MATERNO_PACIENTE FROM cita";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado, $nomPaciente, $appPaternoPaciente, 
								$appMaternoPaciente, $nomOdontologo, $appPaternoOdontologo, $appMaternoOdontologo);
				$indice = 0;
				while($sentencia->fetch())
				{
					$cita = new Cita();
					$cita->initClassDatosExtra($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado, $nomPaciente, $appPaternoPaciente, 
								$appMaternoPaciente, $nomOdontologo, $appPaternoOdontologo, $appMaternoOdontologo);
        			$this->datos[$indice] = $cita;
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

	function buscarCita($fecha, $horaInicio)
	{
		$conexion2 = new MySqlCon();
		$this->datos ='';
		$nuevaHoraInicio = $fecha." ".$horaInicio;
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM cita WHERE FECHA = ? AND HORA_DE_INICIO = ?";
		   	$sentencia=$conexion2->prepare($this->SqlQuery);
		   	$sentencia->bind_param("ss",$fecha,$nuevaHoraInicio);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado);
				$indice = 0;
				while($sentencia->fetch())
				{
					$cita = new Cita();
					$cita->initClass($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado);
        			if($estado == 0)
        			{
        				return 0;
        			}
        			$indice++;
				}
      		}
      		else
      		{
        		echo("hola, else");
      		}
       		$conexion2->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar pacientes");
        }
        return 1;
	}

	function insertarCita(Cita $cita)
	{
		$conexion = new MySqlCon();
		$idOdontologo = $cita->idOdontologo;
		$idPaciente = $cita->idPaciente;
		$horaInicio = $cita->horaInicio;
		$fecha = $cita->fecha;
		$estado = $cita->estado;
		$nuevaHoraInicio = $fecha." ".$horaInicio;
		$nuevaHoraTermino = $fecha." ".$horaInicio;

		if($this->buscarCita($fecha, $horaInicio))
		{
			try 
		   	{ 	 
		        $this->SqlQuery='';
		        $this->SqlQuery='INSERT INTO cita(ID_CITA, ID_ODONTOLOGO, ID_PACIENTE, HORA_DE_INICIO, HORA_DE_TERMINO, FECHA, ESTADO)VALUES(NULL, ?, ?, ?, ?, ?, ?)';
		        $sentencia=$conexion->prepare($this->SqlQuery);
		        $sentencia->bind_param('iisssi',$idOdontologo, $idPaciente, $nuevaHoraInicio, $nuevaHoraTermino, $fecha, $estado);
		      	if($sentencia->execute())
		      	{
		        	$conexion->close();
					return $sentencia->insert_id;
				}
				else
				{
					$conexion->close();
		        	return "-1, else";
		        }
	        }
	    	catch(Exception $e)
	    	{
	         return false;
	         throw new $e("Error al Registrar Odontologo");
	        }	
		}
		else
		{
			return "Ya existe la Cita";
		}
		
	}
	
	function modificarCita($cita)
	{
		$idCita = $cita->idCita;
		$idOdontologo = $cita->idOdontologo;
		$idPaciente = $cita->idPaciente;
		$horaInicio = $cita->horaInicio;
		$horaTermino = $cita->horaTermino;
		$fecha = $cita->fecha;
		$estado = $cita->estado;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE cita SET ID_ODONTOLOGO = ?, ID_PACIENTE = ?, HORA_DE_INICIO = ?, HORA_DE_TERMINO = ?, FECHA = ?, ESTADO = ? WHERE ID_CITA = ?;';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iisssii',$idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado, $idCita);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return $sentencia->insert_id;
			}
			else
			{
				$conexion->close();
	        	return "-1";
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Registrar Odontologo");
        }
	}
}
?>