<?php
session_start();
?>
<!DOCTYPE HTML>
<html>
	<head>
		<link rel="stylesheet" href="estilos/css/bootstrap.css">
		<link rel="stylesheet" href="estilos/css/estiloLogin.css">
		<script type="text/javascript" src="javascript/JQuery.js"></script>
		<script type="text/javascript" src="javascript/scriptLogin.js"></script>
		<title>SFH</title>
	</head>
	<body>
		<div id="cuerpo">
			<div id="login" class="container">
				<div class="form-signin">
					<h2 id="textoBienvenida" class="form-signin-heading">SFH</h2>
					<input type="text" id="txtUsuario" class="form-control" placeholder="Usuario (rut sin punto ni guion)" required autofocus/>
					<input type="password" id="txtPass" class="form-control" placeholder="Contrase&ntilde;a" required/>
					<button id="btnIngresar" class="btn btn-lg btn-primary btn-block" type="submit">Ingresar</button>
					<a href="crearcuenta.php" id="crearCuenta">Crear una Cuenta</a>
				</div>
			</div>
		</div>
		
	</body>
</html>