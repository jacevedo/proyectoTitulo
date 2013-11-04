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
* 1.- Buscar Persona Por Rut
* 2.- Buscar Persona Por Nombre
* 3.- Buscar Funcionario Por Rut
* 4.- Buscar Funcionario Por Nombre Apellido
* 5.- Buscar Paciente Por Rut
* 6.- Buscar Paciente Por Nombre Apellido
* 7.- Buscar Odontologo Por Rut
* 8.- Buscar Odontologo Por Nombre Apellido
* 9.- Listar Personas id nombre
* 11.- Buscar Persona por id
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};


switch ($opcion) 
{
	case 1:
		//json Buscar Persona Por Rut {"indice":1,"rut":17897359,"dv":2}
		$rut = $data->{'rut'};
		$dv = $data->{'dv'};
		$controladoraPersona = new ControladoraPersonaRegionComuna();	
		$arreglo["code"] = 1;
		$arreglo["listaPersonaRut"] = $controladoraPersona->buscarPorRut($rut, $dv);	
		echo(json_encode($arreglo));
	break;
	case 2:
		//json Buscar Persona Por Nombre {"indice":2,"nomPersona":"Jaime","appPersona":"Acevedo"}
		$nomPersona = $data->{'nomPersona'};
		$appPersona = $data->{'appPersona'};
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 2;
		$arreglo["busquedaPersonaNombre"] = $controladoraPersona->buscarPorNombre($nomPersona, $appPersona);
		echo(json_encode($arreglo));
		
	break;
	case 3:
		//json Buscar Funcionario Por Rut {"indice":3,"rut":9878987}
		$rut = $data->{'rut'};
		$controladorafuncionario = new ControladoraFuncionario();
		$arreglo["code"] = 3;
		$arreglo["listaFuncionarioRut"] = $controladorafuncionario->buscarFuncionarioPorRut($rut);
		echo(json_encode($arreglo));
		
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
			echo(json_encode($arreglo));
		}
		
	break;
	case 5:
		//json Buscar Paciente Por Rut {"indice":5,"rut":17231233}
		$rut = $data->{'rut'};
		
		$controladoraPaciente = new ControladoraPaciente();
		$arreglo["code"] = 5;
		$arreglo["buscarPacienteRut"] = $controladoraPaciente->buscarPacientePorRut($rut);
		echo(json_encode($arreglo));
		
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
			echo(json_encode($arreglo));
		}
		
	break;
	case 7:
		//json Buscar Odontologo Por Rut {"indice":7,"rut":15725009}
		$rut = $data->{'rut'};
		$controladoraOdontologo = new ControladoraDoctor();
		$arreglo["code"] = 7;
		$arreglo["buscarOdontologoRut"] = $controladoraOdontologo->buscarOdontologoPorRut($rut);
		echo(json_encode($arreglo));
		
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
			echo(json_encode($arreglo));
		}
		
	break;
	case 9:
		//json Listar paciente con id nombre y apellido {"indice":9}
		$controladoraPaciente = new ControladoraPaciente();
		$arreglo["code"] = 9;
		$arreglo["listaPersonas"] = $controladoraPaciente->listarPacientesNomID();
		echo(json_encode($arreglo));
	break;
	case 10:
		//json Listar odontologo con id nombre y apellido {"indice":10}
		$controladoraPaciente = new ControladoraDoctor();
		$arreglo["code"] = 9;
		$arreglo["listaPersonas"] = $controladoraPaciente->listarOdontologoIdNombre();
		echo(json_encode($arreglo));
	break;
	case 11:
		//json Listar odontologo con id nombre y apellido {"indice":10,"idPersona":8}
		$idPersona = $data->{"idPersona"};
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 11;
		$arreglo["listaPersonas"] = $controladoraPersona->buscarPorId($idPersona);
		echo(json_encode($arreglo));
	break;
}
 
?>