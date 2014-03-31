var direccionWeb = "";
$(document).ready(inicializarEventos);
var horarios = '';

function inicializarEventos()
{
	direccionWeb = $("#direccionWeb").val();
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
		
		if(horarios!=null)
		{
			var select = '';
			select = select + "<option value='0'>Seleccione un Dentista</option>";

			$.each(horarios,function()
			{
				select = select + "<option value="+this.idOdontologo+">"+this.nomOdontologo+"</option>";
			});
			$("#selectDentista").html(select);	
		}
		else
		{
			alert("No se encontraron dentistas.");
			$("#selectDentista").html("");	
		}
		
	});
	$("#selectDentista").change(cargarHoras);
}

function cargarHoras()
{
	var idDent = $("#selectDentista").val();
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
	var idDentista = $("#selectDentista").val();
	var fechaSelect = $("#txtFecha").val();
	var horaSelect = $("#selectHora").val();
	var id = $("#pacientes").val();

	var ingresar = direccionWeb+"ws-cita.php";
	var data = {"send":"{\"indice\":1,\"idPaciente\":\""+id+"\",\"idOdontologo\":\""+idDentista+"\",\"fecha\":\""+fechaSelect+"\",\"horaInicio\":\""+horaSelect+"\",\"estado\":0}"};

	$.post(ingresar, data, function(datos)
	{
		var obj = $.parseJSON(datos);
		var idInsertado = obj.resultado;
		if(idInsertado != 0)
		{
			alert("Cita insertada correctamente.");
			location.href="verHoras.php";
		}
		else
		{
			alert("Se produjo un error, vuelva a intentarlo.");
		}
	});
}