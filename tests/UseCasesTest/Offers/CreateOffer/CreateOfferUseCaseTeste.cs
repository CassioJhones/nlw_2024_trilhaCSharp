using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatSolution.API.Comunication.Request;
using RocketSeatSolution.API.Contratos;
using RocketSeatSolution.API.Entities;
using RocketSeatSolution.API.Services;
using RocketSeatSolution.API.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCasesTest.Offers.CreateOffer;

public class CreateOfferUseCaseTeste
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Sucesso(int itemId)
    {
        //ARRANGE
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, fake => fake.Random.Decimal(1, 700)).Generate();

        var RepositorioOferta = new Mock<IRepositorioOferta>();
        var usuarioLogado = new Mock<IUsuarioLogado>();
        usuarioLogado.Setup(x => x.Usuario()).Returns(new User());

        var useCase = new CreateOfferUseCase(usuarioLogado.Object, RepositorioOferta.Object);

        //ACT
        var act = ()=>useCase.Execute(itemId, request);

        //ASSERT
        act.Should().NotThrow();    
    }
}
