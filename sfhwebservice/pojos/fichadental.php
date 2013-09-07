<?php
class FichaDental
{
	public $idFicha;
	public $idPaciente;
	public $idOdontologo;
	public $fechaIngreso;
	public $anamnesis;
	public $habilitada;

	function initClass($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis,$habilitada)
	{
		$this->idFicha = $idFicha;
		$this->idPaciente = $idPaciente;
		$this->idOdontologo = $idOdontologo;
		$this->fechaIngreso = $fechaIngreso;
		$this->anamnesis = $anamnesis;
		$this->habilitada = $habilitada;
	}
}
?>