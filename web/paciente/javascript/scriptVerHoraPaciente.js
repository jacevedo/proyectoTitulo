var direccionWeb = "http://172.16.28.138/sfhwebservice/webService/";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	cargarHorasReservadas();
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

		/*var select = '';
		select = select + "<option value='0'>Seleccione un Dentista</option>";

		$.each(horarios,function()
		{
			select = select + "<option value="+this.idOdontologo+">"+this.nomOdontologo+"</option>";
		});
		$("#selectDentista").html(select);*/
	});
}