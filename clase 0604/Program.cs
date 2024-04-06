

Persona secretario = new Persona()
{
    Nombre = "Alex",
    Edad = 21,
};

secretario.Sueldo = 1000;
Console.WriteLine($"Sueldo: {secretario.Sueldo}");

class Persona
{
    public string Apellido { get; set; }
    public int MyProperty { get; set; }
    public string Nombre { get; set; }
    
    private string sueldo_privado;

    public int Sueldo
    {
        get
        {
            return int.Parse(sueldo_privado);
        }
        set
        {
            if(value < 0)
            {
                Console.WriteLine("No se puede asignar un sueldo negativo");
            }
            else
            {
                sueldo_privado = value.ToString();
            }
        }
    }

    //public void AsignarSueldo(int cantidad)
    //{
    //    if(cantidad > 0)
    //    {
    //        Sueldo += cantidad;
    //    }
    //    else
    //    {
    //        Console.WriteLine("No se puede cargar saldo negativo");
    //    }
    //}

    //public int ObtenerSueldo()
    //{
    //    return Sueldo;
    //}
}