
// ORM -> Object Relational Mapping
// Entity Framework Core
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var personas = ObtenerTodos();

foreach (var item in personas)
{
    Console.WriteLine($"id: {item.Id} - data: {item.Nombre},{item.Apellido} ");
}

var personaAModificar = ObtenerPorId(2);

personaAModificar.Apellido = "Gonzalez";

var personaModificada = Actualizar(personaAModificar);



personas = ObtenerTodos();

foreach (var item in personas)
{
    Console.WriteLine($"id: {item.Id} - data: {item.Nombre},{item.Apellido} ");
}

Persona Crear(Persona p)
{
    using (AppDbContext context = new AppDbContext())
    {
        context.Database.EnsureCreated();

        context.Personas.Add(p);

        context.SaveChanges();
    }

    return p;
}

Persona ObtenerPorId(int id)
{
    Persona p;

    using (AppDbContext context = new AppDbContext())
    {
        p = context.Personas.Where(x => x.Id == id).First();
    }

    return p;
}

List<Persona> ObtenerTodos()
{
    List<Persona> personas;

    using (AppDbContext context = new AppDbContext())
    {
        personas = context.Personas.ToList();
    }

    return personas;
}

Persona Actualizar(Persona p)
{
    using (AppDbContext context = new AppDbContext())
    {
        context.Personas.Update(p);

        context.SaveChanges();
    }

    return p;
}

void Eliminar(Persona p)
{
    using (AppDbContext context = new AppDbContext())
    {
        context.Personas.Remove(p);

        context.SaveChanges();
    }
}

class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("Data Source=datos.db");
    }

    // dice que a "Persona" Lo transforma en una tabla en la BD
    public DbSet<Persona> Personas { get; set; }
}

class BaseEntidad
{
    public int Id { get; set; }
}

class Persona : BaseEntidad // Entidad -> Modelo
{
    [Required(ErrorMessage = "El nombre de la persona es requerido")]
    public string Nombre { get; set; }
    [Required]
    [MaxLength(25)]
    public string Apellido { get; set; }
    public string Direccion { get; set; }
}

class RepositorioGenerico<T> where T : BaseEntidad
{
    public T Crear(T p)
    {
        using (AppDbContext context = new AppDbContext())
        {
            context.Database.EnsureCreated();

            context.Set<T>().Add(p);

            context.SaveChanges();
        }

        return p;
    }

    public T ObtenerPorId(int id)
    {
        T p;

        using (AppDbContext context = new AppDbContext())
        {
            p = context.Set<T>().Where(x => x.Id == id).First();
        }

        return p;
    }

    public List<T> ObtenerTodos()
    {
        List<T> personas;

        using (AppDbContext context = new AppDbContext())
        {
            personas = context.Set<T>().ToList();
        }

        return personas;
    }

    public T Actualizar(T p)
    {
        using (AppDbContext context = new AppDbContext())
        {
            context.Set<T>().Update(p);

            context.SaveChanges();
        }

        return p;
    }

    public void Eliminar(T p)
    {
        using (AppDbContext context = new AppDbContext())
        {
            context.Set<T>().Remove(p);

            context.SaveChanges();
        }
    }
}