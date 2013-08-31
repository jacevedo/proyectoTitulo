<?php
require_once '../conexion/MySqlCon.php';
class oper_carrera{
    
    //variables
    private $SqlQuery;
    private $datos;
    
    //funcion seleccionar carreras
    function  Select_Carreras(){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT * FROM `region` ';
        $sentencia=$conexion->prepare($this->SqlQuery);
        if($sentencia->execute()){
        $sentencia->bind_result($idcarrera,$nombrecarrera);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $idcarrera;
        $this->datos[$indice][1] = $nombrecarrera;
        $indice++;
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error al listar carreras");
        }
        return $this->datos;
    }
}

?>