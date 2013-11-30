<?php
require_once '../controladoras/controladorahorario.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- ingresarUsuario
* 2.- Logout
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json Login {"indice":1,"fecha":"2013-10-10 13:13:00"}
		$controladora = new ControladoraHorario();
		$fecha =  new DateTime($data->{'fecha'});
		$arreglo["listaHorarios"] = $controladora->mostrarHorasDisponibles($fecha);
		echo(json_encode($arreglo));
	break;	
	case 2:
		//json Login {"indice":1,"fecha":"2013-10-10 13:13:00"}
		$controladora = new ControladoraHorario();
		$fecha =  new DateTime($data->{'fecha'});
		$arreglo["listaHorarios"] = $controladora->mostrarHorasDisponiblesWeb($fecha);
		echo(json_encode($arreglo));
	break;	
}