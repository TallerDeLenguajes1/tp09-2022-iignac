public class Archivo
{
    private int nroRegistro;
    private string nombre;
    private string extension;

    public Archivo(int nro, string nomb, string ext)
    {
        this.nroRegistro = nro;
        this.nombre = nomb;
        this.extension = ext;
    }

    public int NroRegistro { get => nroRegistro; }
    public string Nombre { get => nombre; }
    public string Extension { get => extension; }
}