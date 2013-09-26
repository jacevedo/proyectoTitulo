<?php
require_once '../pojos/listaprecios.php';
require_once '../controladoras/controladoralistapreciosdentales.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
*Opciones:
* 1.- insertar Precio 
* 2.- Modificar Precio
* 3.- Listar precios
* 4.- Listar Precios Por Nombre
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

}