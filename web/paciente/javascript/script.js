window.onload = function()
{
	var btnModificarTratamiento = document.getElementById("btnModificarTratamiento");
	var btnEliminarTratamiento = document.getElementById("btnEliminarTratamiento");
	
	btnModificarHora.addEventListener('click',modificarTratamiento,false);	
	btnEliminarTratamiento.addEventListener('click',eliminarTratamiento,false);
}
function modificarTratamiento()
{
	alert("Tratamiento modificado Correctamente");
}
function eliminarTratamiento()
{
	var confirmar = confirm("Desea Eliminar el tratamiento?");
	if(confirmar)
	{
		alert("tratamiento eliminado Correctamente");
	}
}