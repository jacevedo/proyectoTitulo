<?php
require_once '../conexion/MySqlCon.php';
require_once '../modelobj/reporte.php';
require_once '../seguridad/code_encrypt.php';
class oper_Reportes{
    //variables
    private $SqlQuery;
    private $datos;
    
    //funcion seleccionar todos los reportes
    function  Select_TodReportes(){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT re.ID_REPORTE, usu.NOM_USUARIO,re.FECHA_HORA FROM `reporte` re,`usuario` usu WHERE re.ID_USUARIO = usu.ID_USUARIO LIMIT 0 , 30';
        $sentencia=$conexion->prepare($this->SqlQuery);
        if($sentencia->execute()){
        $sentencia->bind_result($idreporte,$nom_usuario,$fecha_hora);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $idreporte;
        $this->datos[$indice][1] = $nom_usuario;
        $this->datos[$indice][2] = $fecha_hora;
        $indice++;
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error al listar reportes");
        }
        return $this->datos;
    }
    
     //funcion seleccionar reporte por usuario
    function  Select_Reportes_usuario($id_user){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='
        SELECT re.ID_REPORTE, usu.NOM_USUARIO, re.FECHA_HORA FROM `reporte` re, usuario usu  WHERE usu.ID_USUARIO = re.ID_USUARIO AND re.ID_USUARIO =?  LIMIT 0,30';
        $sentencia=$conexion->prepare($this->SqlQuery);
          $sentencia->bind_param("i",$id_user);
        if($sentencia->execute()){
        $sentencia->bind_result($idreporte,$nom_usuario,$fecha_hora);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $idreporte;
        $this->datos[$indice][1] = $nom_usuario;
        $this->datos[$indice][2] = $fecha_hora;
        $indice++;
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error al listar reportes");
        }
        return $this->datos;
    }
       //registrar reporte
     function  RegistrarReporte(Reporte $rep){
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
	$id_rep;$fecha_hor;
	$id_rep = $cript->decrypt($rep->id_usuario);
	$fecha_hor = $cript->decrypt($rep->fecha_hora);
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='INSERT INTO `reporte`(`ID_REPORTE`, `ID_USUARIO`, `FECHA_HORA`) VALUES (null,?,?)';
        $sentencia=$conexion->prepare($this->SqlQuery); 
        $sentencia->bind_param("is",$id_rep,$fecha_hor);
        if($sentencia->execute()){
        $conexion->close();
	return true;
	}else{
	$conexion->close();
        return false;
         }
        }
    catch(Exception $e){
         return false;
         throw new $e("Error al Registrar Reporte");
        }
    }
    
     //eliminar reporte
        function  EliminarReportes($user){
        $user_param;
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
	$user_param = $cript->decrypt($user);
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='DELETE FROM `reporte` WHERE `ID_USUARIO`= ?';
        $sentencia=$conexion->prepare($this->SqlQuery); 
        $sentencia->bind_param("i",$user_param);
        if($sentencia->execute()){
        $conexion->close();
	return true;
	}else{
	$conexion->close();
        return false;
         }
        }
    catch(Exception $e){
         return false;
         throw new $e("Error al Eliminar Reportes");
        }
    }
    
    //conteo de reportes por usuario
    function  Cont_report_user($nom_usuario){
        $cont;$param;
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
	$param=$cript->decrypt($nom_usuario);
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT COUNT(*) FROM `reporte` WHERE `ID_USUARIO`= ?';
        $sentencia=$conexion->prepare($this->SqlQuery);
        $sentencia->bind_param("i",$param);
        if($sentencia->execute()){
        $sentencia->bind_result($conteo);					
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $cont=$conteo;
	}
         $conexion->close();  
      }
    }
    catch(Exception $e){
         throw new $e("Error al recuperar usuario");
        }
        return $cont;  
    }
    
}

?>