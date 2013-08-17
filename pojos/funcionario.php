<?php
public class Funcionario
{
	public $idFuncionario;
	public $idPersona;
	public $puestoTrabajo;

	public initClass($idFuncionario, $idPersona, $puestoTrabajo)
	{
		$this->idFuncionario = $idFuncionario;
		$this->idPersona = $idPersona;
		$this->puestoTrabajo = $puestoTrabajo;
	}
}
?>