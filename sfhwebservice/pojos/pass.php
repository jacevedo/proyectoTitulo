<?php
class Pass
{
	public $idPersona;
	public $contrasena;
	public $fechaCaducidad;

	function initClass($idPersona,$contrasena,$fechaCaducidad)
	{
		$this->idPersona = $idPersona;
		$this->contrasena = $contrasena;
		$this->fechaCaducidad = $fechaCaducidad;
	}
}

?>