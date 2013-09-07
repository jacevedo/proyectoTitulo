<?php 
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/fichadental.php';
require_once '../pojos/presupuesto.php';


class ControladoraFichaPresupuesto
{
	function crearFicha($idFicha, $fechaCreacion, $idPaciente, $Anamnesis)
	{

	}
	function crearPresupuesto()
	{

	}
	public function insertarPresupuesto(Presupuesto $presupuesto)
	{
		$conexion = new MySqlCon();
		$idFicha = $presupuesto->idFicha;
		$ValorTotal = $presupuesto->valorTotal;
		$fechaIngreso = $presupuesto->fechaPresupuesto;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `presupuesto` (`ID_PRESUPUESTO` ,`ID_FICHA` ,`VALORTOTAL`,`FECHA_PRESUPUESTO`) VALUES (NULL ,  ?, ?, ?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iis',$idFicha,$ValorTotal);
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
	public function insertarFicha(FichaDental $ficha)
	{
		$conexion = new MySqlCon();
		$idPaciente = $ficha->idPaciente;
		$idOdontologo = $ficha->idOdontologo;
		$fechaIngreso = $ficha->fechaIngreso;
		$anamnesis = $ficha->anamnesis;
		$habilitada = $ficha->habilitada;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `fichadental` (`ID_FICHA`,`ID_PACIENTE`,`ID_ODONTOLOGO`,`FECH_INGRESO`,`ANAMNESIS`,`HABILITADO_FICHA`)
	         VALUES (NULL , ?,  ?, ?,  ?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iissi',$idPaciente,$idOdontologo,$fechaIngreso,$anamnesis,$habilitada);
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
	public function modificarPresupuesto(Presupuesto $presupuesto)
	{
		$conexion = new MySqlCon();
		$idPresupuesto = $presupuesto->idPresupuesto;
		$idFicha = $presupuesto->idFicha;
		$valorTotal = $presupuesto->valorTotal;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `presupuesto` SET `ID_FICHA` = ?, `VALORTOTAL` = ? WHERE `ID_PRESUPUESTO` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iii',$idFicha,$valorTotal,$idPresupuesto);
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
         throw new $e("Error al Actualizar Usuarios");
        }
	}
	public function modificarFicha(FichaDental $ficha)
	{

		$conexion = new MySqlCon();
		$idFicha = $ficha->idFicha;
		$idPaciente = $ficha->idPaciente;
		$idOdontologo = $ficha->idOdontologo;
		$fechaIngreso = $ficha->fechaIngreso;
		$anamnesis = $ficha->anamnesis;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `fichadental` SET `ID_PACIENTE` = ?, `ID_ODONTOLOGO` = ?, FECH_INGRESO=?, ANAMNESIS=? WHERE `ID_FICHA` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iissi',$idPaciente,$idOdontologo,$fechaIngreso,$anamnesis,$idFicha);
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
	         throw new $e("Error al Actualizar Usuarios");
        }
	}
	function desabilitarPresupuesto($presupuesto)
	{

	}
	public function buscarPresupuestoPorId($idPresupuesto)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM presupuesto WHERE ID_PRESUPUESTO=? ";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$idPresupuesto);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPresupuesto, $idFicha, $valorTotal);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$presupuesto = new Presupuesto();
					$presupuesto->initClass($idPresupuesto, $idFicha, $valorTotal);
        			$this->datos[$indice] = $presupuesto;
        			
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
	public function buscarFichaPorId($idFicha)
	{

		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM fichadental WHERE ID_FICHA=?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$idFicha);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,$habilitado);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$ficha = new FichaDental();
					$ficha->initClass($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,$habilitado);	
        			$this->datos[$indice] = $ficha;
        			
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
	public function buscarFichaPorIdPersona($idPersona)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM fichadental WHERE ID_PACIENTE=?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$idPersona);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,$habilitado);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$ficha = new FichaDental();
					$ficha->initClass($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,$habilitado);	
        			$this->datos[$indice] = $ficha;
        			
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
	public function buscarPresupuestoPorIdPersona($idPersona)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pe.* FROM presupuesto pe, fichadental fi WHERE fi.ID_PACIENTE=? AND fi.ID_FICHA = pe.ID_FICHA ";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$idPersona);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPresupuesto, $idFicha, $valorTotal);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$presupuesto = new Presupuesto();
					$presupuesto->initClass($idPresupuesto, $idFicha, $valorTotal);
        			$this->datos[$indice] = $presupuesto;
        			
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
	public function listarPresupuesto()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `presupuesto`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPresupuesto, $idFicha, $valorTotal);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$presupuesto = new Presupuesto();
					$presupuesto->initClass($idPresupuesto, $idFicha, $valorTotal);
        			$this->datos[$indice] = $presupuesto;
        			
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
	public function listarFicha()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `fichadental`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis, $habilitado);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$ficha = new FichaDental();
					$ficha->initClass($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis ,$habilitado);
        			$this->datos[$indice] = $ficha;
        			
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

	function desabilitarFicha($idFicha, $habilitado)
	{
		$conexion = new MySqlCon();
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `fichadental` SET `HABILITADO_FICHA` = ? WHERE `ID_FICHA` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('ii',$habilitado,$idFicha);
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
	         throw new $e("Error al Actualizar Usuarios");
        }
	}
	
}
?>