var direccionWeb = "";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	direccionWeb = $("#direccionWeb").val();
	cargarRegiones();
	$("#region").change(cambiarComuna);
	$("#btnCrearCuenta").click(guardarPersona);
	$("#txtNombre").blur(ValidarNombre);
	$("#txtAppPaterno").blur(validarApellidoPaterno);
	$("#txtAppMaterno").blur(validarApellidoMaterno);
	$("#txtRut").blur(validarPrimeraParteRut);
	$("#txtDv").blur(validarSegundaParteRut);
	$("#txtFono").blur(validarTelefonoFijo);
	$("#txtCelular").blur(validarCelular);
	$("#txtMail").blur(validarMail);
	$("#txtContrasena").blur(validarPass);
}
function validarPass()
{
	var pass = $("#txtContrasena").val();
	if(pass.length<4)
	{
		$("#errorPass").html("La contrase&ntide;a debe tener al menos 4 caracteres");
		return false;
	}
	else
	{
		$("#errorPass").html("");
		return true;
	}
}
function validarMail()
{
	var mail = $("#txtMail").val();
	var pattern = /^[a-zA-Z0-9._%+-]+@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,4}$/;
	if(!mail.match(pattern))
	{
		$("#errorMail").html("Debe ingresar un email v&aacute;lido");
		return false;
	}
	else
	{
		$("#errorMail").html("");
		return true;
	}
}
function validarCelular()
{
	var telefonoFijo = $("#txtCelular").val();
	var pattern = /0{0,2}([\+]?[\d]{1,3} ?)?([\(]([\d]{2,3})[)] ?)?[0-9][0-9 \-]{6,}( ?([xX]|([eE]xt[\.]?)) ?([\d]{1,5}))?/;
	if(!telefonoFijo.match(pattern))
	{
		$("#errorFonoCell").html("Debe ingresar un n&uacute;mero de tel&eacute;fono v&aacute;lido");
		return false;
	}
	else
	{
		$("#errorFonoCell").html("");
		return true;
	}
}
function validarTelefonoFijo()
{
	var telefonoFijo = $("#txtFono").val();
	var pattern = /0{0,2}([\+]?[\d]{1,3} ?)?([\(]([\d]{2,3})[)] ?)?[0-9][0-9 \-]{6,}( ?([xX]|([eE]xt[\.]?)) ?([\d]{1,5}))?/;
	if(!telefonoFijo.match(pattern))
	{
		$("#errorFonoFijo").html("Debe ingresar un n&uacute;mero de tel&eacute;fono v&aacute;lido");
		return false;
	}
	else
	{
		$("#errorFonoFijo").html("");
		return true;
	}
}
function validarPrimeraParteRut()
{
	var primeraParteRut = $("#txtRut").val();
	var pattern = /\d{7}|\d{8}/;
	if(!primeraParteRut.match(pattern))
	{
		$("#errorRut").html("Debe ingresar s&oacute;lo d&iacute;gitos");
		return false;
	}
	else
	{
		$("#errorRut").html("");
		return true;
	}
}
function dv(T)
{
	var M=0,S=1;for(;T;T=Math.floor(T/10))
S=(S+T%10*(9-M++%6))%11;return S?S-1:'k';
}

function validarSegundaParteRut()
{
	var segundaParteRut = $("#txtDv").val();
	var primeraParteRut = $("#txtRut").val();
	var pattern = /\d{1}|[kK]/;
	if(!segundaParteRut.match(pattern))
	{
		$("#errorRut").html("Debe ingresar s&oacute;lo d&iacute;gitos o una k");
		return false;
	}
	else
	{
		$("#errorRut").html("");

		if(dv(primeraParteRut)!=segundaParteRut)
		{
			$("#errorRut").html("Rut no v&aacute;lido");
			return false;
		}
		else
		{
			$("#errorRut").html("");
			return true;
		}
	}
}

function validarApellidoMaterno()
{
	var appPaterno = $("#txtAppMaterno").val();
	var pattern = /^[a-zA-ZñÑ]*$/;
	if(!appPaterno.match(pattern)||appPaterno.length==0)
	{
		$("#errorAppMaterno").html("Debe ingresar s&oacute;lo letras");
		return false;
	}
	else
	{
		$("#errorAppMaterno").html("");
		return true;
	}
}
function validarApellidoPaterno()
{
	var appPaterno = $("#txtAppPaterno").val();
	var pattern = /^[a-zA-ZñÑ]*$/;
	if(!appPaterno.match(pattern)||appPaterno.length==0)
	{
		$("#errorAppPaterno").html("Debe ingresar s&oacute;lo letras");
		return false;
	}
	else
	{
		$("#errorAppPaterno").html("");
		return true;
	}
}
function ValidarNombre() 
{
	var nombre = $("#txtNombre").val();
	if (/^([a-z ñáéíóú]{2,60})$/i.test(nombre))
	{
	      $("#errorNombre").html("");
               return true;
	}
	else
	{
       $("#errorNombre").html('Debe ingresar s&oacute;lo letras y a lo m&aacute;s, dos nombres');
           return false;
    }
}

