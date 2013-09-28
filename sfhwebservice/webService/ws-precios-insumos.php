<?php
require_once '../pojos/listaprecios.php';
require_once '../controladoras/controladoralistapreciosdentales.php';
require_once '../pojos/insumos.php';
require_once '../controladoras/controladoraInsumos.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- insertar Precio 
* 2.- Modificar Precio
* 3.- Listar precios
* 4.- Listar Precios Por Nombre
* 5.- Eliminar Precios
* 6.- Insertar Insumo 
* 7.- Modificar Insumo
* 8.- Listar Insumos 
* 9.- Listar Insumos Por Area
* 10.- Listar Insumos Por Gastos
* 11.- Listar Insumos Por Nombre
*/
$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
	//json Insertar Precio {"indice":1,"Comentario":"Procedimiento","ValorNeto":12000}
		$comentario = $data->{'Comentario'};
		$valorNeto = $data->{'ValorNeto'};
		$precio = new ListaPrecios();
		$controladoraPrecio = new ControladoraListaPreciosDentales();
		$precio->initClass(0, $comentario, $valorNeto);
		$arreglo["code"] = 1;
		$arreglo["idPrecioInsertado"] = $controladoraPrecio->insertarPrecio($precio);	
		//Retorna {"idPrecioInsertado":id};	
		echo(json_encode($arreglo));
	break;
	case 2:
	//json Modificar Precio {"indice":2,"idPrecio":2,"Comentario":"asd","ValorNeto":130}
		$idPrecio = $data->{"idPrecio"};
		$comentario = $data->{'Comentario'};
		$valorNeto = $data->{'ValorNeto'};
		$precio = new ListaPrecios();
		$controladoraPrecio = new ControladoraListaPreciosDentales();
		$precio->initClass($idPrecio, $comentario, $valorNeto);
		$arreglo["code"] = 2;
		$arreglo["Modificado"] = $controladoraPrecio->modificarPrecios($precio);
		echo(json_encode($arreglo));
	break;
	case 3:
		//json Listar Precios {"indice":3}
		$controladoraLstPrecios = new ControladoraListaPreciosDentales();
		$arreglo["code"]=3;
		$arreglo["listaPrecios"] = $controladoraLstPrecios->listarPrecios();
		echo(json_encode($arreglo));
	break;
	case 4:
		//json Listar Precios Nombre {"indice":4,"nombre":"Urgencia"}
		$nombre = $data->{"nombre"};
		$controladoraLstPrecios = new ControladoraListaPreciosDentales();
		$arreglo["code"]=4;
		$arreglo["listaPrecios"]=$controladoraLstPrecios->listarPreciosNombre($nombre);
		echo(json_encode($arreglo));
	break;
	case 5:
		//json Listar Precios {"indice":5,idPrecio":100}
		$idPrecio = $data->{"idPrecio"};
		$controladoraLstPrecios = new ControladoraListaPreciosDentales();
		$arreglo["code"]=5;
		$arreglo["Eliminado"] = $controladoraLstPrecios->eliminarPrecio($idPrecio);
		echo(json_encode($arreglo));
	break;
	case 6:
		//json insertar Insumo {"indice":6,"idAreaInsumo":3,"idGasto":1,"nomInsumo":"Jeringas 10 ML", "Cantidad":10,"descInsumo": "Compra al por mayor", "unidadMedida":10}
		$idAreaInsumo = $data->{"idAreaInsumo"};
		$idGastos = $data->{"idGasto"};
		$nomInsumos = $data->{"nomInsumo"};
		$cantidad = $data->{"Cantidad"};
		$descInsumo = $data->{"descInsumo"};
		$unidadMedida = $data->{"unidadMedida"};

		$insumo = new Insumos();
		$controladoraInsumo = new ControladoraInsumos();
		$insumo->initClass(0, $idAreaInsumo, $idGastos, $nomInsumos, 
							$cantidad, $descInsumo, $unidadMedida);
		$arreglo["code"]=6;
		$arreglo["idInsertado"] = $controladoraInsumo->insertarInsumos($insumo);
		echo(json_encode($arreglo));



	break;
	case 7:
		//json modificar Insumo {"indice":7,"idInsumo":2,"idAreaInsumo":3,"idGasto":1,"nomInsumo":"Jeringas 15 ML", "Cantidad":10,"descInsumo": "Compra al por mayor", "unidadMedida":10}
		$idInsumo = $data->{"idInsumo"};
		$idAreaInsumo = $data->{"idAreaInsumo"};
		$idGastos = $data->{"idGasto"};
		$nomInsumos = $data->{"nomInsumo"};
		$cantidad = $data->{"Cantidad"};
		$descInsumo = $data->{"descInsumo"};
		$unidadMedida = $data->{"unidadMedida"};

		$insumo = new Insumos();
		$controladoraInsumo = new ControladoraInsumos();
		$insumo->initClass($idInsumo, $idAreaInsumo, $idGastos, $nomInsumos, 
							$cantidad, $descInsumo, $unidadMedida);
		$arreglo["code"]=7;
		$arreglo["Modificado"] = $controladoraInsumo->modificarInsumo($insumo);
		echo(json_encode($arreglo));
	break;
	case 8:
		//json ListarInsumos {"indice":8}
		$controladoraInsumo = new ControladoraInsumos();
		$arreglo["code"]=8;
		$arreglo["Modificado"] = $controladoraInsumo->listarInsumos();
		echo(json_encode($arreglo));
	break;
	case 9:
		//json ListarInsumos Por Area {"indice":9,"idAreaInsumo":3}
		$idAreaInsumo = $data->{"idAreaInsumo"};
		$controladoraInsumo = new ControladoraInsumos();
		$arreglo["code"]=9;
		$arreglo["ListaInsumos"] = $controladoraInsumo->listarInsumosPorArea($idAreaInsumo);
		echo(json_encode($arreglo));
	break;
	case 10:
		//json ListarInsumos Por Gasto {"indice":10,"idGasto":3}
		$idGasto = $data->{"idGasto"};
		$controladoraInsumo = new ControladoraInsumos();
		$arreglo["code"]=10;
		$arreglo["ListaInsumos"] = $controladoraInsumo->listarInsumosPorGastos($idGasto);
		echo(json_encode($arreglo));
	break;
	case 11:
		//Listar Insumos Por Nombre {"indice":11,"nomInsumo":"Jeringas"}
		$nomInsumo = $data->{"nomInsumo"};
		$controladoraInsumo = new ControladoraInsumos();
		$arreglo["code"]=11;
		$arreglo["ListaInsumos"] = $controladoraInsumo->listarInsumosPorNombre($nomInsumo);
		echo(json_encode($arreglo));
	break;


















}
