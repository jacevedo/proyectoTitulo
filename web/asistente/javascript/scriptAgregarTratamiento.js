var direccionWeb = "http://192.168.89.128/sfhwebservice/webService/"
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	obtenerTratamientos();
	$("#btnAgregarTratamiento").click(agregarTratamiento);
	$("#txtNeto").change(calcularIvaTotal);
}
function obtenerTratamientos()
{
	var url = direccionWeb+"ws-tratamiento-abono.php";
	var data = {send:"{\"indice\":3}"};
	$.post(url,data,function(data)
	{
		alert(data);
	});
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
			alert("Tratamiento agregado correctamente.");
			location.href="listaPrecios.php";
		}
		else
		{
			alert("Se produjo un error, vuelva a intentarlo.");
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