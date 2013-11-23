<?php
class Gastos
{
	public $idGastos;
	public $idPersona;
	public $conceptoGasto;
	public $montoGastos;
	public $descuentoGastos;
	public $nomPersona;
	public $apellidoPersona;
	public $fechaGasto;

	function initClass($idGastos,$idPersona,$conceptoGasto,$montoGastos,$descuentoGastos,
						$nomPersona,$apellidoPersona,$fechaGasto)
	{
		$this->idGastos = $idGastos;
		$this->idPersona = $idPersona;
		$this->conceptoGasto = $conceptoGasto;
		$this->montoGastos = $montoGastos;
		$this->descuentoGastos = $descuentoGastos;
		$this->nomPersona = $nomPersona;
		$this->apellidoPersona = $apellidoPersona;
		$this->fechaGasto = $fechaGasto;
	}
}
?>