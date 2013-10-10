<?php
require '../phpass-0.3/PasswordHash.php';
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
		$arreglo["Resultado"] = $controladora->validarUsusario($usuario, $pass);


		echo(json_encode($arreglo));
	break;
	case 2:
		//json Modificar Tratamiento Dental {"indice":2,"idTratamientoDental":1,"idFicha":1,"fechaCreacion":"1991-12-12","tratamiento":"extraccion","fechaSeguimiento":"1991-12-12","valorTotal":100000}
		$idTratamientoDental = $data->{"idTratamientoDental"};
		$idFicha = $data->{'idFicha'};
		$fechaCreacion = $data->{'fechaCreacion'};
		$tratamiento = $data->{'tratamiento'};
		$fechaSeguimiento = $data->{'fechaSeguimiento'};
		$valorTotal = $data->{'valorTotal'};
		$tratamientoDental = new TratamientoDental();
		$tratamientoDental->initClass($idTratamientoDental, $idFicha, $fechaCreacion,$tratamiento, $fechaSeguimiento,$valorTotal);
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=2;
		$arreglo["Resultado"] = $controladoraFicha->modificarTratamiento($tratamientoDental);
		echo(json_encode($arreglo));
	break;
	
}