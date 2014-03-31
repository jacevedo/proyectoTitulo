<<<<<<< HEAD:web/javascript/asistente/scriptReservarHora.js
var direccionWeb = "";
=======
var direccionWeb = "http://sfh.crossline.cl/webServiceencriptado/";
>>>>>>> FETCH_HEAD:web/asistente/javascript/scriptReservarHora.js
var vacio = 0;
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	direccionWeb = $("#direccionWeb").val();
	$("#txtFecha").change(disponibilidad);
	$("#txtDv").blur(buscarPersona);
	$("#btnReservarHora").click(reservarHora);
	$("#txtRut").blur(validarRut);
	$("#txtNombre").blur(validarNombre);
	$("#txtAppPaterno").blur(validarAppPaterno);
	$("#txtAppMaterno").blur(validarAppMaterno);
	$("#selectDentista").blur(validarDentista);
	$("#selectHora").blur(validarHora);

	vacio = 0;
}
function validarDentista()
{
	var idDentista = $("#selectDentista").val();
	if(idDentista=="--"||idDentista==0)
	{
		$("#spanErrorDentista").html("Debe seleccionar un dentista");
		return false;
	}
	else
	{
		$("#spanErrorDentista").html("");
		return true;
	}
}
function validarHora()
{
	var idHora = $("#selectHora").val();
	if(idHora=="--"||idHora==0)
	{
		$("#spanErrorHora").html("Debe seleccionar un dentista");
		return false;
	}
	else
	{
		$("#spanErrorHora").html("");
		return true;
	}
}
function validarAppPaterno()
{
	var appPaterno = $("#txtAppPaterno").val();
	var pattern = /^[a-zA-ZñÑ]*$/;
	if(!appPaterno.match(pattern)||appPaterno.length==0)
	{
		$("#spanErrorAppPaterno").html("Debe ingresar s&oacute;lo letras");
		return false;
	}
	else
	{
		$("#spanErrorAppPaterno").html("");
		return true;
	}
}
function validarAppMaterno()
{
	var appPaterno = $("#txtAppMaterno").val();
	var pattern = /^[a-zA-ZñÑ]*$/;
	if(!appPaterno.match(pattern)||appPaterno.length==0)
	{
		$("#spanErrorAppMaterno").html("Debe ingresar s&oacute;lo letras");
		return false;
	}
	else
	{
		$("#spanErrorAppMaterno").html("");
		return true;
	}
}
function validarRut()
{
	var rut = $("#txtRut").val();
	var pattern = /\d{7}|\d{8}/;
	if(!rut.match(pattern))
	{
		$("#spanErrorRut").html("Debe ingresar s&oacute;lo d&iacute;gitos");
		return false;
	}
	else
	{
		$("#spanErrorRut").html("");
		return true;
	}
}
function validarNombre()
{
	var nombre = $("#txtNombre").val();
	if (/^([a-z ñáéíóú]{2,60})$/i.test(nombre))
	{
	    $("#spanErrorNombre").html("");
        return true;
	}
	else
	{
       	$("#spanErrorNombre").html('Debe ingresar s&oacute;lo letras y a lo m&aacute;s, dos nombres');
        return false;
    }
}
function reservarHora()
{

	var vacioInterno = vacio;
	if(vacio==1)
	{
		if(validarDentista()&validarHora())
		{
			var idPaciente = $("#idUsuario").val();
			var idOdontologo = $("#selectDentista").val();
			var fecha = $("#txtFecha").val();
			var hora = $("#selectHora").val();
			var fechaIngresar = fecha;
			var key = $("#keyPaciente").val();
			//{"indice":1,"idPaciente":3,"idOdontologo":1,"fecha":"2013-10-10","horaInicio":"12:00:00","estado":0}
			var url = direccionWeb+"ws-cita.php";
			var json = "{\"indice\":1,\"idPaciente\":"+idPaciente+",\"idOdontologo\":"+idOdontologo+",\"fecha\":\""+fechaIngresar+"\",\"horaInicio\":\""+hora+"\",\"estado\":0,\"key\":\""+key+"\"}";
			var data = {"send":encriptar(json)};


			$.post(url, data, function(jsonEncriptadoBase){
				var datos = desencriptar(jsonEncriptadoBase);
				//alert(datos);
				var obj = $.parseJSON(datos);
				var resultado = obj.resultado;
				if(resultado!=-1)
				{
					alert("Cita ingresada correctamente.");
					limpiarCampos();
				}
				else
				{
					alert("Se produjo un error, vuelva a intentarlo.");
				}
			});
		}
	}
	else if(vacioInterno==0)
	{
		if(validarRut()&validarRutDigitoVerificador()&validarNombre()&validarAppPaterno()&
			validarAppMaterno()&validarDentista()&validarHora())
		{
			var rut = $("#txtRut").val();
			var dv = $("#txtDv").val();
			var nombre = $("#txtNombre").val();
			var apellidoPaterno = $("#txtAppPaterno").val();
			var apellidoMaterno = $("#txtAppMaterno").val();
			var fechaNacimiento = $("#txtFechaNacimiento").val();
			var idOdontologo = $("#selectDentista").val();
			var fecha = $("#txtFecha").val();
			var hora = $("#selectHora").val();
			var fechaIngresar = fecha;
			var key = $("#keyPaciente").val();
			var url = direccionWeb+"ws-cita.php";
			var json = "{\"indice\":9,\"rut\":"+rut+",\"dv\":\""+dv+"\",\"nombre\":\""+nombre+"\",\"appPaterno\":\""+apellidoPaterno+"\",\"apellidoMaterno\":\""+apellidoMaterno+"\",\"fechaNacimiento\":\""+fechaNacimiento+"\",\"fechaReserva\":\""+fechaIngresar+"\",\"idOdontologo\":"+idOdontologo+",\"horaReserva\":\""+hora+"\",\"estado\":0,\"key\":\""+key+"\"}";
			var data = {"send":encriptar(json)};

			$.post(url, data, function(jsonEncriptadoBase){
				var datos = desencriptar(jsonEncriptadoBase);
				var objeto = $.parseJSON(datos);
				var respuesta = objeto.resultado;
				if(respuesta == "Hubo un error al insertar la persona")
				{
					alert("Se produjo un error, vuelva a intentarlo.");				
				}
				else if(respuesta == "Hubo un error al insertar al paciente")
				{
					alert("Se produjo un error, vuelva a intentarlo.");	
				}
				else if(respuesta!=-1)
				{
					alert("Cita insertada correctamente.");
				}
				else
				{
					alert("Se produjo un error, vuelva a intentarlo.");
				}
				limpiarCampos();
			});

		}
		
	}
	
	
		
}
function limpiarCampos()
{
	$("#idUsuario").val("");
	$("#selectDentista").val("");
	$("#txtFecha").val("");
	$("#selectHora").val("");
	$("#txtNombre").val("");
	$("#txtAppPaterno").val("");
	$("#txtAppMaterno").val("");
	$("#txtFechaNacimiento").val("");
	$("txtRut").val("")
	$("#txtDv").val("");
	vacio=0;
}
function validarDv(T)
{
	var M=0,S=1;for(;T;T=Math.floor(T/10))
S=(S+T%10*(9-M++%6))%11;return S?S-1:'k';
}
function validarRutDigitoVerificador()
{
	var rutAValidar = $("#txtRut").val();
	var digitoVerificador = $("#txtDv").val();
	var digitoDevuelto  = validarDv(rutAValidar);
	if(digitoDevuelto==digitoVerificador)
	{
		$("#spanErrorRut").html("");
		return true;
	}
	else
	{
		$("#spanErrorRut").html("Debe ingresar un rut v&aacute;lido");
		return false;
	}
}
function buscarPersona()
{
	var rutAValidar = $("#txtRut").val();
	var digitoVerificador = $("#txtDv").val();
	var digitoDevuelto  = validarDv(rutAValidar);
	if(digitoDevuelto==digitoVerificador)
	{
		var url = direccionWeb+"ws-admin-usuario-sig.php";
		if($("txtRut").text()!=""||$("#txtDv").text()=="")
		{
			var rut = $("#txtRut").val();
			var dv  = $("#txtDv").val();
			var key = $("#keyPaciente").val();
			var json = "{\"indice\":5,\"rut\":"+rut+",\"dv\":\""+dv+"\",\"key\":\""+key+"\"}";
			var data = {"send":encriptar(json)};

			$.post(url, data, function(jsonEncriptadoBase)
			{
				var datos = desencriptar(jsonEncriptadoBase);
				var objeto = $.parseJSON(datos);
				var datos = objeto.buscarPacienteRut;
				if(datos!="")
				{
					var persona = datos[0];
					var nombre = persona.nombre;
					var appPaterno = persona.apellidoPaterno;
					var appMaterno = persona.apellidoMaterno;
					var fechaNacimiento = persona.fechaNacimiento;
					var idPersona = persona.idPaciente;
					$("#txtNombre").val(nombre);
					$("#txtAppPaterno").val(appPaterno);
					$("#txtAppMaterno").val(appMaterno);
					$("#txtFechaNacimiento").val(fechaNacimiento);
					$("#idUsuario").val(idPersona);
					vacio=1;
				}
				else
				{
					$("#txtNombre").val("");
					$("#txtAppPaterno").val("");
					$("#txtAppMaterno").val("");
					$("#txtFechaNacimiento").val("");
					$("#idUsuario").val("");
					vacio = 0;
				}
			});

		}	
		else
		{
			alert("Debe ingresar un rut v\u00e1lido.");
		}	
		$("#spanErrorRut").html("");
		return true;
	}
	else
	{
		$("#spanErrorRut").html("Debe ingresar un rut v&aacute;lido");
		return false;
	}
	
}
function disponibilidad()
{
	var fecha = $("#txtFecha").val() + " 13:13:00";
	var ingresar = direccionWeb+"ws-horario.php";
	var key = $("#keyPaciente").val();
	var json = "{\"indice\":1,\"fecha\":\""+fecha+"\",\"key\":\""+key+"\"}";
	var data = {"send":encriptar(json)};

	$.post(ingresar, data, function(jsonEncriptadoBase){
		var datos = desencriptar(jsonEncriptadoBase);
		var obj = $.parseJSON(datos);
		horarios = obj.listaHorarios;
		
		if(horarios!=null)
		{
			var select = '';
			select = select + "<option value='0'>Seleccione un Dentista</option>";

			$.each(horarios,function()
			{
				select = select + "<option value="+this.idOdontologo+" >"+this.nomOdontologo+"</option>";
			});
			$("#selectDentista").html(select);	
		}
		else
		{
			alert("No se encontraron dentistas.");
			$("#selectDentista").html("<option>--</option>");
		}
		
	});
	$("#selectDentista").change(cargarHoras);
}

function cargarHoras()
{
	var idDent = document.getElementById("selectDentista").value;
	var select = '';
	select = select + "<option value='0'>Seleccione una Hora</option>";

	$.each(horarios,function()
	{
		if(this.idOdontologo == idDent)
		{
			var arregloDatos = this.numKeys.split(",");
			var objetosHoras = this.horario;
			for(var i = 0; i < arregloDatos.length; i++)
			{
				if(arregloDatos[i]!="")
				{
					var hora ="hora-"+arregloDatos[i];
					select = select + "<option value="+objetosHoras[hora]+">"+objetosHoras[hora]+"</option>";
				}
			}
			$("#selectHora").html(select);
		}
	});
}

