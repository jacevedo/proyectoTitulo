<?php
session_start();
//echo($_SESSION['key']);
//echo($_SESSION['user']);
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloPerfil.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/script.js"></script>
	</head>
	<body>
		<header>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Mi Perfil</h1>
			<div id="menu">
				<table id="tablaMenu">
					<tr>
						<td><a href="perfil.html">Perfil</a></td>
						<td><a href="reservarHoraPaciente.html">Hora Atencion</a></td>
						<td><a href="ListaPrecios.html">Lista Precios</a></td>
						<td><a href="index.html">Logout</a></td>	
					</tr>
				</table>
			</div>
		</header>
		<div id="cuerpo">
			<div id="logo">
				<img src="imagenes/logo.png" id="imagenCostado">
			</div>
			<div id="Contenido">
				<input type="hidden" value=<?=$_SESSION['user'];?> id="idPaciente">
				<input type="hidden" value=<?=$_SESSION['key'];?> id="keyPaciente">

				<table id="tablaContenido">
					<tr>
						<td class="tdIndicador">Nombre:</td>
						<td>Juan</td>
					</tr>
					<tr>
						<td class="tdIndicador">Apellido Paterno:</td>
						<td>Perez</td>
					</tr>
					<tr>
						<td class="tdIndicador">Apellido Materno:</td>
						<td>Saavedra</td>
					</tr>
					<tr>
						<td class="tdIndicador">Rut:</td>
						<td>14.359.018-7</td>
					</tr>
					<tr>
						<td class="tdIndicador">Fecha de Nacimiento:</td>
						<td>05/09/1986</td>
					</tr>
					<tr>
						<td class="tdIndicador">Direccion:</td>
						<td>Calle Falsa 123</td>
					</tr>
					<tr>
						<td class="tdIndicador">Comuna</td>
						<td>Springfield</td>
					</tr>
					<tr>
						<td class="tdIndicador">Telefono Fijo</td>
						<td>27563312</td>
					</tr>
					<tr>
						<td class="tdIndicador">Celular</td>
						<td>96304102</td>
					</tr>
					<tr>
						<td colspan=2><a href="modificarCuenta.html"><button id="btnCrearCuenta">Modificar Cuenta</button></a></td>
					</tr>

					
				</table>
			</div>
		</div>
	</body>
</html>