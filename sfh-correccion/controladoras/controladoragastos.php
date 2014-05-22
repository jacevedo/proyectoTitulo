<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/gastos.php';
class ControladoraGastos
{
	
	function insertarGasto(Gastos $gasto)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		$idPersona = $gasto->idPersona;
		$concepto = $gasto->conceptoGasto;
		$montoGasto = $gasto->montoGastos;
		$descGasto = $gasto->descuentoGastos;
		$fechaGasto = $gasto->fechaGasto;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery="INSERT INTO gastos (ID_GASTOS,ID_PERSONA,CONCEPTO_GASTO,".
	        				"MONTO_GASTOS,DESCUENTO_GASTOS, FECHA_GASTO) VALUES (null,?,?,?,?,?)";
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param("isiis",$idPersona,$concepto,$montoGasto,$descGasto,$fechaGasto);
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
	function modificarGasto(Gastos $gasto)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		$idGasto = $gasto->idGastos;
		$idPersona = $gasto->idPersona;
		$concepto = $gasto->conceptoGasto;
		$montoGasto = $gasto->montoGastos;
		$descGasto = $gasto->descuentoGastos;
		$fechaGasto = $gasto->fechaGasto;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery="UPDATE gastos SET ID_PERSONA=?,CONCEPTO_GASTO=?,".
	        				"MONTO_GASTOS=?,DESCUENTO_GASTOS=?, FECHA_GASTO=?  WHERE ID_GASTOS=?";
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param("isiisi",$idPersona,$concepto,$montoGasto,
	        						$descGasto,$fechaGasto,$idGasto);
	      	if($sentencia->execute())
	      	{
	      		if($sentencia->affected_rows)
	      		{
		        	$conexion->close();
					return "modificado";
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
         throw new $e("Error al Registrar Usuarios");
        }
	}
	function eliminarGasto($idGasto)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery="DELETE FROM gastos WHERE ID_GASTOS=?";
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param("i",$idGasto);
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
         throw new $e("Error al Registrar Usuarios");
        }
	}
	function listarGastos()
	{
		
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ga.ID_GASTOS, ga.ID_PERSONA, ga.CONCEPTO_GASTO,".
							  " ga.MONTO_GASTOS, ga.DESCUENTO_GASTOS, ga.FECHA_GASTO , pe.NOMBRE, ".
							  " pe.APELLIDO_PATERNO  FROM gastos ga, persona pe" .
							  " WHERE ga.ID_PERSONA = pe.ID_PERSONA";

		   	$sentencia=$conexion->prepare($this->SqlQuery);
			
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($id,$idPersona,$concepto,$monto, $descuento, $fechaGasto,
        						$nombre,$app);				
				$indice=0;     

				while($sentencia->fetch())
				{

					$nomPersonaGasto = 
					$gastos = new Gastos();
					$gastos->initClass($id,$idPersona,$concepto,$monto,$descuento,
						$nombre,$app,$fechaGasto);
        			$this->datos[$indice] = $gastos;
        			
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
	function listarGastosIdPersona($idPersona)
	{
		
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ga.ID_GASTOS, ga.ID_PERSONA, ga.CONCEPTO_GASTO,".
							  " ga.MONTO_GASTOS, ga.DESCUENTO_GASTOS,ga.FECHA_GASTO, pe.NOMBRE, ".
							  " pe.APELLIDO_PATERNO  FROM gastos ga, persona pe" .
							  " WHERE ga.ID_PERSONA = pe.ID_PERSONA ".
							  " AND ga.ID_Persona = ?";

		   	$sentencia=$conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("i",$idPersona);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($id,$idPersona,$concepto,$monto, $descuento, $fechaGasto,
        						$nombre,$app);				
				$indice=0;     

				while($sentencia->fetch())
				{

					$nomPersonaGasto = 
					$gastos = new Gastos();
					$gastos->initClass($id,$idPersona,$concepto,$monto,$descuento,
						$nombre,$app, $fechaGasto);
        			$this->datos[$indice] = $gastos;
        			
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
	function listarGastoIdConcepto()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ga.ID_GASTOS, ga.CONCEPTO_GASTO ".
							  "  FROM gastos ga";

		   	$sentencia=$conexion->prepare($this->SqlQuery);
			
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($id,$concepto);				
				$indice=0;     

				while($sentencia->fetch())
				{

					$nomPersonaGasto = 
					$arreglo["idGasto"]=$id;
					$arreglo["concepto"]=$concepto;
					$this->datos[$indice] = $arreglo;
        			
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