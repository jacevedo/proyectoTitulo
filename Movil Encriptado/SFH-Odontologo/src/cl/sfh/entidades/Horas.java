package cl.sfh.entidades;

/**
 * Created by jacevedo on 24-06-13.
 */
public class Horas
{
    private Long id;
    private String hora;
    private String nomPaciente;

    public Horas(Long id, String hora, String nomPaciente)
    {
        this.id = id;
        this.hora = hora;
        this.nomPaciente = nomPaciente;
    }

    public Long getId()
    {
        return id;
    }

    public void setId(Long id)
    {
        this.id = id;
    }

    public String getHora()
    {
        return hora;
    }

    public void setHora(String hora)
    {
        this.hora = hora;
    }

    public String getNomPaciente()
    {
        return nomPaciente;
    }

    public void setNomPaciente(String nomPaciente)
    {
        this.nomPaciente = nomPaciente;
    }
}
