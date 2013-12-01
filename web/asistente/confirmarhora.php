<?php
session_start();
//echo($_SESSION['key']);
//echo($_SESSION['user']);
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/css/bootstrap.css">
		<link rel="stylesheet" href="estilos/css/estiloConfirmarHora.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptConfirmarHora.js"></script>
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
		      		Confirmar Hora
		      	</h1>
		      	<div class="panel panel-default">
					 <div class="panel-heading">
					 	<div class="row">
						 	<div class="col-xs-6 col-sm-4">
								<input type="date" id="dateFecha" />
							</div>
							 <div id="botones" class="col-xs-6 col-sm-4">
							 	<input type="search" id="txtBuscar"/>
							</div>
							<div id="botones" class="col-xs-6 col-sm-4">
								<a href="modificarEliminarHora.html"><button id="btnBuscar" class="btn btn-lg btn-primary btn-block">Buscar</button></a>
							</div>
						</div>
						<div class="row">
					  		<div class="col-xs-6 col-sm-4">
					  			<a href="ReservarHoraAsistente.php" ><button id="btnCrearHora" class="btn btn-lg btn-primary btn-block">Reservar Hora atencion</button></a>
					  		</div>
					  		<div class="col-xs-6 col-sm-4">
					  		</div>
							<div class="col-xs-6 col-sm-4">
					  			<button id="btnConfirmarHora" class="btn btn-lg btn-primary btn-block">Confirmar Hora</button>
					  		</div>
					  	</div>
					 </div>
					  <!-- Table -->
					  <table class="table" id="tablaConfirmarHora">
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
					  </table>

				</div>
		  </div>
		</div>




		<!--<head>
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
		</div>-->
	</body>
</html>