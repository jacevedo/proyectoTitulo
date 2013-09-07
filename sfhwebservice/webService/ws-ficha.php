<?php

require_once '../pojos/fichadental.php';
require_once '../controladoras/controladorafichapresupuesto.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Personas, Ododntologos, Funcionario, Pacientes
*Opciones:
* 1.- insertar Ficha Dental
* 2.- Modificar Ficha Dental
* 3.- Buscar Ficha Por ID
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};


switch ($opcion) 
{
	case 1:
		//json Insertar Ficha {"indice":1,"idPaciente":1,"idOdontologo":1,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina"}
		$idPaciente = $data->{'idPaciente'};
		$idOdontologo = $data->{'idOdontologo'};
		$fechaIngreso = $data->{'fechaIngreso'};
		$anamnesis = $data->{'anamnesis'};
		$fichaDental = new FichaDental();
		$fichaDental->initClass(0, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis);
		$controladoraFicha = new ControladoraFichaPresupuesto();
		$arreglo["idFichaInsertada"] = $controladoraFicha->insertarFicha($fichaDental);
		echo(json_encode($arreglo));
	break;
	case 2:
		//json Modificar Ficha {"indice":2,"idFicha":1,"idPaciente":1,"idOdontologo":1,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina"}
		$idFicha = $data->{'idFicha'};
		$idPaciente = $data->{'idPaciente'};
		$idOdontologo = $data->{'idOdontologo'};
		$fechaIngreso = $data->{'fechaIngreso'};
		$anamnesis = $data->{'anamnesis'};
		$fichaDental = new FichaDental();
		$fichaDental->initClass($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis);
		$controladoraFicha = new ControladoraFichaPresupuesto();
		$arreglo["Resultado"] = $controladoraFicha->modificarFicha($fichaDental);
		echo(json_encode($arreglo));
	break;
	case 3:
		//json Modificar Ficha {"indice":3,"idFicha":1}
		$idFicha = $data->{'idFicha'};
		$controladoraFicha = new ControladoraFichaPresupuesto();
		echo(json_encode($controladoraFicha->buscarFichaPorId($idFicha)));
	break;

}
 
?>