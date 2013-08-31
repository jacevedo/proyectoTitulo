<<<<<<< HEAD
 HEAD
=======
>>>>>>> 1c3afec08499775f7cd7f0320a8dd63648bb08cd
<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/ordenlaboratorio.php';

class ControladoraOrdenLaboratorio
{
	private $SqlQuery;
	private $datos;

	function crearOrden(Orden $orden)
	{

	}

	public function insertarOrden(Orden $orden)
	{
		$conexion = new MySqlCon();
		$idOrdenLaboratorio = $orden->idOrdenLaboratorio;
		$clinica = $orden->clinica;
		$bd = $orden->bd;
		$bi = $orden->bi;
		$pd = $orden->pd;
		$pi = $orden->pi;
		$fechaEntrega = $orden->fechaEntrega;
		$horaEntrega = $orden->horaEntrega;
		$color = $orden->color;
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `ordendelaboratorio`(`ID_ORDEN_LABORATORIO`,`CLINICA`,`BD`,`BI`,`PD`,`PI`,`FECHA_ENTREGA`,`HORA_ENTREGA`,`COLOR`) VALUES (null,?,?,?,?,?,?,?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('issssssss',$idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color);
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
			throw new $e("Error al ingresar orden.");
		}
	}

	public function modificarOrden(Orden $orden)
	{
		$conexion = new MySqlCon();
		$idOrdenLaboratorio = $orden->idOrdenLaboratorio;
		$clinica = $orden->clinica;
		$bd = $orden->bd;
		$bi = $orden->bi;
		$pd = $orden->pd;
		$pi = $orden->pi;
		$fechaEntrega = $orden->fechaEntrega;
		$horaEntrega = $orden->horaEntrega;
		$color = $orden->color;
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='UPDATE `ordendelaboratorio` SET `CLINICA`=?,`BD`=?,`BI`=?,`PD`=?,`PI`=?,`FECHA_ENTREGA`=?,`HORA_ENTREGA`=?,`COLOR`=? WHERE `ID_ORDEN_LABORATORIO`=?;';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('ssssssssi',$clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color, $idOrdenLaboratorio);
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

	function modificarEstadoOrden(Orden $orden)
	{
		
	}

	public function listarOrdenes()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `ordendelaboratorio`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$orden = new OrdenLaboratorio();
					$orden->initClass($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color);
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
        		$sentencia->bind_result($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$orden = new OrdenLaboratorio();
					$orden->initClass($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color);
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
        		$sentencia->bind_result($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$orden = new OrdenLaboratorio();
					$orden->initClass($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color);
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
        		$sentencia->bind_result($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$orden = new OrdenLaboratorio();
					$orden->initClass($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color);
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
<<<<<<< HEAD
?>
=======
?>
>>>>>>> 1c3afec08499775f7cd7f0320a8dd63648bb08cd
