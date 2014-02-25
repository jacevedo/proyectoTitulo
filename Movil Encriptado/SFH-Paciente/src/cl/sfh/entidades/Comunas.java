package cl.sfh.entidades;

public class Comunas
{
	private int idComuna;
	private int idRegion;
	private String nomComuna;
	
	public Comunas(int idComuna, int idRegion, String nomComuna)
	{
		this.idComuna = idComuna;
		this.idRegion = idRegion;
		this.nomComuna = nomComuna;
	}

	public int getIdComuna()
	{
		return idComuna;
	}

	public void setIdComuna(int idComuna)
	{
		this.idComuna = idComuna;
	}

	public int getIdRegion()
	{
		return idRegion;
	}

	public void setIdRegion(int idRegion)
	{
		this.idRegion = idRegion;
	}

	public String getNomComuna()
	{
		return nomComuna;
	}

	public void setNomComuna(String nomComuna)
	{
		this.nomComuna = nomComuna;
	}

	@Override
	public String toString()
	{
		return nomComuna;
	}
	
}
