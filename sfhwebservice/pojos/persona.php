<?php
 class Persona
{
	public $idPersona;
	public $idPerfil;
	public $rut;
	public $dv;
	public $nombre;
	public $apellidoPaterno;
	public $apellidoMaterno;
	public $fechaNacimiento;

	function initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento)
	{
		$this->idPersona = $idPersona;
		$this->idPerfil = $idPerfil;
		$this->rut = $rut;
		$this->dv = $dv;
		$this->nombre = $nombre;
		$this->apellidoPaterno = $apellidoPaterno;
		$this->apellidoMaterno = $apellidoMaterno;
		$this->fechaNacimiento = $fechaNacimiento;
	}
	function initClassPersona(Persona $persona)
	{
		$this->idPersona = $persona->idPersona;
		$this->idPerfil = $persona->idPerfil;
		$this->rut = $persona->rut;
		$this->dv = $persona->dv;
		$this->nombre = $persona->nombre;
		$this->apellidoPaterno = $persona->apellidoPaterno;
		$this->apellidoMaterno = $persona->apellidoMaterno;
		$this->fechaNacimiento = $persona->fechaNacimiento;
	}
}
?>