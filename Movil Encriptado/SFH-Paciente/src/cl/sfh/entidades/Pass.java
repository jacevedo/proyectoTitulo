package cl.sfh.entidades;

public class Pass
{
	private int idPersona;
	private String pass;
	private String fechaCaducidad;
	
	
	public Pass(int idPersona, String pass, String fechaCaducidad)
	{
		this.idPersona = idPersona;
		this.pass = pass;
		this.fechaCaducidad = fechaCaducidad;
	}
	public int getIdPersona()
	{
		return idPersona;
	}
	public void setIdPersona(int idPersona)
	{
		this.idPersona = idPersona;
	}
	public String getPass()
	{
		return pass;
	}
	public void setPass(String pass)
	{
		this.pass = pass;
	}
	public String getFechaCaducidad()
	{
		return fechaCaducidad;
	}
	public void setFechaCaducidad(String fechaCaducidad)
	{
		this.fechaCaducidad = fechaCaducidad;
	}
	
	
}
