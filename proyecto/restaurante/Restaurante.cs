using System;

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
        if (string.IsNullOrWhiteSpace(nit) ||
            string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(dueno) ||
            string.IsNullOrWhiteSpace(celular) ||
            string.IsNullOrWhiteSpace(direccion))
        {
            throw new ArgumentException("ningun campo del restaurante puede estar vacio");
        }

        this.nit = nit;
        this.nombre = nombre;
        this.dueno = dueno;
        this.celular = celular;
        this.direccion = direccion;

        this.clientes = new ListaEnlazada<Cliente>();
        this.menu = new Menu();
        this.pedidosPendientes = new Cola<Pedido>();
        this.pedidosDespachados = new Pila<Pedido>();
    }
    
    public string Nit
    {
        get { return this.nit; }
    }
    
    public string Nombre
    {
        get { return this.nombre; }
    }
    
    public string Dueno
    {
        get { return this.dueno; }
    }
    
    public string Celular
    {
        get { return this.celular; }
    }
    
    public string Direccion
    {
        get { return this.direccion; }
    }

    // metodo para agregar un cliente
    public void AgregarCliente(Cliente c)
    {
        if (c == null) throw new ArgumentNullException("cliente no puede ser nulo");

        if (this.clientes.Buscar(cliente => cliente.Cedula == c.Cedula) != null)
        {
            throw new ArgumentException("ya existe un cliente con esa cedula");
        }
        this.clientes.Agregar(c);
    }

    // metodo para listar clientes
    public void ListarClientes()
    {
        Nodo<Cliente> actual = this.clientes.Cabeza;
        Console.WriteLine("===== LISTA DE CLIENTES =====");
        if (actual == null)
        {
            Console.WriteLine("no hay clientes registrados");
        }
        while (actual != null)
        {
            Cliente c = actual.Valor;
            Console.WriteLine("nombre: " + c.Nombre + " | cedula: " + c.Cedula + " | correo: " + c.Correo + " | celular: " + c.Celular);
            actual = actual.Siguiente;
        }
        Console.WriteLine("================================");
    }

    // metodo para tomar un pedido
    public void TomarPedido(Pedido p)
    {
        this.pedidosPendientes.Agregar(p);
    }

    // metodo para despachar un pedido
    public void DespacharPedido()
    {
        if (this.pedidosPendientes.EstaVacia())
        {
            Console.WriteLine("no hay pedidos pendientes para despachar");
            return;
        }

        Pedido p = this.pedidosPendientes.Primero();
        this.pedidosPendientes.Eliminar();
        p.Despachar();
        this.pedidosDespachados.AgregarElemento(p);
        Console.WriteLine("pedido despachado: " + p.IdPedido);
    }

    // metodo para mostrar pedidos pendientes
    public void MostrarPedidosPendientes()
    {
        Console.WriteLine("===== PEDIDOS PENDEINTES =====");
        Nodo<Pedido> actual = this.pedidosPendientes.PrimeroNodo();
        if (actual == null)
        {
            Console.WriteLine("no hay pedidos pendientes");
        }
        while (actual != null)
        {
            actual.Valor.MostrarPedido();
            actual = actual.Siguiente;
        }
        Console.WriteLine("================================");
    }

    // metodo para mostrar pedidos despachados
    public void MostrarPedidosDespachados()
    {
        Console.WriteLine("===== PEDIDOS DESPACHADOS =====");
        Nodo<Pedido> actual = this.pedidosDespachados.CimaNodo();
        if (actual == null)
        {
            Console.WriteLine("no hay pedidos despachados");
        }
        while (actual != null)
        {
            actual.Valor.MostrarPedido();
            actual = actual.Siguiente;
        }
        Console.WriteLine("================================");
    }

    // metodo para calcular ganancias del dia
    public decimal CalcularGananciasDelDia()
    {
        decimal totalGanancias = 0;
        Nodo<Pedido> actual = this.pedidosDespachados.CimaNodo();
        DateTime hoy = DateTime.Today;

        while (actual != null)
        {
            if (actual.Valor.Fecha.Date == hoy)
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
        this.menu.MostrarMenu();
    }
}
