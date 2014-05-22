<?php
require_once '../pojos/cita.php';
require_once '../pojos/persona.php';
require_once '../pojos/paciente.php';
require_once '../controladoras/controladorapaciente.php';
require_once '../controladoras/controladoracitas.php';
require_once '../controladoras/controladorapersonaregioncomuna.php';
require_once '../controladoras/encript.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- insertar cita
* 2.- listar cita por id Paciente
* 3.- Listar Cita por id Paciente y fecha
* 4.- lista citas por id Odontologo y Fecha
* 5.- listar citas por fecha
* 6.- ConfirmarCitas
* 7.- Confirmar una cita
* 8.- modificarCita web
* 9.- Crear Persona Cita
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
		$arreglo["code"] = 1;
		$arreglo["resultado"] = $controladora->insertarCita($cita);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;	
	case 2:
		//json lista citas por id Paciente{"indice":2,"idPaciente":3}
		$controladora = new ControladoraCitas();
		$idPaciente = $data->{"idPaciente"};
		$arreglo["code"] = 2;
		$arreglo["resultado"] = $controladora->listarCitaPorIdPaciente($idPaciente);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;	
	case 3:
		//json lista citas por id Paciente y fecha {"indice":3,"idPaciente":3,"fecha":"2013-11-02"}
		$controladora = new ControladoraCitas();
		$idPaciente = $data->{"idPaciente"};
		$fecha = $data->{"fecha"};
		$arreglo["code"] = 3;
		$arreglo["resultado"] = $controladora->listarCitaPorPacienteFecha($idPaciente,$fecha);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;	
	case 4:
		//json lista citas por id Odontologo y Fecha {"indice":4,"idOdontologo":3,"fecha":"2013-11-07"}
		$controladora = new ControladoraCitas();
		$idOdontologo = $data->{"idOdontologo"};
		$fecha = $data->{"fecha"};
		$arreglo["code"] = 4;
		$arreglo["resultado"] = $controladora->listarCitaPorOdontologoFecha($idOdontologo,$fecha);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;	
	case 5:
		//json listar citas por fecha {"indice":5,"fecha":"2013-11-16"}
		$controladora = new ControladoraCitas();
		$fecha = $data->{"fecha"};
		$arreglo["code"] = 5;
		$arreglo["resultado"] = $controladora->listarCitaPorFecha($fecha);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 6:

		//json ConfirmarCitas{"indice":6,"citas":[{"idCita":2,"estado":3}]}
		$controladora = new ControladoraCitas();
		$arregloJson = $data->{"citas"};
		$devolucion = true;
		foreach ($arregloJson as $objetoJson) 
		{
			$idCita = $objetoJson->{"idCita"};
			$estado = $objetoJson->{"estado"};
			$devolucion = true && $controladora->confirmarCita($idCita,$estado);

		}

		$arreglo["code"] = 6;
		$arreglo["devolucion"] =  $devolucion;
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 7:
		//json Confirmar una cita {"indice":7,"idCita":3}
		$controladora = new ControladoraCitas();
		$idCita = $data->{"idCita"};
		$estado = 3;
		$arreglo["code"] = 3;
		$arreglo["resultado"] = $controladora->confirmarCita($idCita,$estado);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 8:
		//json modificarCita web {"indice":4,"idOdontologo":3,"hora":"2013-11-30 13:00:00","idCita":1}
		$controladora = new ControladoraCitas();
		$idOdontologo = $data->{"idOdontologo"};
		$hora = $data->{"hora"};
		$idCita = $data->{"idCita"};
		$arreglo["code"] = 8;
		$arreglo["resultado"] = $controladora->modificarCitaWeb($idOdontologo,$hora,$idCita);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 9:
		//json Crear Persona Cita {"indice":9,"rut":123123,"dv":"k","nombre":"antonio","appPaterno":"palmas","apellidoMaterno":"simoneli","fechaNacimiento":"2013-10-12","fechaReserva":"2013-11-30","idOdontologo":2,"horaReserva":"2013-11-30 13:30:00","estado":0}
		$rut = $data->{"rut"};
		$dv = $data->{"dv"};
		$nombre = $data->{"nombre"};
		$appPaterno = $data->{"appPaterno"};
		$appMaterno = $data->{"apellidoMaterno"};
		$fechaNacimiento = $data->{"fechaNacimiento"};
		$fechaReserva = $data->{"fechaReserva"};
		$idOdontologo = $data->{"idOdontologo"};
		$horaReserva = $data->{"horaReserva"};
		$estado = $data->{"estado"};
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$controladoraPaciente = new ControladoraPaciente();
		$controladoraCita = new ControladoraCitas();
		$persona = new Persona();
		$paciente = new Paciente();
		$cita = new Cita();
		$persona->initClass(0, 4, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNacimiento);
		$idPersona = $controladoraPersona->insertarPersona($persona);
		$arreglo["code"] = 9;
		if($idPersona!=-1)
		{
			$paciente->initClassPacientePersona($persona, $idPersona, date("Y-m-d"), 1);
			$idPaciente = $controladoraPaciente->insertarPaciente($paciente);
			if($idPaciente!=-1)
			{
				$cita->initClass(0, $idOdontologo, $idPaciente, $horaReserva, $fechaReserva, $estado);
				$arreglo["resultado"] = $controladoraCita->insertarCita($cita);
			}
			else
			{
				$arreglo["hubo un error al insertar al paciente"];
			}
		}
		else
		{
			$arreglo["resultado"] = "hubo un error al insertar la persona";
		}
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 10:
		//modificar Cita {"indice":1,"idCita":1, "idPaciente":3,"idOdontologo":1,"fecha":"2013-10-10","horaInicio":"12:00:00"}
		$controladora = new ControladoraCitas();
		$fecha =  $data->{'fecha'};
		$idPaciente = $data->{"idPaciente"};
		$idOdontologo = $data->{"idOdontologo"};
		$horaInicio = $data->{"horaInicio"};
		$idCita = $data->{"idCita"};
		$cita = new Cita();

		$cita->initClass($idCita, $idOdontologo, $idPaciente, $horaInicio, $fecha, 0);
		//echo($date);
		$arreglo["code"] = 1;
		$arreglo["resultado"] = $controladora->modificarCita($cita);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
}