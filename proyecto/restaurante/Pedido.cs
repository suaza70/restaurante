using System;

public class Pedido
{
    private int idPedido;
    private Cliente cliente;
    private DateTime fecha;
    private string estado;
    private ListaEnlazada<PlatoPedido> platos;

    // constructor
    public Pedido(int idPedido, Cliente cliente)
    {
        this.idPedido = idPedido;
        this.cliente = cliente;
        this.fecha = DateTime.Now;
        this.estado = "pendiente";
        this.platos = new ListaEnlazada<PlatoPedido>();
    }
    
    public int IdPedido
    {
        get { return this.idPedido; }
    }
    
    public Cliente Cliente
    {
        get { return this.cliente; }
    }
    
    public DateTime Fecha
    {
        get { return this.fecha; }
    }
    
    public string Estado
    {
        get { return this.estado; }
    }
    
    public ListaEnlazada<PlatoPedido> Platos
    {
        get { return this.platos; }
    }
    
    public void AgregarPlato(PlatoPedido plato)
    {
        this.platos.Agregar(plato);
    }

    //calcular el total del pedido
    public decimal Total
    {
        get
        {
            decimal suma = 0;
            Nodo<PlatoPedido> actual = this.platos.Cabeza;
            while (actual != null)
            {
                suma += actual.Valor.PrecioUnitario * actual.Valor.Cantidad;
                actual = actual.Siguiente;
            }
            return suma;
        }
    }

    // metodo para marcar el pedido como despachado
    public void Despachar()
    {
        this.estado = "despachado";
    }

    // metodo para mostrar la informacion del pedido
    public void MostrarPedido()
    {
        Console.WriteLine("===== informacion del pedido =====");
        Console.WriteLine("id: " + this.idPedido);
        Console.WriteLine("cliente: " + this.cliente.Nombre);
        Console.WriteLine("fecha: " + this.fecha);
        Console.WriteLine("estado: " + this.estado);
        Console.WriteLine("total: " + this.Total);
        Console.WriteLine("platos:");
        Nodo<PlatoPedido> actual = this.platos.Cabeza;
        while (actual != null)
        {
            Console.WriteLine("codigo: " + actual.Valor.CodigoPlato + " | cantidad: " + actual.Valor.Cantidad + " | precio unitario: " + actual.Valor.PrecioUnitario);
            actual = actual.Siguiente;
        }
        Console.WriteLine("==================================");
    }
}
