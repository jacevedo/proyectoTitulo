<?php
session_start();
//echo($_SESSION['key']);
//echo($_SESSION['user']);
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloReservarHoraAsistente.css">
		<script type="text/javascript" src="javascript/scriptReservarHoraAsistente.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<head>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Reservar Hora</h1>
			<div id="menu">
				<table id="tablaMenu">
					<tr>
						<td><a href="perfil.html">Perfil</a></td>
						<td><a href="crearcuenta.html">Crear Cuenta</a></td>
						<td><a href="confirmarhora.html">Hora Atencion</a></td>
						<td><a href="ListaPrecios.html">Lista Precios</a></td>
						<td><a href="index.html">Logout</a></td>	
					</tr>
				</table> 
			</div>
		</head>
		<div id="cuerpo">
			<div id="logo">
				<img src="imagenes/logo.png" id="imagenCostado">
			</div>
			<div id="Contenido">
				
				<table id="tablaReservarHoraAsistente">
					<tr>
						<td>Rut</td>
						<td><input type="text" id="txtRut"/> - <input type="text" id="txtDv"/></td>
					</tr>
					<tr>
						<td>Nombre</td>
						<td><input class="inputHora" type="text" id="txtNombre"/></td>
					</tr>
					<tr>
						<td>Apellido Paterno</td>
						<td><input class="inputHora" type="text" id="txtAppPaterno"/></td>
					</tr>
					<tr>
						<td>Apellido Materno</td>
						<td><input class="inputHora" type="text" id="txtAppMaterno"/></td>
					</tr>
					<tr>
						<td>Telefono</td>
						<td><input class="inputHora" type="text" id="txtTelefono"/></td>									
					</tr>
					<tr>
						<td>Fecha</td>
						<td><input class="inputHora" type="date" id="txtFecha"/></td>
										
					</tr>
					<tr>
						<td>Hora</td>
						<td><input class="inputHora" type="text" id="txtHora"/></td>
					</tr>
					<tr>
						<td>Dentista</td>
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
						<td colspan=2><button id="btnReservarHora">Reservar Hora</button></td>
					</tr>
				</table>
			</div>
		</div>
	</body>
</html>