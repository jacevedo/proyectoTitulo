<?php
require_once '../conexion/MySqlCon.php';
require_once '../modelobj/alumnos.php';
require_once '../seguridad/code_encrypt.php';
class oper_alumno{
    private $SqlQuery;
    private $datos;
    /*
 SELECT alum.RUT, alum.NOMBRE,alum.APELLIDO,alum.DIRECCION,alum.TELEFONO_1,
 alum.TELEFONO_2,alum.MAIL_DUOC,alum.MAIL,alum.FECHA_MAT,com.NOMBRE_COMUNA ,reg.NOMBRE_REGION ,carr.NOMBRE_CARRERA
 from   alumnos alum,  carreras  carr, comuna com, region reg WHERE alum. ID_CARRERA=carr. ID_CARRERA AND alum.ID_COMUNA = com.ID_COMUNA AND 
 com.ID_REGION = reg.ID_REGION AND alum.RUT = ' '
    */
    //funcion recuperar datos alumnos 
    function  RecuperarAlumno($runp){
        $conexion = new MySqlCon();
        $alumno = new Alumnos();
    try {  
        $this->SqlQuery='';
        $this->SqlQuery=' SELECT alum.RUT, alum.NOMBRE, alum.DIRECCION, alum.TELEFONO_1, alum.TELEFONO_2, alum.MAIL_DUOC, alum.MAIL, alum.JORNADA, alum.CATEGORIA, com.NOMBRE_COMUNA, com.ID_COMUNA,com.ID_REGION, reg.NOMBRE_REGION, carr.NOMBRE_CARRERA FROM alumnos alum, carreras carr, comuna com, region reg WHERE alum.ID_CARRERA = carr.ID_CARRERA AND alum.ID_COMUNA = com.ID_COMUNA AND com.ID_REGION = reg.ID_REGION AND alum.RUT  = ?';
        $sentencia=$conexion->prepare($this->SqlQuery);
        $sentencia->bind_param("i",$runp);
        if($sentencia->execute()){
        $sentencia->bind_result($run,$nombre,$direccion,$telefono_1,$telefono_2,$mail_duoc,
        $mail,$jornada,$categoria,$nom_comuna,$id_comuna,$id_region,$nom_region,$carrera);
        $val = false;
	while($sentencia->fetch()){
        $val=true;
        $alumno->run = $run;
        $alumno->nombre = $nombre;
        $alumno->direccion = $direccion;
        $alumno->telefono_1 = $telefono_1;
        $alumno->telefono_2 = $telefono_2;
        $alumno->mail_duoc = $mail_duoc;
        $alumno->mail = $mail;
        $alumno->jornada = $jornada;
        $alumno->categoria = $categoria;
        $alumno->nom_comuna = $nom_comuna;
	$alumno->id_comuna = $id_comuna;
	$alumno->id_region = $id_region;
        $alumno->nom_region = $nom_region;
        $alumno->carrera = $carrera;
	
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error interno por favor intente otra vez");
        }
        return $alumno;
    }
    //SELECT COUNT(*) , RUT FROM ALUMNOS WHERE UPPER(TRIM(MAIL_DUOC)) = UPPER(TRIM(fhfhfhhsdfh@duoc.cl)) AND UPPER(TRIM(NOMBRE)) = UPPER(TRIM(SAAVEDRA,MEROLLY MARIA)) AND JORNADA = Diurno AND RUT = 175193820
    //SELECT COUNT(*) , RUT FROM `alumnos` WHERE UPPER(TRIM(MAIL_DUOC)) = UPPER(TRIM('DAV.SOtom@alumnos.duoc.cl')) AND    RUT = TRIM(175193820)
     function  validAlumno(Alumnos $alumnos){
        $conexion = new MySqlCon();
        $cript = new Crypta_cod();
        $verificador = false;
    try {
        $run=$cript->decrypt($alumnos->run);
        $jornada=$cript->decrypt($alumnos->jornada);
        $nombre=$cript->decrypt($alumnos->nombre);
        $correoduoc=$cript->decrypt($alumnos->mail_duoc);
        $this->SqlQuery='';
        $this->SqlQuery='SELECT COUNT(*) , RUT FROM `alumnos` WHERE UPPER(TRIM(MAIL_DUOC)) = UPPER(TRIM(?)) AND    RUT = TRIM(?)';
        $sentencia=$conexion->prepare($this->SqlQuery);
        $sentencia->bind_param("ss",$correoduoc,$run);
        if($sentencia->execute()){
        $sentencia->bind_result($cuenta,$runr);
	while($sentencia->fetch()){
	if($cuenta==1){
        if($run==$runr){
          $verificador=true;
            }
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
    
    /*
    UPDATE `alumnos` SET `DIRECCION`='HSHSSHDS ',`TELEFONO_1`=' 87888989' ,
    `TELEFONO_2`='5454554545',`MAIL`='fhfhfhhsdfh@duoc.cl',`ID_COMUNA`=344
    WHERE `RUT`=175193820
    */
    function ModInfoalumnos(Alumnos $alumnos){
        $conexion = new MySqlCon();
        $cript = new Crypta_cod();
        $dir;$tel_1;$tel_2;$mail;$com;$run;
        $dir=$cript->decrypt($alumnos->direccion);
        $tel_1=$cript->decrypt($alumnos->telefono_1);
        $tel_2=$cript->decrypt($alumnos->telefono_2);
        $mail=$cript->decrypt($alumnos->mail);
        $com=$cript->decrypt($alumnos->id_comuna);
	$fecha= date("Y-m-d");
        $run=$cript->decrypt($alumnos->run);
    try {
        $this->SqlQuery='';
        $this->SqlQuery=' UPDATE `alumnos` SET `DIRECCION`=?,`TELEFONO_1`=?,`TELEFONO_2`=?,`MAIL`=?,`ID_COMUNA`=? ,`FECHA_MOD`=?  WHERE `RUT`=?';
        $sentencia=$conexion->prepare($this->SqlQuery);
        $sentencia->bind_param("ssssiss",$dir,$tel_1,$tel_2,$mail,$com,$fecha,$run);
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
         throw new $e("No se pudieron actualizar los datos");
        }   
         
     }
      
       /*
    UPDATE `alumnos` SET `DIRECCION`='HSHSSHDS ',`TELEFONO_1`=' 87888989' ,
    `TELEFONO_2`='5454554545',`MAIL`='fhfhfhhsdfh@duoc.cl'
    WHERE `RUT`=175193820
    */
      //modifica sin comuna asociada
      function ModInfoalumnosinco(Alumnos $alumnos){
        $conexion = new MySqlCon();
        $cript = new Crypta_cod();
        $dir;$tel_1;$tel_2;$mail;$run;$fecha;
        $dir=$cript->decrypt($alumnos->direccion);
        $tel_1=$cript->decrypt($alumnos->telefono_1);
        $tel_2=$cript->decrypt($alumnos->telefono_2);
        $mail=$cript->decrypt($alumnos->mail);
        $run=$cript->decrypt($alumnos->run);
	//$ts = mktime($hora,$minute,$segundo,$mes,$dia,$anio); 
        $fecha= date("Y-m-d");
    try {
        $this->SqlQuery='';
        $this->SqlQuery=' UPDATE `alumnos` SET `DIRECCION`=?,`TELEFONO_1`=?,`TELEFONO_2`=?,`MAIL`=? ,`FECHA_MOD`=?  WHERE `RUT`=?';
        $sentencia=$conexion->prepare($this->SqlQuery);
        $sentencia->bind_param("sssss",$dir,$tel_1,$tel_2,$mail,$fecha,$run);
        if($sentencia->execute()){
        $conexion->close();
	return true;
	//return $fecha;
	}else{
	$conexion->close();
        return false;
        }
      }
      catch(Exception $e){
         return false;
         throw new $e("No se pudieron actualizar los datos");
        }   
         
     }
     
     //funcion listar actualizacion semanal
     function  ListarActualizacionSemanal(){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT al.RUT, al.NOMBRE, car.NOMBRE_CARRERA, al.MAIL_DUOC, al.JORNADA, al.TELEFONO_2, al.FECHA_MOD FROM  `alumnos` al, carreras car WHERE al.ID_CARRERA = car.ID_CARRERA AND al.FECHA_MOD BETWEEN DATE_SUB(CURDATE(),INTERVAL 1 WEEK) AND CURDATE()';
        $sentencia=$conexion->prepare($this->SqlQuery);
        if($sentencia->execute()){
        $sentencia->bind_result($run,$nombre,$carrera,$mail_duoc,$jornada,$telefono_2,$fecha_mod);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $run;
        $this->datos[$indice][1] = $nombre;
        $this->datos[$indice][2] = $carrera;
	$this->datos[$indice][3] = $mail_duoc;
	$this->datos[$indice][4] = $jornada;
	$this->datos[$indice][5] = $telefono_2;
        $this->datos[$indice][6] = $fecha_mod;
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
   
     
   //funcion reportar actualizacion semanal
     function  ReportarActualizacionSemanal(){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT al.RUT, al.NOMBRE, co.NOMBRE_COMUNA, car.NOMBRE_CARRERA, al.DIRECCION, al.TELEFONO_1, al.TELEFONO_2, al.MAIL_DUOC, al.MAIL, al.JORNADA, al.CATEGORIA, al.FECHA_MOD FROM  `alumnos` al,  `comuna` co,  `carreras` car WHERE al.ID_COMUNA = co.ID_COMUNA AND al.ID_CARRERA = car.ID_CARRERA AND al.FECHA_MOD BETWEEN DATE_SUB( CURDATE() , INTERVAL 1 WEEK )  AND CURDATE()';
        $sentencia=$conexion->prepare($this->SqlQuery);
        if($sentencia->execute()){
        $sentencia->bind_result($run,$nombre,$nom_comuna,$carrera,$direccion,$telefono_1,$telefono_2,$mail_duoc,
        $mail,$jornada,$categoria,$fecha_mod);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $run;
        $this->datos[$indice][1] = $nombre;
	$this->datos[$indice][2] = $nom_comuna;
        $this->datos[$indice][3] = $carrera;
	$this->datos[$indice][4] = $direccion;
        $this->datos[$indice][5] = $telefono_1;
	$this->datos[$indice][6] = $telefono_2;
	$this->datos[$indice][7] = $mail_duoc;
        $this->datos[$indice][8] = $mail;
	$this->datos[$indice][9] = $jornada;
	$this->datos[$indice][10] = $categoria;
        $this->datos[$indice][11] = $fecha_mod;
        $indice++;
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error al listar Alumnos");
        }
        return $this->datos;
    }
   
     function  ResultadoBusqueda($param_bus){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT al.RUT, al.NOMBRE, car.NOMBRE_CARRERA, al.MAIL_DUOC, al.JORNADA, al.TELEFONO_2, al.FECHA_MOD FROM  `alumnos` al, carreras car WHERE al.ID_CARRERA = car.ID_CARRERA AND  al.NOMBRE  LIKE "%'.$param_bus.'%" ORDER BY al.NOMBRE';
        $sentencia=$conexion->prepare($this->SqlQuery);
        if($sentencia->execute()){
        $sentencia->bind_result($run,$nombre,$carrera,$mail_duoc,$jornada,$telefono_2,$fecha_mod);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $run;
        $this->datos[$indice][1] = $nombre;
        $this->datos[$indice][2] = $carrera;
	$this->datos[$indice][3] = $mail_duoc;
	$this->datos[$indice][4] = $jornada;
	$this->datos[$indice][5] = $telefono_2;
        $this->datos[$indice][6] = $fecha_mod;
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
    
    
    //funcion reportar actualizacion total
     function  ReportarActualizacionTotal(){
        $conexion = new MySqlCon();
        $this->datos='';
    try {  
        $this->SqlQuery='';
        $this->SqlQuery='SELECT al.RUT, al.NOMBRE, co.NOMBRE_COMUNA, car.NOMBRE_CARRERA, al.DIRECCION, al.TELEFONO_1, al.TELEFONO_2, al.MAIL_DUOC, al.MAIL, al.JORNADA, al.CATEGORIA, al.FECHA_MOD FROM  `alumnos` al,  `comuna` co,  `carreras` car WHERE al.ID_COMUNA = co.ID_COMUNA AND al.ID_CARRERA = car.ID_CARRERA AND al.FECHA_MOD';
        $sentencia=$conexion->prepare($this->SqlQuery);
        if($sentencia->execute()){
        $sentencia->bind_result($run,$nombre,$nom_comuna,$carrera,$direccion,$telefono_1,$telefono_2,$mail_duoc,
        $mail,$jornada,$categoria,$fecha_mod);					
	$indice=0;                                                         
	$val = false;
	while($sentencia->fetch()){
        $val=true;
        $this->datos[$indice][0] = $run;
        $this->datos[$indice][1] = $nombre;
	$this->datos[$indice][2] = $nom_comuna;
        $this->datos[$indice][3] = $carrera;
	$this->datos[$indice][4] = $direccion;
        $this->datos[$indice][5] = $telefono_1;
	$this->datos[$indice][6] = $telefono_2;
	$this->datos[$indice][7] = $mail_duoc;
        $this->datos[$indice][8] = $mail;
	$this->datos[$indice][9] = $jornada;
	$this->datos[$indice][10] = $categoria;
        $this->datos[$indice][11] = $fecha_mod;
        $indice++;
	}
      }
       $conexion->close();
    }
    catch(Exception $e){
         throw new $e("Error al listar Alumnos");
        }
        return $this->datos;
    }
    
}
?>