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

	$titulo_pagina='Reservar Hora';

	$estilo_css = '<link rel="stylesheet" href="../estilos/css/estiloReservarHora.css">';

	$script_javascript = '<script type="text/javascript" src="../asistente/javascript/scriptReservarHora.js"></script>';
	
	$menu_activo = '
	<li><a href="perfilAsistente.php">Perfil</a></li>
	<li class="active"><a href="confirmarHoras.php">Horas Atenci&oacute;n</a></li>
	<li><a href="listaPrecios.php">Lista Precios</a></li>
	<li><a href="listaOdontologos.php">Horarios Odont&oacute;logo</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Reservar Hora de Atenci&oacute;n</h1>';

	$contenido_pagina = '
	<input type="hidden" id="idUsuario" value=""/>
	<table id="tablaReservarHoraAsistente" class="tab">
		<tr><td>Rut</td><td><input type="text" id="txtRut"/> - <input type="text" id="txtDv"/><span id="spanErrorRut" class="error"></span> <a href="../asistente/crearCuenta.php" id="crearCuenta">Crear Nueva Cuenta</a></td></tr>
		
		<tr><td>Nombre</td><td><input class="inputHora" type="text" id="txtNombre"/><span id="spanErrorNombre" class="error"></span></td></tr>

		<tr><td>Apellido Paterno</td><td><input class="inputHora" type="text" id="txtAppPaterno"/><span id="spanErrorAppPaterno" class="error"></span></td></tr>

		<tr><td>Apellido Materno</td><td><input class="inputHora" type="text" id="txtAppMaterno"/><span id="spanErrorAppMaterno" class="error"></span></td></tr>

		<tr><td>Fecha de Nacimiento</td><td><input class="inputHora" type="date" id="txtFechaNacimiento"/></td></tr>

		<tr><td>Fecha a Reservar</td><td><input class="inputHora" type="date" id="txtFecha"/></td></tr>

		<tr><td>Dentista</td><td><select id="selectDentista"><option value="--">--</option></select><span id="spanErrorDentista" class="error"></span></td></tr>

		<tr><td>Hora</td><td><select id="selectHora"><option value="--">--</option></select><span id="spanErrorHora" class="error"></span></td></tr>
	</table>
	<button id="btnReservarHora" class="btn btn-lg btn-primary btn-block">Reservar Hora</button>';

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
