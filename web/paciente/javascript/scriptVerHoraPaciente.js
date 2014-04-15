var direccionWeb = "";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	direccionWeb = $("#direccionWeb").val();
	cargarHorasReservadas();
	$("#btnReservarHoraPaciente").click(reservarHora);
}

function cargarHorasReservadas()
{
	var ingresar = direccionWeb+"ws-cita.php";
	var idPaciente = $("#pacientes").val();
	var key = $("#keyPaciente").val();
	var json = "{\"indice\":2,\"idPaciente\":"+idPaciente+",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(json)};

	$.post(ingresar, data, function(jsonEncriptadoBase)
	{
		var datos = desencriptar(jsonEncriptadoBase);
		var obj = $.parseJSON(datos);
		var cantCitas = obj.resultado;
		var tr;
		$.each(obj.resultado,function(i,value)
		{
			var fecha = value.cita.fecha;
			var odontologo = value.cita.appPaternoOdontologo+" "+ value.cita.nomOdontologo;
			var horaInicio = value.cita.horaInicio.split(" ");
			tr= tr + "<tr><td>"+fecha+"</td><td>"+odontologo+"</td><td>"+horaInicio[1]+"</td></tr>"
		});
		$("#historialHorasTomadas").html(tr);
	});
}

function reservarHora()
{
	location.href="reservarHoraPaciente.php";
}