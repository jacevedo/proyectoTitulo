var direccionWeb = "http://localhost/proyectoTitulo/sfhwebservice/webService/";
$(document).ready(inicializarEventos);

function inicializarEventos()
{
	cargarPerfil();
}

function cargarPerfil()
{
	var id = $("#idPaciente").val();
	var key = $("#keyPaciente").val();
	//alert("Id: "+id+" || key: "+key);
	var ingresar = direccionWeb+"ws-add-usuario.php";
	var data = {"send":"{\"indice\":2,\"rut\":"+id+"}"};

	//{"indice":2,"rut":16009332
	$.post(ingresar, data, function(datos){
		//alert(datos);
		var obj = $.parseJSON(datos);
		var persona = obj.datosPersona;
		var contacto = obj.datosContacto;
		//alert("Persona: "+persona.apellidoMaterno+". Contacto: "+contacto.direccion);

		var tabla = "";
		tabla = tabla + "<tr><td class='tdIndicador'>Nombre:</td><td>"+persona.nombre+"</td></tr><tr><td class='tdIndicador'>Apellido Paterno:</td><td>"+persona.apellidoPaterno+"</td></tr><tr><td class='tdIndicador'>Apellido Materno:</td><td>"+persona.apellidoMaterno+"</td></tr><tr><td class='tdIndicador'>Rut:</td><td>"+persona.rut+"-"+persona.dv+"</td></tr><tr><td class='tdIndicador'>Fecha de Nacimiento:</td><td>"+persona.fechaNacimiento+"</td></tr><tr><td class='tdIndicador'>Direccion:</td><td>"+contacto.direccion+"</td></tr><tr><td class='tdIndicador'>Comuna</td><td>"+contacto.idComuna+"</td></tr><tr><td class='tdIndicador'>Telefono Fijo</td><td>"+contacto.fonoFijo+"</td></tr><tr><td class='tdIndicador'>Celular</td><td>"+contacto.fonoCelular+"</td></tr><tr><td colspan=2><button id='btnCrearCuenta'>Modificar Cuenta</button></td></tr>";
		$("#tablaContenido").html(tabla);
	});
}