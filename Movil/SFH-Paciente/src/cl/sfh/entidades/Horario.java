package cl.sfh.entidades;

import java.util.ArrayList;

public class Horario
{
	private int idOdontologo;
	private String nomOdontologo;
	private ArrayList<String> horario;
	
	
	public Horario(int idOdontologo, String nomOdontologo, ArrayList<String> horario)
	{
		super();
		this.idOdontologo = idOdontologo;
		this.nomOdontologo = nomOdontologo;
		this.horario = horario;
	}
	public Horario()
	{
	
	}
	
	public int getIdOdontologo()
	{
		return idOdontologo;
	}
	public void setIdOdontologo(int idOdontologo)
	{
		this.idOdontologo = idOdontologo;
	}
	public String getNomOdontologo()
	{
		return nomOdontologo;
	}
	public void setNomOdontologo(String nomOdontologo)
	{
		this.nomOdontologo = nomOdontologo;
	}
	public ArrayList<String> getHorario()
	{
		return horario;
	}
	public void setHorario(ArrayList<String> horario)
	{
		this.horario = horario;
	}
	
}
