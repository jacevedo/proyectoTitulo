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

	$titulo_pagina ='Perfil';

	$estilo_css = '<link rel="stylesheet" href="../estilos/css/estiloPerfil.css">';

	$script_javascript = '<script type="text/javascript" src="../javascript/asistente/scriptPerfil.js"></script>';
	
	$menu_activo = '
	<li class="active"><a href="perfilAsistente.php">Perfil</a></li>
	<li><a href="confirmarHoras.php">Horas Atenci&oacute;n</a></li>
	<li><a href="listaPrecios.php">Lista Precios</a></li>
	<li><a href="listaOdontologos.php">Horarios Odont&oacute;logo</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Mi Perfil</h1>';

	$contenido_pagina = '
	<div class="row"><div class="col-xs-6 col-lg-4">Nombre:</div><div id="tdNombre" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

    <div class="row"><div class="col-xs-6 col-lg-4">Apellido Paterno:</div><div id="tdApellidoPaterno" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><div class="col-xs-6 col-lg-4">Apellido Materno:</div><div id="tdApellidoMaterno" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><div class="col-xs-6 col-lg-4">Rut:</div><div id="tdRut" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><div class="col-xs-6 col-lg-4">Fecha de Nacimiento:</div><div id="tdFechaNacimiento" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><div class="col-xs-6 col-lg-4">Direcci&oacute;n:</div><div id="tdDireccion" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><div class="col-xs-6 col-lg-4">Regi&oacute;n:</div><div id="tdRegion" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><div class="col-xs-6 col-lg-4">Comuna:</div><div id="tdComuna" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><div class="col-xs-6 col-lg-4">Tel&eacute;fono Fijo:</div><div id="tdFonoFijo" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><div class="col-xs-6 col-lg-4">Celular:</div><div id="tdFonoCelular" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><div class="col-xs-6 col-lg-4">Email:</div><div id="tdEmail" class="col-xs-12 col-sm-6 col-lg-8"></div></div>

  	<div class="row"><button id="btnCrearCuenta" class="btn btn-lg btn-primary btn-block" type="submit">Modificar</button></div>

  	<table id="tablaContenido">
		<tr style="display: none;"><td class="tdIndicador">Numero:</td><td id="tdNumero"></td></tr>
		
		<tr style="display: none;"><td class="tdIndicador">Perfil</td><td id="tdPerfil"></td></tr>
		
		<tr style="display: none;"><td class="tdIndicador">idRegion</td><td id="tdidRegion"></td></tr>

		<tr style="display: none;"><td class="tdIndicador">idComuna</td><td id="tdidComuna"></td></tr>
		
		<tr style="display: none;"><td class="tdIndicador">FechaIngreso</td><td id="tdFechaIngreso"></td></tr>

		<tr><td colspan=2></td></tr>
	</table>';

	$valores_ocultos = '
	<input type="hidden" value="'.$user.'" id="idPaciente">
	<input type="hidden" value="'.$key.'" id="keyPaciente">
	<input type="hidden" value="'.$paciente.'" id="pacientes">
	<input type="hidden" value="'.$direccionWeb.'" id="direccionWeb">';

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