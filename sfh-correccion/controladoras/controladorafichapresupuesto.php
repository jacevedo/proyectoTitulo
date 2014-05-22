<?php 
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/fichadental.php';
require_once '../pojos/presupuesto.php';


class ControladoraFichaPresupuesto
{
	
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
	        $sentencia->bind_param('iis',$idFicha,$ValorTotal,$fechaIngreso);
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
		$fechaPresupuesto = $presupuesto->fechaPresupuesto;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `presupuesto` SET `ID_FICHA` = ?, `VALORTOTAL` = ?, `FECHA_PRESUPUESTO` = ? WHERE `ID_PRESUPUESTO` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iisi',$idFicha,$valorTotal,$fechaPresupuesto,$idPresupuesto);
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
        		$sentencia->bind_result($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$presupuesto = new Presupuesto();
					$presupuesto->initClass($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto);
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
			$this->SqlQuery = "SELECT fi.ID_FICHA, fi.id_paciente, fi.id_odontologo, fi.fech_ingreso, fi.ANAMNESIS, fi.HABILITADO_FICHA, pa.id_persona as IDPERSONA, od.id_persona as idOdontologo,(select nombre from persona pe where pe.id_persona = IDPERSONA) as nomPersonas,(select nombre from persona pe where pe.id_persona = idOdontologo) as nomOdontologo, (select APELLIDO_PATERNO from persona pe where pe.id_persona = idOdontologo) as appOdontologo,(select APELLIDO_PATERNO from persona pe where pe.id_persona = IDPERSONA) as appPaciente from fichadental fi, paciente pa, odontologo od where fi.ID_ODONTOLOGO = od.ID_ODONTOLOGO and fi.id_paciente = pa.id_paciente and ID_FICHA=?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$idFicha);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis, $habilitado, $idPacientePersona, $idOdontologoPersona, $nomPaciente,$nomOdontologo,$appOdontologo,$appPaciente	);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$ficha = new FichaDental();
					if($habilitado == 0)
					{
						$habilitado = "desabilitado";
					}
					if ($habilitado==1)
					{
						$habilitado = "habilitado";
					}
					$ficha->initClassConNombres($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,$habilitado,$nomPaciente." ".$appPaciente,$nomOdontologo." " .$appOdontologo);
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
			$this->SqlQuery = "SELECT fi.ID_FICHA, fi.id_paciente, fi.id_odontologo, fi.fech_ingreso, fi.ANAMNESIS, fi.HABILITADO_FICHA, pa.id_persona as IDPERSONA, od.id_persona as idOdontologo,(select nombre from persona pe where pe.id_persona = IDPERSONA) as nomPersonas,(select nombre from persona pe where pe.id_persona = idOdontologo) as nomOdontologo, (select APELLIDO_PATERNO from persona pe where pe.id_persona = idOdontologo) as appOdontologo,(select APELLIDO_PATERNO from persona pe where pe.id_persona = IDPERSONA) as appPaciente from fichadental fi, paciente pa, odontologo od where fi.ID_ODONTOLOGO = od.ID_ODONTOLOGO and  fi.ID_PACIENTE=? and fi.id_paciente = pa.id_paciente";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$idPersona);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis, $habilitado, $idPacientePersona, $idOdontologoPersona, $nomPaciente,$nomOdontologo,$appOdontologo,$appPaciente	);					
				$indice=0;     
				while($sentencia->fetch())
				{

					$ficha = new FichaDental();
					if($habilitado == 0)
					{
						$habilitado = "desabilitado";
					}
					if ($habilitado==1)
					{
						$habilitado = "habilitado";
					}
					$ficha->initClassConNombres($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,$habilitado,$nomPaciente." ".$appPaciente,$nomOdontologo." " .$appOdontologo);
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
			$this->SqlQuery = "SELECT pe.*, fi.ID_PACIENTE FROM presupuesto pe, fichadental fi WHERE fi.ID_PACIENTE=? AND fi.ID_FICHA = pe.ID_FICHA ";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$idPersona);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto,$idPaciente);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$presupuesto = new Presupuesto();
					$presupuesto->initClassIdPersona($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto,$idPaciente);
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
        		$sentencia->bind_result($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$presupuesto = new Presupuesto();
					$presupuesto->initClass($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto);
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
	public function listarFichaNombres()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "Select fi.ID_FICHA, fi.id_paciente, fi.id_odontologo, fi.fech_ingreso, fi.ANAMNESIS, fi.HABILITADO_FICHA, pa.id_persona as IDPERSONA, od.id_persona as idOdontologo,(select nombre from persona pe where pe.id_persona = IDPERSONA) as nomPersonas,(select nombre from persona pe where pe.id_persona = idOdontologo) as nomOdontologo, (select APELLIDO_PATERNO from persona pe where pe.id_persona = idOdontologo) as appOdontologo,(select APELLIDO_PATERNO from persona pe where pe.id_persona = IDPERSONA) as appPaciente from fichadental fi, paciente pa, odontologo od where fi.ID_ODONTOLOGO = od.ID_ODONTOLOGO and fi.id_paciente = pa.id_paciente";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis, $habilitado, $idPacientePersona, $idOdontologoPersona, $nomPaciente,$nomOdontologo,$appOdontologo,$appPaciente	);					
				$indice=0;     
				while($sentencia->fetch())
				{
					if($habilitado == 0)
					{
						$habilitado = "desabilitado";
					}
					if ($habilitado==1)
					{
						$habilitado = "habilitado";
					}

					$ficha = new FichaDental();
					$ficha->initClassConNombres($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,$habilitado,$nomPaciente." ".$appPaciente,$nomOdontologo." " .$appOdontologo);
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
	function listaPersonaFicha()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "Select fi.ID_FICHA, pe.NOMBRE, pe.APELLIDO_PATERNO from fichadental fi, paciente pa, persona pe where fi.ID_PACIENTE = pa.ID_PACIENTE and pa.ID_PERSONA = pe.ID_PERSONA";
			$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFicha, $nomPersona, $appPersona);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$datosPersona["idFicha"] = $idFicha;
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
	function buscarPresupuestoIdFicha($idFichaPaciente)
	{

		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pe.* FROM presupuesto pe WHERE pe.ID_FICHA  = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i',$idFichaPaciente);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$presupuesto = new Presupuesto();
					$presupuesto->initClass($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto);
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
	
}
?>