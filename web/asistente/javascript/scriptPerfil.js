var direccionWeb = "http://sfh.crossline.cl/webServiceencriptado/";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	cargarPerfil();
	$("#btnCrearCuenta").click(accionBoton);
	
}
function validarMail()
{
	var mail = $("#txtEmail").val();
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
	
	var telefonoFijo = $("#txtFonoCelular").val();
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
	var telefonoFijo = $("#txtFonoFijo").val();
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
	var appPaterno = $("#txtApellidoMaterno").val();
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
	var appPaterno = $("#txtApellidoPaterno").val();
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
function validarNombre() 
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
function cargarPerfil()
{
	var id = $("#idPaciente").val();
	var key = $("#keyPaciente").val();
	var ingresar = direccionWeb+"ws-add-usuario.php";
	var json = "{\"indice\":2,\"rut\":"+id+",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(json)};

	$.post(ingresar, data, function(jsonEncriptadoBase)
	{
		var datos = desencriptar(jsonEncriptadoBase);
		var obj = $.parseJSON(datos);
		var persona = obj.datosPersona;
		var contacto = obj.datosContacto;
		var pass = obj.datosPass;
		var comu = obj.datoComuna;
		var reg = obj.datoRegion;

		var tabla = "";

		if(contacto == "No hay datos de contacto")
		{
			//PERSONA
			$("#tdNumero").html(persona.idPersona);
			$("#tdPerfil").html(persona.idPerfil); //Invisible
			$("#tdNombre").html(persona.nombre);
			$("#tdApellidoPaterno").html(persona.apellidoPaterno);
			$("#tdApellidoMaterno").html(persona.apellidoMaterno);
			$("#tdRut").html(persona.rut+"-"+persona.dv);
			$("#tdFechaNacimiento").html(persona.fechaNacimiento);

			//DATOS CONTACTO
			$("#tdRegion").html("----");
			$("#tdDireccion").html("----");
			$("#tdComuna").html("----");
			$("#tdFonoFijo").html("----");
			$("#tdFonoCelular").html("----");
			$("#tdEmail").html("----");
			$("#tdFechaIngreso").html("----"); //Invisible
		}
		else
		{
			//PERSONA
			$("#tdNumero").html(persona.idPersona);
			$("#tdPerfil").html(persona.idPerfil); //Invisible
			$("#tdNombre").html(persona.nombre);
			$("#tdApellidoPaterno").html(persona.apellidoPaterno);
			$("#tdApellidoMaterno").html(persona.apellidoMaterno);
			$("#tdRut").html(persona.rut+"-"+persona.dv);
			$("#tdFechaNacimiento").html(persona.fechaNacimiento);

			//DATOS CONTACTO
			$("#tdDireccion").html(contacto.direccion);
			$("#tdidRegion").html(comu.idRegion); // Invisible
			$("#tdidComuna").html(comu.idComuna); // Invisible
			$("#tdRegion").html(reg.nombreRegion);
			$("#tdComuna").html(comu.nombreComuna);
			$("#tdFonoFijo").html(contacto.fonoFijo);
			$("#tdFonoCelular").html(contacto.fonoCelular);
			$("#tdEmail").html(contacto.mail);
			$("#tdFechaIngreso").html(contacto.fechaIngreso);//Invisible
		}
		
	});
}

function accionBoton()
{
	if($(this).html()=="Modificar")
	{
		modificarCuenta();
	}
	else if(validarNombre() & validarApellidoPaterno() & validarApellidoMaterno() & 
	validarPrimeraParteRut() & validarSegundaParteRut() & (validarCelular() || 
	validarTelefonoFijo() ) & validarMail())
	{
		guardarModificacionCuenta();
	}
}

function modificarCuenta()
{
	//PERSONA
	var numero = $("#tdNumero").html();
	var perfil = $("#tdPerfil").html(); //Invisible
	var nombre = $("#tdNombre").html();
	var apellidoPaterno = $("#tdApellidoPaterno").html();
	var apellidoMaterno = $("#tdApellidoMaterno").html();
	var ruts = $("#tdRut").html().split('-');
	var fechaNac = $("#tdFechaNacimiento").html();

	//DATOS CONTACTO
	var direccion = $("#tdDireccion").html();
	var comuna = $("#tdComuna").html();
	var idRegion = $("#tdidRegion").html(); // Invisible
	var idComuna = $("#tdidComuna").html(); // Invisible
	var fonoFijo = $("#tdFonoFijo").html();
	var fonoCelu = $("#tdFonoCelular").html();
	var email = $("#tdEmail").html();
	var fechaIng = $("#tdFechaIngreso").html(); //Invisible

	//PERSONA
	$("#tdNumero").html("<input type='text'class='form-control'  id='txtNumero'/>");
	$("#tdNombre").html("<input type='text' id='txtNombre'/><span id='errorNombre' class='error' ></span>");
	$("#tdApellidoPaterno").html("<input type='text' id='txtApellidoPaterno'/><span id='errorAppPaterno' class='error'></span>");
	$("#tdApellidoMaterno").html("<input type='text' id='txtApellidoMaterno'/><span id='errorAppMaterno' class='error'></span>");
	$("#tdRut").html("<input type='text' id='txtRut' class='textoRutMod'/> <input type='text' id='txtDv' class='textoDvMod'/><span id='errorRut' class='error'></span>");
	$("#tdFechaNacimiento").html("<input type='date' id='txtFechaNacimiento'/>");

	//DATOS CONTACTO
	$("#tdDireccion").html("<input type='text' id='txtDireccion'/>");
	$("#tdRegion").parent().parent().children().removeClass("regionEscondida");
	$("#tdRegion").html("<select class='textoSelect' id='region'></select>");
	$("#tdComuna").html("<select class='textoSelect' id='comuna'></select>");
	
	$("#tdFonoFijo").html("<input type='text' id='txtFonoFijo'/><span id='errorFonoFijo' class='error'></span>");
	$("#tdFonoCelular").html("<input type='text' id='txtFonoCelular'/><span id='errorFonoCell' class='error'></span>");
	$("#tdEmail").html("<input type='text' id='txtEmail'/><span id='errorMail' class='error'>");

	//PERSONA
	$("#txtNumero").val(numero);
	$("#txtNombre").val(nombre);
	$("#txtApellidoPaterno").val(apellidoPaterno);
	$("#txtApellidoMaterno").val(apellidoMaterno);
	$("#txtRut").val(ruts[0]);
	$("#txtDv").val(ruts[1]);
	$("#txtFechaNacimiento").val(fechaNac);

	//DATOS CONTACTO
	$("#txtDireccion").val(direccion);
	$("#txtComuna").val(comuna);
	$("#txtFonoFijo").val(fonoFijo);
	$("#txtFonoCelular").val(fonoCelu);
	$("#txtEmail").val(email);

	$("#btnCrearCuenta").html("Guardar Cambios");
	cargarRegiones(idRegion);
	cargarComunas(idComuna, idRegion);
	$("#tdRegion").on("change","#region",cambiarComuna);
	
	$("#tdNombre").on("blur","#txtNombre",validarNombre);
	$("#tdApellidoPaterno").on("blur","#txtApellidoPaterno",validarApellidoPaterno);
	$("#tdApellidoMaterno").on("blur","#txtApellidoMaterno",validarApellidoMaterno);
	$("#tdRut").on("blur","#txtRut",validarPrimeraParteRut);
	$("#tdRut").on("blur","#txtDv",validarSegundaParteRut);
	$("#tdFonoFijo").on("blur","#txtFonoFijo",validarTelefonoFijo);
	$("#tdFonoCelular").on("blur","#txtFonoCelular",validarCelular);
	$("#tdEmail").on("blur","#txtEmail",validarMail);
}
function validarTexto()
{
	if (!e) var e = window.event
	if (e.keyCode) code = e.keyCode;
	else if (e.which) code = e.which;
	var character = String.fromCharCode(code);
	var soloLetras = /[A-Za-z]/g;

	var retorno=true;

	if (code==27) { this.blur(); return false; }

	var control = $("#txtUsuario");

	if (!e.ctrlKey && code!=9 && code!=8 && code!=36 && code!=37 && code!=38 && (code!=39 || (code==39 && character=="'")) && code!=40) 
	{
		if (character.match(soloLetras)&&control.val().length<8) 
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
function guardarModificacionCuenta()
{
	//PERSONA
	var numero = $("#txtNumero").val();
	var perfil = $("#tdPerfil").html(); //Invisible
	var nombre = $("#txtNombre").val();
	var apellidoPaterno = $("#txtApellidoPaterno").val();
	var apellidoMaterno = $("#txtApellidoMaterno").val();
	var ruts = $("#txtRut").val();
	var dv = $("#txtDv").val();
	var fechaNac = $("#txtFechaNacimiento").val();

	//DATOS CONTACTO
	var direccion = $("#txtDireccion").val();
	var comuna = $("#comuna").val();
	var fonoFijo = $("#txtFonoFijo").val();
	var fonoCelu = $("#txtFonoCelular").val();
	var email = $("#txtEmail").val();
	var fechaIng = $("#tdFechaIngreso").html(); //Invisible

	if(fechaIng == "----")
	{
		fechaIng = new Date();
		var dd = fechaIng.getDate();
		var mm = fechaIng.getMonth()+1;
		var yyyy = fechaIng.getFullYear();
		if(dd<10){dd='0'+dd} if(mm<10){mm='0'+mm} fechaIng = yyyy+'/'+mm+'/'+dd;
	}

	var usuarioModificado = direccionWeb+"ws-add-usuario.php";
	var key = $("#keyPaciente").val();
	var json = "{\"indice\":5,\"idPersona\":"+numero+",\"idPerfil\":"+perfil+",\"rut\":"+ruts+",\"dv\":\""+dv+"\",\"nombre\": \""+nombre+"\",\"appPaterno\":\""+apellidoPaterno+"\",\"appMaterno\": \""+apellidoMaterno+"\",\"fechaNac\": \""+fechaNac+"\",\"idComuna\":"+comuna+",\"fonoFijo\":\""+fonoFijo+"\",\"celular\":\""+fonoCelu+"\",\"direccion\":\""+direccion+"\",\"mail\":\""+email+"\",\"fechaIngreso\":\""+fechaIng+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(json)};

	$.post(usuarioModificado, data, function(jsonEncriptadoBase)
	{
		var datos = desencriptar(jsonEncriptadoBase);
		var obj = $.parseJSON(datos);
		var persona = obj.resultadoPersona;
		var contacto = obj.resultadoDatos;
		var mensaje = " ";
		var mensaje2 = " ";

		if(persona == "Error al modificar persona" && contacto == "Error al modificar datos contacto")
		{
			mensaje = "Se produjo un error, vuelva a intentarlo.";
			alert(mensaje);
		}
		else
		{
			if(persona == "Modificado") { mensaje = "Datos personales modificados correctamente."; }
			else { mensaje = "Datos personales NO fueron modificados."; }

			if(contacto == "Modificado") { mensaje2 = "\nDatos de contacto modificados correctamente."; }
			else { mensaje2 = "\nDatos de contacto NO fueron modificados."; }
			
			alert(mensaje+" "+mensaje2);
			location.reload();
		}
	});
}

function cargarRegiones()
{
	var regiones = direccionWeb+"ws-add-usuario.php";
	var key = $("#keyPaciente").val();
	var json = "{\"indice\":3,\"key\":\""+key+"\"}";
	var data = {"send":encriptar(json)};

	$.post(regiones, data, function(jsonEncriptadoBase)
	{
		var datos = desencriptar(jsonEncriptadoBase);
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

function cargarRegiones(RegionesID)
{
	var regiones = direccionWeb+"ws-add-usuario.php";
	var key = $("#keyPaciente").val();
	var json = "{\"indice\":3,\"key\":\""+key+"\"}";
	var data = {"send":encriptar(json)};

	$.post(regiones, data, function(jsonEncriptadoBase)
	{
		var datos = desencriptar(jsonEncriptadoBase);
		var obj = $.parseJSON(datos);
		var select = '';
		select = select + "<option value='0'>Seleccione una Regi&oacute;n</option>";

		$.each(obj.listaRegiones,function()
		{
			if(this.idRegion == RegionesID)
			{
				select = select + "<option value="+this.idRegion+" selected='selected'>"+this.nombreRegion+"</option>";
			}
			else
			{
				select = select + "<option value="+this.idRegion+">"+this.nombreRegion+"</option>";
			}
		});
		$("#region").html(select);
	});
}

function cargarComunas(ComunasID, RegionesID)
{
	var comunas = direccionWeb+"ws-add-usuario.php";
	var key = $("#keyPaciente").val();
	var json = "{\"indice\":4,\"idRegion\":\""+RegionesID+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(json)};

	$.post(comunas, data, function(jsonEncriptadoBase)
	{
		var datos = desencriptar(jsonEncriptadoBase);
		var obj = $.parseJSON(datos);
		var select = '';
		select = select + "<option value='0'>Seleccione una Comuna</option>";

		$.each(obj.listaComuna,function()
		{
			if(this.idComuna == ComunasID)
			{
				select = select + "<option value="+this.idComuna+" selected='selected'>"+this.nombreComuna+"</option>";
			}
			else
			{
				select = select + "<option value="+this.idComuna+">"+this.nombreComuna+"</option>";
			}
		});
		$("#comuna").html(select);
	});
}

function cambiarComuna()
{
	var idRegion = document.getElementById("region").value;

	var comunas = direccionWeb+"ws-add-usuario.php";
	var key = $("#keyPaciente").val();
	var json = "{\"indice\":4,\"idRegion\":\""+idRegion+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(json)};

	$.post(comunas, data, function(jsonEncriptadoBase)
	{
		var datos = desencriptar(jsonEncriptadoBase);
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