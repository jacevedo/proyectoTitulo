<?php
public class TipoDePieza
{
	public $idTipoPieza;
	public $nombreCientificoPieza;
	public $descripcion;

	public initClass($idTipoPieza, $nombreCientificoPieza, $descripcion)
	{
		$this->idTipoPieza = $idTipoPieza;
		$this->nombreCientificoPieza = $nombreCientificoPieza;
		$this->descripcion = $descripcion;
	}
}

?>