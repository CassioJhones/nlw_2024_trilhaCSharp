using RocketSeatSolution.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace RocketSeatSolution.API.Entities;

[Table("Items")]
public class Item
{//Essa classe ITEM faz referencia a Tabela ITEMS do banco de dados
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public CondicaoDoItem Condition { get; set; }
    public decimal BasePrice { get; set; }
    public int AuctionID { get; set; }
}
//cada propriedade da classe é uma coluna na tabela do banco de dados