var direccionWeb = ""
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	direccionWeb = $("#direccionWeb").val();
	cargarOdontologos();
}
function cargarOdontologos()
{
	var url = direccionWeb + "ws-admin-usuario.php";
	var data = {"send":"{\"indice\":17}"};
	$.post(url,data,function(datos)
	{
		var tabla = "";
		var obj = $.parseJSON(datos);
		$.each(obj.listaOdontologoHerencia,function()
		{
			tabla = tabla+"<tr><td>"+this.nombre+"</td><td>"+this.apellidoPaterno+"</td><td>"+this.apellidoMaterno+"</td><td>"+this.rut+"-"+this.dv+"</td><td><button class='btnModificarHorario btn btn-lg btn-primary btn-block' type='submit' idOdontologo=\""+this.idOdontologo+"\" >Horario</button></td></tr>";
		});
		$("#cuerpoTabla").html(tabla);
	});
	$("#tablaListaOdontologos").on("click",".btnModificarHorario",llamarHorarios);
}

function llamarHorarios()
{
	var id = $(this).attr("idodontologo");
	var form = $('<form></form>');

    form.attr("method", "post");
    form.attr("action", "horarioOdontologo.php");

    var field = $('<input></input>');

    field.attr("type", "hidden");
    field.attr("name", "idOdontologo");
    field.attr("value", id);

    form.append(field);
    $(document.body).append(form);
    form.submit();
}
