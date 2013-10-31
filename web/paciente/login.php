<?php
session_start();

$id = $_POST['user'];
$key = $_POST['key'];

if($key != "" && $id != "")
{
	$_SESSION['key'] = $key;
	$_SESSION['user'] = $id;
	header("Location: perfil.php");
}
else
{
	echo $id;
	header("Location: error.php");
}
?>