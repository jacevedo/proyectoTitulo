<?php
class Cita
{
	public $idCita;
	public $idOdontologo;
	public $idPaciente;
	public $horaInicio;
	public $horaTermino;
	public $fecha;
	public $estado;
	public $nomPaciente;
	public $appPaternoPaciente;
	public $appMaternoPaciente;
	public $nomOdontologo;
	public $appPaternoOdontologo;
	public $appMaternoOdontologo;

	function initClass($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado)
	{
		$this->idCita = $idCita;
		$this->idOdontologo = $idOdontologo;
		$this->idPaciente = $idPaciente;
		$this->horaInicio = $horaInicio;
		$this->horaTermino = $horaTermino;
		$this->fecha = $fecha;
		$this->estado = $estado;
	}
	function initClassDatosExtra($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $estado, $nomPaciente, $appPaternoPaciente, 
								$appMaternoPaciente, $nomOdontologo, $appPaternoOdontologo, $appMaternoOdontologo)
	{
		$this->idCita = $idCita;
		$this->idOdontologo = $idOdontologo;
		$this->idPaciente = $idPaciente;
		$this->horaInicio = $horaInicio;
		$this->horaTermino = $horaTermino;
		$this->fecha = $fecha;	
		$this->estado = $estado;
		$this->nomPaciente = $nomPaciente;
		$this->appPaternoPaciente = $appPaternoPaciente;
		$this->appMaternoPaciente = $appMaternoPaciente;
		$this->nomOdontologo = $nomOdontologo;
		$this->appPaternoOdontologo = $appPaternoOdontologo;
		$this->appMaternoOdontologo = $appMaternoOdontologo;
	}
}
?>