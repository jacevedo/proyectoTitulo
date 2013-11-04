<?php
class IndicadoresEconomicos
{
	public $idIndicador;
	public $nomIndicador;
	public $valorEnPesos;
	public $unidadDeMedida;

	function initClass($idIndicador, $nomIndicador, $valorEnPesos, $unidadDeMedida)
	{
		$this->idIndicador = $idIndicador;
		$this->nomIndicador = $nomIndicador;
		$this->valorEnPesos = $valorEnPesos;
		$this->unidadDeMedida = $unidadDeMedida;
	}
}
?>