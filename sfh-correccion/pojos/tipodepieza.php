<?php
class TipoDePieza
{
	public $idTipoPieza;
	public $nombreCientificoPieza;
	public $descripcion;

	function initClass($idTipoPieza, $nombreCientificoPieza, $descripcion)
	{
		$this->idTipoPieza = $idTipoPieza;
		$this->nombreCientificoPieza = $nombreCientificoPieza;
		$this->descripcion = $descripcion;
	}
}

?>