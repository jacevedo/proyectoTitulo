<?php
require_once '../bdmysql/MySqlCon.php';
require_once '../pojos/datoscontacto.php';

class ControladoraDatosContacto
{
	private $SqlQuery;
	private $datos;

	function insertarDatosContacto(DatosContactos $contacto)
	{
		$conexion = new MySqlCon();
		$idPersona = $contacto->idPersona;
		$idComuna = $contacto->idComuna;
		$fonoFijo = $contacto->fonoFijo;
		$fonoCelular = $contacto->fonoCelular;
		$direccion = $contacto->direccion;
		$mail = $contacto->mail;
		$fechaIngreso = $contacto->fechaIngreso;

		try
		{
			$this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO datosdecontacto(ID_PERSONA, ID_COMUNA, FONO_FIJO, FONO_CELULAR, DIRECCION, MAIL, F_INGRESO) VALUES(?,?,?,?,?,?,?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('iisssss',$idPersona, $idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return "datos Insertados Correctamente";
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
			throw new $e("Error al insertar datos de contacto.");
		}
	}

	function modificarDatosContacto(DatosContactos $contacto)
	{
		$conexion = new MySqlCon();
		$idPersona = $contacto->idPersona;
		$idComuna = $contacto->idComuna;
		$fonoFijo = $contacto->fonoFijo;
		$fonoCelular = $contacto->fonoCelular;
		$direccion = $contacto->direccion;
		$mail = $contacto->mail;
		$fechaIngreso = $contacto->fechaIngreso;

		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery="UPDATE datosdecontacto SET ID_COMUNA = ?, FONO_FIJO = ?, FONO_CELULAR = ?, DIRECCION = ?, MAIL = ?, F_INGRESO = ? WHERE ID_PERSONA = ?";
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param("isssssi",$idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso, $idPersona);
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
	        	return "Error";
	        }
        }
    	catch(Exception $e)
    	{
         return "Excepcion";
         throw new $e("Error al modificar datos de contacto.");
        }
	}

	function buscarPorPersona($idPersonaViene)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM datosdecontacto WHERE ID_PERSONA = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("i",$idPersonaViene);
			if($sentencia->execute())
			{
				$sentencia->bind_result($idPersona, $idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso);
				if($sentencia->fetch())
	        	{
	        		$contacto = new DatosContactos();
					$contacto->initClass($idPersona, $idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso);
	        		$this->datos = $contacto;
	      		}
	      		else
	      		{
	      			//echo("ERROR");
	      			$contacto = new DatosContactos();
					$contacto->initClass(0, 0, null, null, null, null, null);
	      			$this->datos = $contacto;
	      		}	
			}
			else
			{
				$contacto = new DatosContactos();
				$contacto->initClass(0, 0, null, null, null, null, null);
      			$this->datos = $contacto;
			}
        	

       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al buscar datos contacto.");
        }
        return $this->datos;
	}

	public function listarDatosContacto()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT pe.NOMBRE, pe.APELLIDO_PATERNO, pe.APELLIDO_MATERNO, pe.RUT, pe.DV, da.ID_PERSONA, ".
							  " da.ID_COMUNA,da.FONO_FIJO,da.FONO_CELULAR,da.DIRECCION,da.MAIL,da.F_INGRESO,co.NOM_COMUNA ".
							  " FROM datosdecontacto da, persona pe, comuna co ".
							  " WHERE da.ID_PERSONA = pe.ID_PERSONA AND co.ID_COMUNA = da.ID_COMUNA";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("i",$idPersonaViene);
			if($sentencia->execute())
			{
				$sentencia->bind_result($nombre, $appPaterno, $appMaterno, $rut, $dv, $idPersona, $idComuna, $fonoFijo, $fonoCelular,
										 $direccion, $mail, $fechaIngreso, $nomComuna);
				$index=0;
				while($sentencia->fetch())
	        	{
	        		$arreglo["nombre"] = $nombre;
	        		$arreglo["apellidoPaterno"] = $appPaterno;
	        		$arreglo["apellidoMaterno"] = $appMaterno;
	        		$arreglo["rut"] = $rut;
	        		$arreglo["dv"] = $dv;
	        		$arreglo["idPersona"] = $idPersona;
	        		$arreglo["idComuna"] = $idComuna;
	        		$arreglo["fonoFijo"] = $fonoFijo;
	        		$arreglo["fonoCelular"] = $fonoCelular;
	        		$arreglo["direccion"] = $direccion;
	        		$arreglo["mail"] = $mail;
	        		$arreglo["fechaIngreso"] = $fechaIngreso;
	        		$arreglo["nomComuna"] = $nomComuna;

	        		$this->datos[$index] = $arreglo;
	        		$index++;
	      		}
			}
			else
			{
				$contacto = new DatosContactos();
				$contacto->initClass(0, 0, null, null, null, null, null);
      			$this->datos = $contacto;
			}
        	

       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al buscar datos contacto.");
        }
        return $this->datos;
	}



}
?>