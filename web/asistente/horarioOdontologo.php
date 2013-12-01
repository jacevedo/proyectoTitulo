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
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraIniciolunes"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraTerminolunes"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtDuracionModulolunes"/></td>
						<td><Button dia="lunes" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>
					</tr>
					<tr>
						<td>Martes</td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraIniciomartes"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraTerminomartes"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtDuracionModulomartes"/></td>
						<td><Button dia="martes" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>
					</tr>
					<tr>
						<td>Miercoles</td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraIniciomiercoles"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraTerminomiercoles"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtDuracionModulomiercoles"/></td>
						<td><Button dia="miercoles" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>
					</tr>
					<tr>
						<td>Jueves</td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraIniciojueves"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraTerminojueves"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtDuracionModulojueves"/></td>
						<td><Button dia="jueves" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>							
					</tr>
					<tr>
						<td>Viernes</td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraInicioviernes"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraTerminoviernes"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtDuracionModuloviernes"/></td>
						<td><Button dia="viernes" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>										
					</tr>
					<tr>
						<td>Sabado</td>		
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraIniciosabado"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraTerminosabado"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtDuracionModulosabado"/></td>
						<td><Button dia="sabado" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>						
					</tr>
					<tr>
						<td>Domingo</td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraIniciodomingo"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtHoraTerminodomingo"/></td>
						<td><input placeholder="00:00:00" class="inputHora" type="text" id="txtDuracionModulodomingo"/></td>
						<td><Button dia="domingo" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>
					</tr>
				</table>
		    </div>
		</div>
	</body>
</html>