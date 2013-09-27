<?php
class Insumos
{
	public $idInsumos;
	public $idAreaInsumo;
	public $idGastos;
	public $nomInsumos;
	public $cantidad;
	public $descripcionInsumo;
	public $unidadMedida;
	public $nomAreaInsumo;
	public $conceptoGasto;

	function initClass($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, 
		$cantidad, $descripcionInsumo, $unidadMedida)
	{
		$this->idInsumos = $idInsumos;
		$this->idAreaInsumo = $idAreaInsumo;
		$this->idGastos = $idGastos;
		$this->nomInsumos = $nomInsumos;
		$this->cantidad  = $cantidad;
		$this->descripcionInsumo = $descripcionInsumo;
		$this->unidadMedida = $unidadMedida;
	}
	function initClassNombres($idInsumos, $idAreaInsumo, $idGastos, $nomInsumos, 
		$cantidad, $descripcionInsumo, $unidadMedida,$nomAreaInsumo,$conceptoGasto)
	{
		$this->idInsumos = $idInsumos;
		$this->idAreaInsumo = $idAreaInsumo;
		$this->idGastos = $idGastos;
		$this->nomInsumos = $nomInsumos;
		$this->cantidad  = $cantidad;
		$this->descripcionInsumo = $descripcionInsumo;
		$this->unidadMedida = $unidadMedida;
		$this->nomAreaInsumo = $nomAreaInsumo;
		$this->conceptoGasto = $conceptoGasto;
	}
}


?>