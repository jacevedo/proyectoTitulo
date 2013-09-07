<?php
class Pass
{
	public $idPersona;
	public $pass;
	public $fechaCaducidad;

	function initClass($idPersona,$pass,$fechaCaducidad)
	{
		$this->idPersona = $idPersona;
		$this->pass = $pass;
		$this->fechaCaducidad = $fechaCaducidad;
	}
}

?>