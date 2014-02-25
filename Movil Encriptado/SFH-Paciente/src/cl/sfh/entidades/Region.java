package cl.sfh.entidades;

public class Region
{
	private int idRegion;
	private String nomRegion;
	private String numRegionRomano;
	
	public Region(int idRegion, String nomRegion, String numRegionRomano)
	{
		this.idRegion = idRegion;
		this.nomRegion = nomRegion;
		this.numRegionRomano = numRegionRomano;
	}

	public int getIdRegion()
	{
		return idRegion;
	}

	public void setIdRegion(int idRegion)
	{
		this.idRegion = idRegion;
	}

	public String getNomRegion()
	{
		return nomRegion;
	}

	public void setNomRegion(String nomRegion)
	{
		this.nomRegion = nomRegion;
	}

	public String getNumRegionRomano()
	{
		return numRegionRomano;
	}

	public void setNumRegionRomano(String numRegionRomano)
	{
		this.numRegionRomano = numRegionRomano;
	}

	@Override
	public String toString()
	{
		return nomRegion;
	}
	
}
