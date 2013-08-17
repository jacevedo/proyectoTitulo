<?php
public class Presupuesto
{
	public $idPresupuesto;
	public $valotTotal;

	public initClass($idPresupuesto, $valorTotal)
	{
		$this->idPresupuesto = $idPresupuesto;
		$this->valorTotal = $valorTotal;
	}
}
?>