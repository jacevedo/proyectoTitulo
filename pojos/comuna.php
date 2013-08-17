<?php
public class Comuna
{
	public $idComuna;
	public $idRegion;
	public $nombreComuna;

	public initClass($idComuna, $idRegion, $nombreComuna)
	{
		$this->idComuna = $idComuna;
		$this->idRegion= $idRegion;
		$this->nombreComuna = $nombreComuna;
	}
}
?>