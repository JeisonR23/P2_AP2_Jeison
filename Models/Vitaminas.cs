
using System.ComponentModel.DataAnnotations;

public class Vitaminas
{
    [Key]
    public int VitaminaId { get; set; }
    
    public String Descripcion { get; set; }

    public String UnidadMedida { get; set; }
    
    public double Existencia { get; set; }
}