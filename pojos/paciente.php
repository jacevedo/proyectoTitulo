<?php
class Paciente
{
	public $idPaciente;
	public $idPersona;
	public $fechaIngreso;

	 function initClass($idPaciente, $idPersona, $fechaIngreso)
	{
		$this->idPaciente = $idPaciente;
		$this->idPersona = $idPersona;
		$this->fechaIngreso = $fechaIngreso;
	}
}
?>