<?php

require_once '../controladoras/controladorareportes.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
* 1.- Crear Reporte 
* 2.- Listar Reportes
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json crear reporte {"indice":1, "tipoReportes":"asd"}
		
	break;
	case 2:
		//json listarReportes
	break;

}