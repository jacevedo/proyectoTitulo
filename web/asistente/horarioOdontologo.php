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
	$odontologo = $_POST["idOdontologo"];

	$direccionWeb = "http://192.168.89.128/sfhwebservice/webService/";

	$titulo_pagina ='Horarios Odont&oacute;logo';

	$estilo_css = '<link rel="stylesheet" href="../estilos/css/estiloReservarHora.css">';

	$script_javascript = '<script type="text/javascript" src="../javascript/asistente/scriptHorarioOdontologos.js"></script>';
	
	$menu_activo = '
	<li><a href="perfilAsistente.php">Perfil</a></li>
	<li><a href="confirmarHoras.php">Horas Atenci&oacute;n</a></li>
	<li><a href="listaPrecios.php">Lista Precios</a></li>
	<li class="active"><a href="listaOdontologos.php">Horarios Odont&oacute;logo</a></li>';

	$contenido_usuario='<p id="nomUsuario"> '.$nombre.' '.$apellido.'</p>';

	$titulo_seccion = '<h1>Lista de Odont&oacute;logos</h1>';

	$contenido_pagina = '
	<input type="hidden" id="idUsuario" value=""/>
	<table id="tablaReservarHoraAsistente" class="tab">
		<tr><td>Dia</td><td>Hora Inicio</td><td>Hora T&eacute;rmino</td><td>Duraci&oacute;n M&oacute;dulo</td><td></td></tr>

		<tr><td>Lunes</td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciolunes" type="text" id="txtHoraIniciolunes"/><br><span id="spanHoraIniciolunes"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminolunes" type="text" id="txtHoraTerminolunes"/><br><span id="spanHoraTerminolunes"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulolunes" type="text" id="txtDuracionModulolunes"/><br><span id="spanDuracionModulolunes"></span></td>
		<td><Button dia="lunes" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td></tr>

		<tr><td>Martes</td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciomartes" type="text" id="txtHoraIniciomartes"/><br><span id="spanHoraIniciomartes"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminomartes" type="text" id="txtHoraTerminomartes"/><br><span id="spanHoraTerminomartes"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulomartes" type="text" id="txtDuracionModulomartes"/><br><span id="spanDuracionModulomartes"></span></td>
		<td><Button dia="martes" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td></tr>

		<tr><td>Mi&eacute;rcoles</td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciomiercoles" type="text" id="txtHoraIniciomiercoles"/><br><span id="spanHoraIniciomiercoles"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminomiercoles" type="text" id="txtHoraTerminomiercoles"/><br><span id="spanHoraTerminomiercoles"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulomiercoles" type="text" id="txtDuracionModulomiercoles"/><br><span id="spanDuracionModulomiercoles"></span></td>
		<td><Button dia="miercoles" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td></tr>

		<tr><td>Jueves</td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciojueves" type="text" id="txtHoraIniciojueves"/><br><span id="spanHoraIniciojueves"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminojueves" type="text" id="txtHoraTerminojueves"/><br><span id="spanHoraTerminojueves"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulojueves" type="text" id="txtDuracionModulojueves"/><br><span id="spanDuracionModulojueves"></span></td>
		<td><Button dia="jueves" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>							</tr>

		<tr><td>Viernes</td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraInicioviernes" type="text" id="txtHoraInicioviernes"/><br><span id="spanHoraInicioviernes"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminoviernes" type="text" id="txtHoraTerminoviernes"/><br><span id="spanHoraTerminoviernes"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModuloviernes" type="text" id="txtDuracionModuloviernes"/><br><span id="spanDuracionModuloviernes"></span></td>
		<td><Button dia="viernes" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>										</tr>

		<tr><td>S&aacute;bado</td>		
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciosabado" type="text" id="txtHoraIniciosabado"/><br><span id="spanHoraIniciosabado"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminosabado" type="text" id="txtHoraTerminosabado"/><br><span id="spanHoraTerminosabado"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulosabado" type="text" id="txtDuracionModulosabado"/><br><span id="spanDuracionModulosabado"></span></td>
		<td><Button dia="sabado" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td>						</tr>

		<tr><td>Domingo</td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraIniciodomingo" type="text" id="txtHoraIniciodomingo"/><br><span id="spanHoraIniciodomingo"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="HoraTerminodomingo" type="text" id="txtHoraTerminodomingo"/><br><span id="spanHoraTerminodomingo"></span></td>
		<td><input placeholder="00:00:00" class="inputHora" dia="DuracionModulodomingo" type="text" id="txtDuracionModulodomingo"/><br><span id="spanDuracionModulodomingo"></span></td>
		<td><Button dia="domingo" class="btnGuardar btn btn-lg btn-primary btn-block">Guardar</Button></td></tr>
	</table>';

	$valores_ocultos = '
	<input type="hidden" value="'.$user.'" id="idPaciente">
	<input type="hidden" value="'.$key.'" id="keyPaciente">
	<input type="hidden" value="'.$paciente.'" id="pacientes">
	<input type="hidden" value="'.$odontologo.'" id="odontologos">
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
