using System;

public class Menu
{
    private ListaEnlazada<Plato> platos;
    private ListaEnlazada<Plato> bebidas;
    private ListaEnlazada<Plato> postres;

    // constructor del menu con datos
    public Menu()
    {
        this.platos = new ListaEnlazada<Plato>();
        this.platos.Agregar(new Plato(1, "bandeja paisa", "arroz, frijoles, carne, chicharron, huevo", 25000));
        this.platos.Agregar(new Plato(2, "ajiaco", "sopa tipica de pollo con papa criolla", 18000));
        this.platos.Agregar(new Plato(3, "sancocho de gallina", "sopa tradicional con gallina, yuca, platano y mazorca", 20000));
        this.platos.Agregar(new Plato(4, "arroz con pollo", "arroz con pollo desmechado, verduras y papas fritas", 17000));
        this.platos.Agregar(new Plato(5, "sobrebarriga en salsa", "carne blanda en salsa criolla con arroz y papa salada", 23000));

        this.bebidas = new ListaEnlazada<Plato>();
        this.bebidas.Agregar(new Plato(6, "jugo de mora", "jugo natural de mora en agua o leche", 6000));
        this.bebidas.Agregar(new Plato(7, "limonada natural", "limonada fresca con hielo y azucar", 5000));
        this.bebidas.Agregar(new Plato(8, "gaseosa", "bebida carbonatada en botella de 400 ml", 4000));
        this.bebidas.Agregar(new Plato(9, "agua en botella", "agua mineral sin gas", 3000));
        this.bebidas.Agregar(new Plato(10, "cerveza", "cerveza nacional fria", 7000));

        this.postres = new ListaEnlazada<Plato>();
        this.postres.Agregar(new Plato(11, "flan de caramelo", "flan casero con salsa de caramelo", 7000));
        this.postres.Agregar(new Plato(12, "arroz con leche", "arroz con leche y canela al gusto", 6000));
        this.postres.Agregar(new Plato(13, "tiramisú", "postre italiano con cafe y queso mascarpone", 8500));
        this.postres.Agregar(new Plato(14, "helado", "helado de vainilla, chocolate o fresa", 5000));
        this.postres.Agregar(new Plato(15, "brownie con helado", "brownie de chocolate caliente con bola de helado", 9000));
    }

    // metodo para mostrar el menu completo
    public void MostrarMenu()
    {
        Console.WriteLine("========== MENU DEL RESTAURANTE ==========");
        Console.WriteLine();
        Console.WriteLine("---- PLATOS PRINCIPALES ----");
        MostrarLista(this.platos);
        Console.WriteLine();
        Console.WriteLine("---- BEBIDAS ----");
        MostrarLista(this.bebidas);
        Console.WriteLine();
        Console.WriteLine("---- POSTRES ----");
        MostrarLista(this.postres);
        Console.WriteLine();
        Console.WriteLine("==========================================");
    }

    // metodo para mostrar lista de platos
    private void MostrarLista(ListaEnlazada<Plato> lista)
    {
        Nodo<Plato> actual = lista.Cabeza;
        while (actual != null)
        {
            Plato p = actual.Valor;
            Console.WriteLine("codigo: " + p.Codigo + " | nombre: " + p.Nombre + " | descripcion: " + p.Descripcion + " | precio: " + p.Precio);
            actual = actual.Siguiente;
        }
    }
}
