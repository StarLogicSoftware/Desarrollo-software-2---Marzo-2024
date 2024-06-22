
// ORM -> Object Relational Mapping
// Entity Framework Core
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var repo = new RepositorioGenerico<Persona>();

var persona = new Persona() { Nombre = "carlos", Apellido = "Rubiez" };

repo.Crear(persona);

class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        // Nueva forma para evitar tener mas de un archivo de BD
        // Aqui obtenemos la ruta de donde estamos ejecutando la aplicación
        var rutaBase = AppDomain.CurrentDomain.BaseDirectory;
        var rutaProyecto = Path.GetFullPath(Path.Combine(rutaBase, @"..\..\..\"));

        // Crea la ruta del archivo dinamicamente, para usar siempre la misma
        var rutaBd = Path.Combine(rutaProyecto, "sqlite.db");

        // Y usamos esta ruta para los proyectos
        optionsBuilder.UseSqlite($"Data Source={rutaBd}");
       
       // Forma antigua, donde cada version del programa tiene su propia db
       // optionsBuilder.UseSqlite("Data Source=datos.db");
    }

    // dice que a "Persona" Lo transforma en una tabla en la BD
    public DbSet<Persona> Personas { get; set; }
}

abstract class BaseEntidad
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
