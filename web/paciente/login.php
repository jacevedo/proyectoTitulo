<?php
session_start();

$id = $_POST['user'];
$key = $_POST['key'];

//echo "id:".$id." key:".$key;

if($key != "" && $id != "")
{
	$_SESSION['key'] = $key;
	$_SESSION['user'] = $id;
	header("Location: perfil.php");
	//16009332
}
else
{
	echo $id;
	header("Location: error.php");
}
?>