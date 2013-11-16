<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/tratamientodental.php';
require_once '../pojos/abono.php';

class ControladoraTratamientoAbono
{
	private $SqlQuery;
	private $datos;

	public function insertarTratamiento(TratamientoDental $tratamientoDental)
	{
		$conexion = new MySqlCon();
		$idTratamientoDental = $tratamientoDental->idTratamientoDental;
		$idFicha = $tratamientoDental->idFicha;
		$fechaCreacion = $tratamientoDental->fechaCreacion;
		$tratamiento = $tratamientoDental->tratamiento;
		$fechaSeguimiento = $tratamientoDental->fechaSeguimiento;
		$valorTotal = $tratamientoDental->valorTotal;
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `tratamientodental`(`ID_TRATAMIENTO_DENTAL`,`ID_FICHA`,`FECH_CREACION`,`TRATAMIENTO`,`FECHA_SEGUIMIENTO`,`VALOR_TOTAL`) VALUES (null,?,?,?,?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isssi', $idFicha, $fechaCreacion, $tratamiento, $fechaSeguimiento, $valorTotal);
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
			throw new $e("Error al insertar tratamiento.");
		}
	}

	public function instertarAbono(Abono $abono)
	{
		$conexion = new MySqlCon();
		$idAbono = $abono->idAbono;
		$idTratamientoDental = $abono->idTratamientoDental;
		$fechaAbono = $abono->fechaAbono;
		$monto = $abono->monto;
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `abono`(`ID_ABONO`,`ID_TRATAMIENTO_DENTAL`,`FECHA_DE_ABONO`,`MONTO`) VALUES (null,?,?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isi', $idTratamientoDental, $fechaAbono, $monto);
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
			throw new $e("Error al insertar abono.");
		}
	}

	public function modificarTratamiento(TratamientoDental $tratamientoDental)
	{
		$conexion = new MySqlCon();
		$idTratamientoDental = $tratamientoDental->idTratamientoDental;
		$idFicha = $tratamientoDental->idFicha;
		$fechaCreacion = $tratamientoDental->fechaCreacion;
		$tratamiento = $tratamientoDental->tratamiento;
		$fechaSeguimiento = $tratamientoDental->fechaSeguimiento;
		$valorTotal = $tratamientoDental->valorTotal;

		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='UPDATE `tratamientodental` SET `ID_FICHA`=?,`FECH_CREACION`=?,`TRATAMIENTO`=?,`FECHA_SEGUIMIENTO`=?,`VALOR_TOTAL`=? WHERE `ID_TRATAMIENTO_DENTAL` = ?;';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isssii',$idFicha, $fechaCreacion, $tratamiento, $fechaSeguimiento, $valorTotal, $idTratamientoDental);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Modificado";
			}
			else
			{
				$conexion->close();
	        	return "No Modificado";
	        }
		}
		catch(Exception $e)
		{
			return false;
			throw new $e("Error al modificar tratamiento");
		}
	}

	public function modificarAbono(Abono $abono)
	{
		$conexion = new MySqlCon();
		$idAbono = $abono->idAbono;
		$idTratamientoDental = $abono->idTratamientoDental;
		$fechaAbono = $abono->fechaAbono;
		$monto = $abono->monto;

		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='UPDATE `abono` SET `ID_TRATAMIENTO_DENTAL`=?,`FECHA_DE_ABONO`=?,`MONTO`=? WHERE `ID_ABONO`=?;';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isii',$idTratamientoDental, $fechaAbono, $monto, $idAbono);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Modificado";
			}
			else
			{
				$conexion->close();
	        	return "No Modificado";
	        }
		}
		catch(Exception $e)
		{
			return false;
			throw new $e("Error al modificar tratamiento");
		}
	}

	public function listarTratamiento()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `tratamientodental`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idTratamientoDental, $idFicha, $fechaCreacion, $tratamiento, $fechaSeguimiento, $valorTotal);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$tratamientoDental = new TratamientoDental();
					$tratamientoDental->initClass($idTratamientoDental, $idFicha, $fechaCreacion, $tratamiento, $fechaSeguimiento, $valorTotal);
					$this->datos[$indice] = $tratamientoDental;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar tratamientos.");
		}
		return $this->datos;
	}

	public function listarTratamientoPorFicha($ficha)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `tratamientodental` WHERE `ID_FICHA` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i", $ficha);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idTratamientoDental, $idFicha, $fechaCreacion, $tratamiento, $fechaSeguimiento, $valorTotal);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$tratamientoDental = new TratamientoDental();
					$tratamientoDental->initClass($idTratamientoDental, $idFicha, $fechaCreacion, $tratamiento, $fechaSeguimiento, $valorTotal);
					$this->datos[$indice] = $tratamientoDental;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar tratamientos.");
		}
		return $this->datos;
	}
	public function listarTratamientoPorFichaConTotalAbono($ficha)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_TRATAMIENTO_DENTAL as idTratamiento,ID_FICHA,FECH_CREACION,TRATAMIENTO,FECHA_SEGUIMIENTO,VALOR_TOTAL, (select SUM(MONTO)from abono where ID_TRATAMIENTO_DENTAL	 = idTratamiento) FROM tratamientodental WHERE ID_FICHA = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i", $ficha);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idTratamientoDental, $idFicha, $fechaCreacion, $tratamiento, $fechaSeguimiento, $valorTotal,$TotalAbono);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$tratamientoDental = new TratamientoDental();
					$tratamientoDental->initClassAbono($idTratamientoDental, $idFicha, $fechaCreacion, $tratamiento, $fechaSeguimiento, $valorTotal,$TotalAbono);
					$this->datos[$indice] = $tratamientoDental;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar tratamientos.");
		}
		return $this->datos;
	}

	public function listarAbonos()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `abono`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idAbono, $idTratamientoDental, $fechaAbono, $monto);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$abono = new Abono();
					$abono->initClass($idAbono, $idTratamientoDental, $fechaAbono, $monto);
					$this->datos[$indice] = $abono;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar abonos.");
		}
		return $this->datos;
	}

	public function listarAbonosPorTratamiento($tratamiento)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `abono` WHERE `ID_TRATAMIENTO_DENTAL` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i", $tratamiento);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idAbono, $idTratamientoDental, $fechaAbono, $monto);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$abono = new Abono();
					$abono->initClass($idAbono, $idTratamientoDental, $fechaAbono, $monto);
					$this->datos[$indice] = $abono;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar abonos.");
		}
		return $this->datos;
	}

	public function TotalAbono($idPaciente)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT a.* FROM abono a, tratamientodental d, fichadental f WHERE a.ID_TRATAMIENTO_DENTAL = d.ID_TRATAMIENTO_DENTAL AND d.ID_FICHA = f.ID_FICHA AND f.ID_PACIENTE =?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i", $tratamiento);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idAbono, $idTratamientoDental, $fechaAbono, $monto);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$abono = new Abono();
					$abono->initClass($idAbono, $idTratamientoDental, $fechaAbono, $monto);
					$this->datos[$indice] = $abono;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar total de abonos.");
		}
		return $this->datos;
	}
	public function eliminarAbono($idAbono)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "DELETE FROM abono WHERE ID_ABONO = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i", $idAbono);
        	if($sentencia->execute())
        	{
        		$conexion->close();
        		return "Eliminado";
      		}
      		else
      		{
       			$conexion->close();
       			return "Error";
       		}
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar total de abonos.");
		}
	}
	public function listrarTratamientoPersonas()
	{
		
	}
}
?>