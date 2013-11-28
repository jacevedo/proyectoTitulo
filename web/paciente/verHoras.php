<?php
session_start();
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloTomarHoraPaciente.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptVerHoraPaciente.js"></script>
	</head>
	<body>
		<head>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Reservar Hora</h1>
			<div id="menu">
				<table id="tablaMenu">
					<tr>
						<td><a href="perfil.php">Perfil</a></td>
						<td><a href="verHoras.php">Hora Atencion</a></td>
						<td><a href="listaPrecios.php">Lista Precios</a></td>
						<td><a href="logout.php">Logout</a></td>	
					</tr>
				</table>
			</div>
		</head>
		<div id="cuerpo">
			<div id="logo">
				<img src="imagenes/logo.png" id="imagenCostado">
			</div>
			<div id="Contenido">
				<input type="hidden" value=<?=$_SESSION['user'];?> id="idPaciente">
				<input type="hidden" value=<?=$_SESSION['key'];?> id="keyPaciente">
				<input type="hidden" value=<?=$_SESSION['paciente'];?> id="pacientes">
				
				<table id="tablaTomarHora">
					<tr>
						<td class="encabezado">Fecha</td>
						<td class="encabezado">Dentista</td>
						<td class="encabezado">Hora</td>
					</tr>
					<tr class="tablaHorasReservadas"></tr>
					<tr>
						<td colspan=3><button id="btnReservarHoraPaciente">Reservar Hora</button></td>
					</tr>
				</table>
			</div>
		</div>
	</body>
</html>