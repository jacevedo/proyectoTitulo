<?php
class Funcionario
{
	public $idFuncionario;
	public $idPersona;
	public $puestoTrabajo;
	public $funcionarioHabilitado;

	function initClass($idFuncionario, $idPersona, $puestoTrabajo,$funcionarioHabilitado)
	{
		$this->idFuncionario = $idFuncionario;
		$this->idPersona = $idPersona;
		$this->puestoTrabajo = $puestoTrabajo;
		$this->funcionarioHabilitado = $funcionarioHabilitado;
	}
}
?>