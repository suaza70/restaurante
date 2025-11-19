using System;

public class Program
{
    public static void Main()
    {
        SistemaRestaurante sistema = new SistemaRestaurante();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("===== SOSTEMAS DE RESTAURANTE =====");
            Console.WriteLine("1. restaurante");
            Console.WriteLine("2. clientes");
            Console.WriteLine("3. pedidos");
            Console.WriteLine("4. reportes");
            Console.WriteLine("0. salir");
            Console.WriteLine("==================================");
            Console.Write("seleccione una opcion: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": // restaurante
                    bool regresarRest = false;
                    while (!regresarRest)
                    {
                        Console.WriteLine("===== MENU RESTAURANTE =====");
                        Console.WriteLine("1. crear restaurante");
                        Console.WriteLine("0. regresar");
                        Console.WriteLine("============================");
                        Console.Write("seleccione una opcion: ");
                        string opRest = Console.ReadLine();

                        switch (opRest)
                        {
                            case "1":
                                Console.Write("ingrese nit: ");
                                string nit = Console.ReadLine();
                                Console.Write("ingrese nombre: ");
                                string nombre = Console.ReadLine();
                                Console.Write("ingrese dueño: ");
                                string dueno = Console.ReadLine();
                                Console.Write("ingrese celular: ");
                                string celular = Console.ReadLine();
                                Console.Write("ingrese direccion: ");
                                string direccion = Console.ReadLine();

                                Restaurante r = new Restaurante(nit, nombre, dueno, celular, direccion);
                                sistema.AgregarRestaurante(r);
                                Console.WriteLine("restaurante creado correctamente");
                                break;
                            case "0":
                                regresarRest = true;
                                break;
                            default:
                                Console.WriteLine("opcion invalida");
                                break;
                        }
                    }
                    break;

                case "2": // clientes
                    bool regresarCli = false;
                    while (!regresarCli)
                    {
                        Console.WriteLine("===== MENU DE CKIENTES =====");
                        Console.WriteLine("1. crear cliente");
                        Console.WriteLine("2. editar cliente");
                        Console.WriteLine("3. borrar cliente");
                        Console.WriteLine("4. listar clientes");
                        Console.WriteLine("0. regresar");
                        Console.WriteLine("==========================");
                        Console.Write("seleccione una opcion: ");
                        string opCli = Console.ReadLine();

                        switch (opCli)
                        {
                            case "1":
                                Console.Write("ingrese nombre: ");
                                string nombreCliente = Console.ReadLine();
                                Console.Write("ingrese correo: ");
                                string correoCliente = Console.ReadLine();
                                Console.Write("ingrese celular: ");
                                string celularCliente = Console.ReadLine();
                                Console.Write("ingrese cedula: ");
                                string cedulaCliente = Console.ReadLine();

                                Cliente c = new Cliente(nombreCliente, correoCliente, celularCliente, cedulaCliente);
                                sistema.AgregarCliente(c);
                                Console.WriteLine("cliente creado correctamente");
                                break;

                            case "2":
                                Console.Write("ingrese cedula del cliente a editar: ");
                                string cedulaEditar = Console.ReadLine();
                                Cliente clienteEditar = sistema.BuscarCliente(cedulaEditar);
                                if (clienteEditar == null)
                                {
                                    Console.WriteLine("cliente no encontrado");
                                    break;
                                }
                                Console.Write("nuevo nombre: ");
                                clienteEditar.Nombre = Console.ReadLine();
                                Console.WriteLine("cliente editado correctamente");
                                break;

                            case "3":
                                Console.Write("ingrese cedula del cliente a borrar: ");
                                string cedulaBorrar = Console.ReadLine();
                                break;

                            case "4":
                                sistema.ListarClientes();
                                break;

                            case "0":
                                regresarCli = true;
                                break;

                            default:
                                Console.WriteLine("opcion invalida");
                                break;
                        }
                    }
                    break;

                case "3": // pedidos
                    bool regresarPed = false;
                    while (!regresarPed)
                    {
                        Console.WriteLine("===== MENU PEDIDOS =====");
                        Console.WriteLine("1. tomar pedido");
                        Console.WriteLine("2. despachar pedido");
                        Console.WriteLine("0. regresar");
                        Console.WriteLine("=========================");
                        Console.Write("seleccione una opcion: ");
                        string opPed = Console.ReadLine();

                        switch (opPed)
                        {
                            case "1":
                                Console.Write("ingrese nit del restaurante: ");
                                string nitRest = Console.ReadLine();
                                Restaurante restaurantePedido = sistema.BuscarRestaurante(nitRest);
                                if (restaurantePedido == null)
                                {
                                    Console.WriteLine("restaurante no encontrado");
                                    break;
                                }

                                Console.Write("ingrese cedula del cliente: ");
                                string cedulaPedido = Console.ReadLine();
                                Cliente clientePedido = sistema.BuscarCliente(cedulaPedido);
                                if (clientePedido == null)
                                {
                                    Console.WriteLine("cliente no encontrado");
                                    break;
                                }

                                Console.Write("ingrese id del pedido: ");
                                int idPedido = int.Parse(Console.ReadLine());
                                Pedido pedido = new Pedido(idPedido, clientePedido);

                                bool agregarMas = true;
                                while (agregarMas)
                                {
                                    restaurantePedido.MostrarMenu();
                                    Console.Write("ingrese codigo del plato: ");
                                    int codigoPlato = int.Parse(Console.ReadLine());
                                    Console.Write("ingrese cantidad: ");
                                    int cantidad = int.Parse(Console.ReadLine());
                                    Console.Write("ingrese precio unitario: ");
                                    decimal precioUnitario = decimal.Parse(Console.ReadLine());

                                    PlatoPedido platoPedido = new PlatoPedido(codigoPlato, cantidad, precioUnitario);
                                    pedido.AgregarPlato(platoPedido);

                                    Console.Write("desea agregar otro plato? (s/n): ");
                                    string resp = Console.ReadLine();
                                    agregarMas = resp.ToLower() == "s";
                                }

                                Console.WriteLine("total del pedido: " + pedido.Total);
                                Console.Write("confirmar pedido? (s/n): ");
                                string confirmar = Console.ReadLine();
                                if (confirmar.ToLower() == "s")
                                {
                                    restaurantePedido.TomarPedido(pedido);
                                    Console.WriteLine("pedido tomado correctamente");
                                }
                                else
                                {
                                    Console.WriteLine("pedido cancelado");
                                }
                                break;

                            case "2":
                                Console.Write("ingrese nit del restaurante: ");
                                string nitDespacho = Console.ReadLine();
                                Restaurante restauranteDespacho = sistema.BuscarRestaurante(nitDespacho);
                                if (restauranteDespacho == null)
                                {
                                    Console.WriteLine("restaurante no encontrado");
                                    break;
                                }
                                restauranteDespacho.DespacharPedido();
                                break;

                            case "0":
                                regresarPed = true;
                                break;

                            default:
                                Console.WriteLine("opcion invalida");
                                break;
                        }
                    }
                    break;

                case "4": // reportes
                    bool regresarRep = false;
                    while (!regresarRep)
                    {
                        Console.WriteLine("===== MENU REPORTES =====");
                        Console.WriteLine("1. mostrar pedidos pendientes");
                        Console.WriteLine("2. mostrar pedidos despachados");
                        Console.WriteLine("3. mostrar ganancias del dia");
                        Console.WriteLine("4. mostrar platos servidos");
                        Console.WriteLine("0. regresar");
                        Console.WriteLine("==========================");
                        Console.Write("seleccione una opcion: ");
                        string opRep = Console.ReadLine();

                        switch (opRep)
                        {
                            case "1":
                                Console.Write("ingrese nit del restaurante: ");
                                string nitPend = Console.ReadLine();
                                Restaurante restPend = sistema.BuscarRestaurante(nitPend);
                                if (restPend != null) restPend.MostrarPedidosPendientes();
                                else Console.WriteLine("restaurante no encontrado");
                                break;

                            case "2":
                                Console.Write("ingrese nit del restaurante: ");
                                string nitDesp = Console.ReadLine();
                                Restaurante restDesp = sistema.BuscarRestaurante(nitDesp);
                                if (restDesp != null) restDesp.MostrarPedidosDespachados();
                                else Console.WriteLine("restaurante no encontrado");
                                break;

                            case "3":
                                Console.Write("ingrese nit del restaurante: ");
                                string nitGan = Console.ReadLine();
                                Restaurante restGan = sistema.BuscarRestaurante(nitGan);
                                if (restGan != null)
                                    Console.WriteLine("ganancias del dia: " + restGan.CalcularGananciasDelDia());
                                else Console.WriteLine("restaurante no encontrado");
                                break;

                            case "4":
                                Console.WriteLine("cantidades de platos servidos");
                                break;

                            case "0":
                                regresarRep = true;
                                break;

                            default:
                                Console.WriteLine("opcion invalida");
                                break;
                        }
                    }
                    break;

                case "0":
                    salir = true;
                    Console.WriteLine("saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("opcion invalida, intente de nuevo");
                    break;
            }
        }
    }
}
