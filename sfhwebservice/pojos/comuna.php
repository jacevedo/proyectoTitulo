<?php
class Comuna
{
	public $idComuna;
	public $idRegion;
	public $nombreComuna;

	function initClass($idComuna, $idRegion, $nombreComuna)
	{
		$this->idComuna = $idComuna;
		$this->idRegion= $idRegion;
		$this->nombreComuna = $nombreComuna;
	}
}
?>