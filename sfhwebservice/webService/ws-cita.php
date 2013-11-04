<?php
require_once '../pojos/cita.php';
require_once '../controladoras/controladoracitas.php';

/*
*Contiene la opciones para Citas
*Opciones:
* 1.- ingresarCita
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json insertarCita {"indice":1,"idPaciente":3,"idOdontologo":1,"fecha":"2013-10-10","horaInicio":"12:00:00","estado":0}
		$fecha =  $data->{'fecha'};
		$idPaciente = $data->{"idPaciente"};
		$idOdontologo = $data->{"idOdontologo"};
		$horaInicio = $data->{"horaInicio"};
		$estado = $data->{"estado"};

		$controladora = new ControladoraCitas();
		$cita = new Cita();
		
		$cita->initClass(0, $idOdontologo, $idPaciente, $horaInicio, $fecha, $estado);
		$arreglo["resultado"] = $controladora->insertarCita($cita);
		echo(json_encode($arreglo));
	break;	
}