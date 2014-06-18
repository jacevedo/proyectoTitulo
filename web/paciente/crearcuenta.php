<?php
	require_once '../libsigma/Sigma.php';
	$plantilla = new HTML_Template_Sigma('../plantilla');
	$plantilla->loadTemplateFile('principal.tlp.html');

	$direccionWeb = "http://sfh.crossline.cl/webServiceencriptado/";

	$titulo_pagina ='Crear Cuenta';

	$estilo_css = '<link rel="stylesheet" href="../estilos/css/estiloCrearCuenta.css">';

	$script_javascript = '<script type="text/javascript" src="../paciente/javascript/scriptCrearCuenta.js"></script>';
	
	$menu_activo = '';

	$contenido_usuario='';

	$titulo_seccion = '<h1>Crear Nueva Cuenta</h1>';

	$contenido_pagina = '
	<table class="table">
		<tr><td>Nombre</td><td><input class="textosLargos" type="text" id="txtNombre" placeholder="Esteban"/><span id="errorNombre" class="error" ></span></td></tr>
		
		<tr><td>Apellido Paterno</td><td><input class="textosLargos" type="text" id="txtAppPaterno" placeholder="Apablaza"/><span id="errorAppPaterno" class="error"></span></td></tr>
		
		<tr><td>Apellido Materno</td><td><input  class="textosLargos"type="text" id="txtAppMaterno" placeholder="Moreno"/><span id="errorAppMaterno" class="error"></span></td></tr>
		
		<tr><td>Rut</td><td><input  type="text" id="txtRut" placeholder="17323123" value=""/> - <input type="text" id="txtDv" placeholder="5"/><span id="errorRut" class="error"></span></td></tr>
		
		<tr><td>Fecha de Nacimiento</td><td><input class="textosLargos" type="date" id="txtFechaNacimiento" placeholder="04-06-1993"/></td></tr>
		
		<tr><td>Direcci&oacute;n</td><td><input class="textosLargos" type="text" id="txtDireccion" placeholder="San Benito 43"/></td></tr>

		<tr><td>Regi&oacute;n</td><td><select class="textosLargos" id="region"></select></td></tr>

		<tr><td>Comuna</td><td><select class="textosLargos" id="comuna"></select></td></tr>
		
		<tr><td>Tel&eacute;fono Fijo</td><td><input class="textosLargos" type="text" id="txtFono" placeholder="027780182"/><span id="errorFonoFijo" class="error"></span></td></tr>

		<tr><td>Celular</td><td><input  class="textosLargos"type="text" id="txtCelular" placeholder="+56975478834"/> <span id="errorFonoCell" class="error"></span></td></tr>

		<tr><td>Email</td><td><input  class="textosLargos"type="text" id="txtMail" placeholder="example@example.com"/><span id="errorMail" class="error"></span></td></tr>

		<tr><td>Contrase&ntilde;a</td><td><input class="textosLargos" type="password" id="txtContrasena" placeholder="password"/><span id="errorPass" class="error"></span></td></tr>

		<tr><td colspan=2><button id="btnCrearCuenta">Crear Cuenta</button></td></tr>
	</table>';

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
