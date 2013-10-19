<?php
class Cita
{
	public $idHorario;
	public $idOdontologo;
	public $horaInicio;
	public $horaTermino;
	public $duracionModulo;


	function initClass($idHorario, $idOdontologo, $horaInicio, $horaTermino, 
						$duracionModulo)
	{
		$this->idHorario = $idHorario;
		$this->idOdontologo = $idOdontologo;
		$this->horaInicio = $horaInicio;
		$this->horaTermino = $horaTermino;
		$this->duracionModulo = $duracionModulo;
		
	}
}
?>