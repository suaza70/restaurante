public class Restaurante
{

    private string nit;
    private string nombre;
    private string dueno;
    private string celular;
    private string direccion;
    
    private ListaEnlazada<Cliente> clientes;
    private Menu menu;
    private Cola<Pedido> pedidosPendientes;
    private Pila<Pedido> pedidosDespachados;

    // constructor
    public Restaurante(string nit, string nombre, string dueno, string celular, string direccion)
    {
        this.nit = nit;
        this.nombre = nombre;
        this.dueno = dueno;
        this.celular = celular;
        this.direccion = direccion;

        clientes = new ListaEnlazada<Cliente>(); 
        menu = new Menu();
        pedidosPendientes = new Cola<Pedido>(); 
        pedidosDespachados = new Pila<Pedido>();
    }

    // metedo de clientes
    public void AgregarCliente(Cliente c)
    {
        // validar que la cedula sea unica
        if (clientes.Buscar(cliente => cliente.Cedula == c.Cedula) != null)
        {
            throw new ArgumentException("ya existe un cliente con esa cedula");
        }
        clientes.Agregar(c);
    }

    public void ListarClientes()
    {
        Nodo<Cliente> actual = clientes.Cabeza;
        Console.WriteLine("===== LISTA DE CLIENTES =====");
        while (actual != null)
        {
            Cliente c = actual.Valor;
            Console.WriteLine("Nombre: " + c.Nombre + " | Cedula: " + c.Cedula + " | Correo: " + c.Correo + " | Celular: " + c.Celular);
            actual = actual.Siguiente;
        }
        Console.WriteLine("==============================");
    }

    // metodo de pedidos
    public void TomarPedido(Pedido p)
    {
        pedidosPendientes.Agregar(p);
    }

    public void DespacharPedido()
    {
        if (pedidosPendientes.EstaVacia())
        {
            Console.WriteLine("no hay pedidos pendientes para despachar");
            return;
        }

        Pedido p = pedidosPendientes.Primero(); // obtenemos el primer pedido
        pedidosPendientes.Eliminar(); // lo removemos de la cola
        p.Despachar(); // cambiamos estado a DESPACHADO
        pedidosDespachados.AgregarElemento(p); // agregamos a la pila de despachados
        Console.WriteLine("Pedido despachado: " + p.IdPedido);
    }

    // reportes
    public void MostrarPedidosPendientes()
    {
        Console.WriteLine("===== PEDIDOS PENDIENTES =====");
        Nodo<Pedido> actual = pedidosPendientes.PrimeroNodo();
        while (actual != null)
        {
            actual.Valor.MostrarPedido();
            actual = actual.Siguiente;
        }
        Console.WriteLine("===============================");
    }

    public void MostrarPedidosDespachados()
    {
        Console.WriteLine("===== PEDIDOS DESPACHADOS =====");
        Nodo<Pedido> actual = pedidosDespachados.CimaNodo();
        while (actual != null)
        {
            actual.Valor.MostrarPedido();
            actual = actual.Siguiente;
        }
        Console.WriteLine("===============================");
    }

    public decimal CalcularGananciasDelDia()
    {
        decimal totalGanancias = 0;
        Nodo<Pedido> actual = pedidosDespachados.CimaNodo();
        DateTime hoy = DateTime.Today;

        while (actual != null)
        {
            if (actual.Valor.Fecha.Date == hoy) // comparamos solo la fecha
            {
                totalGanancias += actual.Valor.Total;
            }
            actual = actual.Siguiente;
        }
        return totalGanancias;
    }

    // metodo para mostrar el menu
    public void MostrarMenu()
    {
        menu.MostrarMenu();
    }
}
