using System.ComponentModel.DataAnnotations;

public class VerdurasDetalle
{
    [Key]
    public int Id { get; set; }

    public int VerduraId { get; set; }

    public int VitaminaId { get; set; }

    public double Cantidad { get; set; }
    

}