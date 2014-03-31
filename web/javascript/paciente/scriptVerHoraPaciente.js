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
	var data = {"send":"{\"indice\":2,\"idPaciente\":\""+idPaciente+"\"}"};

	$.post(ingresar, data, function(datos)
	{
		var obj = $.parseJSON(datos);
		var cantCitas = obj.resultado;
		var tr;
		$.each(obj.resultado,function(i,value)
		{
			var fecha = value.fecha.split(" ");
			var odontologo = value.appPaternoOdontologo+" "+ value.nomOdontologo;
			var horaInicio = value.horaInicio.split(" ");
			tr= tr + "<tr><td>"+fecha[0]+"</td><td>"+odontologo+"</td><td>"+horaInicio[1]+"</td></tr>"
		});
		$("#historialHorasTomadas").html(tr);
	});
}

function reservarHora()
{
	location.href="reservarHoraPaciente.php";
}