namespace RocketSeatSolution.API.Entities;

public class Auction
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Starts { get; set; }
    public DateTime Ends { get; set; }
    public List<Item> Items { get; set; } = [];
}
//Essa classe AUCTION faz referencia a Tabela AUCTION do banco de dados
//cada propriedade da classe é uma coluna na tabela do banco de dados