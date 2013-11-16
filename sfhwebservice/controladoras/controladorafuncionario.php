<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/funcionario.php';

class ControladoraFuncionario
{
	function crearFuncionario($idFuncionario,$idPersona,$puestoTrabajo)
	{

	}
	public function insertarFuncionario(Funcionario $funcionario)
	{
		$conexion = new MySqlCon();
	
		$idPersona = $funcionario->idPersona;
		$puestoTrabajo = $funcionario->puestoTrabajo;
		$funcionarioHabilitado = $funcionario->funcionarioHabilitado;
		
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `funcionario` (`ID_FUNCIONARIO`,`ID_PERSONA`,`PUESTO_DE_TRABAJO`,`FUNCIONARIO_HABILITADO`) VALUES (null, ?, ?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isi',$idPersona, $puestoTrabajo,$funcionarioHabilitado);
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
			throw new $e("Error al ingresar orden.");
		}
	}
	public function modificarFuncionario(Funcionario $funcionario)
	{
		$conexion = new MySqlCon();
		$idFuncionario = $funcionario->idFuncionario;
		$idPersona = $funcionario->idPersona;
		$puestoTrabajo = $funcionario->puestoTrabajo;
		
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `funcionario` SET `ID_PERSONA` = ?, `PUESTO_DE_TRABAJO` = ? WHERE `ID_FUNCIONARIO` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('isi',$idPersona,$puestoTrabajo,$idPaciente);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Funcionario Modificado";
			}
			else
			{
				$conexion->close();
	        	return "Error no se modifico el funcionario";
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Actualizar Usuarios");
        }

	}
	public function desabilitarFuncionario(Funcionario $funcionario)
	{
		$conexion = new MySqlCon();
		$idFuncionario = $funcionario->idFuncionario;
		$funcionarioHabilitado = $funcionario->funcionarioHabilitado;
		
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='UPDATE `funcionario` SET `FUNCIONARIO_HABILITADO` = ? WHERE `ID_FUNCIONARIO` = ?';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('ii',$funcionarioHabilitado,$idPaciente);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "Funcionario Desabilitado";
			}
			else
			{
				$conexion->close();
	        	return "Error, no se desabilito el funcionario";
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Actualizar Usuarios");
        }
	}

	//Posible metodo para mejorar busquedas (admin, asistente, etc)
	//public function buscarFuncioinarioPorCargo($cargo)
	//{
		
	//}
	
	public function buscarFuncionarioPorRut($rut)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT fu.ID_FUNCIONARIO, fu.ID_PERSONA, pe.ID_PERFIL, fu.PUESTO_DE_TRABAJO, fu.FUNCIONARIO_HABILITADO, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO, pe.APELLIDO_MATERNO, pe.FECHA_NAC
                         FROM funcionario fu, persona pe WHERE fu.ID_PERSONA = pe.ID_PERSONA AND pe.RUT= ?";                
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	 $sentencia->bind_param('i',$rut);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFuncionario, $idPersona, $idPerfil, $puestoTrabajo, $habilitado, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$funcionario = new Funcionario();
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

	public function buscarFuncionarioPorNombre($nombre, $appPaterno)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT fu.ID_FUNCIONARIO, fu.ID_PERSONA, pe.ID_PERFIL, fu.PUESTO_DE_TRABAJO, fu.FUNCIONARIO_HABILITADO, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO, pe.APELLIDO_MATERNO, pe.FECHA_NAC FROM funcionario fu, persona pe WHERE pe.NOMBRE LIKE ? AND pe.APELLIDO_PATERNO LIKE ? AND fu.ID_PERSONA = pe.ID_PERSONA";
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
					$funcionario = new Funcionario();
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
	public function buscarFuncionarioPorId($id)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `funcionario` WHERE `ID_FUNCIONARIO` = ?'";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	 $sentencia->bind_param('i',$id);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFuncionario,$idPersona,$puestoTrabajo,$funcionarioHabilitado);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$funcionario = new Funcionario();
					$funcionario->initClassFuncionario($idFuncionario,$idPersona,$puestoTrabajo,$funcionarioHabilitado);
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
	public function listarFuncionario()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `funcionario`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idFuncionario,$idPersona,$puestoTrabajo,$funcionarioHabilitado);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$funcionario = new Funcionario();
					$funcionario->initClassFuncionario($idFuncionario,$idPersona,$puestoTrabajo,$funcionarioHabilitado);
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
	public function listarFuncionarioHerencia()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = 'SELECT pe.ID_PERSONA, pe.ID_PERFIL, fun.ID_FUNCIONARIO, pe.RUT, pe.DV, pe.NOMBRE, pe.APELLIDO_PATERNO, pe.APELLIDO_MATERNO,'.
								' pe.FECHA_NAC, fun.PUESTO_DE_TRABAJO, fun.FUNCIONARIO_HABILITADO FROM funcionario fun, persona pe'.
								' WHERE fun.ID_PERSONA = pe.ID_PERSONA';
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $idFuncionario, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $puestoTrabajo, $funcionarioHabilitado);				
				$indice=0;     
				while($sentencia->fetch())
				{
					$funcionario = new Funcionario();
					$funcionario->initClassDatosCompletos($idPersona, $idPerfil, $idFuncionario, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $puestoTrabajo, $funcionarioHabilitado);
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
	public function eliminarFuncionario($idFuncionario)
 	{
 		$conexion = new MySqlCon();
		$this->datos ='';
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery="DELETE FROM funcionario WHERE ID_FUNCIONARIO=?";
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param("i",$idFuncionario);
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
         throw new $e("Error al eliminar Funcionario");
        }
 	}
}
?>