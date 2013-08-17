<?php
public class ListaPrecios
{
	public $idPrecios;
	public $comentario;
	public $valorNeto;

	public initClass($idPrecios, $comentario, $valorNeto)
	{
		$this->idPrecios = $idPrecios;
		$this->comentario = $comentario;
		$this->valorNeto = $valorNeto;
	}
}
?>