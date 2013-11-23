<?php
session_start();
//echo($_SESSION['key']);
//echo($_SESSION['user']);
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/estiloBase.css">
		<link rel="stylesheet" href="estilos/estiloConfirmarHora.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptConfirmarHora.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<head>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Confirmar Hora</h1>
			<div id="menu">
				<table id="tablaMenu">
					<tr>
						<td><a href="perfil.php">Perfil</a></td>
						<td><a href="confirmarhora.php">Hora Atencion</a></td>
						<td><a href="ListaPrecios.php">Lista Precios</a></td>
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
				<div id="campos">
					<input type="date" id="dateFecha" /> <input type="search" id="txtBuscar"/><a href="modificarEliminarHora.html"><button id="btnBuscar">Buscar</button></a>

				</div>
				<table id="tablaConfirmarHora"> 
					<thead>
						<tr>
							<td class="tdId">id</td>
							<td class="tdNombre">Nombre Paciente</td>
							<td class="tdTelefono">Telefono</td>
							<td class="tdHora">Hora</td>
							<td class="tdDentista">Dentista</td>
							<td class="tdConfirmar">Confirmar</td>
							<td class="tdConfirmar">Modificar</td>
							<td class="tdConfirmar">Eliminar</td>
							
						</tr>
					</thead>
					<tbody id="cuerpoTabla">
						
					</tbody>
					<tfoot>
						<tr>
							<td colspan=7><button class="btnOpcionesMenu" id="btnConfirmarHora">Confirmar Hora</button><a href="ReservarHoraAsistente.html"><button class="btnOpcionesMenu" id="btnNuevaHora">Nueva Hora</button></a></td>
						</tr>
					</tfoot>					
				</table>
				<div id="paginas">
					<a href="#"><< Prev</a>
					<a href="#">1</a>
					<a href="#">2</a>
					<a href="#">3</a>
					<a href="#">4</a>
					<a href="#">5</a>
					<a href="#">6</a>
					<a href="#">next >></a>
				</div>
			</div>
		</div>
	</body>
</html>