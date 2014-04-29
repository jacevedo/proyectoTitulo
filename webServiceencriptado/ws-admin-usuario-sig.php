<?php

require_once '../pojos/persona.php';
require_once '../pojos/odontologo.php';
require_once '../pojos/paciente.php';
require_once '../pojos/funcionario.php';
require_once '../controladoras/controladorapersonaregioncomuna.php';
require_once '../controladoras/controladoradoctor.php';
require_once '../controladoras/controladorapaciente.php';
require_once '../controladoras/controladorafuncionario.php';
require_once '../controladoras/encript.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Personas, Ododntologos, Funcionario, Pacientes
*Opciones:
* 1.- Buscar Persona Por Rut
* 2.- Buscar Persona Por Nombre
* 3.- Buscar Funcionario Por Rut
* 4.- Buscar Funcionario Por Nombre Apellido
* 5.- Buscar Paciente Por Rut
* 6.- Buscar Paciente Por Nombre Apellido
* 7.- Buscar Odontologo Por Rut
* 8.- Buscar Odontologo Por Nombre Apellido
* 9.- Listar Paciente
* 10.- Listar Odontolog con Nombre e Id
* 11.- Listar Odontologo por id
* 12.- Eliminar odontologo id
* 13.- Eliminar Funcionario id
* 14.- Eliminar paciente id
* 15.- Listar Paciente Funcionarios
* 16.- Listar Persona Paciente
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
		//json Buscar Persona Por Rut {"indice":1,"rut":17897359,"dv":2}
		$rut = $data->{'rut'};
		$dv = $data->{'dv'};
		$controladoraPersona = new ControladoraPersonaRegionComuna();	
		$arreglo["code"] = 1;
		$arreglo["listaPersonaRut"] = $controladoraPersona->buscarPorRut($rut, $dv);	
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 2:
		//json Buscar Persona Por Nombre {"indice":2,"nomPersona":"Jaime","appPersona":"Acevedo"}
		$nomPersona = $data->{'nomPersona'};
		$appPersona = $data->{'appPersona'};
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 2;
		$arreglo["busquedaPersonaNombre"] = $controladoraPersona->buscarPorNombre($nomPersona, $appPersona);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
		
	break;
	case 3:
		//json Buscar Funcionario Por Rut {"indice":3,"rut":9878987}
		$rut = $data->{'rut'};
		$controladorafuncionario = new ControladoraFuncionario();
		$arreglo["code"] = 3;
		$arreglo["listaFuncionarioRut"] = $controladorafuncionario->buscarFuncionarioPorRut($rut);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
		
	break;
	case 4:
		//json Buscar Funcionario Por Nombre Apellido {"indice":4,"nombre":"Nicolas","apellido":"Palma"}
		$nombre = $data->{'nombre'};
		$apellido = $data->{'apellido'};
		if($nombre!="" && $apellido !="")
		{
			$controladorafuncionario = new ControladoraFuncionario();
			$arreglo["code"] = 4;
			$arreglo["buscarFuncionarioNombre"] = $controladorafuncionario->buscarFuncionarioPorNombre($nombre, $apellido);
			$enript = new Encript();
			$jsonEncriptado = $enript->encriptar($arreglo);
			echo($jsonEncriptado);
		}
		
	break;
	case 5:
		//json Buscar Paciente Por Rut {"indice":5,"rut":17231233}
		$rut = $data->{'rut'};
		
		$controladoraPaciente = new ControladoraPaciente();
		$arreglo["code"] = 5;
		$arreglo["buscarPacienteRut"] = $controladoraPaciente->buscarPacientePorRut($rut);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
		
	break;
	case 6:
		//json Buscar Paciente Por Nombre Apellido {"indice":6,"nombre":"Jose","apellido":"Muñoz"}
		$nombre = $data->{'nombre'};
		$apellido = $data->{'apellido'};
		if($nombre!="" && $apellido !="")
		{
			$controladoraPaciente = new ControladoraPaciente();
			$arreglo["code"] = 6;
			$arreglo["buscarPacienteNombre"] = $controladoraPaciente->buscarPacientePorNombre($nombre, $apellido);
			$enript = new Encript();
			$jsonEncriptado = $enript->encriptar($arreglo);
			echo($jsonEncriptado);
		}
		
	break;
	case 7:
		//json Buscar Odontologo Por Rut {"indice":7,"rut":15725009}
		$rut = $data->{'rut'};
		$controladoraOdontologo = new ControladoraDoctor();
		$arreglo["code"] = 7;
		$arreglo["buscarOdontologoRut"] = $controladoraOdontologo->buscarOdontologoPorRut($rut);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
		
	break;
	case 8:
		//json Buscar Odontologo Por Nombre Apellido {"indice":8,"nombre":"Camila","apellido":"Carrizo"}
		$nombre = $data->{'nombre'};
		$apellido = $data->{'apellido'};
		if($nombre!="" && $apellido !="")
		{
			$controladoraOdontologo = new ControladoraDoctor();
			$arreglo["code"] = 8;
			$arreglo["buscarOdontologoNombre"] = $controladoraOdontologo->buscarOdontologoPorNombreApellido($nombre, $apellido);
			$enript = new Encript();
			$jsonEncriptado = $enript->encriptar($arreglo);
			echo($jsonEncriptado);
		}
		
	break;
	case 9:
		//json Listar paciente con id nombre y apellido {"indice":9}
		$controladoraPaciente = new ControladoraPaciente();
		$arreglo["code"] = 9;
		$arreglo["listaPersonas"] = $controladoraPaciente->listarPacientesNomID();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 10:
		//json Listar odontologo con id nombre y apellido {"indice":10}
		$controladoraPaciente = new ControladoraDoctor();
		$arreglo["code"] = 9;
		$arreglo["listaPersonas"] = $controladoraPaciente->listarOdontologoIdNombre();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 11:
		//json Listar odontologo por id {"indice":11,"idPersona":8}
		$idPersona = $data->{"idPersona"};
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 11;
		$arreglo["listaPersonas"] = $controladoraPersona->buscarPorId($idPersona);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 12:
		//json Eliminar odontologo con id {"indice":12,"idOdontologo":1}
		$idOdontologo = $data->{"idOdontologo"};
		$controladoraOdontologo = new ControladoraDoctor();
		$arreglo["code"] = 12;
		$arreglo["resultado"] = $controladoraOdontologo->eliminarOdontologo($idOdontologo);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 13:
		//json Eliminar funcionario con id {"indice":12,"idFuncionario":1}
		$idFuncionario = $data->{"idFuncionario"};
		$controladoraFuncionario = new ControladoraFuncionario();
		$arreglo["code"] = 13;
		$arreglo["resultado"] = $controladoraFuncionario->eliminarFuncionario($idFuncionario);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 15:
		//json Listar Paciente Funcionarios {"indice":15}
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 15;
		$arreglo["resultado"] = $controladoraPersona->listarPersonasFuncionarios();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 16:
		//json Listar Persona Paciente {"indice":16}
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 16;
		$arreglo["resultado"] = $controladoraPersona->listarPersonaPorPerfil(4);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
}
 
?>