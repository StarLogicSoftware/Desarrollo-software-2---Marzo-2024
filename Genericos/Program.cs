
int dato1, dato2;

GestorRespuesta respuestaMetodo;

Console.Write("Primer numero: ");
dato1 = int.Parse(Console.ReadLine());

Console.Write("Segundo numero: ");
dato2 = int.Parse(Console.ReadLine());

respuestaMetodo = Dividir(dato1, dato2);

if (respuestaMetodo.HayError)
{
    Console.WriteLine($"El resultado es: {respuestaMetodo.Error}");
}
else
{
    Console.WriteLine($"El resultado es: {respuestaMetodo.Resultado}");
}

GestorRespuesta Dividir(int a, int b)
{
    if (b == 0)
    {
        return new GestorRespuesta<int,string>(true, "No se peude divir por cero");
    }
    else if (b < 0)
    {
        return new GestorRespuesta<string,string>(true, "No se puede divir por un valor menor que cero");
    }
    else
    {
        int resultado = a / b;
        return new GestorRespuesta<int,string>(false, resultado);
    }
}

class GestorRespuesta<Tipo,T2>
{

    public Tipo Resultado;
    public T2 Error;
    public bool HayError;
    public GestorRespuesta(bool hayError, T2 mensajeError)
    {
        HayError = hayError;
        Error = mensajeError;
    }

    public GestorRespuesta(bool hayError, Tipo resultado)
    {
        HayError = hayError;
        Resultado = resultado;
    }

}