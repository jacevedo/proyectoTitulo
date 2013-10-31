<?php
require_once '../pojos/session.php';
require_once '../bdmysql/MySqlCon.php'; 
require_once '../phpass/PasswordHash.php';

class ControladoraLogin
{
	private $SqlQuery;
	private $SqlQueryDos;
	private $datos;
	private $datosInternos;

	public function validarUsusarioPaciente($usuario, $pass)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT per.ID_PERSONA as IDPERSONA, per.RUT, pa.PASS, perm.COD_ACCESO,(SELECT ID_PACIENTE FROM paciente WHERE ID_PERSONA=IDPERSONA) FROM persona per, pass pa, permisos perm WHERE per.RUT = ? AND per.ID_PERSONA = pa.ID_PERSONA AND per.ID_PERFIL = perm.ID_PERFIL";

		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$usuario);
		   	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona,$usuarioBD,$passBD,$codAcceso,$idPaciente);	
	        	$hasher = new PasswordHash(8, false);	
	        	if($sentencia->fetch())
	        	{
	        		if($hasher->CheckPassword($pass, $passBD))
			        {
			        	$session = new Session();
						date_default_timezone_set('America/Argentina/Buenos_Aires');
			        	$hoy = date("Y-m-d H:i:s",time());
			        	$keyDesencriptada = $idPersona.$hoy;
			        	$keyHashada = $hasher->HashPassword($keyDesencriptada);
			        	$session->initClass(0, $idPersona,$keyHashada,$hoy,$hoy);
			        	$this->datos["idPersona"]=$idPersona;
			        	$this->datos["key"] = $this->insertSession($session);
			        	$this->datos["codAcceso"] = $codAcceso;
			        	$this->datos["idPaciente"] = $idPaciente;
			        }			
			        else
			        {
			        	$datos = "Usuario o Contrasena no correcta";
			        }
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
	public function validarUsusario($usuario, $pass)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT per.ID_PERSONA as IDPERSONA, per.RUT, pa.PASS, perm.COD_ACCESO FROM persona per, pass pa, permisos perm WHERE per.RUT = ? AND per.ID_PERSONA = pa.ID_PERSONA AND per.ID_PERFIL = perm.ID_PERFIL";

		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$usuario);
		   	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idPersona,$usuarioBD,$passBD,$codAcceso);	
	        	$hasher = new PasswordHash(8, false);	
	        	if($sentencia->fetch())
	        	{
	        		if($hasher->CheckPassword($pass, $passBD))
			        {
			        	$session = new Session();
						date_default_timezone_set('America/Argentina/Buenos_Aires');
			        	$hoy = date("Y-m-d H:i:s",time());
			        	$keyDesencriptada = $idPersona.$hoy;
			        	$keyHashada = $hasher->HashPassword($keyDesencriptada);
			        	$session->initClass(0, $idPersona,$keyHashada,$hoy,$hoy);
			        	$this->datos["idPersona"]=$idPersona;
			        	$this->datos["key"] = $this->insertSession($session);
			        	$this->datos["codAcceso"] = $codAcceso;
			        }			
			        else
			        {
			        	$datos = "Usuario o Contrasena no correcta";
			        }
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

	private function insertSession(Session $session)
	{
		$conexion = new MySqlCon();
		$idPersona = $session->idPersona;
		$keyHashada = $session->keySession;
		$horaFechaIngreso = $session->fechaHoraIngreso;
		$horaFechaCaducidad = $session->fechaHoraIngreso;
		$this->datosInternos = '';
		try
		{
			$this->SqlQueryDos='';
	        $this->SqlQueryDos="INSERT INTO session (ID_SESSION, ID_PERSONA, KEY_SESSION, FECHA_HORA_INGRESO, FECHA_HORA_CADUCIDAD) VALUES (NULL ,?,?,?,?)";
			$sentencia2=$conexion->prepare($this->SqlQueryDos);
	        $sentencia2->bind_param('isss', $idPersona,$keyHashada,$horaFechaIngreso,$horaFechaCaducidad);
	      	if($sentencia2->execute())
	      	{
	        	//$conexion->close();
				if($sentencia2->insert_id!=-1)
				{
					$this->datosInternos = $keyHashada;
				}
				else
				{
					$this->datosInternos = "Error en el inicio de session";
				}
			}
			else
			{
				//$conexion->close();
	        	$this->datosInternos = "Error en el inicio de session";
	        }

		}
		catch(Exception $e)
		{
			throw new $e("Error al listar ordenes");
		}
		return $this->datosInternos;
	}
}
?>