<?php
class ListaPrecios
{
	public $idPrecios;
	public $comentario;
	public $valorNeto;

	function initClass($idPrecios, $comentario, $valorNeto)
	{
		$this->idPrecios = $idPrecios;
		$this->comentario = $comentario;
		$this->valorNeto = $valorNeto;
	}
}
?>