public class Plato
{
    private int codigo;
    private string nombre;
    private string descripcion;
    private decimal precio;

    // Constructor
    public Plato(int codigo,  String nombre, String descripcion, decimal precio)
    {
        // validacion: ningun campo debe estar vacio
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
        {
            throw new ArgumentException("ningun campo puede estar vacio");
        }
        
        // validacion: el precio debe ser mayor que cero
        if (precio <= 0)
        {
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
    
    public void MostrarInfo()
    {
        Console.WriteLine("===== informacion del plato =====");
        Console.WriteLine("Codigo: " + this.codigo);
        Console.WriteLine("Nombre: " + this.nombre);
        Console.WriteLine("Descripcion: " + this.descripcion);
        Console.WriteLine("Precio: " + this.precio);
        Console.WriteLine("=================================");
    }
}   