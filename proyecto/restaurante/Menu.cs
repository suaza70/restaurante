public class Menu
{
    private ListaEnlazada<Plato> platos;
    private ListaEnlazada<Plato> bebidas;
    private ListaEnlazada<Plato> postres;

    // Constructor
    public Menu()
    {

        platos = new ListaEnlazada<Plato>();
        platos.Agregar(new Plato(1, "bandeja paisa", "arroz, frijoles, carne, chicharron, huevo", 25000));
        platos.Agregar(new Plato(2, "Ajiaco", "sopa tipica de pollo con papa criolla", 18000));
        platos.Agregar(new Plato(3, "sancocho de gallina", "sopa tradicional con gallina, yuca, platano y mazorca", 20000));
        platos.Agregar(new Plato(4, "arroz con pollo", "arroz con pollo desmechado, verduras y papas fritas", 17000));
        platos.Agregar(new Plato(5, "sobrebarriga en salsa", "carne blanda en salsa criolla con arroz y papa salada", 23000));

        bebidas = new ListaEnlazada<Plato>();
        bebidas.Agregar(new Plato(1, "jugo de mora", "jugo natural de mora en agua o leche", 6000));
        bebidas.Agregar(new Plato(2, "limonada natural", "limonada fresca con hielo y azucar", 5000));
        bebidas.Agregar(new Plato(3, "gaseosa", "bebida carbonatada en botella de 400ml", 4000));
        bebidas.Agregar(new Plato(4, "Agua en botella", "agua mineral sin gas", 3000));
        bebidas.Agregar(new Plato(5, "Cerveza", "cerveza nacional fria", 7000));

        postres = new ListaEnlazada<Plato>();
        postres.Agregar(new Plato(1, "flan de caramelo", "flan casero con salsa de caramelo", 7000));
        postres.Agregar(new Plato(2, "arroz con leche", "arroz con leche y canela al gusto", 6000));
        postres.Agregar(new Plato(3, "tiramisu", "postre italiano con cafe y queso mascarpone", 8500));
        postres.Agregar(new Plato(4, "helado", "helado de vainilla, chocolate o fresa", 5000));
        postres.Agregar(new Plato(5, "brownie con helado", "brownie de chocolate caliente con bola de helado", 9000));
    }

    // metodo para mostrar menu
    public void MostrarMenu()
    {
        Console.WriteLine("========== MENU DEL RESTAURANTE ==========\n");
        Console.WriteLine("---- PLATOS PRINCIPALES ----");
        MostrarLista(platos);
        Console.WriteLine("\n---- BEBIDAS ----");
        MostrarLista(bebidas);
        Console.WriteLine("\n---- POSTRES ----");
        MostrarLista(postres);
        Console.WriteLine("\n==========================================");
    }

    // metodo para imprimir menu
    private void MostrarLista(ListaEnlazada<Plato> lista)
    {
        Nodo<Plato> actual = lista.Cabeza;
        while (actual != null)
        {
            Plato p = actual.Valor;
            Console.WriteLine("Codigo: " + p.Codigo + " | " + p.Nombre + " - " + p.Descripcion + " ($" + p.Precio + ")");
            actual = actual.Siguiente;
        }
    }
}
