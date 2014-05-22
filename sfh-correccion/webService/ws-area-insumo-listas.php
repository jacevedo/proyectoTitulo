<?php
require_once '../pojos/listaprecios.php';
require_once '../pojos/insumos.php';
require_once '../pojos/areainsumo.php';
require_once '../controladoras/controladoralistapreciosdentales.php';
require_once '../controladoras/controladoraInsumos.php';
require_once '../controladoras/controladoragastos.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- insertar Area Insumo 
* 2.- Modificar Area Insumo
* 3.- Eliminar Area Insumo
* 4.- Listar Area Insumo
* 5.- Listar Area Insumo Nombre ID
* 6.- Listar Gastos Nombre ID
* 7.- Listar Insumos nombre ID
*/
$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1: 
		//Json insertar Area Insumo {"indice":1,"nomArea":"Oficina","descripcion":"asd"}
		$nomArea = $data->{"nomArea"};
		$descripcion = $data->{"descripcion"};
		$controladoraAreaInsumo = new ControladoraInsumos();
		$area = new AreaInsumo();
		$area->initClass(0,$nomArea,$descripcion);
		$arreglo["code"] = 1;
		$arreglo["listaAreaInsumo"] = $controladoraAreaInsumo->insertarAreaInsumo($area);
		echo(json_encode($arreglo));
	break;
	case 2:
		//Json modificar Area Insumo {"indice":2,"idAreaInsumo":3,"nomArea":"Oficina",
		//								"descripcion":"asd"}
		$idAreaInsumo = $data->{"idAreaInsumo"};
		$nomArea = $data->{"nomArea"};
		$descripcion = $data->{"descripcion"};
		$controladoraAreaInsumo = new ControladoraInsumos();
		$area = new AreaInsumo();
		$area->initClass($idAreaInsumo,$nomArea,$descripcion);
		$arreglo["code"] = 2;
		$arreglo["Modificado"] = $controladoraAreaInsumo->modificarAreaInsumo($area);
		echo(json_encode($arreglo)); 
	break;
	case 3: 
		//Json Eliminar Area Insumo {"indice":3,"idAreaInsumo":3}
		$idAreaInsumo = $data->{"idAreaInsumo"};
		$controladoraAreaInsumo = new ControladoraInsumos();
		$arreglo["code"] = 3;
		$arreglo["Eliminado"] = $controladoraAreaInsumo->eliminarAreaInsumo($idAreaInsumo);
		echo(json_encode($arreglo)); 
	break;
	case 4: 
		//Json listar Area Insumo {"indice":4}
		$controladoraAreaInsumo = new ControladoraInsumos();
		$arreglo["code"] = 4;
		$arreglo["ListaAreaInsumo"] = $controladoraAreaInsumo->listarAreaInsumos();
		echo(json_encode($arreglo)); 
	break;
	case 5:
		//Json listar Area Insumo id nombre {"indice":5}
		$controladoraAreaInsumo = new ControladoraInsumos();
		$arreglo["code"] = 5;
		$arreglo["listaAreaInsuno"] = $controladoraAreaInsumo->listarAreaInsumoIdNombre();
		echo(json_encode($arreglo));  
	break;
	case 6: 
		//Json listar Gasto id Concepto {"indice":6}
		$gastos = new ControladoraGastos();
		$arreglo["code"]=6;
		$arreglo["listaGastos"]=$gastos->listarGastoIdConcepto();
		echo (json_encode($arreglo));
	break;
	case 7: 
		//Json Insumos nombre ID {"indice":7}
		$controladoraInsumo = new ControladoraInsumos();
		$arreglo["code"]=7;
		$arreglo["listaInsumos"] = $controladoraInsumo->listaInsumoIdNombre();
		echo(json_encode($arreglo));
	break;
}