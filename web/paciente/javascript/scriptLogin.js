var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	$("#btnIngresar").click(login);
}

function login()
{
	var usuario = $("#txtUsuario").val();
	var contrasena = $("#txtPass").val();

	var ingresar = direccionWeb+"ws-login.php";
	var data = {"send":"{\"indice\":1,\"usuario\":"+usuario+",\"pass\":\""+contrasena+"\"}"};

	$.post(ingresar, data, function(datos){
		alert(datos);
		var obj = $.parseJSON(datos);
		var codigo = obj.codAcceso;
		var key = obj.key;
		var idPaciente = obj.idPaciente;

		if(codigo == 704)
		{
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

	        var field2 = $('<input></input>');

	        field2.attr("type", "hidden");
	        field2.attr("name", "pacienteId");
	        field2.attr("value", idPaciente);

	        form.append(field2);

		    $(document.body).append(form);
		    form.submit();
		}
		else
		{
			alert("Usuario y/o Contrase&ntilde;a erroneo.");
		}
	});
}