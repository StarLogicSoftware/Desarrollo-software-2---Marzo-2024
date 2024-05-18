

IRepositorio repo = new RepositorioVehiculos();

class RepositorioVehiculos : IRepositorio
{
    public void Guardar()
    {
        throw new NotImplementedException();
    }

    public void Obtener(string patente)
    {
        throw new NotImplementedException();
    }

    public void OtroMetodo()
    {

    }
}

class RepositorioString : IRepositorio, IBaseDatos
{
    public void AccederDB()
    {
        throw new NotImplementedException();
    }

    public void Guardar()
    {
        throw new NotImplementedException();
    }

    public void Obtener(string patente)
    {
        throw new NotImplementedException();
    }
}

class Vehiculo { }

interface IRepositorio
{
    void Obtener(string patente);

    void Guardar();
}

interface IBaseDatos
{
    void AccederDB();
}