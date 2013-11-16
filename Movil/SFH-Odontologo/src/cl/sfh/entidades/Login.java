package cl.sfh.entidades;

public class Login
{
	private String key;
	private int codAcceso;
	private int idPersona;
	private int idOdontologo;

	public Login(String key, int codAcceso, int idPersona,int idOdontologo)
	{
		this.key = key;
		this.codAcceso = codAcceso;
		this.idPersona = idPersona;
		this.idOdontologo = idOdontologo;
	}

	
	public int getIdOdontologo()
	{
		return idOdontologo;
	}


	public void setIdOdontologo(int idOdontologo)
	{
		this.idOdontologo = idOdontologo;
	}


	public int getIdPersona()
	{
		return idPersona;
	}

	public void setIdPersona(int idPersona)
	{
		this.idPersona = idPersona;
	}

	public String getKey()
	{
		return key;
	}

	public void setKey(String key)
	{
		this.key = key;
	}

	public int getCodAcceso()
	{
		return codAcceso;
	}

	public void setCodAcceso(int codAcceso)
	{
		this.codAcceso = codAcceso;
	}
}
