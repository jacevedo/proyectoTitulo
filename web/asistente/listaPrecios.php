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

	$titulo_pagina ='Lista de Precios';

	$estilo_css = '<link rel="stylesheet" href="../estilos/css/estiloListaPrecios.css">';

	$script_javascript = '<script type="text/javascript" src="../asistente/javascript/scriptListaPrecios.js"></script>';
	
	$menu_activo = '
	<li><a href="perfilAsistente.php">Perfil</a></li>
	<li><a href="confirmarHoras.php">Horas Atenci&oacute;n</a></li>
	<li class="active"><a href="listaPrecios.php">Lista Precios</a></li>
	<li><a href="listaOdontologos.php">Horarios Odont&oacute;logo</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Lista de Precios</h1>';

	$contenido_pagina = '
	<div class="panel panel-default">
		<div class="panel-heading">
			<div class="row">
				<div class="col-xs-6 col-sm-4"><input type="search" id="txtBuscaTratamiento"/></div>
				<div id="botones" class="col-xs-6 col-sm-4"><button id="btnBuscar" class="btn btn-lg btn-primary btn-block" type="submit">Buscar</button></div>
				<div id="botones" class="col-xs-6 col-sm-4"><button id="btnAgregarTratamiento" class="btn btn-lg btn-primary btn-block" type="submit">Agregar</button></div>
			</div>
			<div class="row agregar" id="filaAgregar">
				<div class="col-xs-6 col-sm-4"><input id="txtNomProcedimiento" placeholder="Nombre Procedimiento" type="text"/><span id="spanErrorNomProcedimiento" class="error"></span></div>
				<div class="col-xs-6 col-sm-4"><input id="txtCostoProcedimiento" placeholder="Costo Neto Proced." type="text"/><span id="spanErrorCostoProcedimiento" class="error"></span></div>
				<div class="col-xs-6 col-sm-4"><Button id="crearNuevoPrecio" class="btn btn-lg btn-primary btn-block">Guardar</Button></div>
			</div>
		</div>
		<div>
		<table class="table" id="tablaListaPrecios">
			<thead><tr><td>Nro</td><td>Nombre Tratamiento</td><td>Precio</td><td>Editar</td><td>Eliminar</td></tr></thead>
			<tbody id="cuerpoTabla"></tbody>
		</table>
		</div>
	</div>';

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
