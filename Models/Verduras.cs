
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Verduras
{
    [Key]
    public int VerduraId { get; set; }

    public DateTime FechaCreacion { get; set; } =  DateTime.Now;

    public String Nombre { get; set; }

    public String Observaciones { get; set; }

    [ForeignKey("VerduraId")]

    public List<VerdurasDetalle> Detalle {get; set;} = new List<VerdurasDetalle>();

}