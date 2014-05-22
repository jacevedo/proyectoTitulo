<?php

class Abono
{
	public $idAbono;
	public $idTratamientoDental;
	public $fechaAbono;
	public $monto;

	function initClass($idAbono,$idTratamientoDental,$fechaAbono,$monto)
	{
		$this->idAbono = $idAbono;
		$this->idTratamientoDental = $idTratamientoDental;
		$this->fechaAbono = $fechaAbono;
		$this->monto = $monto;
	}
}
?>