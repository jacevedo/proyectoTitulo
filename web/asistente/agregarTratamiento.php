<?php
session_start();
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloAgregarTratamiento.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptAgregarTratamiento.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<head>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Agregar Tratamiento</h1>
			<div id="menu">
				<table id="tablaMenu">
					<tr>
						<td><a href="perfil.php">Perfil</a></td>
						<td><a href="confirmarHora.php">Hora Atencion</a></td>
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
				<table id="tablaAgregarTratamiento">
					<tr>
						<td class="tdNombre">Nombre Tratamiento</td>
						<td><input type="text" id="txtNomTratamiento"/></td>
										
					</tr>
					<tr>
						<td class="tdNombre">Precio Neto</td>
						<td><input type="text" id="txtNeto"/></td>
					</tr>
					<tr>
						<td class="tdNombre">Precio Iva</td>
						<td><input type="text" id="txtIva" disabled/></td>
					</tr>
					<tr>
						<td class="tdNombre">Precio Total</td>
						<td><input type="text" id="txtTotal" disabled/></td>
					</tr>
					<tr>
						<td colspan=2><button id="btnAgregarTratamiento">Agregar</button></td>
					</tr>
				</table>
			</div>
		</div>
	</body>
</html>