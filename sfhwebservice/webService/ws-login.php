<?php

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
		//json Login Paciente {"indice":1,"usuario":17231233,"pass":"asdcasco"}
		$usuario = $data->{'usuario'};
		$pass = $data->{'pass'};
		$controladora = new ControladoraLogin();
		$arreglo["resultado"] = $controladora->validarUsusarioPaciente($usuario, $pass);
		echo(json_encode($arreglo));
	break;	
	case 2:
		//json Login Asistente {"indice":2,"usuario":11111111,"pass":"asdcasco"}
		$usuario = $data->{'usuario'};
		$pass = $data->{'pass'};
		$controladora = new ControladoraLogin();
		$arreglo = $controladora->validarUsusarioFuncionario($usuario, $pass);
		echo(json_encode($arreglo));
	break;	
	case 3:
		//json Login Odontologo {"indice":3,"usuario":19746228,"pass":"asdcasco"}
		$usuario = $data->{'usuario'};
		$pass = $data->{'pass'};
		$controladora = new ControladoraLogin();
		$arreglo = $controladora->validarUsusarioOdontologo($usuario, $pass);
		echo(json_encode($arreglo));
	break;	
	case 4:
		//json Login Administrador {"indice":4,"usuario":17231233,"pass":"asdcasco"}
		$usuario = $data->{'usuario'};
		$pass = $data->{'pass'};
		$controladora = new ControladoraLogin();
		$arreglo = $controladora->validarUsusario($usuario, $pass);
		echo(json_encode($arreglo));
	break;	
}