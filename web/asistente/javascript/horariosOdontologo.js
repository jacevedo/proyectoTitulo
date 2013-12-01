var direccionWeb = "http://172.16.28.138/sfhwebservice/webService/";
$(document).ready(inicializarEventos);
var diasArreglo = new Array();
var idHorarioArreglo = new Array();
function inicializarEventos()
{
	cargarHorarios();
	$(".btnGuardar").click(guardarDia);
}
function guardarDia()
{
	var dia = $(this).attr("dia");
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
function cargarHorarios()
{
	var idOdontologo = $("#idOdontologo").val();
	var url = direccionWeb + "ws-horario.php";
	var data = {"send":"{\"indice\":4,\"idOdontologo\":"+idOdontologo+"}"};

	$.post(url,data,function(datos)
	{
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




























