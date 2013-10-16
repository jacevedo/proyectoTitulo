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

	var ingresar = direccionWeb+"ws-login.php";
	var data = {"send":"{\"indice\":1,\"usuario\":"+usuario+",\"pass\":\""+contrasena+"\"}"};

	$.post(ingresar, data, function(datos){
		var obj = $.parseJSON(datos);
		var codigo = obj.codAcceso;
		var key = obj.key;
		//usuario, key, cod acceso
		if(codigo == 704)
		{
			//alert(usuario);
			//window.location.href="login.php?user="+usuario+"&key="+key;

		    var form = $('<form></form>');

		    form.attr("method", "post");
		    form.attr("action", "login.php");

	        var field = $('<input></input>');

	        field.attr("type", "hidden");
	        field.attr("name", "key");
	        field.attr("value", key);

	        form.append(field);

	        var field1 = $('<input></input>');

	        field1.attr("type", "hidden");
	        field1.attr("name", "user");
	        field1.attr("value", usuario);

	        form.append(field1);

		    // The form needs to be a part of the document in
		    // order for us to be able to submit it.
		    $(document.body).append(form);
		    form.submit();

		}
		else
		{
			alert("Usuario y/o Contrase&ntilde;a erroneo.");
		}
	});
}