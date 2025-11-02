namespace restaurante;

public class Cola
{
using System;

public class Cola<T>
{
    private Nodo<T> cabeza;
    private Nodo<T> cola;   
    private int tamano;     
    
    public Cola()
    {
        cabeza = null;
        cola = null;
        tamano = 0;
    }

    // agregar un elemento al final de la cola
    public void Agregar(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);
        
        if (EstaVacia())
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else
        {
            cola.Siguiente = nuevoNodo;
            cola = nuevoNodo;
        }
        tamano++;
    }

    // eliminar el primer elemento de la cola
    public void Eliminar()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("La cola esta vacia.");
        }
        
        cabeza = cabeza.Siguiente;
        tamano--;
    }

    // retornar el primer elemento de la cola sin eliminarlo
    public T Primero()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("la cola esta vacia.");
        }
        return cabeza.Valor;
    }

    public int Tamano()
    {
        return tamano;
    }

    public bool EstaVacia()
    {
        return tamano == 0;
    }

    // imprimir todos los elementos de la cola
    public void Imprimir()
    {
        if (EstaVacia())
        {
            Console.WriteLine("la cola esta vacia.");
            return;
        }

        Nodo<T> actual = cabeza;
        Console.Write("cola: ");
        
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
    
}

}