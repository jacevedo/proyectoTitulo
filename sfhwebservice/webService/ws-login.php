<?php
require '../phpass/PasswordHash.php';
require_once '../controladoras/controladoralogin.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- Login
* 2.- Logout
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json Login {"indice":1,"usuario":17231233,"pass":"asdcasco"}
		$usuario = $data->{'usuario'};
		$pass = $data->{"pass"};
		$controladora = new ControladoraLogin();
		$arreglo = $controladora->validarUsusario($usuario, $pass);
		echo(json_encode($arreglo));
	break;	
}