<?php

require_once '../controladoras/controladoralogin.php';
require_once '../controladoras/encript.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- Login Paciente
* 2.- Login Asistente
* 3.- Login Odontologo
* 4.- Login Administrador
*/


$jsonRecibido = $_REQUEST["send"]; 
$encript = new Encript();
$datos = $encript->validarSinkey($jsonRecibido);
$data = "";
 error_log("json: datos: ".$datos); 
if(!is_numeric($datos))
{
	$data = json_decode($datos);
	$opcion = $data->{"indice"};
}
else
{
	$opcion = -1;	
}
switch ($opcion) 
{
	case 1:
		//json Login Paciente {"indice":1,"usuario":17231233,"pass":"asdcasco"}
		$usuario = $data->{'usuario'};
		$pass = $data->{'pass'};
		$controladora = new ControladoraLogin();
		$consulta["resultado"] = $controladora->validarUsusarioPaciente($usuario, $pass);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($consulta);
		echo($jsonEncriptado);
	break;	
	case 2:
		//json Login Asistente {"indice":2,"usuario":11111111,"pass":"asdcasco"}
		$usuario = $data->{'usuario'};
		$pass = $data->{'pass'};
		$controladora = new ControladoraLogin();
		$consulta["resultado"] =  $controladora->validarUsusarioFuncionario($usuario, $pass);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($consulta);
		echo($jsonEncriptado);
	break;	
	case 3:
		//json Login Odontologo {"indice":3,"usuario":19746228,"pass":"asdcasco"}
		$usuario = $data->{'usuario'};
		$pass = $data->{'pass'};
		$controladora = new ControladoraLogin();
		$consulta["resultado"] =  $controladora->validarUsusarioOdontologo($usuario, $pass);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($consulta);
		echo($jsonEncriptado);
	break;	
	case 4:
		//json Login Administrador {"indice":4,"usuario":17231233,"pass":"asdcasco"}
		$usuario = $data->{'usuario'};
		$pass = $data->{'pass'};
		$controladora = new ControladoraLogin();
		$consulta["resultado"] =  $controladora->validarUsusario($usuario, $pass);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($consulta);
		echo($jsonEncriptado);
	break;	
}