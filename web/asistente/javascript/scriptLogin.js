var direccionWeb = "http://192.168.89.128/sfhwebservice/webService/";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	$("#btnIngresar").click(login);
	$("#txtUsuario").blur(validarUsuario);
	$("#txtPass").blur(validarPass);
}

function validarUsuario()
{
	var usuario = $("#txtUsuario").val();
	var RegExPattern = /\d{7}|\d{8}/;
	if(!usuario.match(RegExPattern))
	{
		$("#validacionUsuario").html("Debe ingresar su rut sin guion ni digito verificador");
		return false;
	}
	else
	{
		$("#validacionUsuario").html("");
		return true;
	}
}
function validarPass()
{
	var pass = $("#txtPass").val();
	if(pass.length==0)
	{
		$("#validacionContrasena").html("Debe ingresar una contrase&ntilde;a");
		return false;
	}
	else
	{
		$("#validacionContrasena").html("");
		return true;
	}
}

function login()
{
	if(validarUsuario()&validarPass())
	{
		var usuario = $("#txtUsuario").val();
		var contrasena = $("#txtPass").val();

		var ingresar = direccionWeb+"ws-login.php";
		var data = {"send":"{\"indice\":2,\"usuario\":"+usuario+",\"pass\":\""+contrasena+"\"}"};

		$.post(ingresar, data, function(datos){
			var datosObjeto = $.parseJSON(datos);
			var obj = datosObjeto.resultado;
			var codigo = obj.codAcceso;
			var key = obj.key;
			var idPaciente = obj.idPaciente;
			var nombre = obj.nombre;
			var appPaterno = obj.appPaterno;
			if(codigo == 707 || codigo == 706 || codigo == 705)
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
		        field3.attr("name", "nombre");
		        field3.attr("value", nombre);

		        form.append(field3);
		         
		        var field4 = $('<input></input>');
		        field4.attr("type", "hidden");
		        field4.attr("name", "appPaterno");
		        field4.attr("value", appPaterno);

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
}
function validarUser()
{
	if (!e) var e = window.event
	if (e.keyCode) code = e.keyCode;
	else if (e.which) code = e.which;
	var character = String.fromCharCode(code);
	var digitsOnly = /[1234567890]/g;

	var retorno=true;

	if (code==27) { this.blur(); return false; }

	var control = $("#txtUsuario");

	if (!e.ctrlKey && code!=9 && code!=8 && code!=36 && code!=37 && code!=38 && (code!=39 || (code==39 && character=="'")) && code!=40) 
	{
		if (character.match(digitsOnly)&&control.val().length<8) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}
	return retorno;
}

