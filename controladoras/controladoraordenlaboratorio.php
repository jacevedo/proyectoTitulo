<<<<<<< HEAD
 HEAD
=======
>>>>>>> 1c3afec08499775f7cd7f0320a8dd63648bb08cd
<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/persona.php';

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
}
<<<<<<< HEAD
?>
=======
?>
>>>>>>> 1c3afec08499775f7cd7f0320a8dd63648bb08cd
