package cl.sfh.entidades;

public class DatosContacto
{
	private int idPersona;
	private int idComuna;
	private String fonoFijo;
	private String fonoCelular;
	private String direccion;
	private String mail;
	private String fechaIngreso;
	
	
	
	public DatosContacto(int idPersona, int idComuna, String fonoFijo,
			String fonoCelular, String direccion, String mail,
			String fechaIngreso)
	{
		this.idPersona = idPersona;
		this.idComuna = idComuna;
		this.fonoFijo = fonoFijo;
		this.fonoCelular = fonoCelular;
		this.direccion = direccion;
		this.mail = mail;
		this.fechaIngreso = fechaIngreso;
	}
	public int getIdPersona()
	{
		return idPersona;
	}
	public void setIdPersona(int idPersona)
	{
		this.idPersona = idPersona;
	}
	public int getIdComuna()
	{
		return idComuna;
	}
	public void setIdComuna(int idComuna)
	{
		this.idComuna = idComuna;
	}
	public String getFonoFijo()
	{
		return fonoFijo;
	}
	public void setFonoFijo(String fonoFijo)
	{
		this.fonoFijo = fonoFijo;
	}
	public String getFonoCelular()
	{
		return fonoCelular;
	}
	public void setFonoCelular(String fonoCelular)
	{
		this.fonoCelular = fonoCelular;
	}
	public String getDireccion()
	{
		return direccion;
	}
	public void setDireccion(String direccion)
	{
		this.direccion = direccion;
	}
	public String getMail()
	{
		return mail;
	}
	public void setMail(String mail)
	{
		this.mail = mail;
	}
	public String getFechaIngreso()
	{
		return fechaIngreso;
	}
	public void setFechaIngreso(String fechaIngreso)
	{
		this.fechaIngreso = fechaIngreso;
	}
	
	
}
