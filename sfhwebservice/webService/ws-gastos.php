<?php
require_once '../pojos/gastos.php';
require_once '../controladoras/controladoragastos.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- insertar Gasto 
* 2.- Modificar Gasto
* 3.- Listar Gastos
* 4.- Listar Gasto Por ID Persona
* 5.- Eliminar Gasto
*/

$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json Insertar Gasto {"indice":1,"idPersona":1,"conceptoGasto":"Colacion","montoGasto":2000,"descuentoGasto":0}
		$idPersona = $data->{"idPersona"};
		$concepto = $data->{"conceptoGasto"};
		$monto  = $data->{"montoGasto"};
		$descuentoGasto = $data->{"descuentoGasto"};
		$gasto = new Gastos();
		$gasto->initClass("",$idPersona,$concepto,$monto,$descuentoGasto,"", "");
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=1;
		$arreglo["idGastoInsertado"] = $controladoraGastos->insertarGasto($gasto);
		echo(json_encode($arreglo));
	break;
	case 2:
		//json Modificar Gasto {"indice":2,"idGasto":4,"idPersona":1,"conceptoGasto":"Colacion","montoGasto":2000,"descuentoGasto":0}
		$idGasto = $data->{"idGasto"}; 
		$idPersona = $data->{"idPersona"};
		$concepto = $data->{"conceptoGasto"};
		$monto  = $data->{"montoGasto"};
		$descuentoGasto = $data->{"descuentoGasto"};
		$gasto = new Gastos();
		$gasto->initClass($idGasto,$idPersona,$concepto,$monto,$descuentoGasto,"", "");
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=2;
		$arreglo["idGastoModificado"] = $controladoraGastos->modificarGasto($gasto);
		echo(json_encode($arreglo));
	break;
	case 3:
		//json Listar Gastos {"indice":3}
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=3;
		$arreglo["listaGastos"] = $controladoraGastos->listarGastos();
		echo(json_encode($arreglo));
	break;
	case 4:
		//json Listar Gastos Id Persona {"indice":4,"idPersona":1}
		$idPersona = $data->{"idPersona"};
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=4;
		$arreglo["listaGastos"] = $controladoraGastos->listarGastosIdPersona($idPersona);
		echo(json_encode($arreglo));
	break;
	case 5:
		//json eliminar Gasto {"indice":5,"idGasto":4}
		$idGasto = $data->{"idGasto"};
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=5;
		$arreglo["Eliminado"] = $controladoraGastos->eliminarGasto($idGasto);
		echo(json_encode($arreglo));
	break;
}