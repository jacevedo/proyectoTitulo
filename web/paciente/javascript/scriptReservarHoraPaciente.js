var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/";
$(document).ready(inicializarEventos);
var horarios = '';

function inicializarEventos()
{
	$("#txtFecha").change(cargarDatosFecha);
	$("#btnReservarHoraPaciente").click(guardarHora);
}

function cargarDatosFecha()
{
	var fecha = $("#txtFecha").val() + " 13:13:00";
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
	$("#selectDentista").change(cargarHoras);
}

function cargarHoras()
{
	var idDent = document.getElementById("selectDentista").value;
	var select = '';
	select = select + "<option value='0'>Seleccione una Hora</option>";

	$.each(horarios,function()
	{
		if(this.idOdontologo == idDent)
		{
			var arregloDatos = this.numKeys.split(",");
			var objetosHoras = this.horario;
			for(var i = 0; i < arregloDatos.length; i++)
			{
				if(arregloDatos[i]!="")
				{
					var hora ="hora-"+arregloDatos[i];
					select = select + "<option value="+objetosHoras[hora]+">"+objetosHoras[hora]+"</option>";
				}
			}
			$("#selectHora").html(select);
		}
	});
}

function guardarHora()
{
	var idDentista = document.getElementById("selectDentista").value;
	var fechaSelect = document.getElementById("txtFecha").value;
	var horaSelect = document.getElementById("selectHora").value;
	var id = document.getElementById("pacientes").value;

	var ingresar = direccionWeb+"ws-cita.php";
	var data = {"send":"{\"indice\":1,\"idPaciente\":\""+id+"\",\"idOdontologo\":\""+idDentista+"\",\"fecha\":\""+fechaSelect+"\",\"horaInicio\":\""+horaSelect+"\",\"estado\":0}"};

	$.post(ingresar, data, function(datos)
	{
		var obj = $.parseJSON(datos);
		var idInsertado = obj.resultado;
		if(idInsertado != 0)
		{
			alert("Su cita fue ingresada correctamente.");
		}
		else
		{
			alert("Se produjo un error, vuelva a intentarlo.");
		}
	});
}