<?php
public class Pass
{
	public $idPersona;
	public $pass;
	public $fechaCaducidad;

	public initClass($idPersona,$pass,$fechaCaducidad)
	{
		$this->idPersona = $idPersona;
		$this->pass = $pass;
		$this->fechaCaducidad = $fechaCaducidad;
	}
}

?>