<?php
session_start();

$id = $_POST['user'];
$key = $_POST['key'];
$paciente = $_POST['pacienteId'];
$nombre = $_POST['nombre'];
$appPaterno = $_POST['appPaterno'];

if($key != "" && $id != "")
{
	$_SESSION['key'] = $key;
	$_SESSION['user'] = $id;
	$_SESSION['paciente'] = $paciente;
	$_SESSION['nombre'] = $nombre;
	$_SESSION['appPaterno'] = $appPaterno;
	
	header("Location: perfilAsistente.php");
}
else
{
	echo $id;
	header("Location: error.php");
}
?>