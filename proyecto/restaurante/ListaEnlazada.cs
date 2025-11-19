using System;

public class ListaEnlazada<T>
{
    private Nodo<T> cabeza;
    private Nodo<T> ultimo;
    private int cantidad;
    
    public Nodo<T> Cabeza
    {
        get { return this.cabeza; }
    }

    //obtener el ultimo
    public Nodo<T> Ultimo
    {
        get { return this.ultimo; }
    }
    //obtener la cantidad
    public int Cantidad
    {
        get { return this.cantidad; }
    }

    // metodo para agregar un elemento al final de la lista
    public void Agregar(T valor)
    {
        Nodo<T> nuevo = new Nodo<T>(valor);
        if (this.cabeza == null)
        {
            this.cabeza = nuevo;
            this.ultimo = nuevo;
        }
        else
        {
            this.ultimo.Siguiente = nuevo;
            this.ultimo = nuevo;
        }
        this.cantidad++;
    }

    // metodo para imprimir los elementos de la lista
    public void Imprimir()
    {
        Nodo<T> actual = this.cabeza;
        Console.Write("lista: ");
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }

    // metodo para eliminar un elemento en una posicion
    public void EliminarPosicion(int posicion)
    {
        if (posicion < 0 || posicion >= this.cantidad || this.cabeza == null) return;

        if (posicion == 0)
        {
            this.cabeza = this.cabeza.Siguiente;
            if (this.cabeza == null) this.ultimo = null;
            this.cantidad--;
            return;
        }

        Nodo<T> actual = this.cabeza;
        for (int i = 0; i < posicion - 1; i++)
        {
            actual = actual.Siguiente;
        }

        actual.Siguiente = actual.Siguiente?.Siguiente;
        if (actual.Siguiente == null) this.ultimo = actual;
        this.cantidad--;
    }

    // metodo para insertar un elemento en una posicion
    public void InsertarEnPosicion(T valor, int posicion)
    {
        if (posicion < 0 || posicion > this.cantidad)
            throw new ArgumentOutOfRangeException("posicion invalida");

        Nodo<T> nuevo = new Nodo<T>(valor);

        if (posicion == 0)
        {
            nuevo.Siguiente = this.cabeza;
            this.cabeza = nuevo;
            if (this.cantidad == 0) this.ultimo = nuevo;
            this.cantidad++;
            return;
        }

        Nodo<T> actual = this.cabeza;
        for (int i = 0; i < posicion - 1; i++)
        {
            actual = actual.Siguiente;
        }

        nuevo.Siguiente = actual.Siguiente;
        actual.Siguiente = nuevo;
        if (nuevo.Siguiente == null) this.ultimo = nuevo;
        this.cantidad++;
    }

    // metodo para contar elementos
    public int Contar()
    {
        return this.cantidad;
    }

    // metodo para buscar un elemento segun condicion
    public T Buscar(Func<T, bool> condicion)
    {
        Nodo<T> actual = this.cabeza;
        while (actual != null)
        {
            if (condicion(actual.Valor))
                return actual.Valor;
            actual = actual.Siguiente;
        }
        return default(T);
    }
}
