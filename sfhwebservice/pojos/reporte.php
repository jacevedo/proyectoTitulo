<?php
class Reporte
{
	public $idReporte;
	public $idPersona;
	public $fechaCreacion;
	public $tipoReporte;
	public $nomPersona;
	public $appPersona;

	function initClass($idReporte, $idPersona, $fechaCreacion, $tipoReporte)
	{
		$this->idReporte = $idReporte;
		$this->idPersona = $idPersona;
		$this->fechaCreacion = $fechaCreacion;
		$this->tipoReporte = $tipoReporte;
	}
	function initClassDatosPersona($idReporte, $idPersona, $fechaCreacion, 
									$tipoReporte, $nomPersona, $appPersona)
	{
		$this->idReporte = $idReporte;
		$this->idPersona = $idPersona;
		$this->fechaCreacion = $fechaCreacion;
		$this->tipoReporte = $tipoReporte;
		$this->nomPersona = $nomPersona;
		$this->appPersona = $appPersona;
	}
}
?>