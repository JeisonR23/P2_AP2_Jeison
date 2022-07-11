
using System.ComponentModel.DataAnnotations;

public class Vitaminas
{
    [Key]
    public int VitaminaId { get; set; }
    public String Descripcion { get; set; }

    public double UnidadDeMedida { get; set; }
    
}