<?php
session_start();
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/css/bootstrap.css">
		<link rel="stylesheet" href="estilos/css/estiloPerfil.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script src="estilos/js/bootstrap.min.js"></script>
		<script type="text/javascript" src="javascript/scriptPerfil.js"></script>
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
		            <li class="active"><a href="perfil.php">Perfil</a></li>
		            <li><a href="confirmarHora.php">Hora Atencion</a></li>
		            <li><a href="listaPrecios.php">Lista Precios</a></li>
		           
		          </ul>
		          <ul class="nav navbar-nav navbar-right">
		            <li class="active"><a href="#"><p id="nomUsuario"> <?php echo($_SESSION['nombre']);?> <?php echo($_SESSION['appPaterno']);?> </p></a></li>
		             <li><a href="logout.php">Logout</a></li>
		          </ul>
		        </div><!--/.nav-collapse -->
		      </div>
		      <div class="jumbotron">
		      	<input type="hidden" value=<?=$_SESSION['user'];?> id="idPaciente">
				<input type="hidden" value=<?=$_SESSION['key'];?> id="keyPaciente">
				<input type="hidden" value=<?=$_SESSION['paciente'];?> id="pacientes">
		      	<h1>
		      		Mi Perfil
		      	</h1>
		      	<div class="row">
			      	<div class="col-xs-6 col-lg-4">Nombre:</div>
			      	<div id="tdNombre" class="col-xs-12 col-sm-6 col-lg-8"></div>
			    </div>
			    <div class="row">
			      	<div class="col-xs-6 col-lg-4">Apellido Paterno:</div>
			      	<div id="tdApellidoPaterno" class="col-xs-12 col-sm-6 col-lg-8"></div>
		      	</div>
		      	<div class="row">
			      	<div class="col-xs-6 col-lg-4">Apellido Materno:</div>
			      	<div id="tdApellidoMaterno" class="col-xs-12 col-sm-6 col-lg-8"></div>
		      	</div>
		      	<div class="row">
			      	<div class="col-xs-6 col-lg-4">Rut:</div>
			      	<div id="tdRut" class="col-xs-12 col-sm-6 col-lg-8"></div>
			    </div>
		      	<div class="row">  	
			      	<div class="col-xs-6 col-lg-4">Fecha de Nacimiento:</div>
			      	<div id="tdFechaNacimiento" class="col-xs-12 col-sm-6 col-lg-8"></div>
			    </div>
		      	<div class="row">
			      	<div class="col-xs-6 col-lg-4">Direccion:</div>
			      	<div id="tdDireccion" class="col-xs-12 col-sm-6 col-lg-8"></div>
			    </div>
		      	<div class="row">
			      	<div class="col-xs-6 col-lg-4">Region:</div>
			      	<div id="tdRegion" class="col-xs-12 col-sm-6 col-lg-8"></div>
			    </div>
		      	<div class="row">
			      	<div class="col-xs-6 col-lg-4">Comuna:</div>
			      	<div id="tdComuna" class="col-xs-12 col-sm-6 col-lg-8"></div>
			    </div>
		      	<div class="row">
			      	<div class="col-xs-6 col-lg-4">Telefono Fijo:</div>
			      	<div id="tdFonoFijo" class="col-xs-12 col-sm-6 col-lg-8"></div>
			    </div>
		      	<div class="row">
			      	<div class="col-xs-6 col-lg-4">Celular:</div>
			      	<div id="tdFonoCelular" class="col-xs-12 col-sm-6 col-lg-8"></div>
			    </div>
		      	<div class="row">
			      	<div class="col-xs-6 col-lg-4">Email:</div>
			      	<div id="tdEmail" class="col-xs-12 col-sm-6 col-lg-8"></div>
		      	</div>
		      	<div class="row">
		      		<button id="btnCrearCuenta" class="btn btn-lg btn-primary btn-block" type="submit">Modificar</button>
		      	</div>
		      	<table id="tablaContenido">
					<tr style="display: none;">
						<td class="tdIndicador">Numero:</td>
						<td id="tdNumero"></td>
					</tr>
					<tr style="display: none;">
						<td class="tdIndicador">Perfil</td>
						<td id='tdPerfil'></td>
					</tr>
					
					<tr style="display: none;">
						<td class="tdIndicador">idRegion</td>
						<td id='tdidRegion'></td>
					</tr>
					<tr style="display: none;">
						<td class="tdIndicador">idComuna</td>
						<td id='tdidComuna'></td>
					</tr>
					
					<tr style="display: none;">
						<td class="tdIndicador">FechaIngreso</td>
						<td id='tdFechaIngreso'></td>
					</tr>
					<tr>
						<td colspan=2></td>
					</tr>					
				</table>
		      </div>
		</div>
		
		<div id="cuerpo">
		
			<div id="Contenido">
				
				
			</div>
		</div>
	</body>
</html>