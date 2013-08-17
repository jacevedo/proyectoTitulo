<?php
public class Region
{
	public $idRegion;
	public $nombreRegion;
	public $numeroRegionRomano;

	public initClass($idRegion, $nombreRegion, $numeroRegionRomano)
	{
		$this->idRegion = $idRegion;
		$this->nombreRegion = $nombreRegion;
		$this->numeroRegionRomano = $numeroRegionRomano;
	}
}
?>