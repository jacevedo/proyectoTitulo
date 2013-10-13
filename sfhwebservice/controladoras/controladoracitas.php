<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/cita.php'; 
 class ControladoraCitas
{
	function ModificarCita(Cita $cita)
	{
		$conexion = new MySqlCon();
		$idCita = $cita->idCita;
		$idOdontologo = $cita->idOdontologo;
		$idPaciente = $cita->idPaciente;
		$horaInicio = $cita->horaInicio;
		$horaTermino = $cita->horaTermino;
		$fecha = $cita->fecha;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO  cita (ID_CITA, ID_ODONTOLOGO, ID_PACIENTE, HORA_DE_INICIO, HORA_DE_TERMINO, FECHA) VALUES (NULL, ?, ?, ?, ?, ?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iisss',$idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha);
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
	function ModificarCita($cita)
	{
		$idCita = $cita->idCita;
		$idOdontologo = $cita->idOdontologo;
		$idPaciente = $cita->idPaciente;
		$horaInicio = $cita->horaInicio;
		$horaTermino = $cita->horaTermino;
		$fecha = $cita->fecha;
	}
	function CancelarCita($cita)
	{

	}


}
?>