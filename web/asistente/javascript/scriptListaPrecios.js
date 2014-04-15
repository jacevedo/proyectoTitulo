//var direccionWeb = "http://sfh.crossline.cl/webServiceencriptado/";
var direccionWeb = "";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	direccionWeb = $("#direccionWeb").val();
	cargarListaPrecios();
	$("#btnBuscar").click(buscarPor);
	$("#btnAgregarTratamiento").click(agregarTratamiento);
	$("#crearNuevoPrecio").click(crearPrecio);
	$("#txtNomProcedimiento").blur(validarVacio);
	$("#txtCostoProcedimiento").blur(validarCostoP);
	$("#filaAgregar").hide();
}
function validarVacio()
{
	var nomProcedimiento = $("#txtNomProcedimiento").val();
	if(nomProcedimiento.length==0)
	{
		$("#spanErrorNomProcedimiento").html("Debe ingresar un nombre");
		return false;
	}
	else
	{
		$("#spanErrorNomProcedimiento").html("");
		return true;
	}
}
function validarCostoP()
{
	var costo = $("#txtCostoProcedimiento").val();
	var pattern = /[0-9]/
	if(costo.length == 0)
	{
		$("#spanErrorCostoProcedimiento").html("Debe ingresar un valor");
		return false;
	}
	else
	{
		$("#spanErrorCostoProcedimiento").html("");
		if(!costo.match(pattern))
		{
			$("#spanErrorCostoProcedimiento").html("Debe ingresar s&oacute;lo d&iacute;gitos");
			return false;
		}
		else
		{
			$("#spanErrorCostoProcedimiento").html("");
			return true;
		}
	}

}
function crearPrecio()
{
	if(validarVacio()&validarCostoP())
	{
		var nomProcedimiento = $("#txtNomProcedimiento").val();
		var precioProcedimiento = $("#txtCostoProcedimiento").val();

		//{"indice":1,"Comentario":"Procedimiento","ValorNeto":12000}
		var url = direccionWeb + "ws-precios-insumos.php";
		var key = $("#keyPaciente").val();
		var stringJson = "{\"indice\":1,\"Comentario\":\""+nomProcedimiento+"\",\"ValorNeto\":"+precioProcedimiento+",\"key\":\""+key+"\"}";
		var data = {"send":encriptar(stringJson)};
		$.post(url,data,function(jsonEncriptado)
		{
			var datos = desencriptar(jsonEncriptado);
			var obj = $.parseJSON(datos);
			if(obj.idPrecioInsertado!=-1)
			{
				alert("Procedimiento guardado correctamente.")
				var textoNuevo = "<tr><td>"+obj.idPrecioInsertado+"</td><td>"+nomProcedimiento+"</td><td>"+precioProcedimiento+"</td><td><button class=\"btnEditarPrecio btn btn-lg btn-primary btn-block\" type=\"submit\">Editar</button></td><td><button class=\"btnEliminarPrecio btn btn-lg btn-primary btn-block\" type=\"submit\">Eliminar</button></td></tr>";
				$("#cuerpoTabla").prepend(textoNuevo);
				$("#tablaListaPrecios").off("click",".btnEditarPrecio",modificarObjeto);
				$("#tablaListaPrecios").off("click",".btnEliminarPrecio",eliminarObjeto);

				$("#tablaListaPrecios").on("click",".btnEditarPrecio",modificarObjeto);
				$("#tablaListaPrecios").on("click",".btnEliminarPrecio",eliminarObjeto);
			}
			else
			{
				alert("Se produjo un error, vuelva a intentarlo.");
			}
		});
	}

}
function buscarPor()
{
	$("#tablaListaPrecios").off("click",".btnEditarPrecio",modificarObjeto);

	var concepto = $("#txtBuscaTratamiento").val();
	var precios = direccionWeb+"ws-precios-insumos.php";
	var tabla = "";
	var key = $("#keyPaciente").val();
	var stringJson = "{\"indice\":4,\"nombre\":\""+concepto+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};
	$.post(precios,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
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
function validarCostoBoton(boton)
{
	var idCosto  = boton.attr("idCosto");
	var costo = $("#costo-"+idCosto).val();
	var pattern = /^[0-9]/
	if(!costo.match(pattern))
	{
		$("#spanErrorCostoDinamico").html("Debe ingresar s&oacute;lo d&iacute;gitos");
		return false;
	}
	else
	{
		$("#spanErrorCostoDinamico").html("");
		return true;
	}

}
function validarNomProcedimientoBoton(boton)
{
	var idCosto  = boton.attr("idCosto");
	var concepto = $("#concepto-"+idCosto).val();
	if(concepto.length==0)
	{
		$("#spanErrorConceptoDinamico").html("Debe ingresar un valor");
		return false;
	}
	else
	{
		$("#spanErrorConceptoDinamico").html("");
		return true;
	}
}
function modificarObjeto()
{
	var boton = $(this);
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
				var input = "<input type='text' id='concepto-"+idCosto+"'  style='width: 80%;' /><br><span id='spanErrorConceptoDinamico' class='error'></span>";
				$(this).html(input);
				$("#concepto-"+idCosto).val(valor);
			}
			else if(i==2)
			{
				var valor = $(this).html();
				var input = "<input type='text' id='costo-"+idCosto+"'  style='width: 80%;' /><span id='spanErrorCostoDinamico' class='error'></span>";				
				$(this).html(input);
				$("#costo-"+idCosto).val(valor);
			}
			else if(i==3)
			{
				$(this).html("<Button idCosto="+idCosto+" class='btnEditarPrecio btn btn-lg btn-primary btn-block'>Guardar</Button>");
			}
		});
		$("#cuerpoTabla").on("blur","#concepto-"+idCosto,validarConcepto);
		$("#cuerpoTabla").on("blur","#costo-"+idCosto,validarCosto);
	}
	else
	{
		if(validarCostoBoton(boton)&validarNomProcedimientoBoton(boton))
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
			var key = $("#keyPaciente").val();
			var stringJson = "{\"indice\":2,\"idPrecio\":"+idCosto+",\"Comentario\":\""+concepto+"\",\"ValorNeto\":"+costo+",\"key\":\""+key+"\"}";
			var data = {"send":encriptar(stringJson)};
			$.post(precios,data,function(jsonEncriptado)
			{
				var datos = desencriptar(jsonEncriptado);
				var obj = $.parseJSON(datos);
				var resultado = obj.Modificado;
				if(resultado=="Modificado")
				{
					alert("Tratamiento modificado correctamente.");
				}
				else
				{
					alert("Se produjo un error, vuelva a intentarlo.")
				}
			});
		}
	}
	$("#tablaListaPrecios").on("click",".btnEditarPrecio",modificarObjeto);
}
function validarConcepto(idCosto)
{
	var concepto = $(this).val();
	if(concepto.length==0)
	{
		$("#spanErrorConceptoDinamico").html("Debe ingresar un valor");
		return false;
	}
	else
	{
		$("#spanErrorConceptoDinamico").html("");
		return true;
	}

}
function validarCosto(idCosto)
{
	var costo = $(this).val();
	var pattern = /^[0-9]/
	if(!costo.match(pattern))
	{
		$("#spanErrorCostoDinamico").html("Debe ingresar s&oacute;lo d&iacute;gitos");
		return false;
	}
	else
	{
		$("#spanErrorCostoDinamico").html("");
		return true;
	}


}
function cargarListaPrecios()
{
	var precios = direccionWeb+"ws-precios-insumos.php";
	var tabla = "";
	var key = $("#keyPaciente").val();
	var stringJson = "{\"indice\":3,\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};
	$.post(precios,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
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
	var key = $("#keyPaciente").val();
	var stringJson = "{\"indice\":5,\"idPrecio\":"+id+",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};
	$.post(precios,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var obj = $.parseJSON(datos);
		if(obj.Eliminado == "Eliminado")
		{
			alert("Tratamiento eliminado correctamente.");
			location.reload();
		}
		else
		{
			alert("Se produjo un error, vuelva a intentarlo.");
		}
	});
}

function agregarTratamiento()
{
	if($(this).html()=="Agregar")
	{
		$("#filaAgregar").fadeIn();
		$(this).html("Cerrar");
	}
	else if($(this).html()=="Cerrar")
	{
		$("#filaAgregar").fadeOut();
		$(this).html("Agregar");
	}
}
