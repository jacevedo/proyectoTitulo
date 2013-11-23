<?php

require_once '../controladoras/controladorareportes.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
* 1.- Crear Reporte Cita rango Fecha
* 2.- Listar Reportes
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};
switch ($opcion) 
{
	case 1:
		//json crear reporte Cita Rango Fecha {"indice":1,"fechaInicio":"2013-02-01","fechaTermino":"2013-10-30"}
		$fechaInicio = $data->{"fechaInicio"};
		$fechaTermino = $data->{"fechaTermino"};
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 1;
		$arreglo["citas"] = $controladoraReporte->citasRangoFecha($fechaInicio,$fechaTermino);
		echo (json_encode($arreglo));
	break;
	case 2:
		//json crear reporte Cita fecha Mas antigua, fecha mas nueva {"indice":2}
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 2;
		$arreglo["citas"] = $controladoraReporte->citasHistoricasAntiguaNueva();
		echo (json_encode($arreglo));
	break;
	case 3:
		//json crear reporte Cita fecha Mas nueva, fecha mas antigua {"indice":2}
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 2;
		$arreglo["citas"] = $controladoraReporte->citasHistoricasNuevaAntigua();
		echo (json_encode($arreglo));
	break;
	case 4:
		//json crear reporte abono rango fecha {"indice":3,"fechaInicio":"2013-02-01","fechaTermino":"2013-10-30"}
		$fechaInicio = $data->{"fechaInicio"};
		$fechaTermino = $data->{"fechaTermino"};
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 2;
		$arreglo["abonos"] = $controladoraReporte->abonoRangoFecha($fechaInicio, $fechaTermino);
		echo (json_encode($arreglo));
	break;
	case 5:
		//json crear reporte Abono fecha Mas antigua, fecha mas nueva {"indice":2}
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 5;
		$arreglo["abonos"] = $controladoraReporte->abonoHistoriocoAntiguaNueva();
		echo (json_encode($arreglo));
	break;
	case 6:
		//json crear reporte Abono fecha Mas nueva, fecha mas antigua {"indice":2}
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 6;
		$arreglo["abonos"] = $controladoraReporte->abonoHistoriocoNuevaAntigua();
		echo (json_encode($arreglo));
	break;
	case 7:
		//json crear reporte abono rango fecha {"indice":7,"fechaInicio":"2013-02-01","fechaTermino":"2013-10-30"}
		$fechaInicio = $data->{"fechaInicio"};
		$fechaTermino = $data->{"fechaTermino"};
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 7;
		$arreglo["gastos"] = $controladoraReporte->gastosRangoFecha($fechaInicio, $fechaTermino);
		echo (json_encode($arreglo));
	break;

}