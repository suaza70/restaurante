using System;

public class Plato
{
    private int codigo;
    private string nombre;
    private string descripcion;
    private decimal precio;

    // constructor
    public Plato(int codigo, string nombre, string descripcion, decimal precio)
    {
        // validacion: ningun campo debe estar vacio
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
        {
            throw new ArgumentException("ningun campo puede estar vacio");
        }

        if (precio <= 0)
        {
            // validacion: el precio debe ser mayor que cero
            throw new ArgumentException("el precio debe ser mayor que cero");
        }

        this.codigo = codigo;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.precio = precio;
    }
    
    public int Codigo
    {
        get { return this.codigo; }
    }
    
    public string Nombre
    {
        get { return this.nombre; }
        set { this.nombre = value; }
    }
    
    public string Descripcion
    {
        get { return this.descripcion; }
        set { this.descripcion = value; }
    }

    public decimal Precio
    {
        get { return this.precio; }
        set { this.precio = value; }
    }

    // metodo para mostrar la informacion del plato
    public void MostrarInfo()
    {
        Console.WriteLine("===== INFORMACION DEL PLATO =====");
        Console.WriteLine("codigo: " + this.codigo);
        Console.WriteLine("nombre: " + this.nombre);
        Console.WriteLine("descripcion: " + this.descripcion);
        Console.WriteLine("precio: " + this.precio);
        Console.WriteLine("=================================");
    }
}