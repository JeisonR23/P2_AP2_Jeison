
using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Verduras> Verduras {get; set;}
    public DbSet<Vitaminas> Vitaminas{ get; set;}


    public Contexto (DbContextOptions<Contexto> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Vitaminas>().HasData
        (
            new Vitaminas
            {
                VitaminaId = 1,
                Descripcion = "Vitamina B2",
                UnidadDeMedida = 2.5
                

            },
            new Vitaminas
            {
                VitaminaId = 2,
                Descripcion = "Vitamina C",
                UnidadDeMedida = 2
            },
                new Vitaminas
            {
                VitaminaId = 3,
                Descripcion = "Vitamina A",
                UnidadDeMedida = 2
            },
                new Vitaminas
            {
                VitaminaId = 4,
                Descripcion = "Vitamina D",
                UnidadDeMedida = 3
            }

        );

    }
    
}