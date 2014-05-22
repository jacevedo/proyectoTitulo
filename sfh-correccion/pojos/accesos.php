<?php

class Accesos
{
	public $codAcceso;
	public $descripcionAcceso;

	function initClass($codAcceso, $descripcionAcceso)
	{
		$this->codAcceso = $codAcceso;
		$this->descripcionAcceso = $descripcionAcceso;
	}
}

?>