var direccionWeb = "http://172.16.28.138/sfhwebservice/webService/";
$(document).ready(inicializarElementos);
var horaActual;
var odontologoActual;
var editando="asd";
var arregloPersonas = [];
var arregloPersonasId = [];
var arregloHoras = [];
var idCita;

function inicializarElementos()
{
	editando=0;
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
		
		if($(this).text()=="Modificar"&&editando==0)
		{
			editando=1;
			var control = $(this);
			var fecha = $("#dateFecha").val()+" 13:13:00";
			var url = direccionWeb+"ws-horario.php";
			var data = {send:"{\"indice\":1,\"fecha\":\""+fecha+"\"}"};
			
			$.ajax({
				url: url,
				data: data,
				type: "POST",
				dataType: "json",
				success: function(source)
				{
					var data = source;
					ajaxCompleto(data,control);	
				},
				error: function(dato)
				{
					alert("No pudimos traer los datos");
				}
			});
			$(this).text("Guardar");
		}
		else if($(this).text()=="Guardar")
		{
			var boton = $(this);
			var url = direccionWeb+"ws-cita.php";

			var idCitaInterno = idCita;
			var odontologo = $(".selectOdontologo").val();
			var nomOdontologo = $(".selectOdontologo option[value='"+odontologo+"']").text();
			var horario = $(".selectHorario").val();
			var hora = $(".selectHorario option[value='"+horario+"']").text();
			var dates = $("#dateFecha").val().split("-");
			var date = dates[0]+"-"+dates[1]+"-"+dates[2];
			var optionValue = $(".opcion"+odontologo).attr("idOdontologo");
			var fechaMasHora = date+" "+hora;

			var data = {send:"{\"indice\":8,\"idOdontologo\":"+optionValue+",\"hora\":\""+fechaMasHora+"\",\"idCita\":"+idCitaInterno+"}"};

			$.post(url,data,function(datos)
			{
				var obj = $.parseJSON(datos);
				var resultado = obj.resultado;
				if(resultado=="se modifico correctamente")
				{
					boton.text("Modificar");
					editando=0;
					$(".hora").html(hora);
					$(".odontologo").html(nomOdontologo);
				}
				else if(resultado=="error al modificar")
				{
					alert("No ha cambiado ningun campo");
					boton.text("Modificar");
					editando=0;
					$(".hora").html(hora);
					$(".odontologo").html(nomOdontologo);
				}
				else
				{
					alert("hubo un error, por favor actualize la pagina");
				}
			});
		}
			
		
}
function ajaxCompleto(source,control)
{
	
	
	$.each(source['listaHorarios'],function(i,value)
	{
		arregloPersonas.push(value["nomOdontologo"]);
		arregloPersonasId.push(value["idOdontologo"]);
		var arreglo2 = [];
		$.each(this["horario"],function(i2,value2)
		{
			arreglo2.push(value2);
		});
		arregloHoras.push(arreglo2);
	});
	control.parent().parent().children().each(function(i)
	{
		if(i==0)
		{
			idCita = $(this).text();
		}
		if(i==3)
		{
			$(this).addClass("hora");
		 	horaActual = $(this).text();
		 	var select = "<select class='selectHorario'><option>"+horaActual+"</option>";
			$.each(arregloHoras[0],function(i2,value)
			{
				select = select+"<option value='"+i2+"'>"+value+"</option>";
			})
			select = select +"<select>";
			$(this).html(select);
		}
		if(i==4)
		{
			$(this).addClass("odontologo");
			controlDentista = $(this);
			odontologoActual = $(this).text();
			var select = "<select class='selectOdontologo'>";
			$.each(arregloPersonas,function(i2,value)
			{
				select = select+"<option value='"+i2+"' class='opcion"+i2+"' idOdontologo='"+arregloPersonasId[i2]+"'>"+value+"</option>";
			})
			select = select +"<select>";
			$(this).html(select);
		}
	});
	$("#tablaConfirmarHora").on("change",".selectOdontologo",cambiarHorario);
			
}
function cambiarHorario()
{
	var indice = $(this).val();
	var select = "<select class='selectHorario'>";
	$.each(arregloHoras[indice],function(i2,value)
	{
		select = select+"<option value='"+i2+"'>"+value+"</option>";
	})
	select = select +"<select>";
	$(".selectHorario").html(select);

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