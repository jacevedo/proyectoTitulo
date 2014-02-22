var direccionWeb = "http://192.168.89.128/sfhwebservice/webService/"
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	cargarListaPrecios();
	$("#btnBuscar").click(buscarPor);
	$("#btnAgregarTratamiento").click(agregarTratamiento);
	$("#crearNuevoPrecio").click(crearPrecio);
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
			tabla = tabla+"<tr><td>"+this.idPrecios+"</td><td>"+this.comentario+"</td><td>"+this.valorTotal+"</td><td><button class='btnEditarPrecio btn btn-lg btn-primary btn-block' type='submit'>Editar</button></td><td><button class='btnEliminarPrecio btn btn-lg btn-primary btn-block' type='submit'>Eliminar</button></td></tr>";
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
				$(this).html("<Button class='btnEditarPrecio btn btn-lg btn-primary btn-block'>Guardar</Button>");
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
				$(this).html("<Button class='btnEditarPrecio btn btn-lg btn-primary btn-block'>Editar</Button>");
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
			tabla = tabla+"<tr><td>"+this.idPrecios+"</td><td>"+this.comentario+"</td><td>"+this.valorTotal+"</td><td><Button class='btnEditarPrecio btn btn-lg btn-primary btn-block'>Editar</Button></td><td><Button class='btnEliminarPrecio btn btn-lg btn-primary btn-block'>Eliminar</Button></td></tr>";
		});
		$("#cuerpoTabla").html(tabla);
	});
	$("#tablaListaPrecios").on("click",".btnEditarPrecio",modificarObjeto);
	$("#tablaListaPrecios").on("click",".btnEliminarPrecio",eliminarObjeto);
}

//
function crearPrecio()
{
	var nomProcedimiento = $("#txtNomProcedimiento").val();
	var precioProcedimiento = $("#txtCostoProcedimiento").val();
	
	//{"indice":1,"Comentario":"Procedimiento","ValorNeto":12000}
	var url = direccionWeb + "ws-precios-insumos.php";
	var data = {"send":"{\"indice\":1,\"Comentario\":\""+nomProcedimiento+"\",\"ValorNeto\":"+precioProcedimiento+"}"};
	$.post(url,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		if(obj.idPrecioInsertado!=-1)
		{
			alert("Procedimiento Insertado Correctamente");
			
			var textoNuevo = "<tr><td>"+obj.idPrecioInsertado+"</td><td>"+nomProcedimiento+"</td><td>"+precioProcedimiento+"</td><td><button class=\"btnEditarPrecio btn btn-lg btn-primary btn-block\" type=\"submit\">Editar</button></td><td><button class=\"btnEliminarPrecio btn btn-lg btn-primary btn-block\" type=\"submit\">Eliminar</button></td></tr>";
			$("#cuerpoTabla").prepend(textoNuevo);
			$("#tablaListaPrecios").off("click",".btnEditarPrecio",modificarObjeto);
			$("#tablaListaPrecios").off("click",".btnEliminarPrecio",eliminarObjeto);

			$("#tablaListaPrecios").on("click",".btnEditarPrecio",modificarObjeto);
			$("#tablaListaPrecios").on("click",".btnEliminarPrecio",eliminarObjeto);
		}
		else
		{
			alert("Hubo un error al insertar el procedimiento");
		}
	});
}

function agregarTratamiento()
{
	//location.href="agregarTratamiento.php";
}
