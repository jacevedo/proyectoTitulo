package cl.sfh.libreria;

/**
 * Created by jacevedo on 24-06-13.
 */
public class Pacientes
{
    private long id;
    private String nombre;
    private String appPaterno;
    private String appMaterno;
    private String ultimoProcedimiento;
    private String fechaNacimiento;
    private String anamnesis;

    public Pacientes(long id, String nombre, String appPaterno, String appMaterno, String ultimoProcedimiento, String fechaNacimiento, String anamnesis)
    {
        this.id = id;
        this.nombre = nombre;
        this.appPaterno = appPaterno;
        this.appMaterno = appMaterno;
        this.ultimoProcedimiento = ultimoProcedimiento;
        this.fechaNacimiento = fechaNacimiento;
        this.anamnesis = anamnesis;
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

    public String getUltimoProcedimiento()
    {
        return ultimoProcedimiento;
    }

    public void setUltimoProcedimiento(String ultimoProcedimiento)
    {
        this.ultimoProcedimiento = ultimoProcedimiento;
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
}
