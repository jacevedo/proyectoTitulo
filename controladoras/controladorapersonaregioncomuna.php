<<<<<<< HEAD
<?php 
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/persona.php';
require_once '../pojos/region.php';
require_once '../pojos/comuna.php';

class ControladoraPersonaRegionComuna
{
	private $SqlQuery;
	private $datos;
	
	public function crearPersona()
	{

	}
	
	public function insertarPersona(Persona $persona)
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
	        $this->SqlQuery='INSERT INTO `persona` (`ID_PERSONA`,`ID_PERFIL`,`RUT`,`DV`,`NOMBRE`,`APELLIDO_PATERNO`,`APELLIDO_MATERNO`,`FECHA_NAC`) (null,?,?,?,?,?,?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iissssss',$idPersona,$idPerfil,$rut,$dv,$nombre,$apellidoP,$apellidoM,$fechaNac);
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
			throw new $e("Error al insertar persona.");
		}
	}

	public function modificarPersona(Persona $persona)
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
	        	$conexion->close();
				return "Ok";
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
	
	function deshabilitarPersona()
	{
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
			$this->SqlQuery = "SELECT * FROM `comuna`";
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
}
=======
<?php 
class ControladoraPersonaRegionComuna
{
	function CrearPersona()
	{

	}
	function ListarPersonas()
	{

	}
}
>>>>>>> 4f5aa118ab62e93b200f2ef3730a8376e8d6a757
?>