<?php
require_once '../controladoras/controladorahorario.php';
require_once '../pojos/horario.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- mostrar horario disponible
* 2.- mostrar horario disponible web
* 3.- agregar horario
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json horas disponibles {"indice":1,"fecha":"2013-10-10 13:13:00"}
		$controladora = new ControladoraHorario();
		$fecha =  new DateTime($data->{'fecha'});
		$arreglo["listaHorarios"] = $controladora->mostrarHorasDisponibles($fecha);
		echo(json_encode($arreglo));
	break;	
	case 2:
		//json horas disponibles web {"indice":1,"fecha":"2013-10-10 13:13:00"}
		$controladora = new ControladoraHorario();
		$fecha =  new DateTime($data->{'fecha'});
		$arreglo["listaHorarios"] = $controladora->mostrarHorasDisponiblesWeb($fecha);
		echo(json_encode($arreglo));
	break;	
	case 3:
		//json insertar horario {"indice":3,"idOdontologo":3,"dia":"lunes","horaInicio":"13:00:00","horaTermino":"14:00:00","duracionModulo":"00:30:00"}
		$idOdontologo = $data->{"idOdontologo"};
		$dia = $data->{"dia"};
		$horaInicio = $data->{"horaInicio"};
		$horaTermino = $data->{"horaTermino"};
		$duracionModulo = $data->{"duracionModulo"};
		$horario = new Horario();
		$controladoraHorario = new ControladoraHorario();
		$horario->initClass(0, $idOdontologo, $horaInicio, $horaTermino, $duracionModulo);
		$arreglo["resultado"] = $controladoraHorario->insertarHorario($horario,$dia);
		echo (json_encode($arreglo));
	break;
	case 4:
		//json listarhorarios {"indice":4,"idOdontologo":2}
		$idOdontologo = $data->{"idOdontologo"};
		$controladoraHorario = new ControladoraHorario();
		$arreglo["listaHorarios"] = $controladoraHorario->listarHorarioOdontologo($idOdontologo);
		echo(json_encode($arreglo));
	break;
	case 5:
		//json insertar horario {"indice":5,"idHorario":2,"idOdontologo":3,"dia":"lunes","horaInicio":"13:00:00","horaTermino":"14:00:00","duracionModulo":"00:30:00"}
		$idHorario = $data->{"idHorario"};
		$idOdontologo = $data->{"idOdontologo"};
		$dia = $data->{"dia"};
		$horaInicio = $data->{"horaInicio"};
		$horaTermino = $data->{"horaTermino"};
		$duracionModulo = $data->{"duracionModulo"};
		$horario = new Horario();
		$controladoraHorario = new ControladoraHorario();
		$horario->initClass($idHorario, $idOdontologo, $horaInicio, $horaTermino, $duracionModulo);
		$arreglo["resultado"] = $controladoraHorario->modificarHorario($horario,$dia);
		echo (json_encode($arreglo));
	break;
}