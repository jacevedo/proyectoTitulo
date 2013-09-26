<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/listaprecios.php';
require_once '../pojos/insumos.php';
require_once '../pojos/areainsumo.php';

class ControladoraListaPreciosDentales
{
	function listarPiesas()
	{

	}
	function listarPreciosNombre($nombre)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		$nombreAInsertar = "%".$nombre."%";
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_PRECIOS, COMENTARIO,VALOR_NETO	".
							  "FROM listaprecios ".
							  "WHERE COMENTARIO LIKE ?";

		   	$sentencia=$conexion->prepare($this->SqlQuery);
			$sentencia->bind_param('s',$nombreAInsertar);

        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($id,$comentario,$valorNeto);				
				$indice=0;     

				while($sentencia->fetch())
				{

					$precios = new ListaPrecios();
					$precios->initClass($id, $comentario, $valorNeto);
        			$this->datos[$indice] = $precios;
        			
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
	function listarPrecios()
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ID_PRECIOS, COMENTARIO, VALOR_NETO ".
								"FROM listaprecios";

		   	$sentencia=$conexion->prepare($this->SqlQuery);


        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($id,$comentario,$valorNeto);				
				$indice=0;     

				while($sentencia->fetch())
				{

					$precios = new ListaPrecios();
					$precios->initClass($id, $comentario, $valorNeto);
        			$this->datos[$indice] = $precios;
        			
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
	function modificarPrecios($precio)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		$idPrecio = $precio->idPrecios;
		$comentario = $precio->comentario;
		$valorNeto = $precio->valorNeto;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery="UPDATE listaprecios SET COMENTARIO = ?, VALOR_NETO = ?".
	        				" WHERE ID_PRECIOS = ?";
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param("sii",$comentario,$valorNeto,$idPrecio);
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
         throw new $e("Error al Registrar Usuarios");
        }
	}
	function crearPrecio($idPrecio, $comentario, $valorNeto)
	{

	}
	function insertarPrecio(ListaPrecios $precio)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		$comentario = $precio->comentario;
		$valorNeto = $precio->valorNeto;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery="INSERT INTO listaprecios (ID_PRECIOS,COMENTARIO, ".
	        				"VALOR_NETO) VALUES (null,  ?,  ?)";
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param("si",$comentario,$valorNeto);
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
	function eliminarPrecio($idPrecio)
	{
		$conexion = new MySqlCon();
		$this->datos ='';
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery="DELETE FROM listaprecios WHERE ID_PRECIOS = ?";
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param("i",$idPrecio);
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
			
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Registrar Usuarios");
        }
	}
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
			$this->SqlQuery = "INSERT INTO insumos(ID_INSUMO, ID_AREA_INSUMO, ID_GASTOS, NOMBRE_INSUMO, ".
				"CANTIDAD, DESCRIPCION_INSUMO, UNIDAD_DE_MEDIDA_INSUMO) values(null, ?, ?, ?, ?, ?, ?)";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("iisiss",$idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida);
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
			$this->SqlQuery = "UPDATE insumos SET ID_AREA_INSUMO = ?, ID_GASTOS = ?, NOMBRE_INSUMO = ?, ".
			"CANTIDAD = ?, DESCRIPCION_INSUMO = ?, UNIDAD_DE_MEDIDA_INSUMO = ? WHERE ID_INSUMO = ?";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("iisissi",$idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida, $idInsumos);
			if($sentencia->execute())
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
			$this->SqlQuery = "SELECT ID_INSUMO, ID_AREA_INSUMO, ID_GASTOS, NOMBRE_INSUMO, CANTIDAD, ".
			"DESCRIPCION_INSUMO, UNIDAD_DE_MEDIDA_INSUMO FROM insumos";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida);				
				$indice = 0;     

				while($sentencia->fetch())
				{
					$insumos = new Insumos();
					$insumos->initClass($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida);
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
			$this->SqlQuery = "SELECT ID_INSUMO, ID_AREA_INSUMO, ID_GASTOS, NOMBRE_INSUMO, CANTIDAD, ".
			"DESCRIPCION_INSUMO, UNIDAD_DE_MEDIDA_INSUMO FROM insumos WHERE ID_AREA_INSUMO = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$idArea);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida);				
				$indice = 0;     

				while($sentencia->fetch())
				{
					$insumos = new Insumos();
					$insumos->initClass($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida);
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
			$this->SqlQuery = "SELECT ID_INSUMO, ID_AREA_INSUMO, ID_GASTOS, NOMBRE_INSUMO, CANTIDAD, ".
			"DESCRIPCION_INSUMO, UNIDAD_DE_MEDIDA_INSUMO FROM insumos WHERE ID_GASTOS = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$gasto);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida);				
				$indice = 0;     

				while($sentencia->fetch())
				{
					$insumos = new Insumos();
					$insumos->initClass($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida);
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
			$this->SqlQuery = "SELECT ID_INSUMO, ID_AREA_INSUMO, ID_GASTOS, NOMBRE_INSUMO, CANTIDAD, ".
			"DESCRIPCION_INSUMO, UNIDAD_DE_MEDIDA_INSUMO FROM insumos WHERE NOMBRE_INSUMO LIKE ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$nombreParam = "%".$nombre."%";
		   	$sentencia->bind_param("s",$nombreParam);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida);				
				$indice = 0;     

				while($sentencia->fetch())
				{
					$insumos = new Insumos();
					$insumos->initClass($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, $cantidad, $descripcionInsumo, $unidadMedida);
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
				return false;
			}
		}
		catch(Exception $e)
		{
			return false;
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
			$this->SqlQuery = "UPDATE areainsumo SET NOMBRE_AREA = ?, DESCRIPCION_AREA = ? ".
			"WHERE ID_AREA_INSUMO = ?";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("ssi",$nombreArea, $descripcionArea, $idAreaInsumo);
			if($sentencia->execute())
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
		catch(Exception $e)
		{
			return false;
			throw new  $e("Error al modificar el área de insumo.");
		}
	}
	function eliminarAreaInsumo($id)
	{
		$conexion = new MySqlCon();
		$this->datos = '';

		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "DELETE FROM areainsumo WHERE ID_AREA_INSUMO = ?";
			$sentencia = $conexion->prepare($this->SqlQuery);
			$sentencia->bind_param("i", $id);
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
		catch(Exception $e)
		{
			return false;
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
			$this->SqlQuery = "SELECT ID_AREA_INSUMO, NOMBRE_AREA, DESCRIPCION_AREA FROM areainsumo";
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
}
?>