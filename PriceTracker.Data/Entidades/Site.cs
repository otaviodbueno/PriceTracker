using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceTracker.Data;

[Table("SITE")]
public class Site
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID_SITE { get; set; }
    public string? NM_SITE { get; set; }
    public DateTime DT_CRIACAO { get; set; } = DateTime.Now;
}

