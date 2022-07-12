
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
                UnidadMedida = "Miligramos"
                

            },
            new Vitaminas
            {
                VitaminaId = 2,
                Descripcion = "Vitamina C",
                UnidadMedida = "Kilosgramos",
                Existencia = 0
            },
                new Vitaminas
            {
                VitaminaId = 3,
                Descripcion = "Vitamina A",
                UnidadMedida = "Gramos",
                Existencia = 0
                
            },
                new Vitaminas
            {
                VitaminaId = 4,
                Descripcion = "Vitamina D",
                UnidadMedida = "Gramos",
                Existencia = 0
                
            }

        );

    }
    
}