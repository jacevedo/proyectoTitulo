<?php
/***************************************/
require_once '../conexion/MySqlCon.php';
require_once '../modelobj/pass.php';
require_once '../seguridad/code_encrypt.php';
/***************************************/
class Oper_pass{
   
    //variables
    private $SqlQuery;
    private $recpass;
    //funcio recuperar pass
     function  RecuperarPass($id_usu){
        $conexion = new MySqlCon();
        $pass = new Pass();
	$cript = new Crypta_cod();
	$pass->id_usuario=$cript->decrypt($id_usu);
    try {
        $this->SqlQuery='';
        $this->SqlQuery='SELECT `PASS` FROM `pass` WHERE `ID_USUARIO` = ?';
        $sentencia=$conexion->prepare($this->SqlQuery);
        $sentencia->bind_param("i",$pass->id_usuario);
        if($sentencia->execute()){
        $sentencia->bind_result($this->recpass);					
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $pass->pass = $this->recpass;
	}
         $conexion->close();  
      }
    }
    catch(Exception $e){
         throw new $e("Algún mensaje de error");
        }
        return $pass;  
    }
    
    
       //registrar pass
     function  RegistrarPass(Pass $pass){
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='INSERT INTO `pass`(`ID_USUARIO`, `PASS`) VALUES (?,?)';
        $sentencia=$conexion->prepare($this->SqlQuery); 
        $sentencia->bind_param("is",$pass->id_usuario,$pass->pass);
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
         throw new $e("Error al Registrar Password");
        }
    }
    
    
      //eliminar pass
        function  EliminarPass($user){
        $user_param;
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
	$user_param = $cript->decrypt($user);
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='DELETE FROM `pass` WHERE `ID_USUARIO` = ?';
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
         throw new $e("Error al Eliminar Password");
        }
    }
    
    
      //Actualizar pass
        function  UpdatePass(Pass $pass){
        $id_user;$password;
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
	$id_user = $cript->decrypt($pass->id_usuario);
	$password = $pass->pass;
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='UPDATE `pass` SET `PASS`= ? WHERE `ID_USUARIO` = ?';
        $sentencia=$conexion->prepare($this->SqlQuery); 
        $sentencia->bind_param("si",$password,$id_user);
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
         throw new $e("Error al Actualizar Password");
        }
    }
    
}

?>
