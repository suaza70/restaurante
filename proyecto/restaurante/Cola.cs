using System;

public class Cola<T>
{
    // nodo cabeza de la cola
    private Nodo<T> cabeza;
    // nodo final de la cola
    private Nodo<T> cola;
    // tamaño de la cola
    private int tamano;

    // constructor
    public Cola()
    {
        this.cabeza = null;
        this.cola = null;
        this.tamano = 0;
    }

    // metodo para agregar un elemento al final de la cola
    public void Agregar(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);

        if (EstaVacia())
        {
            this.cabeza = nuevoNodo;
            this.cola = nuevoNodo;
        }
        else
        {
            this.cola.Siguiente = nuevoNodo;
            this.cola = nuevoNodo;
        }
        this.tamano++;
    }

    // metodo para eliminar el primer elemento de la cola
    public void Eliminar()
    {
        if (EstaVacia())
        {
            Console.WriteLine("la cola esta vacia, no se puede eliminar");
            return;
        }

        this.cabeza = this.cabeza.Siguiente;
        this.tamano--;

        if (this.tamano == 0)
        {
            this.cola = null;
        }
    }

    // metodo para obtener el primer valor de la cola
    public T Primero()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("la cola esta vacia");
        }
        return this.cabeza.Valor;
    }

    // metodo para obtener el primer nodo de la cola
    public Nodo<T> PrimeroNodo()
    {
        return this.cabeza;
    }

    // obtener el tamaño de la cola
    public int Tamano
    {
        get { return this.tamano; }
    }

    // metodo para verificar si la cola esta vacia
    public bool EstaVacia()
    {
        return this.tamano == 0;
    }

    // metodo para imprimir los elementos de la cola
    public void Imprimir()
    {
        if (EstaVacia())
        {
            Console.WriteLine("la cola esta vacia");
            return;
        }

        Nodo<T> actual = this.cabeza;
        Console.Write("cola: ");
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}
