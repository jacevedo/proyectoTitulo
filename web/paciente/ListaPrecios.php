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

	$titulo_pagina ='Lista Precios';

	$estilo_css = '<link rel="stylesheet" href="../estilos/css/estiloListaPrecios.css">';

	$script_javascript = '<script type="text/javascript" src="../javascript/paciente/scriptListaPreciosPaciente.js"></script>';
	
	$menu_activo = '
	<li><a href="perfil.php">Perfil</a></li>
	<li><a href="verHoras.php">Horas Atenci&oacute;n</a></li>
	<li class="active"><a href="listaPrecios.php">Lista Precios</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Lista de Precios</h1>';

	$contenido_pagina = '
	<div class="panel-heading">
		<div class="row">
			<div class="col-xs-12 col-sm-6 col-lg-8"><input type="search" id="txtBuscaTratamiento"/></div>
			<div class="col-xs-6 col-sm-4"><button id="btnBuscar" class="btn btn-lg btn-primary btn-block">Buscar</button></div>
		</div>
	</div>
	<table id="tablaListaPrecios" class="table">
		<thead><tr><td>Nro</td><td>Nombre Tratamiento</td><td>Precio</td></tr></thead>
		<tbody id="cuerpoTabla"></tbody>
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
