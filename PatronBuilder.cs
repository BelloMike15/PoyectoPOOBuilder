// Producto: Pizza
public class Pizza
{
    public string Tipo { get; set; }
    public bool TieneSalsaTomate { get; set; }
    public bool TieneQueso { get; set; }
    public bool TienePepperoni { get; set; }
    // Otros atributos de la pizza...

    public override string ToString()
    {
        return $"Pizza {Tipo} - Salsa de Tomate: {TieneSalsaTomate}, Queso: {TieneQueso}, Pepperoni: {TienePepperoni}";
    }
}

// Builder: Interfaz para construir la pizza
public interface IPizzaBuilder
{
    void SeleccionarTipo(string tipo);
    void AgregarSalsaTomate();
    void AgregarQueso();
    void AgregarPepperoni();
    Pizza ObtenerPizza();
}

public class PizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza;

    public PizzaBuilder()
    {
        _pizza = new Pizza();
    }

    public void SeleccionarTipo(string tipo)
    {
        _pizza.Tipo = tipo;
    }

    public void AgregarSalsaTomate()
    {
        _pizza.TieneSalsaTomate = true;
    }

    public void AgregarQueso()
    {
        _pizza.TieneQueso = true;
    }

    public void AgregarPepperoni()
    {
        _pizza.TienePepperoni = true;
    }

    public Pizza ObtenerPizza()
    {
        return _pizza;
    }
}



// Director: Controla el proceso de construcción de la pizza
public class Pizzero
{
    private IPizzaBuilder _builder;

    public Pizzero(IPizzaBuilder builder)
    {
        _builder = builder;
    }

    public void ConstruirPizzaMargherita()
    {
        _builder.SeleccionarTipo("Margherita");
        _builder.AgregarSalsaTomate();
        _builder.AgregarQueso();
    }

    public void ConstruirPizzaPepperoni()
    {
        _builder.SeleccionarTipo("Pepperoni");
        _builder.AgregarSalsaTomate();
        _builder.AgregarQueso();
        _builder.AgregarPepperoni();
    }
}




// Uso del patrón Builder
public class Program
{
    public static void Main(string[] args)
    {
        // Crear un objeto Builder
        IPizzaBuilder builder = new PizzaBuilder();

        // Crear un objeto Director y pasarle el Builder
        Pizzero pizzero = new Pizzero(builder);

        // Construir una Pizza Margherita
        pizzero.ConstruirPizzaMargherita();
        Pizza pizzaMargherita = builder.ObtenerPizza();
        Console.WriteLine(pizzaMargherita.ToString());

        // Construir una Pizza de Pepperoni
        pizzero.ConstruirPizzaPepperoni();
        Pizza pizzaPepperoni = builder.ObtenerPizza();
        Console.WriteLine(pizzaPepperoni.ToString());

        // Resultado:
        // Pizza Margherita - Salsa de Tomate: True, Queso: True, Pepperoni: False
        // Pizza Pepperoni - Salsa de Tomate: True, Queso: True, Pepperoni: True
    }
}
