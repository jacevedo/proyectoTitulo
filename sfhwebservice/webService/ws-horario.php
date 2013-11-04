<?php
require_once '../controladoras/controladorahorario.php';

/*
*Contiene la opciones para Horario
*Opciones:
* 1.- ingresarHorario
*/

$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json ingresarHorario {"indice":1,"fecha":"2013-10-10 13:13:00"}
		$controladora = new ControladoraHorario();
		$fecha =  new DateTime($data->{'fecha'});
		$arreglo["listaHorarios"] = $controladora->mostrarHorasDisponibles($fecha);
		echo(json_encode($arreglo));
	break;	
}