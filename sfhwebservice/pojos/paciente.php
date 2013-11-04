<?php
require_once 'persona.php';

class Paciente extends Persona
{
	public $idPaciente;
	public $idPersona;
	public $fechaIngreso;
	public $habilitadoPaciente;

	function initClassDatosCompletos($idPersona, $idPerfil, $idPaciente, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $fechaIngreso, $habilitadoPaciente)
	{
		parent::initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);
		$this->idPaciente = $idPaciente;
		$this->idPersona = $idPersona;
		$this->fechaIngreso = $fechaIngreso;
		$this->habilitadoPaciente = $habilitadoPaciente;
	}
	function initClassPacientePersona(Persona $persona, $idPersona, $fechaIngreso, $habilitadoPaciente)
	{
		parent::initClassPersona($persona);
		$this->idPaciente = $idPaciente;
		$this->idPersona = $idPersona;
		$this->fechaIngreso = $fechaIngreso;
		$this->habilitadoPaciente = $habilitadoPaciente;
	}
	function initClassPaciente($idPaciente,$idPersona, $fechaIngreso, $habilitadoPaciente)
	{
		$this->idPaciente = $idPaciente;
		$this->idPersona = $idPersona;
		$this->fechaIngreso = $fechaIngreso;
		$this->habilitadoPaciente = $habilitadoPaciente;
	}
}
?>