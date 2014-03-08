var direccionWeb = "http://192.168.89.128/sfhwebservice/webService/";
$(document).ready(inicializarEventos);
var diasArreglo = new Array();
var idHorarioArreglo = new Array();
function inicializarEventos()
{
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
		$("#span"+campo).html("Debe ingresar una hora valida");
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
		$("#spanHoraInicio"+dia).html("Debe ingresar una hora valida");
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
		$("#spanHoraTermino"+dia).html("Debe ingresar una hora valida");
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
		$("#spanDuracionModulo"+dia).html("Debe ingresar una hora valida");
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
		var idOdontologo = $("#idOdontologo").val();
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
			var data = {"send":"{\"indice\":3,\"idOdontologo\":"+idOdontologo+",\"dia\":\""+dia+"\",\"horaInicio\":\""+horaInicio+"\",\"horaTermino\":\""+horaTermino+"\",\"duracionModulo\":\""+duracionModulo+"\"}"};

			$.post(url,data,function(datos)
			{
				var obj = $.parseJSON(datos);
				if(obj.resultado!=-1)
				{
					alert("se guardo el horario correctamente");
				}
				else
				{
					alert("Hubo un error al guardar el registro");
				}
			});	
		}
		else if(esta=="si")
		{
			var idHorario = idHorarioArreglo[indice];
			var url = direccionWeb + "ws-horario.php";
			var data = {"send":"{\"indice\":5,\"idHorario\":"+idHorario+",\"idOdontologo\":"+idOdontologo+",\"dia\":\""+dia+"\",\"horaInicio\":\""+horaInicio+"\",\"horaTermino\":\""+horaTermino+"\",\"duracionModulo\":\""+duracionModulo+"\"}"};

			$.post(url,data,function(datos)
			{
				var obj = $.parseJSON(datos);
				if(obj.resultado!=-1)
				{
					alert("se guardo el horario correctamente");
				}
				else
				{
					alert("Hubo un error al guardar el registro");
				}
			});	
		}
	}
}
function cargarHorarios()
{
	var idOdontologo = $("#idOdontologo").val();alert(idOdontologo);
	var url = direccionWeb + "ws-horario.php";
	var data = {"send":"{\"indice\":4,\"idOdontologo\":"+idOdontologo+"}"};

	$.post(url,data,function(datos)
	{
		alert(datos);
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
