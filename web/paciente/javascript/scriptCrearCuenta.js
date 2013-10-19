var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	cargarRegiones();
	$("#region").change(cambiarComuna);
	$("#btnCrearCuenta").click(guardarPersona);
}

function cargarRegiones()
{
	var regiones = direccionWeb+"ws-add-usuario.php";
	var data = {"send":"{\"indice\":3}"};

	$.post(regiones,data,function(datos){
		var obj = $.parseJSON(datos);
		var option = document.getElementById("region");
		option.options.add(new Option("Seleccione una Region", 0));

		$.each(obj.listaRegiones,function()
			{
				//sel = sel + "<option value="+this.idCurso+">"+this.nivel+"-"+this.numero+"-"+this.letra+"</option>"
				option.options.add(new Option(this.nombreRegion, this.idRegion));
			});

	});
}

function cambiarComuna()
{
	var idRegion = document.getElementById("region").value;

	var comunas = direccionWeb+"ws-add-usuario.php";
	var data = {"send":"{\"indice\":4,\"idRegion\":\""+idRegion+"\"}"};

	$.post(comunas,data,function(datos){
		var obj = $.parseJSON(datos);
		var option = document.getElementById("comuna");
		$("#comuna").find('option').remove().end();
		//option = "";
		option.options.add(new Option("Seleccione una Comuna", 0));

		$.each(obj.listaComuna,function()
			{
				//sel = sel + "<option value="+this.idCurso+">"+this.nivel+"-"+this.numero+"-"+this.letra+"</option>"
				option.options.add(new Option(this.nombreComuna, this.idComuna));
			});

	});
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

	var persona = direccionWeb+"ws-add-usuario.php";
	var data = {"send":"{\"indice\":1,\"idPerfil\":4,\"rut\":\""+rut+"\",\"dv\":\""+dv+"\",\"nombre\":\""+nombre+"\",\"appPaterno\":\""+appPaterno+"\",\"appMaterno\":\""+appMaterno+"\",\"fechaNac\":\""+fechaNac+"\",\"pass\":\""+pass+"\",\"idComuna\":\""+comuna+"\",\"fonoFijo\":\""+fonoFijo+"\",\"celular\":\""+fonoCel+"\",\"Direccion\":\""+direccion+"\",\"mail\":\""+mail+"\",\"fechaIngreso\":\""+fechaIng+"\"}"};
	//{"indice":1,"idPerfil":4,"rut":17897359,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12","pass":"asdcasco","idComuna":2,"fonoFijo":"0227780184","celular":"+56976087240","Direccion":"antonio Varas 666","mail":"asd@asd.com","fechaIngreso":"2013-02-02"}

	$.post(persona,data,function(datos){
		var obj = $.parseJSON(datos);
		var result = obj.resultado;
		alert(result);
		if(result == "datos Insertados Correctamente")
		{
			alert("Tu cuenta ha sido creada con éxito.");
			window.location.href = "login.php";
		}
		else
		{
			alert("Hubo un error al crear tu cuenta.");
		}
	});
}
