<?php
	require_once 'libsigma/Sigma.php';
	$plantilla = new HTML_Template_Sigma('plantilla');
	$plantilla->loadTemplateFile('login.tlp.html');

	session_start();

	$direccionWeb = "http://192.168.89.128/sfhwebservice/webService/";

	$titulo_pagina='Login';

	$contenido_pagina='
	<div class="form-signin">
        <h2 id="textoBienvenida" class="form-signin-heading">SFH</h2>
        <input type="text" id="txtUsuario" class="form-control" placeholder="Usuario (rut sin punto ni gui&oacute;n)" required autofocus/>
        <span id="validacionUsuario"></span>
        <input type="password" id="txtPass" class="form-control" placeholder="Contrase&ntilde;a" required/>
        <span id="validacionContrasena"></span>
        <button id="btnIngresar" class="btn btn-lg btn-primary btn-block" type="submit">Ingresar</button>
        <a href="../paciente/pagina/crearCuenta.php" id="crearCuenta">Crear una Cuenta</a>
    </div>';

	$valores_ocultos = '<input type="hidden" value="'.$direccionWeb.'" id="direccionWeb">';

	$plantilla->setVariable('titulo',$titulo_pagina);
	$plantilla->setVariable('contenido_pagina',$contenido_pagina);
	$plantilla->setVariable('valores_ocultos',$valores_ocultos);
	$plantilla->parse();
	$plantilla->show();
?>