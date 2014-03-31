<?php
require_once '../pojos/gastos.php';
require_once '../controladoras/controladoragastos.php';
require_once '../controladoras/encript.php';

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
		//json Insertar Gasto {"indice":1,"idPersona":1,"conceptoGasto":"Colacion","montoGasto":2000,"descuentoGasto":0,"fechaGasto":"2013-11-23"}
		$idPersona = $data->{"idPersona"};
		$concepto = $data->{"conceptoGasto"};
		$monto  = $data->{"montoGasto"};
		$descuentoGasto = $data->{"descuentoGasto"};
		$fechaGasto = $data->{"fechaGasto"};
		$gasto = new Gastos();
		$gasto->initClass("",$idPersona,$concepto,$monto,$descuentoGasto,"", "",$fechaGasto);
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=1;
		$arreglo["idGastoInsertado"] = $controladoraGastos->insertarGasto($gasto);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 2:
		//json Modificar Gasto {"indice":2,"idGasto":4,"idPersona":1,"conceptoGasto":"Colacion","montoGasto":2000,"descuentoGasto":0,"fechaGasto":"2013-11-22"}
		$idGasto = $data->{"idGasto"}; 
		$idPersona = $data->{"idPersona"};
		$concepto = $data->{"conceptoGasto"};
		$monto  = $data->{"montoGasto"};
		$descuentoGasto = $data->{"descuentoGasto"};
		$fechaGasto = $data->{"fechaGasto"};
		$gasto = new Gastos();
		$gasto->initClass($idGasto,$idPersona,$concepto,$monto,$descuentoGasto,"", "",$fechaGasto);
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=2;
		$arreglo["idGastoModificado"] = $controladoraGastos->modificarGasto($gasto);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 3:
		//json Listar Gastos {"indice":3}
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=3;
		$arreglo["listaGastos"] = $controladoraGastos->listarGastos();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 4:
		//json Listar Gastos Id Persona {"indice":4,"idPersona":1}
		$idPersona = $data->{"idPersona"};
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=4;
		$arreglo["listaGastos"] = $controladoraGastos->listarGastosIdPersona($idPersona);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 5:
		//json eliminar Gasto {"indice":5,"idGasto":4}
		$idGasto = $data->{"idGasto"};
		$controladoraGastos = new ControladoraGastos();
		$arreglo["code"]=5;
		$arreglo["Eliminado"] = $controladoraGastos->eliminarGasto($idGasto);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
}