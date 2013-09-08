<?php
class Presupuesto
{
	public $idPresupuesto;
	public $valorTotal;
	public $idFicha;
	public $fechaPresupuesto;

	function initClass($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto)
	{
		$this->idFicha = $idFicha;
		$this->idPresupuesto = $idPresupuesto;
		$this->valorTotal = $valorTotal;
		$this->fechaPresupuesto = $fechaPresupuesto;
	}
}
?>