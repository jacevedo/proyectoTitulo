<?php
session_start();
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloTomarHoraPaciente.css">
		<script type="text/javascript" src="javascript/scriptReservarHoraPaciente.js"></script>
	</head>
	<body>
		<head>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Reservar Hora</h1>
			<div id="menu">
				<table id="tablaMenu">
					<tr>
						<td><a href="perfil.php">Perfil</a></td>
						<td><a href="reservarHoraPaciente.php">Hora Atencion</a></td>
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
				<table id="tablaTomarHora">
					<tr>
						<td class="encabezado">Fecha</td>
						<td><input type="date" id="txtFecha"/></td>
										
					</tr>
					<tr>
						<td class="encabezado">Hora</td>
						<td><input type="text" id="txtHora"/></td>
					</tr>
					<tr>
						<td class="encabezado">Dentista</td>
						<td>
							<select id="selectDentista">
								<option value="--">--</option>
								<option value="01">Dra. Pamela Acevedo</option>
								<option value="02">Dr. Ariel Garrido</option>
								<option value="02">Dr. German Garrido</option>
							</select>
						</td>
					</tr>
					<tr>
						<td colspan=2><button id="btnReservarHoraPaciente">Reservar Hora</button></td>
					</tr>
				</table>
			</div>
		</div>
	</body>
</html>