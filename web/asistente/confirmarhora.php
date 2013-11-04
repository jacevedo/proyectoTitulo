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
					<tr>
						<td class="tdNombre">Nombre</td>
						<td class="tdTelefono">Telefono</td>
						<td class="tdHora">Hora</td>
						<td class="tdDentista">Dentista</td>
						<td class="tdConfirmar">Confirmar</td>
						
					</tr>
					<tr>
						<td class="tdNombre">Juan Peres</td>
						<td class="tdTelefono">27362988</td>
						<td class="tdHora">09:00</td>
						<td class="tdDentista">Dra. Pamela Acevedo</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Camila Rios</td>
						<td class="tdTelefono">24559087</td>
						<td class="tdHora">09:00</td>
						<td class="tdDentista">Dr. Ariel Garrido</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Daniel Gernandez</td>
						<td class="tdTelefono">24559087</td>
						<td class="tdHora">09:00</td>
						<td class="tdDentista">Dr. German Garrido</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Juan Peres</td>
						<td class="tdTelefono">27362988</td>
						<td class="tdHora">10:00</td>
						<td class="tdDentista">Dra. Pamela Acevedo</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Camila Rios</td>
						<td class="tdTelefono">24559087</td>
						<td class="tdHora">10:00</td>
						<td class="tdDentista">Dr. Ariel Garrido</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Daniel Gernandez</td>
						<td class="tdTelefono">24559087</td>
						<td class="tdHora">10:00</td>
						<td class="tdDentista">Dr. German Garrido</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Juan Peres</td>
						<td class="tdTelefono">27362988</td>
						<td class="tdHora">11:00</td>
						<td class="tdDentista">Dra. Pamela Acevedo</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Camila Rios</td>
						<td class="tdTelefono">24559087</td>
						<td class="tdHora">11:00</td>
						<td class="tdDentista">Dr. Ariel Garrido</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Daniel Gernandez</td>
						<td class="tdTelefono">24559087</td>
						<td class="tdHora">11:00</td>
						<td class="tdDentista">Dr. German Garrido</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Juan Peres</td>
						<td class="tdTelefono">27362988</td>
						<td class="tdHora">12:00</td>
						<td class="tdDentista">Dra. Pamela Acevedo</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Camila Rios</td>
						<td class="tdTelefono">24559087</td>
						<td class="tdHora">12:00</td>
						<td class="tdDentista">Dr. Ariel Garrido</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td class="tdNombre">Daniel Gernandez</td>
						<td class="tdTelefono">24559087</td>
						<td class="tdHora">12:00</td>
						<td class="tdDentista">Dr. German Garrido</td>
						<td class="tdConfirmar"><input type="checkbox" class="chkConfimado"/></td>
						
					</tr>
					<tr>
						<td colspan=5><button class="btnOpcionesMenu" id="btnConfirmarHora">Confirmar Hora</button><a href="ReservarHoraAsistente.html"><button class="btnOpcionesMenu" id="btnNuevaHora">Nueva Hora</button></a></td>
					</tr>					
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