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

function cambiarComuna()
{
	var idRegion = document.getElementById("region").value;

	var comunas = direccionWeb+"ws-add-usuario.php";
	var data = {"send":"{\"indice\":4,\"idRegion\":\""+idRegion+"\"}"};

	$.post(comunas,data,function(datos)
	{
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
	//PERSONA
	var nombre = $("#txtNombre").val();
	var appPaterno = $("#txtAppPaterno").val();
	var appMaterno = $("#txtAppMaterno").val();
	var rut = $("#txtRut").val();
	var dv = $("#txtDv").val();
	var fechaNac = $("#txtFechaNacimiento").val();

	//DATOS CONTACTO
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

	//PASS
	var pass = $("#txtContrasena").val();
	var fechaCad = new Date();
	var dd = fechaCad.getDate();
	var mm = fechaCad.getMonth()+1;
	var yyyy = fechaCad.getFullYear();
	if(dd<10){dd='0'+dd} if(mm<10){mm='0'+mm} fechaCad = yyyy+'/'+mm+'/'+dd;

	var persona = direccionWeb+"ws-add-usuario.php";
	var data = {"send":"{\"indice\":1,\"idPerfil\":4,\"rut\":\""+rut+"\",\"dv\":\""+dv+"\",\"nombre\":\""+nombre+"\",\"appPaterno\":\""+appPaterno+"\",\"appMaterno\":\""+appMaterno+"\",\"fechaNac\":\""+fechaNac+"\",\"pass\":\""+pass+"\",\"idComuna\":\""+comuna+"\",\"fonoFijo\":\""+fonoFijo+"\",\"celular\":\""+fonoCel+"\",\"Direccion\":\""+direccion+"\",\"mail\":\""+mail+"\",\"fechaIngreso\":\""+fechaIng+"\"}"};

	$.post(persona,data,function(datos)
	{
		var obj = $.parseJSON(datos);
		var result = obj.resultado;
		if(result == "datos Insertados Correctamente")
		{
			alert("Tu cuenta ha sido creada con exito.");
			window.location.href = "login.php";
		}
		else
		{
			alert("Hubo un error al crear tu cuenta.");
		}
	});
}