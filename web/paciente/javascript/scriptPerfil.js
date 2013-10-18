var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	cargarPerfil();
	
}

function cargarPerfil()
{
	var id = $("#idPaciente").val();
	var key = $("#keyPaciente").val();
	//alert("Id: "+id+" || key: "+key);
	var ingresar = direccionWeb+"ws-add-usuario.php";
	var data = {"send":"{\"indice\":2,\"rut\":"+id+"}"};
	//{"indice":2,"rut":16009332

	$.post(ingresar, data, function(datos){
		alert(datos);
		var obj = $.parseJSON(datos);
		var persona = obj.datosPersona;
		var contacto = obj.datosContacto;
		//alert("Persona: "+obj.datosPersona.apellidoMaterno+". Contacto: "+contacto.direccion);

		var tabla = "";
		if(contacto == "No hay datos de contacto")
		{
			tabla = tabla + "<tr><td class='tdIndicador'>Numero:</td><td>"+persona.idPersona+"</td></tr><tr><td class='tdIndicador'>Nombre:</td><td>"+persona.nombre+"</td></tr><tr><td class='tdIndicador'>Apellido Paterno:</td><td>"+persona.apellidoPaterno+"</td></tr><tr><td class='tdIndicador'>Apellido Materno:</td><td>"+persona.apellidoMaterno+"</td></tr><tr><td class='tdIndicador'>Rut:</td><td>"+persona.rut+"-"+persona.dv+"</td></tr><tr><td class='tdIndicador'>Fecha de Nacimiento:</td><td>"+persona.fechaNacimiento+"</td></tr><tr><td class='tdIndicador'>Direccion:</td><td>----</td></tr><tr><td class='tdIndicador'>Comuna</td><td>----</td></tr><tr><td class='tdIndicador'>Telefono Fijo</td><td>----</td></tr><tr><td class='tdIndicador'>Celular</td><td>----</td></tr><tr><td colspan=2><button id='btnCrearCuenta'>Modificar Cuenta</button></td></tr>";
		}
		else
		{
			tabla = tabla + "<tr><td class='tdIndicador'>Numero:</td><td>"+persona.idPersona+"</td></tr><tr><td class='tdIndicador'>Nombre:</td><td>"+persona.nombre+"</td></tr><tr><td class='tdIndicador'>Apellido Paterno:</td><td>"+persona.apellidoPaterno+"</td></tr><tr><td class='tdIndicador'>Apellido Materno:</td><td>"+persona.apellidoMaterno+"</td></tr><tr><td class='tdIndicador'>Rut:</td><td>"+persona.rut+"-"+persona.dv+"</td></tr><tr><td class='tdIndicador'>Fecha de Nacimiento:</td><td>"+persona.fechaNacimiento+"</td></tr><tr><td class='tdIndicador'>Direccion:</td><td>"+contacto.direccion+"</td></tr><tr><td class='tdIndicador'>Comuna</td><td>"+contacto.idComuna+"</td></tr><tr><td class='tdIndicador'>Telefono Fijo</td><td>"+contacto.fonoFijo+"</td></tr><tr><td class='tdIndicador'>Celular</td><td>"+contacto.fonoCelular+"</td></tr><tr><td colspan=2><button id='btnCrearCuenta'>Modificar Cuenta</button></td></tr>";
		}
		$("#tablaContenido").html(tabla);
	});
	$("#tablaContenido").on("click",".btnCrearCuenta",modificarObjeto);
}

function modificarObjeto()
{
	$("#tablaContenido").off("click",".btnCrearCuenta",modificarObjeto);

	if($(this).html()=="Editar")
	{
		var idCosto;
		$(this).parent().parent().children().each(function(i)
		{
			var texto = $(this).html();
			if(i==0)
			{
				idCosto = $(this).html();
			}
			else if(i==1)
			{
				var valor = $(this).html();
				var input = "<input type='text' id='concepto-"+idCosto+"'  style='width: 80%;' />";
				$(this).html(input);
				$("#concepto-"+idCosto).val(valor);

			}
			else if(i==2)
			{
				var valor = $(this).html();
				var input = "<input type='text' id='costo-"+idCosto+"'  style='width: 80%;' />";				
				$(this).html(input);
				$("#costo-"+idCosto).val(valor);
			}
			else if(i==3)
			{
				$(this).html("<Button class='btnEditarPrecio'>Guardar</Button>");
			}
		});
	}
	else
	{
		var idCosto;
		var concepto;
		var costo;
		$(this).parent().parent().children().each(function(i)
		{
			var texto = $(this).html();
			if(i==0)
			{
				idCosto = $(this).html();
			}
			else if(i==1)
			{
				concepto = $("#concepto-"+idCosto).val();
				$(this).html(concepto);
			}
			else if(i==2)
			{
				costo = $("#costo-"+idCosto).val();
				$(this).html(costo);
			}
			else if(i==3)
			{
				$(this).html("<Button class='btnEditarPrecio'>Editar</Button>");
			}
		});

		var precios = direccionWeb+"ws-precios-insumos.php";
		var data = {"send":"{\"indice\":2,\"idPrecio\":"+idCosto+",\"Comentario\":\""+concepto+"\",\"ValorNeto\":"+costo+"}"};
		$.post(precios,data,function(datos)
		{
			var obj = $.parseJSON(datos);
			var resultado = obj.Modificado;
			if(resultado=="Modificado")
			{
				alert("sus datos fueron modificados correctamente");
			}
			else
			{
				alert("no se produjo ninguna modificacion")
			}
		});
		
	}
	$("#tablaListaPrecios").on("click",".btnEditarPrecio",modificarObjeto);
}