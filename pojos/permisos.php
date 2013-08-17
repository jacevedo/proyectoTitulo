<?php

public class Permisos
{
	public $idPerfil;
	public $codAcceso;

	public initClass($idPerfil,$codAcceso)
	{
		$this->idPerfil = $idPerfil;
		$this->codAcceso = $codAcceso;
	}


}
?>