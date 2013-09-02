<?php
class Paciente
{
	public $idPaciente;
	public $idPersona;
	public $fechaIngreso;
	public $habilitadoPaciente;

	 function initClass($idPaciente, $idPersona, $fechaIngreso, $habilitadoPaciente)
	{
		$this->idPaciente = $idPaciente;
		$this->idPersona = $idPersona;
		$this->fechaIngreso = $fechaIngreso;
		$this->habilitadoPaciente = $habilitadoPaciente;
	}
}
?>