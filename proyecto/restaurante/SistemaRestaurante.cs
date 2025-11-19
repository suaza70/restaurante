using System;

public class SistemaRestaurante
{
    private ListaEnlazada<Restaurante> restaurantes;
    private ListaEnlazada<Cliente> clientes;

    // constructor 
    public SistemaRestaurante()
    {
        this.restaurantes = new ListaEnlazada<Restaurante>();
        this.clientes = new ListaEnlazada<Cliente>();
    }

    // metodo para agregar un restaurante
    public void AgregarRestaurante(Restaurante r)
    {
        if (r == null) throw new ArgumentNullException("restaurante no puede ser nulo");
        this.restaurantes.Agregar(r);
    }

    // metodo para listar restaurantes
    public void ListarRestaurantes()
    {
        Nodo<Restaurante> actual = this.restaurantes.Cabeza;
        Console.WriteLine("===== LISTA DE RESTAURANTE =====");
        if (actual == null)
        {
            Console.WriteLine("no hay restaurantes registrados");
        }
        while (actual != null)
        {
            Restaurante r = actual.Valor;
            Console.WriteLine("nit: " + r.Nit + " | nombre: " + r.Nombre + " | dueño: " + r.Dueno + " | celular: " + r.Celular + " | direccion: " + r.Direccion);
            actual = actual.Siguiente;
        }
        Console.WriteLine("=================================");
    }

    // metodo para agregar un cliente
    public void AgregarCliente(Cliente c)
    {
        if (c == null) throw new ArgumentNullException("cliente no puede ser nulo");
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
        Console.WriteLine("=================================");
    }
    
    // metodo para buscar restaurante por nit
    public Restaurante BuscarRestaurante(string nit)
    {
        Nodo<Restaurante> actual = this.restaurantes.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Nit == nit)
                return actual.Valor;
            actual = actual.Siguiente;
        }
        return null;
    }

// metodo para buscar cliente por cedula
    public Cliente BuscarCliente(string cedula)
    {
        Nodo<Cliente> actual = this.clientes.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Cedula == cedula)
                return actual.Valor;
            actual = actual.Siguiente;
        }
        return null;
    }

}
