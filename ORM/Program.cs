
// ORM -> Object Relational Mapping
// Entity Framework Core
using Microsoft.EntityFrameworkCore;


// CRUD -> Create, Read, Update, Delete

void Crear()
{
    Persona p = new Persona();
    p.Nombre = "Nicolas";
    p.Apellido = "Fumo";

    using (AppDbContext context = new AppDbContext())
    {
        context.Personas.Add(p);

        context.SaveChanges();
    }
}

void ObtenerPorId(int id)
{
    Persona p;

    using (AppDbContext context = new AppDbContext())
    {
        p = context.Personas.Where(x => x.Nombre == "nicolas").First();
    }
}

void ObtenerTodos()
{
    List<Persona> personas;

    using (AppDbContext context = new AppDbContext())
    {
        personas = context.Personas.ToList();
    }
}

void Actualizar(int id)
{
    Persona p;

    using (AppDbContext context = new AppDbContext())
    {
        p = context.Personas.Where(x => x.Id == id).First();

        p.Nombre = "Pepe";

        context.SaveChanges();
    }
}

void Eliminar(int id)
{
    Persona p;

    using (AppDbContext context = new AppDbContext())
    {
        p = context.Personas.Where(x => x.Id == id).First();

        context.Personas.Remove(p);

        context.SaveChanges();
    }
}

class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseInMemoryDatabase("Db");
    }

    // dice que a "Persona" Lo transforma en una tabla en la BD
    public DbSet<Persona> Personas { get; set; }
}

class Persona // Entidad -> Modelo
{
    public int Id { get; set; } // Por convencion se debe llamar "Id"
    public string Nombre { get; set; }
    public string Apellido { get; set; }
}