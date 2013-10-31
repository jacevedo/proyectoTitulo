<?php
session_start();
//echo($_SESSION['key']);
//echo($_SESSION['user']);
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloListaPrecios.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptListaPrecios.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<head>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Lista de Precios</h1>
			<div id="menu">
				<table id="tablaMenu">
					<tr>
						<td><a href="perfil.php">Perfil</a></td>
						<td><a href="confirmarHora.php">Hora Atencion</a></td>
						<td><a href="listaPrecios.php">Lista Precios</a></td>
						<td><a href="index.php">Logout</a></td>	
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
				<div id="campos">
				 <input type="search" id="txtBuscaTratamiento"/>
					 <div id="botones">
					 	<button id="btnBuscar">Buscar</button>
						<button id="btnAgregarTratamiento">Agregar Tratamiento</button>
					</div>
				</div>
				<table id="tablaListaPrecios">
					<thead>
						<tr>
							<td>Nro</td>
							<td>Nombre Tratamiento</td>
							<td>Precio</td>
							<td style="width: 70px;">Editar</td>
							<td style="width: 70px;">Eliminar</td>
						</tr>
					</thead>
					<tbody id="cuerpoTabla">
						
					</tbody>
				</table>
			</div>
		</div>
	</body>
</html>