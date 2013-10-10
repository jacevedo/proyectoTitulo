package cl.sfh.entidades;

public class Login
{
	private String key;
	private int codAcceso;

	public Login(String key, int codAcceso)
	{
		this.key = key;
		this.codAcceso = codAcceso;
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
