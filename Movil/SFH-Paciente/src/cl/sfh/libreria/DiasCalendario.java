package cl.sfh.libreria;

/**
 * Created by jacevedo on 24-06-13.
 */
public class DiasCalendario
{
	private long id;
	private int dia;
	private int estado;

	public DiasCalendario(long id, int dia, int estado)
	{
		this.id = id;
		this.dia = dia;
		this.estado = estado;
	}

	public int getEstado()
	{
		return estado;
	}

	public void setEstado(int estado)
	{
		this.estado = estado;
	}

	public long getId()
	{
		return id;
	}

	public void setId(long id)
	{
		this.id = id;
	}

	public int getDia()
	{
		return dia;
	}

	public void setDia(int dia)
	{
		this.dia = dia;
	}
}
