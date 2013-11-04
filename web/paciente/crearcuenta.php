<?php
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloCrearCuenta.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptCrearCuenta.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<head>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Crear Cuenta</h1>
			
		</head>
		<div id="cuerpo">
			<div id="logo">
				<img src="imagenes/logo.png" id="imagenCostado">
			</div>
			<div id="Contenido">
				<table id="tablaCrearCuenta">
					<tr>
						<td>Nombre</td>
						<td><input class="textosLargos" type="text" id="txtNombre" value="Lala"/></td>
					</tr>
					<tr>
						<td>Apellido Paterno</td>
						<td><input class="textosLargos" type="text" id="txtAppPaterno" value="Lala"/></td>
					</tr>
					<tr>
						<td>Apellido Materno</td>
						<td><input  class="textosLargos"type="text" id="txtAppMaterno" value="Lala"/></td>
					</tr>
					<tr>
						<td>Rut</td>
						<td><input  type="text" id="txtRut" value="11222333"/> - <input type="text" id="txtDv" value="5"/></td>
					</tr>
					<tr>
						<td>Fecha de Nacimiento</td>
						<td><input class="textosLargos" type="date" id="txtFechaNacimiento"/></td>
					</tr>
					<tr>
						<td>Direccion</td>
						<td><input class="textosLargos" type="text" id="txtDireccion" value="Lala"/></td>
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
						<td><input class="textosLargos" type="text" id="txtFono" value="8888888"/></td>
					</tr>
					<tr>
						<td>Celular</td>
						<td><input  class="textosLargos"type="text" id="txtCelular" value="555555555"/></td>
					</tr>
					<tr>
						<td>Email</td>
						<td><input  class="textosLargos"type="text" id="txtMail" value="lala@lala.net"/></td>
					</tr>
					<tr>
						<td>Contrase&ntilde;a</td>
						<td><input class="textosLargos" type="password" id="txtContrasena" value="lalala"/></td>
					</tr>
					<tr>
						<td colspan=2><button id="btnCrearCuenta">Crear Cuenta</button></td>
					</tr>

					
				</table>
			</div>
		</div>
	</body>
</html>