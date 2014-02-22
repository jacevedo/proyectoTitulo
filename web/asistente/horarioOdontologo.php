<?php
session_start();
$idOdontologo = $_POST["idOdontologo"]; 
//echo($_SESSION['key']);
//echo($_SESSION['user']);
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/css/bootstrap.css">
		<link rel="stylesheet" href="estilos/css/estiloReservarHora.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/horariosOdontologo.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<div class="container">
			<input type="hidden" value=<?=$_SESSION['user'];?> id="idPaciente">
			<input type="hidden" value=<?=$_SESSION['key'];?> id="keyPaciente">
			<input type="hidden" value=<?=$_SESSION['paciente'];?> id="pacientes">
			<input type="hidden" value=<?=$idOdontologo;?> id="idOdontologo">
			<div class="navbar navbar-default" role="navigation">
		        <div class="navbar-header">
		          <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
		            <span class="sr-only">Toggle navigation</span>
		            <span class="icon-bar"></span>
		            <span class="icon-bar"></span>
		            <span class="icon-bar"></span>
		          </button>
		          <a class="navbar-brand" href="#">SFH <img src="imagenes/logo.png" id="imagenCostado"></a>
		        </div>
		        <div class="navbar-collapse collapse">
		          <ul class="nav navbar-nav">
		            <li ><a href="perfil.php">Perfil</a></li>
		            <li class="active"><a href="confirmarhora.php">Hora Atencion</a></li>
		            <li><a href="listaPrecios.php">Lista Precios</a></li>
		           	<li><a href="listaOdontologos.php">Horarios Odontologo</a></li>
		          </ul>
		          <ul class="nav navbar-nav navbar-right">
		            <li class="active"><a href="#"><p id="nomUsuario"> <?php echo($_SESSION['nombre']);?> <?php echo($_SESSION['appPaterno']);?> </p></a></li>
		             <li><a href="logout.php">Logout</a></li>
		          </ul>
		        </div><!--/.nav-collapse -->
		    </div>
		    <div class="jumbotron">
		    	<h1>
		      		Horarios
		      	</h1>
		      	<input type="hidden" id="idUsuario" value=""/>
		      	<table id="tablaReservarHoraAsistente" class="tab">
					<tr>
						<td>Dia</td>
						<td>Hora Inicio</td>
						<td>Hora Termino</td>
						<td>Duracion Modulo</td>
						<td></td>
					</tr>
					<tr>
						<td>Lunes</td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciolunes" type="text" id="txtHoraIniciolunes"/><br><span id="spanHoraIniciolunes"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminolunes" type="text" id="txtHoraTerminolunes"/><br><span id="spanHoraTerminolunes"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulolunes" type="text" id="txtDuracionModulolunes"/><br><span id="spanDuracionModulolunes"></span></td>
						<td><Button dia="lunes" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>
					</tr>
					<tr>
						<td>Martes</td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciomartes" type="text" id="txtHoraIniciomartes"/><br><span id="spanHoraIniciomartes"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminomartes" type="text" id="txtHoraTerminomartes"/><br><span id="spanHoraTerminomartes"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulomartes" type="text" id="txtDuracionModulomartes"/><br><span id="spanDuracionModulomartes"></span></td>
						<td><Button dia="martes" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>
					</tr>
					<tr>
						<td>Miercoles</td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciomiercoles" type="text" id="txtHoraIniciomiercoles"/><br><span id="spanHoraIniciomiercoles"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminomiercoles" type="text" id="txtHoraTerminomiercoles"/><br><span id="spanHoraTerminomiercoles"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulomiercoles" type="text" id="txtDuracionModulomiercoles"/><br><span id="spanDuracionModulomiercoles"></span></td>
						<td><Button dia="miercoles" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>
					</tr>
					<tr>
						<td>Jueves</td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciojueves" type="text" id="txtHoraIniciojueves"/><br><span id="spanHoraIniciojueves"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminojueves" type="text" id="txtHoraTerminojueves"/><br><span id="spanHoraTerminojueves"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulojueves" type="text" id="txtDuracionModulojueves"/><br><span id="spanDuracionModulojueves"></span></td>
						<td><Button dia="jueves" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>							
					</tr>
					<tr>
						<td>Viernes</td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraInicioviernes" type="text" id="txtHoraInicioviernes"/><br><span id="spanHoraInicioviernes"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminoviernes" type="text" id="txtHoraTerminoviernes"/><br><span id="spanHoraTerminoviernes"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModuloviernes" type="text" id="txtDuracionModuloviernes"/><br><span id="spanDuracionModuloviernes"></span></td>
						<td><Button dia="viernes" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>										
					</tr>
					<tr>
						<td>Sabado</td>		
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciosabado" type="text" id="txtHoraIniciosabado"/><br><span id="spanHoraIniciosabado"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminosabado" type="text" id="txtHoraTerminosabado"/><br><span id="spanHoraTerminosabado"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulosabado" type="text" id="txtDuracionModulosabado"/><br><span id="spanDuracionModulosabado"></span></td>
						<td><Button dia="sabado" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>						
					</tr>
					<tr>
						<td>Domingo</td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciodomingo" type="text" id="txtHoraIniciodomingo"/><br><span id="spanHoraIniciodomingo"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminodomingo" type="text" id="txtHoraTerminodomingo"/><br><span id="spanHoraTerminodomingo"></span></td>
						<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulodomingo" type="text" id="txtDuracionModulodomingo"/><br><span id="spanDuracionModulodomingo"></span></td>
						<td><Button dia="domingo" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>
					</tr>
				</table>
		    </div>
		</div>
	</body>
</html>