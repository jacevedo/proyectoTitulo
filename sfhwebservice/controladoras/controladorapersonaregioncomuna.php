<?php 
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/persona.php';
require_once '../pojos/region.php';
require_once '../pojos/comuna.php';

class ControladoraPersonaRegionComuna
{
	private $SqlQuery;
	private $datos;
	
	function crearPersona()
	{

	}
	
	function insertarPersona(Persona $persona)
	{
		$conexion = new MySqlCon();
		$idPersona = $persona->idPersona;
		$idPerfil = $persona->idPerfil;
		$rut = $persona->rut;
		$dv = $persona->dv;
		$nombre = $persona->nombre;
		$apellidoP = $persona->apellidoPaterno;
		$apellidoM = $persona->apellidoMaterno;
		$fechaNac = $persona->fechaNacimiento;
		
		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO `persona` (`ID_PERSONA`,`ID_PERFIL`,`RUT`,`DV`,`NOMBRE`,`APELLIDO_PATERNO`,`APELLIDO_MATERNO`,`FECHA_NAC`) VALUES (null,?,?,?,?,?,?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iisssss',$idPerfil,$rut,$dv,$nombre,$apellidoP,$apellidoM,$fechaNac);
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
			throw new $e("Error al insertar persona.");
		}
	}

	function modificarPersona(Persona $persona)
	{
		$conexion = new MySqlCon();
		$idPersona = $persona->idPersona;
		$idPerfil = $persona->idPerfil;
		$rut = $persona->rut;
		$dv = $persona->dv;
		$nombre = $persona->nombre;
		$apellidoP = $persona->apellidoPaterno;
		$apellidoM = $persona->apellidoMaterno;
		$fechaNac = $persona->fechaNacimiento;

		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='UPDATE `persona` SET `ID_PERFIL`=?,`RUT`=?,`DV`=?,`NOMBRE`=?,`APELLIDO_PATERNO`=?,`APELLIDO_MATERNO`=?,`FECHA_NAC`=? WHERE `ID_PERSONA`=?;';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('issssssi',$idPerfil, $rut, $dv, $nombre, $apellidoP, $apellidoM, $fechaNac, $idPersona);
	      	if($sentencia->execute())
	      	{
	      		if($sentencia->affected_rows)
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
			else
			{
				$conexion->close();
	        	return "No se modificó persona.";
	        }
		}
		catch(Exception $e)
		{
			return false;
			throw new $e("Error al modificar persona");
		}
	}
	
	public function listarPersonas()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `persona`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$persona = new Persona();
					$persona->initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);
					$this->datos[$indice] = $persona;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar personas");
		}
		return $this->datos;
	}

	public function listarPersonaPorPerfil($perfil)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `persona` WHERE `ID_PERFIL` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i', $perfil);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$persona = new Persona();
					$persona->initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);
					$this->datos[$indice] = $persona;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar personas");
		}
		return $this->datos;
	}

	public function buscarPorRut($rutB, $dvB)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `persona` WHERE `RUT` = ? AND `DV` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('ss', $rutB, $dvB);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$persona = new Persona();
					$persona->initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);
					$this->datos[$indice] = $persona;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al buscar persona");
		}
		return $this->datos;
	}

	public function buscarPorRutUsuario($rutB)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `persona` WHERE `RUT` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('s', $rutB);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$persona = new Persona();
					$persona->initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);
					$this->datos = $persona;
					//$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al buscar persona");
		}
		return $this->datos;
	}

	public function buscarPorNombre($nombrePersona, $apellidoPersona)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM persona WHERE NOMBRE LIKE ? OR APELLIDO_PATERNO LIKE ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$nombreParam = "%".$nombrePersona."%";
		   	$appParam = "%".$apellidoPersona."%";
		   	$sentencia->bind_param('ss', $nombreParam , $appParam);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$persona = new Persona();
					$persona->initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);
					$this->datos[$indice] = $persona;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al buscar persona");
		}
		return $this->datos;
	}
	public function buscarPorId($id)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM persona WHERE ID_PERSONA = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i', $id);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$persona = new Persona();
					$persona->initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);
					$this->datos[$indice] = $persona;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al buscar persona");
		}
		return $this->datos;
	}
	
	public function listarRegion()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `region`";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idRegion, $nombreRegion, $numeroRegionRomano);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$region = new Region();
					$region->initClass($idRegion, $nombreRegion, $numeroRegionRomano);
					$this->datos[$indice] = $region;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar regiones.");
		}
		return $this->datos;
	}

	public function listarComuna()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM comuna";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idComuna, $idRegion, $nombreComuna);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$comuna = new Comuna();
					$comuna->initClass($idComuna, $idRegion, $nombreComuna);
					$this->datos[$indice] = $comuna;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar comunas");
		}
		return $this->datos;
	}

	public function listarComunaPorRegion($id)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `comuna` WHERE `ID_REGION` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i', $id);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idComuna, $idRegion, $nombreComuna);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$comuna = new Comuna();
					$comuna->initClass($idComuna, $idRegion, $nombreComuna);
					$this->datos[$indice] = $comuna;
					$indice++;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar comunas");
		}
		return $this->datos;
	}

		public function buscarComunaPorID($id)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM `comuna` WHERE `ID_COMUNA` = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param('i', $id);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idComuna, $idRegion, $nombreComuna);					
				while($sentencia->fetch())
				{
					$comuna = new Comuna();
					$comuna->initClass($idComuna, $idRegion, $nombreComuna);
					$this->datos = $comuna;
				}
      		}
       		$conexion->close();
		}
		catch(Exception $e)
		{
			throw new $e("Error al listar comunas");
		}
		return $this->datos;
	}
}
?>
