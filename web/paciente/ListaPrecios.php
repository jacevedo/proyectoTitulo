<?php
session_start();
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/css/bootstrap.css">
		<link rel="stylesheet" href="estilos/css/estiloListaPrecios.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptListaPrecios.js"></script>
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
				<h1>Precios</h1>
				<div class="panel-heading">
					 	<div class="row">
					 		<div class="col-xs-12 col-sm-6 col-lg-8">
							 <input type="search" id="txtBuscaTratamiento"/>
							</div>
							<div class="col-xs-6 col-sm-4">
							 <button id="btnBuscar" class="btn btn-lg btn-primary btn-block">Buscar</button>
							</div>
						 	
						</div>
					 </div>
				<table id="tablaListaPrecios" class="table">
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