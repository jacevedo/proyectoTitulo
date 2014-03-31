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

	$direccionWeb = "http://192.168.89.128/sfhwebservice/webService/";

	$titulo_pagina ='Reservar Hora';

	$estilo_css = '<link rel="stylesheet" href="../estilos/css/estiloHoras.css">';

	$script_javascript = '<script type="text/javascript" src="../javascript/paciente/scriptReservarHoraPaciente.js"></script>';
	
	$menu_activo = '
	<li><a href="perfil.php">Perfil</a></li>
	<li class="active"><a href="verHoras.php">Horas Atenci&oacute;n</a></li>
	<li><a href="listaPrecios.php">Lista Precios</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Reservar Hora Atenci&oacute;n</h1>';

	$contenido_pagina = '
	<table id="tablaTomarHora" class="table">
		<tr><td class="encabezado">Fecha</td><td><input type="date" id="txtFecha"/></td></tr>
		<tr><td class="encabezado">Dentista</td><td><select id="selectDentista"></select></td></tr>
		<tr><td class="encabezado">Hora</td><td><select id="selectHora"></select></td></tr>
		<tr><td colspan=2><button id="btnReservarHoraPaciente" class="btn btn-lg btn-primary btn-block">Reservar Hora</button></td></tr>
	</table>';

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
