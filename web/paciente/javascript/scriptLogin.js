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
		var key = obj.key;
		//usuario, key, cod acceso
		if(codigo == 704)
		{
			//alert("OK");
			window.location.href="perfil.php?user="+usuario+"&key="+key;
		}
		else
		{
			alert("Usuario y/o Contrase&ntilde;a erroneo.");
		}
	});
}