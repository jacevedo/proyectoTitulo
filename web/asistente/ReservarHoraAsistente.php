<?php
session_start();
//echo($_SESSION['key']);
//echo($_SESSION['user']);
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/css/bootstrap.css">
		<link rel="stylesheet" href="estilos/css/estiloReservarHora.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptReservarHoraAsistente.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<div class="container">
			<input type="hidden" value=<?=$_SESSION['user'];?> id="idPaciente">
			<input type="hidden" value=<?=$_SESSION['key'];?> id="keyPaciente">
			<input type="hidden" value=<?=$_SESSION['paciente'];?> id="pacientes">
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
		      		Reservar Hora de Atencion
		      	</h1>
		      	<input type="hidden" id="idUsuario" value=""/>
		      	<table id="tablaReservarHoraAsistente" class="tab">
					<tr>
						<td>Rut</td>
						<td><input type="text" id="txtRut"/> - <input type="text" id="txtDv"/><span id="spanErrorRut" class="error"></span></td>
					</tr>
					<tr>
						<td>Nombre</td>
						<td><input class="inputHora" type="text" id="txtNombre"/><span id="spanErrorNombre" class="error"></span></td>
					</tr>
					<tr>
						<td>Apellido Paterno</td>
						<td><input class="inputHora" type="text" id="txtAppPaterno"/><span id="spanErrorAppPaterno" class="error"></span></td>
					</tr>
					<tr>
						<td>Apellido Materno</td>
						<td><input class="inputHora" type="text" id="txtAppMaterno"/><span id="spanErrorAppMaterno" class="error"></span></td>
					</tr>
					<tr>
						<td>Fecha de Nacimiento</td>
						<td><input class="inputHora" type="date" id="txtFechaNacimiento"/></td>									
					</tr>
					<tr>
						<td>Fecha a Reservar</td>
						<td><input class="inputHora" type="date" id="txtFecha"/></td>
										
					</tr>
					<tr>
						<td>Dentista</td>
						<td>
							<select id="selectDentista">
								<option value="--">--</option>
								
							</select>
							<span id="spanErrorDentista" class="error"></span>
						</td>
										
					</tr>
					<tr>
						<td>Hora</td>
						<td>
							<select id="selectHora">
								<option value="--">--</option>
							</select>
							<span id="spanErrorHora" class="error"></span>
						</td>
					</tr>
				</table>
				<button id="btnReservarHora" class="btn btn-lg btn-primary btn-block">Reservar Hora</button>
		    </div>
		</div>
	</body>
</html>