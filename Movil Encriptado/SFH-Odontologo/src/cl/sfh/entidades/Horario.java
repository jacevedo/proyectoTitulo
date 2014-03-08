package cl.sfh.entidades;

public class Horario
{
	private int idHorario;
	private String fecha;
	private String hora;
	private String paciente;
	
	public Horario(int idHorario, String fecha, String hora, String paciente)
	{
		this.idHorario = idHorario;
		this.fecha = fecha;
		this.hora = hora;
		this.paciente = paciente;
	}

	public int getIdHorario()
	{
		return idHorario;
	}

	public void setIdHorario(int idHorario)
	{
		this.idHorario = idHorario;
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

	public String getPaciente()
	{
		return paciente;
	}

	public void setPaciente(String paciente)
	{
		this.paciente = paciente;
	}
	
	
}
