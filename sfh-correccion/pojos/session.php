<?php
class Session
{
	public $idSession;
	public $idPersona;
	public $keySession;
	public $fechaHoraIngreso;
	public $fechaHoraCaducidad;

	function initClass($idSession, $idPersona, $keySession,$fechaHoraIngreso,$fechaHoraCaducidad)
	{
		$this->idSession = $idSession;
		$this->idPersona = $idPersona;
		$this->keySession = $keySession;
		$this->fechaHoraIngreso = $fechaHoraIngreso;
		$this->fechaHoraCaducidad = $fechaHoraCaducidad;
	}
}
?>