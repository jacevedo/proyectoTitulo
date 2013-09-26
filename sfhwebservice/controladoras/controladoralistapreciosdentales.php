<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/listaprecios.php';

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
								"FROM LISTAPRECIOS";

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
	        $this->SqlQuery="UPDATE LISTAPRECIOS SET COMENTARIO = ?, VALOR_NETO = ?".
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
	        $this->SqlQuery="INSERT INTO LISTAPRECIOS (ID_PRECIOS,COMENTARIO, ".
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
	        $this->SqlQuery="DELETE FROM LISTAPRECIOS WHERE ID_PRECIOS = ?";
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
	function listarInsumos()
	{

	}
	function modificarInsumo($insumo)
	{

	}
	function eliminarInsumos($insumo)
	{

	}
}
?>