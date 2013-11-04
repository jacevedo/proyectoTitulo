window.onload = function()
{
	var btnModificarHora = document.getElementById("btnModificarHora");
	var btnEliminarHora = document.getElementById("btnEliminarHora");
	
	btnModificarHora.addEventListener('click',modifcarHora,false);	
	btnEliminarHora.addEventListener('click',eliminarHora,false);
}
function modifcarHora()
{
	alert("Hora modificada Correctamente");
}
function eliminarHora()
{
	var confirmar = confirm("Desea Eliminar la hora de atencion?");
	if(confirmar)
	{
		alert("Hora de atencion eliminada Correctamente");
	}
}