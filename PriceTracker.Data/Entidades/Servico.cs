using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceTracker.Data;

[Table("SERVICO")]
public class Servico
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID_SERVICO { get; set; }
    public string? NM_SERVICO { get; set; }
    public int NU_MINUTOS_INTERVALO { get; set; }
    public DateTime DT_ULTIMA_EXECUCAO { get; set; }
    public DateTime DT_PROXIMA_EXECUCAO { get; set; }
}

