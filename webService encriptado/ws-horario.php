<?php
require_once '../controladoras/controladorahorario.php';
require_once '../pojos/horario.php';
require_once '../controladoras/encript.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
* 1.- mostrar horario disponible
* 2.- mostrar horario disponible web
* 3.- agregar horario
* 4.- listar horarios
* 5.- modificar horario
*/


$jsonRecibido = $_REQUEST["send"];
$encript = new Encript();
$datos = $encript->validarkey($jsonRecibido);
$data = "";
error_log("json: datos: ".$datos); 
if(!is_numeric($datos))
{

	$data = json_decode($datos);
	$opcion = $data->{"indice"};
}
else
{
	$opcion = -1;	
}
switch ($opcion) 
{
	case 1:
		//json horas disponibles {"indice":1,"fecha":"2013-10-10 13:13:00"}
		$controladora = new ControladoraHorario();
		$fecha =  new DateTime($data->{'fecha'});
		$arreglo["code"] = 1;
		$arreglo["listaHorarios"] = $controladora->mostrarHorasDisponibles($fecha);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;	
	case 2:
		//json horas disponibles web {"indice":1,"fecha":"2013-10-10 13:13:00"}
		$controladora = new ControladoraHorario();
		$fecha =  new DateTime($data->{'fecha'});
		$arreglo["code"] = 2;
		$arreglo["listaHorarios"] = $controladora->mostrarHorasDisponiblesWeb($fecha);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
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
		$arreglo["code"] = 3;
		$arreglo["resultado"] = $controladoraHorario->insertarHorario($horario,$dia);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 4:
		//json listarhorarios {"indice":4,"idOdontologo":2}
		$idOdontologo = $data->{"idOdontologo"};
		$controladoraHorario = new ControladoraHorario();
		$arreglo["code"] = 4;
		$arreglo["listaHorarios"] = $controladoraHorario->listarHorarioOdontologo($idOdontologo);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 5:
		//json Modificar horario {"indice":5,"idHorario":2,"idOdontologo":3,"dia":"lunes","horaInicio":"13:00:00","horaTermino":"14:00:00","duracionModulo":"00:30:00"}
		$idHorario = $data->{"idHorario"};
		$idOdontologo = $data->{"idOdontologo"};
		$dia = $data->{"dia"};
		$horaInicio = $data->{"horaInicio"};
		$horaTermino = $data->{"horaTermino"};
		$duracionModulo = $data->{"duracionModulo"};
		$horario = new Horario();
		$controladoraHorario = new ControladoraHorario();
		$horario->initClass($idHorario, $idOdontologo, $horaInicio, $horaTermino, $duracionModulo);
		$arreglo["code"] = 5;
		$arreglo["resultado"] = $controladoraHorario->modificarHorario($horario,$dia);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
}