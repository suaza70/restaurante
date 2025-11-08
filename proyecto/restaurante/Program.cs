class Program
{
    static void Main(string[] args)
    {
        // ==============================================
        // CREACION DEL RESTAURANTE
        // ==============================================
        Restaurante miRestaurante = new Restaurante(
            "123456789", 
            "La Buena Mesa", 
            "Juan Perez", 
            "3123456789", 
            "Calle Falsa 123"
        );

        // ==============================================
        // CREACION DE CLIENTES USANDO LISTA ENLAZADA
        // ==============================================
        miRestaurante.Clientes.Agregar(new Cliente("Sebastian Suaza", "sebastian@email.com", "3001234567", "1001"));
        miRestaurante.Clientes.Agregar(new Cliente("Ana Gomez", "ana@email.com", "3009876543", "1002"));
        miRestaurante.Clientes.Agregar(new Cliente("Luis Ramirez", "luis@email.com", "3012345678", "1003"));

        // ==============================================
        // CREACION DEL MENU YA HECHO
        // ==============================================
        miRestaurante.Menu = new Menu();

        // ==============================================
        // ESTRUCTURAS DE PEDIDOS
        // ==============================================
        miRestaurante.PedidosPendientes = new Cola<Pedido>(); // cola FIFO
        miRestaurante.PedidosDespachados = new Pila<Pedido>(); // pila de historial

        int idPedidoActual = 1; // contador de pedidos
        bool salir = false;

        while (!salir)
        {
            // MENU PRINCIPAL
            Console.WriteLine("\n===== MENU PRINCIPAL =====");
            Console.WriteLine("1. Mostrar menu");
            Console.WriteLine("2. Listar clientes");
            Console.WriteLine("3. Tomar pedido");
            Console.WriteLine("4. Despachar pedido");
            Console.WriteLine("5. Mostrar pedidos pendientes");
            Console.WriteLine("6. Mostrar pedidos despachados");
            Console.WriteLine("7. Mostrar ganancias del dia");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opcion: ");

            string opcion = Console.ReadLine();

            switch(opcion)
            {
                case "1":
                    // Mostrar el menu completo
                    miRestaurante.Menu.MostrarMenu();
                    break;

                case "2":
                    // Listar clientes
                    Nodo<Cliente> actualCliente = miRestaurante.Clientes.Cabeza;
                    while (actualCliente != null)
                    {
                        Cliente c = actualCliente.Valor;
                        Console.WriteLine("Nombre: " + c.Nombre + " | Cedula: " + c.Cedula + " | Celular: " + c.Celular);
                        actualCliente = actualCliente.Siguiente;
                    }
                    break;

                case "3":
                    // Tomar pedido
                    Console.Write("Ingrese la cedula del cliente: ");
                    string cedulaCliente = Console.ReadLine();

                    Cliente clientePedido = miRestaurante.Clientes.Buscar(c => c.Cedula == cedulaCliente);
                    if (clientePedido == null)
                    {
                        Console.WriteLine("Cliente no encontrado");
                        break;
                    }

                    Pedido nuevoPedido = new Pedido(idPedidoActual++, clientePedido);

                    bool agregandoPlatos = true;
                    while (agregandoPlatos)
                    {
                        Console.Write("Ingrese codigo del plato (0 para terminar): ");
                        int codigo = int.Parse(Console.ReadLine());

                        if (codigo == 0)
                        {
                            agregandoPlatos = false;
                            break;
                        }

                        Plato platoSeleccionado = miRestaurante.Menu.BuscarPlato(codigo);
                        if (platoSeleccionado == null)
                        {
                            Console.WriteLine("Codigo de plato invalido");
                            continue;
                        }

                        Console.Write("Ingrese cantidad: ");
                        int cantidad = int.Parse(Console.ReadLine());

                        PlatoPedido pp = new PlatoPedido(platoSeleccionado.Codigo, cantidad, platoSeleccionado.Precio);
                        nuevoPedido.AgregarPlato(pp);
                    }

                    // Encolar el pedido
                    miRestaurante.PedidosPendientes.Agregar(nuevoPedido);
                    Console.WriteLine("Pedido registrado con exito");
                    break;

                case "4":
                    // Despachar pedido
                    if (!miRestaurante.PedidosPendientes.EstaVacia())
                    {
                        Pedido pedidoDespachar = miRestaurante.PedidosPendientes.Primero();
                        pedidoDespachar.Despachar();
                        miRestaurante.PedidosPendientes.Eliminar();
                        miRestaurante.PedidosDespachados.AgregarElemento(pedidoDespachar);
                        Console.WriteLine("Pedido despachado con exito");
                    }
                    else
                    {
                        Console.WriteLine("No hay pedidos pendientes");
                    }
                    break;

                case "5":
                    // Mostrar pedidos pendientes
                    Console.WriteLine("===== PEDIDOS PENDIENTES =====");
                    miRestaurante.PedidosPendientes.Imprimir();
                    break;

                case "6":
                    // Mostrar pedidos despachados
                    Console.WriteLine("===== PEDIDOS DESPACHADOS =====");
                    miRestaurante.PedidosDespachados.ImprimirPila();
                    break;

                case "7":
                    // Mostrar ganancias del dia
                    decimal ganancias = miRestaurante.CalcularGananciasDelDia();
                    Console.WriteLine("Ganancias del dia: $" + ganancias);
                    break;

                case "8":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
        }

        Console.WriteLine("Gracias por usar el sistema del restaurante");
    }
}
riteLine("Hello, World!");