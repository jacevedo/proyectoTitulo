<?php

require_once '../pojos/persona.php';
require_once '../pojos/odontologo.php';
require_once '../pojos/paciente.php';
require_once '../pojos/funcionario.php';
require_once '../pojos/pass.php';
require_once '../controladoras/controladorapersonaregioncomuna.php';
require_once '../controladoras/controladoradoctor.php';
require_once '../controladoras/controladorapaciente.php';
require_once '../controladoras/controladorafuncionario.php';
require_once '../controladoras/controladorapass.php';
require_once '../controladoras/encript.php';

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
* 13.- Listar Pacientes
* 14.- Listar Odontologo 
* 15.- Listar Funcionario 
* 16.- Listar Pacientes Herencia
* 17.- Listar Odontologo Herencia
* 18.- Listar Funcionario Herencia
* Para habilitado 0, desabilitado 1
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
		$arreglo["code"] = 1;
		$arreglo["idPersonaInsertada"] = $controladoraPersona->insertarPersona($persona);	

		//Retorna {"idPersonaInsertada":id};	
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 2:
		//json Insertar Odontologo {"indice":2,"idPersona":1,"especialidad":"Cirugia","habilitado":1}
		$idPersona = $data->{'idPersona'};
		$especialidad = $data->{'especialidad'};
		$habilitado = $data->{'habilitado'};
		$odontologo = new Odontologo();
		$controladoraOdontologo = new ControladoraDoctor();
		$odontologo->initClassOdontologo(0, $idPersona, $especialidad,$habilitado);
		$arreglo["code"] = 2;
		$arreglo["idOdontologoInsertado"] = $controladoraOdontologo->InsertarDoctor($odontologo);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
		
	break;
	case 3:
		//json Insertar Paciente {"indice":3,"idPersona":1,"fechaIngreso":"2013-04-12","habilitado":1}
		$idPersona = $data->{"idPersona"};
		$fechaIngreso = $data->{"fechaIngreso"};
		$habilitado = $data->{"habilitado"};
		$paciente = new Paciente();
		$controladoraPaciente  = new ControladoraPaciente();
		$paciente->initClassPaciente(0, $idPersona, $fechaIngreso,$habilitado);
		$arreglo["code"] = 3;
		$arreglo["idPacienteInsertado"] = $controladoraPaciente->insertarPaciente($paciente);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 4:
		//json Insertar Funcionario {"indice":4,"idPersona":1,"puestoTrabajo":"Administrador","habilitado":1}
		$idPersona = $data->{"idPersona"};
		$puestoTrabajo = $data->{"puestoTrabajo"};
		$funcionarioHabilitado = $data->{"habilitado"};
		$funcionario = new Funcionario();
		$controladoraFuncionario = new ControladoraFuncionario();
		$funcionario->initClassFuncionario(0, $idPersona, $puestoTrabajo,$funcionarioHabilitado);
		$arreglo["code"] = 4;
		$arreglo["idFuncionarioInsertado"] = $controladoraFuncionario->insertarFuncionario($funcionario);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
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
		$arreglo["code"] = 5;
		$arreglo["resultado"] = $controladoraPersona->modificarPersona($persona);	
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 6:
		//json Modificar Odontologo {"indice":6,"idOdontologo":2,"idPersona":1,"especialidad":"Cirugia"}
		$idOdontologo = $data->{'idOdontologo'};
		$idPersona = $data->{'idPersona'};
		$especialidad = $data->{'especialidad'};
		$odontologo = new Odontologo();
		$controladoraOdontologo = new ControladoraDoctor();
		$odontologo->initClassOdontologo($idOdontologo, $idPersona, $especialidad,0);
		$arreglo["code"] = 6;
		$arreglo["resultado"] = $controladoraOdontologo->modificarDoctor($odontologo);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 7:
		//json Modificar Paciente {"indice":7,"idPaciente":1,"idPersona":1,"fechaIngreso":"2013-04-12"}
		$idPaciente = $data->{"idPaciente"};
		$idPersona = $data->{"idPersona"};
		$fechaIngreso = $data->{"fechaIngreso"};
		$paciente = new Paciente();
		$controladoraPaciente  = new ControladoraPaciente();
		$paciente->initClassPaciente($idPaciente, $idPersona, $fechaIngreso,0);
		$arreglo["code"] = 7;
		$arreglo["resultado"] = $controladoraPaciente->modificarPacientes($paciente);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 8:
		//json Modificar Funcionario {"indice":8,"idFuncionario":2,"idPersona":1,"puestoTrabajo":"Administrador"}
		$idFuncionario = $data->{"idFuncionario"};
		$idPersona = $data->{"idPersona"};
		$puestoTrabajo = $data->{"puestoTrabajo"};
		$funcionario = new Funcionario();
		$controladoraFuncionario = new ControladoraFuncionario();
		$funcionario->initClassFuncionario($idFuncionario, $idPersona, $puestoTrabajo,1);
		$arreglo["code"] = 8;
		$arreglo["resultado"] = $controladoraFuncionario->modificarFuncionario($funcionario);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 9:
		//json desabilitarHabilitarPaciente {"indice":9,"idPaciente":1,"habilitado":1}
		$paciente = new Paciente();
		$paciente->idPaciente = $data->{"idPaciente"};
		$paciente->habilitadoPaciente = $data->{"habilitado"};
		$controladoraPaciente = new ControladoraPaciente();
		$arreglo["code"] = 9;
		$arreglo["resutadoHabilitar"] = $controladoraPaciente->habilitarDesabilitarPaciente($paciente);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 10:
		//json desabilitarHabilitarOdontologo {"indice":10,"idOdontologo":1,"habilitado":1}
		$odontologo = new Odontologo();
		$odontologo->idOdontologo = $data->{"idOdontologo"};
		$odontologo->odontologoHabilitado = $data->{"habilitado"};
		$controladoraOdontologo = new ControladoraDoctor();
		$arreglo["code"] = 10;
		$arreglo["resutadoHabilitar"] = $controladoraOdontologo->habilitarDesabilitarOdontologo($odontologo);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 11:
		//json Desabilitar Funcionario {"indice":11,"idFuncionario":2,"isDesabilitado":0}
		$idFuncionario = $data->{"idFuncionario"};
		$funcionarioHabilitado = $data->{"habilitado"};
		$funcionario = new Funcionario();
		$controladoraFuncionario = new ControladoraFuncionario();
		$funcionario->initClassFuncionario($idFuncionario, "", "",$funcionarioHabilitado);
		$arreglo["code"] = 11;
		$arreglo["resutadoHabilitar"] = $controladoraFuncionario->desabilitarFuncionario($funcionario);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 12:
		//json ListarPersonas {"indice":12}
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 12;
		$arreglo["listaPersonas"] = $controladoraPersona->listarPersonas();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 13:
		//json ListarPaciente{"indice":13}
		$controladoraPaciente = new ControladoraPaciente();
		$arreglo["code"] = 13;
		$arreglo["listaPacientes"] = $controladoraPaciente->listarPacientes();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 14:
		//json ListarOdontologo {"indice":14}
		$controladoraOdontologo = new ControladoraDoctor();
		$arreglo["code"] = 14;
		$arreglo["listaOdontologos"] = $controladoraOdontologo->listarDoctores();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 15:
		//json ListarFuncionario {"indice":15}
		$controladoraFuncionario = new ControladoraFuncionario();
		$arreglo["code"] = 15;
		$arreglo["listaFuncionarios"] = $controladoraFuncionario->listarFuncionario();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 16:
		//json Paciente Herencia {"indice":16}
		$controladoraPaciente = new ControladoraPaciente();
		$arreglo["code"] = 16;
		$arreglo["listaPacienteHerencia"] = $controladoraPaciente->listarPacientesPersona();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 17:
		//json Listar Odontologo Herencia {"indice":17}
		$controladoraOdontologo = new ControladoraDoctor();
		$arreglo["code"] = 17;
		$arreglo["listaOdontologoHerencia"] = $controladoraOdontologo->listarDoctoresPersona();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 18:
		//json Listar Funcionaro Herencia {"indice":18}
		$controladoraFuncionario = new ControladoraFuncionario();
		$arreglo["code"] = 18;
		$arreglo["listaFuncionarioHerencia"] = $controladoraFuncionario->listarFuncionarioHerencia();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;

}
 
?>