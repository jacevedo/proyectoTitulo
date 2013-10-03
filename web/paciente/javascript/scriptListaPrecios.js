var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/"
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	cargarListaPrecios();
	$("#btnBuscar").click(buscarPor);
}
function buscarPor()
{
	var concepto = $("#txtBuscaTratamiento").val();
	var precios = "http://localhost/proyectoTitulo/sfhwebservice/webService/ws-precios-insumos.php";
	var data = {"send":"{\"indice\":4,\"nombre\":\""+concepto+"\"}"};
	var tabla = "";
	$.post(precios,data,function(datos){
		var obj = $.parseJSON(datos);
		$.each(obj.listaPrecios,function()
			{
				tabla = tabla+"<tr><td>"+this.idPrecios+"</td><td>"+this.comentario+"</td><td>"+this.valorTotal+"</td></tr>";
			});
		$("#cuerpoTabla").html(tabla);
		//var obj2 = jQuery.parseJSON(obj.listaPrecios[1]);
		//alert(obj.listaPrecios[0].valorNeto);
	});
}
function cargarListaPrecios()
{
	var precios = "http://localhost/proyectoTitulo/sfhwebservice/webService/ws-precios-insumos.php";
	var data = {"send":"{\"indice\":3}"};
	var tabla = "";
	$.post(precios,data,function(datos){
		var obj = $.parseJSON(datos);
		$.each(obj.listaPrecios,function()
			{
				tabla = tabla+"<tr><td>"+this.idPrecios+"</td><td>"+this.comentario+"</td><td>"+this.valorTotal+"</td></tr>";
			});
		$("#cuerpoTabla").html(tabla);
		//var obj2 = jQuery.parseJSON(obj.listaPrecios[1]);
		//alert(obj.listaPrecios[0].valorNeto);
	});
	
}
