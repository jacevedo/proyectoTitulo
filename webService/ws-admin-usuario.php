<?php

require_once '../pojos/persona.php';
require_once '../pojos/odontologo.php';
require_once '../pojos/paciente.php';
require_once '../pojos/funcionario.php';
require_once '../controladoras/controladorapersonaregioncomuna.php';
require_once '../controladoras/controladoradoctor.php';
require_once '../controladoras/controladorapaciente.php';
require_once '../controladoras/controladorafuncionario.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Personas, Ododntologos, Funcionario, Pacientes
*Opciones:
* 1.- insertar Persona
* 2.- insertar Odontologo
* 3.- insertar Paciente
* 4.- insertar Funcionario
* 5.- modificarPersona
* 6.- modificar Odontologo
* 7.- modificar Paciente
* 8.- modificar Funcionario
* 9.- desabilitar Paciente
* 10 .- desabilitar Odontologo
* 11.- desabilitar Funcionario
* 12.- Listar Personas
* 13.- Listar Paciente
* 14.- Listar Funcionario
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};


switch ($opcion) 
{
	case 1:
		//json Insertar Persona {"indice":1,"idPerfil":1,"rut":17897359,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12"}
		$idPerfil = $data->{'idPerfil'};
		$rut = $data->{'rut'};
		$dv = $data->{'dv'};
		$nombre = $data->{'nombre'};
		$appPateno = $data->{'appPaterno'};
		$appMaterno = $data->{'appMaterno'};
		$fechaNac = $data->{'fechaNac'};
		$persona = new Persona();
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$persona->initClass(0, $idPerfil, $rut, $dv, $nombre, $appPateno, $appMaterno, $fechaNac);
		$arreglo["idPersonaInsertada"] = $controladoraPersona->insertarPersona($persona);	
		//Retorna {"idPersonaInsertada":id};	
		echo(json_encode($arreglo));
	break;
	case 2:
		//json Insertar Odontologo {"indice":2,"idPersona":1,"especialidad":"Cirugia"}
		$idPersona = $data->{'idPersona'};
		$especialidad = $data->{'especialidad'};
		$odontologo = new Odontologo();
		$controladoraOdontologo = new ControladoraDoctor();
		$odontologo->initClass(0, $idPersona, $especialidad);
		$arreglo["idOdontologoInsertado"] = $controladoraOdontologo->InsertarDoctor($odontologo);
		echo(json_encode($arreglo));
		
	break;
	case 3:
		//json Insertar Paciente {"indice":3,"idPersona":1,"fechaIngreso":"2013-04-12"}
		$idPersona = $data->{"idPersona"};
		$fechaIngreso = $data->{"fechaIngreso"};
		$paciente = new Paciente();
		$controladoraPaciente  = new ControladoraPaciente();
		$paciente->initClass(0, $idPersona, $fechaIngreso);
		$arreglo["idPacienteInsertado"] = $controladoraPaciente->insertarPaciente($paciente);
		echo(json_encode($arreglo));
	break;
	case 4:
		//json Insertar Funcionario {"indice":4,"idPersona":1,"puestoTrabajo":"Administrador"}
		$idPersona = $data->{"idPersona"};
		$puestoTrabajo = $data->{"puestoTrabajo"};
		$funcionario = new Funcionario();
		$controladoraFuncionario = new ControladoraFuncionario();
		$funcionario->initClass(0, $idPersona, $puestoTrabajo);
		$arreglo["idFuncionarioInsertado"] = $controladoraFuncionario->insertarFuncionario($funcionario);
		echo(json_encode($arreglo));
	break;
	case 5:
		//json Modificar Persona {"indice":5,"idPersona":20,"idPerfil":1,"rut":11111111,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12"}
		$idPersona = $data->{'idPersona'};
		$idPerfil = $data->{'idPerfil'};
		$rut = $data->{'rut'};
		$dv = $data->{'dv'};
		$nombre = $data->{'nombre'};
		$appPateno = $data->{'appPaterno'};
		$appMaterno = $data->{'appMaterno'};
		$fechaNac = $data->{'fechaNac'};
		$persona = new Persona();
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$persona->initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $appPateno, $appMaterno, $fechaNac);
		$arreglo["resultado"] = $controladoraPersona->modificarPersona($persona);	
		echo (json_encode($arreglo));
	break;
	case 6:
	
	break;
	case 7:
	
	break;
	case 8:
	
	break;
	case 9:
	
	break;
	case 10:
	
	break;
	case 11:
	
	break;
	case 12:
	
	break;
	case 13:
	
	break;
	case 14:
	
	break;
}
 
?>