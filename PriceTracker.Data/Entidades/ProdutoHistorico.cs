using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceTracker.Data;

[Table("PRODUTOHISTORICO")]
public class ProdutoHistorico
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID_PRODUTO_HISTORICO { get; set; }
    public long ID_PRODUTO_SITE { get; set; }
    public decimal VL_PRODUTO { get; set; }
    public DateTime DT_PROCURA { get; set; } = DateTime.Now;

    [ForeignKey("ID_PRODUTO_SITE")]
    public ProdutoSite? ProdutoSite { get; set; }
}

