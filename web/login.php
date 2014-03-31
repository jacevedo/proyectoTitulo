<?php
	session_start();

	$id = $_POST['user'];
	$key = $_POST['key'];
	$paciente = $_POST['pacienteId'];
	$nombre = $_POST['nombre'];
	$appPaterno = $_POST['appPaterno'];
	$codigo = $_POST['codigo'];

	if($key != "" && $id != "" && $paciente != "" && $nombre != "" && $appPaterno != "" && $codigo != "")
	{
		if($codigo == 707 || $codigo == 706 || $codigo == 705)
		{
			$_SESSION['key'] = $key;
			$_SESSION['user'] = $id;
			$_SESSION['paciente'] = $paciente;
			$_SESSION['nombre'] = $nombre;
			$_SESSION['appPaterno'] = $appPaterno;
			
			header("Location: ../web/asistente/perfilAsistente.php");
		}
		else if($codigo == 704)
		{
			$_SESSION['key'] = $key;
			$_SESSION['user'] = $id;
			$_SESSION['paciente'] = $paciente;
			$_SESSION['nombre'] = $nombre;
			$_SESSION['appPaterno'] = $appPaterno;
			
			header("Location: ../web/paciente/perfil.php");
		}
		else
		{
			header("Location: algo.php");
		}
	}
	else
	{
		echo $id;
		header("Location: error.php");
	}
?>