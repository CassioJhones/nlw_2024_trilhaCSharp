namespace RocketSeatSolution.API.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;   
}
//Essa classe USER faz referencia a Tabela USERS do banco de dados
//cada propriedade da classe é uma coluna na tabela do banco de dados