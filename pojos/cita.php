<?php
public class Cita
{
	public $idCita;
	public $idOdontologo;
	public $idPaciente;
	public $horaInicio;
	public $horaTermino;
	public $fecha;

	public initClass($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha)
	{
		$this->idCita = $idCita;
		$this->idOdontologo = $idOdontologo;
		$this->idPaciente = $idPaciente;
		$this->horaInicio = $horaInicio;
		$this->horaTermino = $horaTermino;
		$this->fecha = $fecha;
	}
}
?>