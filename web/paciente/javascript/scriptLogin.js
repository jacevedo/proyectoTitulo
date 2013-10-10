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
		var obj = $.parseJSON(datos);
		var codigo = obj.codAcceso;
		if(codigo == 704)
		{
			//alert("OK");
		}
		else
		{
			alert("Usuario y/o Contraseña erroneo.");
		}
	});
}