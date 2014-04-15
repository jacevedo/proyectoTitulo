<?php
	require_once '../libsigma/Sigma.php';
	$plantilla = new HTML_Template_Sigma('../plantilla');
	$plantilla->loadTemplateFile('principal.tlp.html');

	session_start();
	$user = $_SESSION['user'];
	$key = $_SESSION['key'];
	$paciente = $_SESSION['paciente'];
	$nombre = $_SESSION['nombre'];
	$apellido = $_SESSION['appPaterno'];

	$direccionWeb = "http://sfh.crossline.cl/webServiceencriptado/";

	$titulo_pagina ='Crear Cuenta';

	$estilo_css = '<link rel="stylesheet" href="../estilos/css/estiloReservarHora.css">';
	//'<link rel="stylesheet" href="../estilos/css/estiloCrearCuenta.css">';

	$script_javascript = '<script type="text/javascript" src="../asistente/javascript/scriptCrearCuenta.js"></script>';
	
	$menu_activo = '<li><a href="perfilAsistente.php">Perfil</a></li>
	<li class="active"><a href="confirmarHoras.php">Horas Atenci&oacute;n</a></li>
	<li><a href="listaPrecios.php">Lista Precios</a></li>
	<li><a href="listaOdontologos.php">Horarios Odont&oacute;logo</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Crear Nueva Cuenta</h1>';

	$contenido_pagina = '
	<table class="tab">
		<tr><td>Nombre</td><td><input class="textosLargos" type="text" id="txtNombre" placeholder="Esteban"/><span id="errorNombre" class="error" ></span></td></tr>
		
		<tr><td>Apellido Paterno</td><td><input class="textosLargos" type="text" id="txtAppPaterno" placeholder="Apablaza"/><span id="errorAppPaterno" class="error"></span></td></tr>
		
		<tr><td>Apellido Materno</td><td><input  class="textosLargos"type="text" id="txtAppMaterno" placeholder="Moreno"/><span id="errorAppMaterno" class="error"></span></td></tr>
		
		<tr><td>Rut</td><td><input  type="text" id="txtRut" placeholder="17323123" value=""/> - <input type="text" id="txtDv" placeholder="5"/><span id="errorRut" class="error"></span></td></tr>
		
		<tr><td>Fecha de Nacimiento</td><td><input class="textosLargos" type="date" id="txtFechaNacimiento" placeholder="04-06-1993"/></td></tr>
		
		<tr><td>Direcci&oacute;n</td><td><input class="textosLargos" type="text" id="txtDireccion" placeholder="San Benito 43"/></td></tr>

		<tr><td>Regi&oacute;n</td><td><select class="textosLargos" id="region"></select></td></tr>

		<tr><td>Comuna</td><td><select class="textosLargos" id="comuna"></select></td></tr>
		
		<tr><td>Tel&eacute;fono Fijo</td><td><input class="textosLargos" type="text" id="txtFono" placeholder="027780182"/><span id="errorFonoFijo" class="error"></span></td></tr>

		<tr><td>Celular</td><td><input  class="textosLargos"type="text" id="txtCelular" placeholder="555555555"/> <span id="errorFonoCell" class="error"></span></td></tr>

		<tr><td>Email</td><td><input  class="textosLargos"type="text" id="txtMail" placeholder="lala@lala.net"/><span id="errorMail" class="error"></span></td></tr>

		<tr><td>Contrase&ntilde;a</td><td><input class="textosLargos" type="password" id="txtContrasena" placeholder="asdasdasd"/><span id="errorPass" class="error"></span></td></tr>
	</table>
	<button id="btnCrearCuenta" class="btn btn-lg btn-primary btn-block">Crear Cuenta</button>';

	$valores_ocultos = '<input type="hidden" value="'.$direccionWeb.'" id="direccionWeb">';

	$contenido_cuerpo = '';

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
