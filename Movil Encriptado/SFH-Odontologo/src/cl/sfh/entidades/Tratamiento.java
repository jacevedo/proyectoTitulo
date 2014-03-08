package cl.sfh.entidades;

public class Tratamiento
{
	private int idTratamiento;
	private int idFicha;
	private String fechaCreacion;
	private String tratamiento;
	private String fechaSeguimiento;
	private int valor;
	
	public Tratamiento(int idTratamiento, int idFicha, String fechaCreacion, String tratamiento, String fechaSeguimiento, int valor)
	{
		this.idTratamiento = idTratamiento;
		this.idFicha = idFicha;
		this.fechaCreacion = fechaCreacion;
		this.tratamiento = tratamiento;
		this.fechaSeguimiento = fechaSeguimiento;
		this.valor = valor;
	}

	public int getIdTratamiento()
	{
		return idTratamiento;
	}

	public void setIdTratamiento(int idTratamiento)
	{
		this.idTratamiento = idTratamiento;
	}

	public int getIdFicha()
	{
		return idFicha;
	}

	public void setIdFicha(int idFicha)
	{
		this.idFicha = idFicha;
	}

	public String getFechaCreacion()
	{
		return fechaCreacion;
	}

	public void setFechaCreacion(String fechaCreacion)
	{
		this.fechaCreacion = fechaCreacion;
	}

	public String getTratamiento()
	{
		return tratamiento;
	}

	public void setTratamiento(String tratamiento)
	{
		this.tratamiento = tratamiento;
	}

	public String getFechaSeguimiento()
	{
		return fechaSeguimiento;
	}

	public void setFechaSeguimiento(String fechaSeguimiento)
	{
		this.fechaSeguimiento = fechaSeguimiento;
	}

	public int getValor()
	{
		return valor;
	}

	public void setValor(int valor)
	{
		this.valor = valor;
	}
}
