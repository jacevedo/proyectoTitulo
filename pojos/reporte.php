<?php
public class Reporte
{
	public $idReporte;
	public $idPersona;
	public $fechaCreacion;
	public $tipoReporte;

	public initClass($idReporte, $idPersona, $fechaCreacion, $tipoReporte)
	{
		$this->idReporte = $idReporte;
		$this->idPersona = $idPersona;
		$this->fechaCreacion = $fechaCreacion;
		$this->tipoReporte = $tipoReporte;
	}
}
?>