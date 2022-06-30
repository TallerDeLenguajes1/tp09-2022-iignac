using System.Text.Json;
using System.Text.Json.Serialization;

string[] nombresProductos = {"arroz", "queso", "jamon", "dulce de leche", "fideo", "salame"};
string[] pesosProductos = {"1kg", "1/2kg", "1/4kg"};
Random rnd = new Random();
Producto nuevoProducto;
List<Producto> listaProductos = new List<Producto>();
int N;

do
{
    Console.WriteLine("==> Ingrese la cantidad de productos:");
    N = Convert.ToInt32(Console.ReadLine());
} while (N < 1);

for (int i = 0; i < N; i++)
{
    nuevoProducto = new Producto(nombresProductos[rnd.Next(6)], new DateTime(rnd.Next(2023,2025), rnd.Next(1,13), rnd.Next(1,31)), rnd.Next(1000,5001), pesosProductos[rnd.Next(3)]);
    listaProductos.Add(nuevoProducto);
}

string ruta = Directory.GetCurrentDirectory(); //ruta donde se guardará el archivo json
string archivoJson = ruta + @"/productos.json";
guardarEnJson();
List<Producto> listaProdDeserealizada = leerJson();
mostrarProductos(listaProdDeserealizada);


// ---- FUNCIONES ----

void guardarEnJson()
{
    using (FileStream fs = new FileStream(archivoJson, FileMode.Create)) //using evita usar Close()
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            string stringJson = JsonSerializer.Serialize(listaProductos);
            sw.WriteLine(stringJson);
        }
    }
}

List<Producto> leerJson()
{
    using (FileStream fs = new FileStream(archivoJson, FileMode.Open))
    {
        using (StreamReader sr = new StreamReader(fs))
        {
            string stringJson = sr.ReadToEnd();
            List<Producto> listaDeserealizada = JsonSerializer.Deserialize<List<Producto>>(stringJson);
            //var listaDeserializada = ...
            return listaDeserealizada;
        }
    }
}

void mostrarProductos(List<Producto>lista)
{   
    int i=0;
    foreach (Producto unProducto in lista)
    {
        i++;
        Console.WriteLine($"\n### PRODUCTO {i} ###");
        unProducto.mostrarProducto();
    }
}

// serializar: convertir un objeto (o una lista de objetos) en un texto (string) en formato json
// deresializar: guardar los datos del string en formato json en un objeto (o en una lista de objetos) de la clase correspondiente. Se debe definir la clase con el mismo formato que tiene el json

// GUARDAR EN JSON usando Close():
// void guardarEnJson()
// {
//     FileStream fs = new FileStream(archivoJson, FileMode.Create);
//     StreamWriter sw = new StreamWriter(fs);
//     string stringJson = JsonSerializer.Serialize(listaProductos);
//     sw.WriteLine(stringJson);
//     sw.Close();
//     fs.Close();
// }
//

// LEER JSON usando Close():
// List<Producto> leerJson()
// {
//     FileStream fs = new FileStream(archivoJson, FileMode.Open);
//     StreamReader sr = new StreamReader(fs);
//     string stringJson = sr.ReadToEnd();
//     List<Producto> listaDeserealizada = JsonSerializer.Deserialize<List<Producto>>(stringJson);
//     sr.Close();
//     fs.Close();
//     return listaDeserealizada;
// }

