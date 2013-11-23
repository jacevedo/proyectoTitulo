<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/reporte.php'; 
require_once '../pojos/cita.php'; 
require_once '../pojos/abono.php';
require_once '../pojos/gastos.php'; 
class ControladoraReportes
{
    function generarReportes()
	{

	}
	function gastosRangoFecha($fechaInicio, $fechaTermino)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_GASTOS, ID_PERSONA, CONCEPTO_GASTO, MONTO_GASTOS, DESCUENTO_GASTOS, FECHA_GASTO FROM gastos WHERE FECHA_GASTO >= ? AND FECHA_GASTO <=  ?;";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("ss",$fechaInicio, $fechaTermino);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idGastos, $idPersona, $conceptoGasto, $montoGastos, $descuentoGastos, $fecha);
				$indice=0;     
				while($sentencia->fetch())
				{
					$gastos = new Gastos();
					$gastos->initClass($idGastos,$idPersona,$conceptoGasto,$montoGastos,$descuentoGastos,"","",$fecha);
        			$this->datos[$indice]=$gastos;
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
	function abonoHistoriocoAntiguaNueva()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_ABONO, FECHA_DE_ABONO FROM abono ORDER BY FECHA_DE_ABONO;";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idAbono, $fecha);
				$indice=0;     
				while($sentencia->fetch())
				{
					$arreglo["idAbono"]=$idAbono;
					$arreglo["fecha"]=$fecha;
        			$this->datos[$indice]=$arreglo;
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
	function abonoHistoriocoNuevaAntigua()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT  ID_ABONO, FECHA_DE_ABONO FROM abono ORDER BY FECHA_DE_ABONO DESC";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idAbono, $fecha);
				$indice=0;     
				while($sentencia->fetch())
				{
					$arreglo["idAbono"]=$idAbono;
					$arreglo["fecha"]=$fecha;
        			$this->datos[$indice]=$arreglo;
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
	function abonoRangoFecha($fechaInicio, $fechaTermino)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_ABONO, ID_TRATAMIENTO_DENTAL, FECHA_DE_ABONO, MONTO FROM abono WHERE FECHA_DE_ABONO >= ? AND FECHA_DE_ABONO <=  ?;";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("ss",$fechaInicio, $fechaTermino);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idAbono, $idTratamientoDental, $fechaAbono, $monto);
				$indice=0;     
				while($sentencia->fetch())
				{
					$abono = new Abono();
					$abono->initClass($idAbono,$idTratamientoDental,$fechaAbono,$monto);		
        			$this->datos[$indice]=$abono;
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
	function citasHistoricasAntiguaNueva()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_CITA, FECHA FROM  cita ORDER BY  FECHA;";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idCita, $fecha);
				$indice=0;     
				while($sentencia->fetch())
				{
					$arreglo["idCita"]=$idCita;
					$arreglo["fecha"]=$fecha;
        			$this->datos[$indice]=$arreglo;
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
	function citasHistoricasNuevaAntigua()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_CITA, FECHA FROM cita ORDER BY FECHA DESC;";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idCita, $fecha);
				$indice=0;     
				while($sentencia->fetch())
				{
					$arreglo["idCita"]=$idCita;
					$arreglo["fecha"]=$fecha;
        			$this->datos[$indice]=$arreglo;
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
	function citasRangoFecha($fechaInicio, $fechaTermino)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_CITA, ID_ODONTOLOGO, ID_PACIENTE, HORA_DE_INICIO, HORA_DE_TERMINO, FECHA, ESTADO FROM cita WHERE FECHA >=  ? AND  FECHA <=  ?;";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("ss",$fechaInicio, $fechaTermino);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado);
				$indice=0;     
				while($sentencia->fetch())
				{
					$cita = new Cita();
					$cita->initclass($idCita, $idOdontologo, $idPaciente, $horaInicio, $fecha, $estado);		
        			$this->datos[$indice]=$cita;
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
        		$sentencia->bind_result($idReporte, $idPersona, $fechaCreacion, $nombre, $appPaterno);
				$indice=0;     
				while($sentencia->fetch())
				{
					$reporte = new Reporte();
					$reporte->initClassDatosPersona($idReporte, $idPersona, $fechaCreacion, $nombre, $appPaterno);
        			$this->datos[$indice] = $reporte;
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