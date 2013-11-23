var direccionWeb = "http://172.16.28.138/sfhwebservice/webService/";
$(document).ready(inicializarElementos);
function inicializarElementos()
{
	var fecha = new Date();
	var dia = fecha.getDate();
	var mes = fecha.getMonth()+1;
	var year = fecha.getFullYear();
	var fecha = year +"-"+mes+"-"+dia;
	$("#dateFecha").val(fecha);
	buscarFechas(fecha);
	$("#btnConfirmarHora").click(confirmarHora);
}
function modificarHora()
{
	alert("hoa");
}
function eliminarHora()
{
 	var id = $(this).parent().parent().children().first().text();
 	var boton = $(this);
 	var data = {"send":"{\"indice\":7,\"idCita\":"+id+"}"};
	var url = direccionWeb+"ws-cita.php";
	if (confirm("¿Desea Eliminar La cita seleccionada?")) 
	{

		$.post(url,data,function(datos)
		{
			if(datos==1)
			{
				alert("Las cita fue eliminada Correctamente");
				boton.parent().parent().fadeOut(500,function(){
					$(this).remove();
				});
			}
			else
			{
				alert("Hubo un error al eliminar la cita");
			}
		});
	}
}
function buscarFechas(fecha)
{
	var url = direccionWeb + "ws-cita.php";
	var data = {send:"{\"indice\":5,\"fecha\":\""+fecha+"\"}"};
	$.post(url,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		$.each(obj.resultado,function()
		{
			var cita = this.cita;
			var nomPaciente = cita.nomPaciente+" " + cita.appPaternoPaciente+" "+ cita.appMaternoPaciente;
			var hora = cita.horaInicio.split(" ");
			if(this.fonoFijo == null)
			{
				var fonoFijo = "--";
			}
			else
			{
				var fonoFijo = this.fonoFijo;
			}
			if(this.fonoCelular ==null)
			{
				var fonoCelular="--";
			}
			else
			{
				var fonoCelular=this.fonoCelular;
			}

			var telefono = fonoFijo+" " +fonoCelular;
			var id = cita.idCita;
			var estado = cita.estado;
			var odontologo = cita.nomOdontologo+" "+cita.appPaternoOdontologo+" " + cita.appMaternoOdontologo;
			var html = "<tr><td class='tdId'>"+id+" </td><td>"+nomPaciente+"</td><td>"+telefono+"</td><td>"+hora[1]+"</td><td>"+odontologo+"</td><td><input type='checkbox' name='check' class='checkActual'></td><td><Button class='btnModificar btn btn-lg btn-primary btn-block'>Modificar</Button></td><td><Button class='btnEliminar btn btn-lg btn-primary btn-block'>Eliminar</Button></td></tr>"
			
			
			$("#cuerpoTabla").append(html);

			if(estado==1)
			{
				$(".checkActual").attr("checked","checked");

			}
			$(".checkActual").addClass("checkConf");
			$(".checkConf").removeClass("checkActual");
		});
		$("#tablaConfirmarHora").on("click",".btnModificar",modificarHora);
		$("#tablaConfirmarHora").on("click",".btnEliminar",eliminarHora);
	});
}
function confirmarHora()
{
	var json = "{\"indice\":6,\"citas\":[";
	$(".checkConf").each(function()
		{

			var id = $(this).parent().parent().children().first().text();
			var estado;
			if($(this).is(":checked"))
			{
				estado = 1;
			}
			else
			{
				estado = 0;
			}
			if(json!="{\"indice\":6,\"citas\":[")
			{
				json = json+",{\"idCita\":"+id+",\"estado\":"+estado+"}";
			}
			else
			{
				json = json+"{\"idCita\":"+id+",\"estado\":"+estado+"}";
			}

		});
	json = json +"]}";
	var data = {"send":json};
	var url = direccionWeb+"ws-cita.php";
	$.post(url,data,function(datos)
	{
		if(datos==1)
		{
			alert("Las citas fueron Modificadas Correctamente");
		}
		else
		{
			alert("Hubo un error al Modificar las citas");
		}
	});
}