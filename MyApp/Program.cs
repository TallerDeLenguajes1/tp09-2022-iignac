using System.Text.Json;
using System.Text.Json.Serialization;

// Console.WriteLine("Ingrese la ruta de una carpeta:");
// string path = Console.ReadLine();

string path = Directory.GetCurrentDirectory();
string archivoJson = path + @"\index.json";
 
List<string> listaCarpetas = Directory.GetDirectories(path).ToList(); 
List<string> listaArchivos = Directory.GetFiles(path).ToList();
List<Archivo> listaArchivosObj = new List<Archivo>();

Console.WriteLine("----- Carpetas -----");
foreach (string carpetaX in listaCarpetas)
{
    Console.WriteLine(Path.GetFileNameWithoutExtension(carpetaX));
}

int i = 0; 
Console.WriteLine("\n----- Archivos -----");
foreach (string archivoX in listaArchivos)
{
    i++;
    FileInfo archivoXinfo = new FileInfo(archivoX);
    Archivo nuevoArchivo = new Archivo(i, Path.GetFileNameWithoutExtension(archivoX), archivoXinfo.Extension);
    listaArchivosObj.Add(nuevoArchivo);
    Console.WriteLine(Path.GetFileNameWithoutExtension(archivoX));
} 
crearJson();


void crearJson()
{
    FileStream fs = new FileStream(archivoJson, FileMode.Create);
    StreamWriter sw = new StreamWriter(fs);
    foreach (Archivo archivoX in listaArchivosObj)
    {
        sw.WriteLine(serializarArchivo(archivoX));
    }
    sw.Close();
    fs.Close();
}

string serializarArchivo(Archivo archivo)
{
    string stringJson = JsonSerializer.Serialize(archivo);
    return stringJson;
}