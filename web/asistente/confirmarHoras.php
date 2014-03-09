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

	$titulo_pagina='Horas Atenci&oacute;n';

	$estilo_css = '<link rel="stylesheet" href="estilos/css/estiloConfirmarHora.css">';

	$script_javascript = '<script type="text/javascript" src="javascript/scriptConfirmarHora.js"></script>';
	
	$menu_activo = '
	<li><a href="perfilAsistente.php">Perfil</a></li>
	<li class="active"><a href="confirmarHoras.php">Horas Atenci&oacute;n</a></li>
	<li><a href="listaPrecios.php">Lista Precios</a></li>
	<li><a href="listaOdontologos.php">Horarios Odont&oacute;logo</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Horas de Atenci&oacute;n</h1>';

	$contenido_pagina = '
	<div class="panel panel-default">
		<div class="panel-heading">
			<div class="row">
				<div class="col-xs-6 col-sm-4"><input type="date" id="dateFecha" /></div>
				<div id="botones" class="col-xs-6 col-sm-4"><input type="search" id="txtBuscar"/></div>
				<div id="botones" class="col-xs-6 col-sm-4"><button id="btnBuscar" class="btn btn-lg btn-primary btn-block">Buscar</button></div>
			</div>

			<div class="row">
				<div class="col-xs-6 col-sm-4"><button id="btnCrearHora" class="btn btn-lg btn-primary btn-block">Reservar Hora</button></div>
				<div class="col-xs-6 col-sm-4"></div>
				<div class="col-xs-6 col-sm-4"><button id="btnConfirmarHora" class="btn btn-lg btn-primary btn-block">Confirmar Hora</button></div>
			</div>
		</div>
		<table class="table" id="tablaConfirmarHora">
			<thead>
				<tr><td class="tdId">id</td><td class="tdNombre">Nombre Paciente</td>
				<td class="tdTelefono">Tel&eacute;fono</td><td class="tdHora">Hora</td>
				<td class="tdDentista">Dentista</td><td class="tdConfirmar">Confirmar</td>
				<td class="tdConfirmar">Modificar</td><td class="tdConfirmar">Eliminar</td></tr>
			</thead>
			<tbody id="cuerpoTabla"></tbody>
		</table>
	</div>';

	$valores_ocultos = '
	<input type="hidden" value="'.$user.'" id="idPaciente">
	<input type="hidden" value="'.$key.'" id="keyPaciente">
	<input type="hidden" value="'.$paciente.'" id="pacientes">';

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