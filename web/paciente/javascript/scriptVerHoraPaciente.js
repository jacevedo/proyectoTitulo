var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/";
$(document).ready(inicializarEventos);
var horarios = '';

function inicializarEventos()
{
	cargarHorasReservadas();
	$("#btnReservarHoraPaciente").click(reservarHora);
}

function reservarHora()
{

}

function cargarHorasReservadas()
{
	var ingresar = direccionWeb+"ws-horario.php";
	var data = {"send":"{\"indice\":1,\"fecha\":\""+fecha+"\"}"};

	$.post(ingresar, data, function(datos)
	{
		var obj = $.parseJSON(datos);
		horarios = obj.listaHorarios;

		var select = '';
		select = select + "<option value='0'>Seleccione un Dentista</option>";

		$.each(horarios,function()
		{
			select = select + "<option value="+this.idOdontologo+">"+this.nomOdontologo+"</option>";
		});
		$("#selectDentista").html(select);
	});
}