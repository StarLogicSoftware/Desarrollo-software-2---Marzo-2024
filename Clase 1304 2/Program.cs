

Console.WriteLine("Ingrese un numero");

try
{
    int divisor = int.Parse(Console.ReadLine());

    if(divisor == 0)
    {
        // Se dispara una excepcion "personalizada"
        throw new Exception("Trataste de hacer una division por cero, no sea tonto");
    }

    int resultado = 20 / divisor;
    Console.WriteLine($"Resultado: {resultado}");
}
catch (FormatException ex)
{
    Console.WriteLine("Lo que ingresaste no es un numero valido");
}
catch(DivideByZeroException ex)
{
    Console.WriteLine("Trataste de dividir por cero");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Este codigo deberia de ejecutarse siempre!");
}