//var direccionWeb = "http://sfh.crossline.cl/webServiceencriptado/";
var direccionWeb = "";

$(document).ready(inicializarElementos);
var horaActual;
var odontologoActual;
var editando="asd";
var arregloPersonas = new Array();
var arregloPersonasId = new Array();
var arregloHoras = new Array();
var idCita;

function inicializarElementos()
{
	direccionWeb = $("#direccionWeb").val();
	editando=0;
	var fecha = new Date();
	var dia = fecha.getDate();
	var mes = fecha.getMonth()+1;
	var year = fecha.getFullYear();
	var fecha = year +"-"+mes+"-"+dia;
	$("#dateFecha").val(fecha);
	buscarFechas(fecha);
	$("#btnConfirmarHora").click(confirmarHora);
	$("#btnCrearHora").click(reservarHora);
	$("#btnBuscar").click(buscarHora);
	$("#txtBuscar").focus(limpiarFecha);
	$("#dateFecha").focus(limpiarTexto);
}
function limpiarTexto()
{
	$("#txtBuscar").val("");
}
function limpiarFecha()
{
	$("#dateFecha").val("");
}

function modificarHora()
{
	if($(this).text()=="Modificar"&&editando==0)
	{
		editando=1;
		var control = $(this);
		var fecha = $("#dateFecha").val()+" 13:13:00";
		var url = direccionWeb+"ws-horario.php";
		var key = $("#keyPaciente").val();
		var jsonEnviar = "{\"indice\":1,\"fecha\":\""+fecha+"\",\"key\":\""+key+"\"}";alert(jsonEnviar);
		var data = {"send":encriptar(jsonEnviar)};
		$.post(url,data,function(datos)
		{
			var datosDesencriptado = desencriptar(datos);
			ajaxCompleto(datosDesencriptado,control);

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
		var key = $("#keyPaciente").val();
		var jsonEnviar = "{\"indice\":8,\"idOdontologo\":"+optionValue+",\"hora\":\""+fechaMasHora+"\",\"idCita\":"+idCitaInterno+",\"key\":\""+key+"\"}";
		var data = {"send":encriptar(jsonEnviar)};
		
		$.post(url,data,function(jsonEncriptado)
		{
			var datos = desencriptar(jsonEncriptado);
			var obj = $.parseJSON(datos);
			var resultado = obj.resultado;
			if(resultado=="Datos modificados correctamente.")
			{
				boton.text("Modificar");
				editando=0;
				$(".hora").html(hora);
				$(".odontologo").html(nomOdontologo);
			}
			else if(resultado=="error al modificar")
			{
				alert("No ha modificado ning\u00fan campo.");
				boton.text("Modificar");
				editando=0;
				$(".hora").html(hora);
				$(".odontologo").html(nomOdontologo);
			}
			else
			{
				alert("Se produjo un error, vuelva a intentarlo.");
			}
		});
	}	
}
function ajaxCompleto(source,control)
{
	$.each(source.listaHorarios,function()
	{
		arregloPersonas.push(this.nomOdontologo);
		arregloPersonasId.push(this.idOdontologo);
		var arreglo2 = new Array();
		$.each(this.horario,function()
		{
			alert(this);
			arreglo2.push(this);
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
 	var url = direccionWeb+"ws-cita.php";
 	var key = $("#keyPaciente").val();
 	var jsonEnviar = "{\"indice\":7,\"idCita\":"+id+",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(jsonEnviar)};
	
	if (confirm("\u00BFDesea eliminar la cita seleccionada?")) 
	{
		$.post(url,data,function(jsonEncriptado)
		{
			var datos = desencriptar(jsonEncriptado);
			var obj = $.parseJSON(datos);
			
			if(obj.resultado=="true")
			{
				alert("Cita eliminada correctamente.");
				boton.parent().parent().fadeOut(500,function(){
					$(this).remove();
				});
			}
			else
			{
				alert("Se produjo un error, vuelva a intentarlo.");
			}
		});
	}
}

function buscarFechas(fecha)
{
	$("#tablaConfirmarHora").off("click",".btnModificar",modificarHora);
	$("#tablaConfirmarHora").off("click",".btnEliminar",eliminarHora);
	var url = direccionWeb + "ws-cita.php";
	var key = $("#keyPaciente").val();
	var jsonEnviar ="{\"indice\":5,\"fecha\":\""+fecha+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(jsonEnviar)};
	$.post(url,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var obj = $.parseJSON(datos);

		$.each(obj.resultado,function()
		{
			var cita = this.cita;
			var nomPaciente = cita.nomPaciente+" " + cita.appPaternoPaciente+" "+ cita.appMaternoPaciente;
			var hora = cita.horaInicio.split(" ");
			var fechaHoraBuscarda = cita.fecha;
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
			var html = "<tr><td class='tdId'>"+id+" </td><td>"+nomPaciente+"</td><td>"+telefono+"</td><td>"+fechaHoraBuscarda+"</td><td>"+hora[1]+"</td><td>"+odontologo+"</td><td><input type='checkbox' name='check' class='checkActual'></td><td><Button class='btnModificar btn btn-lg btn-primary btn-block'>Modificar</Button></td><td><Button class='btnEliminar btn btn-lg btn-primary btn-block'>Eliminar</Button></td></tr>"
			
			
			$("#cuerpoTabla").append(html);

			if(estado==1)
			{
				$(".checkActual").attr("checked","checked");

			}
			$(".checkActual").addClass("checkConf");
			$(".checkConf").removeClass("checkActual");
		});
		
	});
	$("#tablaConfirmarHora").on("click",".btnModificar",modificarHora);
	$("#tablaConfirmarHora").on("click",".btnEliminar",eliminarHora);
}

function confirmarHora()
{
	var key = $("#keyPaciente").val();
	var json = "{\"key\":\""+key+"\",\"indice\":6,\"citas\":[";
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
		if(json!="{\"key\":\""+key+"\",\"indice\":6,\"citas\":[")
		{
			json = json+",{\"idCita\":"+id+",\"estado\":"+estado+"}";
		}
		else
		{
			json = json+"{\"idCita\":"+id+",\"estado\":"+estado+"}";
		}

	});
	json = json +"]}";
	var url = direccionWeb+"ws-cita.php";
	var data = {"send":encriptar(json)};
	$.post(url,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var resultado = $.parseJSON(datos);
		if(resultado.devolucion==true)
		{
			alert("Cita confirmada correctamente.");
		}
		else
		{
			alert("Se produjo un error, vuelva a intentarlo.");
		}
	});
}

function reservarHora()
{
	location.href="reservarHoras.php";
}

function buscarHora()
{
	$("#cuerpoTabla").html("");
	var fechaBuscar = $("#dateFecha").val();
	var nombreBuscar = $("#txtBuscar").val();
	if(fechaBuscar == "" && nombreBuscar == "")
	{
		alert("Debe ingresar un campo v\u00e1lido.");
	}
	else if(fechaBuscar != "" & nombreBuscar == "")
	{
		buscarFechas(fechaBuscar);
	}
	else if(fechaBuscar == "" && nombreBuscar != "")
	{
		var pattern = /\d{7}|\d{8}/;
		if(nombreBuscar.match(pattern))
		{
			var elem = nombreBuscar.split('-');
			var rut = elem[0];
			var dv = elem[1];

			if(rut != "" && dv != "")
			{
				buscarPacientePorRut(rut);
			}
		}
		else
		{
			var elem = nombreBuscar.split(' ');
			var nombre = elem[0];
			var apellido = elem[1];

			if(nombre != "" && apellido != "")
			{
				buscarPacientePorNombre(nombre, apellido);
			}
		}
	}
	else
	{
		alert("Se produjo un error, vuelva a intentarlo.");
	}
}

function buscarPacientePorNombre(nombre, apellido)
{
	//Buscar por nombre {"indice":6,"nombre":"Jose","apellido":"Muñoz"}
	var idPaciente = "";
	var url = direccionWeb + "ws-admin-usuario-sig.php";
	var key = $("#keyPaciente").val();
	var stringJson = "{\"indice\":6,\"nombre\":\""+nombre+"\",\"apellido\":\""+apellido+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};
	$.post(url,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var objeto = $.parseJSON(datos);
		var paciente = objeto.buscarPacienteNombre;
		if(paciente != "")
		{
			var p = paciente[0];
			idPaciente = p.idPaciente;
			buscarCita(idPaciente);
		}
		else
		{
			alert("Se produjo un error, vuelva a intentarlo.");
		}
	});
}

