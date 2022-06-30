public class Producto
{
    private string nombre;
    private DateTime fechaVencimiento;
    private float precio; //entre 1000 y 5000
    private string peso;

    public Producto(string nombre, DateTime fechaVencimiento, float precio, string peso)
    {
        this.nombre = nombre;
        this.fechaVencimiento = fechaVencimiento;
        this.precio = precio;
        this.peso = peso;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
    public float Precio { get => precio; set => precio = value; }
    public string Peso { get => peso; set => peso = value; }

    public void mostrarProducto()
    {
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Fecha vencimiento: " + FechaVencimiento.ToShortDateString());
        Console.WriteLine("Precio: $" + Precio);
        Console.WriteLine("Peso: " + Peso);
    }
}