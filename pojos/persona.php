<?php
public class Persona
{
	public $idPersona;
	public $idPerfil;
	public $rut;
	public $dv;
	public $nombre;
	public $apellidoPaterno;
	public $apellidoMaterno;
	public $fechaNacimiento;

	public initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento)
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
}
?>