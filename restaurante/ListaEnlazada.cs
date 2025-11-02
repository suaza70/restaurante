using System;

public class ListaEnlazada<T>
{
    private Nodo<T> cabeza;
    private Nodo<T> ultimo;
    private int cantidad = 0;

    public Nodo<T> Cabeza => cabeza;
    public Nodo<T> Ultimo => ultimo;
    public int Cantidad => cantidad;

    // agregar al final
    public void Agregar(T valor)
    {
        var nuevo = new Nodo<T>(valor);
        cantidad++;

        if (cabeza == null)
        {
            cabeza = nuevo;
            ultimo = nuevo;
            return;
        }

        ultimo.Siguiente = nuevo;
        ultimo = nuevo;
    }

    // imprimir lista
    public void Imprimir()
    {
        Nodo<T> actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }

    // eliminar por posicion
    public void EliminarPosicion(int posicion)
    {
        if (posicion < 0 || posicion >= cantidad || cabeza == null)
            return;

        cantidad--;

        if (posicion == 0)
        {
            cabeza = cabeza.Siguiente;
            if (cabeza == null) ultimo = null; // lista quedo vacía
            return;
        }

        Nodo<T> actual = cabeza;
        for (int i = 0; i < posicion - 1; i++)
            actual = actual.Siguiente;

        actual.Siguiente = actual.Siguiente?.Siguiente;

        if (actual.Siguiente == null)
            ultimo = actual;
    }

    // insertar en posicion
    public void InsertarEnPosicion(T valor, int posicion)
    {
        if (posicion < 0 || posicion > cantidad)
            throw new ArgumentOutOfRangeException("Posicion invalida");

        var nuevo = new Nodo<T>(valor);

        if (posicion == 0)
        {
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
            if (cantidad == 0) ultimo = nuevo;
            cantidad++;
            return;
        }

        Nodo<T> actual = cabeza;
        for (int i = 0; i < posicion - 1; i++)
            actual = actual.Siguiente;

        nuevo.Siguiente = actual.Siguiente;
        actual.Siguiente = nuevo;

        if (nuevo.Siguiente == null)
            ultimo = nuevo;

        cantidad++;
    }

    // contar elementos
    public int Contar()
    {
        return cantidad;
    }
    
    // buscar elementos
    public T Buscar(Func<T, bool> condicion)
    {
        Nodo<T> actual = cabeza;
        while (actual != null)
        {
            if (condicion(actual.Valor))
                return actual.Valor;
            actual = actual.Siguiente;
        }
        return default;
    }
