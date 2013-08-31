<?php
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

echo($opcion);
switch ($opcion) 
{
	case 1:
		# code...
		break;
	case 2:
		break;
	case 3:
		break;
	case 4:
		break;
	case 5:
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