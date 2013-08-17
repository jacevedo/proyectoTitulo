<?php

public class Perfil
{
	public $idPerfil;
	public $nomPerfil;

	public initClass($idPerfil,$nomPerfil)
	{
		$this->$idPerfil = $idPerfil;
		$this->nomPerfil = $nomPerfil;
	}
}
?>