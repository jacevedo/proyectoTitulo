<?php

require_once '../pojos/ordenlaboratorio.php';
require_once '../controladoras/controladoraordenlaboratorio.php';
require_once '../controladoras/encript.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Orden de Laboratorio
*Opciones:
* 1.- insertar Orden
* 2.- modificar Orden
* 3.- modificar estado Orden
* 4.- listar Ordees
* 5.- buscar por id Orden
* 6.- buscar por clinica Orden
* 7.- buscar por fecha entrega Orden
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
		//json Insertar Orden {"indice":1,"idOdontologo":1,"idPaciente":1,"numOrden":123123,"clinica":"Santa Ana","bd":"10","bi":"11","pd":"20","pi":"21","fechaCreacion":"2013-09-26","fechaEntrega":"2013-09-26","horaEntrega":"16:00","color":"Blanco","estado":"Recibida"}
		$idOdontologo = $data->{"idOdontologo"};
		$idPaciente = $data->{"idPaciente"};
		$numOrden = $data->{"numOrden"};
		$clinica = $data->{'clinica'};
		$bd = $data->{'bd'};
		$bi = $data->{'bi'};
		$pd = $data->{'pd'};
		$pi = $data->{'pi'};
		$fechaCreacion = $data->{"fechaCreacion"};
		$fechaEntrega = $data->{'fechaEntrega'};
		$horaEntrega = $data->{'horaEntrega'};
		$color = $data->{'color'};
		$estado = $data->{'estado'};


		$orden = new OrdenLaboratorio();
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		$orden->initClass(0, $idOdontologo,$idPaciente, $numOrden,$clinica, $bd, $bi, $pd, $pi,$fechaCreacion, $fechaEntrega, $horaEntrega, $color, $estado,"","");
		$arreglo["code"] =1;
		$arreglo["idOrdenInsertada"] = $controladoraOrden->insertarOrden($orden);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 2:
		//json Modificar Orden {"indice":2,"idOrden":5,"idOdontologo":3,"idPaciente":2,"numOrden":1,"clinica":"Santa","bd":"10","bi":"11","pd":"20","pi":"21","fechaCreacion":"2013-08-26","fechaEntrega":"2013-09-26","horaEntrega":"16:00","color":"Blanco","estado":"Recibida"}
		$idOrden = $data->{'idOrden'};
		$idOdontologo = $data->{"idOdontologo"};
		$idPaciente = $data->{"idPaciente"};
		$numOrden = $data->{"numOrden"};
		$clinica = $data->{'clinica'};
		$bd = $data->{'bd'};
		$bi = $data->{'bi'};
		$pd = $data->{'pd'};
		$pi = $data->{'pi'};
		$fechaCreacion = $data->{"fechaCreacion"};
		$fechaEntrega = $data->{'fechaEntrega'};
		$horaEntrega = $data->{'horaEntrega'};
		$color = $data->{'color'};
		$estado = $data->{'estado'};

		$orden = new OrdenLaboratorio();
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		$orden->initClass($idOrden, $idOdontologo,$idPaciente, $numOrden,$clinica, $bd, $bi, $pd, $pi,$fechaCreacion, $fechaEntrega, $horaEntrega, $color, $estado,"","");
		$arreglo["code"] = 2;
		$arreglo["resultado"] = $controladoraOrden->modificarOrden($orden);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 3:
		//json Modificar Estado Orden {"indice":3,"idOrden":1,"estado":"Rechazada"}
		$orden = new OrdenLaboratorio();
		$idOrden = $data->{'idOrden'};
		$estado = $data->{'estado'};
		$orden->idOrdenLaboratorio = $idOrden;
		$orden->estado = $estado;
		
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		$arreglo["code"] = 3;
		$arreglo["ModificadoEstado"] = $controladoraOrden->modificarEstadoOrden($orden);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 4:
		//json Listar Orden {"indice":4}
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		$arreglo["code"] = 4;
		$arreglo["ListadoOrden"] = $controladoraOrden->listarOrdenes();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 5:
		//json Buscar Orden Por Id {"indice":5,"idOrden":1}
		$idOrden = $data->{'idOrden'};
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		$arreglo["code"] = 5;
		$arreglo["OrdenPorId"] = $controladoraOrden->buscarOrdenPorId($idOrden);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 6:
		//json Buscar Orden Por Clinica {"indice":6,"clinica":"Santa Ana"}
		$clinica = $data->{'clinica'};
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		$arreglo["code"] = 6;
		$arreglo["ordenPorNombreClinica"] = $controladoraOrden->buscarOrdenPorClinica($clinica);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 7:
		//json Buscar Orden Por Fecha Entrega {"indice":7,"fechaEntrega":"2013-10-26"}
		$fechaEntrega = $data->{'fechaEntrega'};
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		$arreglo["code"] = 7;
		$arreglo["ordenPorFechaEntrega"] = $controladoraOrden->buscarOrdenPorFechaEntrega($fechaEntrega);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
}

?>