function cargarRegiones()
{
	var regiones = direccionWeb+"ws-add-usuario.php";
	var key = $("#keyPaciente").val();
	var stringJson = "{\"indice\":3,\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};

	$.post(regiones,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var obj = $.parseJSON(datos);
		var select = '';
		select = select + "<option value='0'>Seleccione una Regi&oacute;n</option>";
		$.each(obj.listaRegiones,function()
		{
			select = select + "<option value="+this.idRegion+">"+this.nombreRegion+"</option>";
		});
		$("#region").html(select);
	});
}

function cambiarComuna()
{
	var idRegion = document.getElementById("region").value;
	var key = $("#keyPaciente").val();
	var comunas = direccionWeb+"ws-add-usuario.php";
	var stringJson = "{\"indice\":4,\"idRegion\":\""+idRegion+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(stringJson)};

	$.post(comunas,data,function(jsonEncriptado)
	{
		var datos = desencriptar(jsonEncriptado);
		var obj = $.parseJSON(datos);
		$("#comuna").find('option').remove().end();
		
		var select = '';
		select = select + "<option value='0'>Seleccione una Comuna</option>";

		$.each(obj.listaComuna,function()
		{
			select = select + "<option value="+this.idComuna+">"+this.nombreComuna+"</option>";
		});
		$("#comuna").html(select);
	});
}

function guardarPersona()
{
	if(ValidarNombre() & validarApellidoPaterno() & validarApellidoMaterno() & 
	validarPrimeraParteRut() & validarSegundaParteRut() & (validarTelefonoFijo() || 
	validarCelular()) & validarMail() & validarPass())
	{
		//PERSONA
		var nombre = $("#txtNombre").val();
		var appPaterno = $("#txtAppPaterno").val();
		var appMaterno = $("#txtAppMaterno").val();
		var rut = $("#txtRut").val();
		var dv = $("#txtDv").val();
		var fechaNac = $("#txtFechaNacimiento").val();

		//DATOS CONTACTO
		var comuna = $("#comuna").val();
		var fonoFijo = $("#txtFono").val();
		var fonoCel = $("#txtCelular").val();
		var direccion = $("#txtDireccion").val(); 
		var mail = $("#txtMail").val();
		var fechaIng = new Date();
		var dd = fechaIng.getDate();
		var mm = fechaIng.getMonth()+1;
		var yyyy = fechaIng.getFullYear();
		if(dd<10){dd='0'+dd} if(mm<10){mm='0'+mm} fechaIng = yyyy+'/'+mm+'/'+dd;

		//PASS
		var pass = $("#txtContrasena").val();
		var fechaCad = new Date();
		var dd = fechaCad.getDate();
		var mm = fechaCad.getMonth()+1;
		var yyyy = fechaCad.getFullYear();
		if(dd<10){dd='0'+dd} if(mm<10){mm='0'+mm}
		//fechaCad = yyyy+'/'+mm+'/'+dd;
		fechaCad = "2014"+'/'+mm+'/'+dd

		var key = $("#keyPaciente").val();
		var persona = direccionWeb+"ws-add-usuario.php";
		var stringJson = "{\"indice\":10,\"idPerfil\":4,\"rut\":\""+rut+"\",\"dv\":\""+dv+"\",\"nombre\":\""+nombre+"\",\"appPaterno\":\""+appPaterno+"\",\"appMaterno\":\""+appMaterno+"\",\"fechaNac\":\""+fechaNac+"\",\"pass\":\""+pass+"\",\"idComuna\":\""+comuna+"\",\"fonoFijo\":\""+fonoFijo+"\",\"celular\":\""+fonoCel+"\",\"direccion\":\""+direccion+"\",\"mail\":\""+mail+"\",\"fechaIngreso\":\""+fechaIng+"\",\"key\":\""+key+"\"}";
		var data = {"send":encriptar(stringJson)};

		$.post(persona,data,function(jsonEncriptado)
		{
			var datos = desencriptar(jsonEncriptado);
			var obj = $.parseJSON(datos);
			var resultado = obj.resultado;
			var result = resultado.resultado;
			if(result == "Todos los datos fueron insertados")
			{
				alert("Cuenta creada correctamente.");
				window.location.href = "/web/asistente/reservarHoras.php";
			}
			else
			{
				alert("Se produjo un error, vuelva a intentarlo.");
			}
		});
	}
}