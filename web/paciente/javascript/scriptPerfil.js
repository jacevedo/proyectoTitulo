var direccionWeb = "http://172.16.28.138/sfhwebservice/webService/";
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
		$("#errorMail").html("Debe ingresar un numero mail valido");
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
		$("#errorFonoCell").html("Debe ingresar un numero de telefono valido");
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
		$("#errorFonoFijo").html("Debe ingresar un numero de telefono valido");
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
		$("#errorRut").html("Debe ingresar solo digitos");
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
		$("#errorRut").html("Debe ingresar un solo digitos o una k");
		return false;
	}
	else
	{
		$("#errorRut").html("");

		if(dv(primeraParteRut)!=segundaParteRut)
		{
			$("#errorRut").html("Rut no valido");
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
		$("#errorAppMaterno").html("Debe ingresar solo letras");
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
		$("#errorAppPaterno").html("Debe ingresar solo letras");
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
       $("#errorNombre").html('Debe ingresar solo letras y a lo mas, 2 nombres');
           return false;
    }
}
function cargarPerfil()
{
	var id = $("#idPaciente").val();
	var key = $("#keyPaciente").val();

	var ingresar = direccionWeb+"ws-add-usuario.php";
	var data = {"send":"{\"indice\":2,\"rut\":"+id+"}"};

	$.post(ingresar, data, function(datos)
	{
		var obj = $.parseJSON(datos);
		var persona = obj.datosPersona;
		var contacto = obj.datosContacto;
		var pass = obj.datosPass;
		var comu = obj.datoComuna;

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
	if($(this).html()=="Modificar Cuenta")
	{
		modificarCuenta();
	}
	else
	{
		if(validarNombre()&validarApellidoPaterno()&validarApellidoMaterno()&validarPrimeraParteRut()&validarSegundaParteRut()
			&(validarCelular() ||validarTelefonoFijo() )&validarMail())
		{
			guardarModificacionCuenta();
		}
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
	$("#tdNumero").html("<input type='text' id='txtNumero'/>");
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
	$("#tdComuna").on("change","#region",cambiarComuna);
	
	$("#tdNombre").on("blur","#txtNombre",validarNombre);
	$("#tdApellidoPaterno").on("blur","#txtApellidoPaterno",validarApellidoPaterno);
	$("#tdApellidoMaterno").on("blur","#txtApellidoMaterno",validarApellidoMaterno);
	$("#tdRut").on("blur","#txtRut",validarPrimeraParteRut);
	$("#tdRut").on("blur","#txtDv",validarSegundaParteRut);
	$("#tdFonoFijo").on("blur","#txtFonoFijo",validarTelefonoFijo);
	$("#tdFonoCelular").on("blur","#txtFonoCelular",validarCelular);
	$("#tdEmail").on("blur","#txtEmail",validarMail);
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
	var data = {"send":"{\"indice\":5,\"idPersona\":\""+numero+"\",\"idPerfil\":\""+perfil+"\",\"rut\":\""+ruts+"\",\"dv\":\""+dv+"\",\"nombre\": \""+nombre+"\",\"appPaterno\":\""+apellidoPaterno+"\",\"appMaterno\": \""+apellidoMaterno+"\",\"fechaNac\": \""+fechaNac+"\",\"idComuna\":\""+comuna+"\",\"fonoFijo\":\""+fonoFijo+"\",\"celular\":\""+fonoCelu+"\",\"direccion\":\""+direccion+"\",\"mail\":\""+email+"\",\"fechaIngreso\":\""+fechaIng+"\"}"}

	$.post(usuarioModificado,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		var persona = obj.resultadoPersona;
		var contacto = obj.resultadoDatos;

		if(persona == "Modificado" ||  contacto == "Modificado")
		{
			alert("Su perfil fue modificado correctamente");
			location.reload();
		}
		else
		{
			alert("Se produjo un error, vuelva a intentarlo")
		}
	});
}

function cargarRegiones()
{
	var regiones = direccionWeb+"ws-add-usuario.php";
	var data = {"send":"{\"indice\":3}"};

	$.post(regiones,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		var select = '';
		select = select + "<option value='0'>Seleccione una Region</option>";

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
	var data = {"send":"{\"indice\":3}"};

	$.post(regiones,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		var select = '';
		select = select + "<option value='0'>Seleccione una Region</option>";

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
	var data = {"send":"{\"indice\":4,\"idRegion\":\""+RegionesID+"\"}"};

	$.post(comunas,data,function(datos)
	{
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
	var data = {"send":"{\"indice\":4,\"idRegion\":\""+idRegion+"\"}"};

	$.post(comunas,data,function(datos){
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