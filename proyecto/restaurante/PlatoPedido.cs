namespace restaurante;

public class PlatoPedido
{
    private int codigoPlato;
    private int cantidad;
    private decimal precioUnitario;
    
    public PlatoPedido(int codigoPlato, int cantidad, decimal precioUnitario )
    {

        // validacion: el precio debe ser mayor que cero
        if (precioUnitario <= 20000)
        {
            throw new ArgumentException("el precio minimo de pedido es de 20.000");
        }
        
        if (cantidad <= 2)
        {
            throw new ArgumentException("la cantidad minima de productos es 2");
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
}