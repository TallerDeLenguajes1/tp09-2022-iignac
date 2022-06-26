using System.Text.Json;
using System.Text.Json.Serialization;

int N;
do
{
    Console.WriteLine("==> Ingrese la cantidad de productos:");
    N = Convert.ToInt32(Console.ReadLine());
} while (N < 1);

List<Producto> listaProductos = new List<Producto>();
for (int i = 0; i < N; i++)
{
    Producto nuevoProducto = new Producto();
    listaProductos.Add(nuevoProducto);
}


string ruta = Directory.GetCurrentDirectory(); // ruta donde se guardará el archivo json
string archivojson = ruta + @"/productos.json";

//guardar en json
using (FileStream fs = new FileStream(archivojson, FileMode.Create))
{
    using (StreamWriter sw = new StreamWriter(fs))
    {
        string stringJson = JsonSerializer.Serialize(listaProductos);
        sw.WriteLine(stringJson);
    }
}

//leer json
using (FileStream fs = new FileStream(archivojson, FileMode.Open) )
{
    //List<Producto>? listaDeserializada;
    using (StreamReader sr = new StreamReader(fs))
    {
        string datosLeidos = sr.ReadToEnd();
        var listaDeserializada = JsonSerializer.Deserialize<List<Producto>>(datosLeidos);
        int i = 0;
        foreach (Producto productoX in listaDeserializada)
        {
            i++;
            Console.WriteLine($"\n### PRODUCTO {i} ###");
            productoX.mostrarProducto();
        }
    }
}