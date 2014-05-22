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

	$titulo_pagina ='Odont&oacute;logos';

	$estilo_css = '<link rel="stylesheet" href="../estilos/css/estiloListaPrecios.css">';

	$script_javascript = '<script type="text/javascript" src="../asistente/javascript/scriptListaOdontologos.js"></script>';
	
	$menu_activo = '
	<li><a href="perfilAsistente.php">Perfil</a></li>
	<li><a href="confirmarHoras.php">Horas Atenci&oacute;n</a></li>
	<li><a href="listaPrecios.php">Lista Precios</a></li>
	<li class="active"><a href="listaOdontologos.php">Horarios Odont&oacute;logo</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Lista de Odont&oacute;logos</h1>';

	$contenido_pagina = '
	<div class="panel panel-default"><table class="table" id="tablaListaOdontologos">
	<thead><tr><td>Nombre Odont&oacute;logo</td><td>Apellido Paterno</td>
	<td>Apellido Materno</td><td>Rut</td><td>Horario</td></tr></thead>
	<tbody id="cuerpoTabla"></tbody></table></div>
	';

	$valores_ocultos = '
	<input type="hidden" value="'.$user.'" id="idPaciente">
	<input type="hidden" value="'.$key.'" id="keyPaciente">
	<input type="hidden" value="'.$paciente.'" id="pacientes">
	<input type="hidden" value="'.$direccionWeb.'" id="direccionWeb">';

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