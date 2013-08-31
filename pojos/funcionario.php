<?php
class Funcionario
{
	public $idFuncionario;
	public $idPersona;
	public $puestoTrabajo;

	function initClass($idFuncionario, $idPersona, $puestoTrabajo)
	{
		$this->idFuncionario = $idFuncionario;
		$this->idPersona = $idPersona;
		$this->puestoTrabajo = $puestoTrabajo;
	}
}
?>