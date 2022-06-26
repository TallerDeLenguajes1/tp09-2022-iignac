public class Producto
{
    string[] nombres = {"arroz", "queso", "jamon", "dulce de leche", "fideo", "salame"};
    string[] pesos = {"1kg", "1/2kg", "1/4kg"};

    private string nombre;
    private DateTime fechavencimiento;
    private float precio; //entre 1000 y 5000
    string peso;

    public Producto()
    {
        Random rnd = new Random();
        this.nombre = nombres[rnd.Next(6)];
        this.fechavencimiento = new DateTime(rnd.Next(2023,2025), rnd.Next(1,13), rnd.Next(1,31));
        this.precio = rnd.Next(1000, 5001);
        this.peso = pesos[rnd.Next(3)];
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public DateTime Fechavencimiento { get => fechavencimiento; set => fechavencimiento = value; }
    public float Precio { get => precio; set => precio = value; }
    public string Peso { get => peso; set => peso = value; }

    public void mostrarProducto()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Fecha vencimiento: " + fechavencimiento.ToShortDateString());
        Console.WriteLine("Precio: $" + precio);
        Console.WriteLine("Peso: " + peso);
    }
}