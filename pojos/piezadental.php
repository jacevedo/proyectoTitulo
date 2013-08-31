<?php
class PiezaDental
{
	public $idPieza;
	public $idTratamientoDental;
	public $idOrdenLaboratorio;
	public $idTipoPieza;
	public $nombrePieza;
	public $descripcionPieza;
	public $periodoPieza;

	function initClass($idPieza, $idTratamientoDental, $idOrdenLaboratorio, $idTipoPieza, $nombrePieza
					 $descripcionPieza, $periodoPieza)
	{
		$this->idPieza = $idPieza;
		$this->idTratamientoDental = $idTratamientoDental;
		$this->idOrdenLaboratorio = $idOrdenLaboratorio;
		$this->idTipoPieza = $idTipoPieza;
		$this->nombrePieza = $nombrePieza;
		$this->descripcionPieza = $descripcionPieza;
		$this->periodoPieza = $periodoPieza;
	}
}

?>