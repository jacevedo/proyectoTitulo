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
		<title>SFH</title>
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
		            <li ><a href="perfil.php">Perfil</a></li>
		            <li><a href="confirmarHora.php">Hora Atencion</a></li>
		            <li class="active"><a href="listaPrecios.php">Lista Precios</a></li>
		           
		          </ul>
		          <ul class="nav navbar-nav navbar-right">
		            <li class="active"><a href="#"><p id="nomUsuario"> <?php echo($_SESSION['nombre']);?> <?php echo($_SESSION['appPaterno']);?> </p></a></li>
		             <li><a href="logout.php">Logout</a></li>
		          </ul>
		        </div><!--/.nav-collapse -->
		    </div>
		    <div class="jumbotron">
		    	<h1>
		      		Lista de Precios
		      	</h1>
		    </div>
		</div>
		<head>
			<img src="imagenes/logo.png" id="imagenLogo">
			<h1>SFH: Lista de Precios</h1>
			<div id="menu">
				<table id="tablaMenu">
					<tr>
						<td><a href="perfil.php">Perfil</a></td>
						<td><a href="confirmarHora.php">Hora Atencion</a></td>
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