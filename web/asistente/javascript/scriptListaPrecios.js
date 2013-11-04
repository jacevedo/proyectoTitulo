var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/"
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	cargarListaPrecios();
	$("#btnBuscar").click(buscarPor);
	$("#btnAgregarTratamiento").click(agregarTratamiento);
}

function buscarPor()
{
	$("#tablaListaPrecios").off("click",".btnEditarPrecio",modificarObjeto);

	var concepto = $("#txtBuscaTratamiento").val();
	var precios = direccionWeb+"ws-precios-insumos.php";
	var data = {"send":"{\"indice\":4,\"nombre\":\""+concepto+"\"}"};

	var tabla = "";
	$.post(precios,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		$.each(obj.listaPrecios,function()
		{
			tabla = tabla+"<tr><td>"+this.idPrecios+"</td><td>"+this.comentario+"</td><td>"+this.valorTotal+"</td><td><Button class='btnEditarPrecio'>Editar</Button></td><td><Button class='btnEliminarPrecio'>Eliminar</Button></td></tr>";
		});
		$("#cuerpoTabla").html(tabla);
	});
	$("#tablaListaPrecios").on("click",".btnEditarPrecio",modificarObjeto);
	$("#tablaListaPrecios").on("click",".btnEliminarPrecio",eliminarObjeto);
}

function modificarObjeto()
{
	$("#tablaListaPrecios").off("click",".btnEditarPrecio",modificarObjeto);

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
				alert("El tratamiento fue modificado correctamente.");
			}
			else
			{
				alert("Se produjo un error, vuelva a intentarlo.")
			}
		});
	}
	$("#tablaListaPrecios").on("click",".btnEditarPrecio",modificarObjeto);
}

function cargarListaPrecios()
{
	var precios = direccionWeb+"ws-precios-insumos.php";
	var data = {"send":"{\"indice\":3}"};
	var tabla = "";

	$.post(precios,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		$.each(obj.listaPrecios,function()
		{
			tabla = tabla+"<tr><td>"+this.idPrecios+"</td><td>"+this.comentario+"</td><td>"+this.valorTotal+"</td><td><Button class='btnEditarPrecio'>Editar</Button></td><td><Button class='btnEliminarPrecio'>Eliminar</Button></td></tr>";
		});
		$("#cuerpoTabla").html(tabla);
	});
	$("#tablaListaPrecios").on("click",".btnEditarPrecio",modificarObjeto);
	$("#tablaListaPrecios").on("click",".btnEliminarPrecio",eliminarObjeto);
}

function eliminarObjeto()
{
	var id = '';
	var nombre = '';
	var precio = '';

	$(this).parent().parent().children().each(function(i)
	{
		if(i == 0)
		{
			id = $(this).html();
		}
	});

	var precios = direccionWeb+"ws-precios-insumos.php";
	var data = {"send":"{\"indice\":5,\"idPrecio\":"+id+"}"};

	$.post(precios,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		if(obj.Eliminado == "Eliminado")
		{
			alert("Tratamiento Eliminado.");
			location.reload();
		}
		else
		{
			alert("No se pudo eliminar el tratamiento.");
		}
	});
}

function agregarTratamiento()
{
	location.href="agregarTratamiento.php";
}