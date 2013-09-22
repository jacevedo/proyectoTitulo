<?php
class OrdenLaboratorio
{
	public $idOrdenLaboratorio;
	public $idOdontologo;
	public $idPaciente;
	public $numOrden;
	public $clinica;
	public $bd;
	public $bi;
	public $pd;
	public $pi;
	public $fechaCreacion;
	public $fechaEntrega;
	public $horaEntrega;
	public $color;
	public $estado;
	public $nomPaciente;
	public $nomOdontologo;

	function initClass($idOrdenLaboratorio, $idOdontologo,$idPaciente, $numOrden,$clinica, $bd, $bi, $pd, $pi,$fechaCreacion, $fechaEntrega, $horaEntrega, $color, 
						$estado,$nomPaciente,$nomOdontologo)
	{
		$this->idOrdenLaboratorio = $idOrdenLaboratorio;
		$this->idOdontologo = $idOdontologo;
		$this->idPaciente = $idPaciente;
		$this->numOrden = $numOrden;
		$this->clinica = $clinica;
		$this->bd = $bd;
		$this->bi = $bi;
		$this->pd = $pd;
		$this->pi = $pi;
		$this->fechaCreacion = $fechaCreacion;
		$this->fechaEntrega = $fechaEntrega;
		$this->horaEntrega = $horaEntrega;
		$this->color = $color;
		$this->estado = $estado;
		$this->nomPaciente = $nomPaciente;
		$this->nomOdontologo = $nomOdontologo;
	}
}
?>