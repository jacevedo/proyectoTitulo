package cl.sfh.entidades;

public class ListaPreciosEntidad
{
	private int idPrecio;
	private String comentario;
	private int valorNeto;
	private int valorIva;
	private int valorTotal;
	
	public ListaPreciosEntidad(int idPrecio, String comentario, int valorNeto,int valorIva,
							int valorTotal) 
	{
		this.idPrecio = idPrecio;
		this.comentario = comentario;
		this.valorNeto = valorNeto;
		this.valorIva = valorIva;
		this.valorTotal = valorTotal;
	}

	public int getIdPrecio() 
	{
		return idPrecio;
	}

	public void setIdPrecio(int idPrecio) 
	{
		this.idPrecio = idPrecio;
	}

	public String getComentario() {
		return comentario;
	}

	public void setComentario(String comentario) 
	{
		this.comentario = comentario;
	}

	public int getValorNeto()
	{
		return valorNeto;
	}

	public void setValorNeto(int valorNeto) 
	{
		this.valorNeto = valorNeto;
	}

	public int getValorIva() 
	{
		return valorIva;
	}

	public void setValorIva(int valorIva) 
	{
		this.valorIva = valorIva;
	}

	public int getValorTotal()
	{
		return valorTotal;
	}

	public void setValorTotal(int valorTotal) 
	{
		this.valorTotal = valorTotal;
	}
	
	
}
