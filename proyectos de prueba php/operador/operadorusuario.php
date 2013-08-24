<?php
/***************************************/
require_once '../conexion/MySqlCon.php';
require_once '../modelobj/usuario.php';
require_once '../seguridad/code_encrypt.php';
/***************************************/
class Oper_usuario{
    //variables
    private $SqlQuery;
    private $id_perfilrec; private $id_usuariorec; private $nom_usurec;
    //recuperar usuario
    function  Rec_usuario($nom_usuario){
        $usuario = new Usuario();
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
	$usuario->nom_usuario=$cript->decrypt($nom_usuario);
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT `ID_USUARIO`, `ID_PERFIL`, `NOM_USUARIO` FROM `usuario` WHERE `NOM_USUARIO` = ?';
        $sentencia=$conexion->prepare($this->SqlQuery);
        $sentencia->bind_param("s",$usuario->nom_usuario);
        if($sentencia->execute()){
        $sentencia->bind_result($this->id_usuariorec,$this->id_perfilrec,$this->nom_usurec);					
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $usuario->id_usuario = $this->id_usuariorec;
	$usuario->id_perfil = $this->id_perfilrec;
        $usuario->nom_usuario = $this->nom_usurec;
	}
         $conexion->close();  
      }
    }
    catch(Exception $e){
         throw new $e("Error al recuperar usuario");
        }
        return $usuario;  
    }
    
    
     //listar usuario
    function  Listar_Usuario(){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT usu.ID_USUARIO,usu.ID_PERFIL, per.NOMBRE_PERFIL, usu.NOM_USUARIO FROM  `usuario` usu,  `perfil` per WHERE usu.ID_PERFIL = per.ID_PERFIL LIMIT 0 , 30';
        $sentencia=$conexion->prepare($this->SqlQuery);
        if($sentencia->execute()){
        $sentencia->bind_result($iduser,$id_perfil,$nom_per,$nom_user);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $iduser;
	$this->datos[$indice][1] = $id_perfil;
        $this->datos[$indice][2] = $nom_user;
	$this->datos[$indice][3] = $nom_per;
        $indice++;
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error al listar Usuarios");
        }
        return $this->datos;
    }
    
    //insertar usuario
    function  RegistrarUsuario(Usuario $user){
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='INSERT INTO `usuario`(`ID_USUARIO`,`ID_PERFIL`, `NOM_USUARIO`) VALUES (null,?,?)';
        $sentencia=$conexion->prepare($this->SqlQuery);
	$id_perfilrec=$cript->decrypt($user->id_perfil);
	$nom_usurec=$cript->decrypt($user->nom_usuario);
        $sentencia->bind_param('is',$id_perfilrec,$nom_usurec);
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
         throw new $e("Error al Registrar Usuarios");
        }
    }   
    
     //eliminar usuario
        function  EliminarUsuario($user2){
        $user_param;
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
	$user_param = $cript->decrypt($user2);
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='DELETE FROM `usuario` WHERE `ID_USUARIO` = ?';
        $sentencia=$conexion->prepare($this->SqlQuery); 
        $sentencia->bind_param('i',$user_param);
	if($sentencia->execute()){
        $conexion->close();
	return true;
	}
	else{
	$conexion->close();
        return false;
         }
        }
    catch(Exception $e){
         return false;
         throw new $e("Error al Eliminar Usuario");
        }
    }
    
    
    //Actualizar usuario
        function  ActualizarUsuario(Usuario $usuario){
        $id_per;$id_usuario;$nom_usuario;
        $conexion = new MySqlCon();
	$cript = new Crypta_cod();
	
	$id_per = $cript->decrypt($usuario->id_perfil);
	$nom_usuario = $cript->decrypt($usuario->nom_usuario);
	$id_usuario = $cript->decrypt($usuario->id_usuario);
	//echo $id_per." ".$nom_usuario." ".$id_usuario;
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='UPDATE `usuario` SET `ID_PERFIL`=? ,`NOM_USUARIO`=?  WHERE `ID_USUARIO`=?';
        $sentencia=$conexion->prepare($this->SqlQuery); 
        $sentencia->bind_param('isi',$id_per,$nom_usuario,$id_usuario);
        if($sentencia->execute())
	{
        $conexion->close();
	return true;
	}
	else{
	$conexion->close();
        return false;
         }
        }
    catch(Exception $e){
         return false;
         throw new $e("Error al Actualizar Usuario");
        }
    }
    
      //Valida Usuario
     function  ValidaUsuario($nom_user){
        $conexion = new MySqlCon();
        $cript = new Crypta_cod();
        $verificador = false;
    try {
        $user_param = $cript->decrypt($nom_user);
        $this->SqlQuery='';
        $this->SqlQuery='SELECT COUNT(*)FROM `usuario` WHERE UPPER(TRIM(`NOM_USUARIO`)) = UPPER(TRIM(?))';
        $sentencia=$conexion->prepare($this->SqlQuery);
        $sentencia->bind_param("s",$user_param);
        if($sentencia->execute()){
        $sentencia->bind_result($cuenta);
	while($sentencia->fetch()){
	if($cuenta==1){
          $verificador=true;
          }
	  else{
	  $verificador=false;
	  }
        }
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error interno por favor intente otra vez");
        }
        return $verificador;
    }
    
    
}
?>