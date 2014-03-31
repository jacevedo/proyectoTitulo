<<<<<<< HEAD:web/javascript/asistente/scriptHorarioOdontologos.js
var direccionWeb = "";
=======
var direccionWeb = "http://sfh.crossline.cl/webServiceencriptado/";
>>>>>>> FETCH_HEAD:web/asistente/javascript/scriptHorarioOdontologos.js
$(document).ready(inicializarEventos);
var diasArreglo = new Array();
var idHorarioArreglo = new Array();
function inicializarEventos()
{
	direccionWeb = $("#direccionWeb").val();
	cargarHorarios();
	$(".btnGuardar").click(guardarDia);
	$("#txtHoraIniciolunes").blur(validarTiempo);
	$("#txtHoraTerminolunes").blur(validarTiempo);
	$("#txtDuracionModulolunes").blur(validarTiempo);
	$("#txtHoraIniciomartes").blur(validarTiempo);
	$("#txtHoraTerminomartes").blur(validarTiempo);
	$("#txtDuracionModulomartes").blur(validarTiempo);
	$("#txtHoraIniciomiercoles").blur(validarTiempo);
	$("#txtHoraTerminomiercoles").blur(validarTiempo);
	$("#txtDuracionModulomiercoles").blur(validarTiempo);
	$("#txtHoraIniciojueves").blur(validarTiempo);
	$("#txtHoraTerminojueves").blur(validarTiempo);
	$("#txtDuracionModulojueves").blur(validarTiempo);
	$("#txtHoraInicioviernes").blur(validarTiempo);
	$("#txtHoraTerminoviernes").blur(validarTiempo);
	$("#txtDuracionModuloviernes").blur(validarTiempo);
	$("#txtHoraIniciosabado").blur(validarTiempo);
	$("#txtHoraTerminosabado").blur(validarTiempo);
	$("#txtDuracionModulosabado").blur(validarTiempo);
	$("#txtHoraIniciodomingo").blur(validarTiempo);
	$("#txtHoraTerminodomingo").blur(validarTiempo);
	$("#txtDuracionModulodomingo").blur(validarTiempo);
}
function validarTiempo()
{
	var texto = $(this).val();
	var campo = $(this).attr("dia");
	var pattern = /\d{2}\:\d{2}\:\d{2}/
	if(!texto.match(pattern))
	{
		$("#span"+campo).html("Debe ingresar una hora v&aacute;lida");
		return false;
	}
	else
	{
		$("#span"+campo).html("");
		return true;
	}
}
function validarHoraInicio(dia)
{
	var texto = $("#txtHoraInicio"+dia).val();
	var pattern = /\d{2}\:\d{2}\:\d{2}/
	if(!texto.match(pattern))
	{
		$("#spanHoraInicio"+dia).html("Debe ingresar una hora v&aacute;lida");
		return false;
	}
	else
	{
		$("#spanHoraInicio"+dia).html("");
		return true;
	}
}
function validarHoraTermino(dia)
{
	var texto = $("#txtHoraTermino"+dia).val();
	var pattern = /\d{2}\:\d{2}\:\d{2}/
	if(!texto.match(pattern))
	{
		$("#spanHoraTermino"+dia).html("Debe ingresar una hora v&aacute;lida");
		return false;
	}
	else
	{
		$("#spanHoraTermino"+dia).html("");
		return true;
	}
}
function validarDuracionModulo(dia)
{
	var texto = $("#txtDuracionModulo"+dia).val();
	var pattern = /\d{2}\:\d{2}\:\d{2}/
	if(!texto.match(pattern))
	{
		$("#spanDuracionModulo"+dia).html("Debe ingresar una hora v&aacute;lida");
		return false;
	}
	else
	{
		$("#spanDuracionModulo"+dia).html("");
		return true;
	}
}
function guardarDia()
{
	var dia = $(this).attr("dia");
	if(validarHoraInicio(dia)&validarHoraTermino(dia)&validarDuracionModulo(dia))
	{
		var idOdontologo = $("#odontologos").val();
		var horaInicio = $("#txtHoraInicio"+dia).val();
		var horaTermino = $("#txtHoraTermino"+dia).val();
		var duracionModulo = $("#txtDuracionModulo"+dia).val();
		var esta = "no";
		var indice = 0;
		for(var i=0;i<diasArreglo.length;i++)
		{
			if(diasArreglo[i]==dia)
			{
				esta="si";
				indice=i;
			}
		}

		if(esta=="no")
		{
			var url = direccionWeb + "ws-horario.php";
			var key = $("#keyPaciente").val();
			var stringJson = "{\"indice\":3,\"idOdontologo\":"+idOdontologo+",\"dia\":\""+dia+"\",\"horaInicio\":\""+horaInicio+"\",\"horaTermino\":\""+horaTermino+"\",\"duracionModulo\":\""+duracionModulo+"\",\"key\":\""+key+"\"}";
			var data = {"send":encriptar(stringJson)};
			$.post(url,data,function(jsonEncriptado)
			{
				var datos = desencriptar(jsonEncriptado);
				var obj = $.parseJSON(datos);
				if(obj.resultado!=-1)
				{
					alert("Horario ingresado correctamente.");
				}
				else
				{
					alert("Se produjo un error, vuelva a intentarlo.");
				}
			});	
		}
		else if(esta=="si")
		{
			var idHorario = idHorarioArreglo[indice];
			var url = direccionWeb + "ws-horario.php";
			var key = $("#keyPaciente").val();
			var stringJson = "{\"indice\":5,\"idHorario\":"+idHorario+",\"idOdontologo\":"+idOdontologo+",\"dia\":\""+dia+"\",\"horaInicio\":\""+horaInicio+"\",\"horaTermino\":\""+horaTermino+"\",\"duracionModulo\":\""+duracionModulo+"\",\"key\":\""+key+"\"}";
			var data = {"send":encriptar(stringJson)};
			$.post(url,data,function(jsonEncriptado)
			{
				var datos = desencriptar(jsonEncriptado);
				var obj = $.parseJSON(datos);
				if(obj.resultado!=-1)
				{
					alert("Horario ingresado correctamente.");
				}
				else
				{
					alert("Se produjo un error, vuelva a intentarlo.");
				}
			});	
		}
	}
}
function cargarHorarios()
{
	var idOdontologo = $("#odontologos").val();
	var url = direccionWeb + "ws-horario.php";
	var key = $("#keyPaciente").val();
	var stringJson = "{\"indice\":4,\"idOdontologo\":"+idOdontologo+",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};
	$.post(url,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
	 	var obj = $.parseJSON(datos);
		$.each(obj.listaHorarios,function()
		{
			var dia = this.dia;
			$("#txtHoraInicio"+dia).val(this.horaInicio);
			$("#txtHoraTermino"+dia).val(this.horaTermino);
			$("#txtDuracionModulo"+dia).val(this.duracionModulo);
			diasArreglo.push(dia);
			idHorarioArreglo.push(this.idHorario);
		});
	});
}
