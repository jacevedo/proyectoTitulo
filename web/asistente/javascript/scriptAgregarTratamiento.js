var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/"
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	$("#btnAgregarTratamiento").click(agregarTratamiento);
	$("#txtNeto").change(calcularIvaTotal);
}
function agregarTratamiento()
{

	var procedimiento = $("#txtNomTratamiento").val();
	var neto = $("#txtNeto").val();
	var data = {"send":"{\"indice\":1,\"Comentario\":\""+procedimiento+"\",\"ValorNeto\":"+neto+"}"};
	var paginaLlamada = direccionWeb+"ws-precios-insumos.php";
	$.post(paginaLlamada,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		if(obj.idPrecioInsertado!=-1)
		{
			alert("Precio Agregado Correctamente");
			location.href="listaPrecios.php";
		}
		else
		{
			alert("Error al Insertar");
		}
	});
}

function calcularIvaTotal()
{
	var neto = $("#txtNeto").val();
	var iva = neto*19/100;
	var total = parseInt(neto) + parseInt(iva);

	$("#txtIva").val(iva);
	$("#txtTotal").val(total);
}