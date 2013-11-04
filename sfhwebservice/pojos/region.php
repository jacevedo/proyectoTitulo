<?php
class Region
{
	public $idRegion;
	public $nombreRegion;
	public $numeroRegionRomano;

	function initClass($idRegion, $nombreRegion, $numeroRegionRomano)
	{
		$this->idRegion = $idRegion;
		$this->nombreRegion = $nombreRegion;
		$this->numeroRegionRomano = $numeroRegionRomano;
	}
}
?>