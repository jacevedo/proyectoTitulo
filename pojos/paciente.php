<?php
public class Paciente
{
	public $idPaciente;
	public $idPersona;
	public $fechaIngreso;

	public initClass($idPaciente, $idPersona, $fechaIngreso)
	{
		$this->idPaciente = $idPaciente;
		$this->idPersona = $idPersona;
		$this->fechaIngreso = $fechaIngreso;
	}
}
?>