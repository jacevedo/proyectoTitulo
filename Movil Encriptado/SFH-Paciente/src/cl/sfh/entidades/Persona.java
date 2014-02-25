package cl.sfh.entidades;

public class Persona
{
	private int idPersona;
	private int idPerfil;
	private int rut;
	private String dv;
	private String nombre;
	private String appPaterno;
	private String appMaterno;
	private String fechaNacimiento;
	
	
	
	public Persona(int idPersona, int idPerfil, int rut, String dv,	String nombre, String appPaterno, String appMaterno,
			String fechaNacimiento)
	{
		this.idPersona = idPersona;
		this.idPerfil = idPerfil;
		this.rut = rut;
		this.dv = dv;
		this.nombre = nombre;
		this.appPaterno = appPaterno;
		this.appMaterno = appMaterno;
		this.fechaNacimiento = fechaNacimiento;
	}
	
	public int getIdPersona()
	{
		return idPersona;
	}
	public void setIdPersona(int idPersona)
	{
		this.idPersona = idPersona;
	}
	public int getIdPerfil()
	{
		return idPerfil;
	}
	public void setIdPerfil(int idPerfil)
	{
		this.idPerfil = idPerfil;
	}
	public int getRut()
	{
		return rut;
	}
	public void setRut(int rut)
	{
		this.rut = rut;
	}
	public String getDv()
	{
		return dv;
	}
	public void setDv(String dv)
	{
		this.dv = dv;
	}
	public String getNombre()
	{
		return nombre;
	}
	public void setNombre(String nombre)
	{
		this.nombre = nombre;
	}
	public String getAppPaterno()
	{
		return appPaterno;
	}
	public void setAppPaterno(String appPaterno)
	{
		this.appPaterno = appPaterno;
	}
	public String getAppMaterno()
	{
		return appMaterno;
	}
	public void setAppMaterno(String appMaterno)
	{
		this.appMaterno = appMaterno;
	}
	public String getFechaNacimiento()
	{
		return fechaNacimiento;
	}
	public void setFechaNacimiento(String fechaNacimiento)
	{
		this.fechaNacimiento = fechaNacimiento;
	}
	
	
}
