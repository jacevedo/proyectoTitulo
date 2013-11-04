<?php
session_start();
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloListaPrecios.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptListaPrecios.js"></script>
	</head>
	<body>
		<head>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Lista de Precios</h1>
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
				
				<div id="campos">
				 <input type="search" id="txtBuscaTratamiento"/><button id="btnBuscar">Buscar</button>
				</div>
				<table id="tablaListaPrecios">
					<thead>
						<tr>
							<td>Nro</td>
							<td>Nombre Tratamiento</td>
							<td>Precio</td>
						</tr>
					</thead>
					<tbody id="cuerpoTabla">
						
					</tbody>
				</table>
			</div>
		</div>
	</body>
</html>