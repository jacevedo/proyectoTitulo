var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/"
$(document).ready(inicializarEventos);

function inicializarEventos()
{

	$("#btnAgregarTratamiento").click(agregarTratamiento);
}
function agregarTratamiento()
{

	var procedimiento = $("#txtNeto").val();
	var neto = $("#txtNeto").val();
	var data = {"send":"{\"indice\":1,\"Comentario\":\""+procedimiento+"\",\"ValorNeto\":"+neto+"}"};
	var paginaLlamada = direccionWeb+"ws-precios-insumos.php";
	$.post(paginaLlamada,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		if(obj.idPrecioInsertado!=-1)
		{
			alert("Precio Agregado Correctamente");
		}
		else
		{
			alert("Error al Insertar");
		}
	});
}