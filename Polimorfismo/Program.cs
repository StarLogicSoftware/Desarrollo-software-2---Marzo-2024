


// POLIMOSFISMO
Perro perrito = new Perro();
Gato gatito = new Gato();

perrito.Hablar();
gatito.Hablar();


class Animal
{
    public string Nombre { get; set; }

    public virtual void Hablar()
    {
        Console.WriteLine("Animal hablando");
    }
}

class Perro : Animal
{
    public override void Hablar()
    {
        Console.WriteLine("Guau");

        base.Hablar();
    }
}

class Gato : Animal
{
    public override void Hablar()
    {
        base.Hablar();

        Console.WriteLine("Miau");
    }
}