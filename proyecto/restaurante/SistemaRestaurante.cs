public class SistemaRestaurante
{
    private ListaEnlazada<Restaurante> restaurantes;
    private Cola<Pedido> pedidosPendientes;
    private Pila<Pedido> pedidosDespachados;
    
    public SistemaRestaurante()
    {
        restaurantes = new ListaEnlazada<Restaurante>();
        pedidosPendientes = new Cola<Pedido>();
        pedidosDespachados = new Pila<Pedido>();
    }

    // metodo para crear un restaurante
    public void CrearRestaurante()
    {
        Console.WriteLine("ingrese nit del restaurante: ");
        string nit = Console.ReadLine();

        Console.WriteLine("ingrese nombre del restaurante: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("ingrese nombre del dueño: ");
        string dueno = Console.ReadLine();

        Console.WriteLine("ingrese celular (10 digitos): ");
        string celular = Console.ReadLine();

        Console.WriteLine("ingrese direccion: ");
        string direccion = Console.ReadLine();

        try
        {
            // creamos el objeto Restaurante
            Restaurante r = new Restaurante(nit, nombre, dueno, celular, direccion);
            
            restaurantes.Agregar(r);
            Console.WriteLine("restaurante creado correctamente");
        }
        catch (Exception ex)
        {
            // mostramos cualquier error de validacion
            Console.WriteLine("error: " + ex.Message);
        }
    }

    // metodo para listar todos los restaurantes
    public void ListarRestaurantes()
    {
        Nodo<Restaurante> actual = restaurantes.Cabeza;

        if (actual == null)
        {
            Console.WriteLine("no hay restaurantes registrados");
            return;
        }

        while (actual != null)
        {
            Restaurante r = actual.Valor;
            Console.WriteLine("Nit: " + r.Nit + " | Nombre: " + r.Nombre + " | Dueno: " + r.Dueno + " | Celular: " + r.Celular + " | Direccion: " + r.Direccion);  // r facilita como el recorrido de la lista
            actual = actual.Siguiente;
        }
    }

    // metodo para crear un cliente dentro de un restaurante
    public void CrearCliente()
    {
        Console.WriteLine("seleccione el restaurante por Nit: ");
        string nit = Console.ReadLine();

        Restaurante r = restaurantes.Buscar(x => x.Nit == nit);

        if (r == null)
        {
            Console.WriteLine("restaurante no encontrado");
            return;
        }

        // pedimos datos del cliente
        Console.WriteLine("ingrese cedula: ");
        string cedula = Console.ReadLine();

        Console.WriteLine("ingrese nombre completo: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("ingrese correo: ");
        string correo = Console.ReadLine();

        Console.WriteLine("ingrese celular (10 digitos): ");
        string celular = Console.ReadLine();

        try
        {
            Cliente c = new Cliente(nombre, correo, celular, cedula);

            // Lo agregamos al restaurante
            r.AgregarCliente(c);

            Console.WriteLine("Cliente creado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // metodo para listar clientes de un restaurante
    public void ListarClientes()
    {
        Console.WriteLine("seleccione el restaurante por Nit: ");
        string nit = Console.ReadLine();

        Restaurante r = restaurantes.Buscar(x => x.Nit == nit);

        if (r == null)
        {
            Console.WriteLine("restaurante no encontrado");
            return;
        }

        r.ListarClientes();
    }

    // metodo para agregar un pedido a la cola de pendientes
    public void TomarPedido(Pedido pedido)
    {

        pedidosPendientes.Agregar(pedido);
        Console.WriteLine("pedido agregado correctamente a la cola de pendientes");
    }

    // metodo para despachar un pedido
    public void DespacharPedido()
    {
        if (pedidosPendientes.EstaVacia())
        {
            Console.WriteLine("no hay pedidos pendientes");
            return;
        }
        
        Pedido pedido = pedidosPendientes.Primero();
        pedidosPendientes.Eliminar();

        // Cambiamos el estado
        pedido.Despachar();

        // Lo guardamos en la pila de despachados
        pedidosDespachados.AgregarElemento(pedido);

        Console.WriteLine("pedido despachado correctamente");
    }

    // metodo para mostrar reporte diario
    public void Reportes()
    {
        Console.WriteLine("===== PEDIDOS DESPACHADOS =====");

        Pila<Pedido> aux = new Pila<Pedido>();

        decimal totalGanancias = 0;

        while (pedidosDespachados.Tamano > 0)
        {
            Pedido p = pedidosDespachados.Primero();
            pedidosDespachados.EliminarElemento();

            p.MostrarPedido();

            totalGanancias += p.Total;
            
            aux.AgregarElemento(p);
        }

        while (aux.Tamano > 0)
        {
            pedidosDespachados.AgregarElemento(aux.Primero());
            aux.EliminarElemento();
        }

        Console.WriteLine("Ganancias del dia: $" + totalGanancias);
    }
}
