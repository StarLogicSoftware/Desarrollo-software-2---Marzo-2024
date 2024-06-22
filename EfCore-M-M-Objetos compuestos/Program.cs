// Objetos compuestos y EF Core

using Microsoft.EntityFrameworkCore;

//Curso curso = new Curso();
//curso.Nombre = "Programacion";

//Alumno a1 = new Alumno();
//a1.NombreAlumno = "Pepe";

//Alumno a2 = new Alumno();
//a2.NombreAlumno = "Mariano";

//Inscripcion insc = new Inscripcion();
//insc.Curso = curso;
//insc.Alumno = a1;
//insc.Nota = 5;
////curso.Alumnos.Add(a1);
////curso.Alumnos.Add(a2);

using (var context = new AppDbContext())
{
    //context.Add(insc);
    //int resultado = context.SaveChanges();
    //Console.WriteLine($"Se han guardado con exito los datos - {resultado}");

    var curso = context.Cursos
        .Where(x => x.Id == 1)
        .Include(x=> x.Alumnos)
        .ThenInclude(a => a.Alumno)
        .Single();

    Inscripcion insc = new Inscripcion();
    insc.AlumnoId = 2;

    curso.Alumnos.Add(insc);

    //context.SaveChanges();

    foreach (var item in curso.Alumnos)
    {
        Console.WriteLine($"Alumno: {item.Alumno.NombreAlumno}");
        Console.WriteLine($"Nota: {item.Nota}");
    }
}

class AppDbContext : DbContext
{
    public AppDbContext()
    {
        //Database.EnsureCreated();
        //Database.Migrate();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var rutaBase = AppDomain.CurrentDomain.BaseDirectory;
        var rutaProyecto = Path.GetFullPath(Path.Combine(rutaBase, @"..\..\..\"));

        // Crea la ruta del archivo dinamicamente, para usar siempre la misma
        var rutaBd = Path.Combine(rutaProyecto, "sqlite.db");

        optionsBuilder.UseSqlite($"Data Source={rutaBd}");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Crea una >clave primaria compuesta< por dos ids (alumno y curso)
        modelBuilder.Entity<Inscripcion>()
            .HasKey( insc => new { insc.AlumnoId, insc.CursoId });

        modelBuilder.Entity<Inscripcion>()
            .HasOne(insc => insc.Alumno)
            .WithMany(alum => alum.Cursos)
            .HasForeignKey(insc => insc.AlumnoId);

        modelBuilder.Entity<Inscripcion>()
            .HasOne(insc => insc.Curso)
            .WithMany(curs => curs.Alumnos)
            .HasForeignKey(insc => insc.CursoId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }
}

class Curso
{
    public Curso()
    {
        Alumnos = new List<Inscripcion>();
    }
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Inscripcion> Alumnos { get; set; }
}

class Alumno
{
    public int Id { get; set; }
    public string NombreAlumno { get; set; }
    public List<Inscripcion> Cursos { get; set; }
}

class Inscripcion
{
    public int AlumnoId { get; set; }
    public Alumno Alumno { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }
    public int Nota { get; set; }
}