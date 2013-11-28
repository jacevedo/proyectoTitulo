<?php
session_start();

$id = $_POST['user'];
$key = $_POST['key'];
$paciente = $_POST['pacienteId'];
$nomPaciente = $_POST['nomPaciente'];
$appPaciente = $_POST['appPaciente'];

if($key != "" && $id != "" && $paciente != "")
{
	$_SESSION['key'] = $key;
	$_SESSION['user'] = $id;
	$_SESSION['paciente'] = $paciente;
	$_SESSION['nombre'] = $nomPaciente;
	$_SESSION['apellido'] = $appPaciente;
	
	header("Location: perfil.php");
}
else
{
	echo $id;
	header("Location: error.php");
}
?>