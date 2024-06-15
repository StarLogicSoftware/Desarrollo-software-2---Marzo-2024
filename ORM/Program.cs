
// ORM -> Object Relational Mapping
// Entity Framework Core
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


// CRUD -> Create, Read, Update, Delete

Persona Crear(Persona p)
{
    using (AppDbContext context = new AppDbContext())
    {
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
        p = context.Personas.Where(x => x.Nombre == "nicolas").First();
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

        //optionsBuilder.UseInMemoryDatabase("Db");
        optionsBuilder.UseSqlite("Data Source=datos.db");
    }

    // dice que a "Persona" Lo transforma en una tabla en la BD
    public DbSet<Persona> Personas { get; set; }
}

class Persona // Entidad -> Modelo
{
    public int Id { get; set; } // Por convencion se debe llamar "Id"

    [Required(ErrorMessage ="El nombre de la persona es requerido")]
    public string Nombre { get; set; }
    [Required]
    public string Apellido { get; set; }

    public int Edad { get; set; }

}
