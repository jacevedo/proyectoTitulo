var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	$("#btnCrearCuenta").click(guardarPersona);
}

function guardarPersona()
{
	// Persona: nombre, apellido paterno, apellido materno, rut, dv, fecha nacimiento, id_perfil(*) => id_persona
	// Datos Contacto: comuna, fonoFijo, fonoCel, direccion, mail, fecha ingreso(*), id_persona
	// Pass: pass, fecha caducidad(*), id_persona (*)
	// Paciente: fecha ingreso(*), habilitado(*), id_persona(*) => id_paciente

	var nombre = $("#txtNombre").val();
	var appPaterno = $("#txtAppPaterno").val();
	var appMaterno = $("#txtAppMaterno").val();
	var rut = $("#txtRut").val();
	var dv = $("#txtDv").val();
	var fechaNac = $("#txtFechaNacimiento").val();

	var comuna = $("#txtDireccion").val();
	var fonoFijo = $("#comuna").val();
	var fonoCel = $("#txtFono").val();
	var direccion = $("#txtCelular").val();
	var mail = $("#txtMail").val();
	var fechaIng = new Date();

	var dd = fechaIng.getDate();
	var mm = fechaIng.getMonth()+1;
	var yyyy = fechaIng.getFullYear();
	if(dd<10){dd='0'+dd} if(mm<10){mm='0'+mm} fechaIng = yyyy+'/'+mm+'/'+dd;

	var pass = $("#txtContrasena").val();

	var fechaCad = new Date();

	var dd = fechaCad.getDate();
	var mm = fechaCad.getMonth()+1;
	var yyyy = fechaCad.getFullYear();
	if(dd<10){dd='0'+dd} if(mm<10){mm='0'+mm} fechaCad = yyyy+'/'+mm+'/'+dd;

	var persona = direccionWeb+"ws-admin-usuario.php";
	var data = {"send":"{\"indice\":1,\"idPerfil\":4,\"rut\":\""+rut+"\",\"dv\":\""+dv+"\",\"nombre\":\""+nombre+"\",\"appPaterno\":\""+appPaterno+"\",\"appMaterno\":\""+appMaterno+"\",\"fechaNac\":\""+fechaNac+"\"}"};

	$.post(persona,data,function(datos){
		var obj = $.parseJSON(datos);
		var idPersona = obj.idPersonaInsertada;

		if(idPersona != -1)
		{
			//alert("La persona fue insertada.");
			var contacto = direccionWeb+"ws-pass-datos.php";
			var data = {"send":"{\"indice\":4,\"idPersona\":\""+idPersona+"\",\"idComuna\":\""+comuna+"\",\"fonoFijo\":\""+fonoFijo+"\",\"fonoCelular\":\""+fonoCel+"\",\"direccion\":\""+direccion+"\",\"mail\":\""+mail+"\",\"fechaIngreso\":\""+fechaIng+"\"}"};

			$.post(contacto,data,function(datos){
				var obj = $.parseJSON(datos);
				var resultado = obj.Resultado;
				alert(resultado);
				if(resultado != -1)
				{
					//alert("Los datos de contacto fueron ingresado.");
					var clave = direccionWeb+"ws-pass-datos.php";
					var data = {"send":"{\"indice\":1,\"idPersona\":\""+idPersona+"\",\"pass\":\""+pass+"\",\"fechaCaducidad\":\""+fonoFijo+"\"}"};
					//{"indice":1,"idPersona":3,"pass":"asdasd","fechaCaducidad":"2013-12-12"}

					$.post(contacto,data,function(datos){
						var obj = $.parseJSON(datos);
						var resultado = obj.Resultado;
						alert(resultado);
						if(resultado != -1)
						{
							alert("Las pass fue ingresada.");
						}
						else
						{
							alert("Error");
						}
					});
				}
				else
				{
					alert("Error");
				}
			});
		}
		else
		{
			alert("Error");
		}
	});
}