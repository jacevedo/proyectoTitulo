<?php

class ControladoraInsumos
{
	function insertarInsumos(Insumos $insumo)
	{
		$conexion = new MySqlCon();
		$this->datos = '';

		$idAreaInsumo = $insumo->idAreaInsumo;
		$idGastos = $insumo->idGastos;
		$nomInsumos = $insumo->nomInsumos;
		$cantidad = $insumo->cantidad;
		$descripcionInsumo = $insumo->descripcionInsumo;
		$unidadMedida = $insumo->unidadMedida;

		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "INSERT INTO insumos(ID_INSUMO, ID_AREA_INSUMO,".
							  " ID_GASTOS, NOMBRE_INSUMO, CANTIDAD,".
							  " DESCRIPCION_INSUMO, UNIDAD_DE_MEDIDA_INSUMO)".
							  " values(null, ?, ?, ?, ?, ?, ?)";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("iisiss",$idAreaInsumo, $idGastos, $nomInsumos, 
									$cantidad, $descripcionInsumo, $unidadMedida);
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
			throw new  $e("Error al ingresar el insumo.");
		}
	}
	function modificarInsumo(Insumos $insumo)
	{
		$conexion = new MySqlCon();
		$this->datos = '';

		$idInsumos = $insumo->idInsumos;
		$idAreaInsumo = $insumo->idAreaInsumo;
		$idGastos = $insumo->idGastos;
		$nomInsumos = $insumo->nomInsumos;
		$cantidad = $insumo->cantidad;
		$descripcionInsumo = $insumo->descripcionInsumo;
		$unidadMedida = $insumo->unidadMedida;

		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "UPDATE insumos SET ID_AREA_INSUMO = ?, ID_GASTOS = ?,".
							  " NOMBRE_INSUMO = ?,CANTIDAD = ?, ".
							  "DESCRIPCION_INSUMO = ?, UNIDAD_DE_MEDIDA_INSUMO = ?".
							  " WHERE ID_INSUMO = ?";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("iisissi",$idAreaInsumo, $idGastos, $nomInsumos, 
									$cantidad, $descripcionInsumo, $unidadMedida, 
									$idInsumos);
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
					return "error";
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
			return false;
			throw new  $e("Error al modificar el insumo.");
		}
	}
	function eliminarInsumos($id)
	{
		$conexion = new MySqlCon();
		$this->datos = '';

		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "DELETE FROM insumos WHERE ID_INSUMO = ?";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("i",$id);
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
	        	return "Error";
	        }
		}
		catch(Exception $e)
		{
			return false;
			throw new  $e("Error al eliminar el insumo.");
		}
	}
	function listarInsumos()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_INSUMO, ID_AREA_INSUMO as AREAINSUMO,".
							  " ID_GASTOS as GastosId,NOMBRE_INSUMO, CANTIDAD,".
							  " DESCRIPCION_INSUMO,UNIDAD_DE_MEDIDA_INSUMO,".
							  " (select NOMBRE_AREA from areainsumo where AREAINSUMO ".
							  "= ID_AREA_INSUMO),(select CONCEPTO_GASTO from gastos".
							  " where GastosId= ID_GASTOS) FROM insumos";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idInsumos, $idAreaInsumo, $idGastos, 
        								$nomInsumos, $cantidad, $descripcionInsumo, 
        								$unidadMedida,$nomArea,$nomConcepto);				
				$indice = 0;     

				while($sentencia->fetch())
				{
					$insumos = new Insumos();
					$insumos->initClassNombres($idInsumos, $idAreaInsumo, $idGastos, 
										$nomInsumos, $cantidad, $descripcionInsumo, 
										$unidadMedida,$nomArea,$nomConcepto);
					$this->datos[$indice] = $insumos;
        			$indice++;
				}
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar insumos");
        }
        return $this->datos;
	}
	function listarInsumosPorArea($idArea)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_INSUMO, ID_AREA_INSUMO as AREAINSUMO,".
							  " ID_GASTOS as GastosId ,NOMBRE_INSUMO, CANTIDAD,".
							  " DESCRIPCION_INSUMO, UNIDAD_DE_MEDIDA_INSUMO,".
							  " (select NOMBRE_AREA from areainsumo where".
							  " AREAINSUMO = ID_AREA_INSUMO),(select CONCEPTO_GASTO".
							  " from gastos where GastosId= ID_GASTOS) FROM insumos".
							  " WHERE ID_AREA_INSUMO = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$idArea);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idInsumos, $idAreaInsumo, $idGastos, 
        								$nomInsumos, $cantidad, $descripcionInsumo, 
        								$unidadMedida,$nomArea,$nomConcepto);				
				$indice = 0;     

				while($sentencia->fetch())
				{
					$insumos = new Insumos();
					$insumos->initClassNombres($idInsumos, $idAreaInsumo, $idGastos, 
										$nomInsumos, $cantidad, $descripcionInsumo, 
										$unidadMedida,$nomArea,$nomConcepto);
					$this->datos[$indice] = $insumos;
        			$indice++;
				}
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar insumos");
        }
        return $this->datos;
	}
	function listarInsumosPorGastos($gasto)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_INSUMO, ID_AREA_INSUMO as AREAINSUMO,".
							  " ID_GASTOS as GastosId, NOMBRE_INSUMO, CANTIDAD,".
							  " DESCRIPCION_INSUMO, UNIDAD_DE_MEDIDA_INSUMO,".
							  " (select NOMBRE_AREA from areainsumo where".
							  " AREAINSUMO = ID_AREA_INSUMO),(select CONCEPTO_GASTO".
							  " from gastos where GastosId= ID_GASTOS) FROM insumos WHERE".
							  " ID_GASTOS = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$gasto);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idInsumos, $idAreaInsumo, $idGastos, 
        								$nomInsumos, $cantidad, $descripcionInsumo, 
        								$unidadMedida,$nomArea,$nomConcepto);			
				$indice = 0;     

				while($sentencia->fetch())
				{
					$insumos = new Insumos();
					$insumos->initClassNombres($idInsumos, $idAreaInsumo, $idGastos, 
										$nomInsumos, $cantidad, $descripcionInsumo, 
										$unidadMedida,$nomArea,$nomConcepto);
					$this->datos[$indice] = $insumos;
        			$indice++;
				}
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar insumos");
        }
        return $this->datos;
	}
	function listarInsumosPorNombre($nombre)
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_INSUMO, ID_AREA_INSUMO as AREAINSUMO,".
							  " ID_GASTOS as GastosId, NOMBRE_INSUMO, CANTIDAD,".
							  " DESCRIPCION_INSUMO, UNIDAD_DE_MEDIDA_INSUMO,".
							  " (select NOMBRE_AREA from areainsumo where".
							  " AREAINSUMO = ID_AREA_INSUMO),(select CONCEPTO_GASTO".
							  " from gastos where GastosId= ID_GASTOS) FROM insumos WHERE".
							  " NOMBRE_INSUMO LIKE ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$nombreParam = "%".$nombre."%";
		   	$sentencia->bind_param("s",$nombreParam);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idInsumos, $idAreaInsumo, $idGastos, 
        								$nomInsumos, $cantidad, $descripcionInsumo, 
        								$unidadMedida,$nomArea,$nomConcepto);		
				$indice = 0;     

				while($sentencia->fetch())
				{
					$insumos = new Insumos();
					$insumos->initClassNombres($idInsumos, $idAreaInsumo, $idGastos,
										$nomInsumos, $cantidad, $descripcionInsumo, 
										$unidadMedida,$nomArea,$nomConcepto);
					$this->datos[$indice] = $insumos;
        			$indice++;
				}
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar insumos");
        }
        return $this->datos;
	}
	function insertarAreaInsumo(AreaInsumo $area)
	{
		$conexion = new MySqlCon();
		$this->datos = '';

		$nombreArea = $area->nombreArea;
		$descripcionArea = $area->descripcionArea;

		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "INSERT INTO areainsumo(ID_AREA_INSUMO, NOMBRE_AREA, ".
				"DESCRIPCION_AREA) VALUES(null, ?, ?)";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("ss",$nombreArea, $descripcionArea);
			if($sentencia->execute())
			{

				$conexion->close();
				return $sentencia->insert_id;
			}
			else
			{
				$conexion->close();
				return "error";
			}
		}
		catch(Exception $e)
		{
			return "Error";
			throw new  $e("Error al ingresar el área de insumo.");
		}
	}
	function modificarAreaInsumo(AreaInsumo $area)
	{
		$conexion = new MySqlCon();
		$this->datos = '';

		$idAreaInsumo = $area->idAreaInsumo;
		$nombreArea = $area->nombreArea;
		$descripcionArea = $area->descripcionArea;

		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "UPDATE areainsumo SET NOMBRE_AREA = ?,".
							  " DESCRIPCION_AREA = ? WHERE ID_AREA_INSUMO = ?";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("ssi",$nombreArea, $descripcionArea, $idAreaInsumo);
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
					return "Error";
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
			return false;
			throw new  $e("Error al modificar el área de insumo.");
		}
	}
	function eliminarAreaInsumo($idAreaInsumo)
	{
		$conexion = new MySqlCon();
		$this->datos = '';

		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "DELETE FROM areainsumo WHERE ID_AREA_INSUMO = ?";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("i", $idAreaInsumo);
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
					return "Error Eliminando";
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
			return "Error Exception";
			throw new  $e("Error al eliminar el área de insumo.");
		}
	}
	function listarAreaInsumos()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_AREA_INSUMO, NOMBRE_AREA, DESCRIPCION_AREA".
							  " FROM areainsumo";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idAreaInsumo, $nombreArea, $descripcionArea);				
				$indice = 0;     

				while($sentencia->fetch())
				{
					$areaInsumo = new AreaInsumo();
					$areaInsumo->initClass($idAreaInsumo, $nombreArea, $descripcionArea);
					$this->datos[$indice] = $areaInsumo;
        			$indice++;
				}
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar área insumos");
        }
        return $this->datos;
	}
	function listarAreaInsumoIdNombre()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_AREA_INSUMO, NOMBRE_AREA".
							  " FROM areainsumo";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idAreaInsumo, $nombreArea);				
				$indice = 0;     

				while($sentencia->fetch())
				{
					$arreglo["idAreaInsumo"] = $idAreaInsumo;
					$arreglo["nombreArea"] = $nombreArea;
					$this->datos[$indice] = $arreglo;
        			$indice++;
				}
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar área insumos");
        }
        return $this->datos;
	}
	function listaInsumoIdNombre()
	{
		$conexion = new MySqlCon();
		$this->datos = '';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_INSUMO,  NOMBRE_INSUMO".
							  " FROM insumos";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idInsumos, $nomInsumos);	
				$indice = 0;     

				while($sentencia->fetch())
				{
					$arreglo["idInsumos"]=$idInsumos;
					$arreglo["nomInsumos"]=$nomInsumos;
					$this->datos[$indice] = $arreglo;
        			$indice++;
				}
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar insumos");
        }
        return $this->datos;
	}
}
?>