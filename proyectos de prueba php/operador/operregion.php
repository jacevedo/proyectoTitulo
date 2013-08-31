<?php
require_once '../conexion/MySqlCon.php';
class oper_region{
    
    //variables
    private $SqlQuery;
    private $datos;
    
    //funcion seleccionar regiones
    function  Select_Region(){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT * FROM `region` LIMIT 0,15';
        $sentencia=$conexion->prepare($this->SqlQuery);
        if($sentencia->execute()){
        $sentencia->bind_result($idregion,$nombre);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $idregion;
        $this->datos[$indice][1] = $nombre;
        $indice++;
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error al listar regiones");
        }
        return $this->datos;
    }
}

?>