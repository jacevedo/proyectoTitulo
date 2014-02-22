<?php
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/css/bootstrap.css">
		<link rel="stylesheet" href="estilos/css/estiloCrearCuenta.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptCrearCuenta.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<div id="nuevaCuenta" class="container">
			<div class="jumbotron">
				<div class="row">
					<div class="col-xs-6 col-sm-4">
						<img src="imagenes/logo.png" id="imagenLogo">
					</div>
					<div class="col-xs-6 col-sm-4">
						<h1>Nueva Cuenta</h1>
					</div>
				</div>
			</div>
			<table class="table">
				<tr>
						<td>Nombre</td>
						<td><input class="textosLargos" type="text" id="txtNombre" placeholder="Esteban"/><span id="errorNombre" class="error" ></span></td>
					</tr>
					<tr>
						<td>Apellido Paterno</td>
						<td><input class="textosLargos" type="text" id="txtAppPaterno" placeholder="Apablaza"/><span id="errorAppPaterno" class="error"></span></td>
					</tr>
					<tr>
						<td>Apellido Materno</td>
						<td><input  class="textosLargos"type="text" id="txtAppMaterno" placeholder="Moreno"/><span id="errorAppMaterno" class="error"></span></td>
					</tr>
					<tr>
						<td>Rut</td>
						<td><input  type="text" id="txtRut" placeholder="17323123" value=""/> - <input type="text" id="txtDv" placeholder="5"/><span id="errorRut" class="error"></span></td>
					</tr>
					<tr>
						<td>Fecha de Nacimiento</td>
						<td><input class="textosLargos" type="date" id="txtFechaNacimiento" placeholder="04-06-1993"/></td>
					</tr>
					<tr>
						<td>Direccion</td>
						<td><input class="textosLargos" type="text" id="txtDireccion" placeholder="San Benito 43"/></td>
					</tr>
					<tr>
						<td>Region</td>
						<td>
							<select class="textosLargos" id="region">
							</select>
						</td>
					</tr>
					<tr>
						<td>Comuna</td>
						<td>
							<select class="textosLargos" id="comuna">
							</select>
						</td>
					</tr>
					<tr>
						<td>Telefono Fijo</td>
						<td><input class="textosLargos" type="text" id="txtFono" placeholder="027780182"/><span id="errorFonoFijo" class="error"></span></td>
					</tr>
					<tr>
						<td>Celular</td>
						<td><input  class="textosLargos"type="text" id="txtCelular" placeholder="555555555"/> <span id="errorFonoCell" class="error"></span></td>
					</tr>
					<tr>
						<td>Email</td>
						<td><input  class="textosLargos"type="text" id="txtMail" placeholder="lala@lala.net"/><span id="errorMail" class="error"></span></td>
					</tr>
					<tr>
						<td>Contrase&ntilde;a</td>
						<td><input class="textosLargos" type="password" id="txtContrasena" placeholder="asdasdasd"/><span id="errorPass" class="error"></span></td>
					</tr>
					<tr>
						<td colspan=2><button id="btnCrearCuenta">Crear Cuenta</button></td>
					</tr>

			</table>
		</div>
	</body>
</html>