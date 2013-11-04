<?php
session_start();

$id = $_POST['user'];
$key = $_POST['key'];
$paciente = $_POST['pacienteId'];

if($key != "" && $id != "" && $paciente != "")
{
	$_SESSION['key'] = $key;
	$_SESSION['user'] = $id;
	$_SESSION['paciente'] = $paciente;
	
	header("Location: perfil.php");
}
else
{
	echo $id;
	header("Location: error.php");
}
?>