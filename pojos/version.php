<?php
class version 
{
	public $idVersion;
	public $nomVersion;
	public $comentario;

	function initClass($idVersion, $nomVersion, $comentario)
	{
		$this->idVersion = $idVersion;
		$this->nomVersion = $nomVersion;
		$this->comentario = $comentario;
	}
}

?>