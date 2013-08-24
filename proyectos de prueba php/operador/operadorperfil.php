<?php
require_once '../conexion/MySqlCon.php';
class Oper_perfil{
    
    //variables
    private $SqlQuery;
    private $datos;
    
    //funcion seleccionar perfiles
    function  Select_perfiles(){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT * FROM  `perfil` LIMIT 0,3';
        $sentencia=$conexion->prepare($this->SqlQuery);
        if($sentencia->execute()){
        $sentencia->bind_result($id_perfil,$nom_perfil);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $id_perfil;
        $this->datos[$indice][1] = $nom_perfil;
        $indice++;
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error al listar perfiles");
        }
        return $this->datos;
    }
}

?>