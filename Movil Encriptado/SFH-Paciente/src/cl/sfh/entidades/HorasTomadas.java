package cl.sfh.entidades;

public class HorasTomadas
{
	private String nomOdontologo;
	private int idOdontologo;
	private String fecha;
	private String hora;
	
	public HorasTomadas(String nomOdontologo, int idOdontologo, String fecha,
			String hora)
	{
		this.nomOdontologo = nomOdontologo;
		this.idOdontologo = idOdontologo;
		this.fecha = fecha;
		this.hora = hora;
	}

	public String getNomOdontologo()
	{
		return nomOdontologo;
	}

	public void setNomOdontologo(String nomOdontologo)
	{
		this.nomOdontologo = nomOdontologo;
	}

	public int getIdOdontologo()
	{
		return idOdontologo;
	}

	public void setIdOdontologo(int idOdontologo)
	{
		this.idOdontologo = idOdontologo;
	}

	public String getFecha()
	{
		return fecha;
	}

	public void setFecha(String fecha)
	{
		this.fecha = fecha;
	}

	public String getHora()
	{
		return hora;
	}

	public void setHora(String hora)
	{
		this.hora = hora;
	}	
}
