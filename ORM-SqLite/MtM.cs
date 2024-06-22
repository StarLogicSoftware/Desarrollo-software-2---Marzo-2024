using Microsoft.EntityFrameworkCore;

public class Alumno
{
    public int AlumnoId { get; set; }
    public string Nombre { get; set; }
    public ICollection<Inscripcion> Inscripciones { get; set; }
}
public class Curso
{
    public int CursoId { get; set; }
    public string Nombre { get; set; }
    public ICollection<Inscripcion> Inscripciones { get; set; }
}
public class Inscripcion
{
    public int AlumnoId { get; set; }
    public Alumno Alumno { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }
}
public class AppDbContext : DbContext
{
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inscripcion>()
            .HasKey(i => new { i.AlumnoId, i.CursoId });

        modelBuilder.Entity<Inscripcion>()
            .HasOne(i => i.Alumno)
            .WithMany(a => a.Inscripciones)
            .HasForeignKey(i => i.AlumnoId);

        modelBuilder.Entity<Inscripcion>()
            .HasOne(i => i.Curso)
            .WithMany(c => c.Inscripciones)
            .HasForeignKey(i => i.CursoId);
    }
}
