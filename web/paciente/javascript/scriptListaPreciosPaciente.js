var direccionWeb = ""
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	direccionWeb = $("#direccionWeb").val();
	cargarListaPrecios();
	$("#btnBuscar").click(buscarPor);
}
function buscarPor()
{
	var concepto = $("#txtBuscaTratamiento").val();
	var tabla = "";
	var key = $("#keyPaciente").val();
	var precios = direccionWeb+"ws-precios-insumos.php";
	var stringJson = "{\"indice\":4,\"nombre\":\""+concepto+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};

	$.post(precios,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var obj = $.parseJSON(datos);
		$.each(obj.listaPrecios,function()
		{
			tabla = tabla+"<tr><td>"+this.idPrecios+"</td><td>"+this.comentario+"</td><td>"+this.valorTotal+"</td></tr>";
		});
		$("#cuerpoTabla").html(tabla);
	});
}

function cargarListaPrecios()
{
	var precios = direccionWeb+"ws-precios-insumos.php";
	var key = $("#keyPaciente").val();
	var stringJson = "{\"indice\":3,\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};
	var tabla = "";

	$.post(precios,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var obj = $.parseJSON(datos);
		$.each(obj.listaPrecios,function()
		{
			tabla = tabla+"<tr><td>"+this.idPrecios+"</td><td>"+this.comentario+"</td><td>"+this.valorTotal+"</td></tr>";
		});
		$("#cuerpoTabla").html(tabla);
	});
}
