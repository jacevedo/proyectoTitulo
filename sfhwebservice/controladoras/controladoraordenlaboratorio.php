<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/ordenlaboratorio.php';

class ControladoraOrdenLaboratorio
{
	private $SqlQuery;
	private $datos;

	

	public function insertarOrden(OrdenLaboratorio $orden)
	{
		$conexion = new MySqlCon();
		$idOrdenLaboratorio = $orden->idOrdenLaboratorio;
		$idOdontologo = $orden->idOdontologo;
		$idPaciente = $orden->idPaciente;
		$numOrden = $orden->numOrden;
		$clinica = $orden->clinica;
		$bd = $orden->bd;
		$bi = $orden->bi;
		$pd = $orden->pd;
		$pi = $orden->pi;
		$fechaCreacion = $orden->fechaCreacion;
		$fechaEntrega = $orden->fechaEntrega;
		$horaEntrega = $orden->horaEntrega;
		$color = $orden->color;
		$estado = $orden->estado;
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery="INSERT INTO ordendelaboratorio (ID_ORDEN_LABORATORIO,ID_ODONTOLOGO,ID_PACIENTE,N_FICHA_LABORATORIO,CLINICA,BD,BI,PD,PI,FECHA_CREACION,FECHA_ENTREGA,HORA_ENTREGA,COLOR,ESTADO) VALUES (NULL,?,?,?,?,?,?,?,?,?,?,?,?,?);";
			$sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iiissssssssss', $idOdontologo,$idPaciente,$numOrden,$clinica,$bd,$bi,$pd,$pi,$fechaCreacion,$fechaEntrega,$horaEntrega,$color,$estado);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return $sentencia->insert_id;;
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

	public function modificarOrden(OrdenLaboratorio $orden)
	{
		$conexion = new MySqlCon();
		$idOrdenLaboratorio = $orden->idOrdenLaboratorio;
		$idOrdenLaboratorio = $orden->idOrdenLaboratorio;
		$idOdontologo = $orden->idOdontologo;
		$idPaciente = $orden->idPaciente;
		$numOrden = $orden->numOrden;
		$clinica = $orden->clinica;
		$bd = $orden->bd;
		$bi = $orden->bi;
		$pd = $orden->pd;
		$pi = $orden->pi;
		$fechaCreacion = $orden->fechaCreacion;
		$fechaEntrega = $orden->fechaEntrega;
		$horaEntrega = $orden->horaEntrega;
		$color = $orden->color;
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='UPDATE ordendelaboratorio SET ID_ODONTOLOGO=?,ID_PACIENTE=?,N_FICHA_LABORATORIO=?,	 CLINICA=?,BD=?,BI=?,PD=?,PI=?,FECHA_CREACION=? ,FECHA_ENTREGA=?,HORA_ENTREGA=?,COLOR=? WHERE ID_ORDEN_LABORATORIO=?;';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iiisssssssssi',$idOdontologo,$idPaciente,$numOrden, $clinica, $bd, $bi, $pd, $pi,$fechaCreacion,$fechaEntrega, $horaEntrega, $color, $idOrdenLaboratorio);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Ok";
			}
			else
			{
				$conexion->close();
	        	return "No se modificó la orden.";
	        }
		}
		catch(Exception $e)
		{
			return false;
			throw new $e("Error al modificar orden.");
		}
	}

	function modificarEstadoOrden(OrdenLaboratorio $orden)
	{
		$conexion = new MySqlCon();
		$idOrdenLaboratorio = $orden->idOrdenLaboratorio;
		$estado = $orden->estado;
		echo($idOrdenLaboratorio);
		echo($estado);
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='UPDATE `ordendelaboratorio` SET `ESTADO`=? WHERE `ID_ORDEN_LABORATORIO`=?;';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('si',$estado, $idOrdenLaboratorio);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Estado Modificado";
			}
			else
			{
				$conexion->close();
	        	return "No se modificó la orden.";
	        }
		}
		catch(Exception $e)
		{
			return false;
			throw new $e("Error al modificar orden.");
		}
	}

	public function listarOrdenes()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT orden.ID_ORDEN_LABORATORIO,orden.ID_ODONTOLOGO,orden.ID_PACIENTE,orden.N_FICHA_LABORATORIO,orden.CLINICA,orden.BD,orden.BI,orden.PD,orden.PI,orden.FECHA_CREACION,orden.FECHA_ENTREGA,orden.HORA_ENTREGA,orden.COLOR,orden.ESTADO, pa.ID_PERSONA as IDPERSONAPACIENTE, od.ID_PERSONA as IDPERSONAODONTOLOGO, (select nombre from persona where id_persona = IDPERSONAPACIENTE) as NOMPERSONAPACIENTE,(select APELLIDO_PATERNO from persona where id_persona = IDPERSONAPACIENTE) as AppPERSONAPACIENTE, (select nombre from persona where id_persona = IDPERSONAODONTOLOGO) as NOMPERSONAODONTOLOGO, (select APELLIDO_PATERNO from persona where id_persona = IDPERSONAODONTOLOGO) as AppPeRSONAODONTOLOGO FROM ordendelaboratorio orden, paciente pa, odontologo od WHERE orden.ID_PACIENTE = pa.ID_PACIENTE and orden.ID_ODONTOLOGO = od.ID_ODONTOLOGO";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idOrdenLaboratorio, $idOdontologo, $idPaciente,$numFicha, $clinica, $bd, $bi, $pd, $pi, $fechaCreacion, $fechaEntrega, $horaEntrega, $color, $estado, $idPersonaPaciente, $idPersonaOdontologo, $nomPersonaPaciente, $appPersonaPaciente , $nomPersonaOdontologo,$appPersonaOdontologo);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$orden = new OrdenLaboratorio();
					$orden->initClass($idOrdenLaboratorio, $idOdontologo,$idPaciente, $numFicha,$clinica, $bd, $bi, $pd, $pi,$fechaCreacion, $fechaEntrega, $horaEntrega, $color, 
						$estado,$nomPersonaPaciente ." ". $appPersonaPaciente,$nomPersonaOdontologo." ".$appPersonaOdontologo);
					$this->datos[$indice] = $orden;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar ordenes");
		}
		return $this->datos;
	}

	public function buscarOrdenPorId($id)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `ordendelaboratorio` WHERE `ID_ORDEN_LABORATORIO` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i', $id);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color, $estado);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$orden = new OrdenLaboratorio();
					$orden->initClass($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color, $estado);
					$this->datos[$indice] = $orden;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al buscar orden");
		}
		return $this->datos;
	}

	public function buscarOrdenPorClinica($nombreClinica)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `ordendelaboratorio` WHERE `CLINICA` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('s', $nombreClinica);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color, $estado);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$orden = new OrdenLaboratorio();
					$orden->initClass($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color, $estado);
					$this->datos[$indice] = $orden;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al buscar orden");
		}
		return $this->datos;
	}

	public function buscarOrdenPorFechaEntrega($fecha)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `ordendelaboratorio` WHERE `FECHA_ENTREGA` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('s', $fecha);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color, $estado);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$orden = new OrdenLaboratorio();
					$orden->initClass($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color, $estado);
					$this->datos[$indice] = $orden;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al buscar orden");
		}
		return $this->datos;
	}

}
?>
