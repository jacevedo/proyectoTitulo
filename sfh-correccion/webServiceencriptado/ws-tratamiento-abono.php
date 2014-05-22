<?php
require_once '../pojos/tratamientodental.php';
require_once '../pojos/abono.php';
require_once '../controladoras/controladoratratamientoabono.php';
require_once '../controladoras/controladorapaciente.php';
require_once '../controladoras/encript.php';

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
* 12.- Listar Pacientes y Tratamiento
* 13.- buscar Presupuesto persona
*/


$jsonRecibido = $_REQUEST["send"];
$encript = new Encript();
$datos = $encript->validarkey($jsonRecibido);
$data = "";
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
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
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
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 3:
		//json Listar Tratamiento Dental {"indice":3}
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=3;
		$arreglo["Resultado"] = $controladoraFicha->listarTratamiento();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 4:
		//json Listar Tratamiento Dental {"indice":4,"idFicha":3}
		$ficha = $data->{"idFicha"};
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=4;
		$arreglo["listadoTratamiento"]=$controladoraFicha->listarTratamientoPorFicha($ficha);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
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
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
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
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 7:
		//json Listar Abono {"indice":7}
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=7;
		$arreglo["Resultado"] = $controladoraFicha->listarAbonos();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 8:
		//json Listar Abono Por Id tratamiento {"indice":8,"idTratamiento":3}
		$idTratamiento = $data->{"idTratamiento"};
		$controladoraAbono = new ControladoraTratamientoAbono();
		$arreglo["code"]=8;
		$arreglo["listaAbono"]=$controladoraAbono->listarAbonosPorTratamiento($idTratamiento);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 9:
		//json Total Abono Por Id Paciente {"indice":9,"idPaciente":3}
		$idPaciente = $data->{"idPaciente"};
		$controladoraAbono = new ControladoraTratamientoAbono();
		$arreglo["code"]=9;
		$arreglo["listaAbono"]=$controladoraAbono->TotalAbono($idPaciente);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 10:
		//json Total Abono Por Id Paciente {"indice":10,"idFicha":3}
		$ficha = $data->{"idFicha"};
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=10;
		$arreglo["listadoTratamiento"]=$controladoraFicha->listarTratamientoPorFichaConTotalAbono($ficha);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 11:
		//json Eliminar Abono {"indice":11,"idAbono":3}
		$idAbono = $data->{"idAbono"};
		$controladoraFicha = new ControladoraTratamientoAbono();
		$arreglo["code"]=11;
		$arreglo["eliminado"]=$controladoraFicha->eliminarAbono($idAbono);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 12:
		//json Pacientes con Tratamiento {"indice":12,"cantPaciente":1}
		$cantRonda = $data->{"cantPaciente"};
		$controladoraPaciente  = new ControladoraPaciente();
		$arreglo["code"]=12;
		$arreglo["lista"] = $controladoraPaciente->buscarPresupuesto($cantRonda);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 13:
		//json Presupuesto nomPaciente {"indice":13,"nomPaciente":"ada"}
		$nomPaciente = $data->{"nomPaciente"};
		$controladoraPaciente  = new ControladoraPaciente();
		$arreglo["code"]=12;
		$arreglo["lista"] = $controladoraPaciente->buscarPresupuestoPersona($nomPaciente);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
}