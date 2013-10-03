window.onload = function()
{
	var btnModificarTratamiento = document.getElementById("btnModificarTratamiento");
	var btnEliminarTratamiento = document.getElementById("btnEliminarTratamiento");


	btnModificarTratamiento.addEventListener('click',modificarTratamientoSeguro,false);
	btnEliminarTratamiento.addEventListener('click',eliminarTratamientoSeguro,false);
}
function modificarTratamientoSeguro()
{
	alert("Su tratamiento fue modificado con exito");
}
function eliminarTratamientoSeguro()
{
	var confirmar = confirm("Estas seguro de Eliminar el Tratamiento?");
	if(confirmar)
	{
		alert("Tratamiento Eliminado Correctamente");
	}
	else
	{

	}
	window.redire
}