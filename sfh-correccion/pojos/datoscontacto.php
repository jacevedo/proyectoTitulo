<?php
class DatosContactos
{
	public $idPersona;
	public $idComuna;
	public $fonoFijo;
	public $fonoCelular;
	public $direccion;
	public $mail;
	public $fechaIngreso;

	function initClass($idPersona, $idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso)
	{
		$this->idPersona = $idPersona;
		$this->idComuna = $idComuna;
		$this->fonoFijo = $fonoFijo;
		$this->fonoCelular = $fonoCelular;
		$this->direccion = $direccion;
		$this->mail = $mail;
		$this->fechaIngreso = $fechaIngreso;
	}
}
?>