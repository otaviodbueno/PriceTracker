using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceTracker.Data;

[Table("PRODUTOSITE")]
public class ProdutoSite
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID_PRODUTO_SITE { get; set; }
    public long ID_PRODUTO { get; set; }
    public long ID_SITE { get; set; }
    public string? DS_URL_PRODUTO { get; set; }
    public short IN_ATIVO { get; set; }
    public DateTime DT_CRIACAO { get; set; }

    [ForeignKey("ID_PRODUTO")]
    public Produto? Produto { get; set; }

    [ForeignKey("ID_SITE")]
    public Site? Site { get; set; }
}

