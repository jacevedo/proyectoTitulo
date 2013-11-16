package cl.sfh.entidades;

import java.sql.Date;

public class Cita
{
	Date fecha;
	Date horaInicio;
	String nomPaciente;
	String appPaternoPaciente;
	String appMaternoPaciente;
	
	public Cita(Date fecha, Date horaInicio, String nomPaciente,String appPaternoPaciente, String appMaternoPaciente)
	{
		this.fecha = fecha;
		this.horaInicio = horaInicio;
		this.nomPaciente = nomPaciente;
		this.appPaternoPaciente = appPaternoPaciente;
		this.appMaternoPaciente = appMaternoPaciente;
	}

	public Date getFecha()
	{
		return fecha;
	}

	public void setFecha(Date fecha)
	{
		this.fecha = fecha;
	}

	public Date getHoraInicio()
	{
		return horaInicio;
	}

	public void setHoraInicio(Date horaInicio)
	{
		this.horaInicio = horaInicio;
	}

	public String getNomPaciente()
	{
		return nomPaciente;
	}

	public void setNomPaciente(String nomPaciente)
	{
		this.nomPaciente = nomPaciente;
	}

	public String getAppPaternoPaciente()
	{
		return appPaternoPaciente;
	}

	public void setAppPaternoPaciente(String appPaternoPaciente)
	{
		this.appPaternoPaciente = appPaternoPaciente;
	}

	public String getAppMaternoPaciente()
	{
		return appMaternoPaciente;
	}

	public void setAppMaternoPaciente(String appMaternoPaciente)
	{
		this.appMaternoPaciente = appMaternoPaciente;
	}
}