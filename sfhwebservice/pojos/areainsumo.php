<?php
class AreaInsumo
{
	public $idAreaInsumo;
	public $nombreArea;
	public $descripcionArea;

	function initClass($idAreaInsumo,$nombreArea,$descripcionArea)
	{
		$this->idAreaInsumo = $idAreaInsumo;
		$this->nombreArea = $nombreArea;
		$this->descripcionArea = $descripcionArea;
	}
}


?>