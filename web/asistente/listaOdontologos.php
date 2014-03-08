<?php
	require_once 'libsigma/Sigma.php';
	$plantilla = new HTML_Template_Sigma('plantilla');
	$plantilla->loadTemplateFile('principal.tlp.html');

	session_start();
	$user = $_SESSION['user'];
	$key = $_SESSION['key'];
	$paciente = $_SESSION['paciente'];
	$nombre = $_SESSION['nombre'];
	$apellido = $_SESSION['appPaterno'];

	$direccionWeb = "http://192.168.89.128/sfhwebservice/webService/";

	$titulo_pagina ='Odontologos';

	$estilo_css = '<link rel="stylesheet" href="estilos/css/estiloListaPrecios.css">';

	$script_javascript = '<script type="text/javascript" src="javascript/scriptListaOdontologos.js"></script>';
	
	$menu_activo = '
	<li><a href="perfilAsistente.php">Perfil</a></li>
	<li><a href="confirmarHoras.php">Hora Atencion</a></li>
	<li><a href="listaPrecios.php">Lista Precios</a></li>
	<li class="active"><a href="listaOdontologos.php">Horarios Odontologo</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Lista de Odontólogos</h1>';

	$contenido_pagina = '
	';

	$valores_ocultos = '
	<input type="hidden" value='.$user.' id="idPaciente">
	<input type="hidden" value='.$key.' id="keyPaciente">
	<input type="hidden" value='.$paciente.' id="pacientes">';

	$contenido_cuerpo = '<div id="Contenido"></div>';

	$plantilla->setVariable('titulo',$titulo_pagina);
	$plantilla->setVariable('estilo_css',$estilo_css);
	$plantilla->setVariable('script_javascript',$script_javascript);
	$plantilla->setVariable('menu_activo',$menu_activo);
	$plantilla->setVariable('contenido_usuario',$contenido_usuario);
	$plantilla->setVariable('titulo_seccion',$titulo_seccion);
	$plantilla->setVariable('contenido_pagina',$contenido_pagina);
	$plantilla->setVariable('valores_ocultos',$valores_ocultos);
	$plantilla->setVariable('contenido_cuerpo',$contenido_cuerpo);

	$plantilla->parse();
	$plantilla->show();
?>
<!DOCTYPE HTML>
<html>

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
		            <li><a href="confirmarhora.php">Hora Atencion</a></li>
		            <li><a href="listaPrecios.php">Lista Precios</a></li>
		           	<li class="active"><a href="listaOdontologos.php">Horarios Odontologo</a></li>
		          </ul>
		          <ul class="nav navbar-nav navbar-right">
		            <li class="active"><a href="#"><p id="nomUsuario"> <?php echo($_SESSION['nombre']);?> <?php echo($_SESSION['appPaterno']);?> </p></a></li>
		             <li><a href="logout.php">Logout</a></li>
		          </ul>
		        </div><!--/.nav-collapse -->
		    </div>
		    <div class="jumbotron">
		    	<h1>
		      		Lista de Odontologos
		      	</h1>
		      	<div class="panel panel-default">
					 <!--<div class="panel-heading">
					 	<div class="row">
						 	<div class="col-xs-6 col-sm-4">
								<input type="search" id="txtBuscaTratamiento"/>
							</div>
							 <div id="botones" class="col-xs-6 col-sm-4">
							 	
							</div>
							<div id="botones" class="col-xs-6 col-sm-4">
								<button id="btnBuscar" class="btn btn-lg btn-primary btn-block" type="submit">Buscar</button>
							</div>
						</div>
					 </div>-->
					  <!-- Table -->
					  <table class="table" id="tablaListaOdontologos">
					  	<thead>
					  		<tr>
								<td>Nombre Odontologo</td>
								<td>Apellido Paterno</td>
								<td>Apellido Materno</td>
								<td>Rut</td>
								<td>Horario</td>
							</tr>
							
					  	</thead>
					  	<tbody id="cuerpoTabla">
						
						</tbody>
					  </table>
					</div>
		    </div>
		</div>
		
	<!--<div id="cuerpo">
			<div id="logo">
				<img src="imagenes/logo.png" id="imagenCostado">
			</div>
			<div id="Contenido">
				
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
		</div>-->
	</body>
</html>