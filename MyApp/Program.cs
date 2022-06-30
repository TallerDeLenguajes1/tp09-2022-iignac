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
    FileStream fs = new FileStream(archivoJson, FileMode.Create); //creo el archivo json (si existe se sobreescribe con uno nuevo)
    StreamWriter sw = new StreamWriter(fs); //tomo control del archivo json para poder escribirlo
    sw.WriteLine(serializarLista()); // escribo el string en el archivo json
    sw.Close();
    fs.Close();
}

string serializarLista()
{
    string stringJson = JsonSerializer.Serialize(listaArchivosObj); //serializar: convertir una "lista de objetos"  o "un objeto" a un "string"
    return stringJson;
}


// crear Json usando "using": evita usar Close()
// using (FileStream fs = new FileStream(archivoJson, FileMode.Create))
// {
//     using (StreamWriter sw = new StreamWriter(fs))
//     {
//         string stringJson = JsonSerializer.Serialize(listaArchivosObj);
//         sw.WriteLine(stringJson);
//     }
// }


// serializar por cada elemento de la lista (da un error en el json):
// void crearJson()
// {
//     FileStream fs = new FileStream(archivoJson, FileMode.Create);
//     StreamWriter sw = new StreamWriter(fs);
//     foreach (Archivo archivoX in listaArchivosObj)
//     {
//         sw.WriteLine(serializarArchivo(archivoX));
//     }
//     sw.Close();
//     fs.Close();
// }