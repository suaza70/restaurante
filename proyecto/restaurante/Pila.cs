using System;

public class Pila<T>
{
    private Nodo<T> cima;
    private int tamano;
    
    public int Tamano
    {
        get { return this.tamano; }
    }

    // metodo para agregar un elemento a la pila
    public void AgregarElemento(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);

        if (this.cima == null)
        {
            this.cima = nuevoNodo;
        }
        else
        {
            nuevoNodo.Siguiente = this.cima;
            this.cima = nuevoNodo;
        }
        this.tamano++;
    }

    // metodo para eliminar el elemento en la cima de la pila
    public void EliminarElemento()
    {
        if (this.cima != null)
        {
            this.cima = this.cima.Siguiente;
            this.tamano--;
        }
        else
        {
            Console.WriteLine("la pila esta vacia, no se puede eliminar");
        }
    }

    // metodo para obtener el primer elemento de la pila
    public T Primero()
    {
        if (this.cima == null)
        {
            throw new InvalidOperationException("la pila esta vacia");
        }
        return this.cima.Valor;
    }

    // metodo para obtener el nodo cima
    public Nodo<T> CimaNodo()
    {
        return this.cima;
    }

    // metodo para imprimir los elementos de la pila
    public void ImprimirPila()
    {
        if (this.cima == null)
        {
            Console.WriteLine("la pila esta vacia");
            return;
        }

        Nodo<T> nodoActual = this.cima;
        Console.WriteLine("contenido de la pila:");
        while (nodoActual != null)
        {
            Console.WriteLine("- " + nodoActual.Valor);
            nodoActual = nodoActual.Siguiente;
        }
        Console.WriteLine();
    }

    // metodo para imprimir la pila al reves
    public void ImprimirAlReves()
    {
        Pila<T> pilaAuxiliar = new Pila<T>();

        Nodo<T> cursor = this.cima;
        while (cursor != null)
        {
            pilaAuxiliar.AgregarElemento(cursor.Valor);
            cursor = cursor.Siguiente;
        }

        pilaAuxiliar.ImprimirPila();
    }
}
