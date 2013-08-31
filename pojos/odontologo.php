<?php
class Odontologo
{
	public $idOdontologo;
	public $idPersona;
	public $especialidad;

	function initClass($idOdontologo, $idPersona, $especialidad)
	{
		$this->idOdontologo = $idOdontologo;
		$this->idPersona = $idPersona;
		$this->especialidad = $especialidad;
	}
}
?>