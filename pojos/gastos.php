<?php
class Gastos
{
	public $idGastos;
	public $idPersona;
	public $montoGastos;
	public $descuentoGastos;

	function initClass($idGastos,$idPersona,$montoGastos,$descuentoGastos)
	{
		$this->idGastos = $idGastos;
		$this->idPersona = $idPersona;
		$this->montoGastos = $montoGastos;
		$this->descuentoGastos = $descuentoGastos;
	}
}
?>