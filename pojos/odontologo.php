<?php
require_once 'persona.php';
class Odontologo extends Persona
{
	public $idOdontologo;
	public $idPersona;
	public $especialidad;
	public $odontologoHabilitado;

	function initClass($idOdontologo, $idPersona, $especialidad,$odontologoHabilitado)
	{
		$this->idOdontologo = $idOdontologo;
		$this->idPersona = $idPersona;
		$this->especialidad = $especialidad;
		$this->odontologoHabilitado = $odontologoHabilitado;
	}
	function initClassConPersona(Persona $per,$idOdontologo, $idPersona, $especialidad,$odontologoHabilitado)
	{
		parent::initClassPersona($persona);
		$this->idOdontologo = $idOdontologo;
		$this->idPersona = $idPersona;
		$this->especialidad = $especialidad;
		$this->odontologoHabilitado = $odontologoHabilitado;
	}
	function initClassDatosCompletos($idPersona, $idPerfil, $idOdontologo, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $especialidad,$odontologoHabilitado)
	{
		parent::initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);
		$this->idPaciente = $idPaciente;
		$this->idPersona = $idPersona;
		$this->fechaIngreso = $fechaIngreso;
		$this->habilitadoPaciente = $habilitadoPaciente;
	}
}
?>