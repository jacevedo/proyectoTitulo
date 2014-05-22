<?php
class ListaPrecios
{
	public $idPrecios;
	public $comentario;
	public $valorNeto;
	public $valorIva;
	public $valorTotal;

	function initClass($idPrecios, $comentario, $valorNeto)
	{
		$this->idPrecios = $idPrecios;
		$this->comentario = $comentario;
		$this->valorNeto = $valorNeto;
		$this->valorIva = round(($valorNeto*19)/100, 0, PHP_ROUND_HALF_UP); 
		$this->valorTotal = ($valorNeto+$this->valorIva);
	}
}
?>