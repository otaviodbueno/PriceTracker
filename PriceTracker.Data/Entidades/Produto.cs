using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceTracker.Data;

[Table("PRODUTO")]
public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID_PRODUTO { get; set; }
    public string? NM_PRODUTO { get; set; }
    public DateTime DT_CRIACAO { get; set; } = DateTime.Now;
}

