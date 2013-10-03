window.onload = function()
{
	var btnReservarHora = document.getElementById("btnReservarHora");
		
	btnReservarHora.addEventListener('click',reservarHora,false);
}
function reservarHora()
{
	alert("Hora de atencion agendada correctamente");
}
