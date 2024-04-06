//Motor Fire = new Motor();
//Fire.Cilindrada = 1300;
//Fire.TipoCombustible = "Nafta";
//Fire.Peso = 120;

//Automovil Palio = new Automovil();
//Automovil Siena = new Automovil();

//Palio.motor = Fire;
//Siena.motor = Fire;

//Console.WriteLine($"Tipo de combustible del palio: { Palio.motor.TipoCombustible }");

//class Automovil
//{
//    public string Marca { get; set; }
//    public string Color { get; set; }

//    public Motor motor;
//}

//class Motor
//{
//    public int Cilindrada { get; set; }
//    public string TipoCombustible { get; set; }
//    public int Peso { get; set; }
//}






// Factura usando objetos combinados

// Segunda opcion
//PersonaJuridica emisor = new PersonaJuridica();
//emisor.RazonSocial = "Agenpia";

//PersonaJuridica receptor = new PersonaJuridica();
//emisor.RazonSocial = "Nicolas Fumo";


//Factura factura = new Factura();
//factura.Tipo = "A";

//factura.Emisor = new PersonaJuridica()
//{
//    RazonSocial = "Agenpia"
//};

//factura.Receptor = receptor;


// primera opcion
//Factura factura = new Factura();
//factura.Tipo = "A";
//factura.Emisor = emisor;
//factura.Receptor = receptor;








Factura factura = new Factura();
factura.Tipo = TipoFactura.FacturaA;
factura.Emisor.RazonSocial = "Agenpia";
factura.Receptor.RazonSocial = "Nicolas Fumo";

factura.CalcularTotal();

class Factura
{
    public Factura()
    {
        Emisor = new PersonaJuridica()
        {
            RazonSocial = "agenpia"
        };

        Receptor = new PersonaJuridica();
        Items = new List<ItemFactura>();

        Items.Add(new ItemFactura()
        {
            Nombre = "Cerveza",
            Precio = 1000,
            Cantidad = 5,
        });
        Items.Add(new ItemFactura()
        {
            Cantidad = 2,
            Precio = 1200,
            Nombre = "Mani"
        });
    }

    public TipoFactura Tipo;
    public int Total;
    public PersonaJuridica Emisor;
    public PersonaJuridica Receptor;
    public List<ItemFactura> Items;

    public void CalcularTotal()
    {
        int subTotal = 0;

        // Calculamos el subtotal de todos los item
        foreach (var item in Items)
        {
            int totalPorItem = item.Cantidad * item.Precio;
            subTotal += totalPorItem;

            //subTotal += item.Cantidad * item.Precio;
        }

        switch (Tipo)
        {
            case TipoFactura.FacturaA:
                float totalConIVA = subTotal * 1.21f;
                Console.WriteLine($"Total: {totalConIVA}");
                break;
            case TipoFactura.FacturaB:
                Console.WriteLine($"Total: {subTotal}");
                break;
        }
    }
}

class PersonaJuridica
{
    public string RazonSocial;
}

class ItemFactura
{
    public int Cantidad;
    public string Nombre;
    public int Precio;
}

enum TipoFactura
{
    FacturaA,
    FacturaB,
    FacturaC,
    FacturaZ
}