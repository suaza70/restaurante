namespace restaurante;

public class Pila
{
namespace Listas;

public class Pila<T>
{
    // nodo superior de la pila
    private Nodo<T> cima;
    private int tamano;
    public int Tamano
    
    {
        get { return this.tamano; }
    }

    // metodo para agregar un nuevo elemento a la pila
    public void AgregarElemento(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor); 

        if (cima == null)
        {
            // Si la pila está vacia, el nuevo nodo sera la cima
            cima = nuevoNodo;
        }
        else
        {
            nuevoNodo.Siguiente = cima;
            cima = nuevoNodo;
        }
        tamano++;
    }

    // metodo para eliminar el elemento superior de la pila
    public void EliminarElemento()
    {
        if (cima != null)
        {
            cima = cima.Siguiente;
            tamano--;
        }
        else
        {
            Console.WriteLine("la pila está vacia, no se puede eliminar.");
        }
    }

    // metodo para imprimir los elementos de la pila
    public void ImprimirPila()
    {
        if (cima == null)
        {
            Console.WriteLine("la pila esta vacia");
            return;
        }

        Nodo<T> nodoActual = cima;
        Console.WriteLine("contenido de la pila: ");
        while (nodoActual != null)
        {
            Console.WriteLine("- " + nodoActual.Valor);
            nodoActual = nodoActual.Siguiente;
        }
        Console.WriteLine();
    }

    // metodo para imprimir la pila en orden inverso
    public void ImprimirAlReves()
    {
        Pila<T> pilaAuxiliar = new Pila<T>();
        
        while (cima != null)
        {
            pilaAuxiliar.AgregarElemento(cima.Valor);
            EliminarElemento();
        }
        
        pilaAuxiliar.ImprimirPila();
    }
}

}