<?php
class Presupuesto
{
	public $idPresupuesto;
	public $valotTotal;

	function initClass($idPresupuesto, $valorTotal)
	{
		$this->idPresupuesto = $idPresupuesto;
		$this->valorTotal = $valorTotal;
	}
}
?>