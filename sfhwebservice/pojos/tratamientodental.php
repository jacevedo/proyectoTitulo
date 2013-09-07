<?php

class TratamientoDental
{
	public $idTratamientoDental;
	public $idFicha;
	public $fechaCreacion;
	public $tratamiento;
	public $fechaSeguimiento;
	public $valorTotal;

	function initClass($idTratamientoDental, $idFicha, $fechaCreacion,$tratamiento,
					 $fechaSeguimiento,$valorTotal)
	{
		$this->idTratamientoDental = $idTratamientoDental;
		$this->idFicha = $idFicha;
		$this->fechaCreacion = $fechaCreacion;
		$this->tratamiento = $tratamiento;
		$this->fechaSeguimiento = $fechaSeguimiento;
		$this->valorTotal = $valorTotal;
	}
}
?>