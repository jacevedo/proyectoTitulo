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
		echo(json_encode($controladoraPersona->buscarPorRut($rut, $dv);));
	break;
	case 2:
		//json Buscar Persona Por Nombre {"indice":2,"nomPersona":"Jaime","appPersona":"Acevedo"}
		$nomPersona = $data->{'nomPersona'};
		$appPersona = $data->{'appPersona'};
		$controladoraOdontologo = new ControladoraDoctor();
		echo(json_encode($controladoraOdontologo->buscarPorNombre($nomPersona, $appPersona)));
		
	break;
}
 
?>