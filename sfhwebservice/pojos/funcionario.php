<?php
require_once 'persona.php';
class Funcionario extends Persona
{
	public $idFuncionario;
	public $idPersona;
	public $puestoTrabajo;
	public $funcionarioHabilitado;

	function initClassFuncionario($idFuncionario, $idPersona, $puestoTrabajo,$funcionarioHabilitado)
	{
		$this->idFuncionario = $idFuncionario;
		$this->idPersona = $idPersona;
		$this->puestoTrabajo = $puestoTrabajo;
		$this->funcionarioHabilitado = $funcionarioHabilitado;
	}
	function initClassDatosCompletos($idPersona, $idPerfil, $idFuncionario, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento, $puestoTrabajo, $funcionarioHabilitado)
	{
		parent::initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $apellidoPaterno, $apellidoMaterno, $fechaNacimiento);
		$this->idFuncionario = $idFuncionario;
		$this->idPersona = $idPersona;
		$this->puestoTrabajo = $puestoTrabajo;
		$this->funcionarioHabilitado = $funcionarioHabilitado;
	}
	function initClassFuncionarioPersona(Persona $persona, $idFuncionario,$idPersona,$puestoTrabajo, $funcionarioHabilitado)
	{
		parent::initClassPersona($persona);
		$this->idFuncionario = $idFuncionario;
		$this->idPersona = $idPersona;
		$this->puestoTrabajo = $puestoTrabajo;
		$this->funcionarioHabilitado = $funcionarioHabilitado;
	}
}
?>