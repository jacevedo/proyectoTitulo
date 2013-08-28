<?php
public class OrdenLaboratorio
{
	public $idOrdenLaboratorio;
	public $clinica;
	public $bd;
	public $bi;
	public $pd;
	public $pi;
	public $fechaEntrega;
	public $horaEntrega;
	public $color;

	public initClass($idOrdenLaboratorio, $clinica, $bd, $bi, $pd, $pi, $fechaEntrega, $horaEntrega, $color)
	{
		$this->idOrdenLaboratorio = $idOrdenLaboratorio;
		$this->clinica = $clinica;
		$this->bd = $bd;
		$this->bi = $bi;
		$this->pd = $pd;
		$this->pi = $pi;
		$this->fechaEntrega = $fechaEntrega;
		$this->horaEntrega = $horaEntrega;
		$this->color = $color;
	}
}
?>