function buscarPacientePorRut(rut)
{
	//Buscar por rut {"indice":5,"rut":17231233}
	var idPaciente = "";
	var url = direccionWeb + "ws-admin-usuario-sig.php";
	var key = $("#keyPaciente").val();
	var stringJson = "{\"indice\":5,\"rut\":\""+rut+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};
	$.post(url,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var objeto = $.parseJSON(datos);
		var paciente = objeto.buscarPacienteRut;
		if(paciente != "")
		{
			var p = paciente[0];
			idPaciente = p.idPaciente;
			buscarCita(idPaciente);
		}
		else
		{
			alert("Se produjo un error, vuelva a intentarlo.");
		}
	});
}

function buscarCita(idPaciente)
{

	$("#tablaConfirmarHora").off("click",".btnModificar",modificarHora);
	$("#tablaConfirmarHora").off("click",".btnEliminar",eliminarHora);
	//{"indice":2,"idPaciente":3}
	var url = direccionWeb + "ws-cita.php";
	var key = $("#keyPaciente").val();
	var stringJson = "{\"indice\":2,\"idPaciente\":\""+idPaciente+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};
	$.post(url,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var obj = $.parseJSON(datos);
		$.each(obj.resultado,function(datosInterno)
		{
			//[{horaInicio":"2014-02-24 12:30:00","fecha":"2014-02-24"
			var cita = this.cita;
			var nomPaciente = cita.nomPaciente+ " " + cita.appPaternoPaciente+" "+ cita.appMaternoPaciente;
			var horaI = cita.horaInicio;
			var hora = horaI.split(' ');
			var fechaHoraBuscarda = cita.fecha;
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
			var html = "<tr><td class='tdId'>"+id+" </td><td>"+nomPaciente+"</td><td>"+telefono+"</td><td>"+fechaHoraBuscarda+"</td><td>"+hora[1]+"</td><td>"+odontologo+"</td><td><input type='checkbox' name='check' class='checkActual'></td><td><Button class='btnModificar btn btn-lg btn-primary btn-block'>Modificar</Button></td><td><Button class='btnEliminar btn btn-lg btn-primary btn-block'>Eliminar</Button></td></tr>"
			
			
			$("#cuerpoTabla").append(html);

			if(estado==1)
			{
				$(".checkActual").attr("checked","checked");

			}
			$(".checkActual").addClass("checkConf");
			$(".checkConf").removeClass("checkActual");
		});
		//$("#tablaConfirmarHora").on("click",".btnModificar",modificarHora);
		//$("#tablaConfirmarHora").on("click",".btnEliminar",eliminarHora);
	});
	$("#tablaConfirmarHora").on("click",".btnModificar",modificarHora);
	$("#tablaConfirmarHora").on("click",".btnEliminar",eliminarHora);
}

