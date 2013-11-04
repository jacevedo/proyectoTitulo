<?php

class Permisos
{
	public $idPerfil;
	public $codAcceso;
     public $descripcionAcceso

	function initClass($idPerfil,$codAcceso,$descripcionAcceso)
	{
		$this->idPerfil = $idPerfil;
		$this->codAcceso = $codAcceso;
           $this->$descripcionAcceso=$descripcionAcceso;
	}


}
?>