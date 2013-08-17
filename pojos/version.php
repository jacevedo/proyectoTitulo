<?php
public class version 
{
	public $idVersion;
	public $nomVersion;
	public $comentario;

	public initClass($idVersion, $nomVersion, $comentario)
	{
		$this->idVersion = $idVersion;
		$this->nomVersion = $nomVersion;
		$this->comentario = $comentario;
	}
}

?>