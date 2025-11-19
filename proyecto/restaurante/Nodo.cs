public class Nodo<T>
{
    private T valor;
    private Nodo<T> siguiente;

    // constructor inicia el nodo con un valor
    public Nodo(T valor)
    {
        this.valor = valor;
        this.siguiente = null;
    }
    
    public T Valor
    {
        get { return this.valor; }
        set { this.valor = value; }
    }

    // obtener el siguiente nodo
    public Nodo<T> Siguiente
    {
        get { return this.siguiente; }
        set { this.siguiente = value; }
    }
}