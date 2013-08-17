<?php
public class Odontologo
{
	public $idOdontologo;
	public $idPersona;
	public $especialidad;

	public initClass($idOdontologo, $idPersona, $especialidad)
	{
		$this->idOdontologo = $idOdontologo;
		$this->idPersona = $idPersona;
		$this->especialidad = $especialidad;
	}
}
?>