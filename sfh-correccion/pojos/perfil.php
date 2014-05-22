<?php
class Perfil
{
	public $idPerfil;
	public $nomPerfil;

	function initClass($idPerfil,$nomPerfil)
	{
		$this->$idPerfil = $idPerfil;
		$this->nomPerfil = $nomPerfil;
	}
}
?>