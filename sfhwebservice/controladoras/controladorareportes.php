<?php
require_once '../pojos/reporte.php'; 
class ControladoraReportes
{
    function generarReportes()
	{

	}
	function listarReportes()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_REPORTE, ID_PERSONA as IDPERSONA, F_CREACION, (SELECT NOMBRE FROM persona pe WHERE pe.ID_PERSONA = IDPERSONA ) AS NOMBRE,(SELECT APELLIDO_PATERNO FROM persona pe WHERE pe.ID_PERSONA = IDPERSONA ) AS APELLIDO_PATERNO_PACIENTE,(SELECT APELLIDO_MATERNO FROM persona pe WHERE pe.ID_PERSONA  = IDPERSONA) AS APELLIDO_MATERNO_PACIENTE FROM reporte";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado, $nomPaciente, $appPaternoPaciente, 
								$appMaternoPaciente, $nomOdontologo, $appPaternoOdontologo, $appMaternoOdontologo);
				$indice=0;     
				while($sentencia->fetch())
				{
					$cita = new Cita();
					$cita->initClassDatosExtra($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado, $nomPaciente, $appPaternoPaciente, 
								$appMaternoPaciente, $nomOdontologo, $appPaternoOdontologo, $appMaternoOdontologo);
					if($estado!=3)
					{
						$this->datos[$indice] = $cita;	
					}
        			
        			
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
	function insertarReportes(Reporte $reporte)
	{
		$conexion = new MySqlCon();
		$idPersona = $reporte->idPersona;
		$fechaCreacion = $reporte->fechaCreacion;
		$tipoReporte = $reporte->tipoReporte;
		
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO reporte(ID_REPORTE, ID_PERSONA, F_CREACION, TIPO_REPORTE)VALUES(NULL, ?, ?, ?)';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iss',$idPersona, $fechaCreacion, $tipoReporte);
	      	if($sentencia->execute())
	      	{
	      		//$id = ;
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
         throw new $e("Error al Registrar el Reporte");
        }	
	}
}
?>