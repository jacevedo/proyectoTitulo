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
		<script type="text/javascript" src="javascript/scriptPerfil.js"></script>
	</head>
	<body>
		<header>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Mi Perfil</h1>
			<div id="menu">
				<table id="tablaMenu">
					<tr>
						<td><a href="perfil.php">Perfil</a></td>
						<td><a href="reservarHoraPaciente.php">Hora Atencion</a></td>
						<td><a href="ListaPrecios.php">Lista Precios</a></td>
						<td><a href="index.php">Logout</a></td>	
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
					<tr style="display: none;">
						<td class="tdIndicador">Numero:</td>
						<td id="tdNumero"></td>
					</tr>
					<tr style="display: none;">
						<td class="tdIndicador">Perfil</td>
						<td id='tdPerfil'></td>
					</tr>
					<tr>
						<td class="tdIndicador">Nombre:</td>
						<td id="tdNombre"></td>
					</tr>
					<tr>
						<td class="tdIndicador">Apellido Paterno:</td>
						<td id="tdApellidoPaterno"></td>
					</tr>
					<tr>
						<td class="tdIndicador">Apellido Materno:</td>
						<td id="tdApellidoMaterno"></td>
					</tr>
					<tr>
						<td class="tdIndicador">Rut:</td>
						<td id="tdRut"></td>
					</tr>
					<tr>
						<td class="tdIndicador">Fecha de Nacimiento:</td>
						<td id="tdFechaNacimiento"></td>
					</tr>
					<tr>
						<td class="tdIndicador">Direccion:</td>
						<td id='tdDireccion'></td>
					</tr>
					<tr class="regionEscondida">
						<td class="tdIndicador">Region</td>
						<td id='tdRegion'></td>
					</tr>
					<tr>
						<td class="tdIndicador">Comuna</td>
						<td id='tdComuna'></td>
					</tr>
					<tr style="display: none;">
						<td class="tdIndicador">idRegion</td>
						<td id='tdidRegion'></td>
					</tr>
					<tr style="display: none;">
						<td class="tdIndicador">idComuna</td>
						<td id='tdidComuna'></td>
					</tr>
					<tr>
						<td class="tdIndicador">Telefono Fijo</td>
						<td id='tdFonoFijo'></td>
					</tr>
					<tr>
						<td class="tdIndicador">Celular</td>
						<td id='tdFonoCelular'></td>
					</tr>
					<tr>
						<td class="tdIndicador">Email</td>
						<td id='tdEmail'></td>
					</tr>
					<tr style="display: none;">
						<td class="tdIndicador">FechaIngreso</td>
						<td id='tdFechaIngreso'></td>
					</tr>
					<tr>
						<td colspan=2><button id="btnCrearCuenta">Modificar Cuenta</button></td>
					</tr>				
				</table>
			</div>
		</div>
	</body>
</html>