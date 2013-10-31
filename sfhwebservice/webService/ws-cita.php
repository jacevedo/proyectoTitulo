<?php
require_once '../pojos/cita.php';
require_once '../controladoras/controladoracitas.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- ingresarCita
* 2.- Logout
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json insertar Cita{"indice":1,"idPaciente":3,"idOdontologo":1,"fecha":"2013-10-10","horaInicio":"12:00:00","estado":0}
		$controladora = new ControladoraCitas();
		$fecha =  $data->{'fecha'};
		$idPaciente = $data->{"idPaciente"};
		$idOdontologo = $data->{"idOdontologo"};
		$horaInicio = $data->{"horaInicio"};
		$estado = $data->{"estado"};
		$cita = new Cita();
		$cita->initClass(0, $idOdontologo, $idPaciente, $horaInicio, $fecha, $estado);
		//echo($date);
		$arreglo["resultado"] = $controladora->insertarCita($cita);
		echo(json_encode($arreglo));
	break;	
}