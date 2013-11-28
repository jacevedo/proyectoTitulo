var direccionWeb = "http://172.16.28.138/sfhwebservice/webService/";
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
		var obj = $.parseJSON(datos);
		var resultado = obj.resultado;
		var codigo = resultado.codAcceso;
		var key = resultado.key;
		var idPaciente = resultado.idPaciente;
		var nomPaciente = resultado.nombre;
		var appPaciente = resultado.appPaterno;
	

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

	        var field3 = $('<input></input>');

	        field3.attr("type", "hidden");
	        field3.attr("name", "nomPaciente");
	        field3.attr("value", nomPaciente);

	        form.append(field3);

	        var field4 = $('<input></input>');

	        field4.attr("type", "hidden");
	        field4.attr("name", "appPaciente");
	        field4.attr("value", appPaciente);

	        form.append(field4);

		    $(document.body).append(form);
		    form.submit();
		}
		else
		{
			alert("Usuario y/o Contrase&ntilde;a erroneo.");
		}
	});
}