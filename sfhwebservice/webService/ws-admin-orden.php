<?php

require_once '../pojos/ordenlaboratorio.php';
require_once '../controladoras/controladoraordenlaboratorio.php';

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
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};

switch ($opcion) 
{
	case 1:
		//json Insertar Orden {"indice":1,"clinica":"Santa Ana","bd":"10","bi":"11","pd":"20","pi":"21","fechaEntrega":"2013-09-26","horaEntrega":"16:00","color":"Blanco","estado":"Recibida"}
		$clinica = $data->{'clinica'};
		$bd = $data->{'bd'};
		$bi = $data->{'bi'};
		$pd = $data->{'pd'};
		$pi = $data->{'pi'};
		$fechaEntrega = $data->{'fechaEntrega'};
		$horaEntrega = $data->{'horaEntrega'};
		$color = $data->{'color'};
		$estado = $data->{'estado'};

		$orden = new OrdenLaboratorio();
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		$orden->initClass(0, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color, $estado);
		$arreglo["idOrdenInsertada"] = $controladoraOrden->insertarOrden($orden);
		echo(json_encode($arreglo));
	break;
	case 2:
		//json Modificar Orden {"indice":2,"idOrden":1,"clinica":"Santa Ana","bd":"10","bi":"11","pd":"20","pi":"21","fechaEntrega":"2013-10-26","horaEntrega":"14:00","color":"Blanco"}
		$idOrden = $data->{'idOrden'};
		$clinica = $data->{'clinica'};
		$bd = $data->{'bd'};
		$bi = $data->{'bi'};
		$pd = $data->{'pd'};
		$pi = $data->{'pi'};
		$fechaEntrega = $data->{'fechaEntrega'};
		$horaEntrega = $data->{'horaEntrega'};
		$color = $data->{'color'};

		$orden = new OrdenLaboratorio();
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		$orden->initClass($idOrden, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color, "Recibida");
		$arreglo["resultado"] = $controladoraOrden->modificarOrden($orden);
		echo(json_encode($arreglo));
	break;
	case 3:
		//json Modificar Estado Orden {"indice":3,"idOrden":1,"estado":"Rechazada"}
		$orden = new OrdenLaboratorio();
		$idOrden = $data->{'idOrden'};
		$estado = $data->{'estado'};
		$orden->idOrdenLaboratorio = $idOrden;
		$orden->estado = $estado;
		
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		echo(json_encode($controladoraOrden->modificarEstadoOrden($orden)));
	break;
	case 4:
		//json Listar Orden {"indice":4}
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		echo(json_encode($controladoraOrden->listarOrdenes()));
	break;
	case 5:
		//json Buscar Orden Por Id {"indice":5,"idOrden":1}
		$idOrden = $data->{'idOrden'};
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		echo(json_encode($controladoraOrden->buscarOrdenPorId($idOrden)));
	break;
	case 6:
		//json Buscar Orden Por Clinica {"indice":6,"clinica":"Santa Ana"}
		$clinica = $data->{'clinica'};
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		echo(json_encode($controladoraOrden->buscarOrdenPorClinica($clinica)));
	break;
	case 7:
		//json Buscar Orden Por Fecha Entrega {"indice":7,"fechaEntrega":"2013-10-26"}
		$fechaEntrega = $data->{'fechaEntrega'};
		$controladoraOrden = new ControladoraOrdenLaboratorio();
		echo(json_encode($controladoraOrden->buscarOrdenPorFechaEntrega($fechaEntrega)));
	break;
}

?>