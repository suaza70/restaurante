using System;

public class PlatoPedido
{
    private int codigoPlato;
    private int cantidad;
    private decimal precioUnitario;

    // constructor que inicia el plato pedido con sus datos
    public PlatoPedido(int codigoPlato, int cantidad, decimal precioUnitario)
    {
        if (precioUnitario <= 20000)
        {
            throw new ArgumentException("el precio total debe ser mayor que 20.000");
        }

        if (cantidad <= 1)
        {
            throw new ArgumentException("la cantidad minima es de dos productos");
        }

        this.codigoPlato = codigoPlato;
        this.cantidad = cantidad;
        this.precioUnitario = precioUnitario;
    }
    
    public int CodigoPlato
    {
        get { return this.codigoPlato; }
        set { this.codigoPlato = value; }
    }
    
    public int Cantidad
    {
        get { return this.cantidad; }
        set { this.cantidad = value; }
    }
    
    public decimal PrecioUnitario
    {
        get { return this.precioUnitario; }
        set { this.precioUnitario = value; }
    }

    // metodo para mostrar la informacion del plato pedido
    public void MostrarInfo()
    {
        Console.WriteLine("===== INFORMACION DEL PLATO PEDIDO =====");
        Console.WriteLine("codigo plato: " + this.codigoPlato);
        Console.WriteLine("cantidad: " + this.cantidad);
        Console.WriteLine("precio total: " + (this.precioUnitario * this.cantidad));
        Console.WriteLine("========================================");
    }
}