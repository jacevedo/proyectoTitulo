<?php

require_once '../pojos/fichadental.php';
require_once '../pojos/presupuesto.php';
require_once '../controladoras/controladorafichapresupuesto.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Fichas y presupuestos
*Opciones:
*Opciones:
* 1.- insertar Ficha Dental
* 2.- Modificar Ficha Dental
* 3.- Buscar Ficha Por ID
* 4.- Buscar Ficha Por ID Persona
* 5.- Listar Fichas
* 6.- Deshabilitar Ficha
* 7.- insertar Presupuesto
* 8.- modificar Presupuesto
* 9.- buscar por id
* 10.- buscar por id persona
* 11.- listar Presupuestos
* 12.- Listar Ficha con nombres
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};


switch ($opcion) 
{
	case 1:
		//json Insertar Ficha {"indice":1,"idPaciente":1,"idOdontologo":1,"fechaIngreso":"1991-12-12","anamnesis":"Penisilina","habilitada":0}
		$idPaciente = $data->{'idPaciente'};
		$idOdontologo = $data->{'idOdontologo'};
		$fechaIngreso = $data->{'fechaIngreso'};
		$anamnesis = $data->{'anamnesis'};
		$habilitada = $data->{'habilitada'};
		$fichaDental = new FichaDental();
		$fichaDental->initClass(0, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,$habilitada);
		$controladoraFicha = new ControladoraFichaPresupuesto();
		$arreglo["code"]=1;
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
		$fichaDental->initClass($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,0);
		$controladoraFicha = new ControladoraFichaPresupuesto();
		$arreglo["code"]=2;
		$arreglo["Resultado"] = $controladoraFicha->modificarFicha($fichaDental);
		echo(json_encode($arreglo));
	break;
	case 3:
		//json Buscar Ficha Por Id {"indice":3,"idFicha":1}
		$idFicha = $data->{'idFicha'};
		$controladoraFicha = new ControladoraFichaPresupuesto();
		$arreglo["code"]=3;
		$arreglo["FichaPorID"] = $controladoraFicha->buscarFichaPorId($idFicha);
		echo(json_encode($arreglo));
	break;
	case 4:
		//json Buscar Ficha Por Id Persona {"indice":4,"idPersona":1}
		$idPersona = $data->{'idPersona'};
		$controladoraFicha = new ControladoraFichaPresupuesto();
		$arreglo["code"]=4;
		$arreglo["FichaIdPersona"] = $controladoraFicha->buscarFichaPorIdPersona($idPersona);
		echo(json_encode($arreglo));
	break;
	case 5:
		//json Listar Ficha {"indice":5}
		$controladoraFicha = new ControladoraFichaPresupuesto();
		$arreglo["code"]=5;
		$arreglo["ListaFicha"] = $controladoraFicha->listarFicha();
		echo(json_encode($arreglo));
	break;
	case 6:
		//json Habilitar desabilitar Ficha {"indice":6,"idFicha":3,"habilitada":1}
		$idFicha = $data->{"idFicha"};
		$habilitada = $data->{"habilitada"};
		$controladoraFicha = new ControladoraFichaPresupuesto();
		$arreglo["code"]=6;
		$arreglo["resultado"] = $controladoraFicha->desabilitarFicha($idFicha,$habilitada);
		echo(json_encode($arreglo));
	break;
	case 7:
		//json Insertar Presupuesto {"indice":7,"idFicha":3,"valorTotal":10000,"fechaPresupuesto":"1991-12-12"}
		$idFicha = $data->{"idFicha"};
		$valorTotal = $data->{"valorTotal"};
		$fechaPresupuesto = $data->{"fechaPresupuesto"};
		$presupuesto = new Presupuesto();
		$presupuesto->initClass(0, $idFicha, $valorTotal,$fechaPresupuesto);
		$controladoraPresupuesto = new ControladoraFichaPresupuesto();
		$arreglo["code"]=7;
		$arreglo["idPresupuestoInsertado"] = $controladoraPresupuesto->insertarPresupuesto($presupuesto);
		echo(json_encode($arreglo));
	break;
	case 8:
		//json Modificar Presupuesto {"indice":8,"idPresupuesto":1,"idFicha":3,"valorTotal":10000,"fechaPresupuesto":"1991-12-12"}
		$idPresupuesto = $data->{"idPresupuesto"};
		$idFicha = $data->{"idFicha"};
		$valorTotal = $data->{"valorTotal"};
		$fechaPresupuesto = $data->{"fechaPresupuesto"};
		$presupuesto = new Presupuesto();
		$presupuesto->initClass($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto);
		$controladoraPresupuesto = new ControladoraFichaPresupuesto();
		$arreglo["code"]=8;
		$arreglo["modificado"] = $controladoraPresupuesto->modificarPresupuesto($presupuesto);
		echo(json_encode($arreglo));
	break;
	case 9:
		//json buscar Presupuesto por id {"indice":9,"idPresupuesto":1}
		$idPresupuesto = $data->{"idPresupuesto"};
		$controladoraPresupuesto = new ControladoraFichaPresupuesto();
		$arreglo["code"]=9;
		$arreglo["PresupuestoID"] = $controladoraPresupuesto->buscarPresupuestoPorId($idPresupuesto);
		echo(json_encode($arreglo));
	break;
	case 10:
		//json buscar Presupuesto por id Paciente {"indice":10,"idPaciente":3}
		$idPaciente = $data->{"idPaciente"};
		$controladoraPresupuesto = new ControladoraFichaPresupuesto();
		$arreglo["code"]=10;
		$arreglo["PresupuestoIDPaciente"] = $controladoraPresupuesto->buscarPresupuestoPorIdPersona($idPaciente);
		echo(json_encode($arreglo));
	break;
	case 11:
		//json Listar Presupuestos {"indice":11}
		$idPaciente = $data->{"idPaciente"};
		$controladoraPresupuesto = new ControladoraFichaPresupuesto();
		$arreglo["code"]=11;
		$arreglo["listarPresupuesto"] = $controladoraPresupuesto->listarPresupuesto();
		echo(json_encode($arreglo));
	break;
	case 12:
		//json Listar Ficha {"indice":12}
		$controladoraFicha = new ControladoraFichaPresupuesto();
		$arreglo["code"]=12;
		$arreglo["ListaFicha"] = $controladoraFicha->listarFichaNombres();
		echo(json_encode($arreglo));
		break;
	case 13:
		//json Listar Ficha con nombre Y apellido Paciente {"indice":13}
		$idPaciente = $data->{"idPaciente"};
		$controladoraPresupuesto = new ControladoraFichaPresupuesto();
		$arreglo["code"]=13;
		$arreglo["PresupuestoIDPaciente"] = $controladoraPresupuesto->listaPersonaFicha();
		echo(json_encode($arreglo));
		break;
	case 14:
		//json buscar Presupuesto por id Ficha {"indice":14,"idFicha":3}
		$idFicha = $data->{"idFicha"};
		$controladoraPresupuesto = new ControladoraFichaPresupuesto();
		$arreglo["code"]=14;
		$arreglo["PresupuestoIDPaciente"] = $controladoraPresupuesto->buscarPresupuestoIdFicha($idFicha);
		echo(json_encode($arreglo));
	break;
}
 
?>