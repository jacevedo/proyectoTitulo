<?php

require_once '../controladoras/controladorareportes.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
* 1.- Crear Reporte Cita rango Fecha
* 2.- Crear Reporte Cita fecha mas antigua a mas nueva
* 3.- Crear Reporte Cita fecha mas nueva a mas antigua
* 4.- crear Reporte abono rango fecha
* 5.- crear Reporte abono mas antigua a mas nueva
* 6.- crear Reporte abono mas nueva a mas antigua
* 7.- crear reporte gastos rango fecha
* 8.- listar reportes con datos persona
* 9.- listar reportes entre fechas
* 10.- listar reportes de manera ascendente
* 11.- listar reportes de manera desendente
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
		//json crear reporte gastos rango fecha {"indice":7,"fechaInicio":"2013-02-01","fechaTermino":"2013-10-30"}
		$fechaInicio = $data->{"fechaInicio"};
		$fechaTermino = $data->{"fechaTermino"};
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 7;
		$arreglo["gastos"] = $controladoraReporte->gastosRangoFecha($fechaInicio, $fechaTermino);
		echo (json_encode($arreglo));
	break;
	case 8:
		//JSON listar reportes con datos persona {indice:8}
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 8;
		$arreglo["reportes"] = $controladoraReporte->listarReportes();
		echo (json_encode($arreglo));
	break;
	case 9:
		//JSON listar reportes entre fechas {"indice":9,"fechaInicio":"2013-02-01","fechaTermino":"2013-10-30"}
		$fechaInicio = $data->{"fechaInicio"};
		$fechaTermino = $data->{"fechaTermino"};
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 9;
		$arreglo["reportes"] = $controladoraReporte->listarReportesFiltros($fechaInicio,$fechaTermino);
		echo (json_encode($arreglo));
	break;
	case 10:
		//JSON listar reportes de manera ascendente {"indice":10}
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 10;
		$arreglo["reportes"] = $controladoraReporte->listarReportesFechaOrdenada();
		echo (json_encode($arreglo));
	break;
	case 11:
		//JSON listar reportes de manera desendente {"indice":11}
		$controladoraReporte = new ControladoraReportes();
		$arreglo["code"] = 11;
		$arreglo["reportes"] = $controladoraReporte->listarReportesFechaDesordenada();
		echo (json_encode($arreglo));
	break;
}