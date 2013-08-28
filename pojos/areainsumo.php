<?php
public class AreaInsumo
{
	public $idAreaInsumo;
	public $nombreArea;
	public $descripcionArea;

	public initClass($idAreaInsumo,$nombreArea,$descripcionArea)
	{
		$this->idAreaInsumo = $idAreaInsumo;
		$this->nombreArea = $nombreArea;
		$this->descripcionArea = $descripcionArea;
	}
}


?>