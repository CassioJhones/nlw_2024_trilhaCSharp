using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatSolution.API.Contratos;
using RocketSeatSolution.API.Entities;
using RocketSeatSolution.API.Enums;
using RocketSeatSolution.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCasesTest.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTeste
{
    [Fact]
    public void Sucesso()
    {
        //ARRANGE
        //Criacão das informações ficticias para usar nos testes unitarios
        Auction UsuarioFake = new Faker<Auction>()
            .RuleFor(leilao => leilao.Id, fake => fake.Random.Number(1, 10))
            .RuleFor(leilao => leilao.Name, fake => fake.Lorem.Word())
            .RuleFor(leilao => leilao.Starts, fake => fake.Date.Past())
            .RuleFor(leilao => leilao.Ends, fake => fake.Date.Future())
            .RuleFor(leilao => leilao.Items, (fake, leilao) => new List<Item>
            {
                new Item
                {
                    Id = fake.Random.Number(1, 10),
                    Name = fake.Commerce.ProductName(),
                    Brand = fake.Commerce.Department(),
                    BasePrice = fake.Random.Decimal(50,1000),
                    Condition = fake.PickRandom<CondicaoDoItem>(),
                    AuctionID = leilao.Id
                }
            }).Generate();

        var mock = new Mock<IRepositorioLeilao>();
        mock.Setup(x => x.GetCurrent()).Returns(UsuarioFake);
        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        //ACT
        var leilao = useCase.Execute();
        //ASSERT
        leilao.Should().NotBeNull();
        leilao.Id.Should().Be(leilao.Id);
        leilao.Name.Should().Be(leilao.Name);
        
    }
}
