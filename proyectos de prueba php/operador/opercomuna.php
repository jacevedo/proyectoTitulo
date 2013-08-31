<?php
require_once '../conexion/MySqlCon.php';
class Opercomuna{
    
    //variables
    private $SqlQuery;
    private $datos;
    
     //funcion seleccionar Comunas
    function  Select_Comunas($codreg){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT `ID_COMUNA` , `NOMBRE_COMUNA` FROM `comuna`WHERE ID_REGION = ?';
        $sentencia=$conexion->prepare($this->SqlQuery);
        $sentencia->bind_param("i",$codreg);
        if($sentencia->execute()){
        $sentencia->bind_result($idcomuna,$nombre);					
	$indice=0;
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $idcomuna;
        $this->datos[$indice][1] = $nombre;
        $indice++;
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error al listar comunas");
        }
        return $this->datos;
    }
}

?>