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
	
}
 
?>