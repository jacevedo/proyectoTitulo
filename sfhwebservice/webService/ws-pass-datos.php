<?php
require_once '../pojos/pass.php';
require_once '../pojos/datoscontacto.php';
require_once '../controladoras/controladorapass.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- insertar pass
* 2.- Modificar pass
* 3.- Listar pass por idPersona
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json Insertar Pass {"indice":1,"idPersona":3,"pass":"asdasd","fechaCaducidad":"2013-12-12"}
		$idPersona = $data->{'idPersona'};
		$password = $data->{'pass'};
		$fechaCaducidad = $data->{'fechaCaducidad'};
		
		$pass = new Pass();
		$pass->initClass($idPersona,$password,$fechaCaducidad);
		$controladoraPass = new ControladoraPass();
		$arreglo["code"]=1;
		$arreglo["Resultado"] = $controladoraPass->insertarPass($pass);
		echo(json_encode($arreglo));
	break;
	case 2:
		//json Modificar Pass {"indice":2,"idPersona":3,"pass":"asdasd","fechaCaducidad":"2013-08-09"}
		$idPersona = $data->{'idPersona'};
		$password = $data->{'pass'};
		$fechaCaducidad = $data->{'fechaCaducidad'};
		
		$pass = new Pass();
		$pass->initClass($idPersona,$password,$fechaCaducidad);
		$controladoraPass = new ControladoraPass();
		$arreglo["code"]=1;
		$arreglo["Resultado"] = $controladoraPass->modificarPass($pass);
		echo(json_encode($arreglo));
	break;
	case 3:
		//json Listar Pass idPersona {"indice":3,"idPersona":1}
		$idPersona = $data->{"idPersona"};
		$controladoraPass = new ControladoraPass();
		$arreglo["code"] = 3;
		$arreglo["resultado"] =  $controladoraPass->buscarIdPersona($idPersona);
		echo(json_encode());
	break;
	
}