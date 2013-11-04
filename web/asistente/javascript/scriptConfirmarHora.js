window.onload = function()
{
	var btnConfirmarHora = document.getElementById("btnConfirmarHora");
	
	btnConfirmarHora.addEventListener('click',ConfirmarHora,false);
}
function ConfirmarHora()
{
	alert("Las horas fueron confirmadas con exito");
}