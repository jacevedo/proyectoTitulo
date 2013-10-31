<?php
session_start();
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloLogin.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptLogin.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<header>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1 id="titulo">Sistema de Fichas Medicas y Toma de Horas (SFH)</h1>
		</header>
		<div id="cuerpo">
			<div id="logo">
				<img src="imagenes/logo.png" >
			</div>
			<div id="login">
				<p id="textoBienvenida"> Bienvenido SFH.</br>Ingresa tu usuario y contrase&ntilde;a </p>
				<table>
					<tr>
						<td>Usuario</td>
						<td><input type="text" id="txtUsuario"/></td>
					</tr>
					<tr>
						<td>Contrase&ntilde;a</td>
						<td><input type="password" id="txtPass"/></td>
					</tr>
					<tr>
						<td colspan=2><button id="btnIngresar" value="Login">Login</button></td>
					</tr>
				</table>
			</div>
		</div>
	</body>
</html>