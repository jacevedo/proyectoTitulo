<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/paciente.php';
require_once '../pojos/persona.php';
require_once '../pojos/tratamientodental.php';

class ControladoraPaciente
{
	private $SqlQuery;
	private $datos;

	
	public function insertarPaciente(Paciente $paciente)
	{
		$conexion = new MySqlCon();
		$idPersona = $paciente->idPersona;
		$fechaIngreso = $paciente->fechaIngreso;
		$habilitado = $paciente->habilitadoPaciente;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `paciente` (`ID_PACIENTE` ,`ID_PERSONA` ,`FECHA_INGRESO`,`HABILITADO_PACIENTE`) VALUES (null,  ?,  ?, 1);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('is',$idPersona,$fechaIngreso);
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
         throw new $e("Error al Registrar Usuarios");
        }
	}
	public function listarPacientesPersona()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pe.ID_PERSONA, pe.ID_PERFIL, pa.ID_PACIENTE, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO,".
								" pe.APELLIDO_MATERNO, pe.FECHA_NAC, pa.FECHA_INGRESO, pa.HABILITADO_PACIENTE FROM paciente pa, persona pe ".
								"WHERE pa.ID_PERSONA = pe.ID_PERSONA";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $idPaciente, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $fechaIngreso, $habilitadoPaciente);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$paciente = new Paciente();
					$paciente->initClassDatosCompletos($idPersona, $idPerfil, $idPaciente, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $fechaIngreso, $habilitadoPaciente);
        			$this->datos[$indice] = $paciente;
        			
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
	public function listarPacientes()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `paciente`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPaciente,$idPersona,$fechaIngreso,$habilitadoPaciente);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$paciente = new Paciente();
					$paciente->initClassPaciente($idPaciente,$idPersona,$fechaIngreso,$habilitadoPaciente);
        			$this->datos[$indice] = $paciente;
        			
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
    public function buscarPacientePorRut($rut)
    {
    	$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pa.ID_PACIENTE, pa.ID_PERSONA, pe.ID_PERFIL, pa.FECHA_INGRESO, pa.HABILITADO_PACIENTE, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO, pe.APELLIDO_MATERNO, pe.FECHA_NAC
                         FROM paciente pa, persona pe WHERE pa.ID_PERSONA = pe.ID_PERSONA AND pe.RUT= ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	 $sentencia->bind_param('i',$rut);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPaciente, $idPersona, $idPerfil, $fechaIngreso, $habilitado, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$paciente = new Paciente();
					$paciente->initClassDatosCompletos($idPersona, $idPerfil, $idPaciente, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento, $fechaIngreso, $habilitado);
        			$this->datos[$indice] = $paciente;
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

	public function modificarPacientes(Paciente $pacientes)
	{
		$conexion = new MySqlCon();
		$idPersona = $pacientes->idPersona;
		$fechaIngreso = $pacientes->fechaIngreso;
		$idPaciente = $pacientes->idPaciente;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `paciente` SET `ID_PERSONA` = ?, `FECHA_INGRESO` = ? WHERE `ID_PACIENTE` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isi',$idPersona,$fechaIngreso,$idPaciente);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Modificado";
			}
			else
			{
				$conexion->close();
	        	return "no modifique";
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Actualizar Usuarios");
        }
	}
	public function habilitarDesabilitarPaciente(Paciente $paciente)
	{
		$conexion = new MySqlCon();
		$idPaciente = $paciente->idPaciente;
		$habilitado = $paciente->habilitadoPaciente;
		
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE paciente SET HABILITADO_PACIENTE = ? WHERE ID_PACIENTE = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('ii',$habilitado,$idPaciente);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Modificado";
			}
			else
			{
				$conexion->close();
	        	return "no modifique";
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Actualizar Usuarios");
        }
	}
	public function buscarPacientePorNombre($nombre, $apellido)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pa.ID_PACIENTE, pa.ID_PERSONA, pe.ID_PERFIL, pa.FECHA_INGRESO, pa.HABILITADO_PACIENTE, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO, pe.APELLIDO_MATERNO, pe.FECHA_NAC FROM paciente pa, persona pe  WHERE pe.NOMBRE LIKE ? AND pe.APELLIDO_PATERNO LIKE ? AND pa.ID_PERSONA = pe.ID_PERSONA";
			$sentencia=$conexion->prepare($this->SqlQuery);
		   	$nombreParam = "%".$nombre."%";
		   	$appPaternoParam = "%".$appPaterno."%";
		   	$sentencia->bind_param('ss',$nombreParam,$appPaternoParam);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFuncionario, $idPersona, $idPerfil, $puestoTrabajo, $habilitado, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$funcionario = new Paciente();
					$funcionario->initClassDatosCompletos($idPersona, $idPerfil, $idFuncionario, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento, $puestoTrabajo, $habilitado);
        			$this->datos[$indice] = $funcionario;
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
	public function listarPacientesNomID()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pa.id_paciente, per.nombre, per.APELLIDO_PATERNO FROM paciente pa, persona per WHERE pa.id_persona = per.id_persona";
			$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $nomPersona, $appPersona);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$datosPersona["idPaciente"] = $idPersona;
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
	public function eliminarPaciente($idPaciente)
 	{
 		$conexion = new MySqlCon();
		$this->datos ='';
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery="DELETE FROM paciente WHERE ID_PACIENTE=?";
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param("i",$idPaciente);
	      	if($sentencia->execute())
	      	{
	      		if($sentencia->affected_rows)
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
			else
			{
				$conexion->close();
	        	return false;
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al eliminar Paciente");
        }
 	}
 	public function personasConPresupesto($canPersonas)
 	{
 		$limitInferior = 0;
 		$limitSuperior = 0;
 		if($canPersonas==1)
 		{
 			$limitInferior = 0;
 			$limitSuperior = 10;	
 		}
 		else
 		{
 			$limitSuperior = $canPersonas * 10;
 			$limitInferior = $limitSuperior-10;
 		}
 		
 		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pe.ID_PERSONA, pe.ID_PERFIL, pa.ID_PACIENTE, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO,".
								" pe.APELLIDO_MATERNO, pe.FECHA_NAC, pa.FECHA_INGRESO, pa.HABILITADO_PACIENTE FROM paciente pa, persona pe ".
								" WHERE pa.ID_PERSONA = pe.ID_PERSONA Limit ? , ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("ii",$limitInferior,$limitSuperior);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $idPaciente, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $fechaIngreso, $habilitadoPaciente);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$paciente = new Paciente();
					$paciente->initClassDatosCompletos($idPersona, $idPerfil, $idPaciente, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $fechaIngreso, $habilitadoPaciente);
        			$this->datos[$indice] = $paciente;
        			
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
 	public function personasConPresupestoLista($nomPersona)
 	{
 		$nomPersonaBusqueda = '%'.$nomPersona.'%';
 		
 		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pe.ID_PERSONA, pe.ID_PERFIL, pa.ID_PACIENTE, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO,".
								" pe.APELLIDO_MATERNO, pe.FECHA_NAC, pa.FECHA_INGRESO, pa.HABILITADO_PACIENTE FROM paciente pa, persona pe ".
								" WHERE pa.ID_PERSONA = pe.ID_PERSONA AND pe.NOMBRE LIKE ? OR pe.APELLIDO_PATERNO LIKE ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("ss",$nomPersonaBusqueda,$nomPersonaBusqueda);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $idPaciente, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $fechaIngreso, $habilitadoPaciente);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$paciente = new Paciente();
					$paciente->initClassDatosCompletos($idPersona, $idPerfil, $idPaciente, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $fechaIngreso, $habilitadoPaciente);
        			$this->datos[$indice] = $paciente;
        			
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
 	function buscarPresupuesto($canPersonas)
 	{
 		$personas = $this->personasConPresupesto($canPersonas);
 		$devolucion = array();
 		$contadorObjetos = 0;
 		foreach ($personas as $value)
 		{
 			$conexion = new MySqlCon();
			
 			try
			{
				$idPaciente = $value->idPaciente;
				$arregloTratamientos = array();
				$this->SqlQuery = '';
				$this->SqlQuery = "SELECT ta.*, fi.ANAMNESIS FROM tratamientodental ta, fichadental fi WHERE ta.ID_FICHA = fi.ID_FICHA AND fi.ID_PACIENTE = ? Limit 0 , 3";
			   	$sentencia=$conexion->prepare($this->SqlQuery);
			   	$sentencia->bind_param("i",$idPaciente);
	        	if($sentencia->execute())
	        	{
	        		$sentencia->bind_result($idTrataMiento, $idFicha, $fechaCreacion, $tratamientoDental, $fechaSeguimiento, $valorTotalConsulta,$amamnesis);				
					$indice=0;     
					while($sentencia->fetch())
					{
						$tratamiento = new TratamientoDental();
						$tratamiento->initClass($idTrataMiento, $idFicha, $fechaCreacion,$tratamientoDental,$fechaSeguimiento, $valorTotalConsulta);
	        			$arregloTratamientos[$indice] = $tratamiento;
	        			$indice++;
					}
					$arregloTemporal = array();
					$arregloTemporal["persona"] = $value;
					$arregloTemporal["tratamiento"] = $arregloTratamientos;
					$arregloTemporal["amamnesis"] = $amamnesis;
					$devolucion[$contadorObjetos] = $arregloTemporal;
					$contadorObjetos++;
	      		}

	       		$conexion->close();
       		}
	    	catch(Exception $e)
	    	{
	        	throw new $e("Error al listar pacientes");
	        }
 		}
 		return $devolucion;
			
 	} 	
 	function buscarPresupuestoPersona($nomPersona)
 	{
 		$personas = $this->personasConPresupestoLista($nomPersona);
 		$devolucion = array();
 		$contadorObjetos = 0;
 		foreach ($personas as $value)
 		{
 			$conexion = new MySqlCon();
			
 			try
			{
				$idPaciente = $value->idPaciente;
				$arregloTratamientos = array();
				$this->SqlQuery = '';
				$this->SqlQuery = "SELECT ta.*, fi.ANAMNESIS FROM tratamientodental ta, fichadental fi WHERE ta.ID_FICHA = fi.ID_FICHA AND fi.ID_PACIENTE = ? Limit 0 , 3";
			   	$sentencia=$conexion->prepare($this->SqlQuery);
			   	$sentencia->bind_param("i",$idPaciente);
	        	if($sentencia->execute())
	        	{
	        		$sentencia->bind_result($idTrataMiento, $idFicha, $fechaCreacion, $tratamientoDental, $fechaSeguimiento, $valorTotalConsulta,$amamnesis);				
					$indice=0;     
					while($sentencia->fetch())
					{
						$tratamiento = new TratamientoDental();
						$tratamiento->initClass($idTrataMiento, $idFicha, $fechaCreacion,$tratamientoDental,$fechaSeguimiento, $valorTotalConsulta);
	        			$arregloTratamientos[$indice] = $tratamiento;
	        			$indice++;
					}
					$arregloTemporal = array();
					$arregloTemporal["persona"] = $value;
					$arregloTemporal["tratamiento"] = $arregloTratamientos;
					$arregloTemporal["amamnesis"] = $amamnesis;
					$devolucion[$contadorObjetos] = $arregloTemporal;
					$contadorObjetos++;
	      		}

	       		$conexion->close();
       		}
	    	catch(Exception $e)
	    	{
	        	throw new $e("Error al listar pacientes");
	        }
 		}
 		return $devolucion;
			
 	} 	
}

?>