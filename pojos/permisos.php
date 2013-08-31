<?php

class Permisos
{
	public $idPerfil;
	public $codAcceso;

	function initClass($idPerfil,$codAcceso)
	{
		$this->idPerfil = $idPerfil;
		$this->codAcceso = $codAcceso;
	}


}
?>