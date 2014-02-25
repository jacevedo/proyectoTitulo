package cl.sfh.entidades;

public class DatosContactoEditar
{
	private int idPersona;
	private int rut;
	private int perfil;
	private String dv;
	private String nombre;
	private String apellidoPaterno;
	private String apellidoMaterno;
	private String fechaNacimiento;
	private String fechaIngreso;
	private String fonoFijo;
	private String fonoCelular;
	private String direccion;
	private int comuna;
	private int region;
	private String correo;
	
	public DatosContactoEditar(int idPersona, int rut, int perfil, String dv,
			String nombre, String apellidoPaterno, String apellidoMaterno,
			String fechaNacimiento, String fechaIngreso, String fonoFijo,
			String fonoCelular, String direccion, int comuna, int region,
			String correo)
	{
		this.idPersona = idPersona;
		this.rut = rut;
		this.perfil = perfil;
		this.dv = dv;
		this.nombre = nombre;
		this.apellidoPaterno = apellidoPaterno;
		this.apellidoMaterno = apellidoMaterno;
		this.fechaNacimiento = fechaNacimiento;
		this.fechaIngreso = fechaIngreso;
		this.fonoFijo = fonoFijo;
		this.fonoCelular = fonoCelular;
		this.direccion = direccion;
		this.comuna = comuna;
		this.region = region;
		this.correo = correo;
	}

	public int getIdPersona()
	{
		return idPersona;
	}

	public void setIdPersona(int idPersona)
	{
		this.idPersona = idPersona;
	}

	public int getRut()
	{
		return rut;
	}

	public void setRut(int rut)
	{
		this.rut = rut;
	}

	public int getPerfil()
	{
		return perfil;
	}

	public void setPerfil(int perfil)
	{
		this.perfil = perfil;
	}

	public String getDv()
	{
		return dv;
	}

	public void setDv(String dv)
	{
		this.dv = dv;
	}

	public String getNombre()
	{
		return nombre;
	}

	public void setNombre(String nombre)
	{
		this.nombre = nombre;
	}

	public String getApellidoPaterno()
	{
		return apellidoPaterno;
	}

	public void setApellidoPaterno(String apellidoPaterno)
	{
		this.apellidoPaterno = apellidoPaterno;
	}

	public String getApellidoMaterno()
	{
		return apellidoMaterno;
	}

	public void setApellidoMaterno(String apellidoMaterno)
	{
		this.apellidoMaterno = apellidoMaterno;
	}

	public String getFechaNacimiento()
	{
		return fechaNacimiento;
	}

	public void setFechaNacimiento(String fechaNacimiento)
	{
		this.fechaNacimiento = fechaNacimiento;
	}

	public String getFechaIngreso()
	{
		return fechaIngreso;
	}

	public void setFechaIngreso(String fechaIngreso)
	{
		this.fechaIngreso = fechaIngreso;
	}

	public String getFonoFijo()
	{
		return fonoFijo;
	}

	public void setFonoFijo(String fonoFijo)
	{
		this.fonoFijo = fonoFijo;
	}

	public String getFonoCelular()
	{
		return fonoCelular;
	}

	public void setFonoCelular(String fonoCelular)
	{
		this.fonoCelular = fonoCelular;
	}

	public String getDireccion()
	{
		return direccion;
	}

	public void setDireccion(String direccion)
	{
		this.direccion = direccion;
	}

	public int getComuna()
	{
		return comuna;
	}

	public void setComuna(int comuna)
	{
		this.comuna = comuna;
	}

	public int getRegion()
	{
		return region;
	}

	public void setRegion(int region)
	{
		this.region = region;
	}

	public String getCorreo()
	{
		return correo;
	}

	public void setCorreo(String correo)
	{
		this.correo = correo;
	}
	
	
	
}
