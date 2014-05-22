//var direccionWeb = "http://sfh.crossline.cl/webServiceencriptado/";
var direccionWeb = "";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	direccionWeb = $("#direccionWeb").val();
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
		$("#validacionUsuario").html("Debe ingresar rut sin gui&oacute;n ni d&iacute;gito verificador");
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
	var validador = "";
	var validador2 = "";

	if(validarUsuario()&validarPass())
	{
		var usuario = $("#txtUsuario").val();
		var contrasena = $("#txtPass").val();
		var ingresar = direccionWeb+"ws-login.php";
		var json = "{\"indice\":2,\"usuario\":"+usuario+",\"pass\":\""+contrasena+"\"}";
		var data = {"send":encriptar(json)};

		$.post(ingresar, data, function(jsonEncriptadoBase){
			var datos = desencriptar(jsonEncriptadoBase);
			var datosObjeto = $.parseJSON(datos);
			var obj = datosObjeto.resultado;
			var codigo = obj.codAcceso;
			var key = obj.key;
			var idPaciente = obj.idPersona;
			var nombre = obj.nombre;
			var appPaterno = obj.appPaterno;
			if(codigo == 707 || codigo == 706 || codigo == 705)
			{
				validador = "true";

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

		        var field5 = $('<input></input>');
		        field5.attr("type", "hidden");
		        field5.attr("name", "codigo");
		        field5.attr("value", codigo);
		        form.append(field5);

			    $(document.body).append(form);
			    form.submit();
			}
			else
			{
				validador = "false";

				var ingresar2 = direccionWeb+"ws-login.php";
				var json2 = "{\"indice\":1,\"usuario\":"+usuario+",\"pass\":\""+contrasena+"\"}";
				var data2 = {"send":encriptar(json2)};

				$.post(ingresar2, data2, function(jsonEncriptadoBase){
					var datos2 = desencriptar(jsonEncriptadoBase);
					var obj2 = $.parseJSON(datos2);
					var resultado = obj2.resultado;
					if(resultado == "")
					{
						validador2 = "false";
						if(validador == "false" && validador2 == "false")
							alert("Usuario y/o contrase\u00f1a err\u00f3neo!");
					}
					else
					{
						var codigo2 = resultado.codAcceso;
						var key2 = resultado.key;
						var idPaciente2 = resultado.idPaciente;
						var nomPaciente2 = resultado.nombre;
						var appPaciente2 = resultado.appPaterno;
						if(codigo2 == 704)
						{
							validador2 = "true";

						    var form = $('<form></form>');
						    form.attr("method", "post");
						    form.attr("action", "login.php");

					        var field = $('<input></input>');
					        field.attr("type", "hidden");
					        field.attr("name", "key");
					        field.attr("value", key2);
					        form.append(field);

					        var field1 = $('<input></input>');
					        field1.attr("type", "hidden");
					        field1.attr("name", "user");
					        field1.attr("value", usuario);
					        form.append(field1);

					        var field2 = $('<input></input>');
					        field2.attr("type", "hidden");
					        field2.attr("name", "pacienteId");
					        field2.attr("value", idPaciente2);
					        form.append(field2);

					        var field3 = $('<input></input>');
					        field3.attr("type", "hidden");
					        field3.attr("name", "nombre");
					        field3.attr("value", nomPaciente2);
					        form.append(field3);

					        var field4 = $('<input></input>');
					        field4.attr("type", "hidden");
					        field4.attr("name", "appPaterno");
					        field4.attr("value", appPaciente2);
					        form.append(field4);

					        var field5 = $('<input></input>');
					        field5.attr("type", "hidden");
					        field5.attr("name", "codigo");
					        field5.attr("value", codigo2);
					        form.append(field5);

						    $(document.body).append(form);
						    form.submit();
						}
					}
				});
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

