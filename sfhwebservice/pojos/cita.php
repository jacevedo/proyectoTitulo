<?php
class Cita
{
	public $idCita;
	public $idOdontologo;
	public $idPaciente;
	public $horaInicio;
	public $horaTermino;
	public $fecha;
	public $nomPaciente;
	public $appPaternoPaciente;
	public $appMaternoPaciente;
	public $nomOdontologo;
	public $appPaternoOdontologo;
	public $appMaternoOdontologo;

	function initClass($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha)
	{
		$this->idCita = $idCita;
		$this->idOdontologo = $idOdontologo;
		$this->idPaciente = $idPaciente;
		$this->horaInicio = $horaInicio;
		$this->horaTermino = $horaTermino;
		$this->fecha = $fecha;
	}
	function initClassDatosExtra($idCita, $idOdontologo, $idPaciente, $horaInicio, $horaTermino, $fecha, $nomPaciente, appPaternoPaciente, 
								$appMaternoPaciente, $nomOdontologo, $appPaternoOdontologo, $appMaternoOdontologo)
	{
		$this->idCita = $idCita;
		$this->idOdontologo = $idOdontologo;
		$this->idPaciente = $idPaciente;
		$this->horaInicio = $horaInicio;
		$this->horaTermino = $horaTermino;
		$this->fecha = $fecha;	
		$this->nomPaciente = $nomPaciente;
		$this->appPaternoPaciente = $appPaternoPaciente;
		$this->appMaternoPaciente = $appMaternoPaciente;
		$this->nomOdontologo = $nomOdontologo;
		$this->appPaternoOdontologo = $appPaternoOdontologo;
		$this->appMaternoOdontologo = $appMaternoOdontologo;
	}
}
?>