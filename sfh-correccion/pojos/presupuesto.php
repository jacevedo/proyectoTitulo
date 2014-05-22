<?php
class Presupuesto
{
	public $idPresupuesto;
	public $valorTotal;
	public $idFicha;
	public $fechaPresupuesto;
	public $idPersona;

	function initClass($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto)
	{
		$this->idFicha = $idFicha;
		$this->idPresupuesto = $idPresupuesto;
		$this->valorTotal = $valorTotal;
		$this->fechaPresupuesto = $fechaPresupuesto;
	}
	function initClassIdPersona($idPresupuesto, $idFicha, $valorTotal,$fechaPresupuesto,$idPersona)
	{
		$this->idFicha = $idFicha;
		$this->idPresupuesto = $idPresupuesto;
		$this->valorTotal = $valorTotal;
		$this->fechaPresupuesto = $fechaPresupuesto;
		$this->idPersona = $idPersona;
	}
}
?>