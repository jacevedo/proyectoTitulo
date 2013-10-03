window.onload = function()
{
	var btnModificarCuenta = document.getElementById("btnModificarCuenta");
	
	btnModificarCuenta.addEventListener('click',modificarCuenta,false);
}
function modificarCuenta()
{
	alert("Su Cuenta fue modificada con exito");
}