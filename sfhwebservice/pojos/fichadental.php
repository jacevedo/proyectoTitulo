<?php
class FichaDental
{
	public $idFicha;
	public $idPaciente;
	public $idOdontologo;
	public $fechaIngreso;
	public $anamnesis;

	function initClass($idFicha, $idPaciente, $idOdontologo, $fechaIngreso, $anamnesis)
	{
		$this->idFicha = $idFicha;
		$this->idPaciente = $idPaciente;
		$this->idOdontologo = $idOdontologo;
		$this->fechaIngreso = $fechaIngreso;
		$this->anamnesis = $anamnesis;
	}
}
?>