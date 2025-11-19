using System;

// clase cliente representa a un cliente del sistema
public class Cliente
{
    private string nombre;
    private string correo;
    private string celular;
    private string cedula;

    // constructor
    public Cliente(string nombre, string correo, string celular, string cedula)
    {
        // validacion de campos vacios
        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(correo) ||
            string.IsNullOrWhiteSpace(celular) ||
            string.IsNullOrWhiteSpace(cedula))
        {
            throw new ArgumentException("ningun campo puede estar vacio");
        }
        // validacion de celular de 10 digitos
        if (celular.Length != 10 || !ulong.TryParse(celular, out _))
        {
            throw new ArgumentException("el numero de celular debe tener 10 digitos");
        }
        
        this.nombre = nombre;
        this.correo = correo;
        this.celular = celular;
        this.cedula = cedula;
    }
    
    public string Nombre
    {
        get { return this.nombre; }
        set { this.nombre = value; }
    }

    public string Correo
    {
        get { return this.correo; }
    }
    
    public string Celular
    {
        get { return this.celular; }
    }
    
    public string Cedula
    {
        get { return this.cedula; }
    }

    // metodo para mostrar los datos del cliente
    public void MostrarDatos()
    {
        Console.WriteLine("===== INFORMACION DEL CLIENTE =====");
        Console.WriteLine("nombre: " + this.nombre);
        Console.WriteLine("correo: " + this.correo);
        Console.WriteLine("celular: " + this.celular);
        Console.WriteLine("cedula: " + this.cedula);
        Console.WriteLine("===================================");
    }
}
