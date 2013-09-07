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
* 14.- Listar Odontologo
* 15.- Listar Funcionario
* 16.- Listar Pacientes Herencia
* 17.- Listar Odontologo Herencia
* 18.- Listar Funcionario Herencia
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
		//json Insertar Odontologo {"indice":2,"idPersona":1,"especialidad":"Cirugia","habilitado":1}
		$idPersona = $data->{'idPersona'};
		$especialidad = $data->{'especialidad'};
		$habilitado = $data->{'habilitado'};
		$odontologo = new Odontologo();
		$controladoraOdontologo = new ControladoraDoctor();
		$odontologo->initClass(0, $idPersona, $especialidad,$habilitado);
		$arreglo["idOdontologoInsertado"] = $controladoraOdontologo->InsertarDoctor($odontologo);
		echo(json_encode($arreglo));
		
	break;
	case 3:
		//json Insertar Paciente {"indice":3,"idPersona":1,"fechaIngreso":"2013-04-12","habilitado":1}
		$idPersona = $data->{"idPersona"};
		$fechaIngreso = $data->{"fechaIngreso"};
		$habilitado = $data->{"habilitado"};
		$paciente = new Paciente();
		$controladoraPaciente  = new ControladoraPaciente();
		$paciente->initClass(0, $idPersona, $fechaIngreso,$habilitado);
		$arreglo["idPacienteInsertado"] = $controladoraPaciente->insertarPaciente($paciente);
		echo(json_encode($arreglo));
	break;
	case 4:
		//json Insertar Funcionario {"indice":4,"idPersona":1,"puestoTrabajo":"Administrador","habilitado":1}
		$idPersona = $data->{"idPersona"};
		$puestoTrabajo = $data->{"puestoTrabajo"};
		$funcionarioHabilitado = $data->{"habilitado"};
		$funcionario = new Funcionario();
		$controladoraFuncionario = new ControladoraFuncionario();
		$funcionario->initClass(0, $idPersona, $puestoTrabajo,$funcionarioHabilitado);
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
		//json Modificar Odontologo {"indice":6,"idOdontologo":2,idPersona":1,"especialidad":"Cirugia"}
		$idOdontologo = $data->{'idOdontologo'};
		$idPersona = $data->{'idPersona'};
		$especialidad = $data->{'especialidad'};
		$odontologo = new Odontologo();
		$controladoraOdontologo = new ControladoraDoctor();
		$odontologo->initClass($idOdontologo, $idPersona, $especialidad);
		$arreglo["resultado"] = $controladoraOdontologo->modificarDoctor($odontologo);
		echo(json_encode($arreglo));
	break;
	case 7:
		//json Modificar Paciente {"indice":3,"idPaciente":1,"idPersona":1,"fechaIngreso":"2013-04-12"}
		$idPaciente = $data->{"idPaciente"};
		$idPersona = $data->{"idPersona"};
		$fechaIngreso = $data->{"fechaIngreso"};
		$paciente = new Paciente();
		$controladoraPaciente  = new ControladoraPaciente();
		$paciente->initClass($idPaciente, $idPersona, $fechaIngreso);
		$arreglo["resultado"] = $controladoraPaciente->modificarPacientes($paciente);
		echo(json_encode($arreglo));
	break;
	case 8:
		//json Modificar Funcionario {"indice":4,"idFuncionario":2,"idPersona":1,"puestoTrabajo":"Administrador"}
		$idFuncionario = $data->{"idFuncionario"};
		$idPersona = $data->{"idPersona"};
		$puestoTrabajo = $data->{"puestoTrabajo"};
		$funcionario = new Funcionario();
		$controladoraFuncionario = new ControladoraFuncionario();
		$funcionario->initClass($idFuncionario, $idPersona, $puestoTrabajo,1);
		$arreglo["resultado"] = $controladoraFuncionario->insertarFuncionario($funcionario);
		echo(json_encode($arreglo));
	break;
	case 9:
		//json ListarPaciente{"indice":9,"idPaciente":1,"habilitado":1}
		$paciente = new Paciente();
		$paciente->idPaciente = $data->{"idPaciente"};
		$paciente->habilitadoPaciente = $data->{"habilitado"};
		$controladoraPaciente = new ControladoraPaciente();
		echo(json_encode($controladoraPaciente->habilitarDesabilitarPaciente($paciente)));
	break;
	case 10:
	
	break;
	case 11:
		//json Desabilitar Funcionario {"indice":11,"idFuncionario":2,"isDesabilitado":0}
		$idFuncionario = $data->{"idFuncionario"};
		$funcionarioHabilitado = $data->{"habilitado"};
		$funcionario = new Funcionario();
		$controladoraFuncionario = new ControladoraFuncionario();
		$funcionario->initClass($idFuncionario, "", "",$funcionarioHabilitado);
		$arreglo["resultado"] = $controladoraFuncionario->desabilitarFuncionario($funcionario);
		echo(json_encode($arreglo));
	break;
	case 12:
		//json ListarPersonas {"indice":12}
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		echo(json_encode($controladoraPersona->listarPersonas()));
	break;
	case 13:
		//json ListarPaciente{"indice":13}
		$controladoraPaciente = new ControladoraPaciente();
		echo(json_encode($controladoraPaciente->listarPacientes()));
	break;
	case 14:
		//json ListarOdontologo {"indice":14}
		$controladoraOdontologo = new ControladoraDoctor();
		echo(json_encode($controladoraOdontologo->listarDoctores()));
	break;
	case 15:
		//json ListarFuncionario {"indice":15}
		$controladoraFuncionario = new ControladoraFuncionario();
		echo(json_encode($controladoraFuncionario->listarFuncionario()));
	break;
	case 16:
		//json Paciente Herencia {"indice":16}
		$controladoraPaciente = new ControladoraPaciente();
		echo(json_encode($controladoraPaciente->listarPacientesPersona()));
	break;
	case 17:
		//json Listar Odontologo Herencia {"indice":17}
		$controladoraOdontologo = new ControladoraDoctor();
		echo(json_encode($controladoraOdontologo->listarDoctoresPersona()));
	break;
	case 18:
		//json Listar Funcionaro Herencia {"indice":16}
		$controladoraFuncionario = new ControladoraFuncionario();
		echo(json_encode($controladoraFuncionario->listarFuncionarioHerencia()));
	break;
}
 
?>