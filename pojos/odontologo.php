<?php
class Odontologo
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
}
?>