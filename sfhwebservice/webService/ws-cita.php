<?php
require_once '../pojos/cita.php';
require_once '../controladoras/controladoracitas.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- ingresarCita
* 2.- listar cita por id Paciente
* 3.- Listar Cita por id Paciente y fecha
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
	case 2:
		//json lista citas por id Paciente{"indice":2,"idPaciente":3}
		$controladora = new ControladoraCitas();
		$idPaciente = $data->{"idPaciente"};
		$arreglo["resultado"] = $controladora->listarCitaPorIdPaciente($idPaciente);
		echo(json_encode($arreglo));
	break;	
	case 3:
		//json lista citas por id Paciente y fecha {"indice":3,"idPaciente":3,"fecha":"2013-11-02"}
		$controladora = new ControladoraCitas();
		$idPaciente = $data->{"idPaciente"};
		$fecha = $data->{"fecha"};
		$arreglo["resultado"] = $controladora->listarCitaPorPacienteFecha($idPaciente,$fecha);
		echo(json_encode($arreglo));
	break;	
	case 4:
		//json lista citas por id Odontologo y Fecha {"indice":4,"idOdontologo":3,"fecha":"2013-11-07"}
		$controladora = new ControladoraCitas();
		$idOdontologo = $data->{"idOdontologo"};
		$fecha = $data->{"fecha"};
		$arreglo["resultado"] = $controladora->listarCitaPorOdontologoFecha($idOdontologo,$fecha);
		echo(json_encode($arreglo));
	break;	
}