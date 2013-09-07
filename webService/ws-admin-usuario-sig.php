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
		echo(json_encode($controladoraPersona->buscarPorRut($rut, $dv)));
	break;
	case 2:
		//json Buscar Persona Por Nombre {"indice":2,"nomPersona":"Jaime","appPersona":"Acevedo"}
		$nomPersona = $data->{'nomPersona'};
		$appPersona = $data->{'appPersona'};
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		echo(json_encode($controladoraPersona->buscarPorNombre($nomPersona, $appPersona)));
		
	break;
	case 3:
		//json Buscar Funcionario Por Rut {"indice":3,"rut":9878987}
		$rut = $data->{'rut'};
		$controladorafuncionario = new ControladoraFuncionario();
		echo(json_encode($controladorafuncionario->buscarFuncionarioPorRut($rut)));
		
	break;
	case 4:
		//json Buscar Funcionario Por Rut {"indice":4,"nombre":"Nicolas","apellido":"Palma"}
		$nombre = $data->{'nombre'};
		$apellido = $data->{'apellido'};
		$controladorafuncionario = new ControladoraFuncionario();
		echo(json_encode($controladorafuncionario->buscarFuncionarioPorNombre($nombre, $apellido)));
		
	break;
}
 
?>