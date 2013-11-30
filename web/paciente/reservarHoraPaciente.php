<?php
session_start();
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/css/bootstrap.css">
		<link rel="stylesheet" href="estilos/css/estiloHoras.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptReservarHoraPaciente.js"></script>
	</head>
	<body>
		<div class="container">
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
		            <li class="active"><a href="perfil.php">Perfil</a></li>
		            <li><a href="verHoras.php">Hora Atencion</a></li>
		            <li><a href="ListaPrecios.php">Lista Precios</a></li>
		           
		          </ul>
		          <ul class="nav navbar-nav navbar-right">
		            <li class="active"><a href="#"><p id="nomUsuario"> <?=$_SESSION['nombre'];?> <?=$_SESSION['apellido'];?> </p></a></li>
		             <li><a href="logout.php">Logout</a></li>
		          </ul>
		        </div><!--/.nav-collapse -->
		    </div>
		    <div class="jumbotron">
		    	<input type="hidden" value=<?=$_SESSION['user'];?> id="idPaciente">
				<input type="hidden" value=<?=$_SESSION['key'];?> id="keyPaciente">
				<input type="hidden" value=<?=$_SESSION['paciente'];?> id="pacientes">
				<h1>Tomar Hora</h1>
				<table id="tablaTomarHora" class="table">
					<tr>
						<td class="encabezado">Fecha</td>
						<td><input type="date" id="txtFecha"/></td>
										
					</tr>
					<tr>
						<td class="encabezado">Dentista</td>
						<td><select id="selectDentista"></select></td>
					</tr>
					<tr>
						<td class="encabezado">Hora</td>
						<td><select id="selectHora"></select></td>
					</tr>
					<tr>
						<td colspan=2><button id="btnReservarHoraPaciente" class="btn btn-lg btn-primary btn-block">Reservar Hora</button></td>
					</tr>
				</table>
		    </div>
		  </div>
		
		</div>
	</body>
</html>