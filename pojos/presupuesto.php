<?php
class Presupuesto
{
	public $idPresupuesto;
	public $valotTotal;
	public $idFicha;

	function initClass($idPresupuesto, $idFicha, $valorTotal)
	{
		$this->idFicha = $idFicha;
		$this->idPresupuesto = $idPresupuesto;
		$this->valorTotal = $valorTotal;
	}
}
?>