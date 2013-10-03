window.onload = function()
{
	var btnReservarHoraPaciente = document.getElementById("btnReservarHoraPaciente");
	
	btnReservarHoraPaciente.addEventListener('click',reservarHoraPaciente,false);
}
function reservarHoraPaciente()
{
	alert("Su Hora fue agendada con exito");
}