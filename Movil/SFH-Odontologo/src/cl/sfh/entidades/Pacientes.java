package cl.sfh.entidades;

import java.util.ArrayList;

/**
 * Created by jacevedo on 24-06-13.
 */
public class Pacientes
{
    private long id;
    private String nombre;
    private String appPaterno;
    private String appMaterno;
    private String fechaNacimiento;
    private String anamnesis;
    private ArrayList<Tratamiento> listaTratamientos;

    public Pacientes(long id, String nombre, String appPaterno, String appMaterno,  String fechaNacimiento, String anamnesis, ArrayList<Tratamiento> listaTratamiento)
    {
        this.id = id;
        this.nombre = nombre;
        this.appPaterno = appPaterno;
        this.appMaterno = appMaterno;
        this.fechaNacimiento = fechaNacimiento;
        this.anamnesis = anamnesis;
        this.listaTratamientos = listaTratamiento;
    }

  
    public long getId()
    {
        return id;
    }

    public void setId(long id)
    {
        this.id = id;
    }

    public String getNombre()
    {
        return nombre;
    }

    public void setNombre(String nombre)
    {
        this.nombre = nombre;
    }

    public String getAppPaterno()
    {
        return appPaterno;
    }

    public void setAppPaterno(String appPaterno)
    {
        this.appPaterno = appPaterno;
    }

    public String getAppMaterno()
    {
        return appMaterno;
    }

    public void setAppMaterno(String appMaterno)
    {
        this.appMaterno = appMaterno;
    }

   
    public String getFechaNacimiento()
    {
        return fechaNacimiento;
    }

    public void setFechaNacimiento(String fechaNacimiento)
    {
        this.fechaNacimiento = fechaNacimiento;
    }

    public String getAnamnesis()
    {
        return anamnesis;
    }

    public void setAnamnesis(String anamnesis)
    {
        this.anamnesis = anamnesis;
    }


	public ArrayList<Tratamiento> getListaTratamientos()
	{
		return listaTratamientos;
	}


	public void setListaTratamientos(ArrayList<Tratamiento> listaTratamientos)
	{
		this.listaTratamientos = listaTratamientos;
	}
    
    
}
