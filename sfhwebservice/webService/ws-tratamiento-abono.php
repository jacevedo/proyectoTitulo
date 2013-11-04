<?php
require_once '../pojos/tratamientodental.php';
require_once '../pojos/abono.php';
require_once '../controladoras/controladoratratamientoabono.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- insertar Tratamiento Dental 
* 2.- Modificar Tratamiento Dental
* 3.- Listar Tratamientos
* 4.- Listar Tratamientos Por ID Ficha
* 5.- insertar Abono
* 6.- Modificar Abono
* 7.- Listar Abono
* 8.- Listar Por Tratamiento
* 9.- Total Abono Paciente
* 10.- Listar Tratamientos Con total Abono
* 11.- Eliminar Abono
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json Insertar Tratamiento Dental {"indice":1,"idFicha":1,"fechaCreacion":"1991-12-12","tratamiento":"extraccion","fechaSeguimiento":"1991-12-12","valorTotal":100000}
		$idFicha = $data->{'idFicha'};
		$fechaCreacion = $data->{'fechaCreacion'};
		$tratamiento = $data->{'tratamiento'};
		$fechaSeguimiento = $data->{'fechaSeguimiento'};
		$valorTotal = $data->{'valorTotal'};
		$tratamientoDental = new TratamientoDental();
		$tratamientoDental->initClass(0, $idFicha, $fechaCreacion,$tratamiento, $fechaSeguimiento,$valorTotal);
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=1;
		$arreglo["idTratamientoInsertada"] = $controladoraFicha->insertarTratamiento($tratamientoDental);
		echo(json_encode($arreglo));
	break;
	case 2:
		//json Modificar Tratamiento Dental {"indice":2,"idTratamientoDental":1,"idFicha":1,"fechaCreacion":"1991-12-12","tratamiento":"extraccion","fechaSeguimiento":"1991-12-12","valorTotal":100000}
		$idTratamientoDental = $data->{"idTratamientoDental"};
		$idFicha = $data->{'idFicha'};
		$fechaCreacion = $data->{'fechaCreacion'};
		$tratamiento = $data->{'tratamiento'};
		$fechaSeguimiento = $data->{'fechaSeguimiento'};
		$valorTotal = $data->{'valorTotal'};
		$tratamientoDental = new TratamientoDental();
		$tratamientoDental->initClass($idTratamientoDental, $idFicha, $fechaCreacion,$tratamiento, $fechaSeguimiento,$valorTotal);
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=2;
		$arreglo["Resultado"] = $controladoraFicha->modificarTratamiento($tratamientoDental);
		echo(json_encode($arreglo));
	break;
	case 3:
		//json Listar Tratamiento Dental {"indice":3}
		$controladoraFicha = new ControladoraTratamientoAbono();
		echo(json_encode($controladoraFicha->listarTratamiento()));
	break;
	case 4:
		//json Listar Tratamiento Dental {"indice":4,"idFicha":3}
		$ficha = $data->{"idFicha"};
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=4;
		$arreglo["listadoTratamiento"]=$controladoraFicha->listarTratamientoPorFicha($ficha);
		echo(json_encode($arreglo));
	break;
	case 5:
		//json Insertar Abono {"indice":5,"idTratamientoDental":3,"fechaAbono":"1991-12-12","monto":1000}
		$idTratamientoDental = $data->{"idTratamientoDental"};
		$fechaAbono = $data->{"fechaAbono"};
		$monto = $data->{"monto"};
		$abono = new Abono();
		$abono->initClass(0,$idTratamientoDental,$fechaAbono,$monto);
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"] = 5;
		$arreglo["idAbonoInsertado"] = $controladoraFicha->instertarAbono($abono);
		echo(json_encode($arreglo));
	break;
	case 6:
		//json Modificar Abono {"indice":6,"idAbono":1,"idTratamientoDental":3,"fechaAbono":"1991-12-12","monto":10000}
		$idAbono = $data->{"idAbono"};
		$idTratamientoDental = $data->{"idTratamientoDental"};
		$fechaAbono = $data->{"fechaAbono"};
		$monto = $data->{"monto"};
		$abono = new Abono();
		$abono->initClass($idAbono,$idTratamientoDental,$fechaAbono,$monto);
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=6;
		$arreglo["Resultado"] = $controladoraFicha->modificarAbono($abono);
		echo(json_encode($arreglo));
	break;
	case 7:
		//json Listar Abono {"indice":7}
		$controladoraFicha = new ControladoraTratamientoAbono();
		echo(json_encode($controladoraFicha->listarAbonos()));
	break;
	case 8:
		//json Listar Abono Por Id tratamiento {"indice":8,"idTratamiento":3}
		$idTratamiento = $data->{"idTratamiento"};
		$controladoraAbono = new ControladoraTratamientoAbono();
		$arreglo["code"]=8;
		$arreglo["listaAbono"]=$controladoraAbono->listarAbonosPorTratamiento($idTratamiento);
		echo(json_encode($arreglo));
	break;
	case 9:
		//json Total Abono Por Id Paciente {"indice":9,"idPaciente":3}
		$idPaciente = $data->{"idPaciente"};
		$controladoraAbono = new ControladoraTratamientoAbono();
		echo(json_encode($controladoraAbono->TotalAbono($idPaciente)));
	break;
	case 10:
		//json Total Abono Por Id Paciente {"indice":10,"idFicha":3}
		$ficha = $data->{"idFicha"};
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=10;
		$arreglo["listadoTratamiento"]=$controladoraFicha->listarTratamientoPorFichaConTotalAbono($ficha);
		echo(json_encode($arreglo));
	break;
	case 11:
		//json Eliminar Abono {"indice":11,"idAbono":3}
		$idAbono = $data->{"idAbono"};
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=11;
		$arreglo["eliminado"]=$controladoraFicha->eliminarAbono($idAbono);
		echo(json_encode($arreglo));
	break;
}