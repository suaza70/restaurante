public class Pedido
{
    private int idpedido;
    private Cliente cliente;
    private ListaEnlazada<PlatoPedido> platos;
    private decimal total;
    private DateTime fecha;
    private string estado;

    // constructor
    public Pedido(int idpedido, Cliente cliente)
    {
        this.idpedido = idpedido;
        this.cliente = cliente;
        this.platos = new ListaEnlazada<PlatoPedido>();
        this.total = 0;
        this.fecha = DateTime.Now;
        this.estado = "PENDIENTE";
    }
    
    // metodo para agregar un plato al pedido
    public void AgregarPlato(PlatoPedido plato)
    {
        platos.Agregar(plato);
        total += plato.PrecioUnitario * plato.Cantidad;
    }

    // metodo para despachar el pedido
    public void Despachar()
    {
        if (estado == "PENDIENTE")
        {
            estado = "DESPACHADO";
        }
        else
        {
            Console.WriteLine("El pedido ya fue despachado");
        }
    }

    // metodo para mostrar la informacion del pedido
    public void MostrarPedido()
    {
        Console.WriteLine("===== INFORMACION DEL PEDIDO =====");
        Console.WriteLine("ID Pedido: " + idpedido);
        Console.WriteLine("Cliente: " + cliente.Nombre + " | Cedula: " + cliente.Cedula);
        Console.WriteLine("Fecha: " + fecha);
        Console.WriteLine("Estado: " + estado);
        Console.WriteLine("Platos:");
        
        Nodo<PlatoPedido> actual = platos.Cabeza;
        while (actual != null)
        {
            PlatoPedido p = actual.Valor;
            Console.WriteLine("Codigo Plato: " + p.CodigoPlato + " | Cantidad: " + p.Cantidad + " | Precio Unitario: $" + p.PrecioUnitario);
            actual = actual.Siguiente;
        }

        Console.WriteLine("Total: $" + total);
        Console.WriteLine("===================================");
    }
    
}
