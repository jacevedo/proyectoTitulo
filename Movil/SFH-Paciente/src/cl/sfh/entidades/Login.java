package cl.sfh.entidades;

public class Login
{
	private String key;
	private int codAcceso;
	private int idPaciente;

	public Login(String key, int codAcceso,int idPaciente)
	{
		this.key = key;
		this.codAcceso = codAcceso;
		this.idPaciente = idPaciente;
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
	
	public int getIdPaciente()
	{
		return idPaciente;
	}

	public void setIdPaciente(int idPaciente)
	{
		this.idPaciente = idPaciente;
	}
}
